using System;
using System.Drawing;
using System.IO;
using ns60;

namespace ns62;

internal class Class2742 : Class2623, Interface41
{
	public const int int_0 = 61456;

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

	public Rectangle Rectangle => rectangle_0;

	public Class2742()
		: base(61456, 0)
	{
	}

	protected override void vmethod_0(BinaryReader reader)
	{
		int num;
		int num2;
		int num3;
		int num4;
		if (base.Header.Length == 16)
		{
			num = reader.ReadInt32();
			num2 = reader.ReadInt32();
			num3 = reader.ReadInt32();
			num4 = reader.ReadInt32();
		}
		else
		{
			num2 = reader.ReadInt16();
			num = reader.ReadInt16();
			num3 = reader.ReadInt16();
			num4 = reader.ReadInt16();
		}
		rectangle_0 = new Rectangle(Math.Min(num, num3), Math.Min(num2, num4), Math.Abs(num3 - num), Math.Abs(num4 - num2));
	}

	public override void vmethod_1(BinaryWriter writer)
	{
		writer.Write((short)rectangle_0.Y);
		writer.Write((short)rectangle_0.X);
		writer.Write((short)(rectangle_0.X + rectangle_0.Width));
		writer.Write((short)(rectangle_0.Y + rectangle_0.Height));
	}

	public override int vmethod_2()
	{
		return 8;
	}
}
