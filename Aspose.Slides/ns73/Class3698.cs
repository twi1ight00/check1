namespace ns73;

internal class Class3698
{
	private const string string_0 = "decimal";

	private string string_1;

	private string string_2;

	private string string_3;

	public string Identifier => string_1;

	public string ListStyle => string_2;

	public string Separator => string_3;

	internal Class3698(string identifier, string listStyle, string separator)
	{
		string_1 = identifier;
		string_2 = listStyle ?? "decimal";
		string_3 = separator;
	}
}
