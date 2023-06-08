using System.IO;
using ns60;

namespace ns63;

internal class Class2937 : Interface40
{
	private uint uint_0;

	private int int_0;

	private int int_1;

	private int int_2;

	public uint Model => uint_0;

	public int Value1 => int_0;

	public int Value2 => int_1;

	public int Value3 => int_2;

	public Class2937()
	{
	}

	public Class2937(uint model, int value1, int value2, int value3)
	{
		uint_0 = model;
		int_0 = value1;
		int_1 = value2;
		int_2 = value3;
	}

	public void method_0(BinaryReader reader)
	{
		uint_0 = reader.ReadUInt32();
		int_0 = reader.ReadInt32();
		int_1 = reader.ReadInt32();
		int_2 = reader.ReadInt32();
	}

	public void method_1(BinaryWriter writer)
	{
		writer.Write(uint_0);
		writer.Write(int_0);
		writer.Write(int_1);
		writer.Write(int_2);
	}
}
