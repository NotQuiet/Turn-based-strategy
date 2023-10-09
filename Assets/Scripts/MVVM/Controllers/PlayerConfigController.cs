using DTO.Matchmaking;
using ScriptableObjects;
using UniRx;

namespace MVVM.Controllers
{
    public class PlayerConfigController : ModelsController
    {
        private PlayerDataConfigurationSo _startData;

        public ReactiveCommand<PlayerDataConfigurationSo> InitializePLayerBaseConfig = new();
        public ReactiveCommand<PlayerStatDto> OnSetNewStat = new();
        
        public PlayerConfigController(PlayerDataConfigurationSo data)
        {
            _startData = data;
        }

        public void SetNewStat(PlayerStatDto newStat)
        {
            OnSetNewStat.Execute(newStat);
        }

        public override void OnInitialize()
        {
            InitializePLayerBaseConfig.Execute(_startData);
        }

        public override void Restart()
        {
            // base.Restart();
            
            OnInitialize();
        }
    }
}