using System;
using MVVM.ActiveUi.Model;
using MVVM.Core;
using UniRx;

namespace MVVM.ActiveUi.ViewModel
{
    public class ApplyBuffViewModel : ViewModel<ApplyBuffModel>
    {
        public ReactiveCommand OnMaximumBuffs = new();
        
        public ApplyBuffViewModel(ApplyBuffModel model) : base(model)
        {
        }

        protected override void Subscribe(Action onSubscribe)
        {
            base.Subscribe(() =>
            {
                Model.OnMaximumBuffs.Subscribe(_ => MaximumBuffs()).AddTo(Disposable);
            });
        }

        public void OnApplyBuff()
        {
            Model.OnApplyBuff();
        }

        private void MaximumBuffs()
        {
            OnMaximumBuffs.Execute();
        }
    }
}