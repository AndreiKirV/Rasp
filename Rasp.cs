using System;

namespace Rasp
{
    class Weapon
    {
        private int _damage;
        private int _bullets;

        public Weapon(int damage, int bullets)
        {
            if (damage > 0)
                _damage = damage;
            else
                _damage = 1;

            if (bullets > 0)
                _bullets = bullets;
            else
                _bullets = 1;
        }

        public void TryFire(Player player)
        {
            if (_bullets > 0)
            {
                player.TryTakeDamage(_damage);
                _bullets -= 1;
            }
            else
                Console.WriteLine("Кончились патроны");
        }
    }

    class Player
    {
        private int _health;
        private bool _isDead = false;

        public void TryTakeDamage(int damage) 
        {
            if (damage > 0 && _isDead == false)
            {
                _health -= damage;

                if (_health <= 0)
                {
                    _isDead = true;
                }
            }
            else
                Console.WriteLine($"Персонаж уже мертв, или урон меньше положительного значения");
            }
        }
    }

    class Bot
    {
        private Weapon _weapon;

        public void OnSeePlayer(Player player)
        {
            _weapon.TryFire(player);
        }
    }
}