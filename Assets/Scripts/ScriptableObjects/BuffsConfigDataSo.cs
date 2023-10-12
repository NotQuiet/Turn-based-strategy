using System.Collections.Generic;
using Buffs;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(menuName = "Buffs/BuffsConfigDataSo", fileName = "BuffsConfigDataSo")]
    public class BuffsConfigDataSo : ScriptableObject
    {
        // public List<BuffConfigDto> buffsList;
        public List<BaseBuff> buffsList;
    }
}