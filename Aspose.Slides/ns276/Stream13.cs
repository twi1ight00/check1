using System;
using System.IO;
using System.Reflection;
using System.Text;

namespace ns276;

internal class Stream13 : Stream
{
	internal enum Enum918
	{
		const_0,
		const_1,
		const_2
	}

	protected internal Class6756 class6756_0;

	protected internal Enum918 enum918_0 = Enum918.const_2;

	protected internal Enum898 enum898_0;

	protected internal Enum917 enum917_0;

	protected internal Enum916 enum916_0;

	protected internal Enum914 enum914_0;

	protected internal bool bool_0;

	protected internal byte[] byte_0;

	protected internal int int_0 = 8192;

	protected internal byte[] byte_1 = new byte[1];

	protected internal Stream stream_0;

	protected internal Enum915 enum915_0;

	private Class6740 class6740_0;

	protected internal string string_0;

	protected internal string string_1;

	protected internal DateTime dateTime_0;

	protected internal int int_1;

	private bool bool_1;

	internal int Crc32
	{
		get
		{
			if (class6740_0 == null)
			{
				return 0;
			}
			return class6740_0.Crc32Result;
		}
	}

	protected internal bool _wantCompress => enum916_0 == Enum916.const_0;

	private Class6756 z
	{
		get
		{
			if (class6756_0 == null)
			{
				bool flag = enum917_0 == Enum917.const_0;
				class6756_0 = new Class6756();
				if (enum916_0 == Enum916.const_1)
				{
					class6756_0.method_1(flag);
				}
				else
				{
					class6756_0.enum915_0 = enum915_0;
					class6756_0.method_9(enum914_0, flag);
				}
			}
			return class6756_0;
		}
	}

	private byte[] workingBuffer
	{
		get
		{
			if (byte_0 == null)
			{
				byte_0 = new byte[int_0];
			}
			return byte_0;
		}
	}

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

	public Stream13(Stream stream, Enum916 compressionMode, Enum914 level, Enum917 flavor, bool leaveOpen)
	{
		enum898_0 = Enum898.const_0;
		stream_0 = stream;
		bool_0 = leaveOpen;
		enum916_0 = compressionMode;
		enum917_0 = flavor;
		enum914_0 = level;
		if (flavor == Enum917.const_2)
		{
			class6740_0 = new Class6740();
		}
	}

	public override void Write(byte[] buffer, int offset, int count)
	{
		if (class6740_0 != null)
		{
			class6740_0.method_3(buffer, offset, count);
		}
		if (enum918_0 == Enum918.const_2)
		{
			enum918_0 = Enum918.const_0;
		}
		else if (enum918_0 != 0)
		{
			throw new Exception67("Cannot Write after Reading.");
		}
		if (count == 0)
		{
			return;
		}
		z.byte_0 = buffer;
		class6756_0.int_0 = offset;
		class6756_0.int_1 = count;
		bool flag = false;
		while (true)
		{
			class6756_0.byte_1 = workingBuffer;
			class6756_0.int_2 = 0;
			class6756_0.int_3 = byte_0.Length;
			int num = ((!_wantCompress) ? class6756_0.method_4(enum898_0) : class6756_0.method_13(enum898_0));
			if (num != 0 && num != 1)
			{
				break;
			}
			stream_0.Write(byte_0, 0, byte_0.Length - class6756_0.int_3);
			flag = class6756_0.int_1 == 0 && class6756_0.int_3 != 0;
			if (enum917_0 == Enum917.const_2 && !_wantCompress)
			{
				flag = class6756_0.int_1 == 8 && class6756_0.int_3 != 0;
			}
			if (flag)
			{
				return;
			}
		}
		throw new Exception67((_wantCompress ? "de" : "in") + "flating: " + class6756_0.string_0);
	}

	private void method_0()
	{
		if (class6756_0 == null)
		{
			return;
		}
		if (enum918_0 == Enum918.const_0)
		{
			bool flag = false;
			do
			{
				class6756_0.byte_1 = workingBuffer;
				class6756_0.int_2 = 0;
				class6756_0.int_3 = byte_0.Length;
				int num = ((!_wantCompress) ? class6756_0.method_4(Enum898.const_4) : class6756_0.method_13(Enum898.const_4));
				if (num == 1 || num == 0)
				{
					if (byte_0.Length - class6756_0.int_3 > 0)
					{
						stream_0.Write(byte_0, 0, byte_0.Length - class6756_0.int_3);
					}
					flag = class6756_0.int_1 == 0 && class6756_0.int_3 != 0;
					if (enum917_0 == Enum917.const_2 && !_wantCompress)
					{
						flag = class6756_0.int_1 == 8 && class6756_0.int_3 != 0;
					}
					continue;
				}
				throw new Exception67((_wantCompress ? "de" : "in") + "flating: " + class6756_0.string_0);
			}
			while (!flag);
			Flush();
			if (enum917_0 == Enum917.const_2)
			{
				if (!_wantCompress)
				{
					throw new Exception67("Writing with decompression is not supported.");
				}
				int crc32Result = class6740_0.Crc32Result;
				stream_0.Write(BitConverter.GetBytes(crc32Result), 0, 4);
				int value = (int)(class6740_0.TotalBytesRead & 0xFFFFFFFFL);
				stream_0.Write(BitConverter.GetBytes(value), 0, 4);
			}
		}
		else
		{
			if (enum918_0 != Enum918.const_1 || enum917_0 != Enum917.const_2)
			{
				return;
			}
			if (_wantCompress)
			{
				throw new Exception67("Reading with compression is not supported.");
			}
			if (class6756_0.long_1 != 0L)
			{
				byte[] array = new byte[8];
				if (class6756_0.int_1 != 8)
				{
					throw new Exception67($"Protocol error. AvailableBytesIn={class6756_0.int_1}, expected 8");
				}
				Array.Copy(class6756_0.byte_0, class6756_0.int_0, array, 0, array.Length);
				int num2 = BitConverter.ToInt32(array, 0);
				int crc32Result2 = class6740_0.Crc32Result;
				int num3 = BitConverter.ToInt32(array, 4);
				int num4 = (int)(class6756_0.long_1 & 0xFFFFFFFFL);
				if (crc32Result2 != num2)
				{
					throw new Exception67($"Bad CRC32 in GZIP stream. (actual({crc32Result2:X8})!=expected({num2:X8}))");
				}
				if (num4 != num3)
				{
					throw new Exception67($"Bad size in GZIP stream. (actual({num4})!=expected({num3}))");
				}
			}
		}
	}

	private void method_1()
	{
		if (z != null)
		{
			if (_wantCompress)
			{
				class6756_0.method_14();
			}
			else
			{
				class6756_0.method_5();
			}
			class6756_0 = null;
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
			method_0();
		}
		finally
		{
			method_1();
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

	private string method_2()
	{
		MemoryStream memoryStream = new MemoryStream();
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
					memoryStream.WriteByte(byte_1[0]);
				}
				continue;
			}
			throw new Exception67("Unexpected EOF reading GZIP header.");
		}
		while (!flag);
		byte[] array = memoryStream.ToArray();
		return Stream9.encoding_0.GetString(array, 0, array.Length);
	}

	private int method_3()
	{
		int num = 0;
		byte[] array = new byte[10];
		int num2 = stream_0.Read(array, 0, array.Length);
		switch (num2)
		{
		case 0:
			return 0;
		default:
			throw new Exception67("Not a valid GZIP stream.");
		case 10:
			if (array[0] == 31 && array[1] == 139 && array[2] == 8)
			{
				int num3 = BitConverter.ToInt32(array, 4);
				dateTime_0 = Stream9.dateTime_1.AddSeconds(num3);
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
						throw new Exception67("Unexpected end-of-file reading GZIP header.");
					}
					num += num2;
				}
				if ((array[3] & 8) == 8)
				{
					string_0 = method_2();
				}
				if ((array[3] & 0x10) == 16)
				{
					string_1 = method_2();
				}
				if ((array[3] & 2) == 2)
				{
					Read(byte_1, 0, 1);
				}
				return num;
			}
			throw new Exception67("Bad GZIP header.");
		}
	}

	public override int Read(byte[] buffer, int offset, int count)
	{
		if (enum918_0 == Enum918.const_2)
		{
			if (!stream_0.CanRead)
			{
				throw new Exception67("The stream is not readable.");
			}
			enum918_0 = Enum918.const_1;
			z.int_1 = 0;
			if (enum917_0 == Enum917.const_2)
			{
				int_1 = method_3();
				if (int_1 == 0)
				{
					return 0;
				}
			}
		}
		if (enum918_0 != Enum918.const_1)
		{
			throw new Exception67("Cannot Read after Writing.");
		}
		if (count == 0)
		{
			return 0;
		}
		if (bool_1 && _wantCompress)
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
		class6756_0.byte_1 = buffer;
		class6756_0.int_2 = offset;
		class6756_0.int_3 = count;
		class6756_0.byte_0 = workingBuffer;
		do
		{
			if (class6756_0.int_1 == 0 && !bool_1)
			{
				class6756_0.int_0 = 0;
				class6756_0.int_1 = stream_0.Read(byte_0, 0, byte_0.Length);
				if (class6756_0.int_1 == 0)
				{
					bool_1 = true;
				}
			}
			num = (_wantCompress ? class6756_0.method_13(enum898_0) : class6756_0.method_4(enum898_0));
			if (!bool_1 || num != -5)
			{
				if (num != 0 && num != 1)
				{
					throw new Exception67(string.Format("{0}flating:  rc={1}  msg={2}", _wantCompress ? "de" : "in", num, class6756_0.string_0));
				}
				continue;
			}
			return 0;
		}
		while (((!bool_1 && num != 1) || class6756_0.int_3 != count) && class6756_0.int_3 > 0 && !bool_1 && num == 0);
		if (class6756_0.int_3 > 0)
		{
			if (num != 0)
			{
			}
			if (bool_1 && _wantCompress)
			{
				num = class6756_0.method_13(Enum898.const_4);
				if (num != 0 && num != 1)
				{
					throw new Exception67($"Deflating:  rc={num}  msg={class6756_0.string_0}");
				}
			}
		}
		num = count - class6756_0.int_3;
		if (class6740_0 != null)
		{
			class6740_0.method_3(buffer, offset, num);
		}
		return num;
	}

	public static byte[] smethod_0(string s, Type type)
	{
		Encoding uTF = Encoding.UTF8;
		byte[] bytes = uTF.GetBytes(s);
		using MemoryStream memoryStream = new MemoryStream();
		Stream stream = (Stream)type.InvokeMember("This IS Ignored", BindingFlags.CreateInstance, null, null, new object[3]
		{
			memoryStream,
			Enum916.const_0,
			Enum914.const_12
		});
		using (stream)
		{
			stream.Write(bytes, 0, bytes.Length);
		}
		return memoryStream.ToArray();
	}

	public static string smethod_1(byte[] compressed, Type type)
	{
		byte[] array = new byte[1024];
		Encoding uTF = Encoding.UTF8;
		using MemoryStream memoryStream2 = new MemoryStream();
		using MemoryStream memoryStream = new MemoryStream(compressed);
		Stream stream = (Stream)type.InvokeMember("This IS Ignored", BindingFlags.CreateInstance, null, null, new object[2]
		{
			memoryStream,
			Enum916.const_1
		});
		using (stream)
		{
			int count;
			while ((count = stream.Read(array, 0, array.Length)) != 0)
			{
				memoryStream2.Write(array, 0, count);
			}
		}
		memoryStream2.Seek(0L, SeekOrigin.Begin);
		StreamReader streamReader = new StreamReader(memoryStream2, uTF);
		return streamReader.ReadToEnd();
	}

	public static byte[] smethod_2(byte[] b, Type type)
	{
		using MemoryStream memoryStream = new MemoryStream();
		Stream stream = (Stream)type.InvokeMember("This IS Ignored", BindingFlags.CreateInstance, null, null, new object[3]
		{
			memoryStream,
			Enum916.const_0,
			Enum914.const_12
		});
		using (stream)
		{
			stream.Write(b, 0, b.Length);
		}
		return memoryStream.ToArray();
	}

	public static byte[] smethod_3(byte[] compressed, Type type)
	{
		byte[] array = new byte[1024];
		using MemoryStream memoryStream2 = new MemoryStream();
		using MemoryStream memoryStream = new MemoryStream(compressed);
		Stream stream = (Stream)type.InvokeMember("This IS Ignored", BindingFlags.CreateInstance, null, null, new object[2]
		{
			memoryStream,
			Enum916.const_1
		});
		using (stream)
		{
			int count;
			while ((count = stream.Read(array, 0, array.Length)) != 0)
			{
				memoryStream2.Write(array, 0, count);
			}
		}
		return memoryStream2.ToArray();
	}
}
