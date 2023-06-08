using System;

namespace ns221;

[Attribute2("Autoporter attribute - not needed in java.")]
[AttributeUsage(AttributeTargets.All, AllowMultiple = false, Inherited = true)]
internal class Attribute5 : Attribute
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

	public Attribute5()
	{
	}

	public Attribute5(string comment)
	{
		string_0 = comment;
	}
}
