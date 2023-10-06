using System;
using System.Collections.Generic;
using DTO.UI;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(menuName = "PlayerConfig/BaseConfiguration", fileName = "BasePlayerConfigurationSo")]
    public class PlayerDataConfigurationSo : ScriptableObject
    {
        public List<BasePlayerConfig> playerConfigurations;
    }

    [Serializable]
    public class BasePlayerConfig
    {
        public Enums.Enums.PlayerConfigurationType playerConfigurationType;
        public ConfigData data;
    }
}