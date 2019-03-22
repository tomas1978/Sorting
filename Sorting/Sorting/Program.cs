using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> tallista = new List<int>();
            tallista.Add(8);
            tallista.Add(4);
            tallista.Add(1);
            tallista.Add(9);
            tallista.Add(5);
            tallista.Sort();
            foreach(int element in tallista)
            {
                Console.Write(element + " ");
            }
        }
    }
}
