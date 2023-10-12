using DTO.Matchmaking;
using UnityEngine;

namespace Services
{
    public class BuffPerformerService
    {
        private PlayerStatDto _playerStat;
        
        // public PlayerStatDto EndBuff(BuffConfigDto buff, PlayerStatDto playerStat)
        // {
        //     _playerStat = playerStat;
        //     
        //     EndArmor(buff);
        //     EndVampire(buff);
        //
        //     if (buff.damageMultiplication > 0)
        //         _playerStat.damage /= buff.damageMultiplication;
        //
        //     return _playerStat;
        // }
        //
        // private void EndArmor(BuffConfigDto buff)
        // {
        //     if (_playerStat.armor - Mathf.Abs(buff.armorToSelf) > 0)
        //     {
        //         _playerStat.armor -= Mathf.Abs(buff.armorToSelf);
        //     }
        //     else
        //     {
        //         _playerStat.armor = 0;
        //     }
        // }
        //
        // private void EndVampire(BuffConfigDto buff)
        // {
        //     if (_playerStat.vampirism - Mathf.Abs(buff.vampirismToSelf) > 0)
        //     {
        //         _playerStat.vampirism -= Mathf.Abs(buff.vampirismToSelf);
        //     }
        //     else
        //     {
        //         _playerStat.vampirism = 0;
        //     }
        // }
        //
        // public PlayerStatDto SetBuff(BuffConfigDto buff, PlayerStatDto playerStat)
        // {
        //     _playerStat = playerStat;
        //     
        //     SetArmor(buff);
        //     SetVampire(buff);
        //
        //     if (buff.damageMultiplication > 0)
        //         _playerStat.damage *= buff.damageMultiplication;
        //
        //     return _playerStat;
        // }
        //
        // private void SetArmor(BuffConfigDto buff)
        // {
        //     if (_playerStat.armor + buff.armorToSelf > _playerStat.maxArmor)
        //     {
        //         _playerStat.armor = _playerStat.maxArmor;
        //         return;
        //     }
        //
        //     if (_playerStat.armor + buff.armorToSelf < 0)
        //     {
        //         _playerStat.armor = 0;
        //         return;
        //     }
        //
        //     _playerStat.armor += buff.armorToSelf;
        // }
        //
        // private void SetVampire(BuffConfigDto buff)
        // {
        //     if (_playerStat.vampirism + buff.vampirismToSelf > _playerStat.maxVampirism)
        //     {
        //         _playerStat.vampirism = _playerStat.maxVampirism;
        //         return;
        //     }
        //
        //     if (_playerStat.vampirism + buff.vampirismToSelf < 0)
        //     {
        //         _playerStat.vampirism = 0;
        //         return;
        //     }
        //     
        //     _playerStat.vampirism += buff.vampirismToSelf;
        // }
    }
}