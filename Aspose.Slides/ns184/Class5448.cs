using System;

namespace ns184;

internal class Class5448
{
	public const string string_0 = "auto";

	public const string string_1 = "single-byte";

	public const string string_2 = "cid";

	private string string_3;

	private Class5448(string name)
	{
		string_3 = name;
	}

	public string method_0()
	{
		return string_3;
	}

	public static Class5448 smethod_0(string name)
	{
		return name.ToLower() switch
		{
			"auto" => new Class5448("auto"), 
			"single-byte" => new Class5448("single-byte"), 
			"cid" => new Class5448("cid"), 
			_ => throw new ArgumentException("Invalid encoding mode: " + name), 
		};
	}

	public override string ToString()
	{
		return "EncodingMode: " + method_0();
	}
}
