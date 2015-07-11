namespace DependencyInversionPrinciple.ConsoleApp
{
    class Program
    {
        static void Main()
        {
            // Composition Root
            var reader = new ConsoleReader();
            var writer = new ConsoleWriter();
            //var writer = new FileWriter("Text.txt");
            var copyProcess = new CopyProcess(reader, writer);

            // Run the actual program
            copyProcess.Execute();

            // Teardown
            //writer.Dispose(); Not necessary for ConsoleWriter
        }
    }
}
