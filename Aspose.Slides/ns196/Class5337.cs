using System;

namespace ns196;

internal abstract class Class5337 : Class5328
{
	public static int int_0 = 1000;

	private int int_1;

	private bool bool_0;

	protected Class5337(int width, Class5254 pos, bool auxiliary)
		: base(pos)
	{
		int_1 = width;
		bool_0 = auxiliary;
	}

	public bool method_3()
	{
		return bool_0;
	}

	public int method_4()
	{
		return int_1;
	}

	public void method_5(int value)
	{
		int_1 = value;
	}

	public virtual int vmethod_5()
	{
		throw new Exception("Element is not a penalty");
	}

	public virtual int vmethod_6()
	{
		throw new Exception("Element is not a glue");
	}

	public virtual int vmethod_7()
	{
		throw new Exception("Element is not a glue");
	}

	public override bool vmethod_4()
	{
		return false;
	}
}
