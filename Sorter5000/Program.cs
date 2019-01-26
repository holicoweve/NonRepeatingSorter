using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Sorter5000
{
    class Program
    {
        static void Main(string[] args)
        {
            // Testing dataSet
            int[] dataSet = new int[] { 100, 20, 50, 70, 1, 60, 80, 10, 90, 5000, 30, 40 };

            // Instantiate Sorter, we are told the integers will be between the value 1 and 5000.
            Sorter mySorter = new Sorter(1, 5000);

            // Populate the sorter with integers from the dataSet, every integer is only accessed once.
            foreach (int i in dataSet)
            {
                mySorter.SotreInt(i);
            }

            // Printed the sorted integers to console.
            Console.WriteLine(mySorter.PrintSorted());

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();

        }
    }

    /// <summary>
    /// Sort non-repeating integers in a given range, in ascending order
    /// Usage: 
    /// 1. Instantiate Sorter by defining the maximum and minimum value of integers that we will encounter, wider range will consume more memory.
    /// 2. Populate sorter by calling SotreInt.
    /// 3. PrintSorter will print the sorted integers in ascending order.
    /// 
    /// Note:
    /// Values and Indices are not checked for out of bound exception, so the thought process of this algorithm stands out. 
    /// for real world, obviously we need to check the parameters supplied to us.
    /// </summary>
    class Sorter
    {
        private BitArray myBitArray;
        private int startingIndex;

        /// <summary>
        /// Instantiate a sorter that can handle integers between min and max
        /// </summary>
        /// <param name="min">Minimum value that sorter can handle</param>
        /// <param name="max">Maximum value that sorter can handle</param>
        public Sorter(int min, int max)
        {
            myBitArray = new BitArray(max - min + 1);
            startingIndex = min;
        }

        /// <summary>
        /// Populate sorter with supplied integer
        /// </summary>
        /// <param name="num">Integer to be stored in the sorter</param>
        public void SotreInt(int num)
        {
            myBitArray[num - startingIndex] = true;
        }

        /// <summary>
        /// Produce a string of sorted integers currently in sorter
        /// </summary>
        /// <returns>String of sorted integers</returns>
        public string PrintSorted()
        {
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < myBitArray.Length; i++)
            {
                if (myBitArray[i] == true)
                {
                    result.AppendLine((i + startingIndex).ToString());
                }
            }

            return result.ToString();
        }
    }
}
