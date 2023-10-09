using DTO.UI;

namespace MVVM.ActiveUi.View
{
    public class DamageBarView : SliderBarBaseView
    {
        protected override void SetSliderValue((ConfigData, Enums.Enums.PlayerConfigurationType) cort)
        {
            if(playerConfigurationType != cort.Item2) return;
            
            sliderValue.text = $"{cort.Item1.currentValue}";
        }
    }
}