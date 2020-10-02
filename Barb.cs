using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld
{
    class Barb : Character
    {
        private float _stamina;
        public Barb() : base()
        {
            _stamina = 100;
        }

        public Barb(float healthVal, string nameVal, float damageVal, float goldVal, float staminaVal)
            : base(healthVal, nameVal, damageVal, goldVal)
        {
            _stamina = staminaVal;
        }
        public override float Attack(Character enemy)
        {
            float damageTaken = 0.0f;
            if (_stamina >= 2)
            {
                float totalDamage = _damage + _stamina * .25f;
                _stamina -= _stamina * .5f;
                damageTaken = enemy.TakeDamage(totalDamage);
                return damageTaken;
            }
            damageTaken = base.Attack(enemy);
            return base.Attack(enemy);
        }
    }
}
