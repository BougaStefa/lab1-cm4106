namespace lab1_cm4106;

interface IStatsGenerator{
	int GetLineCount();
	int GetCharacterCount();
	List<char> GetEndLine();
	List<string> GetFirstWord();
	int GetWordCount();
	List<char> GetFirstLetter();
}
