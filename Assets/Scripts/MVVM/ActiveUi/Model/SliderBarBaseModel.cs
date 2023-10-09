using System;
using DTO.Configurations;
using MVVM.Controllers;
using ScriptableObjects;
using UniRx;
using UnityEngine;

namespace MVVM.ActiveUi.Model
{
    public class SliderBarBaseModel : Core.Model
    {
        private PlayerConfigController _configController;
        private ActiveBuffsController _buffsController;

        public ReactiveCommand<BasePlayerConfig> OnSetConfig = new();
        public ReactiveCommand<BuffConfigDto> OnGetBuff = new();

        public SliderBarBaseModel(PlayerConfigController configController, ActiveBuffsController buffsController)
        {
            _configController = configController;
            _buffsController = buffsController;
            
        }

        protected override void Subscribe(Action onSubscribe)
        {
            base.Subscribe(() =>
            {
                _configController.InitializeSliders.Subscribe(InitializeSliders).AddTo(Disposable);
                _buffsController.OnGetBuff.Subscribe(OnBuff).AddTo(Disposable);
            });
        }

        private void OnBuff(BuffConfigDto buff)
        {
            OnGetBuff.Execute(buff);
        }

        private void InitializeSliders(PlayerDataConfigurationSo data)
        {
            foreach (var config in data.playerConfigurations)
            {
                Debug.Log($"Command to set data {config.playerConfigurationType}");
                OnSetConfig.Execute(config);
            }
        }
    }
}