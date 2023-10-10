using DTO.Matchmaking;
using UnityEngine;

namespace MVVM.ActiveUi.View
{
    public class ArmorBarView : SliderBarBaseView
    {
        protected override void OnSetNewStat(PlayerStatDto newStat)
        {
            Debug.Log("Set new armor stat");
            
            slider.maxValue = newStat.maxArmor;
            slider.value = newStat.armor;
            
            sliderValue.text = $"{newStat.armor}/{newStat.maxArmor}";
        }
    }
}