using task2.Algorithms;

namespace task2.Formats
{
    internal class PlainTextFormats : IFormat
    {
        private readonly IEncounteredWords _encounteredWords;

        public PlainTextFormats(IEncounteredWords encounteredWords)
        {
            _encounteredWords = encounteredWords;
        }

        public string RecordWords(string readFrom, string writeTo = "result.txt")
        {
            string text = File.ReadAllText(readFrom);

            IEnumerable<(string, int)> list = _encounteredWords.GetList(text, true);

            // finding the maximum length of formatingList for formatting
            int max = 0;
            foreach (var item in list)
            {
                if (item.Item1.Length > max)
                    max = item.Item1.Length;
            }

            // formatting list
            string format = $"{{0,{-max}}} | {{1}}";
            List<string> formatingList = new();
            foreach (var item in list)
            {
                formatingList.Add(string.Format(format, item.Item1, item.Item2));
            }

            string result = string.Join(Environment.NewLine, formatingList.ToArray());
            File.WriteAllText(writeTo, result);
            return result;
        }
	}
}
