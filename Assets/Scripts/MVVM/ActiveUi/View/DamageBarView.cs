using DTO.Matchmaking;
using TMPro;
using UnityEngine;

namespace MVVM.ActiveUi.View
{
    public class DamageBarView : SliderBarBaseView
    {
        [SerializeField] private TextMeshProUGUI damageValueText;
        
        protected override void OnSetNewStat(PlayerStatDto newStat)
        {
            base.OnSetNewStat(newStat);

            damageValueText.text = newStat.damage.ToString();
        }
    }
}