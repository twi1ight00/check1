using System;
using System.Drawing;
using System.IO;
using ns205;

namespace ns173;

internal class Class4971 : Class4942, Interface192
{
	private Class4964 class4964_0;

	private RectangleF rectangleF_0;

	private bool bool_0;

	public Class4971(RectangleF viewArea)
	{
		rectangleF_0 = viewArea;
		method_29(Class5757.int_25, true);
	}

	public void method_37(Class4964 reg)
	{
		class4964_0 = reg;
	}

	public Class4964 method_38()
	{
		return class4964_0;
	}

	public void method_39(bool c)
	{
		bool_0 = c;
	}

	public bool imethod_0()
	{
		return bool_0;
	}

	public RectangleF imethod_1()
	{
		if (bool_0)
		{
			return new RectangleF(0f, 0f, method_12(), vmethod_1());
		}
		return RectangleF.Empty;
	}

	public RectangleF method_40()
	{
		return rectangleF_0;
	}

	private static void smethod_0(Stream @out)
	{
		throw new NotSupportedException();
	}

	private void method_41(Stream @in)
	{
		throw new NotSupportedException();
	}

	public object method_42()
	{
		throw new NotSupportedException();
	}

	public override void vmethod_4(Interface231 wmtg)
	{
		if (class4964_0 != null)
		{
			class4964_0.vmethod_4(wmtg);
		}
	}
}
