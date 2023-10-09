using Managers;
using MVVM.ActiveUi.Model;
using MVVM.ActiveUi.ViewModel;
using MVVM.Core;
using UnityEngine;


namespace MVVM.ActiveUi.View
{
    public class PlayerView : View<PlayerViewModel, PlayerModel>
    {
        [SerializeField] private Enums.Enums.PlayerOriented playerOriented;
        [SerializeField] private FightManager fightManager;

        public override void Show()
        {
            base.Show();
            
            InitializePlayer();
        }

        private void InitializePlayer()
        {
            ViewModel.InitializePlayer(playerOriented, fightManager);
        }
        
    }
}