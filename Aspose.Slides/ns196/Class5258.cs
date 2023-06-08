using System.Text;

namespace ns196;

internal class Class5258 : Class5254
{
	private int int_1;

	public Class5258(Interface173 layoutManager, int pos)
		: base(layoutManager)
	{
		int_1 = pos;
	}

	public Class5258(Interface173 layoutManager, int pos, int index)
		: base(layoutManager, index)
	{
		int_1 = pos;
	}

	public int method_6()
	{
		return int_1;
	}

	public override bool vmethod_1()
	{
		return method_0() != null;
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("LeafPos:").Append(method_4()).Append("(");
		stringBuilder.Append("pos=").Append(method_6());
		stringBuilder.Append(", lm=").Append(method_5()).Append(")");
		return stringBuilder.ToString();
	}
}
