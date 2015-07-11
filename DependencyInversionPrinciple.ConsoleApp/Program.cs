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

    public interface IReader
    {
        ConsoleKeyInfo Read();
    }

    public class ConsoleReader : IReader
    {
        public ConsoleKeyInfo Read()
        {
            return Console.ReadKey(true);
        }
    }

    public interface IWriter
    {
        void Write(char character);
    }

    public class ConsoleWriter : IWriter
    {
        public void Write(char character)
        {
            Console.Write(character);
        }
    }

    public class FileWriter : IWriter, IDisposable
    {
        private readonly StreamWriter _streamWriter;

        public FileWriter(string filePath)
        {
            _streamWriter = new StreamWriter(filePath);
        }

        public void Dispose()
        {
            _streamWriter.Dispose();
        }

        public void Write(char character)
        {
            _streamWriter.Write(character);
        }
    }

    class Program
    {
        static void Main()
        {
            // Composition Root
            var reader = new ConsoleReader();
            //var writer = new ConsoleWriter();
            var writer = new FileWriter("Text.txt");

            // Run the actual program
            Copy(reader, writer);

            // Close external resource
            writer.Dispose();
        }

        private static void Copy(IReader reader, IWriter writer) // This is dependency injection
        {
            // Copy is now programming only against the IReader and IWriter abstractions
            // There is no other dependency to concrete classes

            while(true)
            {
                var consoleKeyInfo = reader.Read();
                if (consoleKeyInfo.Key == ConsoleKey.Escape)
                    break;
                writer.Write(consoleKeyInfo.KeyChar);
            }
        }
    }
}
