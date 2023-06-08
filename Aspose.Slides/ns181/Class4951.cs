using System;
using System.Drawing;
using System.IO;
using ns173;

namespace ns181;

internal class Class4951 : Class4943, Interface192
{
	private Class4942 class4942_1;

	private bool bool_0;

	private RectangleF rectangleF_0;

	public Class4951(Class4942 child)
		: this(child, -1)
	{
	}

	public Class4951(Class4942 child, int bidiLevel)
		: base(0, bidiLevel)
	{
		class4942_1 = child;
	}

	public void method_51(bool c)
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

	public void method_52(RectangleF cp)
	{
		rectangleF_0 = cp;
	}

	public RectangleF method_53()
	{
		return rectangleF_0;
	}

	public void method_54(Class4942 contenT)
	{
		class4942_1 = contenT;
	}

	public Class4942 method_55()
	{
		return class4942_1;
	}

	private void method_56(Stream @out)
	{
		throw new NotImplementedException();
	}

	private void method_57(Stream @in)
	{
		throw new NotImplementedException();
	}
}
