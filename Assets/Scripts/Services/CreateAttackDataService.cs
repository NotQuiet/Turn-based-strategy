using System.Collections.Generic;
using DTO.Configurations;

namespace Services
{
    public class CreateAttackDataService
    {
        public AttackDataDto CreateAttackData(List<BuffConfigDto> buffs)
        {
            var attackData = new AttackDataDto();

            foreach (var buff in buffs)
            {
                attackData += buff;
            }
        }
    }
}