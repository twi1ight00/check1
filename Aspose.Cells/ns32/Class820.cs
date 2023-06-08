using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using ns19;
using ns22;
using ns31;

namespace ns32;

internal class Class820 : IDisposable
{
	private GraphicsPath graphicsPath_0 = new GraphicsPath();

	private bool bool_0;

	private static byte[] byte_0 = new byte[4] { 0, 1, 1, 129 };

	public static readonly Class820 class820_0 = new Class820();

	protected Class820()
	{
	}

	public Class820(PointF pointF_0, PointF pointF_1, PointF pointF_2, PointF pointF_3, bool bool_1)
	{
		byte[] array = (byte[])byte_0.Clone();
		if (bool_1)
		{
			array[3] |= 128;
		}
		graphicsPath_0 = new GraphicsPath(new PointF[4] { pointF_0, pointF_1, pointF_2, pointF_3 }, array);
	}

	~Class820()
	{
		Dispose(bool_1: false);
	}

	public void Dispose()
	{
		Dispose(bool_1: true);
		GC.SuppressFinalize(this);
	}

	protected virtual void Dispose(bool bool_1)
	{
		if (!bool_0)
		{
			if (bool_1)
			{
				graphicsPath_0.Dispose();
			}
			bool_0 = true;
		}
	}

	public void Draw(Interface42 interface42_0, Pen pen_0, Brush brush_0, Class796 class796_0)
	{
		if (class796_0 != null && class796_0.method_3().method_2())
		{
			brush_0 = Struct18.smethod_3(class796_0.method_3(), Class1181.smethod_1(graphicsPath_0), 0.5f);
		}
		if (class796_0.method_3().Formatting != 0)
		{
			interface42_0.imethod_33(brush_0, graphicsPath_0);
		}
		if (class796_0.method_4().IsVisible)
		{
			interface42_0.imethod_18(pen_0, graphicsPath_0);
		}
	}
}
