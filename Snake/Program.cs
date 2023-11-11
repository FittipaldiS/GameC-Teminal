using System;

namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            bool finished = false;
            Canvas canvas = new Canvas();
            Snake snake = new Snake();
            Food food = new Food();

            Console.WriteLine("\t \t \t \t PRESS ENTER");
            Console.Read();

            while (!finished)
            {
                try
                {

                    canvas.DrawCanvas();

                    Console.SetCursorPosition(90, 5);
                    Console.WriteLine("Score: {0}", snake.score);
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

                            snake.x = 20;
                            snake.y = 20;
                            snake.score = 0;
                            snake.SnakeBody.RemoveRange(0, snake.SnakeBody.Count - 1);

                            break;

                        case ConsoleKey.N:
                            finished = true;

                            break;
                    }

                    Console.Read();
                }
            }

        }
    }
}
