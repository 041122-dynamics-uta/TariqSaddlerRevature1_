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

namespace HR_TimeConversion
{
    class Result
{

    /*
     * Complete the 'timeConversion' function below.
     *
     * The function is expected to return a STRING.
     * The function accepts STRING s as parameter.
     */

    public static string timeConversion(string s)
    {
        
        int theHour = Int32.Parse(s.Substring(0, 2));
        int INTmilitaryHour = theHour + 12;
        string STRmilitaryHour = INTmilitaryHour.ToString();
        string militaryTime = s.Substring(2, 6);

        if(s.Substring(8) == "AM" && s.Substring(0, 2) == "12")
        {
            militaryTime = militaryTime.Insert(0, "00");  
        }
        
        else if(s.Substring(8) == "PM" && s.Substring(0, 2) != "12")
        {
            if(s.Substring(0, 1) == "0")
            {
                theHour = Int32.Parse(s.Substring(1, 1));
                INTmilitaryHour = theHour + 12;
                STRmilitaryHour = INTmilitaryHour.ToString();
            }
            if(theHour < 12)
            {
                militaryTime = militaryTime.Insert(0, STRmilitaryHour);
            }
        }
        
        else
        {
            militaryTime = militaryTime.Insert(0, s.Substring(0, 2));
        }
        
        return militaryTime;
    }

}
    class Program
    {
        static void Main(string[] args)
        {
            TextWriter textWriter = new StreamWriter(("c:\\Users\\Tariq Saddler\\RevatureFiles\\TariqSaddlerRevature1_\\cSharpHRChallenges\\HR_TimeConversion\\OUTPUT.txt"), true);

            string s = Console.ReadLine();

            string result = Result.timeConversion(s);

            textWriter.WriteLine(result);

            textWriter.Flush();
            textWriter.Close();
        }
    }
}
