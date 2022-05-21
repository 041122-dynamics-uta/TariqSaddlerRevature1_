using System;
using System.Collections.Generic;
using System.Linq;

namespace sweetNSalty
{
    class Program
    {
        static void Main(string[] args)
        {
            void fun()
            {
                int lineBreak = 0;

                //List<int> total = new List<int>();

                int sweets = 0;
                int saltys = 0;
                int sns = 0;


                Console.WriteLine("Gimme a start number");
                int num1 = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Gimme an end number");
                int num2 = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Gimme the quantity to print per line");
                int qty = Convert.ToInt32(Console.ReadLine());
                
                

                int range = num2 - num1;

                IEnumerable<int> total = Enumerable.Range(num1, range);

                // for(int i = num1; i<=num1 + range; i++)
                // {
                //     total.Add(i);
                // }
                int k = Convert.ToInt32(Console.ReadLine());
                foreach(int i in total)
                {
                    if(lineBreak == qty)
                    {
                        Console.WriteLine();
                        lineBreak = 0;
                    }

                    if(i % 3 == 0 && i % 5 == 0)
                    {
                        Console.Write("Sweet&Salty ");
                        sns++;
                    }
                    else if(i % 3 == 0)
                    {
                        Console.Write("Sweet ");
                        sweets++;
                    }
                    else if(i % 5 == 0)
                    {
                        Console.Write("Salty ");
                        saltys++;
                    }
                    else
                    {
                        Console.Write($"{i} ");
                    }

                    lineBreak++;
                }
                Console.WriteLine();
                Console.WriteLine("-------------------------");
                Console.WriteLine($"Number of sweets: {sweets}");
                Console.WriteLine($"Number of saltys: {saltys}");
                Console.WriteLine($"Number of Sweet&Saltys {sns}");

                Console.WriteLine("-------------------------");
                Console.WriteLine("Wanna find some sweet and salty total? 'yes' or 'no'");
                string ans = Console.ReadLine();

                if(ans == "yes")
                {
                    fun();
                }
                else
                {
                    Console.WriteLine("Now I'm salty.");
                    Environment.Exit(0);
                }




            }
            fun();

        }
        
    }
}
