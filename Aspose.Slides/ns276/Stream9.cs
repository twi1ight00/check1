using System;
using System.Globalization;
using System.IO;
using System.Text;

namespace ns276;

internal class Stream9 : Stream, IDisposable
{
	public DateTime dateTime_0 = DateTime.MinValue;

	private int int_0;

	internal Stream13 stream13_0;

	private bool bool_0;

	private bool bool_1;

	private string string_0;

	private string string_1;

	private int int_1;

	internal static DateTime dateTime_1 = new DateTime(1970, 1, 1, 0, 0, 0, CultureInfo.InvariantCulture.Calendar);

	internal static Encoding encoding_0 = Encoding.GetEncoding("iso-8859-1");

	public string Comment
	{
		get
		{
			return string_1;
		}
		set
		{
			if (bool_0)
			{
				throw new ObjectDisposedException("GZipStream");
			}
			string_1 = value;
		}
	}

	public string FileName
	{
		get
		{
			return string_0;
		}
		set
		{
			if (bool_0)
			{
				throw new ObjectDisposedException("GZipStream");
			}
			string_0 = value;
			if (string_0 != null)
			{
				if (string_0.IndexOf("/") != -1)
				{
					string_0 = string_0.Replace("/", "\\");
				}
				if (string_0.EndsWith("\\"))
				{
					throw new InvalidOperationException("Illegal filename");
				}
				if (string_0.IndexOf("\\") != -1)
				{
					string_0 = Path.GetFileName(string_0);
				}
			}
		}
	}

	public int Crc32 => int_1;

	public virtual Enum898 FlushMode
	{
		get
		{
			return stream13_0.enum898_0;
		}
		set
		{
			if (bool_0)
			{
				throw new ObjectDisposedException("GZipStream");
			}
			stream13_0.enum898_0 = value;
		}
	}

	public int BufferSize
	{
		get
		{
			return stream13_0.int_0;
		}
		set
		{
			if (bool_0)
			{
				throw new ObjectDisposedException("GZipStream");
			}
			if (stream13_0.byte_0 != null)
			{
				throw new Exception67("The working buffer is already set.");
			}
			if (value < 128)
			{
				throw new Exception67($"Don't be silly. {value} bytes?? Use a bigger buffer.");
			}
			stream13_0.int_0 = value;
		}
	}

	public virtual long TotalIn => stream13_0.class6756_0.long_0;

	public virtual long TotalOut => stream13_0.class6756_0.long_1;

	public override bool CanRead
	{
		get
		{
			if (bool_0)
			{
				throw new ObjectDisposedException("GZipStream");
			}
			return stream13_0.stream_0.CanRead;
		}
	}

	public override bool CanSeek => false;

	public override bool CanWrite
	{
		get
		{
			if (bool_0)
			{
				throw new ObjectDisposedException("GZipStream");
			}
			return stream13_0.stream_0.CanWrite;
		}
	}

	public override long Length
	{
		get
		{
			throw new NotImplementedException();
		}
	}

	public override long Position
	{
		get
		{
			if (stream13_0.enum918_0 == Stream13.Enum918.const_0)
			{
				return stream13_0.class6756_0.long_1 + int_0;
			}
			if (stream13_0.enum918_0 == Stream13.Enum918.const_1)
			{
				return stream13_0.class6756_0.long_0 + stream13_0.int_1;
			}
			return 0L;
		}
		set
		{
			throw new NotImplementedException();
		}
	}

	public Stream9(Stream stream, Enum916 mode)
		: this(stream, mode, Enum914.const_8, leaveOpen: false)
	{
	}

	public Stream9(Stream stream, Enum916 mode, Enum914 level)
		: this(stream, mode, level, leaveOpen: false)
	{
	}

	public Stream9(Stream stream, Enum916 mode, bool leaveOpen)
		: this(stream, mode, Enum914.const_8, leaveOpen)
	{
	}

	public Stream9(Stream stream, Enum916 mode, Enum914 level, bool leaveOpen)
	{
		stream13_0 = new Stream13(stream, mode, level, Enum917.const_2, leaveOpen);
	}

	public override void Close()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	protected new virtual void Dispose(bool disposing)
	{
		if (!bool_0)
		{
			if (disposing && stream13_0 != null)
			{
				stream13_0.Close();
				int_1 = stream13_0.Crc32;
			}
			bool_0 = true;
		}
	}

	public override void Flush()
	{
		if (bool_0)
		{
			throw new ObjectDisposedException("GZipStream");
		}
		stream13_0.Flush();
	}

	public override int Read(byte[] buffer, int offset, int count)
	{
		if (bool_0)
		{
			throw new ObjectDisposedException("GZipStream");
		}
		int result = stream13_0.Read(buffer, offset, count);
		if (!bool_1)
		{
			bool_1 = true;
			FileName = stream13_0.string_0;
			Comment = stream13_0.string_1;
		}
		return result;
	}

	public override long Seek(long offset, SeekOrigin origin)
	{
		throw new NotImplementedException();
	}

	public override void SetLength(long value)
	{
		throw new NotImplementedException();
	}

	public override void Write(byte[] buffer, int offset, int count)
	{
		if (bool_0)
		{
			throw new ObjectDisposedException("GZipStream");
		}
		if (stream13_0.enum918_0 == Stream13.Enum918.const_2)
		{
			if (!stream13_0._wantCompress)
			{
				throw new InvalidOperationException();
			}
			int_0 = method_0();
		}
		stream13_0.Write(buffer, offset, count);
	}

	private int method_0()
	{
		byte[] array = ((Comment == null) ? null : encoding_0.GetBytes(Comment));
		byte[] array2 = ((FileName == null) ? null : encoding_0.GetBytes(FileName));
		int num = ((Comment != null) ? (array.Length + 1) : 0);
		int num2 = ((FileName != null) ? (array2.Length + 1) : 0);
		int num3 = 10 + num + num2;
		byte[] array3 = new byte[num3];
		int num4 = 0;
		num4 = 1;
		array3[0] = 31;
		num4 = 2;
		array3[1] = 139;
		num4 = 3;
		array3[2] = 8;
		byte b = 0;
		if (Comment != null)
		{
			b = (byte)(b ^ 0x10u);
		}
		if (FileName != null)
		{
			b = (byte)(b ^ 8u);
		}
		array3[num4++] = b;
		if (dateTime_0 == DateTime.MinValue)
		{
			dateTime_0 = DateTime.Now;
		}
		int value = (int)(dateTime_0 - dateTime_1).TotalSeconds;
		Array.Copy(BitConverter.GetBytes(value), 0, array3, num4, 4);
		num4 += 4;
		array3[num4++] = 0;
		array3[num4++] = byte.MaxValue;
		if (num2 != 0)
		{
			Array.Copy(array2, 0, array3, num4, num2 - 1);
			num4 += num2 - 1;
			array3[num4++] = 0;
		}
		if (num != 0)
		{
			Array.Copy(array, 0, array3, num4, num - 1);
			num4 += num - 1;
			array3[num4++] = 0;
		}
		stream13_0.stream_0.Write(array3, 0, array3.Length);
		return array3.Length;
	}

	public static byte[] smethod_0(string s)
	{
		byte[] bytes = Encoding.UTF8.GetBytes(s);
		return smethod_1(bytes);
	}

	public static byte[] smethod_1(byte[] b)
	{
		using MemoryStream memoryStream = new MemoryStream();
		Stream stream = new Stream9(memoryStream, Enum916.const_0, Enum914.const_12);
		using (stream)
		{
			stream.Write(b, 0, b.Length);
		}
		return memoryStream.ToArray();
	}

	public static string smethod_2(byte[] compressed)
	{
		byte[] bytes = smethod_3(compressed);
		return Encoding.UTF8.GetString(bytes);
	}

	public static byte[] smethod_3(byte[] compressed)
	{
		byte[] array = new byte[1024];
		using MemoryStream memoryStream = new MemoryStream();
		using MemoryStream stream = new MemoryStream(compressed);
		Stream stream2 = new Stream9(stream, Enum916.const_1);
		using (stream2)
		{
			int count;
			while ((count = stream2.Read(array, 0, array.Length)) != 0)
			{
				memoryStream.Write(array, 0, count);
			}
		}
		return memoryStream.ToArray();
	}

	void IDisposable.Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}
}
