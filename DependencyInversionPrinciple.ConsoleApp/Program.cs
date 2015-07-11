using LightInject;

namespace DependencyInversionPrinciple.ConsoleApp
{
    class Program
    {
        private const string FilePath = "Text.txt";

        static void Main()
        {
            // Composition Root
            // We're using a DI container now
            var serviceContainer = new ServiceContainer();
            serviceContainer.Register<IReader, ConsoleReader>();
            serviceContainer.Register<IWriter>(f => new FileWriter(FilePath), new PerRequestLifeTime());
            serviceContainer.Register<CopyProcess>();

            // Run the actual program
            // Obtain the root object of the object graph that is necessary to run this program
            using (serviceContainer.BeginScope())
            {
                var copyProcess = serviceContainer.GetInstance<CopyProcess>();
                copyProcess.Execute();
            } // Teardown happens here
        }
    }
}
