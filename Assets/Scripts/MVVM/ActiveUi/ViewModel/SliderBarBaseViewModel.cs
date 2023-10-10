using System;
using DTO.Matchmaking;
using MVVM.ActiveUi.Model;
using MVVM.Core;
using UniRx;

namespace MVVM.ActiveUi.ViewModel
{
    public class SliderBarBaseViewModel : ViewModel<SliderBarBaseModel>
    {
        public SliderBarBaseViewModel(SliderBarBaseModel model) : base(model)
        {
        }

        public readonly ReactiveCommand<PlayerStatDto> OnSetNewStat = new();

        protected override void Subscribe(Action onSubscribe)
        {
            base.Subscribe(() =>
            {
                Model.OnSetNewStat.Subscribe(SetNewStat).AddTo(Disposable);
            });
        }

        private void SetNewStat(PlayerStatDto stat)
        {
            OnSetNewStat.Execute(stat);
        }
    }
}