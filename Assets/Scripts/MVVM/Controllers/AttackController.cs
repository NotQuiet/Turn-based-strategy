using DTO.Configurations;
using UniRx;
using UnityEngine;

namespace MVVM.Controllers
{
    public class AttackController : ModelsController
    {
        public ReactiveCommand<AttackDataDto> OnAttack = new();
        public ReactiveCommand<AttackDataDto> OnGetDamage = new();
        
        public void Attack(AttackDataDto attackDataDto)
        {
            OnAttack.Execute(attackDataDto);

            Debug.Log($"damage: {attackDataDto.damage} armor decrease: {attackDataDto.armorDecrease} " +
                      $"vampirism decrease: {attackDataDto.vampirismDecrease} vampirism value: {attackDataDto.vampirismValue}");
        }

        public void SetDamage(AttackDataDto damageData)
        {
            OnGetDamage.Execute(damageData);
        }
    }
}