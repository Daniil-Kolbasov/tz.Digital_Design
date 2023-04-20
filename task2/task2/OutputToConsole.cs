using task2.Algorithms;
using task2.Formats;

namespace task2
{
	internal class OutputToConsole
	{
		public static void Output()
		{
			msg("Open a file (path of a file):");
			string readFrom = enter();

			msg("Save the file (path of the file):");
			string writeTo = enter();

			IFormat format;
			format = new PlainTextFormats(new RegexEncounteredWords());

			try
			{
				format.RecordWords(readFrom, writeTo);
				msg("Сompleted successfully");
			}
			catch (Exception ex)
			{
				err(ex.Message);
			}
		}

		private static string enter()
		{
			string? input;
			do
				input = Console.ReadLine();
			while (input == null);
            Console.WriteLine();
            return input;
		}

		private static void msg(string text)
		{
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.WriteLine(text);
            Console.ForegroundColor = ConsoleColor.Gray;
		}

		private static void err(string text)
		{
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine(text);
			Console.ForegroundColor = ConsoleColor.Gray;
		}
	}
}
