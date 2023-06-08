using System.IO;
using System.Runtime.CompilerServices;

namespace ns18;

internal class Class1393
{
	private BinaryReader binaryReader_0;

	private Class1393()
	{
	}

	public Class1393(Stream stream_0)
	{
		binaryReader_0 = new BinaryReader(stream_0);
	}

	[SpecialName]
	public Stream method_0()
	{
		return binaryReader_0.BaseStream;
	}

	public int method_1()
	{
		return Class1015.smethod_0(binaryReader_0.ReadInt32());
	}

	public uint method_2()
	{
		return Class1015.smethod_1(binaryReader_0.ReadUInt32());
	}

	public short method_3()
	{
		return Class1015.smethod_2(binaryReader_0.ReadInt16());
	}

	public ushort method_4()
	{
		return Class1015.smethod_3(binaryReader_0.ReadUInt16());
	}

	public byte ReadByte()
	{
		return binaryReader_0.ReadByte();
	}

	public byte[] method_5(int int_0)
	{
		return binaryReader_0.ReadBytes(int_0);
	}

	public char[] method_6(int int_0)
	{
		char[] array = new char[int_0];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = (char)binaryReader_0.ReadByte();
		}
		return array;
	}
}
