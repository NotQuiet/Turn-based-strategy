using MVVM.Controllers;
using UnityEngine;

namespace MVVM.ActiveUi.Model
{
    public class ApplyBuffModel : Core.Model
    {
        private ActiveBuffsController _buffsController;
        public ApplyBuffModel(ActiveBuffsController controller)
        {
            _buffsController = controller;
        }
        
        public void OnApplyBuff()
        {
            _buffsController.SetNewBuff();
            Debug.Log("On buff apply!");
        }
    }
}