using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRS5
{
    internal class Class1
    {
        public void S()
        {
            Func<string> s;
            s = () => "a";
            s += () => "b";
            s += () => "c";
            Console.WriteLine(s());
        }

    }
}
