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

namespace HR_CatsandaMouse
{
    class Program
    {
        static string catAndMouse(int x, int y, int z)
        {
            int ACatDistance = Math.Abs(x - z);
            int BCatDistance = Math.Abs(y - z);
            
            if(ACatDistance < BCatDistance)
            {
                return "Cat A";
            }
            else if(ACatDistance > BCatDistance)
            {
                return "Cat B";
            }
            else
            {
                return "Mouse C";
            }
        }

        static void Main(string[] args) 
        {
            TextWriter textWriter = new StreamWriter(("c:\\Users\\Tariq Saddler\\RevatureFiles\\TariqSaddlerRevature1_\\cSharpHRChallenges\\HR_CatsandaMouse\\OUTPUT.txt"), true);

            int q = Convert.ToInt32(Console.ReadLine());

            for (int qItr = 0; qItr < q; qItr++) 
            {
                string[] xyz = Console.ReadLine().Split(' ');

                int x = Convert.ToInt32(xyz[0]);

                int y = Convert.ToInt32(xyz[1]);

                int z = Convert.ToInt32(xyz[2]);

                string result = catAndMouse(x, y, z);

                textWriter.WriteLine(result);
            }

            textWriter.Flush();
            textWriter.Close();
        }
    }
}
