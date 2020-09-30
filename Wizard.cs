﻿using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld
{
    class Wizard : Character
    {
        private float _mana;

        //calls the default constructor for the wizard, and then calls the base classes constructor.
        public Wizard() : base()
        {
            _mana = 100;
        }

        public Wizard(float healthVal, string nameVal, float damageVal, float goldVal, float manaVal) 
            : base(healthVal, nameVal, damageVal, goldVal)
        {
            _mana = manaVal;
        }

        public override float Attack(Character enemy)
        {
            float damageTaken = 0.0f;
            if(_mana >= 4)
            {
                float totalDamage = _damage + _mana * .25f;
                _mana -= _mana * .25f;
                damageTaken = enemy.TakeDamage(totalDamage);
                return damageTaken;
            }
            damageTaken = base.Attack(enemy);
            return base.Attack(enemy);
        }
    }
}
