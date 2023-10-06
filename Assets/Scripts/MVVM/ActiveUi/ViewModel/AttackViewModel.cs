using MVVM.ActiveUi.Model;
using MVVM.Core;

namespace MVVM.ActiveUi.ViewModel
{
    public class AttackViewModel : ViewModel<AttackModel>
    {
        public AttackViewModel(AttackModel model) : base(model)
        {
        }

        public void OnAttack()
        {
            Model.OnAttack();
        }
    }
}