using System.Globalization;
using DTO.Configurations;
using UniRx;

namespace MVVM.ActiveUi.View
{
    public class ArmorBarView : SliderBarBaseView
    {
        protected override void Subscribe()
        {
            base.Subscribe();
            
            ViewModel.OnGetBuff.Subscribe(OnGetBuff).AddTo(Disposable);
            ViewModel.OnEndBuff.Subscribe(OnEndBuff).AddTo(Disposable);
        }

        private void OnGetBuff(BuffConfigDto buff)
        {
            if (slider.value + buff.armorToSelf < slider.maxValue)
                slider.value += buff.armorToSelf;
            else
                slider.value = slider.maxValue;
            
            sliderValue.text = sliderValue.text = $"{slider.value.ToString(CultureInfo.InvariantCulture)}/{slider.maxValue}";
        }

        private void OnEndBuff(BuffConfigDto buff)
        {
            if (slider.value - buff.armorToSelf > 0)
                slider.value -= buff.armorToSelf;
            else
                slider.value = 0;
            
            sliderValue.text = sliderValue.text = $"{slider.value.ToString(CultureInfo.InvariantCulture)}/{slider.maxValue}";
        }
    }
}