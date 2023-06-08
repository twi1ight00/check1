using System.Text;
using ns192;

namespace ns197;

internal class Class5649
{
	internal Class5631 class5631_0;

	internal int int_0;

	internal int int_1;

	private int int_2;

	private int int_3;

	private int int_4;

	private int int_5;

	private int int_6;

	private int int_7;

	private int int_8;

	private bool bool_0;

	internal Class5649(Class5631 pgu, int start, int end, bool last, int condBeforeContentLength, int length, int condAfterContentLength, int bpBeforeNormal, int bpBeforeFirst, int bpAfterNormal, int bpAfterLast)
	{
		class5631_0 = pgu;
		int_0 = start;
		int_1 = end;
		bool_0 = last;
		int_2 = condBeforeContentLength;
		int_3 = length;
		int_4 = condAfterContentLength;
		int_5 = bpBeforeNormal;
		int_6 = bpBeforeFirst;
		int_7 = bpAfterNormal;
		int_8 = bpAfterLast;
	}

	public bool method_0()
	{
		return int_0 == 0;
	}

	internal bool method_1()
	{
		return bool_0;
	}

	internal int method_2(bool firstOnPage)
	{
		if (firstOnPage)
		{
			return int_6;
		}
		return int_5;
	}

	internal int method_3(bool lastOnPage)
	{
		if (lastOnPage)
		{
			return int_8;
		}
		return int_7;
	}

	internal int method_4()
	{
		return int_2;
	}

	internal int method_5()
	{
		return int_3;
	}

	internal int method_6()
	{
		return int_4;
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder("IPart: ");
		stringBuilder.Append(int_0).Append("-").Append(int_1);
		stringBuilder.Append(" [").Append(method_0() ? "F" : "-").Append(method_1() ? "L" : "-");
		stringBuilder.Append("] ").Append(class5631_0);
		return stringBuilder.ToString();
	}
}
