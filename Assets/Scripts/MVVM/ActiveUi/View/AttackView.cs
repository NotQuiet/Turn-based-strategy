using MVVM.ActiveUi.Model;
using MVVM.ActiveUi.ViewModel;
using MVVM.Core;
using UnityEngine;
using UnityEngine.UI;

namespace MVVM.ActiveUi.View
{
    public class AttackView : View<AttackViewModel, AttackModel>
    {
        [SerializeField] private Button attackButton;

        protected override void Subscribe()
        {
            base.Subscribe();
            
            attackButton.onClick.AddListener(OnAttack);
        }

        protected override void Unsubscribe()
        {
            base.Unsubscribe();
            
            attackButton.onClick.RemoveAllListeners();
        }
        
        private void OnAttack()
        {
            ViewModel.OnAttack();
        }
    }
}