using System;
using System.IO;

namespace ns218;

internal class Class5950
{
	private BinaryReader binaryReader_0;

	public Stream BaseStream => binaryReader_0.BaseStream;

	private Class5950()
	{
	}

	public Class5950(Stream stream)
	{
		binaryReader_0 = new BinaryReader(stream);
	}

	public int method_0()
	{
		return Class5952.smethod_0(binaryReader_0.ReadInt32());
	}

	[CLSCompliant(false)]
	public uint method_1()
	{
		return Class5952.smethod_1(binaryReader_0.ReadUInt32());
	}

	public short method_2()
	{
		return Class5952.smethod_2(binaryReader_0.ReadInt16());
	}

	[CLSCompliant(false)]
	public ushort method_3()
	{
		return Class5952.smethod_3(binaryReader_0.ReadUInt16());
	}

	public float method_4()
	{
		byte[] array = method_8(4);
		Array.Reverse(array);
		return BitConverter.ToSingle(array, 0);
	}

	public bool method_5()
	{
		return binaryReader_0.ReadBoolean();
	}

	public char method_6()
	{
		byte[] array = method_8(2);
		Array.Reverse(array);
		return BitConverter.ToChar(array, 0);
	}

	public char[] method_7(int count)
	{
		return binaryReader_0.ReadChars(count);
	}

	public byte ReadByte()
	{
		return binaryReader_0.ReadByte();
	}

	public byte[] method_8(int count)
	{
		return binaryReader_0.ReadBytes(count);
	}

	[CLSCompliant(false)]
	public sbyte method_9()
	{
		return binaryReader_0.ReadSByte();
	}

	public int Read(byte[] buff, int offset, int count)
	{
		return binaryReader_0.Read(buff, offset, count);
	}

	public char[] method_10(int count)
	{
		char[] array = new char[count];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = (char)binaryReader_0.ReadByte();
		}
		return array;
	}
}
