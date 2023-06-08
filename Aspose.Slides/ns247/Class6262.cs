using ns218;

namespace ns247;

internal class Class6262
{
	private readonly string string_0;

	private readonly string string_1;

	private readonly string string_2;

	private readonly bool bool_0;

	public string Id => string_0;

	public string Type => string_1;

	public string Target => string_2;

	public bool IsExternal => bool_0;

	public Class6262(string id, string type, string target, bool isExternal)
	{
		Class5964.smethod_24(id, "id");
		Class5964.smethod_24(type, "type");
		Class5964.smethod_24(target, "target");
		string_0 = id;
		string_2 = target;
		string_1 = type;
		bool_0 = isExternal;
	}
}
