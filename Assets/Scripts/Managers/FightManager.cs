using DTO.Configurations;
using UniRx;
using UnityEngine;

namespace Managers
{
    public class FightManager : MonoBehaviour
    {
        public ReactiveCommand<(Enums.Enums.PlayerOriented oriented, AttackDataDto attackDataDto)> OnGetDamage = new();
        public ReactiveCommand<(Enums.Enums.PlayerOriented oriented, AttackDataDto attackDataDto)> OnGetHeal = new();

        
        public ReactiveCommand OnMatchEnd = new();

        public void MakeAttack(Enums.Enums.PlayerOriented oriented, AttackDataDto attackDataDto)
        {
            OnGetDamage.Execute((oriented, attackDataDto));
        }

        public void PlayerDie()
        {
            OnMatchEnd.Execute();
        }

        public void MakeHeal(Enums.Enums.PlayerOriented oriented, AttackDataDto attackDataDto)
        {
            OnGetHeal.Execute((oriented, attackDataDto));
        }
    }
}