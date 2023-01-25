using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibliotek.Other
{
    internal class ChooseOption
    {

        public int ThreeOption()
        {
            int input;
            do
            {
                try
                {
                    input = int.Parse(Console.ReadLine());
                    if (input == 1 || input == 2 || input == 3)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Välj alternativ 1, 2 eller 3!");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Välj alternativ 1, 2 eller 3!");
                }
            } while (true);

            return input;
        }
        public int TwoOption()
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

        public int OptionAmount(int amount)
        {
            int input = 0;
            bool correct = false;
            do
            {
                try
                {
                    input = int.Parse(Console.ReadLine());
                    for (int i = 1; i <= amount; i++)
                    {
                        if (input == i)
                        {
                            correct = true;
                        }
                    }
                    if (!correct)
                    {
                        Console.WriteLine("Välj ett efterfrågat alternativ!");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Vänligen välj en int!");
                }
            } while (!correct);

            return input;
        }
    }
}
