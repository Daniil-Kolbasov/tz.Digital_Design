namespace task2
{
	internal interface IEncounteredWords
	{
		public IEnumerable<(string, int)> GetList(string input, bool ignorCase);
	}
}
