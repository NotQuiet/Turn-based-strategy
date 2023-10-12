using System.Linq;
using DTO.Matchmaking;

namespace Buffs
{
    public class DamageBuff : BaseBuff
    {
        public override PlayerStatDto SetBuff(PlayerStatDto stat)
        {
            foreach (var buffData in data.Where(d => d.kind == Enums.Enums.BuffKind.Damage))
            {
                stat.damage *= buffData.value;
            }

            return CheckThresholds(stat);
        }

        public override PlayerStatDto RemoveBuff(PlayerStatDto stat)
        {
            foreach (var buffData in data.Where(d => d.kind == Enums.Enums.BuffKind.Damage))
            {
                stat.damage /= buffData.value;
            }

            return CheckThresholds(stat);
        }

        public DamageBuff(BaseBuff buff) : base(buff)
        {
        }
    }
}