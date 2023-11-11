using System;

namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            bool finished = false;
            Canvas canvas = new();
            Snake snake = new();
            Food food = new();

            Console.WriteLine("\t \t \t \t PRESS ENTER");
            Console.Read();

            while (!finished)
            {
                try
                {
                    canvas.DrawCanvas();

                    Console.SetCursorPosition(90, 5);

                    Console.WriteLine("Score: {0}", snake.Score);

                    snake.Input();
                    food.DrawFood();
                    snake.DrawSnake();
                    snake.MoveSnake();
                    snake.Eat(food.FoodLocation(), food);
                    snake.IsDead();
                    snake.HitWall(canvas);
                }
                catch (SnakeException e)
                {
                    Console.Clear();
                    Console.WriteLine(e.Message);

                    Console.WriteLine("Restart (y/n)");
                    ConsoleKeyInfo key = Console.ReadKey();

                    switch (key.Key)
                    {
                        case ConsoleKey.Y:

                            snake.X = 20;
                            snake.Y = 20;
                            snake.Score = 0;
                            snake.SnakeBody.RemoveRange(0, snake.SnakeBody.Count - 1);

                            break;

                        case ConsoleKey.N:

                            finished = true;

                            break;
                    }
                    //Console.Read();
                }
            }
        }
    }
}
