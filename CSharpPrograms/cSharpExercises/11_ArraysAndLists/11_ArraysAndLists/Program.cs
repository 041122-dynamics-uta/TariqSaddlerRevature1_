using System;
using System.Collections;
using System.Collections.Generic;

namespace _11_ArraysAndListsChallenge
{
    public class Program
    {
        public static void Main(string[] args)
        {

        }//EoM

        /// <summary>
        /// This method takes an array of integers and returns a double, the average 
        /// value of all the integers in the array
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public static double AverageOfValues(int[] array)
        {
            double sum = 0.0;
            double avg = 0.0;
            for(int i = 0; i<array.Length; i++)
            {
                sum += array[i];
            }
            avg = sum / array.Length;
            return avg;

            // double converted = 0.0;
            // for(int i = 0; i<array.Length; i++)
            // {
            //     converted = Convert.ToDouble(array[i]);
            //     total += converted;
            // }
            // avg = total / array.Length;
            // return avg;
            //throw new NotImplementedException("AverageOfValues has not been implemented yet.");
        }

        /// <summary>
        /// This method increases each array element by 2 and 
        /// returns an array with the altered values.
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static int[] SunIsShining(int[] x)
        {
            for(int i = 0; i<x.Length; i++)
            {
                x[i] += 2;
            }
            return x;
            //throw new NotImplementedException("SunIsShining has not been implemented yet.");
        }

        /// <summary>
        /// This method takes an ArrayList containing types of double, int, and string 
        /// and returns the average of the ints and doubles only, as a decimal.
        /// It ignores the string values and rounds the result to 3 decimal places toward the nearest even number.
        /// </summary>
        /// <param name="myArrayList"></param>
        /// <returns></returns>
        public static decimal ArrayListAvg(ArrayList myArrayList)
        {
            double sum = 0;
            int validElements = 0;
            for(int i = 0; i < myArrayList.Count; i++)
            {
                switch(myArrayList[i])
                {    
                    case int x:
                        sum += Convert.ToDouble(myArrayList[i]);
                        validElements++;
                    break;

                    case double x:
                        sum += Convert.ToDouble(myArrayList[i]);
                        validElements++;
                    break;
                    default:
                    break;
                }
            }

            decimal avg = Convert.ToDecimal(sum / validElements);
            avg = Math.Round(avg, 3);
            return avg;
            //throw new NotImplementedException("ArrayListAvg has not been implemented yet.");
        }

        /// <summary>
        /// This method returns the rank (starting with 1st place) of a new 
        /// score entered into a list of randomly ordered scores.
        /// </summary>
        /// <param name="myArray1"></param>
        public static int ListAscendingOrder(List<int> scores, int yourScore)
        {
            //scores.Sort();
            //int i = 0;
            int betterThan = 0;
            for(int i = 0; i < scores.Count; i++)
            {
                if(yourScore > scores[i])
                {
                    betterThan++;
                }
                // else if(yourScore < scores[i] && i == 0)
                // {
                //     return i;
                // }
            }
            //return 4;
            return betterThan+1;
            //throw new NotImplementedException("ListAscendingOrder has not been implemented yet.");
        }

        /// <summary>
        /// This method has with two parameters takes a List<string> and a string.
        /// The method returns true if the string parameter is found in the List, otherwise false.
        /// </summary>
        /// <param name="myArray2"></param>
        /// <param name="word"></param>
        /// <returns></returns>
        public static bool FindStringInList(List<string> myArray2, string word)
        {
            for(int i = 0; i<myArray2.Count; i++)
            {
                if(myArray2[i] == word)
                {
                    return true;
                }
            }
            return false;
            //throw new NotImplementedException("FindStringInList has not been implemented yet.");
        }
    }//EoP
}// EoN