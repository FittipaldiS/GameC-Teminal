using System;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            int currentPlayer = -1;
            char[] gameMarker = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            int gameStatus = 0;


            do
            {
                Console.Clear();
                currentPlayer = GetNextPlayer(currentPlayer);

                HeadsUpDisplay(currentPlayer);
                DrawBoard(gameMarker);

                GameEngine(gameMarker, currentPlayer);

                gameStatus = CheckWinner(gameMarker);

                //string userInput = Console.ReadLine();
                //Console.Clear();

            } while (gameStatus.Equals(0));

            Console.Clear();
            HeadsUpDisplay(currentPlayer);
            DrawBoard(gameMarker);

            if (gameStatus.Equals(1))
            {
          
                Console.WriteLine($"Player {currentPlayer} WIN!!");
            }

            if (gameStatus.Equals(2))
            {
                Console.WriteLine($"The Game is a Draw!");
            }

        }

        private static int CheckWinner(char[] gameMarker)
        {
            if (IsGameDraw(gameMarker))
            {
                return 2;
            }

            if (IsGameWinner(gameMarker))
            {
                return 1;
            }
            return 0;

        }

        private static bool IsGameDraw(char[] gameMarker)
        {
            return gameMarker[0] != '1' &&
                         gameMarker[1] != '2' &&
                          gameMarker[2] != '3' &&
                           gameMarker[3] != '4' &&
                            gameMarker[4] != '5' &&
                             gameMarker[5] != '6' &&
                              gameMarker[6] != '7' &&
                               gameMarker[7] != '8' &&
                                gameMarker[8] != '9';


        }

        private static bool IsGameWinner(char[] gameMarker)
        {
            if (IsGamerMarkersTheSame(gameMarker,0, 1,2))
            {
                return true;
            }
            if (IsGamerMarkersTheSame(gameMarker, 3, 4, 5))
            {
                return true;
            }
            if (IsGamerMarkersTheSame(gameMarker, 6, 7, 8))
            {
                return true;
            }
            if (IsGamerMarkersTheSame(gameMarker, 0, 3, 6))
            {
                return true;
            }
            if (IsGamerMarkersTheSame(gameMarker, 1, 4, 7))
            {
                return true;
            }
            if (IsGamerMarkersTheSame(gameMarker, 2, 5, 8))
            {
                return true;
            }
            if (IsGamerMarkersTheSame(gameMarker, 0, 4, 8))
            {
                return true;
            }
            if (IsGamerMarkersTheSame(gameMarker, 1, 5, 9))
            {
                return true;
            }
            if (IsGamerMarkersTheSame(gameMarker, 3, 5, 7))
            {
                return true;
            }

            return false;
        }

        private static bool IsGamerMarkersTheSame(char[] testGameMarkers, int pos1, int pos2, int pos3)
        {
            return testGameMarkers[pos1].Equals(testGameMarkers[pos2]) && testGameMarkers[pos2].Equals(testGameMarkers[pos3]);
        }


        private static void GameEngine(char[] gameMarker, int currentPlayer)
        {
            bool notValidMove = true;

            do
            {
                string userInput = Console.ReadLine();

                //Se qualcuno preme lo stesso numero allora se la stringa dell array e gia stata scritto allora 
                if (!string.IsNullOrEmpty(userInput) &&
                    (userInput.Equals("1") ||
                    userInput.Equals("2") ||
                    userInput.Equals("3") ||
                    userInput.Equals("4") ||
                    userInput.Equals("5") ||
                    userInput.Equals("6") ||
                    userInput.Equals("7") ||
                    userInput.Equals("8") ||
                    userInput.Equals("9")))
                {
                    Console.Clear();

                    //Con tryparse trasformiamo la stringa in un numero
                    int.TryParse(userInput, out var gamePlacementMarker);

                    char currentMaker = gameMarker[gamePlacementMarker - 1];

                    //X or O
                    if (currentMaker.Equals('X') || currentMaker.Equals('O'))
                    {
                        Console.WriteLine("Placement has already a marker please select another placement");
                    }
                    else
                    {
                        gameMarker[gamePlacementMarker - 1] = GetNextPlayerMarker(currentPlayer);
                        notValidMove = false;
                    }
                }

                else
                {
                    Console.WriteLine("Invalid value!");
                }
            } while (notValidMove);


          
        }


        //Quando durante la scelta del Player ovviamente uno puo inserire solamente x e la ltro invece solamente O e si puo fare con la logica del pari
        private static char GetNextPlayerMarker(int player)
        {
            if (player % 2 == 0)
            {
                return 'O';
            }

            return 'X';
        }

        static void HeadsUpDisplay(int PlayerNumber)
        {
            //Istruction

            Console.WriteLine("Herzlichen Wilkommen bei TIC TAC TOE spiel!!");
            Console.WriteLine("Player 1 : X");
            Console.WriteLine("Player 2 : O");
            Console.WriteLine();

            Console.WriteLine($"Player >>{PlayerNumber}<< to Move, select 1 thorugh 9 from the Game board");
            Console.WriteLine();
        }

        static void DrawBoard(char[] gameMarker)
        {
            //Zeichen der Game Board

            Console.WriteLine($" {gameMarker[0]} | {gameMarker[1]}  | {gameMarker[2]}  ");
            Console.WriteLine($"---+---+---");
            Console.WriteLine($" {gameMarker[3]} | {gameMarker[4]}  | {gameMarker[5]}  ");
            Console.WriteLine($"---+---+---");
            Console.WriteLine($" {gameMarker[6]} | {gameMarker[7]}  | {gameMarker[8]}  ");
            Console.WriteLine();
    
        }

        static int GetNextPlayer(int player)
        {
            if (player.Equals(1))
            {
                return 2;
            }
            else
            {

                return 1;
            }

        }
    }
}
