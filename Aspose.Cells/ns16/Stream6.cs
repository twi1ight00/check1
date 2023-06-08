using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;

namespace ns16;

internal class Stream6 : Stream
{
	private int int_0;

	private Enum43 enum43_0;

	private Enum42 enum42_0;

	private Enum29 enum29_0;

	private Enum24 enum24_0;

	private Enum28 enum28_0;

	internal string string_0;

	private string string_1;

	private Stream stream_0;

	private Class744 class744_0;

	internal Enum32 enum32_0;

	private Dictionary<string, Class744> dictionary_0;

	private int int_1;

	private Enum33 enum33_0;

	private Encoding encoding_0 = Encoding.GetEncoding("IBM437");

	private bool bool_0;

	private bool bool_1;

	private bool bool_2;

	private bool bool_3;

	private bool bool_4;

	private Stream3 stream3_0;

	private Stream stream_1;

	private Stream stream_2;

	private Stream1 stream1_0;

	private bool bool_5;

	private string string_2;

	internal Stream10 stream10_0;

	private long long_0;

	private int int_2 = 16;

	public override bool CanRead => false;

	public override bool CanSeek => false;

	public override bool CanWrite => true;

	public override long Length
	{
		get
		{
			throw new NotSupportedException();
		}
	}

	public override long Position
	{
		get
		{
			return stream_0.Position;
		}
		set
		{
			throw new NotSupportedException();
		}
	}

	public string Comment => string_1;

	public Stream6(Stream stream_3)
		: this(stream_3, bool_6: false)
	{
	}

	public Stream6(Stream stream_3, bool bool_6)
	{
		method_0(stream_3, bool_6, null);
	}

	private void method_0(Stream stream_3, bool bool_6, string string_3)
	{
		stream_0 = (stream_3.CanRead ? stream_3 : new Stream3(stream_3));
		method_6(Enum42.const_8);
		method_8(Enum29.const_1);
		enum24_0 = Enum24.const_0;
		dictionary_0 = new Dictionary<string, Class744>(StringComparer.Ordinal);
		enum32_0 = Enum32.const_0;
		bool_0 = bool_6;
		method_4(Enum43.const_0);
		string_2 = string_3 ?? "(stream)";
		method_13(-1L);
	}

	public override string ToString()
	{
		return $"ZipOutputStream::{string_2}(leaveOpen({bool_0})))";
	}

	[SpecialName]
	public Enum24 method_1()
	{
		return enum24_0;
	}

	[SpecialName]
	public int method_2()
	{
		return int_0;
	}

	[SpecialName]
	public Enum43 method_3()
	{
		return enum43_0;
	}

	[SpecialName]
	public void method_4(Enum43 enum43_1)
	{
		enum43_0 = enum43_1;
	}

	[SpecialName]
	public Enum42 method_5()
	{
		return enum42_0;
	}

	[SpecialName]
	public void method_6(Enum42 enum42_1)
	{
		enum42_0 = enum42_1;
	}

	[SpecialName]
	public Enum29 method_7()
	{
		return enum29_0;
	}

	[SpecialName]
	public void method_8(Enum29 enum29_1)
	{
		enum29_0 = enum29_1;
	}

	[SpecialName]
	public Enum32 method_9()
	{
		return enum32_0;
	}

	[SpecialName]
	public void method_10(Enum32 enum32_1)
	{
		if (bool_1)
		{
			bool_2 = true;
			throw new InvalidOperationException("The stream has been closed.");
		}
		enum32_0 = enum32_1;
	}

	[SpecialName]
	public Encoding method_11()
	{
		return encoding_0;
	}

	[SpecialName]
	public Enum33 method_12()
	{
		return enum33_0;
	}

	[SpecialName]
	public static Encoding smethod_0()
	{
		return Encoding.GetEncoding("IBM437");
	}

	[SpecialName]
	public void method_13(long long_1)
	{
		if (long_1 != 0 && long_1 != -1 && long_1 < 65536)
		{
			throw new ArgumentOutOfRangeException("value must be greater than 64k, or 0, or -1");
		}
		long_0 = long_1;
	}

	[SpecialName]
	public long method_14()
	{
		return long_0;
	}

	[SpecialName]
	public int method_15()
	{
		return int_2;
	}

	private void method_16(Class744 class744_1)
	{
		if (dictionary_0.ContainsKey(class744_1.FileName))
		{
			bool_2 = true;
			throw new ArgumentException($"The entry '{class744_1.FileName}' already exists in the zip archive.");
		}
	}

	[SpecialName]
	internal Stream method_17()
	{
		return stream_0;
	}

	public override void Write(byte[] buffer, int offset, int count)
	{
		if (bool_1)
		{
			bool_2 = true;
			throw new InvalidOperationException("The stream has been closed.");
		}
		if (buffer == null)
		{
			bool_2 = true;
			throw new ArgumentNullException("buffer");
		}
		if (class744_0 == null)
		{
			bool_2 = true;
			throw new InvalidOperationException("You must call PutNextEntry() before calling Write().");
		}
		if (class744_0.method_18())
		{
			bool_2 = true;
			throw new InvalidOperationException("You cannot Write() data for an entry that is a directory.");
		}
		if (bool_5)
		{
			method_19(bool_6: false);
		}
		if (count != 0)
		{
			stream1_0.Write(buffer, offset, count);
		}
	}

	public Class744 method_18(string string_3)
	{
		if (string.IsNullOrEmpty(string_3))
		{
			throw new ArgumentNullException("entryName");
		}
		if (bool_1)
		{
			bool_2 = true;
			throw new InvalidOperationException("The stream has been closed.");
		}
		method_20();
		class744_0 = Class744.smethod_4(string_3);
		class744_0.class751_0 = new Class751(this);
		if (!stream_0.CanSeek)
		{
			class744_0.short_6 |= 8;
		}
		class744_0.method_6(DateTime.Now, DateTime.Now, DateTime.Now);
		class744_0.method_15(method_5());
		class744_0.method_13(method_7());
		class744_0.Password = string_0;
		class744_0.method_21(method_1());
		class744_0.method_30(method_11());
		class744_0.method_32(method_12());
		if (string_3.EndsWith("/"))
		{
			class744_0.method_33();
		}
		class744_0.method_7((enum28_0 & Enum28.flag_2) != 0);
		class744_0.method_8((enum28_0 & Enum28.flag_3) != 0);
		method_16(class744_0);
		bool_5 = true;
		return class744_0;
	}

	private void method_19(bool bool_6)
	{
		dictionary_0.Add(class744_0.FileName, class744_0);
		int_1++;
		if (int_1 > 65534 && enum32_0 == Enum32.const_0)
		{
			bool_2 = true;
			throw new InvalidOperationException("Too many entries. Consider setting ZipOutputStream.EnableZip64.");
		}
		class744_0.method_74(stream_0, bool_6 ? 99 : 0);
		class744_0.method_88();
		if (!class744_0.method_18())
		{
			class744_0.method_90(stream_0);
			class744_0.method_84(stream_0, (!bool_6) ? (-1) : 0, out stream3_0, out stream_1, out stream_2, out stream1_0);
		}
		bool_5 = false;
	}

	private void method_20()
	{
		if (class744_0 != null)
		{
			if (bool_5)
			{
				method_19(bool_6: true);
			}
			class744_0.method_81(stream_0, stream3_0, stream_1, stream_2, stream1_0);
			class744_0.method_82(stream_0);
			if (class744_0.method_11().HasValue)
			{
				bool_3 |= class744_0.method_11().Value;
			}
			stream3_0 = null;
			stream_1 = (stream_2 = null);
			stream1_0 = null;
		}
	}

	protected override void Dispose(bool disposing)
	{
		if (bool_1)
		{
			return;
		}
		if (disposing && !bool_2)
		{
			method_20();
			bool_4 = Class750.smethod_0(stream_0, dictionary_0.Values, 1u, enum32_0, Comment, new Class751(this));
			Stream stream = null;
			if (stream_0 is Stream3 stream2)
			{
				stream = stream2.method_0();
				stream2.Dispose();
			}
			else
			{
				stream = stream_0;
			}
			if (!bool_0)
			{
				stream.Dispose();
			}
			stream_0 = null;
		}
		bool_1 = true;
	}

	private void method_21()
	{
		if (!bool_1)
		{
			if (!bool_2)
			{
				method_20();
				bool_4 = Class750.smethod_0(stream_0, dictionary_0.Values, 1u, enum32_0, Comment, new Class751(this));
			}
			bool_1 = true;
		}
	}

	public void method_22()
	{
		method_21();
	}

	public override void Flush()
	{
	}

	public void method_23()
	{
	}

	public override int Read(byte[] buffer, int offset, int count)
	{
		throw new NotSupportedException("Read");
	}

	public override long Seek(long offset, SeekOrigin origin)
	{
		throw new NotSupportedException("Seek");
	}

	public override void SetLength(long value)
	{
		throw new NotSupportedException();
	}
}
