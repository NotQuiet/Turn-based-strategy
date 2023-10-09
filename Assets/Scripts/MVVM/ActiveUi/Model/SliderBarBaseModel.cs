using System;
using MVVM.Controllers;
using ScriptableObjects;
using UniRx;
using UnityEngine;

namespace MVVM.ActiveUi.Model
{
    public class SliderBarBaseModel : Core.Model
    {
        private PlayerConfigController _configController;
        private RestartController _restartController;

        public ReactiveCommand<BasePlayerConfig> OnSetConfig = new();

        public SliderBarBaseModel(PlayerConfigController configController)
        {
            _configController = configController;
        }

        protected override void Subscribe(Action onSubscribe)
        {
            base.Subscribe(() =>
            {
                _configController.InitializeSliders.Subscribe(InitializeSliders).AddTo(Disposable);
            });
        }

        private void InitializeSliders(PlayerDataConfigurationSo data)
        {
            foreach (var config in data.playerConfigurations)
            {
                OnSetConfig.Execute(config);
            }
        }
    }
}