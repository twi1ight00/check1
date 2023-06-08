using System.Runtime.CompilerServices;
using ns48;

namespace ns26;

internal class Class1096
{
	private string string_0;

	private string string_1;

	private string string_2;

	private Enum172 enum172_0;

	private Enum171 enum171_0;

	internal string Name
	{
		get
		{
			return string_0;
		}
		set
		{
			string_0 = value;
		}
	}

	internal Enum172 ShowType
	{
		set
		{
			enum172_0 = value;
		}
	}

	[SpecialName]
	internal string method_0()
	{
		return string_1;
	}

	[SpecialName]
	internal void method_1(string string_3)
	{
		string_1 = string_3;
	}

	[SpecialName]
	internal string method_2()
	{
		return string_2;
	}

	[SpecialName]
	internal void method_3(string string_3)
	{
		string_2 = string_3;
	}

	[SpecialName]
	internal void method_4(Enum171 enum171_1)
	{
		enum171_0 = enum171_1;
	}
}
