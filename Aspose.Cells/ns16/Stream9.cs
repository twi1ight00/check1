using System;
using System.IO;
using System.Text;

namespace ns16;

internal class Stream9 : Stream
{
	public DateTime? nullable_0;

	private int int_0;

	internal Stream11 stream11_0;

	private bool bool_0;

	private bool bool_1;

	private string string_0;

	private string string_1;

	private int int_1;

	internal static readonly DateTime dateTime_0 = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

	internal static readonly Encoding encoding_0 = Encoding.GetEncoding("iso-8859-1");

	public override bool CanRead
	{
		get
		{
			if (bool_0)
			{
				throw new ObjectDisposedException("GZipStream");
			}
			return stream11_0.stream_0.CanRead;
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
			return stream11_0.stream_0.CanWrite;
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
			if (stream11_0.enum46_0 == Stream11.Enum46.const_0)
			{
				return stream11_0.class765_0.long_1 + int_0;
			}
			if (stream11_0.enum46_0 == Stream11.Enum46.const_1)
			{
				return stream11_0.class765_0.long_0 + stream11_0.int_1;
			}
			return 0L;
		}
		set
		{
			throw new NotImplementedException();
		}
	}

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
					throw new Exception("Illegal filename");
				}
				if (string_0.IndexOf("\\") != -1)
				{
					string_0 = Path.GetFileName(string_0);
				}
			}
		}
	}

	protected override void Dispose(bool disposing)
	{
		try
		{
			if (!bool_0)
			{
				if (disposing && stream11_0 != null)
				{
					stream11_0.Close();
					int_1 = stream11_0.method_0();
				}
				bool_0 = true;
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	public override void Flush()
	{
		if (bool_0)
		{
			throw new ObjectDisposedException("GZipStream");
		}
		stream11_0.Flush();
	}

	public override int Read(byte[] buffer, int offset, int count)
	{
		if (bool_0)
		{
			throw new ObjectDisposedException("GZipStream");
		}
		int result = stream11_0.Read(buffer, offset, count);
		if (!bool_1)
		{
			bool_1 = true;
			FileName = stream11_0.string_0;
			Comment = stream11_0.string_1;
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
		if (stream11_0.enum46_0 == Stream11.Enum46.const_2)
		{
			if (!stream11_0.method_1())
			{
				throw new InvalidOperationException();
			}
			int_0 = method_0();
		}
		stream11_0.Write(buffer, offset, count);
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
		num4 = 0 + 1;
		array3[0] = 31;
		num4 = 1 + 1;
		array3[1] = 139;
		num4 = 2 + 1;
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
		if (!nullable_0.HasValue)
		{
			nullable_0 = DateTime.Now;
		}
		int value = (int)(nullable_0.Value - dateTime_0).TotalSeconds;
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
		stream11_0.stream_0.Write(array3, 0, array3.Length);
		return array3.Length;
	}
}
