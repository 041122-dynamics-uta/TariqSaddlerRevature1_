using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;


namespace HR_MigratoryBirds
{
    class Result
    {

    /*
     * Complete the 'migratoryBirds' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts INTEGER_ARRAY arr as parameter.
     */

        public static int migratoryBirds(List<int> arr)
        {
            //MY CODE GOES HERE
            arr.Sort();
            int mostFrequent = arr[0];
            int currentElement = arr[0];
            int topCount = 1;
            int currentCount = 0;
            //Count how man times <arrayelement> shows up in the array

            for(int i=0; i<arr.Count; i += currentCount)
            {
                
                if(currentElement > 0 && currentElement < 5)
                {
                    currentElement = arr[i];// (1, 1, 1, 3, 3, 3, 3, 5)
                    
                    currentCount = 0;
                    for(int x=0; x<arr.Count; x++)
                    {
                        if(currentElement == arr[x])
                        {
                            currentCount++;
                        }
                        if(currentCount > topCount)
                        {
                            mostFrequent = currentElement;
                            topCount++;
                        }
                    }
                }
            }

            return mostFrequent;
        }

    }
        class Solution
        {
            public static void Main(string[] args)
            {
                
                TextWriter textWriter = new StreamWriter(("c:\\Users\\Tariq Saddler\\RevatureFiles\\TariqSaddlerRevature1_\\cSharpHRChallenges\\HR_MigratoryBirds\\OUTPUT.txt"), true);//DETERMINE THE DIRECTORY WHERE YOUR RESULTS WILL BE PRINTED

                int arrCount = Convert.ToInt32(Console.ReadLine().Trim());
                if(arrCount > 4 && arrCount < 200000)
                {
                    List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();
                    int result = Result.migratoryBirds(arr); 

                    textWriter.WriteLine(result);

                    textWriter.Flush();
                    textWriter.Close();
                    
                }
                else
                {
                    
                }
            }
            // List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList(); //THIS ACCEPTS AN ARRAY OF INTS FROM USER, EACH INT SPLIT BY A SPACE

            
            //'int' is the value type of variable
            //'result' is the name of the variable
            //'Result' is the name of the name of the class to access the following function
            //'migratoryBirds' is the name of the function
            //'(arr)' is the argument required by the function. An array.
        }
}
