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

        public static void InsertionSort(List<int> list)
        {
            int i, j;
            for (i = 1; i < list.Count; i++)
            {
                int item = list[i];
                int ins = 0;
                for (j = i - 1; j >= 0 && ins != 1;)
                {
                    if (item < list[j])
                    {
                        list[j + 1] = list[j];
                        j--;
                        list[j + 1] = item;
                    }
                    else ins = 1;
                }
            }
        }

        public static void CombSort(List<int> data) //from https://www.csharpstar.com
        {
            double gap = data.Count;
            bool swaps = true;

            while (gap > 1 || swaps)
            {
                gap /= 1.247330950103979;

                if (gap < 1)
                    gap = 1;

                int i = 0;
                swaps = false;

                while (i + gap < data.Count)
                {
                    int igap = i + (int)gap;

                    if (data[i] > data[igap])
                    {
                        int temp = data[i];
                        data[i] = data[igap];
                        data[igap] = temp;
                        swaps = true;
                    }

                    ++i;
                }
            }
        }

        private static List<int> MergeSort(List<int> unsorted) //From w3resource.com
        {
            if (unsorted.Count <= 1)
                return unsorted;

            List<int> left = new List<int>();
            List<int> right = new List<int>();

            int middle = unsorted.Count / 2;
            for (int i = 0; i < middle; i++)  //Dividing the unsorted list
            {
                left.Add(unsorted[i]);
            }
            for (int i = middle; i < unsorted.Count; i++)
            {
                right.Add(unsorted[i]);
            }

            left = MergeSort(left);
            right = MergeSort(right);
            return Merge(left, right);
        }

        private static List<int> Merge(List<int> left, List<int> right) //From w3resource.com
        {
            List<int> result = new List<int>();

            while (left.Count > 0 || right.Count > 0)
            {
                if (left.Count > 0 && right.Count > 0)
                {
                    if (left.First() <= right.First())  //Comparing First two elements to see which is smaller
                    {
                        result.Add(left.First());
                        left.Remove(left.First());      //Rest of the list minus the first element
                    }
                    else
                    {
                        result.Add(right.First());
                        right.Remove(right.First());
                    }
                }
                else if (left.Count > 0)
                {
                    result.Add(left.First());
                    left.Remove(left.First());
                }
                else if (right.Count > 0)
                {
                    result.Add(right.First());

                    right.Remove(right.First());
                }
            }
            return result;
        }
        private static void QuickSort(List<int> list, int left, int right) //From w3resource.com
        {
            if (left < right)
            {
                int pivot = Partition(list, left, right);

                if (pivot > 1)
                {
                    QuickSort(list, left, pivot - 1);
                }
                if (pivot + 1 < right)
                {
                    QuickSort(list, pivot + 1, right);
                }
            }
        }

        private static int Partition(List<int> list, int left, int right) //From w3resource.com
        {
            int pivot = list[left];
            while (true)
            {

                while (list[left] < pivot)
                {
                    left++;
                }

                while (list[right] > pivot)
                {
                    right--;
                }

                if (left < right)
                {
                    if (list[left] == list[right]) return right;

                    int temp = list[left];
                    list[left] = list[right];
                    list[right] = temp;


                }
                else
                {
                    return right;
                }
            }
        }

        public static void MakeRandomList(List<int> list, int size) //From w3resource.com
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
            List<int> tallista3 = new List<int>();
            List<int> tallista4 = new List<int>();
            List<int> tallista5 = new List<int>();
            List<int> tallista6 = new List<int>();
            List<int> tallista7 = new List<int>();
            
            MakeRandomList(tallista1,listSize);
            MakeRandomList(tallista2, listSize);
            MakeRandomList(tallista3, listSize);
            MakeRandomList(tallista4, listSize);
            MakeRandomList(tallista5, listSize);
            MakeRandomList(tallista6, listSize);
            MakeRandomList(tallista7, listSize);
            
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

            sw.Reset();
            sw.Start();
            InsertionSort(tallista3);
            sw.Stop();
            Console.WriteLine("Insertionsort: " + sw.ElapsedMilliseconds + " millisekunder"); 

            sw.Reset();
            sw.Start();
            MergeSort(tallista4);
            sw.Stop();
            Console.WriteLine("Merge Sort: " + sw.ElapsedMilliseconds + " millisekunder");

            sw.Reset();
            sw.Start();
            QuickSort(tallista5,0,tallista5.Count-1);
            sw.Stop();
            Console.WriteLine("Quick Sort: " + sw.ElapsedMilliseconds + " millisekunder");

            sw.Reset();
            sw.Start();
            CombSort(tallista6);
            sw.Stop();
            Console.WriteLine("Comb Sort: " + sw.ElapsedMilliseconds + " millisekunder");

            sw.Reset();
            sw.Start();
            tallista7.Sort();
            sw.Stop();
            Console.WriteLine(".NET built in sort: " + sw.ElapsedMilliseconds + " millisekunder");

        }
    }
}
