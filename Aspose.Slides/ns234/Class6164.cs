using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using ns235;

namespace ns234;

internal static class Class6164
{
	private static readonly Matrix matrix_0 = new Matrix();

	public static Region smethod_0(BinaryReader reader)
	{
		reader.ReadUInt32();
		reader.ReadUInt32();
		uint num = reader.ReadUInt32();
		reader.ReadUInt32();
		smethod_1(reader);
		GraphicsPath graphicsPath = new GraphicsPath();
		for (int i = 0; i < num; i++)
		{
			graphicsPath.AddRectangle(smethod_1(reader));
		}
		return new Region(graphicsPath);
	}

	private static RectangleF smethod_1(BinaryReader reader)
	{
		return RectangleF.FromLTRB(reader.ReadInt32(), reader.ReadInt32(), reader.ReadInt32(), reader.ReadInt32());
	}

	public static Class6217 smethod_2(Region region)
	{
		Class6217 @class = new Class6217();
		RectangleF[] regionScans = region.GetRegionScans(matrix_0);
		RectangleF[] array = regionScans;
		foreach (RectangleF rect in array)
		{
			@class.Add(Class6218.smethod_2(rect));
		}
		return @class;
	}
}
