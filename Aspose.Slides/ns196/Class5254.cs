using System.Text;

namespace ns196;

internal class Class5254
{
	private Interface173 interface173_0;

	private int int_0 = -1;

	public Class5254(Interface173 lm)
	{
		interface173_0 = lm;
	}

	public Class5254(Interface173 lm, int index)
		: this(lm)
	{
		method_3(index);
	}

	public Interface173 method_0()
	{
		return interface173_0;
	}

	public Interface173 method_1(int depth)
	{
		return method_2(depth)?.method_0();
	}

	public virtual Class5254 vmethod_0()
	{
		return null;
	}

	public Class5254 method_2(int depth)
	{
		Class5254 @class = this;
		int num = 0;
		while (num < depth && @class != null)
		{
			num++;
			@class = @class.vmethod_0();
		}
		return @class;
	}

	public virtual bool vmethod_1()
	{
		return false;
	}

	public void method_3(int value)
	{
		int_0 = value;
	}

	public int method_4()
	{
		return int_0;
	}

	protected string method_5()
	{
		if (method_0() != null)
		{
			string text = method_0().ToString();
			int num = text.LastIndexOf('.');
			if (num >= 0 && text.IndexOf('@') > 0)
			{
				return text.Substring(num + 1);
			}
			return text;
		}
		return "null";
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Position:").Append(method_4()).Append("(");
		stringBuilder.Append(method_5());
		stringBuilder.Append(")");
		return stringBuilder.ToString();
	}
}
