using System;
using DTO.Configurations;
using MVVM.Controllers;
using ScriptableObjects;
using Services;
using UniRx;
using UnityEngine;

namespace MVVM.ActiveUi.Model
{
    public class AttackModel : Core.Model
    {
        private AttackDataDto _attackData = new();
        private CreateAttackDataService _attackDataService = new ();
        private ActiveBuffsController _buffsController;
        private PlayerConfigController _playerConfigController;
        private AttackController _attackController;

        public AttackModel(ActiveBuffsController activeBuffsController, 
            PlayerConfigController playerConfigController,
            AttackController attackController)
        {
            _buffsController = activeBuffsController;
            _playerConfigController = playerConfigController;
            _attackController = attackController;
        }

        private int _baseDamage;

        protected override void Subscribe(Action onSubscribe)
        {
            base.Subscribe(() =>
            {
                _playerConfigController.InitializePLayerBaseConfig.Subscribe(SetBaseAttack).AddTo(Disposable);
            });
        }

        public void OnAttack()
        {
            Debug.Log("On attack!");
            
            CreateAttackData();
            _attackController.Attack(_attackData);

            _attackData = new();
        }
        
        private void CreateAttackData()
        {
            _attackData.damage = _baseDamage;
            _attackData = _attackDataService.SetAttackData(_attackData, _buffsController.CurrentBuffs.Values);
        }

        private void SetBaseAttack(PlayerDataConfigurationSo config)
        {
            foreach (var data in config.playerConfigurations)
            {
                if (data.playerConfigurationType == Enums.Enums.PlayerConfigurationType.Damage)
                    _baseDamage = data.data.currentValue;
            }
        }

       
    }
}