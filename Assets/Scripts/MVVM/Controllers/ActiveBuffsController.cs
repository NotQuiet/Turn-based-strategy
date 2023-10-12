using System.Collections.Generic;
using Buffs;
using ScriptableObjects;
using UniRx;
using UnityEngine;
using Random = UnityEngine.Random;

namespace MVVM.Controllers
{
    public class ActiveBuffsController : ModelsController
    {
        public ActiveBuffsController(BuffsConfigDataSo buffsConfigDataSo)
        {
            _buffsConfigDataSo = buffsConfigDataSo;
            CreateBuffsPool();
        }

        public Dictionary<Enums.Enums.BuffTitle, BaseBuff> CurrentBuffs { get; private set; } = new();

        private readonly BuffsConfigDataSo _buffsConfigDataSo;
        public readonly ReactiveCommand<BaseBuff> OnGetBuff = new();
        public readonly ReactiveCommand<BaseBuff> OnEndBuff = new();
        public readonly ReactiveCommand MaximumNumbersOfBuffs = new();

        private List<BaseBuff> _buffsPool = new();

        private bool _canAddBuff = true;

        private void CreateBuffsPool()
        {
            foreach (var buff in _buffsConfigDataSo.buffsList)
            {
                switch (buff.title)
                {
                    case Enums.Enums.BuffTitle.DoubleDamage:
                        _buffsPool.Add(new DamageBuff(buff));
                        break;
                    case Enums.Enums.BuffTitle.ArmorSelf:
                        _buffsPool.Add(new ArmorSelf(buff));
                        break;
                    case Enums.Enums.BuffTitle.ArmorDestruction:
                        _buffsPool.Add(new ArmorDestruction(buff));
                        break;
                    case Enums.Enums.BuffTitle.VampirismSelf:
                        _buffsPool.Add(new VampirismSelf(buff));
                        break;
                    case Enums.Enums.BuffTitle.VampirismDecrease:
                        _buffsPool.Add(new VampirismDecrease(buff));
                        break;
                    default:
                        break;
                }
            }
        }

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

            BaseBuff newBuff;

            do
            {
                int r = Random.Range(0, _buffsPool.Count);
                newBuff = _buffsPool[r];

                foreach (var buffs in _buffsPool)
                {
                    Debug.Log(buffs.GetType().Name);
                }
                
                
            } while (CurrentBuffs.ContainsKey(newBuff.title));

            CurrentBuffs.Add(newBuff.title, newBuff);
            OnGetBuff.Execute(newBuff);

            _canAddBuff = false;
        }

        public void RemoveBuff(Enums.Enums.BuffTitle key)
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