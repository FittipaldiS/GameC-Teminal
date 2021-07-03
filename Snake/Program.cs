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
                   
                    canvas.drawCanvas();

                    Console.SetCursorPosition(90, 5);
                    Console.WriteLine("Score: {0}", snake.score);
                    snake.Input();
                    food.drawFood();
                    snake.drawSnake();
                    snake.moveSnake();
                    snake.eat(food.foodLocation(), food);
                    snake.isDead();
                    snake.hitWall(canvas);
                }
                catch (SnakeException e)
                {
                    Console.Clear();
                    Console.WriteLine(e.Message);

                    Console.WriteLine("Restart (y/n)");
                    char c = char.Parse(Console.ReadLine());


                    switch (c)
                    {
                        case 'y':
                           
                            snake.x=20;
                            snake.y = 20;
                            snake.score = 0;
                            snake.snakeBody.RemoveRange(0, snake.snakeBody.Count - 1);
                        
                            break;

                        case 'n':
                            finished = true;

                            break;
                    }

                }
            
                //Console.Read();
            }
           
        }
    }
}
