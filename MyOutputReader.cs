namespace lab1_cm4106;

public class MyOutputReader : MyReader
{
	public override void ReadFile(string filename)
	{
		File.Delete("output.txt"); // Clear file on before next run
		base.ReadFile(filename);
	}

	public override void ProcessLine(string line, int lineNum)
	{
		try
		{
			File.AppendAllText("output.txt", $"{lineNum} {line}\n");
		}
		catch (IOException ex)
		{
			Console.WriteLine($"Error writing to output.txt: {ex.Message}");
		}
	}
}
