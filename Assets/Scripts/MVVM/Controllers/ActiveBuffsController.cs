using System.Collections.Generic;
using DTO.Configurations;
using ScriptableObjects;
using UniRx;
using UnityEngine;

namespace MVVM.Controllers
{
    public class ActiveBuffsController : ModelsController
    {
        public ActiveBuffsController(BuffsConfigDataSo buffsConfigDataSo)
        {
            _buffsConfigDataSo = buffsConfigDataSo;
        }
        public Dictionary<string, BuffConfigDto> CurrentBuffs { get; private set; } = new();

        private readonly BuffsConfigDataSo _buffsConfigDataSo;
        public readonly ReactiveCommand<BuffConfigDto> OnGetBuff = new();
        public readonly ReactiveCommand<BuffConfigDto> OnEndBuff = new();
        public readonly ReactiveCommand MaximumNumbersOfBuffs = new();

        private bool _canAddBuff = true;

        public void SetNewBuff()
        {
            if (!_canAddBuff)
            {
                MaximumNumbersOfBuffs.Execute();
                return;
            }
            
            if (CurrentBuffs.Count >= 2)
            {
                MaximumNumbersOfBuffs.Execute();
                return;
            }

            BuffConfigDto newBuff;

            do
            {
                int r = Random.Range(0, _buffsConfigDataSo.buffsList.Count);
                newBuff = _buffsConfigDataSo.buffsList[r];
            } while (CurrentBuffs.ContainsKey(newBuff.title));

            CurrentBuffs.Add(newBuff.title, newBuff);
            OnGetBuff.Execute(newBuff);

            _canAddBuff = false;
        }

        public void RemoveBuff(string key)
        {
            var buff = CurrentBuffs[key];
            CurrentBuffs.Remove(key);
            OnEndBuff.Execute(buff);
        }

        public override void Restart()
        {
            base.Restart();

            _canAddBuff = true;
            CurrentBuffs.Clear();
        }

        public override void RoundEnd()
        {
            base.RoundEnd();

            _canAddBuff = true;
        }
    }
}