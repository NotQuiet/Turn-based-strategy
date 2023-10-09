using DTO.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UiCells.Buffs
{
    public class BuffCell : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI title;
        [SerializeField] private TextMeshProUGUI lifeCount;
        
        [SerializeField] private Image buffImage;

        public void InitializeUi(BuffCellUiDto buffUiDto, int lifeTime)
        {
            title.text = buffUiDto.title;
            lifeCount.text = lifeTime.ToString();
            buffImage.sprite = buffUiDto.buffImage;
        }
    }
}