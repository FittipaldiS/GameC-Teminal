using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class SnakeException : ApplicationException
    {
        public SnakeException(string message) : base(message)
        {

        }
    }
}
