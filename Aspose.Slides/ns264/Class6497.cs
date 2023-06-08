using System;
using System.Drawing;
using System.IO;

namespace ns264;

internal class Class6497
{
	private Rectangle rectangle_0 = Rectangle.Empty;

	private Rectangle rectangle_1 = Rectangle.Empty;

	private int int_0;

	private int int_1;

	private int int_2;

	private int int_3;

	internal Rectangle BoundsPixels => rectangle_0;

	internal Rectangle FrameHundredsMm => rectangle_1;

	internal RectangleF FramePixels => new RectangleF(method_0(rectangle_1.X), method_0(rectangle_1.Y), method_0(rectangle_1.Width), method_0(rectangle_1.Height));

	internal float HorizontalResolution => (float)((double)int_0 / ((double)int_2 / 25.4));

	internal float VerticalResolution => (float)((double)int_1 / ((double)int_3 / 25.4));

	internal Class6497()
	{
	}

	internal void Read(BinaryReader reader)
	{
		reader.ReadUInt32();
		uint num = reader.ReadUInt32();
		int left = reader.ReadInt32();
		int top = reader.ReadInt32();
		int right = reader.ReadInt32();
		int bottom = reader.ReadInt32();
		rectangle_0 = Rectangle.FromLTRB(left, top, right, bottom);
		left = reader.ReadInt32();
		top = reader.ReadInt32();
		right = reader.ReadInt32();
		bottom = reader.ReadInt32();
		rectangle_1 = Rectangle.FromLTRB(left, top, right, bottom);
		reader.ReadUInt32();
		reader.ReadUInt32();
		reader.ReadUInt32();
		reader.ReadUInt32();
		reader.ReadUInt16();
		reader.ReadUInt16();
		reader.ReadUInt32();
		reader.ReadUInt32();
		reader.ReadUInt32();
		int_0 = reader.ReadInt32();
		int_1 = reader.ReadInt32();
		int_2 = reader.ReadInt32();
		int_3 = reader.ReadInt32();
		reader.BaseStream.Position = num;
	}

	private int method_0(float hundredsMm)
	{
		return (int)Math.Round(hundredsMm * (float)int_0 / ((float)int_2 * 100f));
	}
}
