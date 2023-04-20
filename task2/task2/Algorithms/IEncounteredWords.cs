namespace task2.Algorithms
{
    internal interface IEncounteredWords
    {
        public IEnumerable<(string, int)> GetList(string input, bool ignorCase);
    }
}
