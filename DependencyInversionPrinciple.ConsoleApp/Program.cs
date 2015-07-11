using System;

namespace DependencyInversionPrinciple.ConsoleApp
{
    class Program
    {
        static void Main()
        {
            Copy();
        }

        private static void Copy()
        {
            while(true)
            {
                var consoleKeyInfo = Console.ReadKey(true);
                if (consoleKeyInfo.Key == ConsoleKey.Escape)
                    return;
                Console.Write(consoleKeyInfo.KeyChar);
            }
        }
    }
}
