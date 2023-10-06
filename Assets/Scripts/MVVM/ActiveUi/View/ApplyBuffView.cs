using MVVM.ActiveUi.Model;
using MVVM.ActiveUi.ViewModel;
using MVVM.Core;
using UnityEngine;
using UnityEngine.UI;

namespace MVVM.ActiveUi.View
{
    public class ApplyBuffView : View<ApplyBuffViewModel, ApplyBuffModel>
    {
        [SerializeField] private Button applyBuffButton;

        protected override void Subscribe()
        {
            base.Subscribe();
            
            applyBuffButton.onClick.AddListener(OnApplyBuff);
        }

        protected override void Unsubscribe()
        {
            base.Unsubscribe();
            
            applyBuffButton.onClick.RemoveAllListeners();
        }
        
        private void OnApplyBuff()
        {
            ViewModel.OnApplyBuff();
        }
    }
}