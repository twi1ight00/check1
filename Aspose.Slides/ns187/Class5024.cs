using System.Collections;
using System.Drawing;
using ns175;
using ns176;

namespace ns187;

internal abstract class Class5024
{
	private string string_0;

	public void method_0(string value)
	{
		string_0 = value;
	}

	public string method_1()
	{
		return string_0;
	}

	public virtual Interface182 vmethod_0()
	{
		return null;
	}

	public virtual Color vmethod_1(Class5738 foUserAgent)
	{
		return Color.Empty;
	}

	public virtual Class5032 vmethod_2()
	{
		return null;
	}

	public virtual Class5045 vmethod_3()
	{
		return null;
	}

	public virtual Class5044 vmethod_4()
	{
		return null;
	}

	public virtual Class5046 vmethod_5()
	{
		return null;
	}

	public virtual Class5043 vmethod_6()
	{
		return null;
	}

	public virtual int imethod_0()
	{
		return 0;
	}

	public bool method_2()
	{
		return imethod_0() == 9;
	}

	public virtual char vmethod_7()
	{
		return '\0';
	}

	public virtual ArrayList vmethod_8()
	{
		return null;
	}

	public virtual object vmethod_9()
	{
		return null;
	}

	public virtual Interface181 vmethod_10()
	{
		return null;
	}

	public virtual string vmethod_11()
	{
		return null;
	}

	public virtual object vmethod_12()
	{
		return null;
	}

	public virtual string vmethod_13()
	{
		return null;
	}

	public override string ToString()
	{
		object obj = vmethod_12();
		if (obj != this)
		{
			return obj.ToString();
		}
		return string.Empty;
	}
}
