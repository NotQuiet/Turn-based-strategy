using DG.Tweening;
using Managers;
using MVVM.ActiveUi.Model;
using MVVM.ActiveUi.ViewModel;
using MVVM.Core;
using UniRx;
using UnityEngine;


namespace MVVM.ActiveUi.View
{
    public class PlayerView : View<PlayerViewModel, PlayerModel>
    {
        [SerializeField] private Enums.Enums.PlayerOriented playerOriented;
        [SerializeField] private FightManager fightManager;
        [SerializeField] private MeshRenderer playerMaterial;

        protected override void Subscribe()
        {
            base.Subscribe();

            ViewModel.OnGetDamage.Subscribe(OnGetDamage).AddTo(Disposable);
            ViewModel.Restart.Subscribe(_ => Restart()).AddTo(Disposable);
        }

        public override void Show()
        {
            base.Show();
            
            InitializePlayer();
        }

        private void InitializePlayer()
        {
            ViewModel.InitializePlayer(playerOriented, fightManager);
        }

        private void Restart()
        {
            DOTween.Sequence()
                .Append(transform.DOScale(new Vector3(1.1f, 1.1f, 1.1f), 0.3f))
                .Append(transform.DOScale(Vector3.one, 0.3f));
            
            DOTween.Sequence()
                .Append(playerMaterial.material.DOColor(Color.yellow, 0.3f))
                .Append(playerMaterial.material.DOColor(Color.white, 0.3f));
        }

        private void OnGetDamage(bool isDie)
        {
            DOTween.Sequence()
                .Append(transform.DOScale(new Vector3(1.1f, 1.1f, 1.1f), 0.3f))
                .Append(transform.DOScale(Vector3.one, 0.3f))
                .AppendCallback(() =>
                {
                    if (isDie)
                    {
                        DOTween.Sequence()
                            .Append(transform.DOScale(Vector3.zero, 0.3f))
                            .AppendCallback(() =>
                            {
                                ViewModel.Die();
                            });
                    }
                });
            
            DOTween.Sequence()
                .Append(playerMaterial.material.DOColor(Color.red, 0.3f))
                .Append(playerMaterial.material.DOColor(Color.white, 0.3f));
            
        }
    }
}