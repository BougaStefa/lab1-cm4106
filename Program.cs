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
		MyOutputReader reader = new MyOutputReader();
		reader.ReadFile(args[0]);
	}
}
