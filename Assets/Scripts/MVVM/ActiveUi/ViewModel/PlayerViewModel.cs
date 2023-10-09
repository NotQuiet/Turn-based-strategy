using Managers;
using MVVM.ActiveUi.Model;
using MVVM.Core;

namespace MVVM.ActiveUi.ViewModel
{
    public class PlayerViewModel : ViewModel<PlayerModel>
    {
        public PlayerViewModel(PlayerModel model) : base(model)
        {
        }

        public void InitializePlayer(Enums.Enums.PlayerOriented oriented, FightManager fightManager)
        {
            Model.InitializePlayer(oriented, fightManager);
        }
    }
}