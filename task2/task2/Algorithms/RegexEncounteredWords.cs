using System.Text.RegularExpressions;

namespace task2.Algorithms
{
    internal class RegexEncounteredWords : IEncounteredWords
    {
        public IEnumerable<(string, int)> GetList(string input, bool ignorCase = true)
        {
            List<string> words = new();

            if (ignorCase)
                input = input.ToLower();

            foreach (Match match in Regex.Matches(input, @"\w+('\w*)?").Cast<Match>())
            {
                // exception number
                if (Regex.IsMatch(match.Value, @"\d"))
                    continue;

                // exception apostrophe
                if (Regex.IsMatch(match.Value, @"\w+'\w"))
                    words.Add(match.Value.Substring(0, match.Value.IndexOf('\'')));
                else
                    words.Add(match.Value);
            }

            // sorded and grouped
            var result = from x in words
                         group x by x into g
                         let count = g.Count()
                         orderby count descending, g.Key
                         select (g.Key, count);

            return result;
        }
    }
}
