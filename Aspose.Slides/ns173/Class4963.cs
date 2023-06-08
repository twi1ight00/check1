using System.Drawing;

namespace ns173;

internal class Class4963 : Class4962, Interface192
{
	private bool bool_6;

	private Class5492 class5492_0;

	private RectangleF rectangleF_0;

	private int int_27;

	internal int EndIndent
	{
		get
		{
			return int_27;
		}
		set
		{
			int_27 = value;
		}
	}

	public Class4963()
		: this(allowBPDUpdate: false)
	{
	}

	public Class4963(bool allowBPDUpdate)
	{
		bool_4 = allowBPDUpdate;
	}

	public void method_49(Class5492 ctm)
	{
		class5492_0 = ctm;
	}

	public Class5492 method_50()
	{
		return class5492_0;
	}

	public void method_51(bool cl)
	{
		bool_6 = cl;
		if (cl)
		{
			if (rectangleF_0 == RectangleF.Empty)
			{
				rectangleF_0 = new RectangleF(0f, 0f, method_12(), vmethod_1());
			}
		}
		else
		{
			rectangleF_0 = RectangleF.Empty;
		}
	}

	public bool imethod_0()
	{
		return bool_6;
	}

	public void method_52(RectangleF rectangle)
	{
		rectangleF_0 = rectangle;
	}

	public RectangleF imethod_1()
	{
		if (bool_6 && ((rectangleF_0.Width == 0f && method_12() != 0) || (rectangleF_0.Height == 0f && vmethod_1() != 0)))
		{
			rectangleF_0 = new RectangleF(0f, 0f, method_12(), vmethod_1());
		}
		return rectangleF_0;
	}
}
