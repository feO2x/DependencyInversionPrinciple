using LightInject;

namespace DependencyInversionPrinciple.ConsoleApp
{
    class Program
    {
        static void Main()
        {
            // Composition Root
            // We're using a DI container now
            var serviceContainer = new ServiceContainer();
            serviceContainer.Register<IReader, ConsoleReader>();
            serviceContainer.Register<IWriter, ConsoleWriter>();
            serviceContainer.Register<CopyProcess>();

            // Run the actual program
            // Obtain the root object of the object graph that is necessary to run this program
            var copyProcess = serviceContainer.GetInstance<CopyProcess>();
            copyProcess.Execute();

            // Teardown
            //writer.Dispose(); Not necessary for ConsoleWriter
        }
    }
}
