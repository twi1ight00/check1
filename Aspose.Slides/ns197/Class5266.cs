using System.Collections;
using System.Text;
using ns196;

namespace ns197;

internal class Class5266 : Class5254
{
	internal bool bool_0;

	internal ArrayList arrayList_0;

	internal Class5266(Interface173 lm, bool header, ArrayList nestedElements)
		: base(lm)
	{
		bool_0 = header;
		arrayList_0 = nestedElements;
	}

	public override bool vmethod_1()
	{
		return true;
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder("Table");
		stringBuilder.Append(bool_0 ? "Header" : "Footer");
		stringBuilder.Append("Position:");
		stringBuilder.Append(method_4()).Append("(");
		stringBuilder.Append(arrayList_0);
		stringBuilder.Append(")");
		return stringBuilder.ToString();
	}
}
