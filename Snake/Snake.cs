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
        public List<Position> snakeBody { get; set; }

        public int x { get; set; }
        public int y { get; set; }

        public int score { get; set; }


        //Construtto con la posizione del Serpente piu la lista posizione
        public Snake()
        {
            x = 20;
            y = 20;
            score = 0;

            snakeBody = new List<Position>();
            snakeBody.Add(new Position(x, y));


        }

        public void drawSnake()
        {
            foreach (Position pos in snakeBody)
            {
                Console.SetCursorPosition(pos.x, pos.y);
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
            if (key == 'w' && dir !='d')
            {
                dir = 'u';
            }
            else if (key =='s' && dir !='u')
            {
                dir = 'd';
            }
            else if (key == 'd' && dir !='l')
            {
                dir = 'r';
            }
            else if (key == 'a' && dir != 'r')
            {
                dir = 'l';
            }
        }

        public void moveSnake()
        {
            direction();

            if(dir == 'u')
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

            snakeBody.Add(new Position(x, y));
            snakeBody.RemoveAt(0);
            Thread.Sleep(100);
        }

        public void eat(Position food, Food f)
        {
            //Abbiamo bisogno dell ultima posizione del corpo del serpente
            Position head = snakeBody[snakeBody.Count - 1];//head

            if (head.x == food.x && head.y == food.y)
            {
                snakeBody.Add(new Position(x, y));
                f.foodNewLocation();
                score++;
            }
        }

        public void isDead()
        {

            Position head = snakeBody[snakeBody.Count - 1];//head

            for (int i = 0; i < snakeBody.Count -2; i++)
            {
                Position sb = snakeBody[i]; //stocca tutte le posizioni in lista

                if (head.x == sb.x && head.y == sb.y) // se lo snake è se stessa
                {
                    throw new SnakeException("LOSER!!!!");
                }

            }

        }

        public void hitWall(Canvas canvas)
        {
            Position head = snakeBody[snakeBody.Count - 1];
            if (head.x >= canvas.Width || head.x <= 0 || head.y >= canvas.Height || head.y <= 0)
            {
                throw new SnakeException("You DEAD!!!!");
            }

        }

    }
}
