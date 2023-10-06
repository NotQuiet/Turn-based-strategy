using ScriptableObjects;
using UniRx;

namespace MVVM.Controllers
{
    public class PlayerConfigController : ModelsController
    {
        private PlayerDataConfigurationSo _startData;

        public ReactiveCommand<PlayerDataConfigurationSo> InitializeSliders = new();
        
        public PlayerConfigController(PlayerDataConfigurationSo data)
        {
            _startData = data;
        }

        public override void OnInitialize()
        {
            InitializeSliders.Execute(_startData);
        }
    }
}