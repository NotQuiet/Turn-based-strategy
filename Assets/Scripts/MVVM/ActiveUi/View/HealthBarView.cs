using DTO.Matchmaking;

namespace MVVM.ActiveUi.View
{
    public class HealthBarView : SliderBarBaseView
    {
        protected override void OnSetNewStat(PlayerStatDto newStat)
        {
            base.OnSetNewStat(newStat);
            
            slider.maxValue = newStat.maxHealth;
            slider.value = newStat.health;
            
            sliderValue.text = $"{newStat.health}/{newStat.maxHealth}";
        }
    }
}