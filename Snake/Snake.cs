using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace Snake
{
    public class Snake
    {
        ConsoleKeyInfo keyInfo = new ConsoleKeyInfo();
        char key = 'w';
        char dir = 'u';

        //Fare la lista delle posizioni
        public List<Position> SnakeBody { get; set; }

        public int x { get; set; }
        public int y { get; set; }

        public int score { get; set; }


        //Construtto con la posizione del Serpente piu la lista posizione
        public Snake()
        {
            x = 20;
            y = 20;
            score = 0;

            SnakeBody = new List<Position>();
            SnakeBody.Add(new Position(x, y));


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
                keyInfo = Console.ReadKey(true);
                key = keyInfo.KeyChar;
            }
        }

        private void direction()
        {
            if (key == 'w' && dir != 'd')
            {
                dir = 'u';
            }
            else if (key == 's' && dir != 'u')
            {
                dir = 'd';
            }
            else if (key == 'd' && dir != 'l')
            {
                dir = 'r';
            }
            else if (key == 'a' && dir != 'r')
            {
                dir = 'l';
            }
        }

        public void MoveSnake()
        {
            direction();

            if (dir == 'u')
            {
                y--;
            }
            else if (dir == 'd')
            {
                y++;
            }
            else if (dir == 'r')
            {
                x++;
            }
            else if (dir == 'l')
            {
                x--;
            }

            SnakeBody.Add(new Position(x, y));
            SnakeBody.RemoveAt(0);
            Thread.Sleep(100);
        }

        public void Eat(Position food, Food f)
        {
            //Abbiamo bisogno dell ultima posizione del corpo del serpente
            Position head = SnakeBody[SnakeBody.Count - 1];//head

            if (head.X == food.X && head.Y == food.Y)
            {
                SnakeBody.Add(new Position(x, y));
                f.FoodNewLocation();
                score++;
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
