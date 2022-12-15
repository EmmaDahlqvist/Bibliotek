using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibliotek.Other
{
    internal class Option1or2
    {
        public int ChooseOption1Or2()
        {
            int input;
            do
            {
                try
                {
                    input = int.Parse(Console.ReadLine());
                    if (input == 1 || input == 2)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Välj alternativ 1 eller 2!");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Välj alternativ 1 eller 2!");
                }
            } while (true);

            return input;
            
        }
    }
}
