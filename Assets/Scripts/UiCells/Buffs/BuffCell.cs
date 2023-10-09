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

        private Action<string> _endLifetimeAction;

        private int _currentLifeTime;

        public void InitializeUi(BuffCellUiDto buffUiDto, Action<string> endLifeTimeAction, int lifeTime)
        {
            title.text = buffUiDto.title;
            lifeCount.text = lifeTime.ToString();
            buffImage.sprite = buffUiDto.buffImage;

            _currentLifeTime = lifeTime;

            _endLifetimeAction = endLifeTimeAction;
        }

        public void OnRoundEnd()
        {
            if (_currentLifeTime <= 1)
            {
                _endLifetimeAction(title.text);
            }
            else
            {
                _currentLifeTime--;
                lifeCount.text = _currentLifeTime.ToString();
            }
        }
    }
}