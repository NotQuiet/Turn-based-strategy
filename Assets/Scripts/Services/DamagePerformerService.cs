using DTO.Configurations;
using DTO.Matchmaking;
using UnityEngine;

namespace Services
{
    public class DamagePerformerService
    {
        private PlayerStatDto _currentStat;
        private AttackDataDto _attackDataDto;

        public (bool, PlayerStatDto) HealByVampirism(PlayerStatDto currentStat, 
            AttackDataDto attackDataDto)
        {
            _currentStat = currentStat;
            _attackDataDto = attackDataDto;

            bool isHeal = CalculateHeal();

            return (isHeal, _currentStat);
        }

        private bool CalculateHeal()
        {
            if (_attackDataDto.vampirismValue != 0)
            {
                double healReduction = (double)_attackDataDto.vampirismValue / 100.0; // Преобразование хила в десятичный процент
                double finalHeal = _attackDataDto.damage * healReduction; // Вычисление хила
                _currentStat.health += (int)finalHeal;
                
                Debug.Log($"Heal: vampirism value {_attackDataDto.vampirismValue} attack damage {_attackDataDto.damage}" +
                          $" heal value {(int)finalHeal}");


                return true;
            }
            else
            {
                return false;
            }
        }
        
        public (PlayerStatDto, AttackDataDto) DamageCalculation(PlayerStatDto currentStat, 
            AttackDataDto attackDataDto)
        {
            _currentStat = currentStat;
            _attackDataDto = attackDataDto;
            
            DecreaseStats();
            CalculateDamage();

            return (_currentStat, _attackDataDto) ;
        }

        private void CalculateDamage()
        {
            if (_currentStat.armor != 0)
            {
                double damageReduction = (double)_currentStat.armor / 100.0; // Преобразование брони в десятичный процент
                double damageBlocked = _attackDataDto.damage * damageReduction; // Вычисление урона, который броня блокирует
                double finalDamage = _attackDataDto.damage - damageBlocked; // Вычисление урона, который проходит через броню
                _currentStat.health -= (int)finalDamage;

                _attackDataDto.damage = (int)finalDamage;
            }
            else
            {
                _currentStat.health -= _attackDataDto.damage;
            }

            if (_currentStat.health < 0) _currentStat.health = 0;
        }

        private void DecreaseStats()
        {
            Debug.Log($"On get damage decrease stats: decrease armor - {_attackDataDto.armorDecrease}" +
                      $" _currentStat.vampirism - {_attackDataDto.vampirismDecrease}");
            
            _currentStat.armor -= Mathf.Abs(_attackDataDto.armorDecrease);
            _currentStat.vampirism -= Mathf.Abs(_attackDataDto.vampirismDecrease);
            
            if (_currentStat.armor < 0) _currentStat.armor = 0;
            if (_currentStat.vampirism < 0) _currentStat.vampirism = 0;
        }
    }
}