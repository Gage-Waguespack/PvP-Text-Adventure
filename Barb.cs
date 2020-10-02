using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld
{
    class Barb : Character
    {
        private float _stamina;

        // created a barb that has a stamina value.
        public Barb() : base()
        {
            _stamina = 100;
        }

        //created an overload of the barb that takes in specific values to give it set stats.
        public Barb(float healthVal, string nameVal, float damageVal, float goldVal, float staminaVal)
            : base(healthVal, nameVal, damageVal, goldVal)
        {
            _stamina = staminaVal;
        }

        //Makes it to where the Barb can attack with the player (player 1)..
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
