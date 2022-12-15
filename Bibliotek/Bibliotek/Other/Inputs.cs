using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibliotek.Other
{
    internal class Inputs
    {
        public int ForceIntInput()
        {
            bool correctInt = false;
            do
            {
                try
                {
                    int input = int.Parse(Console.ReadLine());
                    return input;
                }
                catch (Exception ex)
                {
                }
            } while (!correctInt);
            return 0;
        }
    }
}
