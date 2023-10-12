using System;
using DTO.UI;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace UiCells.Buffs
{
    public class BuffCell : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI title;
        [SerializeField] private TextMeshProUGUI lifeCount;
        
        [SerializeField] private Image buffImage;

        private Action<Enums.Enums.BuffTitle> _endLifetimeAction;

        private Enums.Enums.BuffTitle _thisTitle;
        private int _currentLifeTime;

        public void InitializeUi(BuffCellUiDto buffUiDto, Action<Enums.Enums.BuffTitle> endLifeTimeAction, int lifeTime)
        {
            _thisTitle = buffUiDto.title;
            title.text = buffUiDto.title.ToString();
            lifeCount.text = lifeTime.ToString();
            buffImage.sprite = buffUiDto.buffImage;

            _currentLifeTime = lifeTime;

            _endLifetimeAction = endLifeTimeAction;
        }

        public void OnRoundEnd()
        {
            if (_currentLifeTime <= 1)
            {
                _endLifetimeAction(_thisTitle);
            }
            else
            {
                _currentLifeTime--;
                lifeCount.text = _currentLifeTime.ToString();
            }
        }
    }
}