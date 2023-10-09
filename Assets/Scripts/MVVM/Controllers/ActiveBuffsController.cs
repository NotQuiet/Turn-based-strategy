using System.Collections.Generic;
using DTO.Configurations;
using ScriptableObjects;
using UniRx;
using UnityEngine;

namespace MVVM.Controllers
{
    public class ActiveBuffsController : ModelsController
    {
        private BuffsConfigDataSo _buffsConfigDataSo;

        public Dictionary<string, BuffConfigDto> CurrentBuffs { get; private set; } = new();

        public ActiveBuffsController(BuffsConfigDataSo buffsConfigDataSo)
        {
            _buffsConfigDataSo = buffsConfigDataSo;
        }

        public ReactiveCommand<BuffConfigDto> OnGetBuff = new();
        public ReactiveCommand MaximumNumbersOfBuffs = new();

        public void SetNewBuff()
        {
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
        }

        public void RemoveBuff(string key)
        {
            CurrentBuffs.Remove(key);
        }
    }
}