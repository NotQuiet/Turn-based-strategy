using System;
using DTO.UI;
using MVVM.ActiveUi.Model;
using MVVM.Core;
using ScriptableObjects;
using UniRx;

namespace MVVM.ActiveUi.ViewModel
{
    public class SliderBarBaseViewModel : ViewModel<SliderBarBaseModel>
    {
        public SliderBarBaseViewModel(SliderBarBaseModel model) : base(model)
        {
        }

        public ReactiveCommand<(ConfigData, Enums.Enums.PlayerConfigurationType)> Initialize = new();

        protected override void Subscribe(Action onSubscribe)
        {
            base.Subscribe(() =>
            {
                Model.OnSetConfig.Subscribe(InitializeSlider).AddTo(Disposable);
            });
        }

        private void InitializeSlider(BasePlayerConfig config)
        {
            Initialize.Execute((config.data, config.playerConfigurationType));
        }
    }
}