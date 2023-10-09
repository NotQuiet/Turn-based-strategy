using System.Collections.Generic;
using DTO.Configurations;

namespace Services
{
    public class CreateAttackDataService
    {
        public AttackDataDto SetAttackData(AttackDataDto attackDataDto, IEnumerable<BuffConfigDto> buffs)
        {
            foreach (var buff in buffs)
            {
                if (buff.damageMultiplication > 0)
                    attackDataDto.damage *= buff.damageMultiplication;

                attackDataDto.armorDecrease += buff.armorToEnemy;
                attackDataDto.vampirismValue += buff.vampirismToSelf;
                attackDataDto.vampirismDecrease += buff.vampirismToEnemy;
            }

            return attackDataDto;
        }
    }
}