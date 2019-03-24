using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    class Program
    {
        public static void Bubblesort(List<int> list)
        {
            for(int i = 0; i < list.Count - 1; i++)
            {
                for(int j=0;j<list.Count-i-1;j++)
                {
                    if (list[j] > list[j + 1])
                    {
                        int temp = list[j];
                        list[j] = list[j + 1];
                        list[j + 1] = temp;
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            List<int> tallista = new List<int>();
            tallista.Add(8);
            tallista.Add(4);
            tallista.Add(1);
            tallista.Add(9);
            tallista.Add(5);
            Bubblesort(tallista);
            foreach(int element in tallista)
            {
                Console.Write(element + " ");
            }
        }
    }
}
