using System;
using System.IO;
using System.Runtime.CompilerServices;

namespace ns16;

internal class Stream7 : Stream
{
	private Enum35 enum35_0;

	private bool bool_0;

	private string string_0;

	private string string_1;

	private string string_2;

	private string string_3;

	private uint uint_0;

	private uint uint_1;

	private int int_0;

	private Stream stream_0;

	private bool bool_1;

	public override bool CanRead
	{
		get
		{
			if (enum35_0 == Enum35.const_1 && stream_0 != null)
			{
				return stream_0.CanRead;
			}
			return false;
		}
	}

	public override bool CanSeek
	{
		get
		{
			if (stream_0 != null)
			{
				return stream_0.CanSeek;
			}
			return false;
		}
	}

	public override bool CanWrite
	{
		get
		{
			if (enum35_0 == Enum35.const_2 && stream_0 != null)
			{
				return stream_0.CanWrite;
			}
			return false;
		}
	}

	public override long Length => stream_0.Length;

	public override long Position
	{
		get
		{
			return stream_0.Position;
		}
		set
		{
			stream_0.Position = value;
		}
	}

	private Stream7()
	{
		bool_0 = false;
	}

	public static Stream7 smethod_0(string string_4, uint uint_2, uint uint_3)
	{
		Stream7 stream = new Stream7();
		stream.enum35_0 = Enum35.const_1;
		stream.method_3(uint_2);
		stream.uint_1 = uint_3;
		stream.string_0 = string_4;
		stream.method_8();
		return stream;
	}

	public static Stream7 smethod_1(string string_4, int int_1)
	{
		Stream7 stream = new Stream7();
		stream.enum35_0 = Enum35.const_2;
		stream.method_3(0u);
		stream.string_0 = string_4;
		stream.int_0 = int_1;
		stream.string_1 = Path.GetDirectoryName(string_4);
		if (stream.string_1 == "")
		{
			stream.string_1 = ".";
		}
		stream.method_9(0u);
		return stream;
	}

	public static Stream smethod_2(string string_4, uint uint_2)
	{
		if (uint_2 >= 99)
		{
			throw new ArgumentOutOfRangeException("diskNumber");
		}
		string path = $"{Path.Combine(Path.GetDirectoryName(string_4), Path.GetFileNameWithoutExtension(string_4))}.z{uint_2 + 1:D2}";
		return File.Open(path, FileMode.Open, FileAccess.ReadWrite, FileShare.None);
	}

	[SpecialName]
	public bool method_0()
	{
		return bool_1;
	}

	[SpecialName]
	public void method_1(bool bool_2)
	{
		bool_1 = bool_2;
	}

	[SpecialName]
	public uint method_2()
	{
		return uint_0;
	}

	[SpecialName]
	private void method_3(uint uint_2)
	{
		uint_0 = uint_2;
		string_2 = null;
	}

	[SpecialName]
	public string method_4()
	{
		if (string_2 == null)
		{
			string_2 = method_6(method_2());
		}
		return string_2;
	}

	[SpecialName]
	public string method_5()
	{
		return string_3;
	}

	private string method_6(uint uint_2)
	{
		if (uint_2 >= 99)
		{
			bool_0 = true;
			throw new OverflowException("The number of zip segments would exceed 99.");
		}
		return $"{Path.Combine(Path.GetDirectoryName(string_0), Path.GetFileNameWithoutExtension(string_0))}.z{uint_2 + 1:D2}";
	}

	public uint method_7(int int_1)
	{
		if (stream_0.Position + int_1 > int_0)
		{
			return method_2() + 1;
		}
		return method_2();
	}

	private void method_8()
	{
		if (stream_0 != null)
		{
			stream_0.Dispose();
		}
		if (method_2() + 1 == uint_1)
		{
			string_2 = string_0;
		}
		stream_0 = File.OpenRead(method_4());
	}

	public override int Read(byte[] buffer, int offset, int count)
	{
		if (enum35_0 != Enum35.const_1)
		{
			bool_0 = true;
			throw new InvalidOperationException("Stream Error: Cannot Read.");
		}
		int num = stream_0.Read(buffer, offset, count);
		int num2 = num;
		while (true)
		{
			if (num2 != count)
			{
				if (stream_0.Position == stream_0.Length)
				{
					if (method_2() + 1 == uint_1)
					{
						break;
					}
					method_3(method_2() + 1);
					method_8();
					offset += num2;
					count -= num2;
					num2 = stream_0.Read(buffer, offset, count);
					num += num2;
					continue;
				}
				bool_0 = true;
				throw new Exception1($"Read error in file {method_4()}");
			}
			return num;
		}
		return num;
	}

	private void method_9(uint uint_2)
	{
		if (stream_0 != null)
		{
			stream_0.Dispose();
			if (File.Exists(method_4()))
			{
				File.Delete(method_4());
			}
			File.Move(string_3, method_4());
		}
		if (uint_2 != 0)
		{
			method_3(method_2() + uint_2);
		}
		Class742.smethod_14(string_1, out stream_0, out string_3);
		if (method_2() == 0)
		{
			stream_0.Write(BitConverter.GetBytes(134695760), 0, 4);
		}
	}

	public override void Write(byte[] buffer, int offset, int count)
	{
		if (enum35_0 != Enum35.const_2)
		{
			bool_0 = true;
			throw new InvalidOperationException("Stream Error: Cannot Write.");
		}
		if (method_0())
		{
			if (stream_0.Position + count > int_0)
			{
				method_9(1u);
			}
		}
		else
		{
			while (stream_0.Position + count > int_0)
			{
				int num = int_0 - (int)stream_0.Position;
				stream_0.Write(buffer, offset, num);
				method_9(1u);
				count -= num;
				offset += num;
			}
		}
		stream_0.Write(buffer, offset, count);
	}

	public long method_10(uint uint_2, long long_0)
	{
		if (uint_2 >= 99)
		{
			throw new ArgumentOutOfRangeException("diskNumber");
		}
		if (enum35_0 != Enum35.const_2)
		{
			bool_0 = true;
			throw new Exception1("bad state.");
		}
		if (uint_2 == method_2())
		{
			return stream_0.Seek(long_0, SeekOrigin.Begin);
		}
		if (stream_0 != null)
		{
			stream_0.Dispose();
			if (File.Exists(string_3))
			{
				File.Delete(string_3);
			}
		}
		for (uint num = method_2() - 1; num > uint_2; num--)
		{
			string path = method_6(num);
			if (File.Exists(path))
			{
				File.Delete(path);
			}
		}
		method_3(uint_2);
		for (int i = 0; i < 3; i++)
		{
			try
			{
				string_3 = Class742.smethod_15();
				File.Move(method_4(), string_3);
			}
			catch (IOException)
			{
				if (i == 2)
				{
					throw;
				}
				continue;
			}
			break;
		}
		stream_0 = new FileStream(string_3, FileMode.Open);
		return stream_0.Seek(long_0, SeekOrigin.Begin);
	}

	public override void Flush()
	{
		stream_0.Flush();
	}

	public override long Seek(long offset, SeekOrigin origin)
	{
		return stream_0.Seek(offset, origin);
	}

	public override void SetLength(long value)
	{
		if (enum35_0 != Enum35.const_2)
		{
			bool_0 = true;
			throw new InvalidOperationException();
		}
		stream_0.SetLength(value);
	}

	protected override void Dispose(bool disposing)
	{
		try
		{
			if (stream_0 != null)
			{
				stream_0.Dispose();
				if (enum35_0 != Enum35.const_2)
				{
				}
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}
}
