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
            
            CalculateDamage(attackDataDto);

            return _currentStat;
        }

        private void CalculateDamage(AttackDataDto attackDataDto)
        {
            _currentStat.armor -= Mathf.Abs(attackDataDto.armorDecrease);

            if (_currentStat.armor < 0) _currentStat.armor = 0;

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
        }
    }
}