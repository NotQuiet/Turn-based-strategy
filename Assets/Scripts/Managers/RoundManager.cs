using System;
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
        
        private void Start()
        {
            starterInitializer.OnControllersInitialized.Subscribe(OnControllersInitialized).AddTo(_disposable);
        }

        private void OnControllersInitialized(List<ModelsController> controllers)
        {
            _gameControllers = controllers;
        }

        private void OnPlayersTurn()
        {
            _playersTurn.OnPlayersTurn();
            
            if(_playersTurn.RoundIsEnd())
                NextRound();
        }

        private void NextRound()
        {
            _currentRound++;
            SetCurrentRound();
        }

        public void RestartRound()
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
