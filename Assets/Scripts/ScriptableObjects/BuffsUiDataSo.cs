using System.Collections.Generic;
using DTO.UI;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(menuName = "Buffs/BuffsUiDataSo", fileName = "BuffsUiDataSo")]
    public class BuffsUiDataSo : ScriptableObject
    {
        public List<BuffCellUiDto> buffsList;
    }
}