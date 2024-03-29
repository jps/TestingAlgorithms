﻿using System;
using System.Collections.Generic;
using System.Collections.Specialized; 
using System.Linq;
using System.Text;

namespace TestingAlgorithms
{
    class Program
    {

        static void Main(string[] args)
        {

            List<Int32> _UnorderedList = GenrateRandomUnorderedList(10, 0, 100); //new List<Int32>( new Int32[]{ 13, 4, 62, 7, 8, 9, 0, 12});
            bool active = true;
            while (active)
            {
                Console.Out.WriteLine("This application will show an implementation of the following algorithms:");
                Console.Out.WriteLine("\n");
                Console.Out.WriteLine("1 QuickSort");
                Console.Out.WriteLine("2 Bubble Sort");
                Console.Out.WriteLine("3 Heap Sort");
                Console.Out.WriteLine("4 Generate new rand sequence");
                Console.Out.WriteLine("x to quit");
                Console.Out.WriteLine("Input the number of the Algorithm you would like to be demonstrated:");
                Console.Out.WriteLine("\n");

                String In = Console.In.ReadLine(); //Console read line
                List<Int32> UnorderedList = new List<Int32>(_UnorderedList); //new List<Int32>( new Int32[]{ 13, 4, 62, 7, 8, 9, 0, 12});
                List<Int32> OrderedList = new List<Int32>();
                switch (In)
                {
                    case "1":
                        Console.Out.WriteLine("\n");
                        Console.Out.WriteLine("UnorderedList :" + PrintList(UnorderedList));
                        OrderedList = QuickSort(UnorderedList);
                        Console.Out.WriteLine("OrderedList :" + PrintList(OrderedList));
                        Console.Out.WriteLine("\n");
                        break;
                    case "2":
                        Console.Out.WriteLine("\n");
                        Console.Out.WriteLine("UnorderedList :" + PrintList(UnorderedList));
                        OrderedList = BubbleSort(UnorderedList);
                        Console.Out.WriteLine("OrderedList :" + PrintList(OrderedList));
                        Console.Out.WriteLine("\n");
                        break;
                    case "3":
                        Console.Out.WriteLine("\n");
                        Console.Out.WriteLine("UnorderedList :" + PrintList(UnorderedList));
                        //HeapSort nhs = new HeapSort(UnorderedList;)
                        OrderedList = HeapSort.Sort(UnorderedList.ToArray()).ToList();
                        //OrderedList = nhs.UnorderedList.ToList();
                        Console.Out.WriteLine("OrderedList :" + PrintList(OrderedList));
                        Console.Out.WriteLine("\n");

                        break;
                    case "4":
                        Console.Out.WriteLine("amount : ");
                        In = Console.In.ReadLine(); //Console read line

                        Int32 amount;
                        try{
                            amount = Int32.Parse(In);
                        }catch{
                            amount = 10; 
                        }
                        _UnorderedList = GenrateRandomUnorderedList(amount, 0, 100); //new List<Int32>( new Int32[]{ 13, 4, 62, 7, 8, 9, 0, 12});
                        break;
                    case "x" :
                    case "X" :
                        active = false;
                        break; 
                    default:
                        Console.Out.WriteLine("This input is not supported. Try again or x to exit");
                        break;
                }
            }
        }


        static List<Int32> GenrateRandomUnorderedList(Int32 Amount, Int32 Min = Int32.MinValue, Int32 Max = Int32.MaxValue )
        {
            List<Int32> UnorderedList = new List<Int32>();
            Random rand = new Random();
            for (int i = 0; i < Amount; i++)
            {
                UnorderedList.Add(rand.Next(Min, Max));
            }
            return UnorderedList;
        }
        
        static String PrintList(List<Int32> List)
        {
            String Out = "";
            foreach (var item in List)
                Out += item + ",";
            return Out;
        }


        static List<Int32> QuickSort(List<Int32>UnorderedList) //this is a simple version that uses O(n) space 
        {
            if (UnorderedList.Count() <= 1)
                return UnorderedList;
            var pivotKey = UnorderedList.Count / 2; //Find a pivot point I'm taking the midpoint here
            Int32 Pivot = UnorderedList[pivotKey]; //take and assign pivot
            UnorderedList.RemoveAt(pivotKey); // remove pivot
            List<Int32> Less = new List<Int32>();
            List<Int32> Greater = new List<Int32>(); 
            foreach (Int32 x in UnorderedList) //if greater of less than pivot
                if (x < Pivot)
                    Less.Add(x);
                else
                    Greater.Add(x);
            //recursively call method on less and greater lists and then rebuild and return
            Less = QuickSort(Less);
            Less.Add(Pivot);
            return Less.Concat(QuickSort(Greater)).ToList(); 
        }



        class HeapSort
        {
            private static void Adjust(int[] list, int i, int size)
            {
                int Temp = list[i]; //temp value
                int j = i * 2 + 1; //double current index and increment to get children

                while (j <= size)
                {
                    //more children
                    if (j < size)
                        if (list[j] < list[j + 1])
                            j = j + 1;

                    //compare roots and the older children
                    if (Temp < list[j])
                    {
                        list[i] = list[j];
                        i = j;
                        j = 2 * i + 1;
                    }
                    else
                        j = size + 1; //increment j
                }

                list[i] = Temp; //replace item
            }

            public static int[] Sort (int[] list)
            {
                //build the initial heap
                for (int i = (list.Length - 1) / 2; i >= 0; i--)
                    Adjust (list, i, list.Length - 1);

                foreach( var a in list)
                Console.Out.WriteLine(a);

                //swap root node and the last heap node 
                for (int i = list.Length - 1; i >= 1; i--)
                {
                    int Temp = list [0];
                    list [0] = list [i];
                    list [i] = Temp;
                    Adjust (list, 0, i - 1);
                }

                return list;
            }
        }


        static List<Int32> BubbleSort(List<Int32> UnorderedList)
        {
            bool swapped; 
            do
            {
                swapped = false;
                for (int i = 1; i < UnorderedList.Count; ++i)//for each item in list
                {
                    if (UnorderedList[i - 1] > UnorderedList[i])//if item on left is greater than item on right swap.
                    {
                        Int32 hold = UnorderedList[i - 1]; //temp hold the value
                        UnorderedList[i - 1] = UnorderedList[i]; //shift value left
                        UnorderedList[i] = hold;//insert held value
                        swapped = true;
                    }
                }
            } while (swapped != false); //if no values were swapped this iteration list is sorted
            return UnorderedList;
        }
    }
}



