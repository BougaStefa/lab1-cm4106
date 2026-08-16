namespace lab1_cm4106;

public class MyOutputReader : MyReader, IStatsGenerator
{
	private List<string> lines = new();
	private const string output = "output.txt";
	private const string stats = "stats.txt";
	private bool isValid = true;
	private int errorLine = -1;

	public int GetLineCount()
	{
		return lines.Count;
	}

	public int GetCharacterCount()
	{
		return lines.Sum(l => l.Length);
	}

	public int GetWordCount()
	{
		return lines.SelectMany(l => l.Split(' ', StringSplitOptions.RemoveEmptyEntries)).Count();
	}

	public List<string> GetFirstWord()
	{
		return lines.Select(l => l.Split(' ', StringSplitOptions.RemoveEmptyEntries))
				.Where(words => words.Length > 0)
				.Select(words => words[0]).ToList();
	}

	public List<char> GetEndLine()
	{
		return lines.Where(l => l.Length > 0)
			.Select(l => l[^1])
			.ToList();
	}

	public List<char> GetFirstLetter()
	{
		return lines
				.SelectMany(l => l.Split(' ', StringSplitOptions.RemoveEmptyEntries))
				.Where(w => w.Length > 0)
				.Select(w => w[0])
				.ToList();
	}

	public override void ReadFile(string filename)
	{
		File.Delete(output); // Clear files before next run
		File.Delete(stats);
		base.ReadFile(filename);
		if (!isValid){
			Console.WriteLine($"Error on line {errorLine}");
			return;
		}
		File.WriteAllLines(output,lines.Select((l,i)=> $"{i+1} {l}"));
		GenerateStatsFile();
	}

	public override void ProcessLine(string line, int lineNum)
	{
		if (line.TrimStart().StartsWith('#'))
		{
			return;
		}

		string trimmedEnd = line.TrimEnd();
		if (trimmedEnd.Length == 0)
		{
			return;
		}
		if (trimmedEnd[^1] != '+' && trimmedEnd[^1]!=';'){
			isValid = false;
			if (errorLine == -1) errorLine = lineNum;
			return;
		}
		lines.Add(line);
	}
	public void GenerateStatsFile()
	{
		List<string> statsLines = new List<string>
		{
			$"Line Count: {GetLineCount()}",
			$"Character Count: {GetCharacterCount()}",
			$"Word Count: {GetWordCount()}",
			$"First Words: {string.Join(", ", GetFirstWord())}",
			$"First Letters: {string.Join(", ", GetFirstLetter())}",
			$"End Characters: {string.Join(", ", GetEndLine())}",
		};
		File.AppendAllLines(stats, statsLines);
	}
}
