using System;

namespace ns221;

[Attribute2("Autoporter functionality. Not needed in java.")]
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum | AttributeTargets.Interface, AllowMultiple = false, Inherited = false)]
internal class Attribute6 : Attribute
{
	private string string_0;

	public string Comment
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

	public Attribute6()
	{
	}

	public Attribute6(string comment)
	{
		string_0 = comment;
	}
}
