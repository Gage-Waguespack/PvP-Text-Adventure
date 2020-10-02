using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld
{
    class Player : Character
    {
        private Item[] _inventory;
        private Item _currentWeapon;
        private Item _hands;


        //creates a player with an inventory and "hands"
        public Player() : base()
        {
            _inventory = new Item[3];
            _hands.name = "These hands";
            _hands.statBoost = 0;
        }

        //Overloads the player to set a players stats
        public Player(string nameVal, float healthVal, float damageVal, float goldVal, int inventorySize)
            : base(healthVal, nameVal, damageVal, goldVal)
        {
            _inventory = new Item[inventorySize];
            _hands.name = "These hands";
            _hands.statBoost = 0;
        }

        //Returns the inventory
        public Item[] GetInventory()
        {
            return _inventory;
        }

        //Adds items to the players inventory
        public void AddItemToInventory(Item item, int index)
        {
            _inventory[index] = item;
        }

        //Checks the players inventory to what's in a specific slot
        public bool Contains(int itemIndex)
        {
            if(itemIndex > 0 && itemIndex < _inventory.Length)
            {
                return true;
            }
            return false;
        }

        //Allows the player to equip an item.
        public void EquipItem(int itemIndex)
        {
            if(Contains(itemIndex))
            {
                _currentWeapon = _inventory[itemIndex];
            }
        }

        //Allows the player to unequip an item
        public void UnequipItem()
        {
            _currentWeapon = _hands;
        }

        //allows the player to attack
        public override float Attack(Character enemy)
        {
            float totalDamage = _damage + _currentWeapon.statBoost;
            return enemy.TakeDamage(totalDamage);
        }

        //created a buy function to buy potions in game
        public bool Buy(Item item)
        {
            if (_gold >= item.cost)
            {
                // pays for the item then places it in the inventory array
                _gold -= item.cost;
                return true;
            }
            return false;
        }
    }
}
