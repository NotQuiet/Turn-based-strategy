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

        private Dictionary<string, BuffConfigDto> _currentBuffs = new();

        public ActiveBuffsController(BuffsConfigDataSo buffsConfigDataSo)
        {
            _buffsConfigDataSo = buffsConfigDataSo;
        }

        public ReactiveCommand<BuffConfigDto> OnGetBuff = new();

        public void SetNewBuff()
        {
            BuffConfigDto newBuff;
            
            int r = Random.Range(0, _buffsConfigDataSo.buffsList.Count);
            newBuff = _buffsConfigDataSo.buffsList[r];

            OnGetBuff.Execute(newBuff);
        }
    }
}