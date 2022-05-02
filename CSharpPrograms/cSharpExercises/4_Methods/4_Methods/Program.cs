using System;

namespace _4_MethodsChallenge
{
    public class Program
    {
        public static void Main(string[] args)
        {
            /**
                YOUR CODE HERE.
            **/
        }

        public static string GetName()
        {
            
            string gotName = Console.ReadLine();
            return gotName;
            //throw new NotImplementedException("GetName() is not implemented yet0");
        }

        public static string GreetFriend(string name)
        {
            return ($"Hello, {name}. You are my friend.");
            //throw new NotImplementedException("GreetFriend() is not implemented yet");
        }

        public static double GetNumber()
        {
            string stringNumber = Console.ReadLine();
            int gotNumber = Int32.Parse(stringNumber);
            return gotNumber;
            //throw new NotImplementedException("GetNumber() is not implemented yet");

        }

        public static int GetAction()
        {
            string stringChoice = Console.ReadLine();
            int gotChoice = Int32.Parse(stringChoice);
            while(gotChoice < 1 && gotChoice > 4)
            {
                stringChoice = Console.ReadLine();
                gotChoice = Int32.Parse(stringChoice);
            }
            return gotChoice;
            //throw new NotImplementedException("GetAction() is not implemented yet");
        }

        public static double DoAction(double x, double y, int action)
        {
            double result;
            switch(action)
            {
                case 1: result = (x + y);
                break;
                case 2: result = Math.Abs(x - y);
                break;
                case 3: result = (x * y);
                break;
                case 4: result = (x / y);
                break;
                default: throw new FormatException("Invalid Input");
                break;

            }
            Console.WriteLine(result);
            return result;
            //throw new NotImplementedException("DoAction() is not implemented yet");
        }
    }
}
