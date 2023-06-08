using System.Collections;
using System.Text;
using ns196;

namespace ns197;

internal class Class5267 : Class5254
{
	internal ArrayList arrayList_0;

	internal ArrayList arrayList_1;

	internal Class5267(Interface173 lm)
		: base(lm)
	{
	}

	public override bool vmethod_1()
	{
		return true;
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder("TableHFPenaltyPosition:");
		stringBuilder.Append(method_4()).Append("(");
		stringBuilder.Append("header:");
		stringBuilder.Append(arrayList_0);
		stringBuilder.Append(", footer:");
		stringBuilder.Append(arrayList_1);
		stringBuilder.Append(")");
		return stringBuilder.ToString();
	}
}
