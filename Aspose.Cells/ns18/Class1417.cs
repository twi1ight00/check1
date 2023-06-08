using System;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;

namespace ns18;

internal class Class1417
{
	private Rectangle rectangle_0;

	private RectangleF rectangleF_0;

	private int int_0;

	private int int_1;

	private int int_2;

	private int int_3;

	internal float HorizontalResolution => (float)((double)int_0 / ((double)int_2 / 25.4));

	internal float VerticalResolution => (float)((double)int_1 / ((double)int_3 / 25.4));

	internal Class1417()
	{
	}

	internal void Read(BinaryReader binaryReader_0)
	{
		binaryReader_0.ReadUInt32();
		uint num = binaryReader_0.ReadUInt32();
		int left = binaryReader_0.ReadInt32();
		int top = binaryReader_0.ReadInt32();
		int right = binaryReader_0.ReadInt32();
		int bottom = binaryReader_0.ReadInt32();
		rectangle_0 = Rectangle.FromLTRB(left, top, right, bottom);
		left = binaryReader_0.ReadInt32();
		top = binaryReader_0.ReadInt32();
		right = binaryReader_0.ReadInt32();
		bottom = binaryReader_0.ReadInt32();
		rectangleF_0 = RectangleF.FromLTRB(left, top, right, bottom);
		binaryReader_0.ReadUInt32();
		binaryReader_0.ReadUInt32();
		binaryReader_0.ReadUInt32();
		binaryReader_0.ReadUInt32();
		binaryReader_0.ReadUInt16();
		binaryReader_0.ReadUInt16();
		binaryReader_0.ReadUInt32();
		binaryReader_0.ReadUInt32();
		binaryReader_0.ReadUInt32();
		int_0 = binaryReader_0.ReadInt32();
		int_1 = binaryReader_0.ReadInt32();
		int_2 = binaryReader_0.ReadInt32();
		int_3 = binaryReader_0.ReadInt32();
		rectangleF_0 = new RectangleF(method_0(rectangleF_0.X, int_2, int_0), method_0(rectangleF_0.Y, int_3, int_1), method_0(rectangleF_0.Width, int_2, int_0), method_0(rectangleF_0.Height, int_3, int_1));
		binaryReader_0.BaseStream.Position = num;
	}

	private int method_0(float float_0, int int_4, int int_5)
	{
		return (int)Math.Round(float_0 * (float)int_5 / ((float)int_4 * 100f));
	}

	[SpecialName]
	internal RectangleF method_1()
	{
		return rectangleF_0;
	}
}
