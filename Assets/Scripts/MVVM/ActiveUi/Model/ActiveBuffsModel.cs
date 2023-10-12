using System;
using Buffs;
using MVVM.Controllers;
using UniRx;

namespace MVVM.ActiveUi.Model
{
    public class ActiveBuffsModel : Core.Model
    {
        private ActiveBuffsController _buffsController;
        public ReactiveCommand<BaseBuff> GetBuff = new();
        public ReactiveCommand OnRoundEnd = new();
        public ReactiveCommand OnRestart = new();

        public ActiveBuffsModel(ActiveBuffsController controller)
        {
            _buffsController = controller;
        }

        protected override void Subscribe(Action onSubscribe)
        {
            base.Subscribe(() =>
            {
                _buffsController.OnGetBuff.Subscribe(OnGetBuff).AddTo(Disposable);
                _buffsController.OnRoundEnd.Subscribe(_ => RoundEnd()).AddTo(Disposable);

                _buffsController.OnRestart.Subscribe(_ => Restart()).AddTo(Disposable);
            });
        }

        public void BuffEnd(string title)
        {
            _buffsController.RemoveBuff(title);
        }

        private void Restart()
        {
            OnRestart.Execute();
        }

        private void RoundEnd()
        {
            OnRoundEnd.Execute();
        }

        private void OnGetBuff(BaseBuff config)
        {
            GetBuff.Execute(config);
        }
    }
}