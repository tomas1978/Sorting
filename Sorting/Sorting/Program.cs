using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    class Program
    {
        public static void BubbleSort(List<int> list)
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

        public static void MakeRandomList(List<int> list, int size)
        {
            int newNumber;
            Random rand = new Random();
            for(int i=0;i<size;i++)
            {
                newNumber = rand.Next(0, size);
                list.Add(newNumber);
            }

        }

        static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();
            int listSize = 20000;
            List<int> tallista1 = new List<int>();
            List<int> tallista2 = new List<int>();
            MakeRandomList(tallista1,listSize);
            MakeRandomList(tallista2, listSize);
            sw.Reset();
            sw.Start();
            BubbleSort(tallista1);
            sw.Stop();
            Console.WriteLine("Bubblesort: " + sw.ElapsedMilliseconds + " millisekunder");
            sw.Reset();
            sw.Start();
            SelectionSort(tallista2);
            sw.Stop();
            Console.WriteLine("Selectionsort: " + sw.ElapsedMilliseconds + " millisekunder");

        }
    }
}
