using System;
using System.IO;
using ns231;

namespace ns232;

internal class Class6120
{
	private static int int_0 = 255;

	private static int int_1 = int_0 - 7;

	private static int int_2 = int_1 - 1;

	private static int int_3 = int_2 - 7;

	private static int int_4 = int_3 - 1;

	private static int int_5 = int_4 - 1;

	private static int int_6 = int_5;

	private StreamWriter streamWriter_0;

	public Class6120()
	{
		streamWriter_0 = new StreamWriter(new MemoryStream());
		streamWriter_0.AutoFlush = true;
	}

	public void method_0(Class6039 cvtTable)
	{
		int num = cvtTable.method_13();
		streamWriter_0.BaseStream.WriteByte((byte)(num >> 8));
		streamWriter_0.BaseStream.WriteByte((byte)((uint)num & 0xFFu));
		int num2 = 0;
		for (int i = 0; i < num; i++)
		{
			int num3 = cvtTable.method_12(i * 2);
			int num4 = (short)(num3 - num2);
			int num5 = Math.Abs(num4);
			int num6 = num5 / int_6;
			if (num6 <= 8)
			{
				if (num4 < 0)
				{
					streamWriter_0.BaseStream.WriteByte((byte)(int_4 + num6));
					streamWriter_0.BaseStream.WriteByte((byte)(num5 - num6 * int_6));
				}
				else
				{
					if (num6 > 0)
					{
						streamWriter_0.BaseStream.WriteByte((byte)(int_1 + num6 - 1));
					}
					streamWriter_0.BaseStream.WriteByte((byte)(num5 - num6 * int_6));
				}
			}
			else
			{
				streamWriter_0.BaseStream.WriteByte((byte)int_5);
				streamWriter_0.BaseStream.WriteByte((byte)(num4 >> 8));
				streamWriter_0.BaseStream.WriteByte((byte)((uint)num4 & 0xFFu));
			}
			num2 = num3;
		}
	}

	public byte[] method_1()
	{
		return ((MemoryStream)streamWriter_0.BaseStream).ToArray();
	}
}
