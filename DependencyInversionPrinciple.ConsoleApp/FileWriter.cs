using System;
using System.IO;

namespace DependencyInversionPrinciple.ConsoleApp
{
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
}
