using System;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace DTO.UI
{
    [Serializable]
    public class BuffCellUiDto
    {
        public Enums.Enums.BuffTitle title;

        public Sprite buffImage;
    }
}