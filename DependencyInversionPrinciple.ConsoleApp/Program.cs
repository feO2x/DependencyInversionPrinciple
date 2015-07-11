using System;
using System.IO;

namespace DependencyInversionPrinciple.ConsoleApp
{
    public class File
    {
        private static StreamWriter _streamWriter;

        public static void InitializeStreamWriter(string filePath)
        {
            _streamWriter = new StreamWriter(filePath);
        }

        public static void Write(char character)
        {
            _streamWriter.Write(character);
        }

        public static void Dispose()
        {
            _streamWriter.Close();
            _streamWriter = null;
        }
    }

    public enum Target
    {
        Console,
        File
    }

    class Program
    {
        static void Main()
        {
            Copy(Target.File);
        }

        private static void Copy(Target target)
        {
            if (target == Target.File)
                File.InitializeStreamWriter("Text.txt");

            while(true)
            {
                var consoleKeyInfo = Console.ReadKey(true);
                if (consoleKeyInfo.Key == ConsoleKey.Escape)
                    break;
                if (target == Target.Console)
                    Console.Write(consoleKeyInfo.KeyChar);
                else if (target == Target.File)
                    File.Write(consoleKeyInfo.KeyChar);
            }

            if (target == Target.File)
                File.Dispose();
        }
    }
}
