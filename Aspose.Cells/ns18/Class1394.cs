using System.IO;
using System.Runtime.CompilerServices;

namespace ns18;

internal class Class1394
{
	private BinaryWriter binaryWriter_0;

	private Class1394()
	{
	}

	public Class1394(Stream stream_0)
	{
		binaryWriter_0 = new BinaryWriter(stream_0);
	}

	[SpecialName]
	public Stream method_0()
	{
		return binaryWriter_0.BaseStream;
	}

	public void method_1(int int_0)
	{
		binaryWriter_0.Write(Class1015.smethod_0(int_0));
	}

	public void method_2(uint uint_0)
	{
		binaryWriter_0.Write(Class1015.smethod_1(uint_0));
	}

	public void method_3(int int_0)
	{
		binaryWriter_0.Write(Class1010.smethod_1((short)int_0));
	}

	public void method_4(ushort ushort_0)
	{
		binaryWriter_0.Write(Class1015.smethod_3(ushort_0));
	}

	public void WriteByte(byte byte_0)
	{
		binaryWriter_0.Write(byte_0);
	}

	public void method_5(byte[] byte_0, int int_0, int int_1)
	{
		binaryWriter_0.Write(byte_0, int_0, int_1);
	}

	public void Flush()
	{
		binaryWriter_0.Flush();
	}
}
