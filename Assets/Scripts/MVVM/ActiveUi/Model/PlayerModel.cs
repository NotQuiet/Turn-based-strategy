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
        private BuffPerformerService _buffPerformerService;

        private Enums.Enums.PlayerOriented _oriented;
        private FightManager _fightManager;
        
        // is die
        public ReactiveCommand<bool> GetDamage = new ();
        
        public ReactiveCommand Restart = new ();

        public PlayerModel(AttackController attackController, PlayerConfigController playerConfigController,
            ActiveBuffsController activeBuffsController)
        {
            _playerStat = new PlayerStatDto();
            _damagePerformerService = new DamagePerformerService();
            _buffPerformerService = new BuffPerformerService();
            
            _attackController = attackController;
            _playerConfigController = playerConfigController;
            _activeBuffsController = activeBuffsController;

            Subscribe();
        }

        private void Subscribe()
        {
            _attackController.OnAttack.Subscribe(MakeAttack).AddTo(Disposable);
            _playerConfigController.InitializePLayerBaseConfig.Subscribe(InitializeBaseConfig).AddTo(Disposable);
            
            _activeBuffsController.OnGetBuff.Subscribe(OnGetBuff).AddTo(Disposable);
            _activeBuffsController.OnEndBuff.Subscribe(OnEndBuff).AddTo(Disposable);

            _activeBuffsController.OnRestart.Subscribe(_ => OnRestart()).AddTo(Disposable);
        }
        
        public void InitializePlayer(Enums.Enums.PlayerOriented oriented, FightManager fightManager)
        {
            _oriented = oriented;
            _fightManager = fightManager;

            _fightManager.OnGetDamage.Subscribe(OnGetDamage).AddTo(Disposable);
        }

        public void Die()
        {
            OnPlayerDie();

        }

        private void InitializeBaseConfig(PlayerDataConfigurationSo baseConfig)
        {
            foreach (var config in baseConfig.playerConfigurations)
            {
                switch (config.playerConfigurationType)
                {
                    case Enums.Enums.PlayerConfigurationType.Health:
                        _playerStat.health = config.data.currentValue;
                        _playerStat.maxHealth = config.data.maxValue;
                        break;
                    case Enums.Enums.PlayerConfigurationType.Damage:
                        _playerStat.damage = config.data.currentValue;
                        _playerStat.maxDamage = config.data.maxValue;

                        break;
                    case Enums.Enums.PlayerConfigurationType.Armor:
                        _playerStat.armor = config.data.currentValue;
                        _playerStat.maxArmor = config.data.maxValue;
                        break;
                    case Enums.Enums.PlayerConfigurationType.Vampirism:
                        _playerStat.vampirism = config.data.currentValue;
                        _playerStat.maxVampirism = config.data.maxValue;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
            
            _playerConfigController.SetNewStat(_playerStat);
        }

        private void OnRestart()
        {
            Restart.Execute();
        }

        private void MakeAttack(AttackDataDto attackDataDto)
        {
            _fightManager.MakeAttack(_oriented, attackDataDto);
        }

        private void OnGetDamage((Enums.Enums.PlayerOriented oriented, AttackDataDto attackDataDto) data)
        {
            if(data.oriented == _oriented) return;
            
            _playerStat = _damagePerformerService.DamageCalculation(_playerStat, data.attackDataDto);
            
            _playerConfigController.SetNewStat(_playerStat);
            
            GetDamage.Execute(_playerStat.health <= 0);
        }

        private void OnGetBuff(BuffConfigDto buff)
        {
            _playerStat = _buffPerformerService.SetBuff(buff, _playerStat);
            
            _playerConfigController.SetNewStat(_playerStat);
        }
        
        private void OnEndBuff(BuffConfigDto buff)
        {
            _playerStat = _buffPerformerService.EndBuff(buff, _playerStat);
            
            _playerConfigController.SetNewStat(_playerStat);
        }

        private void OnPlayerDie()
        {
            _fightManager.PlayerDie();
        }
    }
}