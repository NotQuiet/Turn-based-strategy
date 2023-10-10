using System;
using Managers;
using MVVM.ActiveUi.Model;
using MVVM.Core;
using UniRx;

namespace MVVM.ActiveUi.ViewModel
{
    public class PlayerViewModel : ViewModel<PlayerModel>
    {
        public PlayerViewModel(PlayerModel model) : base(model)
        {
        }

        public ReactiveCommand<bool> OnGetDamage = new ();
        public ReactiveCommand Restart = new ();

        protected override void Subscribe(Action onSubscribe)
        {
            base.Subscribe(() =>
            {
                Model.GetDamage.Subscribe(GetDamage).AddTo(Disposable);
                Model.Restart.Subscribe(_ => OnRestart()).AddTo(Disposable);
            });
        }

        public void InitializePlayer(Enums.Enums.PlayerOriented oriented, FightManager fightManager)
        {
            Model.InitializePlayer(oriented, fightManager);
        }

        public void Die()
        {
            Model.Die();
        }

        private void GetDamage(bool isDie)
        {
            OnGetDamage.Execute(isDie);
        }
        
        private void OnRestart()
        {
            Restart.Execute();
        }
    }
}