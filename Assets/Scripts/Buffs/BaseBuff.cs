using System;
using System.Collections.Generic;
using System.Globalization;
using DTO.Matchmaking;

namespace Buffs
{
    [Serializable]
    public class BaseBuff
    {
        public Enums.Enums.BuffTitle title;
        public Enums.Enums.BuffType buffType;
        public List<BuffData> data;
        public int lifeTime;

        public BaseBuff(BaseBuff buff)
        {
            title = buff.title;
            buffType = buff.buffType;
            data = buff.data;
            lifeTime = buff.lifeTime;
        }

        public virtual PlayerStatDto SetBuff(PlayerStatDto stat)
        {
            return CheckThresholds(stat);
        }

        public virtual PlayerStatDto RemoveBuff(PlayerStatDto stat)
        {
            return CheckThresholds(stat);
        }

        protected PlayerStatDto CheckThresholds(PlayerStatDto stat)
        {
            if (stat.armor > stat.maxArmor)
                stat.armor = stat.maxArmor;
            
            if (stat.armor <= 0)
                stat.armor = 0;
            
            if (stat.vampirism > stat.maxVampirism)
                stat.vampirism = stat.maxVampirism;
            
            if (stat.vampirism <= 0)
                stat.vampirism = 0;

            return stat;
        }
    }

    [Serializable]
    public class BuffData
    {
        public Enums.Enums.BuffKind kind;
        public int value;
    }
}