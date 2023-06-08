namespace ns302;

internal class Class6904
{
	private Enum941 enum941_0;

	private int int_0;

	private int int_1;

	private int int_2;

	private string string_0;

	private string string_1;

	public Enum941 Code => enum941_0;

	public int Line => int_0;

	public int LinePosition => int_1;

	public int StreamPosition => int_2;

	public string SourceText => string_0;

	public string Reason => string_1;

	internal Class6904(Enum941 code, int line, int linePosition, int streamPosition, string sourceText, string reason)
	{
		enum941_0 = code;
		int_0 = line;
		int_1 = linePosition;
		int_2 = streamPosition;
		string_0 = sourceText;
		string_1 = reason;
	}
}
