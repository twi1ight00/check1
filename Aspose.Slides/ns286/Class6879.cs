namespace ns286;

internal class Class6879
{
	private string string_0;

	private string string_1;

	public string Code => string_0;

	public string Entity => string_1;

	public Class6879(string entity, string code)
	{
		string_0 = code;
		string_1 = entity.ToLowerInvariant();
	}

	internal string method_0()
	{
		return $"<!ENTITY {string_1} \"{string_0}\">";
	}
}
