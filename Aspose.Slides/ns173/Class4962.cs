using ns176;

namespace ns173;

internal class Class4962 : Class4957
{
	public const int int_17 = 0;

	public const int int_18 = 1;

	public const int int_19 = 2;

	public const int int_20 = 4;

	public const int int_21 = 5;

	public const int int_22 = 3;

	private int int_23;

	protected bool bool_4 = true;

	private bool bool_5;

	private int int_24;

	private int int_25;

	private Interface182 interface182_0;

	private int int_26;

	internal bool IsFloatSide
	{
		get
		{
			return bool_5;
		}
		set
		{
			bool_5 = value;
		}
	}

	internal int FloatWidth
	{
		get
		{
			return int_24;
		}
		set
		{
			int_24 = value;
		}
	}

	internal int LeftInset
	{
		get
		{
			return int_25;
		}
		set
		{
			int_25 = value;
		}
	}

	internal Interface182 PredefinedWidth
	{
		get
		{
			return interface182_0;
		}
		set
		{
			interface182_0 = value;
		}
	}

	internal int XOffset
	{
		get
		{
			return int_26;
		}
		set
		{
			int_26 = value;
		}
	}

	public override void vmethod_5(Class4962 block)
	{
		method_42(block, autoHeight: true);
	}

	public void method_42(Class4962 block, bool autoHeight)
	{
		if (autoHeight && bool_4 && block.method_46())
		{
			int_13 += block.method_15();
		}
		else if (bool_4 && block.method_45() == 4)
		{
			int_13 += block.method_15();
		}
		vmethod_2(block);
	}

	public void method_43(Class4972 line)
	{
		int_13 += line.method_15();
		vmethod_2(line);
	}

	public void method_44(int pos)
	{
		int_23 = pos;
	}

	public int method_45()
	{
		return int_23;
	}

	public bool method_46()
	{
		if (method_45() != 0)
		{
			return method_45() == 1;
		}
		return true;
	}

	public int method_47()
	{
		object obj = method_33(Class5757.int_20);
		if (obj == null)
		{
			return 0;
		}
		return (int)obj;
	}

	public int method_48()
	{
		object obj = method_33(Class5757.int_21);
		if (obj == null)
		{
			return 0;
		}
		return (int)obj;
	}
}
