namespace DependencyInversionPrinciple.ConsoleApp
{
    public struct ReadResult
    {
        public readonly char Character;
        public readonly bool ShouldQuit;

        public ReadResult(char character, bool shouldQuit)
        {
            Character = character;
            ShouldQuit = shouldQuit;
        }
    }
}