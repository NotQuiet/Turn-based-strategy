using System;
using System.Collections.Generic;
using DTO.Matchmaking;
using UnityEngine;

namespace Buffs
{
    [Serializable]
    public class BaseBuff
    {
        public string title;
        public Enums.Enums.BuffType buffType;
        public List<BuffData> data;
        public int lifeTime;

        public PlayerStatDto SetBuff(PlayerStatDto stat)
        {
            foreach (var buffData in data)
            {
                switch (buffType)
                {
                    case Enums.Enums.BuffType.OnYourself:
                        switch (buffData.kind)
                        {
                            case Enums.Enums.BuffKind.Damage:
                                stat.damage *= buffData.value;
                                break;
                            case Enums.Enums.BuffKind.Armor:
                                stat.armor += buffData.value;
                                break;
                            case Enums.Enums.BuffKind.Health:
                                stat.health += buffData.value;
                                break;
                            case Enums.Enums.BuffKind.Vampirism:
                                stat.vampirism += buffData.value;
                                break;
                            default:
                                Debug.LogError("Cant find this kind");
                                break;
                        }
                        break;
                    case Enums.Enums.BuffType.OnEnemy:
                        switch (buffData.kind)
                        {
                            case Enums.Enums.BuffKind.Damage:
                                break;
                            case Enums.Enums.BuffKind.Armor:
                                stat.armorDecrease += buffData.value;
                                break;
                            case Enums.Enums.BuffKind.Health:
                                break;
                            case Enums.Enums.BuffKind.Vampirism:
                                stat.vampirismDecrease += buffData.value;
                                break;
                            default:
                                Debug.LogError("Cant find this kind");
                                break;
                        }
                        break;
                    default:
                        Debug.LogError("Wrong type!");
                        break;
                }
                
            }
            
            return CheckThresholds(stat);
        }

        public PlayerStatDto RemoveBuff(PlayerStatDto stat)
        {
            foreach (var buffData in data)
            {
                switch (buffType)
                {
                    case Enums.Enums.BuffType.OnYourself:
                        switch (buffData.kind)
                        {
                            case Enums.Enums.BuffKind.Damage:
                                stat.damage /= buffData.value;
                                break;
                            case Enums.Enums.BuffKind.Armor:
                                stat.armor -= Mathf.Abs(buffData.value);
                                break;
                            case Enums.Enums.BuffKind.Health:
                                stat.health -= Mathf.Abs(buffData.value);
                                break;
                            case Enums.Enums.BuffKind.Vampirism:
                                stat.vampirism -= Mathf.Abs(buffData.value);
                                break;
                            default:
                                Debug.LogError("Cant find this kind");
                                break;
                        }
                        break;
                    case Enums.Enums.BuffType.OnEnemy:
                        switch (buffData.kind)
                        {
                            case Enums.Enums.BuffKind.Damage:
                                break;
                            case Enums.Enums.BuffKind.Armor:
                                stat.armorDecrease -= Mathf.Abs(buffData.value);
                                break;
                            case Enums.Enums.BuffKind.Health:
                                break;
                            case Enums.Enums.BuffKind.Vampirism:
                                stat.vampirismDecrease -= Mathf.Abs(buffData.value);
                                break;
                            default:
                                Debug.LogError("Cant find this kind");
                                break;
                        }
                        break;
                    default:
                        Debug.LogError("Wrong type!");
                        break;
                }
            }
            
            return CheckThresholds(stat);
        }

        private PlayerStatDto CheckThresholds(PlayerStatDto stat)
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