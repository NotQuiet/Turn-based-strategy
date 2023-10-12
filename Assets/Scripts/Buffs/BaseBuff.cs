using System;
using DTO.Matchmaking;

namespace Buffs
{
    [Serializable]
    public abstract class BaseBuff
    {
        public string title;
        public Enums.Enums.BuffType buffType;
        public int value;
        public int lifeTime;

        public virtual PlayerStatDto SetBuff(PlayerStatDto stat)
        {
            return new PlayerStatDto();
        }

        public virtual PlayerStatDto RemoveBuff(PlayerStatDto stat)
        {
            return new PlayerStatDto();
        }
    }

    [Serializable]
    public class BuffData
    {
        
    }
}