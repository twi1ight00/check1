using System.Text;
using ns171;
using ns189;

namespace ns182;

internal class Class5756
{
	private Class5088 class5088_0;

	private int int_0;

	private int int_1;

	private int int_2;

	private int int_3;

	internal Class5756(Class5088 fn, int start, int end)
		: this(fn, start, start, end, -1)
	{
	}

	internal Class5756(Class5088 fn, int textStart, int start, int end, int level)
	{
		class5088_0 = fn;
		int_0 = textStart;
		int_1 = start;
		int_2 = end;
		int_3 = level;
	}

	internal Class5088 method_0()
	{
		return class5088_0;
	}

	private int method_1()
	{
		return int_0;
	}

	internal int method_2()
	{
		return int_1;
	}

	internal int method_3()
	{
		return int_2;
	}

	private int method_4()
	{
		return int_3;
	}

	internal void method_5(int leveL)
	{
		int_3 = leveL;
	}

	public int method_6()
	{
		return int_2 - int_1;
	}

	public string method_7()
	{
		if (class5088_0 is Class5172)
		{
			return ((Class5172)class5088_0).method_25().ToString();
		}
		if (class5088_0 is Class5165)
		{
			return new string(new char[1] { ((Class5165)class5088_0).method_51() });
		}
		return null;
	}

	public void method_8()
	{
		if (class5088_0 is Class5172)
		{
			((Class5172)class5088_0).method_47(int_3, int_1 - int_0, int_2 - int_0);
		}
		else if (class5088_0 is Class5165)
		{
			((Class5165)class5088_0).method_40(int_3);
		}
		else if (class5088_0 is Class5120)
		{
			((Class5120)class5088_0).method_40(int_3);
		}
		else if (class5088_0 is Class5109)
		{
			((Class5109)class5088_0).method_40(int_3);
		}
		else if (class5088_0 is Class5102)
		{
			((Class5102)class5088_0).method_40(int_3);
		}
	}

	public override bool Equals(object o)
	{
		if (o is Class5756)
		{
			Class5756 @class = (Class5756)o;
			if (@class.method_0() != class5088_0)
			{
				return false;
			}
			if (@class.method_2() != int_1)
			{
				return false;
			}
			if (@class.method_3() != int_2)
			{
				return false;
			}
			return true;
		}
		return false;
	}

	public override int GetHashCode()
	{
		int num = ((class5088_0 != null) ? class5088_0.GetHashCode() : 0);
		num = (num ^ int_1) + (num << 19);
		return (num ^ int_2) + (num << 11);
	}

	public string method_9()
	{
		StringBuilder stringBuilder = new StringBuilder();
		char value = ((class5088_0 is Class5172) ? 'T' : ((class5088_0 is Class5165) ? 'C' : ((class5088_0 is Class5101) ? 'B' : ((class5088_0 is Class5120) ? '#' : ((class5088_0 is Class5109) ? 'G' : ((!(class5088_0 is Class5102)) ? '?' : 'L'))))));
		stringBuilder.Append(value);
		stringBuilder.Append("[" + int_1 + "," + int_2 + "][" + int_0 + "](" + int_3 + ")");
		return stringBuilder.ToString();
	}
}
