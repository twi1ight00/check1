using System;
using System.IO;
using System.Text;
using ns119;

namespace ns149;

internal class Class4689 : IDisposable
{
	private Stream stream_0;

	private Class4487 class4487_0;

	public long Position => stream_0.Position;

	public long StreamLength => stream_0.Length;

	public bool IsOutOfStream => Position > StreamLength - 1L;

	public Class4689(Class4487 streamSource)
	{
		stream_0 = streamSource.vmethod_0();
		class4487_0 = streamSource;
	}

	public void Seek(long position)
	{
		stream_0.Seek(position, SeekOrigin.Begin);
	}

	public byte ReadByte()
	{
		int num = stream_0.ReadByte();
		if (num == -1)
		{
			throw new EndOfStreamException();
		}
		return (byte)num;
	}

	public sbyte method_0()
	{
		int num = stream_0.ReadByte();
		if (num == -1)
		{
			throw new EndOfStreamException();
		}
		return (sbyte)num;
	}

	public byte[] method_1(int bytesCount)
	{
		byte[] array = new byte[bytesCount];
		method_2(bytesCount, array, 0);
		return array;
	}

	public void method_2(int bytesCount, byte[] buffer, int bufferOffset)
	{
		int num = stream_0.Read(buffer, bufferOffset, bytesCount);
		if (num == -1)
		{
			throw new EndOfStreamException();
		}
	}

	public string method_3(int charsNum)
	{
		byte[] array = new byte[charsNum];
		int num = stream_0.Read(array, 0, charsNum);
		if (num == 0 || num < charsNum)
		{
			throw new EndOfStreamException();
		}
		return Encoding.ASCII.GetString(array);
	}

	public string method_4(int bytesNum, string encodingName)
	{
		return method_5(bytesNum, encodingName, useDefaultOnFail: false);
	}

	public string method_5(int bytesNum, string encodingName, bool useDefaultOnFail)
	{
		byte[] array = new byte[bytesNum];
		if (bytesNum != 0)
		{
			int num = stream_0.Read(array, 0, bytesNum);
			if (!useDefaultOnFail && (num == 0 || num < bytesNum))
			{
				throw new EndOfStreamException();
			}
		}
		if (encodingName == "big5")
		{
			byte[] array2 = new byte[bytesNum];
			int count = 0;
			byte[] array3 = array;
			foreach (byte b in array3)
			{
				if (b != 0)
				{
					array2[count++] = b;
				}
			}
			return Encoding.GetEncoding(encodingName).GetString(array2, 0, count);
		}
		return Encoding.GetEncoding(encodingName).GetString(array);
	}

	public DateTime method_6()
	{
		return method_7(useDefaultOnFail: false);
	}

	public DateTime method_7(bool useDefaultOnFail)
	{
		long num = method_16();
		DateTime result = new DateTime(1904, 1, 1);
		try
		{
			result = result.AddSeconds(num);
			return result;
		}
		catch (ArgumentOutOfRangeException)
		{
			if (!useDefaultOnFail)
			{
				throw;
			}
		}
		return result;
	}

	public float method_8()
	{
		float num = 0f;
		num = method_14();
		return num + (float)((int)method_18() / 65536);
	}

	public ushort method_9()
	{
		return method_18();
	}

	public short method_10()
	{
		return method_14();
	}

	public sbyte method_11()
	{
		byte b = method_17();
		return (sbyte)((b < 127) ? b : (b - 256));
	}

	public double method_12()
	{
		short num = method_14();
		return (double)(num >> 14) + (double)(num & 0x3FFF) / 16384.0;
	}

	public double method_13()
	{
		int num = method_15();
		return (double)num / 64.0;
	}

	public short method_14()
	{
		ushort num = method_18();
		return (short)num;
	}

	public int method_15()
	{
		return (int)method_19();
	}

	public long method_16()
	{
		byte[] array = new byte[8];
		int num = stream_0.Read(array, 0, 8);
		if (num == 0 || num < 8)
		{
			throw new EndOfStreamException();
		}
		return (long)(((ulong)array[0] << 56) + ((ulong)array[1] << 48) + ((ulong)array[2] << 40) + ((ulong)array[3] << 32) + ((ulong)array[4] << 24) + ((ulong)array[5] << 16) + ((ulong)array[6] << 8) + array[7]);
	}

	public byte method_17()
	{
		int num = stream_0.ReadByte();
		if (num < 0)
		{
			throw new EndOfStreamException();
		}
		return (byte)num;
	}

	public ushort method_18()
	{
		byte[] array = new byte[2];
		int num = stream_0.Read(array, 0, 2);
		if (num == 0 || num < 2)
		{
			throw new EndOfStreamException();
		}
		return (ushort)((array[0] << 8) + array[1]);
	}

	public uint method_19()
	{
		byte[] array = new byte[4];
		int num = stream_0.Read(array, 0, 4);
		if (num == 0 || num < 4)
		{
			throw new EndOfStreamException();
		}
		return (uint)((array[0] << 24) + (array[1] << 16) + (array[2] << 8) + array[3]);
	}

	void IDisposable.Dispose()
	{
		if (class4487_0.vmethod_1())
		{
			stream_0.Close();
		}
	}
}
