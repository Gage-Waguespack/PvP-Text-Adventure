using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld
{


    struct Item
    {
        public string name;
        public int statBoost;
        public char size;
    }
    class Game
    {
        private bool _gameOver = false;
        private Player _player1;
        private Player _player2;
        private Item _longSword;
        private Item _dagger;
        private Item _bow;
        private Item _crossBow;
        private Item _cherryBomb;
        private Item _mace;
        private Role _fighter = new Role("Fighter", 120, 15, 'L');
        private Role _assassin = new Role("Assassin", 100, 30, 'S');

        //Run the game
        public void Run()
        {
            Start();

            while(_gameOver == false)
            {
                Update();
            }

            End();

        }

        public void InitializeItems()
        {
            _longSword.name = "Long Sword";
            _longSword.statBoost = 15;
            _longSword.size = 'L';
            _dagger.name = "Dagger";
            _dagger.statBoost = 10;
            _dagger.size = 'S';
            _bow.name = "Bow";
            _bow.statBoost = 12;
            _bow.size = 'M';
            _crossBow.name = "Crossbow";
            _crossBow.statBoost = 34;
            _crossBow.size = 'M';
            _cherryBomb.name = "Cherry Bomb";
            _cherryBomb.statBoost = 24;
            _cherryBomb.size = 'S';
            _mace.name = "Mace";
            _mace.statBoost = 25;
            _mace.size = 'L';
        }

        public void GetInput(out char input, string option1, string option2, string query)
        {
            Console.WriteLine(query);
            Console.WriteLine("1. " + option1);
            Console.WriteLine("2. " + option2);
            Console.WriteLine("> ");
            input = ' ';
            while (input != '1' && input != '2')
            {
                input = Console.ReadKey().KeyChar;
                if(input != '1' && input != '2')
                {
                    Console.WriteLine("Invalid Input");
                }
            }
        }

        public void GetInput(out char input, string option1, string option2, string option3, string query)
        {
            Console.WriteLine(query);
            Console.WriteLine("1. " + option1);
            Console.WriteLine("2. " + option2);
            Console.WriteLine("3. " + option3);
            Console.WriteLine("> ");
            input = ' ';
            while (input != '1' && input != '2' && input != '3')
            {
                input = Console.ReadKey().KeyChar;
                if (input != '1' && input != '2' && input != '3')
                {
                    Console.WriteLine("Invalid Input");
                }
            }
        }

        //Choose a new role for both players at the start of the game
        //Equip items to both players in the beginning of the game
        public void SelectLoadout(Player player)
        {
            Console.Clear();
            Console.WriteLine("Loadout 1: ");
            Console.WriteLine(_longSword.name);
            Console.WriteLine(_dagger.name);
            Console.WriteLine(_bow.name);

            Console.WriteLine("\n Loadout 2: ");
            Console.WriteLine(_crossBow.name);
            Console.WriteLine(_cherryBomb.name);
            Console.WriteLine(_mace.name);
            Console.WriteLine();

            char input;
            GetInput(out input, "Loadout 1", "Loadout 2", "Welcome! " +  player.GetName() + " please choose a weapon.");

            if (input == '1')
            {
                player.AddItemToInventory(_longSword, 0);
                player.AddItemToInventory(_dagger, 1);
                player.AddItemToInventory(_bow, 2);

                player.SetRole(_fighter);
            }
            else if (input == '2')
            {
                player.AddItemToInventory(_crossBow, 0);
                player.AddItemToInventory(_cherryBomb, 1);
                player.AddItemToInventory(_mace, 2);

                player.SetRole(_assassin);
            }
            else
            {
                Console.WriteLine("Invalid Input");
            }
            Console.WriteLine("These are your stats");
            player.PrintStats();
        }

        public Player CreateCharacter()
        {
            Console.WriteLine("What is your name?");
            string name = Console.ReadLine();
            Player player = new Player();
            SelectLoadout(player);
            return player;
        }

        public void SwitchWeapons(Player player)
        {
            Item[] inventory = player.GetInventory();

            char input = ' ';
            for(int i = 0; i < inventory.Length; i++)
            {
                Console.WriteLine((i + 1) + ". " + inventory[i].name + " \n Damage: " + inventory[i].statBoost);
            }
            Console.WriteLine("> ");

            input = Console.ReadKey().KeyChar;

            switch (input)
            {
                case '1':
                    {
                        player.EquipItem(0);
                        Console.WriteLine("You equipped " + inventory[0].name);
                        Console.WriteLine("Damage increased by " + inventory[0].statBoost);
                        break;
                    }
                case '2':
                    {
                        player.EquipItem(1);
                        Console.WriteLine("You equipped " + inventory[1].name);
                        Console.WriteLine("Damage increased by " + inventory[1].statBoost);
                        break;
                    }
                case '3':
                    {
                        player.EquipItem(2);
                        Console.WriteLine("You equipped " + inventory[2].name);
                        Console.WriteLine("Damage increased by " + inventory[2].statBoost);
                        break;
                    }
                default:
                    {
                        player.UnequipItem();
                        Console.WriteLine("You accidently dropped your weapon! \nUnfortunate :(");
                        break;
                    }
            }
        }

        public void StartBattle()
        {
            Console.Clear();
            Console.WriteLine("Now GO!");

            while(_player1.GetIsAlive() && _player2.GetIsAlive())
            {
                //Print player stats to console
                Console.WriteLine("Player 1");
                _player1.PrintStats();
                Console.WriteLine("Player 2");
                _player2.PrintStats();
                //Player 1 turn start
                //Get player input
                char input;
                GetInput(out input, "Attack", "Change Weapon", "Your turn Player 1");

                if(input == '1')
                {
                    _player1.Attack(_player2);
                }
                else
                {
                    SwitchWeapons(_player1);
                }

                GetInput(out input, "Attack", "Change Weapon", "Your turn Player 2");

                if (input == '1')
                {
                    _player2.Attack(_player1);
                }
                else
                {
                    SwitchWeapons(_player2);
                }
                Console.Clear();
            }
            if (_player1.GetIsAlive())
            {
                Console.WriteLine("Player 1 wins !1!!11!1!111!?");
            }
            else
            {
                //Yes the 1's and /'s are necessary... fight me lmao
                Console.WriteLine("Player 2 wins //???//?!1!111!?");
            }
            _gameOver = true;
        }

        //Performed once when the game begins
        public void Start()
        {
            InitializeItems();
        }

        //Repeated until the game ends
        public void Update()
        {
            _player1 = CreateCharacter();
            _player2 = CreateCharacter();

            StartBattle();
        }

        //Performed once when the game ends
        public void End()
        {
            
        }
    }
}
