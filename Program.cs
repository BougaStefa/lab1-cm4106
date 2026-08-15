namespace lab1_cm4106;

public class Program
{
	public static void Main(string[] args)
	{
		if (args.Length < 1)
		{
			Console.WriteLine("Usage: MyReader <filename>.");
			return;
		}
		MyReader reader = new MyReader();
		reader.ReadFile(args[0]);
	}
}
