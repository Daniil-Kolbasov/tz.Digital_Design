namespace task2
{
	internal class WorkWithFiles
	{
		public static void WriteWords(string readFrom, string writeTo)
		{
			string text = File.ReadAllText(readFrom);

			IEncounteredWords encounteredWords = new EncounteredWords();
			IEnumerable<(string, int)> list = encounteredWords.GetList(text);

			// finding the maximum length of result
			int max = 0;
			foreach (var item in list)
			{
				if (item.Item1.Length > max)
					max = item.Item1.Length;
			}

			string format = $"{{0,{-max}}} | {{1}}";
			List<string> result = new();
			foreach (var item in list)
			{
				result.Add(string.Format(format, item.Item1, item.Item2));
			}

			File.WriteAllText(writeTo, string.Join(Environment.NewLine, result.ToArray()));
		}

		public static void Output()
		{
			string readFrom = "sampleQuotes.txt";
			string writeTo = "result.txt";

			Console.WriteLine("Do you want to install files for reading and writing?");
			Console.Write("(Yes/No): ");

			string option = Console.ReadLine() ?? "no";
			if (option.ToLower() == "yes")
			{
				Console.WriteLine("\nSet the path to read the file:");
				readFrom = Console.ReadLine() ?? readFrom;

				Console.WriteLine("\nSet the path to write the file:");
				writeTo = Console.ReadLine() ?? writeTo;
			}

			try
			{
				WriteWords(readFrom, writeTo);
                Console.WriteLine("Сompleted successfully");
            }
			catch (Exception ex)
			{
                Console.WriteLine(ex.Message);
            }
		}
	}
}
