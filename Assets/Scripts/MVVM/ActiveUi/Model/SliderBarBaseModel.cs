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

        public ReactiveCommand<BasePlayerConfig> OnSetConfig = new();

        public SliderBarBaseModel(PlayerConfigController configController)
        {
            _configController = configController;
            
            _configController.InitializeSliders.Subscribe(InitializeSliders).AddTo(Disposable);
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