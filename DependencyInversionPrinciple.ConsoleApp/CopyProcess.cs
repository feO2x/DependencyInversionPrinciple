using System;

namespace DependencyInversionPrinciple.ConsoleApp
{
    public class CopyProcess
    {
        private readonly IReader _reader;
        private readonly IWriter _writer;

        public CopyProcess(IReader reader, IWriter writer)  // This is constructor injection
        {
            if (reader == null) throw new ArgumentNullException("reader");
            if (writer == null) throw new ArgumentNullException("writer");

            _reader = reader;
            _writer = writer;
        }

        public void Execute()
        {
            while (true)
            {
                var readResult = _reader.Read();
                if (readResult.ShouldQuit)
                    break;
                _writer.Write(readResult.Character);
            }
        }
    }
}
