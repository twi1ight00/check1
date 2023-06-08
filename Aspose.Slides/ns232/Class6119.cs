using System.IO;

namespace ns232;

internal class Class6119
{
	private StreamWriter streamWriter_0;

	private byte byte_0;

	private int int_0;

	public Class6119()
	{
		streamWriter_0 = new StreamWriter(new MemoryStream());
		streamWriter_0.AutoFlush = true;
		int_0 = 0;
		byte_0 = 0;
	}

	public void method_0(int bit)
	{
		byte_0 |= (byte)(bit << 7 - int_0);
		int_0++;
		if (int_0 == 8)
		{
			streamWriter_0.BaseStream.WriteByte(byte_0);
			byte_0 = 0;
			int_0 = 0;
		}
	}

	public void method_1(bool bit)
	{
		method_0(bit ? 1 : 0);
	}

	public void method_2(int value, int numBits)
	{
		for (int num = numBits - 1; num >= 0; num--)
		{
			method_0((value >> num) & 1);
		}
	}

	public void Flush()
	{
		if (int_0 > 0)
		{
			streamWriter_0.BaseStream.WriteByte(byte_0);
			byte_0 = 0;
			int_0 = 0;
		}
	}

	public byte[] method_3()
	{
		return ((MemoryStream)streamWriter_0.BaseStream).ToArray();
	}
}
