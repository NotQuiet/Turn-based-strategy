using ScriptableObjects;
using UniRx;
using UnityEngine;

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
            Debug.Log("OnInitialize");
            
            InitializeSliders.Execute(_startData);
        }
    }
}