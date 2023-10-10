using System;
using DTO.Configurations;
using DTO.Matchmaking;
using MVVM.Controllers;
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

        // public ReactiveCommand<PlayerStatDto> OnSetStat = new();

        public AttackModel(ActiveBuffsController activeBuffsController, 
            PlayerConfigController playerConfigController,
            AttackController attackController)
        {
            _buffsController = activeBuffsController;
            _playerConfigController = playerConfigController;
            _attackController = attackController;
        }

        private int _damage;

        protected override void Subscribe(Action onSubscribe)
        {
            base.Subscribe(() =>
            {
                _playerConfigController.OnSetNewStat.Subscribe(SetBaseAttack).AddTo(Disposable);
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
            _attackData.damage = _damage;
            _attackData = _attackDataService.SetAttackData(_attackData, _buffsController.CurrentBuffs.Values);
        }

        private void SetBaseAttack(PlayerStatDto config)
        {
            _damage = config.damage;
            // OnSetStat.Execute(config);
        }

       
    }
}