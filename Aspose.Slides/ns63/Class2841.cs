using System;
using System.Drawing;
using System.IO;
using ns60;

namespace ns63;

internal class Class2841 : Class2623
{
	internal const int int_0 = 12001;

	private int int_1;

	private Class2939 class2939_0 = new Class2939();

	private Point point_0;

	public int Index
	{
		get
		{
			return int_1;
		}
		set
		{
			int_1 = value;
		}
	}

	public DateTime DateTime
	{
		get
		{
			return class2939_0.DateTime;
		}
		set
		{
			class2939_0.DateTime = value;
		}
	}

	public Point Anchor
	{
		get
		{
			return point_0;
		}
		set
		{
			point_0 = value;
		}
	}

	public Class2841()
	{
		base.Header.Type = 12001;
	}

	protected override void vmethod_0(BinaryReader reader)
	{
		int_1 = reader.ReadInt32();
		class2939_0.method_0(reader);
		int x = reader.ReadInt32();
		int y = reader.ReadInt32();
		point_0 = new Point(x, y);
	}

	public override void vmethod_1(BinaryWriter writer)
	{
		writer.Write((uint)int_1);
		class2939_0.method_1(writer);
		writer.Write(point_0.X);
		writer.Write(point_0.Y);
	}

	public override int vmethod_2()
	{
		return 28;
	}
}
