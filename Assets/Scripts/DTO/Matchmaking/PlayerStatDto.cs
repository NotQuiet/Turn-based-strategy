using System;

namespace DTO.Matchmaking
{
    [Serializable]
    public class PlayerStatDto
    {
        public int damage;
        public int maxDamage;
        public int health;
        public int maxHealth;
        public int armor;
        public int maxArmor;
        public int vampirism;
        public int maxVampirism;
    }
}