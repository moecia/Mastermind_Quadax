using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mastermind_Quadax
{
    class Digit
    {
        public int Value { get; private set; }
        public int Position { get; private set; }

        public Digit(int position)
        {
            Random random = new Random();
            Value = random.Next(1, 6);
            Position = position;           
        }
    }
}
