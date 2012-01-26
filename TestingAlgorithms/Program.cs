using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestingAlgorithms
{
    class Program
    {


        

        static void Main(string[] args)
        {
            Console.Out.WriteLine("This application will show an implementation of the following algorithms:");

            Console.Out.WriteLine("1 QuickSort");
            Console.Out.WriteLine("2 Bubble Sort");
            Console.Out.WriteLine("3 Insertion Sort");

            Console.Out.WriteLine("Input the number of the Algorithm you would like to be demonstrated:");


            List<Int32> UnorderedList = new List<Int32>( new Int32[]{ 13, 4, 62, 7, 8, 9, 0, 12});

            String In = Console.In.ReadLine(); //Console read line



            switch(In)
            {
                case "1":
                    Console.Out.WriteLine("UnorderedList :" + PrintList(UnorderedList));
                    var OrderedList = QuickSort(UnorderedList);
                    Console.Out.WriteLine("OrderedList :" + PrintList(OrderedList));
                    break;
                case "2":
                    Console.Out.WriteLine("Sorry this is not implemented"); 
                    break;
                case "3":
                    Console.Out.WriteLine("Sorry this is not implemented");
                    break;
                default:
                    Console.Out.WriteLine("This input is not supported. Try again or x to exit");
                    break;
            }
                
            


            Console.Out.WriteLine(In);
            In = Console.In.ReadLine(); 

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



    }
}
