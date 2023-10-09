using System;
using DTO.Configurations;
using DTO.Matchmaking;
using Managers;
using MVVM.Controllers;
using ScriptableObjects;
using Services;
using UniRx;

namespace MVVM.ActiveUi.Model
{
    public class PlayerModel : Core.Model
    {
        private PlayerStatDto _playerStat;
        
        private AttackController _attackController;
        private PlayerConfigController _playerConfigController;
        private ActiveBuffsController _activeBuffsController;

        private DamagePerformerService _damagePerformerService;

        private Enums.Enums.PlayerOriented _oriented;
        private FightManager _fightManager;

        public PlayerModel(AttackController attackController, PlayerConfigController playerConfigController,
            ActiveBuffsController activeBuffsController)
        {
            _playerStat = new PlayerStatDto();
            _damagePerformerService = new DamagePerformerService();

            _attackController = attackController;
            _playerConfigController = playerConfigController;
            _activeBuffsController = activeBuffsController;

            Subscribe();
        }

        private void Subscribe()
        {
            _attackController.OnAttack.Subscribe(MakeAttack).AddTo(Disposable);
            _playerConfigController.InitializePLayerBaseConfig.Subscribe(InitializeBaseConfig).AddTo(Disposable);
        }
        
        public void InitializePlayer(Enums.Enums.PlayerOriented oriented, FightManager fightManager)
        {
            _oriented = oriented;
            _fightManager = fightManager;

            _fightManager.OnGetDamage.Subscribe(OnGetDamage).AddTo(Disposable);
        }

        private void InitializeBaseConfig(PlayerDataConfigurationSo baseConfig)
        {
            foreach (var config in baseConfig.playerConfigurations)
            {
                switch (config.playerConfigurationType)
                {
                    case Enums.Enums.PlayerConfigurationType.Health:
                        _playerStat.health = config.data.currentValue;
                        break;
                    case Enums.Enums.PlayerConfigurationType.Damage:
                        break;
                    case Enums.Enums.PlayerConfigurationType.Armor:
                        _playerStat.armor = config.data.currentValue;
                        break;
                    case Enums.Enums.PlayerConfigurationType.Vampirism:
                        _playerStat.vampirism = config.data.currentValue;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        private void MakeAttack(AttackDataDto attackDataDto)
        {
            _fightManager.MakeAttack(_oriented, attackDataDto);
        }

        private void OnGetDamage((Enums.Enums.PlayerOriented oriented, AttackDataDto attackDataDto) data)
        {
            if(data.oriented == _oriented) return;
            
            _playerStat = _damagePerformerService.DamageCalculation(_playerStat, data.attackDataDto, 
                _activeBuffsController.CurrentBuffs.Values);
        }
    }
}