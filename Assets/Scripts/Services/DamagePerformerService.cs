using System.Collections.Generic;
using DTO.Configurations;
using DTO.Matchmaking;
using UnityEngine;

namespace Services
{
    public class DamagePerformerService
    {
        private PlayerStatDto _currentStat;
        
        public PlayerStatDto DamageCalculation(PlayerStatDto currentStat, 
            AttackDataDto attackDataDto)
        {
            _currentStat = currentStat;
            
            DecreaseStats(attackDataDto);
            CalculateDamage(attackDataDto);

            return _currentStat;
        }

        private void CalculateDamage(AttackDataDto attackDataDto)
        {
            if (_currentStat.armor != 0)
            {
                double damageReduction = (double)_currentStat.armor / 100.0; // Преобразование брони в десятичный процент
                double damageBlocked = attackDataDto.damage * damageReduction; // Вычисление урона, который броня блокирует
                double finalDamage = attackDataDto.damage - damageBlocked; // Вычисление урона, который проходит через броню
                _currentStat.health -= (int)finalDamage;
            }
            else
            {
                _currentStat.health -= attackDataDto.damage;
            }

            if (_currentStat.health < 0) _currentStat.health = 0;
        }

        private void DecreaseStats(AttackDataDto attackDataDto)
        {
            _currentStat.armor -= Mathf.Abs(attackDataDto.armorDecrease);
            _currentStat.vampirism -= Mathf.Abs(attackDataDto.vampirismDecrease);
            
            if (_currentStat.armor < 0) _currentStat.armor = 0;
            if (_currentStat.vampirism < 0) _currentStat.vampirism = 0;
        }
    }
}