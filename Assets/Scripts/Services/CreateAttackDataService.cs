using System.Collections.Generic;
using Buffs;
using DTO.Configurations;

namespace Services
{
    public class CreateAttackDataService
    {
        public AttackDataDto SetAttackData(AttackDataDto attackDataDto, IEnumerable<BaseBuff> buffs)
        {
         
            return attackDataDto;
        }
    }
}