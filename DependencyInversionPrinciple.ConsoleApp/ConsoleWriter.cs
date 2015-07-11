using System;

namespace DependencyInversionPrinciple.ConsoleApp
{
    public class ConsoleWriter : IWriter
    {
        public void Write(char character)
        {
            Console.Write(character);
        }
    }
}
