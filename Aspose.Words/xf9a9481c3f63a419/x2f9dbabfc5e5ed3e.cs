using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using Aspose;
using x5794c252ba25e723;
using x6c95d9cf46ff5f25;

namespace xf9a9481c3f63a419;

[JavaManual("Manual porting by design.")]
internal class x2f9dbabfc5e5ed3e
{
	private x2f9dbabfc5e5ed3e()
	{
	}

	public static Matrix xc675a307f114fa9b(x54366fa5f75a02f7 xb38c108353fa4c7d)
	{
		return new Matrix(xb38c108353fa4c7d.xb4f54e8f080ddae5, xb38c108353fa4c7d.xdde8182ef4f9942b, xb38c108353fa4c7d.xa71255917a9143ca, xb38c108353fa4c7d.xcd7062a84a8f3162, xb38c108353fa4c7d.x35fa2f38e277fdee, xb38c108353fa4c7d.x93f6f49bd53e2628);
	}

	public static x54366fa5f75a02f7 xab63241bfc57f0e2(Matrix xa801ccff44b0c7eb)
	{
		float[] elements = xa801ccff44b0c7eb.Elements;
		return new x54366fa5f75a02f7(elements[0], elements[1], elements[2], elements[3], elements[4], elements[5]);
	}

	public static string x2db14af6af01f00b(x54366fa5f75a02f7 xb38c108353fa4c7d)
	{
		return $"{x0d299f323d241756.x482624a13e9e9d98(BitConverter.GetBytes(xb38c108353fa4c7d.xb4f54e8f080ddae5), 0, 4, x2e6b322d68dfff21: true)}, {x0d299f323d241756.x482624a13e9e9d98(BitConverter.GetBytes(xb38c108353fa4c7d.xdde8182ef4f9942b), 0, 4, x2e6b322d68dfff21: true)}, {x0d299f323d241756.x482624a13e9e9d98(BitConverter.GetBytes(xb38c108353fa4c7d.xa71255917a9143ca), 0, 4, x2e6b322d68dfff21: true)}, {x0d299f323d241756.x482624a13e9e9d98(BitConverter.GetBytes(xb38c108353fa4c7d.xcd7062a84a8f3162), 0, 4, x2e6b322d68dfff21: true)}, {x0d299f323d241756.x482624a13e9e9d98(BitConverter.GetBytes(xb38c108353fa4c7d.x35fa2f38e277fdee), 0, 4, x2e6b322d68dfff21: true)}, {x0d299f323d241756.x482624a13e9e9d98(BitConverter.GetBytes(xb38c108353fa4c7d.x93f6f49bd53e2628), 0, 4, x2e6b322d68dfff21: true)}";
	}

	public static string x2db14af6af01f00b(PointF x2f7096dac971d6ec)
	{
		return $"{x0d299f323d241756.x482624a13e9e9d98(BitConverter.GetBytes(x2f7096dac971d6ec.X), 0, 4, x2e6b322d68dfff21: true)}, {x0d299f323d241756.x482624a13e9e9d98(BitConverter.GetBytes(x2f7096dac971d6ec.Y), 0, 4, x2e6b322d68dfff21: true)}";
	}

	public static string x2db14af6af01f00b(float xbcea506a33cf9111)
	{
		return x0d299f323d241756.x482624a13e9e9d98(BitConverter.GetBytes(xbcea506a33cf9111), 0, 4, x2e6b322d68dfff21: true);
	}

	public static string x2db14af6af01f00b(double xbcea506a33cf9111)
	{
		return x0d299f323d241756.x482624a13e9e9d98(BitConverter.GetBytes(xbcea506a33cf9111), 0, 8, x2e6b322d68dfff21: true);
	}
}
