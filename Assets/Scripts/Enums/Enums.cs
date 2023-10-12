namespace Enums
{
    public static class Enums
    {
        public enum PlayerConfigurationType
        {
            Health,
            Armor,
            Vampirism,
            Damage
        }
        
        public enum PlayerOriented
        {
            Left, 
            Right
        }

        public enum BuffType
        {
            OnYourself, 
            OnEnemy
        }
        
        public enum BuffTitle
        {
            DoubleDamage, 
            ArmorSelf,
            ArmorDestruction,
            VampirismSelf,
            VampirismDecrease
        }

        public enum BuffKind
        {
            Damage,
            Health,
            Armor,
            Vampirism
        }
    }
}