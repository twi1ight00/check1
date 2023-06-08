using System;

namespace ns221;

[Attribute2("Autoporter attribute - not needed in java.")]
[AttributeUsage(AttributeTargets.All, AllowMultiple = false, Inherited = true)]
internal class Attribute4 : Attribute
{
	private string string_0;

	public string TypeParameter
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

	public Attribute4(string typeParameter)
	{
		TypeParameter = typeParameter;
	}
}
