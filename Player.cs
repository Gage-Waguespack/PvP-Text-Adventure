using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld
{
    class Player
    {
        private Role _role;
        private string _name;
        private Item _equipItem;
        private int _health;
        private int _damage;
        private Item[] _inventory;
        public Player()
        {
            _role = new Role();
            _inventory = new Item[3];
            _health = _role.GetHealth();
            _damage = _role.GetDamage();
        }
        public Player(string nameVal, Role role, int inventorySize)
        {
            _name = nameVal;
            _role = role;
            _health = _role.GetHealth();
            _damage = _role.GetDamage();
            _inventory = new Item[inventorySize];
        }

        public void AddItemToInventory(Item item, int index)
        {
            _inventory[index] = item;
        }

        public void EquipItem(int itemIndex)
        {
            _damage = _inventory[itemIndex].statBoost;
        }

        public string GetName()
        {
            return _name;
        }

        public void SetRole(Role role)
        {
            _role = role;
        }
        public bool GetIsAlive()
        {
            return _health > 0;
        }
        public void Attack(Player enemy)
        {
            enemy.TakeDamage(_damage);
        }

        public void PrintStats()
        {
            Console.WriteLine("Name: " + _name);
            Console.WriteLine("Health: " + _health);
            Console.WriteLine("Damage: " + _damage);
            Console.WriteLine("Role: " + _role.GetName());
        }
        private void TakeDamage(int damageVal)
        {
            damageVal = _role.GetDamage();
            if(GetIsAlive())
            {
                _health -= damageVal;
            }
            Console.WriteLine(_name + " took " + damageVal + " damage!!!");
        }
    }
}
