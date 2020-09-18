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
        private int _baseDamage;
        private Item[] _inventory;
        private Item _currentWeapon;
        private Item _hands;

        public Player()
        {
            _role = new Role();
            _inventory = new Item[3];
            _health = _role.GetHealth();
            _baseDamage = _role.GetDamage();
            _hands.name = "These hands";
            _hands.statBoost = 0;
        }
        public Player(string nameVal, Role role, int inventorySize)
        {
            _name = nameVal;
            _role = role;
            _health = _role.GetHealth();
            _baseDamage = _role.GetDamage();
            _inventory = new Item[inventorySize];
            _hands.name = "These hands";
            _hands.statBoost = 0;
        }

        public Item[] GetInventory()
        {
            return _inventory;
        }

        public void AddItemToInventory(Item item, int index)
        {
            _inventory[index] = item;
        }

        public bool Contains(int itemIndex)
        {
            if(itemIndex > 0 && itemIndex < _inventory.Length)
            {
                return true;
            }
            return false;
        }

        public void EquipItem(int itemIndex)
        {
            if(Contains(itemIndex))
            {
                _currentWeapon = _inventory[itemIndex];
            }
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

        public void UnequipItem()
        {
            _currentWeapon = _hands;
        }

        public void Attack(Player enemy)
        {
            int totalDamage = _baseDamage + _currentWeapon.statBoost;
            enemy.TakeDamage(totalDamage);
        }

        public void PrintStats()
        {
            Console.WriteLine("Name: " + _name);
            Console.WriteLine("Health: " + _health);
            Console.WriteLine("Damage: " + _baseDamage);
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
