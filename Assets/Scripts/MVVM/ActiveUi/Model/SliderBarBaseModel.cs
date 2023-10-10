using System;
using DTO.Matchmaking;
using MVVM.Controllers;
using UniRx;
using UnityEngine;

namespace MVVM.ActiveUi.Model
{
    public class SliderBarBaseModel : Core.Model
    {
        private PlayerConfigController _configController;
       
        public ReactiveCommand<PlayerStatDto> OnSetNewStat = new();

        public SliderBarBaseModel(PlayerConfigController configController)
        {
            _configController = configController;
        }

        protected override void Subscribe(Action onSubscribe)
        {
            base.Subscribe(() =>
            {
                _configController.OnSetNewStat.Subscribe(SetNewStat).AddTo(Disposable);
            });
        }

        private void SetNewStat(PlayerStatDto playerStatDto)
        {
            Debug.Log("Set new stat in SliderBarBaseModel");
            OnSetNewStat.Execute(playerStatDto);
        }
    }
}