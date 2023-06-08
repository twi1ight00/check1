using System;
using System.IO;
using System.Runtime.CompilerServices;

namespace ns16;

internal class Stream5 : Stream
{
	private int int_0;

	private Stream stream_0;

	private Class744 class744_0;

	private bool bool_0;

	private Stream1 stream1_0;

	private long long_0;

	internal string string_0;

	private long long_1;

	private string string_1;

	private bool bool_1;

	private bool bool_2;

	private bool bool_3;

	private bool bool_4;

	public override bool CanRead => true;

	public override bool CanSeek => stream_0.CanSeek;

	public override bool CanWrite => false;

	public override long Length => stream_0.Length;

	public override long Position
	{
		get
		{
			return stream_0.Position;
		}
		set
		{
			Seek(value, SeekOrigin.Begin);
		}
	}

	public override string ToString()
	{
		return $"ZipInputStream::{string_1}(leaveOpen({bool_1})))";
	}

	[SpecialName]
	public int method_0()
	{
		return int_0;
	}

	private void method_1()
	{
		stream1_0 = class744_0.method_40(string_0);
		long_0 = stream1_0.Length;
		bool_0 = false;
	}

	[SpecialName]
	internal Stream method_2()
	{
		return stream_0;
	}

	public override int Read(byte[] buffer, int offset, int count)
	{
		if (bool_2)
		{
			bool_4 = true;
			throw new InvalidOperationException("The stream has been closed.");
		}
		if (bool_0)
		{
			method_1();
		}
		if (long_0 == 0)
		{
			return 0;
		}
		int count2 = (int)((long_0 > count) ? count : long_0);
		int num = stream1_0.Read(buffer, offset, count2);
		long_0 -= num;
		if (long_0 == 0)
		{
			stream1_0.method_1();
			stream_0.Seek(long_1, SeekOrigin.Begin);
		}
		return num;
	}

	protected override void Dispose(bool disposing)
	{
		if (bool_2)
		{
			return;
		}
		if (disposing)
		{
			if (bool_4)
			{
				return;
			}
			if (!bool_1)
			{
				stream_0.Dispose();
			}
		}
		bool_2 = true;
	}

	public override void Flush()
	{
		throw new NotSupportedException("Flush");
	}

	public override void Write(byte[] buffer, int offset, int count)
	{
		throw new NotSupportedException("Write");
	}

	public override long Seek(long offset, SeekOrigin origin)
	{
		bool_3 = true;
		return stream_0.Seek(offset, origin);
	}

	public override void SetLength(long value)
	{
		throw new NotSupportedException();
	}
}
