using System;
using DTO.Configurations;
using MVVM.Controllers;
using UniRx;

namespace MVVM.ActiveUi.Model
{
    public class ActiveBuffsModel : Core.Model
    {
        private ActiveBuffsController _buffsController;
        public ReactiveCommand<BuffConfigDto> GetBuff = new();

        public ActiveBuffsModel(ActiveBuffsController controller)
        {
            _buffsController = controller;
        }

        protected override void Subscribe(Action onSubscribe)
        {
            base.Subscribe(() =>
            {
                _buffsController.OnGetBuff.Subscribe(OnGetBuff).AddTo(Disposable);
            });
        }


        private void OnGetBuff(BuffConfigDto config)
        {
            GetBuff.Execute(config);
        }
    }
}