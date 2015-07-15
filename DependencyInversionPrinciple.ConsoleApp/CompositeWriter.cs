using System;
using System.Collections.Generic;

namespace DependencyInversionPrinciple.ConsoleApp
{
    public class CompositeWriter : IWriter
    {
        private IEnumerable<IWriter> _writers;

        public CompositeWriter(IEnumerable<IWriter> writers)
        {
            if (writers == null) throw new ArgumentNullException("writers");

            _writers = writers;
        }

        public void Write(char character)
        {
            foreach (var writer in _writers)
            {
                writer.Write(character);
            }
        }
    }
}
