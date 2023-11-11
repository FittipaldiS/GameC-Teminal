using System;
using System.Collections.Generic;
using System.Threading;


namespace Snake
{
    public class Snake
    {
        ConsoleKeyInfo KeyInfo = new ConsoleKeyInfo();
        char Key = 'w';
        char Dir = 'u';

        //Fare la lista delle posizioni
        public List<Position> SnakeBody { get; set; }

        public int X { get; set; }
        public int Y { get; set; }

        public int Score { get; set; }


        //Construtto con la posizione del Serpente piu la lista posizione
        public Snake()
        {
            X = 20;
            Y = 20;
            Score = 0;

            SnakeBody = new List<Position>();
            SnakeBody.Add(new Position(X, Y));
        }

        public void DrawSnake()
        {
            foreach (Position pos in SnakeBody)
            {
                Console.SetCursorPosition(pos.X, pos.Y);
                Console.Write("▐");
            }
        }

        public void Input()
        {
            if (Console.KeyAvailable)
            {
                KeyInfo = Console.ReadKey(true);
                Key = KeyInfo.KeyChar;
            }
        }

        private void Direction()
        {
            if (Key == 'w' && Dir != 'd')
            {
                Dir = 'u';
            }
            else if (Key == 's' && Dir != 'u')
            {
                Dir = 'd';
            }
            else if (Key == 'd' && Dir != 'l')
            {
                Dir = 'r';
            }
            else if (Key == 'a' && Dir != 'r')
            {
                Dir = 'l';
            }
        }

        public void MoveSnake()
        {
            Direction();

            if (Dir == 'u')
            {
                Y--;
            }
            else if (Dir == 'd')
            {
                Y++;
            }
            else if (Dir == 'r')
            {
                X++;
            }
            else if (Dir == 'l')
            {
                X--;
            }

            SnakeBody.Add(new Position(X, Y));
            SnakeBody.RemoveAt(0);
            Thread.Sleep(100);
        }

        public void Eat(Position food, Food f)
        {
            //Abbiamo bisogno dell ultima posizione del corpo del serpente
            Position head = SnakeBody[SnakeBody.Count - 1];//head

            if (head.X == food.X && head.Y == food.Y)
            {
                SnakeBody.Add(new Position(X, Y));
                f.FoodNewLocation();
                Score++;
            }
        }

        public void IsDead()
        {
            Position head = SnakeBody[SnakeBody.Count - 1];//head

            for (int i = 0; i < SnakeBody.Count - 2; i++)
            {
                Position sb = SnakeBody[i]; //stocca tutte le posizioni in lista

                if (head.X == sb.X && head.Y == sb.Y) // se lo snake è se stessa
                {
                    throw new SnakeException("You ate yourself, you losers!");
                }
            }

        }

        public void HitWall(Canvas canvas)
        {
            Position head = SnakeBody[SnakeBody.Count - 1];
            if (head.X >= canvas.Width || head.X <= 0 || head.Y >= canvas.Height || head.Y <= 0)
            {
                throw new SnakeException("You DEAD!!!!");
            }
        }

    }
}
