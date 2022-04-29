using System;

namespace switchCaseUtility
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            string inputNumber1 = Console.ReadLine();
            switch (inputNumber1)
            {
                case "1": Console.WriteLine("Sunday"); break; //Makes a ""jump table" for selecting the pathe of execution. Compiles much quicker than a series of equivalent if/elses
                case "2": Console.WriteLine("Monday"); break; //Great for fixed data values
                case "3": Console.WriteLine("Tuesday"); break;
                case "4": Console.WriteLine("Wednesday"); break;
                case "5": Console.WriteLine("Thursday"); break;
                case "6": Console.WriteLine("Friday"); break;
                case "7": Console.WriteLine("Saturday"); break;

                default: Console.WriteLine("Nope"); break;
            }
            
            string inputNumber2 = Console.ReadLine();

            if (inputNumber2 == "1"){ Console.WriteLine("Sunday"); }
            else if (inputNumber2 == "2"){ Console.WriteLine("Monday"); }
            else if (inputNumber2 == "3"){ Console.WriteLine("Tuesday"); }
            else if (inputNumber2 == "4"){ Console.WriteLine("Wednesday"); }
            else if (inputNumber2 == "5"){ Console.WriteLine("Thursday"); }
            else if (inputNumber2 == "6"){ Console.WriteLine("Friday"); }
            else if (inputNumber2 == "7"){ Console.WriteLine("Saturday"); }

            else Console.WriteLine("Nope");

            string inputNumber4 = Console.ReadLine();
            int intInputNumber4 = Convert.ToInt32(inputNumber4);

            switch(intInputNumber4)
            {
                case 1 : Console.WriteLine("Weekend"); break; //Way less efficient to type
                case 2: Console.WriteLine("Work"); break;
                case 3: Console.WriteLine("Work"); break;
                case 4: Console.WriteLine("Work"); break;
                case 5: Console.WriteLine("Work"); break;
                case 6: Console.WriteLine("Work"); break;
                case 7: Console.WriteLine("Weekend"); break;
                case 8: Console.WriteLine("Weekend"); break;
                case 9: Console.WriteLine("Work"); break;
                case 10: Console.WriteLine("Work"); break;
                case 11: Console.WriteLine("Work"); break;
                case 12: Console.WriteLine("Work"); break;
                case 13: Console.WriteLine("Work"); break;
                case 14: Console.WriteLine("Weekend"); break;
                case 15: Console.WriteLine("Weekend"); break;
                case 16: Console.WriteLine("Vacation"); break;
                case 17: Console.WriteLine("Vacation"); break;
                case 18: Console.WriteLine("Vacation"); break;
                case 19: Console.WriteLine("Vacation"); break;
                case 20: Console.WriteLine("Vacation"); break;
                case 21: Console.WriteLine("Vacation"); break;
                case 22: Console.WriteLine("Vacation"); break;
                case 23: Console.WriteLine("Work"); break;
                case 24: Console.WriteLine("Work"); break;
                case 25: Console.WriteLine("Work"); break;
                case 26: Console.WriteLine("Work"); break;
                case 27: Console.WriteLine("Work"); break;
                case 28: Console.WriteLine("Weekend"); break;
                case 29: Console.WriteLine("Weekend"); break;
                case 30: Console.WriteLine("Work"); break;





                default: Console.WriteLine("Nope"); break;
            }
            
            
            
            string inputNumber3 = Console.ReadLine();         //Console.ReadLine(); //More efficient with booleans
            int intInputNumber3 = Convert.ToInt32(inputNumber3);      //Great for ranges of values //More Efficient to type
            
            for (int i = 1; i < 31; i++)
            if ((intInputNumber3 > 1 && intInputNumber3 < 7) || (intInputNumber3 > 8 && intInputNumber3 < 14) || 
            (intInputNumber3 > 22 && intInputNumber3 < 28) || intInputNumber3 == 30 )
            {
                Console.WriteLine("Work");
            }
            else if (intInputNumber3 == 1 || intInputNumber3 == 7 || intInputNumber3 == 8 || intInputNumber3 == 14 || intInputNumber3 == 15 ||
            intInputNumber3 == 28 || intInputNumber3 == 29)
            {
                Console.WriteLine("Weekend");
            }
            else if (intInputNumber3 > 15 && intInputNumber3 < 23)
            {
                Console.WriteLine("Vacation");
            }
            else Console.WriteLine("Nope");
        }
    }
}
