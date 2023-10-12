using System.Linq;
using DTO.Matchmaking;

namespace Buffs
{
    public class ArmorSelf : BaseBuff
    {
        public override PlayerStatDto SetBuff(PlayerStatDto stat)
        {
            foreach (var buffData in data.Where(d => d.kind == Enums.Enums.BuffKind.Armor))
            {
                stat.armor += buffData.value;
            }

            return CheckThresholds(stat);
        }

        public override PlayerStatDto RemoveBuff(PlayerStatDto stat)
        {
            foreach (var buffData in data.Where(d => d.kind == Enums.Enums.BuffKind.Armor))
            {
                stat.armor -= buffData.value;
            }

            return CheckThresholds(stat);
        }

        public ArmorSelf(BaseBuff buff) : base(buff)
        {
        }
    }
}