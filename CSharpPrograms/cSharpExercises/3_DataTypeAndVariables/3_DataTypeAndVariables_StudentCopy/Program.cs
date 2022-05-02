using System;

namespace _3_DataTypeAndVariablesChallenge
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //
            //
            // Insert code here.
            //
            //
        }

        /// <summary>
        /// This method has an 'object' type parameter. 
        /// 1. Create a switch statement that evaluates for the data type of the parameter
        /// 2. You will need to get the data type of the parameter in the 'case' part of the switch statement
        /// 3. For each data type, return a string of exactly format, "Data type => <type>" 
        /// 4. For example, an 'int' data type will return ,"Data type => int",
        /// 5. A 'ulong' data type will return "Data type => ulong",
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string PrintValues(object obj)
        {
            
            switch(obj)
            {
                //case string s: s = "Data Type => String";
                case byte b: return "Data type => byte";
                break;
                case sbyte b: return "Data type => sbyte";
                break;
                case int b: return "Data type => int";
                break;
                case uint b: return "Data type => uint";
                break;
                case short b: return "Data type => short";
                break;
                case ushort b: return "Data type => ushort";
                break;
                case float b: return "Data type => float";
                break;
                case double b: return "Data type => double";
                break;
                case char b: return "Data type => char";
                break;
                case string b: return "Data type => string";
                break;
                case decimal b: return "Data type => decimal";
                break;
                case long b: return "Data type => long";
                break;
                case ulong b: return "Data type => ulong";
                break;
                default: return "";
                break;
            }
            //throw new NotImplementedException($"PrintValues() has not been implemented");
        }

        /// <summary>
        /// THis method has a string parameter.
        /// 1. Use the .TryParse() method of the Int32 class (Int32.TryParse()) to convert the string parameter to an integer. 
        /// 2. You'll need to investigate how .TryParse() and 'out' parameters work to implement the body of StringToInt().
        /// 3. If the string cannot be converted to a integer, return 'null'. 
        /// 4. Investigate how to use '?' to make non-nullable types nullable.
        /// </summary>
        /// <param name="numString"></param>
        /// <returns></returns>
        public static int? StringToInt(string numString)
        {
            int i;
            if(Int32.TryParse(numString, out i))
            {
                return i;
            }
            else
            {
                return null;
            }
            //throw new NotImplementedException($"StringToInt() has not been implemented");

        }
    }// end of class
}// End of Namespace
