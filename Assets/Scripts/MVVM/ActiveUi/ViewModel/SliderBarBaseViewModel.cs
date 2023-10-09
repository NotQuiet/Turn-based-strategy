using System;
using DTO.Configurations;
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
        public ReactiveCommand<BuffConfigDto> OnGetBuff = new();

        protected override void Subscribe(Action onSubscribe)
        {
            base.Subscribe(() =>
            {
                Model.OnSetConfig.Subscribe(InitializeSlider).AddTo(Disposable);
                Model.OnGetBuff.Subscribe(GetBuff).AddTo(Disposable);
            });
        }

        private void GetBuff(BuffConfigDto buff)
        {
            OnGetBuff.Execute(buff);
        }

        private void InitializeSlider(BasePlayerConfig config)
        {
            Initialize.Execute((config.data, config.playerConfigurationType));
        }
    }
}