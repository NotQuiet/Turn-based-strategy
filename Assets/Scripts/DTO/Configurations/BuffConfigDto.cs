using System;
using UnityEngine;

namespace DTO.Configurations
{
    [Serializable]
    public class BuffConfigDtoe
    {
        public string title;
        [Space]
        public int damageMultiplication;
        public int armorToSelf;
        public int armorToEnemy;
        public int vampirismToSelf;
        public int vampirismToEnemy;
        [Space]
        public int lifeTime;

    }
}