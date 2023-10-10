using DTO.Configurations;
using DTO.Matchmaking;
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
        [SerializeField] protected Enums.Enums.PlayerConfigurationType playerConfigurationType;
        [SerializeField] protected Slider slider;
        [SerializeField] protected TextMeshProUGUI sliderValue;

        protected override void Subscribe()
        {
            base.Subscribe();

            ViewModel.Initialize.Subscribe(SetSliderValue).AddTo(Disposable);
            ViewModel.OnSetNewStat.Subscribe(OnSetNewStat).AddTo(Disposable);
        }

        protected virtual void SetSliderValue((ConfigData, Enums.Enums.PlayerConfigurationType) cort)
        {
            if(playerConfigurationType != cort.Item2) return;

            Debug.Log($"Initialize slider {playerConfigurationType}");
            
            slider.maxValue = cort.Item1.maxValue;
            slider.value = cort.Item1.currentValue;

            sliderValue.text = $"{cort.Item1.currentValue}/{cort.Item1.maxValue}";
        }

        protected virtual void OnSetNewStat(PlayerStatDto newStat)
        {
            
        }
    }
}