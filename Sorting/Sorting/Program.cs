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

        public static void SelectionSort(List<int> list)
        {
            //pos_min is short for position of min
            int pos_min, temp;

            for (int i = 0; i < list.Count - 1; i++)
            {
                pos_min = i;//set pos_min to the current index of array

                for (int j = i + 1; j < list.Count; j++)
                {
                    if (list[j] < list[pos_min])
                    {
                        //pos_min will keep track of the index that min is in, this is needed when a swap happens
                        pos_min = j;
                    }
                }

                //if pos_min no longer equals i than a smaller value must have been found, so a swap must occur
                if (pos_min != i)
                {
                    temp = list[i];
                    list[i] = list[pos_min];
                    list[pos_min] = temp;
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
            SelectionSort(tallista);
            foreach(int element in tallista)
            {
                Console.Write(element + " ");
            }
        }
    }
}
