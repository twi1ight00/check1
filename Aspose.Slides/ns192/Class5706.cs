using ns171;
using ns187;

namespace ns192;

internal class Class5706
{
	private static Class5706 class5706_0;

	private Class5703.Class5704 class5704_0;

	private int int_0;

	public Class5706(Class5703.Class5704 borderInfo, int holder)
	{
		class5704_0 = borderInfo;
		int_0 = holder;
	}

	internal static Class5706 smethod_0()
	{
		if (class5706_0 == null)
		{
			class5706_0 = new Class5706(Class5703.smethod_0(), 75);
		}
		return class5706_0;
	}

	public Class5703.Class5704 method_0()
	{
		return class5704_0;
	}

	public int method_1()
	{
		return int_0;
	}

	public override string ToString()
	{
		string text = string.Empty;
		switch ((Enum679)int_0)
		{
		case Enum679.const_72:
			text = "table";
			break;
		case Enum679.const_74:
			text = "table-body";
			break;
		case Enum679.const_76:
			text = "table-cell";
			break;
		case Enum679.const_77:
			text = "table-column";
			break;
		case Enum679.const_78:
			text = "table-footer";
			break;
		case Enum679.const_79:
			text = "table-header";
			break;
		case Enum679.const_80:
			text = "table-row";
			break;
		}
		return string.Concat("{", class5704_0, ", ", text, "}");
	}
}
