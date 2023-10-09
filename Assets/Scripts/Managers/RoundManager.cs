using System.Collections.Generic;
using DTO.Matchmaking;
using MVVM.Controllers;
using MVVM.Starters;
using TMPro;
using UniRx;
using UnityEngine;

namespace Managers
{
    public class RoundManager : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI roundCounter;
        [SerializeField] private PlayerUiMvvmStarter starterInitializer;

        private CompositeDisposable _disposable = new();
        
        private readonly PlayersTurnDto _playersTurn = new();
        private List<ModelsController> _gameControllers;
        
        private int _currentRound = 1;
        
        private void Awake()
        {
            starterInitializer.OnControllersInitialized.Subscribe(OnControllersInitialized).AddTo(_disposable);
        }

        private void OnControllersInitialized(List<ModelsController> controllers)
        {
            _gameControllers = controllers;
            
            SubscribesOnControllers();
        }

        private void SubscribesOnControllers()
        {
            foreach (var controller in _gameControllers)
            {
                if (controller is AttackController attackController)
                {
                    attackController.OnAttack.Subscribe(_ => OnPlayersTurn()).AddTo(_disposable);
                }
            }
        }

        private void OnPlayersTurn()
        {
            _playersTurn.OnPlayersTurn();

            Debug.Log("On player turn");
            
            if(_playersTurn.RoundIsEnd())
                NextRound();
        }

        private void NextRound()
        {
            _currentRound++;
            SetCurrentRound();
            _playersTurn.Restart();
        }

        public void Restart()
        {
            _playersTurn.Restart();
            RestartControllers();
        }

        private void SetCurrentRound()
        {
            roundCounter.text = _currentRound.ToString();
        }

        private void RestartControllers()
        {
            foreach (var controller in _gameControllers)
            {
                controller.Restart();
            }
        }
    }
}
