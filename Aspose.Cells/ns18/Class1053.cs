using System.Runtime.CompilerServices;

namespace ns18;

internal class Class1053
{
	private readonly string string_0;

	private readonly string string_1;

	private readonly string string_2;

	private readonly bool bool_0;

	public string Type => string_1;

	public Class1053(string string_3, string string_4, string string_5, bool bool_1)
	{
		Class1015.smethod_12(string_3, "id");
		Class1015.smethod_12(string_4, "type");
		Class1015.smethod_12(string_5, "target");
		string_0 = string_3;
		string_2 = string_5;
		string_1 = string_4;
		bool_0 = bool_1;
	}

	[SpecialName]
	public string method_0()
	{
		return string_0;
	}

	[SpecialName]
	public string method_1()
	{
		return string_2;
	}

	[SpecialName]
	public bool method_2()
	{
		return bool_0;
	}
}
