using System;
using MVVM.Controllers;
using UniRx;
using UnityEngine;

namespace MVVM.ActiveUi.Model
{
    public class ApplyBuffModel : Core.Model
    {
        private ActiveBuffsController _buffsController;
        public ReactiveCommand OnMaximumBuffs = new();

        public ApplyBuffModel(ActiveBuffsController controller)
        {
            _buffsController = controller;
        }

        protected override void Subscribe(Action onSubscribe)
        {
            base.Subscribe(() =>
            {
                _buffsController.MaximumNumbersOfBuffs.Subscribe(_ => MaxBuffs()).AddTo(Disposable);
            });
        }

        public void OnApplyBuff()
        {
            _buffsController.SetNewBuff();
            Debug.Log("On buff apply!");
        }

        private void MaxBuffs()
        {
            OnMaximumBuffs.Execute();
        }
    }
}