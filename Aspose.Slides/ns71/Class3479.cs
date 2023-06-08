using System;
using System.IO;

namespace ns71;

internal class Class3479 : Class3478
{
	private ushort ushort_0;

	private int int_0;

	private int int_1;

	public ushort Value
	{
		get
		{
			return ushort_0;
		}
		set
		{
			ushort_0 = value;
		}
	}

	internal override void vmethod_0(BinaryReader reader)
	{
		byte b = reader.ReadByte();
		byte b2 = reader.ReadByte();
		ushort_0 = (ushort)((b2 << 8) + b);
	}

	internal override void vmethod_1(BinaryWriter writer)
	{
		writer.Write(ushort_0);
	}

	public override void vmethod_2(BinaryWriter writer)
	{
		MemoryStream memoryStream = writer.BaseStream as MemoryStream;
		int num = method_1(writer.BaseStream.Position);
		int num2 = 16 - num;
		int num3 = method_2(num2);
		int_0 = ((ushort_0 & num3) >> num2) + 1;
		int num4 = method_3(num);
		int_1 = (ushort_0 & num4) + 3;
		for (int i = 0; i < int_1; i++)
		{
			byte[] buffer = memoryStream.GetBuffer();
			byte value = buffer[writer.BaseStream.Position - int_0];
			writer.Write(value);
		}
	}

	public int method_0(int length, int offset, int pos)
	{
		int_0 = offset - 1;
		int num = method_1(pos);
		int num2 = 16 - num;
		int val = 65535 >> num;
		int_1 = Math.Min(length - 3, val);
		ushort_0 = (ushort)int_1;
		ushort_0 |= (ushort)(int_0 << num2);
		return int_1 + 3;
	}

	private int method_1(long pos)
	{
		int num = Convert.ToInt32(Math.Ceiling(Math.Log(pos, 2.0)));
		if (num < 4)
		{
			num = 4;
		}
		return num;
	}

	private int method_2(int lengthBitsNumber)
	{
		return Convert.ToInt32(Math.Pow(2.0, 16 - lengthBitsNumber)) - 1 << lengthBitsNumber;
	}

	private int method_3(int offsetBitsNumber)
	{
		return Convert.ToInt32(Math.Pow(2.0, 16 - offsetBitsNumber)) - 1;
	}
}
