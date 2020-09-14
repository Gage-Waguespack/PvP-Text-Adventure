using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld
{
    struct Player
    {
        public int health;
        public int damage;
    }

    struct Item
    {
        public int statBoost;
    }
    class Game
    {
        bool _gameOver = false;
        Player _player1;
        Player _player2;
        Item longSword;
        Item dagger;

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

        public void InitializePlayers()
        {
            _player1.health = 100;
            _player1.damage = 5;

            _player2.health = 100;
            _player2.damage = 5;
        }

        public void InitializeItems()
        {
            longSword.statBoost = 15;
            dagger.statBoost = 10;
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
        public void EquipItems()
        {

            char input;
            GetInput(out input, "Longsword", "Dagger", "Welcome! Player one please choose a weapon.");

                if (input == '1')
                {
                    _player1.damage += longSword.statBoost;
                }
                else if (input == '2')
                {
                    _player1.damage += dagger.statBoost;
                }
                else
                {
                    Console.WriteLine("Invalid Input");
                }
            Console.WriteLine("player 1");
            PrintStats(_player1);

                GetInput(out input, "Longsword", "Dagger", "Welcome! Player one please choose a weapon.");
            if (input == '1')
            {
                _player2.damage += longSword.statBoost;
            }
            else if (input == '2')
            {
                _player2.damage += dagger.statBoost;
            }
            else
            {
                Console.WriteLine("Invalid Input");
            }
            Console.WriteLine("player 2");
            PrintStats(_player2);

        }

        public void StartBattle()
        {
            Console.Clear();
            Console.WriteLine("Now GO!");

            while(_player1.health >=0 && _player2.health >= 0)
            {
                //Print player stats to console
                Console.WriteLine("Player 1");
                PrintStats(_player1);
                Console.WriteLine("Player 2");
                PrintStats(_player2);
                //Player 1 turn start
                //Get player input
                char input;
                GetInput(out input, "Attack", "NO", "Your turn Player 1");

                if(input == '1')
                {
                    _player2.health -= _player2.damage;
                    Console.WriteLine("Player 2 took " + _player1.damage + " damage");
                }
                else
                {
                    Console.WriteLine("NO!!!!!!!!");
                }

                GetInput(out input, "Attack", "NO", "Your turn Player 2");

                if (input == '1')
                {
                    _player2.health -= _player1.damage;
                    Console.WriteLine("Player 1 took " + _player2.damage + " damage");
                }
                else
                {
                    Console.WriteLine("NO!!!!!!!!");
                }
                Console.Clear();
            }
            if (_player1.health > 0)
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

        public void PrintStats(Player player)
        {
            Console.WriteLine("Health: " + player.health);
            Console.WriteLine("Damage: " + player.damage);
        }

        //Performed once when the game begins
        public void Start()
        {
            InitializePlayers();
            InitializeItems();
        }

        //Repeated until the game ends
        public void Update()
        {
            EquipItems();
            StartBattle();
        }

        //Performed once when the game ends
        public void End()
        {
            
        }
    }
}
