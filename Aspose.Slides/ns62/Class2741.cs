using System;
using System.Drawing;
using System.IO;
using ns60;

namespace ns62;

internal class Class2741 : Class2623, Interface41
{
	internal const int int_0 = 61455;

	private Rectangle rectangle_0 = new Rectangle(0, 0, 0, 0);

	public int X
	{
		get
		{
			return rectangle_0.X;
		}
		set
		{
			rectangle_0.X = value;
		}
	}

	public int Y
	{
		get
		{
			return rectangle_0.Y;
		}
		set
		{
			rectangle_0.Y = value;
		}
	}

	public int Width
	{
		get
		{
			return rectangle_0.Width;
		}
		set
		{
			rectangle_0.Width = value;
		}
	}

	public int Height
	{
		get
		{
			return rectangle_0.Height;
		}
		set
		{
			rectangle_0.Height = value;
		}
	}

	public Rectangle Rectangle
	{
		get
		{
			return rectangle_0;
		}
		set
		{
			rectangle_0 = new Rectangle(value.Location, value.Size);
		}
	}

	public Class2741()
		: base(61455, 0)
	{
	}

	protected override void vmethod_0(BinaryReader reader)
	{
		int num = reader.ReadInt32();
		int num2 = reader.ReadInt32();
		int num3 = reader.ReadInt32();
		int num4 = reader.ReadInt32();
		rectangle_0 = new Rectangle(Math.Min(num, num3), Math.Min(num2, num4), Math.Abs(num3 - num), Math.Abs(num4 - num2));
	}

	public override void vmethod_1(BinaryWriter writer)
	{
		writer.Write(rectangle_0.X);
		writer.Write(rectangle_0.Y);
		writer.Write(rectangle_0.X + rectangle_0.Width);
		writer.Write(rectangle_0.Y + rectangle_0.Height);
	}

	public override int vmethod_2()
	{
		return 16;
	}
}
