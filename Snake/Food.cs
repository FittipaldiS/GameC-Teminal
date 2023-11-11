using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class Food
    {
        public Position foodPos = new Position();
        Random rnd = new Random();
        Canvas canvas = new Canvas();

        public Food()
        {
            foodPos.X = rnd.Next(5, canvas.Width);
            foodPos.Y = rnd.Next(5, canvas.Height);
        }

        public void DrawFood()
        {
            Console.SetCursorPosition(foodPos.X, foodPos.Y);
            Console.Write("F");
        }

        public Position FoodLocation()
        {
            return foodPos;
        }


        public void FoodNewLocation()
        {
            foodPos.X = rnd.Next(5, canvas.Width);
            foodPos.Y = rnd.Next(5, canvas.Height);
        }

    }
}
