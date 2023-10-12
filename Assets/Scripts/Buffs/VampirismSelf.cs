using DTO.Matchmaking;
using UnityEngine;

namespace Buffs
{
    public class VampirismSelf : BaseBuff
    {
        public override PlayerStatDto SetBuff(PlayerStatDto stat)
        {
            foreach (var buffData in data)
            {
                if(buffData.kind == Enums.Enums.BuffKind.Vampirism)
                    stat.vampirism += Mathf.Abs(buffData.value);
                else if (buffData.kind == Enums.Enums.BuffKind.Armor)
                    stat.armor -= Mathf.Abs(buffData.value);
            }
            

            return CheckThresholds(stat);
        }

        public override PlayerStatDto RemoveBuff(PlayerStatDto stat)
        {
            foreach (var buffData in data)
            {
                if(buffData.kind == Enums.Enums.BuffKind.Vampirism)
                    stat.vampirism -= Mathf.Abs(buffData.value);
                else if (buffData.kind == Enums.Enums.BuffKind.Armor)
                    stat.armor += Mathf.Abs(buffData.value);
            }

            return CheckThresholds(stat);
        }

        public VampirismSelf(BaseBuff buff) : base(buff)
        {
        }
    }
}