using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace HelloWorld
{
    class Character
    {
        private float _health;
        private string _name;
        protected float _damage;

        public Character()
        {
            _health = 100;
            _name = "Hero";
            _damage = 10;
        }
        public Character(float healthVal, string nameVal, float damageVal)
        {
            _health = healthVal;
            _name = nameVal;
            _damage = damageVal;
        }

        public virtual float Attack(Character enemy)
        {
            float damageTaken = enemy.TakeDamage(_damage);
            return damageTaken;
            //return enemy.TakeDamage(_damage);
        }

        public void PrintStats()
        {
            Console.WriteLine("Name: " + _name);
            Console.WriteLine("Health: " + _health);
            Console.WriteLine("Damage: " + _damage);
        }

        public virtual float TakeDamage(float damageVal)
        {
            _health -= damageVal;
            if(_health < 0)
            {
                _health = 0;
            }
            return damageVal;
        }

        public virtual void Save(StreamWriter writer)
        {
            //Save the characters stats
            writer.WriteLine(_name);
            writer.WriteLine(_health);
            writer.WriteLine(_damage);
        }

        public virtual bool Load(StreamReader reader)
        {
            //Create variables to store loaded data.
            string name = reader.ReadLine();
            float damage = 0;
            float health = 0;
            //Checks to see if loading was successful.
            if (float.TryParse(reader.ReadLine(), out health) == false)
            {
                return false;
            }
            if (float.TryParse(reader.ReadLine(), out damage) == false)
            {
                return false;
            }
            //If successful, set update the member variable and return true.
            _name = name;
            _damage = damage;
            _health = health;
            return true;
        }

        public string GetName()
        {
            return _name;
        }

        public bool GetIsAlive()
        {
            return _health > 0;
        }
    }
}
