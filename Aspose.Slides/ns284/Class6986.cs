using System;
using ns305;

namespace ns284;

internal sealed class Class6986 : Class6983, Interface323
{
	private const string string_2 = "http://www.w3.org/2000/svg";

	public string Height => method_20("height");

	public string Width => method_20("width");

	protected internal Class6986(Class7096 name, Class7046 doc)
		: base(name, doc)
	{
		if (!method_34("xmlns"))
		{
			method_21("xmlns", "http://www.w3.org/2000/svg");
		}
	}

	public override void vmethod_5(Interface325 visitor)
	{
		int num = Attributes.Length;
		for (int i = 0; i < num; i++)
		{
			Class7045 @class = Attributes[i];
			string localName = @class.LocalName;
			if (!char.IsLetter(localName[0]))
			{
				Attributes.method_14(@class);
				i--;
				num--;
			}
		}
		Class7045 class2 = Attributes.method_11("xmlns");
		if (string.IsNullOrEmpty(class2.Value) || !"http://www.w3.org/2000/svg".Equals(class2.Value, StringComparison.OrdinalIgnoreCase))
		{
			class2.Value = "http://www.w3.org/2000/svg";
		}
		visitor.imethod_49(this);
	}
}
