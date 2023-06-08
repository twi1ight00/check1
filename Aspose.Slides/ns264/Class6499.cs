using System.Collections.Generic;
using System.Drawing;

namespace ns264;

internal class Class6499 : Interface318
{
	private int int_0;

	private RectangleF rectangleF_0 = RectangleF.Empty;

	private readonly List<RectangleF> list_0 = new List<RectangleF>();

	public Enum866 Type => Enum866.const_4;

	public int Handle
	{
		get
		{
			return int_0;
		}
		set
		{
			int_0 = value;
		}
	}

	internal RectangleF Bounds
	{
		get
		{
			return rectangleF_0;
		}
		set
		{
			rectangleF_0 = value;
		}
	}

	internal List<RectangleF> Scans => list_0;

	internal void method_0(Class6501 reader)
	{
		reader.ReadInt16();
		reader.ReadInt16();
		reader.ReadInt32();
		reader.ReadInt16();
		int num = reader.ReadInt16();
		reader.ReadInt16();
		rectangleF_0 = reader.method_7();
		list_0.Clear();
		for (int i = 0; i < num; i++)
		{
			int num2 = reader.ReadUInt16();
			int num3 = reader.ReadUInt16();
			int num4 = reader.ReadUInt16();
			for (int j = 0; j < num2; j++)
			{
				int num5 = reader.ReadUInt16();
				int num6 = reader.ReadUInt16();
				list_0.Add(new RectangleF(num5, num3, num6 - num5, num4 - num3));
			}
			reader.ReadUInt16();
		}
	}

	internal void method_1(Class6498 reader)
	{
		reader.ReadInt32();
		reader.ReadInt32();
		int num = reader.ReadInt32();
		reader.ReadInt32();
		rectangleF_0 = reader.method_8();
		list_0.Clear();
		for (int i = 0; i < num; i++)
		{
			list_0.Add(reader.method_8());
		}
	}
}
