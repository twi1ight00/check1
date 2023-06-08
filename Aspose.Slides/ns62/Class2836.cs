using System.IO;
using ns60;

namespace ns62;

internal class Class2836 : Class2623
{
	public const int int_0 = 61449;

	private int int_1;

	private int int_2;

	private int int_3;

	private int int_4;

	public int X
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

	public int Y
	{
		get
		{
			return int_2;
		}
		set
		{
			int_2 = value;
		}
	}

	public int Width
	{
		get
		{
			return int_3;
		}
		set
		{
			int_3 = value;
		}
	}

	public int Height
	{
		get
		{
			return int_4;
		}
		set
		{
			int_4 = value;
		}
	}

	public Class2836()
		: base(61449, 1)
	{
		int_1 = 0;
		int_2 = 0;
		int_3 = 0;
		int_4 = 0;
	}

	public Class2836(int left, int top, int width, int height)
		: base(61449, 1)
	{
		int_1 = left;
		int_2 = top;
		int_3 = width;
		int_4 = height;
	}

	protected override void vmethod_0(BinaryReader reader)
	{
		int_1 = reader.ReadInt32();
		int_2 = reader.ReadInt32();
		int_3 = reader.ReadInt32() - int_1;
		int_4 = reader.ReadInt32() - int_2;
	}

	public override void vmethod_1(BinaryWriter writer)
	{
		writer.Write(int_1);
		writer.Write(int_2);
		writer.Write(int_1 + int_3);
		writer.Write(int_2 + int_4);
	}

	public override int vmethod_2()
	{
		return 16;
	}
}
