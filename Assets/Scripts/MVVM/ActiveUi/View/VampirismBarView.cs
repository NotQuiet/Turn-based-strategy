using System.Globalization;
using DTO.Configurations;
using UniRx;

namespace MVVM.ActiveUi.View
{
    public class VampirismBarView : SliderBarBaseView
    {
        protected override void Subscribe()
        {
            base.Subscribe();
            
            ViewModel.OnGetBuff.Subscribe(OnGetBuff).AddTo(Disposable);
        }

        private void OnGetBuff(BuffConfigDto buff)
        {
            if (slider.value + buff.vampirismToSelf < slider.maxValue)
                slider.value += buff.vampirismToSelf;
            else
                slider.value = slider.maxValue;
            
            sliderValue.text = sliderValue.text = $"{slider.value.ToString(CultureInfo.InvariantCulture)}/{slider.maxValue}";
        }
    }
}