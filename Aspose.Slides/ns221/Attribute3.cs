using System;

namespace ns221;

[AttributeUsage(AttributeTargets.All, AllowMultiple = false, Inherited = true)]
[Attribute2("Autoporter attribute - not needed in java.")]
internal class Attribute3 : Attribute
{
	private string[] string_0;

	public string[] TypeArguments
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

	public Attribute3(string typeArgument1)
	{
		TypeArguments = new string[1] { typeArgument1 };
	}

	public Attribute3(string typeArgument1, string typeArgument2)
	{
		TypeArguments = new string[2] { typeArgument1, typeArgument2 };
	}

	public Attribute3(string typeArgument1, string typeArgument2, string typeArgument3)
	{
		TypeArguments = new string[3] { typeArgument1, typeArgument2, typeArgument3 };
	}
}
