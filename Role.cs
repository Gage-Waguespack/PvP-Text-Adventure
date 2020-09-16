using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld
{
    class Role
    {
        //Variable definitions
        private string _name;
        private int _health;
        private int _damage;
        private char _proficiency;

        //Add a constructor
        public Role()
        {
            _name = "nothing";
            _health = 100;
            _damage = 10;
            _proficiency = 'N';
        }

        public Role(string name, int health, int damage, char proficiency)
        {
            _name = name;
            _health = health;
            _damage = damage;
            _proficiency = proficiency;
        }

        public bool IsProficient(Item item)
        {
            if (item.size == _proficiency)
            {
                return true;
            }
            return false;
        }

        public int GetHealth()
        {
            return _health;
        }

        public string GetName()
        {
            return _name;
        }
        
        public int GetDamage()
        {
            return _damage;
        }
        
    }
}
