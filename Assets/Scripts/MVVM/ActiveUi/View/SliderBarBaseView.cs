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

            ViewModel.OnSetNewStat.Subscribe(OnSetNewStat).AddTo(Disposable);
        }

        protected virtual void OnSetNewStat(PlayerStatDto newStat)
        {
            
        }
    }
}