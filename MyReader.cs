namespace lab1_cm4106;

public class MyReader
{
	public virtual void ReadFile(string filename)
	{
		if (string.IsNullOrWhiteSpace(filename))
		{
			throw new ArgumentException("File name must not be null or empty.", nameof(filename));
		}

		if (!File.Exists(filename))
		{
			throw new FileNotFoundException("Could not find file.", filename);
		}

		try
		{
			int lineNum = 1;
			using StreamReader sr = new StreamReader(filename);
			string? line;
			while ((line = sr.ReadLine()) != null)
			{
				ProcessLine(line, lineNum);
				lineNum++;
			}
		}
		catch (IOException ex)
		{
			Console.WriteLine($"Error reading file '{filename}': {ex.Message}");
		}
	}


	public virtual void ProcessLine(string line, int lineNum)
	{
		Console.WriteLine($"{lineNum} {line}");
	}

}
