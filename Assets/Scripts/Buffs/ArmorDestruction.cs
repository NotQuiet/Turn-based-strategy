using System.Linq;
using DTO.Matchmaking;
using UnityEngine;

namespace Buffs
{
    public class ArmorDestruction : BaseBuff
    {
        public override PlayerStatDto SetBuff(PlayerStatDto stat)
        {
            foreach (var buffData in data)
            {
                if (buffType == Enums.Enums.BuffType.OnEnemy)
                {
                    if(buffData.kind == Enums.Enums.BuffKind.Armor)
                        stat.armorDecrease += Mathf.Abs(buffData.value);
                }
            }
            
            return CheckThresholds(stat);
        }

        public override PlayerStatDto RemoveBuff(PlayerStatDto stat)
        {
            foreach (var buffData in data)
            {
                if (buffType == Enums.Enums.BuffType.OnEnemy)
                {
                    if(buffData.kind == Enums.Enums.BuffKind.Armor)
                        stat.armorDecrease -= Mathf.Abs(buffData.value);
                }
            }

            return CheckThresholds(stat);
        }

        public ArmorDestruction(BaseBuff buff) : base(buff)
        {
        }
    }
}