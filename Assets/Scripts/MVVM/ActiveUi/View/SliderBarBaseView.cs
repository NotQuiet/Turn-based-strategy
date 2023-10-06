using DTO.UI;
using MVVM.ActiveUi.Model;
using MVVM.ActiveUi.ViewModel;
using MVVM.Core;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace MVVM.ActiveUi.View
{
    public class SliderBarBaseView : View<SliderBarBaseViewModel, SliderBarBaseModel>
    {
        [SerializeField] private Enums.Enums.PlayerConfigurationType playerConfigurationType;
        [SerializeField] private Slider slider;
        [SerializeField] private TextMeshProUGUI sliderValue;
        

        protected override void Subscribe()
        {
            base.Subscribe();

            ViewModel.Initialize.Subscribe(SetSliderValue).AddTo(Disposable);
        }

        private void SetSliderValue((ConfigData, Enums.Enums.PlayerConfigurationType) cort)
        {
            if(playerConfigurationType != cort.Item2) return;

            Debug.Log($"Initialize slider {playerConfigurationType}");
            
            slider.maxValue = cort.Item1.maxValue;
            slider.value = cort.Item1.currentValue;

            sliderValue.text = $"{cort.Item1.currentValue}/{cort.Item1.maxValue}";
        }
    }
}