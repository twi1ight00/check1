using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using ns19;
using ns33;

namespace ns34;

internal class Class855 : IDisposable
{
	private GraphicsPath graphicsPath_0 = new GraphicsPath();

	private bool bool_0;

	private static byte[] byte_0 = new byte[4] { 0, 1, 1, 129 };

	public static readonly Class855 class855_0 = new Class855();

	protected Class855()
	{
	}

	public Class855(PointF pointF_0, PointF pointF_1, PointF pointF_2, PointF pointF_3, bool bool_1)
	{
		byte[] array = (byte[])byte_0.Clone();
		if (bool_1)
		{
			array[3] |= 128;
		}
		graphicsPath_0 = new GraphicsPath(new PointF[4] { pointF_0, pointF_1, pointF_2, pointF_3 }, array);
	}

	~Class855()
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

	public void Draw(Interface42 interface42_0, Pen pen_0, Brush brush_0, Class831 class831_0)
	{
		if (class831_0 != null && graphicsPath_0.PointCount > 0)
		{
			class831_0.method_3().method_10(graphicsPath_0, 0.5f);
		}
		if (class831_0 != null && graphicsPath_0.PointCount > 0)
		{
			class831_0.method_4().method_11(graphicsPath_0);
		}
	}
}
