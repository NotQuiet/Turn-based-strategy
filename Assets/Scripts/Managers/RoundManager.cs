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
        [SerializeField] private PlayerUiMvvmStarter leftStarterInitializer;
        [SerializeField] private PlayerUiMvvmStarter rightStarterInitializer;

        [SerializeField] private PlayerUiController leftPanel;
        [SerializeField] private PlayerUiController rightPanel;
        
        private readonly PlayersTurnDto _playersTurn = new();
        private CompositeDisposable _disposable = new();
        private List<ModelsController> _gameControllers = new ();
        
        private int _currentRound = 1;

        private int timeInit = 0;
        
        private void Awake()
        {
            leftStarterInitializer.OnControllersInitialized.Subscribe(OnControllersInitialized).AddTo(_disposable);
            rightStarterInitializer.OnControllersInitialized.Subscribe(OnControllersInitialized).AddTo(_disposable);
        }

        private void OnControllersInitialized(List<ModelsController> controllers)
        {
            foreach (var controller in controllers)
            {
                _gameControllers.Add(controller);
            }

            timeInit++;
            
            if(timeInit > 1)
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

            if(_playersTurn.RoundIsEnd())
                NextRound();
            
            ActivateUi();
        }

        private void ActivateUi()
        {
            if (_playersTurn.FirstIsReady())
            {
                ActivateSecond();
            }
            else
            {
                ActivateFirst();
            }
        }

        private void ActivateFirst()
        {
            leftPanel.Activate();
            rightPanel.Deactivate();
        }

        private void ActivateSecond()
        {
            leftPanel.Deactivate();
            rightPanel.Activate();
        }

        private void NextRound()
        {
            OnRoundEnd();
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

        private void OnRoundEnd()
        {
            foreach (var controller in _gameControllers)
            {
                controller.RoundEnd();
            }
        }
    }
}
