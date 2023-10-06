using MVVM.ActiveUi.Model;
using MVVM.Core;

namespace MVVM.ActiveUi.ViewModel
{
    public class ApplyBuffViewModel : ViewModel<ApplyBuffModel>
    {
        public ApplyBuffViewModel(ApplyBuffModel model) : base(model)
        {
        }

        public void OnApplyBuff()
        {
            Model.OnApplyBuff();
        }
    }
}