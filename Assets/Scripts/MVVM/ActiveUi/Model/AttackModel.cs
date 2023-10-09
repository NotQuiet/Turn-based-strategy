using DTO.Configurations;
using UnityEngine;

namespace MVVM.ActiveUi.Model
{
    public class AttackModel : Core.Model
    {
        private AttackDataDto _attackData;
        
        
        
        
        public void OnAttack()
        {
            Debug.Log("On attack!");
        }
    }
}