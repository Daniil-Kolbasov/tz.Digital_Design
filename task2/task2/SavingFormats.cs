namespace task2
{
    internal class SavingFormats : ISavingFromats
    {
        private readonly IEncounteredWords _encounteredWords;

        public SavingFormats(IEncounteredWords encounteredWords)
        {
			_encounteredWords = encounteredWords;
        }

        public void SimpleText(string readFrom, string writeTo = "result.txt")
        {
            // reading text
            string text = File.ReadAllText(readFrom);

			// get sorted encountered words
			IEnumerable<(string, int)> list = _encounteredWords.GetList(text, true);

            // finding the maximum length of result for formatting
            int max = 0;
            foreach (var item in list)
            {
                if (item.Item1.Length > max)
                    max = item.Item1.Length;
            }

            // formatting list
            string format = $"{{0,{-max}}} | {{1}}";
            List<string> result = new();
            foreach (var item in list)
            {
                result.Add(string.Format(format, item.Item1, item.Item2));
            }

            // save list
            File.WriteAllText(writeTo, string.Join(Environment.NewLine, result.ToArray()));
        }
    }
}
