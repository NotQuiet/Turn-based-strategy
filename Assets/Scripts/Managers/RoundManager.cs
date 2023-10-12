using System.Collections.Generic;
using DTO.Matchmaking;
using MVVM.Controllers;
using MVVM.Starters;
using TMPro;
using UniRx;
using UnityEngine;

namespace Managers
{
    public abstract class BaseState
    {
        public bool IsActive;
        
        public virtual void Activate()
        {
            IsActive = true;
        }
        
        public virtual void Deactivate()
        {
            IsActive = false;
        }
    }
    public class RoundState : BaseState
    {
        private PlayerUiController _uiPanel;
        public RoundState(PlayerUiController uiPanel, bool activeByDefault)
        {
            _uiPanel = uiPanel;

            IsActive = activeByDefault;

            if (IsActive)
                Activate();
            else 
                Deactivate();
        }

        public sealed override void Activate()
        {
            base.Activate();
            
            _uiPanel.Activate();
        }

        public sealed override void Deactivate()
        {
            base.Deactivate();
            
            _uiPanel.Deactivate();
        }
    }
    
    public class RoundManager : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI roundCounter;
        [SerializeField] private PlayerUiMvvmStarter leftStarterInitializer;
        [SerializeField] private PlayerUiMvvmStarter rightStarterInitializer;

        [SerializeField] private PlayerUiController leftPanel;
        [SerializeField] private PlayerUiController rightPanel;
        
        [SerializeField] private FightManager fightManager;
        
        private readonly PlayersTurnDto _playersTurn = new();
        private CompositeDisposable _disposable = new();
        private List<ModelsController> _gameControllers = new ();

        private List<RoundState> _states;

        private int _currentRound = 1;

        private int _timeInit = 0;
        
        private void Awake()
        {
            leftStarterInitializer.OnControllersInitialized.Subscribe(OnControllersInitialized).AddTo(_disposable);
            rightStarterInitializer.OnControllersInitialized.Subscribe(OnControllersInitialized).AddTo(_disposable);

            fightManager.OnMatchEnd.Subscribe(_ => Restart()).AddTo(_disposable);
            
            CreateStates();
        }

        private void CreateStates()
        {
            _states = new List<RoundState>
            {
                new(leftPanel, true),
                new(rightPanel, false)
            };
        }
        
        public void Restart()
        {
            _playersTurn.Restart();
            RestartControllers();
            _currentRound = 1;
            SetCurrentRound();
            CreateStates();
            // ActivateFirst();
        }

        private void OnControllersInitialized(List<ModelsController> controllers)
        {
            foreach (var controller in controllers)
            {
                _gameControllers.Add(controller);
            }

            _timeInit++;
            
            if(_timeInit > 1)
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
            foreach (var state in _states)
            {
                if (!state.IsActive)
                {
                    state.Activate();
                }
                else
                {
                    state.Deactivate();
                }
            }
            //
            //
            // if (_playersTurn.FirstIsReady())
            // {
            //     ActivateSecond();
            // }
            // else
            // {
            //     ActivateFirst();
            // }
        }

        // private void ActivateFirst()
        // {
        //     leftPanel.Activate();
        //     rightPanel.Deactivate();
        // }
        //
        // private void ActivateSecond()
        // {
        //     leftPanel.Deactivate();
        //     rightPanel.Activate();
        // }

        private void NextRound()
        {
            OnRoundEnd();
            _currentRound++;
            SetCurrentRound();
            _playersTurn.Restart();
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
