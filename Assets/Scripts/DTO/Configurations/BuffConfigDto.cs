using System;
using UnityEngine;

namespace DTO.Configurations
{
    [Serializable]
    public class BuffConfigDto
    {
        public string title;
        [Space]
        public int damageMultiplication;
        public int armorToSelf;
        public int armorToEnemy;
        public int vampirismToSelf;
        public int vampirismToEnemy;
    }
}