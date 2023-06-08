using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using Aspose;
using x1c8faa688b1f0b0c;

namespace xf9a9481c3f63a419;

[JavaManual("Manual porting by design.")]
internal class x8ebf543aaab29d16
{
	private static readonly Matrix xa67451daaf1f3933 = new Matrix();

	private x8ebf543aaab29d16()
	{
	}

	public static Region x33de56df0a95ed83(BinaryReader xe134235b3526fa75)
	{
		xe134235b3526fa75.ReadUInt32();
		xe134235b3526fa75.ReadUInt32();
		uint num = xe134235b3526fa75.ReadUInt32();
		xe134235b3526fa75.ReadUInt32();
		x70a5bafbe8fbfeb2(xe134235b3526fa75);
		GraphicsPath graphicsPath = new GraphicsPath();
		for (int i = 0; i < num; i++)
		{
			graphicsPath.AddRectangle(x70a5bafbe8fbfeb2(xe134235b3526fa75));
		}
		return new Region(graphicsPath);
	}

	private static RectangleF x70a5bafbe8fbfeb2(BinaryReader xe134235b3526fa75)
	{
		return RectangleF.FromLTRB(xe134235b3526fa75.ReadInt32(), xe134235b3526fa75.ReadInt32(), xe134235b3526fa75.ReadInt32(), xe134235b3526fa75.ReadInt32());
	}

	public static xab391c46ff9a0a38 x2ffd000f9d74db27(Region xa4d52e34b62b5495)
	{
		xab391c46ff9a0a38 xab391c46ff9a0a = new xab391c46ff9a0a38();
		RectangleF[] regionScans = xa4d52e34b62b5495.GetRegionScans(xa67451daaf1f3933);
		RectangleF[] array = regionScans;
		foreach (RectangleF x26545669838eb36e in array)
		{
			xab391c46ff9a0a.xd6b6ed77479ef68c(x1cab6af0a41b70e2.x7c89cd07f845b8e1(x26545669838eb36e));
		}
		return xab391c46ff9a0a;
	}
}
