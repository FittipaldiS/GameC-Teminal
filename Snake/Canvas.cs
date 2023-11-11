using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class Canvas
    {
        //Altezza e Lunghezza con i cicli for costruiamo il nostro spazio
        public int Width { get; set; }
        public int Height { get; set; }

        public Canvas()
        {
            Width = 50;
            Height = 20;

            Console.CursorVisible = false;
        }

        public void DrawCanvas()
        {
            Console.Clear();

            for (int i = 0; i < Width; i++)
            {
                Console.SetCursorPosition(i, 0) ;
                Console.Write("_");
            }

            for (int i = 0; i < Width; i++)
            {
                Console.SetCursorPosition(i, Height);
                Console.Write("_");
            }

            for (int i = 0; i < Height; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write("|");
            }

            for (int i = 0; i < Height; i++)
            {
                Console.SetCursorPosition(Width, i);
                Console.WriteLine("|");
            }


        }







    }
}
