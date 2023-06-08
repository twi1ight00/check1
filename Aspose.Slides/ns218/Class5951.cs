using System;
using System.IO;

namespace ns218;

internal class Class5951
{
	private readonly BinaryWriter binaryWriter_0;

	public Stream BaseStream => binaryWriter_0.BaseStream;

	public Class5951(Stream stream)
	{
		binaryWriter_0 = new BinaryWriter(stream);
	}

	public void method_0(int value)
	{
		binaryWriter_0.Write(Class5952.smethod_0(value));
	}

	[CLSCompliant(false)]
	public void method_1(uint value)
	{
		binaryWriter_0.Write((int)Class5952.smethod_1(value));
	}

	[CLSCompliant(false)]
	public void method_2(ushort value)
	{
		binaryWriter_0.Write((int)Class5952.smethod_3(value));
	}

	public void method_3(int value)
	{
		binaryWriter_0.Write(Class5952.smethod_2((short)value));
	}

	public void WriteByte(byte value)
	{
		binaryWriter_0.Write(value);
	}

	public void method_4(byte[] buffer, int index, int count)
	{
		binaryWriter_0.Write(buffer, index, count);
	}

	public void Flush()
	{
		binaryWriter_0.Flush();
	}
}
