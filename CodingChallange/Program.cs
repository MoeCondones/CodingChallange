﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallange
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] array = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int N = 3;

            //instantiating the class
            List<int[]> divArrays = ArrayDiv.divArray(array, N);

            //printing the divided arrays
            foreach (int[] subarray in divArrays)
            {
                Console.WriteLine(string.Join(", ", subarray));
            }
        }


        public class ArrayDiv
        {
            public static List<int[]> divArray(int[] array,int N)
            {
                //creating a new list to store the subarrays
                List<int[]> result = new List<int[]>();

                //this line is to check if the array is empty or not
                if (array == null || array.Length == 0)
                {
                    //if the array is empty you return an empty list
                    return result;
                }
                // this line is for calculating each subarray except for the last one
                int subArrayLength = array.Length / N;
                // this line is for calculating the number of elements in the last subarray 
                int remainderLength = array.Length % N;


                // now we need to create variables that keep track of each start indecies of the subarrays
                int startIndex = 0;

                //we create a loop to divide the array into subarrays
                for (int i = 0; i < N; i++)
                {
                    //this calculates the ending index of the current subarray
                    int endIndex = startIndex + subArrayLength;

                    //this checks if this is the last subarray 
                    if (i < remainderLength)
                    {
                        //if it is add an extra element to the last subarray
                        endIndex++;
                    }

                    //we need to create a new subarray with the appropriate size 
                    int[] subarray = new int[endIndex - startIndex];

                    //we need to now copy the elements from the original array to the subarray
                    for (int j = startIndex; j < endIndex; j++)
                    {
                        //this calculate the index of the subarray from the index of the original array
                        int subarrayIndex = j - startIndex;

                        //this copies the elements from the original array into the subarray
                        subarray[subarrayIndex] = array[j];
                    }

                    //this adds the subarrays to the list of subarrays
                    result.Add(subarray);

                    //this moves the starting index to the next subarray
                    startIndex = endIndex;
                }

                //return the list of subarrays
                return result;
            }
        }
    }
}
