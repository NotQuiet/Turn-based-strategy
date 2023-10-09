using System;

namespace DTO.Configurations
{
    [Serializable]
    public class AttackDataDto
    {
        public int damage;
        public int armorDecrease;
        public int vampirismDecrease;

        public int vampirismValue;
    }
}