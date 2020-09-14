using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld
{


    struct Item
    {
        public int statBoost;
    }
    class Game
    {
        private bool _gameOver = false;
        private Player _player1;
        private Player _player2;
        private Item _longSword;
        private Item _dagger;

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
            _longSword.statBoost = 15;
            _dagger.statBoost = 10;
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

        //Equip items to both players in the beginning of the game
        public void SelectItems(Player player)
        {

            char input;
            GetInput(out input, "Longsword", "Dagger", "Welcome! Player one please choose a weapon.");

                if (input == '1')
                {
                player.EquipItem(_longSword);
                }
                else if (input == '2')
                {
                    player.EquipItem(_dagger);
                }
                else
                {
                    Console.WriteLine("Invalid Input");
                }
            Console.WriteLine("player 1");
            _player1.PrintStats();

                GetInput(out input, "Longsword", "Dagger", "Welcome! Player one please choose a weapon.");
            if (input == '1')
            {
                _player2.EquipItem(_longSword);
            }
            else if (input == '2')
            {
                _player2.EquipItem(_dagger);
            }
            else
            {
                Console.WriteLine("Invalid Input");
            }
            Console.WriteLine("player 2");
            _player2.PrintStats();

        }

        public Player CreateCharacter()
        {
            Console.WriteLine("What is your name?");
            string name = Console.ReadLine();
            Player player = new Player(name, 100, 10);
            SelectItems(player);
            return player;
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
                GetInput(out input, "Attack", "NO", "Your turn Player 1");

                if(input == '1')
                {
                    _player1.Attack(_player2);
                }
                else
                {
                    Console.WriteLine("NO!!!!!!!!");
                }

                GetInput(out input, "Attack", "NO", "Your turn Player 2");

                if (input == '1')
                {
                    _player2.Attack(_player1);
                }
                else
                {
                    Console.WriteLine("NO!!!!!!!!");
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
