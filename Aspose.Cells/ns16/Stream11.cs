using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;

namespace ns16;

internal class Stream11 : Stream
{
	internal enum Enum46
	{
		const_0,
		const_1,
		const_2
	}

	protected internal Class765 class765_0;

	protected internal Enum46 enum46_0 = Enum46.const_2;

	protected internal Enum41 enum41_0;

	protected internal Enum45 enum45_0;

	protected internal Enum44 enum44_0;

	protected internal Enum42 enum42_0;

	protected internal bool bool_0;

	protected internal byte[] byte_0;

	protected internal int int_0 = 16384;

	protected internal byte[] byte_1 = new byte[1];

	protected internal Stream stream_0;

	protected internal Enum43 enum43_0;

	private Class741 class741_0;

	protected internal string string_0;

	protected internal string string_1;

	protected internal DateTime dateTime_0;

	protected internal int int_1;

	private bool bool_1;

	public override bool CanRead => stream_0.CanRead;

	public override bool CanSeek => stream_0.CanSeek;

	public override bool CanWrite => stream_0.CanWrite;

	public override long Length => stream_0.Length;

	public override long Position
	{
		get
		{
			throw new NotImplementedException();
		}
		set
		{
			throw new NotImplementedException();
		}
	}

	[SpecialName]
	internal int method_0()
	{
		if (class741_0 == null)
		{
			return 0;
		}
		return class741_0.method_1();
	}

	public Stream11(Stream stream_1, Enum44 enum44_1, Enum42 enum42_1, Enum45 enum45_1, bool bool_2)
	{
		enum41_0 = Enum41.const_0;
		stream_0 = stream_1;
		bool_0 = bool_2;
		enum44_0 = enum44_1;
		enum45_0 = enum45_1;
		enum42_0 = enum42_1;
		if (enum45_1 == Enum45.const_2)
		{
			class741_0 = new Class741();
		}
	}

	[SpecialName]
	protected internal bool method_1()
	{
		return enum44_0 == Enum44.const_0;
	}

	[SpecialName]
	private Class765 method_2()
	{
		if (class765_0 == null)
		{
			bool flag = enum45_0 == Enum45.const_0;
			class765_0 = new Class765();
			if (enum44_0 == Enum44.const_1)
			{
				class765_0.method_0(flag);
			}
			else
			{
				class765_0.enum43_0 = enum43_0;
				class765_0.method_4(enum42_0, flag);
			}
		}
		return class765_0;
	}

	[SpecialName]
	private byte[] method_3()
	{
		if (byte_0 == null)
		{
			byte_0 = new byte[int_0];
		}
		return byte_0;
	}

	public override void Write(byte[] buffer, int offset, int count)
	{
		if (class741_0 != null)
		{
			class741_0.method_6(buffer, offset, count);
		}
		if (enum46_0 == Enum46.const_2)
		{
			enum46_0 = Enum46.const_0;
		}
		else if (enum46_0 != 0)
		{
			throw new Exception5("Cannot Write after Reading.");
		}
		if (count == 0)
		{
			return;
		}
		method_2().byte_0 = buffer;
		class765_0.int_0 = offset;
		class765_0.int_1 = count;
		bool flag = false;
		while (true)
		{
			class765_0.byte_1 = method_3();
			class765_0.int_2 = 0;
			class765_0.int_3 = byte_0.Length;
			int num = ((!method_1()) ? class765_0.method_2(enum41_0) : class765_0.method_6(enum41_0));
			if (num != 0 && num != 1)
			{
				break;
			}
			stream_0.Write(byte_0, 0, byte_0.Length - class765_0.int_3);
			flag = class765_0.int_1 == 0 && class765_0.int_3 != 0;
			if (enum45_0 == Enum45.const_2 && !method_1())
			{
				flag = class765_0.int_1 == 8 && class765_0.int_3 != 0;
			}
			if (flag)
			{
				return;
			}
		}
		throw new Exception5((method_1() ? "de" : "in") + "flating: " + class765_0.string_0);
	}

	internal void method_4()
	{
		if (class765_0 == null)
		{
			return;
		}
		if (enum46_0 == Enum46.const_0)
		{
			bool flag = false;
			do
			{
				class765_0.byte_1 = method_3();
				class765_0.int_2 = 0;
				class765_0.int_3 = byte_0.Length;
				int num = ((!method_1()) ? class765_0.method_2(Enum41.const_4) : class765_0.method_6(Enum41.const_4));
				if (num == 1 || num == 0)
				{
					if (byte_0.Length - class765_0.int_3 > 0)
					{
						stream_0.Write(byte_0, 0, byte_0.Length - class765_0.int_3);
					}
					flag = class765_0.int_1 == 0 && class765_0.int_3 != 0;
					if (enum45_0 == Enum45.const_2 && !method_1())
					{
						flag = class765_0.int_1 == 8 && class765_0.int_3 != 0;
					}
					continue;
				}
				string text = (method_1() ? "de" : "in") + "flating";
				if (class765_0.string_0 == null)
				{
					throw new Exception5($"{text}: (rc = {num})");
				}
				throw new Exception5(text + ": " + class765_0.string_0);
			}
			while (!flag);
			Flush();
			if (enum45_0 == Enum45.const_2)
			{
				if (!method_1())
				{
					throw new Exception5("Writing with decompression is not supported.");
				}
				int value = class741_0.method_1();
				stream_0.Write(BitConverter.GetBytes(value), 0, 4);
				int value2 = (int)(class741_0.method_0() & 0xFFFFFFFFu);
				stream_0.Write(BitConverter.GetBytes(value2), 0, 4);
			}
		}
		else
		{
			if (enum46_0 != Enum46.const_1 || enum45_0 != Enum45.const_2)
			{
				return;
			}
			if (method_1())
			{
				throw new Exception5("Reading with compression is not supported.");
			}
			if (class765_0.long_1 == 0)
			{
				return;
			}
			byte[] array = new byte[8];
			if (class765_0.int_1 < 8)
			{
				Array.Copy(class765_0.byte_0, class765_0.int_0, array, 0, class765_0.int_1);
				int num2 = 8 - class765_0.int_1;
				int num3 = stream_0.Read(array, class765_0.int_1, num2);
				if (num2 != num3)
				{
					throw new Exception5($"Missing or incomplete GZIP trailer. Expected 8 bytes, got {class765_0.int_1 + num3}.");
				}
			}
			else
			{
				Array.Copy(class765_0.byte_0, class765_0.int_0, array, 0, array.Length);
			}
			int num4 = BitConverter.ToInt32(array, 0);
			int num5 = class741_0.method_1();
			int num6 = BitConverter.ToInt32(array, 4);
			int num7 = (int)(class765_0.long_1 & 0xFFFFFFFFu);
			if (num5 != num4)
			{
				throw new Exception5($"Bad CRC32 in GZIP trailer. (actual({num5:X8})!=expected({num4:X8}))");
			}
			if (num7 != num6)
			{
				throw new Exception5($"Bad size in GZIP trailer. (actual({num7})!=expected({num6}))");
			}
		}
	}

	private void method_5()
	{
		if (method_2() != null)
		{
			if (method_1())
			{
				class765_0.method_7();
			}
			else
			{
				class765_0.method_3();
			}
			class765_0 = null;
		}
	}

	public override void Close()
	{
		if (stream_0 == null)
		{
			return;
		}
		try
		{
			method_4();
		}
		finally
		{
			method_5();
			if (!bool_0)
			{
				stream_0.Close();
			}
			stream_0 = null;
		}
	}

	public override void Flush()
	{
		stream_0.Flush();
	}

	public override long Seek(long offset, SeekOrigin origin)
	{
		throw new NotImplementedException();
	}

	public override void SetLength(long value)
	{
		stream_0.SetLength(value);
	}

	private string method_6()
	{
		List<byte> list = new List<byte>();
		bool flag = false;
		do
		{
			int num = stream_0.Read(byte_1, 0, 1);
			if (num == 1)
			{
				if (byte_1[0] == 0)
				{
					flag = true;
				}
				else
				{
					list.Add(byte_1[0]);
				}
				continue;
			}
			throw new Exception5("Unexpected EOF reading GZIP header.");
		}
		while (!flag);
		byte[] array = list.ToArray();
		return Stream9.encoding_0.GetString(array, 0, array.Length);
	}

	private int method_7()
	{
		int num = 0;
		byte[] array = new byte[10];
		int num2 = stream_0.Read(array, 0, array.Length);
		switch (num2)
		{
		case 0:
			return 0;
		default:
			throw new Exception5("Not a valid GZIP stream.");
		case 10:
			if (array[0] == 31 && array[1] == 139 && array[2] == 8)
			{
				int num3 = BitConverter.ToInt32(array, 4);
				dateTime_0 = Stream9.dateTime_0.AddSeconds(num3);
				num += num2;
				if ((array[3] & 4) == 4)
				{
					num2 = stream_0.Read(array, 0, 2);
					num += num2;
					short num4 = (short)(array[0] + array[1] * 256);
					byte[] array2 = new byte[num4];
					num2 = stream_0.Read(array2, 0, array2.Length);
					if (num2 != num4)
					{
						throw new Exception5("Unexpected end-of-file reading GZIP header.");
					}
					num += num2;
				}
				if ((array[3] & 8) == 8)
				{
					string_0 = method_6();
				}
				if ((array[3] & 0x10) == 16)
				{
					string_1 = method_6();
				}
				if ((array[3] & 2) == 2)
				{
					Read(byte_1, 0, 1);
				}
				return num;
			}
			throw new Exception5("Bad GZIP header.");
		}
	}

	public override int Read(byte[] buffer, int offset, int count)
	{
		if (enum46_0 == Enum46.const_2)
		{
			if (!stream_0.CanRead)
			{
				throw new Exception5("The stream is not readable.");
			}
			enum46_0 = Enum46.const_1;
			method_2().int_1 = 0;
			if (enum45_0 == Enum45.const_2)
			{
				int_1 = method_7();
				if (int_1 == 0)
				{
					return 0;
				}
			}
		}
		if (enum46_0 != Enum46.const_1)
		{
			throw new Exception5("Cannot Read after Writing.");
		}
		if (count == 0)
		{
			return 0;
		}
		if (bool_1 && method_1())
		{
			return 0;
		}
		if (buffer == null)
		{
			throw new ArgumentNullException("buffer");
		}
		if (count < 0)
		{
			throw new ArgumentOutOfRangeException("count");
		}
		if (offset < buffer.GetLowerBound(0))
		{
			throw new ArgumentOutOfRangeException("offset");
		}
		if (offset + count > buffer.GetLength(0))
		{
			throw new ArgumentOutOfRangeException("count");
		}
		int num = 0;
		class765_0.byte_1 = buffer;
		class765_0.int_2 = offset;
		class765_0.int_3 = count;
		class765_0.byte_0 = method_3();
		do
		{
			if (class765_0.int_1 == 0 && !bool_1)
			{
				class765_0.int_0 = 0;
				class765_0.int_1 = stream_0.Read(byte_0, 0, byte_0.Length);
				if (class765_0.int_1 == 0)
				{
					bool_1 = true;
				}
			}
			num = (method_1() ? class765_0.method_6(enum41_0) : class765_0.method_2(enum41_0));
			if (!bool_1 || num != -5)
			{
				if (num != 0 && num != 1)
				{
					throw new Exception5(string.Format("{0}flating:  rc={1}  msg={2}", method_1() ? "de" : "in", num, class765_0.string_0));
				}
				continue;
			}
			return 0;
		}
		while (((!bool_1 && num != 1) || class765_0.int_3 != count) && class765_0.int_3 > 0 && !bool_1 && num == 0);
		if (class765_0.int_3 > 0)
		{
			if (num != 0)
			{
			}
			if (bool_1 && method_1())
			{
				num = class765_0.method_6(Enum41.const_4);
				if (num != 0 && num != 1)
				{
					throw new Exception5($"Deflating:  rc={num}  msg={class765_0.string_0}");
				}
			}
		}
		num = count - class765_0.int_3;
		if (class741_0 != null)
		{
			class741_0.method_6(buffer, offset, num);
		}
		return num;
	}
}
