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

        public readonly ReactiveCommand<(ConfigData, Enums.Enums.PlayerConfigurationType)> Initialize = new();
        public readonly ReactiveCommand<BuffConfigDto> OnGetBuff = new();
        public readonly ReactiveCommand<BuffConfigDto> OnEndBuff = new();

        protected override void Subscribe(Action onSubscribe)
        {
            base.Subscribe(() =>
            {
                Model.OnSetConfig.Subscribe(InitializeSlider).AddTo(Disposable);
                Model.OnGetBuff.Subscribe(GetBuff).AddTo(Disposable);
                Model.OnEndBuff.Subscribe(EndBuff).AddTo(Disposable);
            });
        }

        private void GetBuff(BuffConfigDto buff)
        {
            OnGetBuff.Execute(buff);
        }
        
        private void EndBuff(BuffConfigDto buff)
        {
            OnEndBuff.Execute(buff);
        }
        
        private void InitializeSlider(BasePlayerConfig config)
        {
            Initialize.Execute((config.data, config.playerConfigurationType));
        }
    }
}