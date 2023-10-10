using System.Globalization;
using DTO.Configurations;
using DTO.Matchmaking;
using UniRx;

namespace MVVM.ActiveUi.View
{
    public class VampirismBarView : SliderBarBaseView
    {
        protected override void Subscribe()
        {
            base.Subscribe();
            
            ViewModel.OnGetBuff.Subscribe(OnGetBuff).AddTo(Disposable);
            ViewModel.OnEndBuff.Subscribe(OnEndBuff).AddTo(Disposable);
        }
        
        protected override void OnSetNewStat(PlayerStatDto newStat)
        {
            base.OnSetNewStat(newStat);

            slider.value = newStat.vampirism;
            sliderValue.text = newStat.vampirism.ToString();
        }

        private void OnGetBuff(BuffConfigDto buff)
        {
            if (slider.value + buff.vampirismToSelf < slider.maxValue)
                slider.value += buff.vampirismToSelf;
            else
                slider.value = slider.maxValue;
            
            sliderValue.text = sliderValue.text = $"{slider.value.ToString(CultureInfo.InvariantCulture)}/{slider.maxValue}";
        }
        
        private void OnEndBuff(BuffConfigDto buff)
        {
            if (slider.value - buff.vampirismToSelf > 0)
                slider.value -= buff.vampirismToSelf;
            else
                slider.value = 0;
            
            sliderValue.text = sliderValue.text = $"{slider.value.ToString(CultureInfo.InvariantCulture)}/{slider.maxValue}";
        }
    }
}