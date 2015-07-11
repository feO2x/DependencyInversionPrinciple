using System;

namespace DependencyInversionPrinciple.ConsoleApp
{
    public class ConsoleReader : IReader
    {
        public ReadResult Read()
        {
            var consoleKeyInfo = Console.ReadKey(true);
            return new ReadResult(consoleKeyInfo.KeyChar,
                                  consoleKeyInfo.Key == ConsoleKey.Escape);
        }
    }
}
