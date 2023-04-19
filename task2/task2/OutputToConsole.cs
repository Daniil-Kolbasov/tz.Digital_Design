namespace task2
{
	internal class OutputToConsole
	{
		public static void Output()
		{
			ISavingFormats savingFormats = new(new EncounteredWords());
			string readFrom = "sampleQuotes.txt";
			string writeTo = "result.txt";

			Console.WriteLine("Do you want to install files for reading and writing?");
			Console.WriteLine("(Yes/No):");

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
				savingFormats.SimpleText(readFrom, writeTo);
				Console.WriteLine("Сompleted successfully");
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}
	}
}
