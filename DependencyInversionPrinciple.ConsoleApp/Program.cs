namespace DependencyInversionPrinciple.ConsoleApp
{
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

            // Teardown
            writer.Dispose();
        }

        private static void Copy(IReader reader, IWriter writer) // This is dependency injection
        {
            // Copy is now programming only against the IReader and IWriter abstractions
            // There is no other dependency to concrete classes

            while(true)
            {
                var readResult = reader.Read();
                if (readResult.ShouldQuit)
                    break;
                writer.Write(readResult.Character);
            }
        }
    }
}
