using System.Collections;
using ns284;

namespace ns290;

internal class Class6847 : Class6846
{
	private string string_3;

	public string Src => string_3;

	public Class6847(Class6844 parent, string src, Interface329 style)
		: base(parent)
	{
		Style = style;
		string_3 = src;
	}

	public override void vmethod_0(Interface332 visitor, bool boxType, ref Hashtable pageSet)
	{
		visitor.imethod_2(this, boxType, ref pageSet);
	}
}
