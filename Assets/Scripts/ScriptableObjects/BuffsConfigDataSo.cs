using System.Collections.Generic;
using DTO.Configurations;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(menuName = "Buffs/BuffsConfigDataSo", fileName = "BuffsConfigDataSo")]
    public class BuffsConfigDataSo : ScriptableObject
    {
        public List<BuffConfigDto> buffsList;
    }
}