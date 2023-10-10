using DTO.Matchmaking;

namespace MVVM.ActiveUi.View
{
    public class HealthBarView : SliderBarBaseView
    {
        protected override void OnSetNewStat(PlayerStatDto newStat)
        {
            base.OnSetNewStat(newStat);

            slider.value = newStat.health;
            sliderValue.text = newStat.health.ToString();
        }
    }
}