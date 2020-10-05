using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace HelloWorld
{


    struct Item
    {
        public string name;
        public int statBoost;
        public int cost;
    }
    class Game
    {
        private bool _gameOver = false;
        private Player _player1;
        private Player _player2;
        private Character _player1Partner;
        private Character _player2Partner;
        private Item _longSword;
        private Item _dagger;
        private Item _bow;
        private Item _crossBow;
        private Item _cherryBomb;
        private Item _mace;
        private Item _healthPot;
        private Item _strengthPot;
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


        // Initializes all items created, making them usable in the game.
        public void InitializeItems()
        {
            _longSword.name = "Long Sword";
            _longSword.statBoost = 15;
            _dagger.name = "Dagger";
            _dagger.statBoost = 10;
            _bow.name = "Bow";
            _bow.statBoost = 12;
            _crossBow.name = "Crossbow";
            _crossBow.statBoost = 34;
            _cherryBomb.name = "Cherry Bomb";
            _cherryBomb.statBoost = 24;
            _mace.name = "Mace";
            _mace.statBoost = 25;
            _healthPot.name = "Health Potion";
            _healthPot.statBoost = 50;
            _healthPot.cost = 25;
            _strengthPot.name = "Strength Potion";
            _strengthPot.statBoost = 25;
            _strengthPot.cost = 25;
        }

        //created a GetInput function that takes in an input, 2 options, and a query to simplify making a question and an oppertunity to pick one of the selected options.
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

        //made another GetInput function that takes in a third option.
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

            //used the GetInput function to chose a loadout for the game
            char input;
            GetInput(out input, "Loadout 1", "Loadout 2", "Welcome! " +  player.GetName() + " please choose a weapon.");

            if (input == '1')
            {
                player.AddItemToInventory(_longSword, 0);
                player.AddItemToInventory(_mace, 1);
                player.AddItemToInventory(_bow, 2);
            }
            else if (input == '2')
            {
                player.AddItemToInventory(_crossBow, 0);
                player.AddItemToInventory(_cherryBomb, 1);
                player.AddItemToInventory(_dagger, 2);
            }
            else
            {
                Console.WriteLine("Invalid Input");
            }
            Console.WriteLine("These are your stats");
            player.PrintStats();
        }

        public void PrintText(string Text, ConsoleColor Color)
        {
            Console.ForegroundColor = Color;
            Console.WriteLine(Text);
            Console.ForegroundColor = ConsoleColor.White;
        }

        //I want to have the player change the color of the text.
        public void ColorChange()
        {
            Console.WriteLine("Would you like to change the color of the text?");
            Console.WriteLine("Current Color: ", Console.ForegroundColor);
            GetInput(out char input, "Yes", "No", "Would you like to change the color of the text?");
            if (input == '1')
            {
                int[] _choices = new int[4] { 1, 2, 3, 4, };
                for (int i = 0; i < _choices.Length; i++)
                {
                    PrintText(_choices[i].ToString(), (ConsoleColor)i + 9);
                }

                int choice = 0;
                while (choice == 0)
                {
                    if (int.TryParse(Console.ReadLine(), out choice) == false)
                    {
                        Console.WriteLine("Invalid Input");
                    }
                }
                Console.ForegroundColor = (ConsoleColor)choice + 8;
            }
            else if (input == '2')
            {
                Console.WriteLine("You decided not to change your color!");
            }
        }

        public void Save()
        {
            //Create a new stream writer.
            StreamWriter writer = new StreamWriter("SaveData.txt");
            //Call save for both instances for player.
            _player1.Save(writer);
            _player2.Save(writer);
            //Close writer.
            writer.Close();
        }

        public void Load()
        {
            //Create a new stream reader.
            StreamReader reader = new StreamReader("SaveData.txt");
            //Call load for each instance of player to load data.
            _player1.Load(reader);
            _player2.Load(reader);
            //Close reader.
            reader.Close();
        }

        //Made a main menu that is used at the start of the game..
        public void OpenMainMenu()
        {
            char input;
            GetInput(out input, "Create new character", "Load Character", "What would you like to do?");
            if (input == '2')
            {
                _player1 = new Player();
                _player2 = new Player();
                Load();
                return;
            }
            _player1 = CreateCharacter();
            _player2 = CreateCharacter();
            Save();
        }

        //Lets the player(s) create their own character OR load a save at the start..
        public Player CreateCharacter()
        {
            
            Console.WriteLine("\nWhat is your name?");
            string name = Console.ReadLine();
            Player player = new Player(name, 100, 10, 500, 3);
            SelectLoadout(player);
            return player;
        }

        //Lets the player switch weapons 
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
                GetInput(out input, "Attack", "Change Weapon", "Shop", "Your turn Player 1");

                if(input == '1')
                {
                    float damageTaken = _player1.Attack(_player2);
                    Console.WriteLine(_player1.GetName() + " did " + damageTaken + " damage.");
                    damageTaken = _player1Partner.Attack(_player2);
                    Console.WriteLine(_player1Partner.GetName() + " did " + damageTaken + " damage.");
                }
                if (input == '2')
                {
                    SwitchWeapons(_player1);
                }
                //Lets the player pick an item to buy.. health pot upgrades health by 25 and strength pot ups damage by 25.
                if (input == '3')
                {
                    GetInput(out input, "Health Potion", "Strength Potion","Pick an item to buy!");
                    if (input == '1')
                    {
                        _player1.Buy(_healthPot);
                        _player1.HealthPot();
                    }
                    if (input == '2')
                    {
                        _player1.Buy(_strengthPot);
                        _player1.StrengthPot();
                    }
                }

                GetInput(out input, "Attack", "Change Weapon", "Shop", "Your turn Player 2");

                if (input == '1')
                {
                    float damageTaken = _player2.Attack(_player1);
                    Console.WriteLine(_player2.GetName() + " did " + damageTaken + " damage.");
                    damageTaken = _player2Partner.Attack(_player1);
                    Console.WriteLine(_player2Partner.GetName() + " did " + damageTaken + " damage.");
                }
                if (input == '2')
                {
                    SwitchWeapons(_player2);
                }
                if (input == '3')
                {
                    GetInput(out input, "Health Potion", "Strength Potion", "Pick an item to buy!");
                    if (input == '1')
                    {
                        _player2.Buy(_healthPot);
                        _player2.HealthPot();
                    }
                    if (input == '2')
                    {
                        _player2.Buy(_strengthPot);
                        _player2.StrengthPot();
                    }
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
            ColorChange();
            InitializeItems();
            _player1Partner = new Barb(150, "Shrek", 40, 500, 2);
            _player2Partner = new Wizard(120, "Barry Hizard", 20, 100, 50);

        }

        //Repeated until the game ends
        public void Update()
        {
            OpenMainMenu();
            StartBattle();
        }

        //Performed once when the game ends
        public void End()
        {
            Console.WriteLine("CONGRATS!!!!");
        }
    }
}
