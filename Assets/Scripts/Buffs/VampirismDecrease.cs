using System.Linq;
using DTO.Matchmaking;
using UnityEngine;

namespace Buffs
{
    public class VampirismDecrease : BaseBuff
    {
        public override PlayerStatDto SetBuff(PlayerStatDto stat)
        {
            foreach (var buffData in data.Where(buffData => buffData.kind == Enums.Enums.BuffKind.Vampirism))
            {
                stat.vampirismDecrease += Mathf.Abs(buffData.value);
            }


            return CheckThresholds(stat);
        }

        public override PlayerStatDto RemoveBuff(PlayerStatDto stat)
        {
            foreach (var buffData in data.Where(buffData => buffData.kind == Enums.Enums.BuffKind.Vampirism))
            {
                stat.vampirismDecrease -= Mathf.Abs(buffData.value);
            }

            return CheckThresholds(stat);
        }

        public VampirismDecrease(BaseBuff buff) : base(buff)
        {
        }
    }
}