using System;

namespace ns221;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum | AttributeTargets.Constructor | AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Event | AttributeTargets.Interface | AttributeTargets.Delegate, AllowMultiple = false, Inherited = false)]
[Attribute2("Autoporter functionality. Not needed in java.")]
internal class Attribute2 : Attribute
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

	public Attribute2()
	{
	}

	public Attribute2(string comment)
	{
		string_0 = comment;
	}
}
