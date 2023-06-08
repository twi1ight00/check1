using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;

namespace ns16;

[ComVisible(true)]
[ClassInterface(ClassInterfaceType.AutoDispatch)]
[Guid("ebc25cf6-9120-4283-b972-0e5520d00004")]
internal class Class744
{
	private class Class745
	{
		private static Regex regex_0 = new Regex(" \\(copy (\\d+)\\)$");

		private static int int_0 = 0;

		internal static string smethod_0(string string_0)
		{
			int_0++;
			if (int_0 > 25)
			{
				throw new OverflowException("overflow while creating filename");
			}
			int num = 1;
			int num2 = string_0.LastIndexOf(".");
			if (num2 == -1)
			{
				Match match = regex_0.Match(string_0);
				if (match.Success)
				{
					num = int.Parse(match.Groups[1].Value) + 1;
					string text = $" (copy {num})";
					string_0 = string_0.Substring(0, match.Index) + text;
				}
				else
				{
					string text2 = $" (copy {num})";
					string_0 += text2;
				}
			}
			else
			{
				Match match2 = regex_0.Match(string_0.Substring(0, num2));
				if (match2.Success)
				{
					num = int.Parse(match2.Groups[1].Value) + 1;
					string text3 = $" (copy {num})";
					string_0 = string_0.Substring(0, match2.Index) + text3 + string_0.Substring(num2);
				}
				else
				{
					string text4 = $" (copy {num})";
					string_0 = string_0.Substring(0, num2) + text4 + string_0.Substring(num2);
				}
			}
			return string_0;
		}
	}

	private short short_0;

	private short short_1;

	private int int_0;

	private short short_2;

	private short short_3;

	private short short_4;

	private Enum26 enum26_0;

	private Enum31 enum31_0;

	private Delegate3 delegate3_0;

	private Encoding encoding_0;

	private Enum33 enum33_0;

	private Class743 class743_0;

	private Class743 class743_1;

	internal DateTime dateTime_0;

	private DateTime dateTime_1;

	private DateTime dateTime_2;

	private DateTime dateTime_3;

	private bool bool_0;

	private bool bool_1 = true;

	private bool bool_2;

	private bool bool_3 = true;

	internal string string_0;

	private string string_1;

	internal short short_5;

	internal short short_6;

	internal short short_7;

	private short short_8;

	private Enum42 enum42_0;

	internal string string_2;

	private bool bool_4;

	private byte[] byte_0;

	internal long long_0;

	internal long long_1;

	internal long long_2;

	internal int int_1;

	private bool bool_5;

	internal int int_2;

	internal byte[] byte_1;

	private bool bool_6;

	private bool bool_7;

	private bool bool_8;

	private bool bool_9;

	private uint uint_0;

	private static Encoding encoding_1 = Encoding.GetEncoding("IBM437");

	private Encoding encoding_2;

	internal Class751 class751_0;

	private long long_3 = -1L;

	private byte[] byte_2;

	internal long long_4;

	private long long_5;

	private long long_6;

	private int int_3;

	private int int_4;

	internal bool bool_10;

	private uint uint_1;

	internal string string_3;

	internal Enum30 enum30_0;

	internal Enum24 enum24_0;

	internal Enum24 enum24_1;

	internal byte[] byte_3;

	internal Stream stream_0;

	private Stream stream_1;

	private long? nullable_0;

	private bool bool_11;

	private bool bool_12;

	private bool? nullable_1;

	private bool? nullable_2;

	private bool bool_13;

	private Enum28 enum28_0;

	private static DateTime dateTime_4 = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

	private static DateTime dateTime_5 = DateTime.FromFileTimeUtc(0L);

	private static DateTime dateTime_6 = new DateTime(1, 1, 1, 0, 0, 0, DateTimeKind.Utc);

	private Delegate0 delegate0_0;

	private Delegate1 delegate1_0;

	private Delegate2 delegate2_0;

	private Stream stream_2;

	private int int_5;

	private object object_0 = new object();

	public long Size => method_17();

	public string FileName => string_1;

	public string Name => string_1;

	public string Comment => string_2;

	public string Password
	{
		set
		{
			string_3 = value;
			if (string_3 == null)
			{
				enum24_0 = Enum24.const_0;
				return;
			}
			if (enum30_0 == Enum30.const_3 && !bool_8)
			{
				bool_7 = true;
			}
			if (method_20() == Enum24.const_0)
			{
				enum24_0 = Enum24.const_1;
			}
		}
	}

	[SpecialName]
	internal bool method_0()
	{
		if (short_1 == 0)
		{
			return (int_0 & 0x10) == 16;
		}
		return false;
	}

	internal void method_1()
	{
		long_3 = -1L;
		int_3 = 0;
	}

	internal static Class744 smethod_0(Class746 class746_0, Dictionary<string, object> dictionary_0)
	{
		Stream stream = class746_0.method_46();
		Encoding encoding = ((class746_0.method_21() == Enum33.const_3) ? class746_0.method_19() : Class746.smethod_0());
		int num = Class742.smethod_6(stream);
		if (smethod_1(num))
		{
			stream.Seek(-4L, SeekOrigin.Current);
			if ((long)num != 101010256 && (long)num != 101075792 && num != 67324752)
			{
				throw new Exception3($"  Bad signature (0x{num:X8}) at position 0x{stream.Position:X8}");
			}
			return null;
		}
		int num2 = 46;
		byte[] array = new byte[42];
		int num3 = stream.Read(array, 0, array.Length);
		if (num3 != array.Length)
		{
			return null;
		}
		Class744 @class = new Class744();
		@class.method_30(encoding);
		@class.enum30_0 = Enum30.const_3;
		@class.class751_0 = new Class751(class746_0);
		byte[] array2 = array;
		_ = 0 + 1;
		byte num4 = array2[0];
		byte[] array3 = array;
		_ = 1 + 1;
		@class.short_0 = (short)(num4 + array3[1] * 256);
		byte[] array4 = array;
		_ = 2 + 1;
		byte num5 = array4[2];
		byte[] array5 = array;
		_ = 3 + 1;
		@class.short_5 = (short)(num5 + array5[3] * 256);
		byte[] array6 = array;
		_ = 4 + 1;
		byte num6 = array6[4];
		byte[] array7 = array;
		_ = 5 + 1;
		@class.short_6 = (short)(num6 + array7[5] * 256);
		byte[] array8 = array;
		_ = 6 + 1;
		byte num7 = array8[6];
		byte[] array9 = array;
		_ = 7 + 1;
		@class.short_7 = (short)(num7 + array9[7] * 256);
		byte[] array10 = array;
		_ = 8 + 1;
		byte num8 = array10[8];
		byte[] array11 = array;
		_ = 9 + 1;
		int num9 = num8 + array11[9] * 256;
		byte[] array12 = array;
		_ = 10 + 1;
		int num10 = num9 + array12[10] * 256 * 256;
		byte[] array13 = array;
		_ = 11 + 1;
		@class.int_1 = num10 + array13[11] * 256 * 256 * 256;
		@class.dateTime_0 = Class742.smethod_12(@class.int_1);
		@class.enum28_0 |= Enum28.flag_1;
		byte[] array14 = array;
		_ = 12 + 1;
		byte num11 = array14[12];
		byte[] array15 = array;
		_ = 13 + 1;
		int num12 = num11 + array15[13] * 256;
		byte[] array16 = array;
		_ = 14 + 1;
		int num13 = num12 + array16[14] * 256 * 256;
		byte[] array17 = array;
		_ = 15 + 1;
		@class.int_2 = num13 + array17[15] * 256 * 256 * 256;
		byte[] array18 = array;
		_ = 16 + 1;
		byte num14 = array18[16];
		byte[] array19 = array;
		_ = 17 + 1;
		int num15 = num14 + array19[17] * 256;
		byte[] array20 = array;
		_ = 18 + 1;
		int num16 = num15 + array20[18] * 256 * 256;
		byte[] array21 = array;
		_ = 19 + 1;
		@class.long_0 = (uint)(num16 + array21[19] * 256 * 256 * 256);
		byte[] array22 = array;
		_ = 20 + 1;
		byte num17 = array22[20];
		byte[] array23 = array;
		_ = 21 + 1;
		int num18 = num17 + array23[21] * 256;
		byte[] array24 = array;
		_ = 22 + 1;
		int num19 = num18 + array24[22] * 256 * 256;
		byte[] array25 = array;
		_ = 23 + 1;
		@class.long_2 = (uint)(num19 + array25[23] * 256 * 256 * 256);
		@class.short_8 = @class.short_7;
		byte[] array26 = array;
		_ = 24 + 1;
		byte num20 = array26[24];
		byte[] array27 = array;
		_ = 25 + 1;
		@class.short_2 = (short)(num20 + array27[25] * 256);
		byte[] array28 = array;
		_ = 26 + 1;
		byte num21 = array28[26];
		byte[] array29 = array;
		_ = 27 + 1;
		@class.short_3 = (short)(num21 + array29[27] * 256);
		byte[] array30 = array;
		_ = 28 + 1;
		byte num22 = array30[28];
		byte[] array31 = array;
		_ = 29 + 1;
		@class.short_4 = (short)(num22 + array31[29] * 256);
		byte[] array32 = array;
		_ = 30 + 1;
		byte num23 = array32[30];
		byte[] array33 = array;
		_ = 31 + 1;
		@class.uint_0 = (uint)(num23 + array33[31] * 256);
		byte[] array34 = array;
		_ = 32 + 1;
		byte num24 = array34[32];
		byte[] array35 = array;
		_ = 33 + 1;
		@class.short_1 = (short)(num24 + array35[33] * 256);
		byte[] array36 = array;
		_ = 34 + 1;
		byte num25 = array36[34];
		byte[] array37 = array;
		_ = 35 + 1;
		int num26 = num25 + array37[35] * 256;
		byte[] array38 = array;
		_ = 36 + 1;
		int num27 = num26 + array38[36] * 256 * 256;
		byte[] array39 = array;
		_ = 37 + 1;
		@class.int_0 = num27 + array39[37] * 256 * 256 * 256;
		byte[] array40 = array;
		_ = 38 + 1;
		byte num28 = array40[38];
		byte[] array41 = array;
		_ = 39 + 1;
		int num29 = num28 + array41[39] * 256;
		byte[] array42 = array;
		_ = 40 + 1;
		int num30 = num29 + array42[40] * 256 * 256;
		byte[] array43 = array;
		_ = 41 + 1;
		@class.long_4 = (uint)(num30 + array43[41] * 256 * 256 * 256);
		@class.method_34((@class.short_1 & 1) == 1);
		array = new byte[@class.short_2];
		num3 = stream.Read(array, 0, array.Length);
		num2 += num3;
		if ((@class.short_6 & 0x800) == 2048)
		{
			@class.string_1 = Class742.smethod_4(array);
		}
		else
		{
			@class.string_1 = Class742.smethod_5(array, encoding);
		}
		while (dictionary_0.ContainsKey(@class.string_1))
		{
			@class.string_1 = Class745.smethod_0(@class.string_1);
			@class.bool_6 = true;
		}
		if (@class.method_0())
		{
			@class.method_33();
		}
		else if (@class.string_1.EndsWith("/"))
		{
			@class.method_33();
		}
		@class.long_1 = @class.long_0;
		if ((@class.short_6 & 1) == 1)
		{
			@class.enum24_0 = Enum24.const_1;
			@class.enum24_1 = Enum24.const_1;
			@class.bool_8 = true;
		}
		if (@class.short_3 > 0)
		{
			@class.bool_10 = @class.long_0 == uint.MaxValue || @class.long_2 == uint.MaxValue || @class.long_4 == uint.MaxValue;
			num2 += @class.method_60(stream, @class.short_3);
			@class.long_1 = @class.long_0;
		}
		if (@class.enum24_0 == Enum24.const_1)
		{
			@class.long_1 -= 12L;
		}
		if ((@class.short_6 & 8) == 8)
		{
			if (@class.bool_10)
			{
				@class.int_4 += 24;
			}
			else
			{
				@class.int_4 += 16;
			}
		}
		@class.method_30(((@class.short_6 & 0x800) == 2048) ? Encoding.UTF8 : encoding);
		@class.method_32(Enum33.const_3);
		if (@class.short_4 > 0)
		{
			array = new byte[@class.short_4];
			num3 = stream.Read(array, 0, array.Length);
			num2 += num3;
			if ((@class.short_6 & 0x800) == 2048)
			{
				@class.string_2 = Class742.smethod_4(array);
			}
			else
			{
				@class.string_2 = Class742.smethod_5(array, encoding);
			}
		}
		return @class;
	}

	internal static bool smethod_1(int int_6)
	{
		return int_6 != 33639248;
	}

	public Class744()
	{
		short_7 = 8;
		enum42_0 = Enum42.const_8;
		enum24_0 = Enum24.const_0;
		enum30_0 = Enum30.const_0;
		method_30(Encoding.GetEncoding("IBM437"));
		method_32(Enum33.const_0);
	}

	[SpecialName]
	public DateTime method_2()
	{
		return dateTime_0.ToLocalTime();
	}

	[SpecialName]
	private int method_3()
	{
		return class751_0.method_3();
	}

	[SpecialName]
	public void method_4(DateTime dateTime_7)
	{
		method_6(dateTime_3, dateTime_2, dateTime_7);
	}

	[SpecialName]
	public void method_5(DateTime dateTime_7)
	{
		method_4(dateTime_7);
	}

	public void method_6(DateTime dateTime_7, DateTime dateTime_8, DateTime dateTime_9)
	{
		bool_0 = true;
		if (dateTime_7 == dateTime_6 && dateTime_7.Kind == dateTime_6.Kind)
		{
			dateTime_7 = dateTime_5;
		}
		if (dateTime_8 == dateTime_6 && dateTime_8.Kind == dateTime_6.Kind)
		{
			dateTime_8 = dateTime_5;
		}
		if (dateTime_9 == dateTime_6 && dateTime_9.Kind == dateTime_6.Kind)
		{
			dateTime_9 = dateTime_5;
		}
		dateTime_3 = dateTime_7.ToUniversalTime();
		dateTime_2 = dateTime_8.ToUniversalTime();
		dateTime_1 = dateTime_9.ToUniversalTime();
		dateTime_0 = dateTime_1;
		if (!bool_2 && !bool_1)
		{
			bool_1 = true;
		}
		bool_6 = true;
	}

	[SpecialName]
	public void method_7(bool bool_14)
	{
		bool_1 = bool_14;
		bool_6 = true;
	}

	[SpecialName]
	public void method_8(bool bool_14)
	{
		bool_2 = bool_14;
		bool_6 = true;
	}

	[SpecialName]
	internal string method_9()
	{
		return string_0;
	}

	[SpecialName]
	public short method_10()
	{
		return short_5;
	}

	[SpecialName]
	public bool? method_11()
	{
		return nullable_2;
	}

	[SpecialName]
	public Enum29 method_12()
	{
		return (Enum29)short_7;
	}

	[SpecialName]
	public void method_13(Enum29 enum29_0)
	{
		if (enum29_0 != (Enum29)short_7)
		{
			if (enum29_0 != 0 && enum29_0 != Enum29.const_1)
			{
				throw new InvalidOperationException("Unsupported compression method.");
			}
			short_7 = (short)enum29_0;
			if (short_7 == 0)
			{
				enum42_0 = Enum42.const_0;
			}
			else if (method_14() == Enum42.const_0)
			{
				enum42_0 = Enum42.const_8;
			}
			if (class751_0.method_0() != null)
			{
				class751_0.method_0().method_33();
			}
			bool_7 = true;
		}
	}

	[SpecialName]
	public Enum42 method_14()
	{
		return enum42_0;
	}

	[SpecialName]
	public void method_15(Enum42 enum42_1)
	{
		if ((short_7 != 8 && short_7 != 0) || (enum42_1 == Enum42.const_8 && short_7 == 8))
		{
			return;
		}
		enum42_0 = enum42_1;
		if (enum42_1 != 0 || short_7 != 0)
		{
			if (enum42_0 == Enum42.const_0)
			{
				short_7 = 0;
			}
			else
			{
				short_7 = 8;
			}
			if (class751_0.method_0() != null)
			{
				class751_0.method_0().method_33();
			}
			bool_7 = true;
		}
	}

	[SpecialName]
	public long method_16()
	{
		return long_0;
	}

	[SpecialName]
	public long method_17()
	{
		return long_2;
	}

	[SpecialName]
	public bool method_18()
	{
		return bool_4;
	}

	[SpecialName]
	public bool method_19()
	{
		return !bool_4;
	}

	[SpecialName]
	public Enum24 method_20()
	{
		return enum24_0;
	}

	[SpecialName]
	public void method_21(Enum24 enum24_2)
	{
		if (enum24_2 != enum24_0)
		{
			if (enum24_2 == Enum24.const_2)
			{
				throw new InvalidOperationException("You may not set Encryption to that value.");
			}
			enum24_0 = enum24_2;
			bool_7 = true;
			if (class751_0.method_0() != null)
			{
				class751_0.method_0().method_33();
			}
		}
	}

	[SpecialName]
	public Enum26 method_22()
	{
		return enum26_0;
	}

	[SpecialName]
	public void method_23(Enum26 enum26_1)
	{
		enum26_0 = enum26_1;
	}

	[SpecialName]
	public Enum31 method_24()
	{
		return enum31_0;
	}

	[SpecialName]
	public void method_25(Enum31 enum31_1)
	{
		enum31_0 = enum31_1;
	}

	[SpecialName]
	public bool method_26()
	{
		return !bool_9;
	}

	[SpecialName]
	public Delegate3 method_27()
	{
		return delegate3_0;
	}

	[SpecialName]
	public void method_28(Delegate3 delegate3_1)
	{
		delegate3_0 = delegate3_1;
	}

	[SpecialName]
	public Encoding method_29()
	{
		return encoding_0;
	}

	[SpecialName]
	public void method_30(Encoding encoding_3)
	{
		encoding_0 = encoding_3;
	}

	[SpecialName]
	public Enum33 method_31()
	{
		return enum33_0;
	}

	[SpecialName]
	public void method_32(Enum33 enum33_1)
	{
		enum33_0 = enum33_1;
	}

	internal static string smethod_2(string string_4, string string_5)
	{
		string text = null;
		text = ((string_5 == null) ? string_4 : ((!string.IsNullOrEmpty(string_5)) ? Path.Combine(string_5, Path.GetFileName(string_4)) : Path.GetFileName(string_4)));
		return Class742.smethod_1(text);
	}

	internal static Class744 smethod_3(string string_4, Stream stream_3)
	{
		return smethod_5(string_4, Enum30.const_2, stream_3, null);
	}

	internal static Class744 smethod_4(string string_4)
	{
		return smethod_5(string_4, Enum30.const_6, null, null);
	}

	private static Class744 smethod_5(string string_4, Enum30 enum30_1, object object_1, object object_2)
	{
		if (string.IsNullOrEmpty(string_4))
		{
			throw new Exception1("The entry name must be non-null and non-empty.");
		}
		Class744 @class = new Class744();
		@class.short_0 = 45;
		@class.enum30_0 = enum30_1;
		@class.dateTime_1 = (@class.dateTime_2 = (@class.dateTime_3 = DateTime.UtcNow));
		switch (enum30_1)
		{
		case Enum30.const_2:
			@class.stream_1 = object_1 as Stream;
			break;
		case Enum30.const_4:
			@class.delegate0_0 = object_1 as Delegate0;
			break;
		case Enum30.const_5:
			@class.delegate1_0 = object_1 as Delegate1;
			@class.delegate2_0 = object_2 as Delegate2;
			break;
		case Enum30.const_0:
			@class.enum30_0 = Enum30.const_1;
			break;
		default:
		{
			string text = object_1 as string;
			if (string.IsNullOrEmpty(text))
			{
				throw new Exception1("The filename must be non-null and non-empty.");
			}
			try
			{
				@class.dateTime_1 = File.GetLastWriteTime(text).ToUniversalTime();
				@class.dateTime_3 = File.GetCreationTime(text).ToUniversalTime();
				@class.dateTime_2 = File.GetLastAccessTime(text).ToUniversalTime();
				if (File.Exists(text) || Directory.Exists(text))
				{
					@class.int_0 = (int)File.GetAttributes(text);
				}
				@class.bool_0 = true;
				@class.string_0 = Path.GetFullPath(text);
			}
			catch (PathTooLongException exception_)
			{
				string text2 = $"The path is too long, filename={text}";
				throw new Exception1(text2, exception_);
			}
			break;
		}
		case Enum30.const_6:
			break;
		}
		@class.dateTime_0 = @class.dateTime_1;
		@class.string_1 = Class742.smethod_1(string_4);
		return @class;
	}

	internal void method_33()
	{
		bool_4 = true;
		if (!string_1.EndsWith("/"))
		{
			string_1 += "/";
		}
	}

	[SpecialName]
	public void method_34(bool bool_14)
	{
		bool_13 = bool_14;
	}

	public override string ToString()
	{
		return $"ZipEntry::{FileName}";
	}

	[SpecialName]
	internal Stream method_35()
	{
		if (stream_0 == null)
		{
			if (class751_0.method_0() != null)
			{
				Class746 @class = class751_0.method_0();
				@class.Reset(bool_18: false);
				stream_0 = @class.method_34(uint_0);
			}
			else
			{
				stream_0 = class751_0.method_1().method_17();
			}
		}
		return stream_0;
	}

	private void method_36()
	{
		long position = method_35().Position;
		try
		{
			method_35().Seek(long_4, SeekOrigin.Begin);
		}
		catch (IOException exception_)
		{
			string text = $"Exception seeking  entry({FileName}) offset(0x{long_4:X8}) len(0x{method_35().Length:X8})";
			throw new Exception4(text, exception_);
		}
		byte[] array = new byte[30];
		method_35().Read(array, 0, array.Length);
		short num = (short)(array[26] + array[27] * 256);
		short num2 = (short)(array[28] + array[29] * 256);
		method_35().Seek(num + num2, SeekOrigin.Current);
		int_3 = 30 + num2 + num + smethod_6(enum24_1);
		long_3 = long_4 + int_3;
		method_35().Seek(position, SeekOrigin.Begin);
	}

	internal static int smethod_6(Enum24 enum24_2)
	{
		return enum24_2 switch
		{
			Enum24.const_0 => 0, 
			Enum24.const_1 => 12, 
			_ => throw new Exception1("internal error"), 
		};
	}

	[SpecialName]
	internal long method_37()
	{
		if (long_3 == -1)
		{
			method_36();
		}
		return long_3;
	}

	[SpecialName]
	private int method_38()
	{
		if (int_3 == 0)
		{
			method_36();
		}
		return int_3;
	}

	public void method_39(Stream stream_3)
	{
		method_46(null, stream_3, null);
	}

	internal Stream1 method_40(string string_4)
	{
		method_56();
		method_55();
		method_57(string_4);
		if (enum30_0 != Enum30.const_3)
		{
			throw new Exception4("You must call ZipFile.Save before calling OpenReader");
		}
		long num = ((short_8 == 0) ? long_1 : method_17());
		Stream stream_ = method_35();
		method_35().Seek(method_37(), SeekOrigin.Begin);
		stream_2 = method_51(stream_);
		Stream stream = method_50(stream_2);
		return new Stream1(stream, num);
	}

	private void method_41(long long_7, long long_8)
	{
		if (class751_0.method_0() != null)
		{
			bool_11 = class751_0.method_0().method_59(this, long_7, long_8);
		}
	}

	private void method_42(string string_4)
	{
		if (class751_0.method_0() != null && !class751_0.method_0().bool_16)
		{
			bool_11 = class751_0.method_0().method_60(this, string_4, bool_18: true);
		}
	}

	private void method_43(string string_4)
	{
		if (class751_0.method_0() != null && !class751_0.method_0().bool_16)
		{
			class751_0.method_0().method_60(this, string_4, bool_18: false);
		}
	}

	private void method_44(string string_4)
	{
		if (class751_0.method_0() != null)
		{
			bool_11 = class751_0.method_0().method_61(this, string_4);
		}
	}

	private static void smethod_7(string string_4)
	{
		if ((File.GetAttributes(string_4) & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)
		{
			File.SetAttributes(string_4, FileAttributes.Normal);
		}
		File.Delete(string_4);
	}

	private void method_45(string string_4, object[] object_1)
	{
		if (class751_0.method_0() != null && class751_0.method_0().method_15())
		{
			class751_0.method_0().method_23().WriteLine(string_4, object_1);
		}
	}

	private void method_46(string string_4, Stream stream_3, string string_5)
	{
		if (class751_0 == null)
		{
			throw new Exception4("This entry is an orphan");
		}
		if (class751_0.method_0() == null)
		{
			throw new InvalidOperationException("Use Extract() only with ZipFile.");
		}
		class751_0.method_0().Reset(bool_18: false);
		if (enum30_0 != Enum30.const_3)
		{
			throw new Exception4("You must call ZipFile.Save before calling any Extract method");
		}
		method_42(string_4);
		bool_11 = false;
		string outFileName = null;
		Stream stream = null;
		bool flag = false;
		bool flag2 = false;
		try
		{
			method_56();
			method_55();
			if (method_58(string_4, stream_3, out outFileName))
			{
				method_45("extract dir {0}...", new object[1] { outFileName });
				method_43(string_4);
				return;
			}
			if (outFileName != null && File.Exists(outFileName))
			{
				flag = true;
				int num = method_47(string_4, outFileName);
				if (num == 2 || num == 1)
				{
					return;
				}
			}
			string text = string_5 ?? string_3 ?? class751_0.Password;
			if (enum24_1 != 0)
			{
				if (text == null)
				{
					throw new Exception2();
				}
				method_57(text);
			}
			if (outFileName != null)
			{
				method_45("extract file {0}...", new object[1] { outFileName });
				outFileName += ".tmp";
				string directoryName = Path.GetDirectoryName(outFileName);
				if (!Directory.Exists(directoryName))
				{
					Directory.CreateDirectory(directoryName);
				}
				else if (class751_0.method_0() != null)
				{
					flag2 = class751_0.method_0().bool_16;
				}
				stream = new FileStream(outFileName, FileMode.CreateNew);
			}
			else
			{
				method_45("extract entry {0} to stream...", new object[1] { FileName });
				stream = stream_3;
			}
			if (bool_11)
			{
				return;
			}
			method_49(stream);
			if (bool_11)
			{
				return;
			}
			if (outFileName != null)
			{
				stream.Close();
				stream = null;
				string text2 = outFileName;
				string text3 = null;
				outFileName = text2.Substring(0, text2.Length - 4);
				if (flag)
				{
					text3 = outFileName + ".PendingOverwrite";
					File.Move(outFileName, text3);
				}
				File.Move(text2, outFileName);
				method_52(outFileName, bool_14: true);
				if (text3 != null && File.Exists(text3))
				{
					smethod_7(text3);
				}
				if (flag2 && FileName.IndexOf('/') != -1)
				{
					string directoryName2 = Path.GetDirectoryName(FileName);
					if (class751_0.method_0()[directoryName2] == null)
					{
						method_52(Path.GetDirectoryName(outFileName), bool_14: false);
					}
				}
				if ((short_0 & 0xFF00) == 2560 || (short_0 & 0xFF00) == 0)
				{
					File.SetAttributes(outFileName, (FileAttributes)int_0);
				}
			}
			method_43(string_4);
		}
		catch (Exception)
		{
			bool_11 = true;
			throw;
		}
		finally
		{
			if (bool_11 && outFileName != null)
			{
				stream?.Close();
				if (File.Exists(outFileName) && !flag)
				{
					File.Delete(outFileName);
				}
			}
		}
	}

	private int method_47(string string_4, string string_5)
	{
		int num = 0;
		while (true)
		{
			switch (method_22())
			{
			case Enum26.const_3:
				if (num <= 0)
				{
					method_44(string_4);
					if (bool_11)
					{
						return 2;
					}
					break;
				}
				throw new Exception1($"The file {string_5} already exists.");
			default:
				throw new Exception1($"The file {string_5} already exists.");
			case Enum26.const_1:
				method_45("the file {0} exists; will overwrite it...", new object[1] { string_5 });
				return 0;
			case Enum26.const_2:
				method_45("the file {0} exists; not extracting entry...", new object[1] { FileName });
				method_43(string_4);
				return 1;
			}
			num++;
		}
	}

	private void method_48(int int_6)
	{
		if (int_6 == 0)
		{
			throw new Exception3($"bad read of entry {FileName} from compressed archive.");
		}
	}

	private int method_49(Stream stream_3)
	{
		int num = 0;
		Stream stream = method_35();
		try
		{
			stream.Seek(method_37(), SeekOrigin.Begin);
			byte[] array = new byte[method_3()];
			long num2 = ((short_8 != 0) ? method_17() : long_1);
			stream_2 = method_51(stream);
			Stream stream2 = method_50(stream_2);
			long num3 = 0L;
			using Stream1 stream3 = new Stream1(stream2);
			while (num2 > 0)
			{
				int count = (int)((num2 > array.Length) ? array.Length : num2);
				int num4 = stream3.Read(array, 0, count);
				method_48(num4);
				stream_3.Write(array, 0, num4);
				num2 -= num4;
				num3 += num4;
				method_41(num3, method_17());
				if (bool_11)
				{
					break;
				}
			}
			return stream3.method_1();
		}
		finally
		{
			if (stream is Stream7 stream4)
			{
				stream4.Dispose();
				stream_0 = null;
			}
		}
	}

	internal Stream method_50(Stream stream_3)
	{
		return short_8 switch
		{
			8 => new Stream8(stream_3, Enum44.const_1, bool_1: true), 
			0 => stream_3, 
			_ => null, 
		};
	}

	internal Stream method_51(Stream stream_3)
	{
		Stream stream = null;
		if (enum24_1 == Enum24.const_1)
		{
			return new Stream4(stream_3, class743_0, Enum27.const_1);
		}
		return stream_3;
	}

	internal void method_52(string string_4, bool bool_14)
	{
		try
		{
			if (bool_0)
			{
				if (bool_14)
				{
					if (File.Exists(string_4))
					{
						File.SetCreationTimeUtc(string_4, dateTime_3);
						File.SetLastAccessTimeUtc(string_4, dateTime_2);
						File.SetLastWriteTimeUtc(string_4, dateTime_1);
					}
				}
				else if (Directory.Exists(string_4))
				{
					Directory.SetCreationTimeUtc(string_4, dateTime_3);
					Directory.SetLastAccessTimeUtc(string_4, dateTime_2);
					Directory.SetLastWriteTimeUtc(string_4, dateTime_1);
				}
			}
			else
			{
				DateTime lastWriteTime = Class742.smethod_11(method_2());
				if (bool_14)
				{
					File.SetLastWriteTime(string_4, lastWriteTime);
				}
				else
				{
					Directory.SetLastWriteTime(string_4, lastWriteTime);
				}
			}
		}
		catch (IOException ex)
		{
			method_45("failed to set time on {0}: {1}", new object[2] { string_4, ex.Message });
		}
	}

	[SpecialName]
	private string method_53()
	{
		string empty = string.Empty;
		return uint_1 switch
		{
			26113u => "DES", 
			26114u => "RC2", 
			26115u => "3DES-168", 
			0u => "--", 
			26126u => "PKWare AES128", 
			26127u => "PKWare AES192", 
			26128u => "PKWare AES256", 
			26121u => "3DES-112", 
			26400u => "Blowfish", 
			26401u => "Twofish", 
			26370u => "RC2", 
			26625u => "RC4", 
			_ => $"Unknown (0x{uint_1:X4})", 
		};
	}

	[SpecialName]
	private string method_54()
	{
		string empty = string.Empty;
		return short_7 switch
		{
			8 => "DEFLATE", 
			9 => "Deflate64", 
			12 => "BZIP2", 
			14 => "LZMA", 
			0 => "Store", 
			1 => "Shrink", 
			98 => "PPMd", 
			19 => "LZ77", 
			_ => $"Unknown (0x{short_7:X4})", 
		};
	}

	internal void method_55()
	{
		if (method_20() != Enum24.const_1 && method_20() != 0)
		{
			if (uint_1 != 0)
			{
				throw new Exception1($"Cannot extract: Entry {FileName} is encrypted with an algorithm not supported by DotNetZip: {method_53()}");
			}
			throw new Exception1($"Cannot extract: Entry {FileName} uses an unsupported encryption algorithm ({(int)method_20():X2})");
		}
	}

	private void method_56()
	{
		if (short_8 != 0 && short_8 != 8)
		{
			throw new Exception1($"Entry {FileName} uses an unsupported compression method (0x{short_8:X2}, {method_54()})");
		}
	}

	private void method_57(string string_4)
	{
		if (enum24_1 != 0 && enum24_1 == Enum24.const_1)
		{
			if (string_4 == null)
			{
				throw new Exception1("Missing password.");
			}
			method_35().Seek(method_37() - 12, SeekOrigin.Begin);
			class743_0 = Class743.smethod_1(string_4, this);
		}
	}

	private bool method_58(string basedir, Stream outstream, out string outFileName)
	{
		if (basedir != null)
		{
			string text = FileName.Replace("\\", "/");
			if (text.IndexOf(':') == 1)
			{
				text = text.Substring(2);
			}
			if (text.StartsWith("/"))
			{
				text = text.Substring(1);
			}
			if (class751_0.method_0().method_10())
			{
				outFileName = Path.Combine(basedir, (text.IndexOf('/') != -1) ? Path.GetFileName(text) : text);
			}
			else
			{
				outFileName = Path.Combine(basedir, text);
			}
			outFileName = outFileName.Replace("/", "\\");
			if (!method_18() && !FileName.EndsWith("/"))
			{
				return false;
			}
			if (!Directory.Exists(outFileName))
			{
				Directory.CreateDirectory(outFileName);
				method_52(outFileName, bool_14: false);
			}
			else if (method_22() == Enum26.const_1)
			{
				method_52(outFileName, bool_14: false);
			}
			return true;
		}
		if (outstream != null)
		{
			outFileName = null;
			if (!method_18() && !FileName.EndsWith("/"))
			{
				return false;
			}
			return true;
		}
		throw new ArgumentNullException("outstream");
	}

	private void method_59()
	{
		int_5++;
		long position = method_35().Position;
		method_35().Seek(long_4, SeekOrigin.Begin);
		byte[] array = new byte[30];
		method_35().Read(array, 0, array.Length);
		_ = 26 + 1;
		byte num = array[26];
		_ = 27 + 1;
		short num2 = (short)(num + array[27] * 256);
		_ = 28 + 1;
		byte num3 = array[28];
		_ = 29 + 1;
		short short_ = (short)(num3 + array[29] * 256);
		method_35().Seek(num2, SeekOrigin.Current);
		method_60(method_35(), short_);
		method_35().Seek(position, SeekOrigin.Begin);
		int_5--;
	}

	private static bool smethod_8(Class744 class744_0, Encoding encoding_3)
	{
		int num = 0;
		class744_0.long_4 = class744_0.method_35().Position;
		int num2 = Class742.smethod_7(class744_0.method_35());
		num = 0 + 4;
		if (smethod_10(num2))
		{
			class744_0.method_35().Seek(-4L, SeekOrigin.Current);
			if (smethod_1(num2) && (long)num2 != 101010256)
			{
				throw new Exception3($"  Bad signature (0x{num2:X8}) at position  0x{class744_0.method_35().Position:X8}");
			}
			return false;
		}
		byte[] array = new byte[26];
		int num3 = class744_0.method_35().Read(array, 0, array.Length);
		if (num3 != array.Length)
		{
			return false;
		}
		num += num3;
		int num4 = 0;
		byte[] array2 = array;
		num4 = 0 + 1;
		byte num5 = array2[0];
		byte[] array3 = array;
		num4 = 1 + 1;
		class744_0.short_5 = (short)(num5 + array3[1] * 256);
		byte[] array4 = array;
		num4 = 2 + 1;
		byte num6 = array4[2];
		byte[] array5 = array;
		num4 = 3 + 1;
		class744_0.short_6 = (short)(num6 + array5[3] * 256);
		byte[] array6 = array;
		num4 = 4 + 1;
		byte num7 = array6[4];
		byte[] array7 = array;
		num4 = 5 + 1;
		class744_0.short_8 = (class744_0.short_7 = (short)(num7 + array7[5] * 256));
		byte[] array8 = array;
		num4 = 6 + 1;
		byte num8 = array8[6];
		byte[] array9 = array;
		num4 = 7 + 1;
		int num9 = num8 + array9[7] * 256;
		byte[] array10 = array;
		num4 = 8 + 1;
		int num10 = num9 + array10[8] * 256 * 256;
		byte[] array11 = array;
		num4 = 9 + 1;
		class744_0.int_1 = num10 + array11[9] * 256 * 256 * 256;
		class744_0.dateTime_0 = Class742.smethod_12(class744_0.int_1);
		class744_0.enum28_0 |= Enum28.flag_1;
		if ((class744_0.short_6 & 1) == 1)
		{
			class744_0.enum24_0 = Enum24.const_1;
			class744_0.enum24_1 = Enum24.const_1;
			class744_0.bool_8 = true;
		}
		class744_0.int_2 = array[num4++] + array[num4++] * 256 + array[num4++] * 256 * 256 + array[num4++] * 256 * 256 * 256;
		class744_0.long_0 = (uint)(array[num4++] + array[num4++] * 256 + array[num4++] * 256 * 256 + array[num4++] * 256 * 256 * 256);
		class744_0.long_2 = (uint)(array[num4++] + array[num4++] * 256 + array[num4++] * 256 * 256 + array[num4++] * 256 * 256 * 256);
		if ((int)class744_0.long_0 == -1 || (int)class744_0.long_2 == -1)
		{
			class744_0.bool_10 = true;
		}
		short num11 = (short)(array[num4++] + array[num4++] * 256);
		short short_ = (short)(array[num4++] + array[num4++] * 256);
		array = new byte[num11];
		num3 = class744_0.method_35().Read(array, 0, array.Length);
		num += num3;
		if ((class744_0.short_6 & 0x800) == 2048)
		{
			class744_0.method_30(Encoding.UTF8);
			class744_0.method_32(Enum33.const_3);
		}
		class744_0.string_1 = class744_0.method_29().GetString(array, 0, array.Length);
		if (class744_0.string_1.EndsWith("/"))
		{
			class744_0.method_33();
		}
		num += class744_0.method_60(class744_0.method_35(), short_);
		class744_0.int_4 = 0;
		if (!class744_0.string_1.EndsWith("/") && (class744_0.short_6 & 8) == 8)
		{
			long position = class744_0.method_35().Position;
			bool flag = true;
			long num12 = 0L;
			int num13 = 0;
			while (flag)
			{
				num13++;
				if (class744_0.class751_0.method_0() != null)
				{
					class744_0.class751_0.method_0().method_56(class744_0);
				}
				long num14 = Class742.smethod_10(class744_0.method_35(), 134695760);
				if (num14 != -1)
				{
					num12 += num14;
					if (class744_0.bool_10)
					{
						array = new byte[20];
						num3 = class744_0.method_35().Read(array, 0, array.Length);
						if (num3 != 20)
						{
							return false;
						}
						num4 = 0;
						byte[] array12 = array;
						num4 = 0 + 1;
						byte num15 = array12[0];
						byte[] array13 = array;
						num4 = 1 + 1;
						int num16 = num15 + array13[1] * 256;
						byte[] array14 = array;
						num4 = 2 + 1;
						int num17 = num16 + array14[2] * 256 * 256;
						byte[] array15 = array;
						num4 = 3 + 1;
						class744_0.int_2 = num17 + array15[3] * 256 * 256 * 256;
						class744_0.long_0 = BitConverter.ToInt64(array, 4);
						num4 = 4 + 8;
						class744_0.long_2 = BitConverter.ToInt64(array, 12);
						num4 = 12 + 8;
						class744_0.int_4 += 24;
					}
					else
					{
						array = new byte[12];
						num3 = class744_0.method_35().Read(array, 0, array.Length);
						if (num3 != 12)
						{
							return false;
						}
						num4 = 0;
						byte[] array16 = array;
						num4 = 0 + 1;
						byte num18 = array16[0];
						byte[] array17 = array;
						num4 = 1 + 1;
						int num19 = num18 + array17[1] * 256;
						byte[] array18 = array;
						num4 = 2 + 1;
						int num20 = num19 + array18[2] * 256 * 256;
						byte[] array19 = array;
						num4 = 3 + 1;
						class744_0.int_2 = num20 + array19[3] * 256 * 256 * 256;
						byte[] array20 = array;
						num4 = 4 + 1;
						byte num21 = array20[4];
						byte[] array21 = array;
						num4 = 5 + 1;
						int num22 = num21 + array21[5] * 256;
						byte[] array22 = array;
						num4 = 6 + 1;
						int num23 = num22 + array22[6] * 256 * 256;
						byte[] array23 = array;
						num4 = 7 + 1;
						class744_0.long_0 = (uint)(num23 + array23[7] * 256 * 256 * 256);
						byte[] array24 = array;
						num4 = 8 + 1;
						byte num24 = array24[8];
						byte[] array25 = array;
						num4 = 9 + 1;
						int num25 = num24 + array25[9] * 256;
						byte[] array26 = array;
						num4 = 10 + 1;
						int num26 = num25 + array26[10] * 256 * 256;
						byte[] array27 = array;
						num4 = 11 + 1;
						class744_0.long_2 = (uint)(num26 + array27[11] * 256 * 256 * 256);
						class744_0.int_4 += 16;
					}
					if (flag = num12 != class744_0.long_0)
					{
						class744_0.method_35().Seek(-12L, SeekOrigin.Current);
						num12 += 4;
					}
					continue;
				}
				return false;
			}
			class744_0.method_35().Seek(position, SeekOrigin.Begin);
		}
		class744_0.long_1 = class744_0.long_0;
		if ((class744_0.short_6 & 1) == 1)
		{
			class744_0.byte_3 = new byte[12];
			num += smethod_9(class744_0.stream_0, class744_0.byte_3);
			class744_0.long_1 -= 12L;
		}
		class744_0.int_3 = num;
		class744_0.long_6 = class744_0.int_3 + class744_0.long_1 + class744_0.int_4;
		return true;
	}

	internal static int smethod_9(Stream stream_3, byte[] byte_4)
	{
		int num = stream_3.Read(byte_4, 0, 12);
		if (num != 12)
		{
			throw new Exception1($"Unexpected end of data at position 0x{stream_3.Position:X8}");
		}
		return num;
	}

	private static bool smethod_10(int int_6)
	{
		return int_6 != 67324752;
	}

	internal static Class744 smethod_11(Class751 class751_1, bool bool_14)
	{
		Class746 @class = class751_1.method_0();
		Stream stream = class751_1.method_14();
		Encoding encoding_ = class751_1.method_11();
		Class744 class2 = new Class744();
		class2.enum30_0 = Enum30.const_3;
		class2.class751_0 = class751_1;
		class2.stream_0 = stream;
		@class?.method_57(bool_18: true, null);
		if (bool_14)
		{
			smethod_12(stream);
		}
		if (!smethod_8(class2, encoding_))
		{
			return null;
		}
		class2.long_3 = class2.method_35().Position;
		stream.Seek(class2.long_1 + class2.int_4, SeekOrigin.Current);
		smethod_13(class2);
		if (@class != null)
		{
			@class.method_56(class2);
			@class.method_57(bool_18: false, class2);
		}
		return class2;
	}

	internal static void smethod_12(Stream stream_3)
	{
		uint num = (uint)Class742.smethod_8(stream_3);
		if (num != 808471376)
		{
			stream_3.Seek(-4L, SeekOrigin.Current);
		}
	}

	private static void smethod_13(Class744 class744_0)
	{
		Stream stream = class744_0.method_35();
		uint num = (uint)Class742.smethod_8(stream);
		if (num == class744_0.int_2)
		{
			int num2 = Class742.smethod_8(stream);
			if (num2 == class744_0.long_0)
			{
				num2 = Class742.smethod_8(stream);
				if (num2 != class744_0.long_2)
				{
					stream.Seek(-12L, SeekOrigin.Current);
				}
			}
			else
			{
				stream.Seek(-8L, SeekOrigin.Current);
			}
		}
		else
		{
			stream.Seek(-4L, SeekOrigin.Current);
		}
	}

	internal int method_60(Stream stream_3, short short_9)
	{
		int num = 0;
		if (short_9 > 0)
		{
			byte[] array = (byte_1 = new byte[short_9]);
			num = stream_3.Read(array, 0, array.Length);
			long long_ = stream_3.Position - num;
			int num2 = 0;
			while (num2 + 3 < array.Length)
			{
				int num3 = num2;
				ushort num4 = (ushort)(array[num2++] + array[num2++] * 256);
				short num5 = (short)(array[num2++] + array[num2++] * 256);
				switch (num4)
				{
				case 23:
					num2 = method_61(array, num2);
					break;
				case 10:
					num2 = method_67(array, num2, num5, long_);
					break;
				case 1:
					num2 = method_62(array, num2, num5, long_);
					break;
				case 22613:
					num2 = method_64(array, num2, num5, long_);
					break;
				case 21589:
					num2 = method_65(array, num2, num5, long_);
					break;
				}
				num2 = num3 + num5 + 4;
			}
		}
		return num;
	}

	private int method_61(byte[] byte_4, int int_6)
	{
		int_6 += 2;
		uint_1 = (ushort)(byte_4[int_6++] + byte_4[int_6++] * 256);
		enum24_0 = Enum24.const_2;
		enum24_1 = Enum24.const_2;
		return int_6;
	}

	private int method_62(byte[] byte_4, int int_6, short short_9, long long_7)
	{
		bool_10 = true;
		if (short_9 > 28)
		{
			throw new Exception3($"  Inconsistent size (0x{short_9:X4}) for ZIP64 extra field at position 0x{long_7:X16}");
		}
		int int_7 = short_9;
		if (long_2 == uint.MaxValue)
		{
			long_2 = method_63(ref int_6, ref int_7, byte_4, long_7);
		}
		if (long_0 == uint.MaxValue)
		{
			long_0 = method_63(ref int_6, ref int_7, byte_4, long_7);
		}
		if (long_4 == uint.MaxValue)
		{
			long_4 = method_63(ref int_6, ref int_7, byte_4, long_7);
		}
		return int_6;
	}

	private long method_63(ref int int_6, ref int int_7, byte[] byte_4, long long_7)
	{
		if (int_7 < 8)
		{
			throw new Exception3($"  Missing data for ZIP64 extra field, position 0x{long_7:X16}");
		}
		long result = BitConverter.ToInt64(byte_4, int_6);
		int_6 += 8;
		int_7 -= 8;
		return result;
	}

	private int method_64(byte[] byte_4, int int_6, short short_9, long long_7)
	{
		if (short_9 != 12 && short_9 != 8)
		{
			throw new Exception3($"  Unexpected size (0x{short_9:X4}) for InfoZip v1 extra field at position 0x{long_7:X16}");
		}
		int num = BitConverter.ToInt32(byte_4, int_6);
		dateTime_1 = dateTime_4.AddSeconds(num);
		int_6 += 4;
		num = BitConverter.ToInt32(byte_4, int_6);
		dateTime_2 = dateTime_4.AddSeconds(num);
		int_6 += 4;
		dateTime_3 = DateTime.UtcNow;
		bool_0 = true;
		enum28_0 |= Enum28.flag_4;
		return int_6;
	}

	private int method_65(byte[] byte_4, int int_6, short short_9, long long_7)
	{
		if (short_9 != 13 && short_9 != 9 && short_9 != 5)
		{
			throw new Exception3($"  Unexpected size (0x{short_9:X4}) for Extended Timestamp extra field at position 0x{long_7:X16}");
		}
		int num = short_9;
		if (short_9 != 13 && int_5 <= 0)
		{
			method_59();
		}
		else
		{
			byte b = byte_4[int_6++];
			num--;
			if (((uint)b & (true ? 1u : 0u)) != 0 && num >= 4)
			{
				dateTime_1 = method_66(ref int_6, ref num, byte_4);
			}
			dateTime_2 = (((b & 2) == 0 || num < 4) ? DateTime.UtcNow : method_66(ref int_6, ref num, byte_4));
			dateTime_3 = (((b & 4) == 0 || num < 4) ? DateTime.UtcNow : method_66(ref int_6, ref num, byte_4));
			enum28_0 |= Enum28.flag_3;
			bool_0 = true;
			bool_2 = true;
		}
		return int_6;
	}

	private DateTime method_66(ref int int_6, ref int int_7, byte[] byte_4)
	{
		int num = BitConverter.ToInt32(byte_4, int_6);
		int_6 += 4;
		int_7 -= 4;
		return dateTime_4.AddSeconds(num);
	}

	private int method_67(byte[] byte_4, int int_6, short short_9, long long_7)
	{
		if (short_9 != 32)
		{
			throw new Exception3($"  Unexpected size (0x{short_9:X4}) for NTFS times extra field at position 0x{long_7:X16}");
		}
		int_6 += 4;
		short num = (short)(byte_4[int_6] + byte_4[int_6 + 1] * 256);
		short num2 = (short)(byte_4[int_6 + 2] + byte_4[int_6 + 3] * 256);
		int_6 += 4;
		if (num == 1 && num2 == 24)
		{
			long fileTime = BitConverter.ToInt64(byte_4, int_6);
			dateTime_1 = DateTime.FromFileTimeUtc(fileTime);
			int_6 += 8;
			fileTime = BitConverter.ToInt64(byte_4, int_6);
			dateTime_2 = DateTime.FromFileTimeUtc(fileTime);
			int_6 += 8;
			fileTime = BitConverter.ToInt64(byte_4, int_6);
			dateTime_3 = DateTime.FromFileTimeUtc(fileTime);
			int_6 += 8;
			bool_0 = true;
			enum28_0 |= Enum28.flag_2;
			bool_1 = true;
		}
		return int_6;
	}

	internal void method_68(Stream stream_3)
	{
		byte[] array = new byte[4096];
		int num = 0;
		num = 0 + 1;
		array[0] = 80;
		num = 1 + 1;
		array[1] = 75;
		num = 2 + 1;
		array[2] = 1;
		num = 3 + 1;
		array[3] = 2;
		num = 4 + 1;
		array[4] = (byte)((uint)short_0 & 0xFFu);
		num = 5 + 1;
		array[5] = (byte)((short_0 & 0xFF00) >> 8);
		short num2 = (short)((method_10() != 0) ? method_10() : 20);
		if (!nullable_2.HasValue)
		{
			nullable_2 = class751_0.method_2() == Enum32.const_3;
		}
		short num3 = (short)(nullable_2.Value ? 45 : num2);
		array[num++] = (byte)((uint)num3 & 0xFFu);
		array[num++] = (byte)((num3 & 0xFF00) >> 8);
		array[num++] = (byte)((uint)short_6 & 0xFFu);
		array[num++] = (byte)((short_6 & 0xFF00) >> 8);
		array[num++] = (byte)((uint)short_7 & 0xFFu);
		array[num++] = (byte)((short_7 & 0xFF00) >> 8);
		array[num++] = (byte)((uint)int_1 & 0xFFu);
		array[num++] = (byte)((int_1 & 0xFF00) >> 8);
		array[num++] = (byte)((int_1 & 0xFF0000) >> 16);
		array[num++] = (byte)((int_1 & 0xFF000000u) >> 24);
		array[num++] = (byte)((uint)int_2 & 0xFFu);
		array[num++] = (byte)((int_2 & 0xFF00) >> 8);
		array[num++] = (byte)((int_2 & 0xFF0000) >> 16);
		array[num++] = (byte)((int_2 & 0xFF000000u) >> 24);
		int num4 = 0;
		if (nullable_2.Value)
		{
			for (num4 = 0; num4 < 8; num4++)
			{
				array[num++] = byte.MaxValue;
			}
		}
		else
		{
			array[num++] = (byte)(long_0 & 0xFF);
			array[num++] = (byte)((long_0 & 0xFF00) >> 8);
			array[num++] = (byte)((long_0 & 0xFF0000) >> 16);
			array[num++] = (byte)((long_0 & 0xFF000000u) >> 24);
			array[num++] = (byte)(long_2 & 0xFF);
			array[num++] = (byte)((long_2 & 0xFF00) >> 8);
			array[num++] = (byte)((long_2 & 0xFF0000) >> 16);
			array[num++] = (byte)((long_2 & 0xFF000000u) >> 24);
		}
		byte[] array2 = method_71();
		short num5 = (short)array2.Length;
		array[num++] = (byte)((uint)num5 & 0xFFu);
		array[num++] = (byte)((num5 & 0xFF00) >> 8);
		bool_12 = nullable_2.Value;
		byte_1 = method_69(bool_14: true);
		short num6 = (short)((byte_1 != null) ? byte_1.Length : 0);
		array[num++] = (byte)((uint)num6 & 0xFFu);
		array[num++] = (byte)((num6 & 0xFF00) >> 8);
		int num7 = ((byte_0 != null) ? byte_0.Length : 0);
		if (num7 + num > array.Length)
		{
			num7 = array.Length - num;
		}
		array[num++] = (byte)((uint)num7 & 0xFFu);
		array[num++] = (byte)((num7 & 0xFF00) >> 8);
		if (class751_0.method_0() != null && class751_0.method_0().method_29() != 0)
		{
			array[num++] = (byte)(uint_0 & 0xFFu);
			array[num++] = (byte)((uint_0 & 0xFF00) >> 8);
		}
		else
		{
			array[num++] = 0;
			array[num++] = 0;
		}
		array[num++] = (byte)(bool_13 ? 1u : 0u);
		array[num++] = 0;
		array[num++] = (byte)((uint)int_0 & 0xFFu);
		array[num++] = (byte)((int_0 & 0xFF00) >> 8);
		array[num++] = (byte)((int_0 & 0xFF0000) >> 16);
		array[num++] = (byte)((int_0 & 0xFF000000u) >> 24);
		if (long_4 > uint.MaxValue)
		{
			array[num++] = byte.MaxValue;
			array[num++] = byte.MaxValue;
			array[num++] = byte.MaxValue;
			array[num++] = byte.MaxValue;
		}
		else
		{
			array[num++] = (byte)(long_4 & 0xFF);
			array[num++] = (byte)((long_4 & 0xFF00) >> 8);
			array[num++] = (byte)((long_4 & 0xFF0000) >> 16);
			array[num++] = (byte)((long_4 & 0xFF000000u) >> 24);
		}
		Buffer.BlockCopy(array2, 0, array, num, num5);
		num += num5;
		if (byte_1 != null)
		{
			byte[] src = byte_1;
			Buffer.BlockCopy(src, 0, array, num, num6);
			num += num6;
		}
		if (num7 != 0)
		{
			Buffer.BlockCopy(byte_0, 0, array, num, num7);
			num += num7;
		}
		stream_3.Write(array, 0, num);
	}

	private byte[] method_69(bool bool_14)
	{
		List<byte[]> list = new List<byte[]>();
		if (class751_0.method_2() == Enum32.const_3 || (class751_0.method_2() == Enum32.const_2 && (!bool_14 || nullable_1.Value)))
		{
			int num = 4 + (bool_14 ? 28 : 16);
			byte[] array = new byte[num];
			int num2 = 0;
			if (!bool_12 && !bool_14)
			{
				array[num2++] = 153;
				array[num2++] = 153;
			}
			else
			{
				array[num2++] = 1;
				array[num2++] = 0;
			}
			array[num2++] = (byte)(num - 4);
			array[num2++] = 0;
			Array.Copy(BitConverter.GetBytes(long_2), 0, array, num2, 8);
			num2 += 8;
			Array.Copy(BitConverter.GetBytes(long_0), 0, array, num2, 8);
			num2 += 8;
			if (bool_14)
			{
				Array.Copy(BitConverter.GetBytes(long_4), 0, array, num2, 8);
				num2 += 8;
				Array.Copy(BitConverter.GetBytes(0), 0, array, num2, 4);
			}
			list.Add(array);
		}
		if (bool_0 && bool_1)
		{
			byte[] array = new byte[36];
			byte[] array2 = array;
			_ = 0 + 1;
			array2[0] = 10;
			byte[] array3 = array;
			_ = 1 + 1;
			array3[1] = 0;
			byte[] array4 = array;
			_ = 2 + 1;
			array4[2] = 32;
			byte[] array5 = array;
			_ = 3 + 1;
			array5[3] = 0;
			byte[] array6 = array;
			_ = 8 + 1;
			array6[8] = 1;
			byte[] array7 = array;
			_ = 9 + 1;
			array7[9] = 0;
			byte[] array8 = array;
			_ = 10 + 1;
			array8[10] = 24;
			byte[] array9 = array;
			_ = 11 + 1;
			array9[11] = 0;
			long value = dateTime_1.ToFileTime();
			Array.Copy(BitConverter.GetBytes(value), 0, array, 12, 8);
			value = dateTime_2.ToFileTime();
			Array.Copy(BitConverter.GetBytes(value), 0, array, 20, 8);
			value = dateTime_3.ToFileTime();
			Array.Copy(BitConverter.GetBytes(value), 0, array, 28, 8);
			list.Add(array);
		}
		if (bool_0 && bool_2)
		{
			int num3 = 9;
			if (!bool_14)
			{
				num3 += 8;
			}
			byte[] array = new byte[num3];
			int num4 = 0;
			byte[] array10 = array;
			num4 = 0 + 1;
			array10[0] = 85;
			byte[] array11 = array;
			num4 = 1 + 1;
			array11[1] = 84;
			byte[] array12 = array;
			num4 = 2 + 1;
			array12[2] = (byte)(num3 - 4);
			byte[] array13 = array;
			num4 = 3 + 1;
			array13[3] = 0;
			byte[] array14 = array;
			num4 = 4 + 1;
			array14[4] = 7;
			int value2 = (int)(dateTime_1 - dateTime_4).TotalSeconds;
			Array.Copy(BitConverter.GetBytes(value2), 0, array, 5, 4);
			num4 = 5 + 4;
			if (!bool_14)
			{
				value2 = (int)(dateTime_2 - dateTime_4).TotalSeconds;
				Array.Copy(BitConverter.GetBytes(value2), 0, array, num4, 4);
				num4 += 4;
				value2 = (int)(dateTime_3 - dateTime_4).TotalSeconds;
				Array.Copy(BitConverter.GetBytes(value2), 0, array, num4, 4);
				num4 += 4;
			}
			list.Add(array);
		}
		byte[] array15 = null;
		if (list.Count > 0)
		{
			int num5 = 0;
			int num6 = 0;
			for (int i = 0; i < list.Count; i++)
			{
				num5 += list[i].Length;
			}
			array15 = new byte[num5];
			for (int i = 0; i < list.Count; i++)
			{
				Array.Copy(list[i], 0, array15, num6, list[i].Length);
				num6 += list[i].Length;
			}
		}
		return array15;
	}

	private string method_70()
	{
		string text = FileName.Replace("\\", "/");
		string text2 = null;
		if (bool_3 && FileName.Length >= 3 && FileName[1] == ':' && text[2] == '/')
		{
			return text.Substring(3);
		}
		if (FileName.Length >= 4 && text[0] == '/' && text[1] == '/')
		{
			int num = text.IndexOf('/', 2);
			if (num == -1)
			{
				throw new ArgumentException("The path for that entry appears to be badly formatted");
			}
			return text.Substring(num + 1);
		}
		if (FileName.Length >= 3 && text[0] == '.' && text[1] == '/')
		{
			return text.Substring(2);
		}
		return text;
	}

	private byte[] method_71()
	{
		string text = method_70();
		switch (method_31())
		{
		case Enum33.const_0:
			if (string_2 != null && string_2.Length != 0)
			{
				byte_0 = encoding_1.GetBytes(string_2);
			}
			encoding_2 = encoding_1;
			return encoding_1.GetBytes(text);
		default:
		{
			byte[] bytes = encoding_1.GetBytes(text);
			string @string = encoding_1.GetString(bytes, 0, bytes.Length);
			byte_0 = null;
			if (@string != text)
			{
				bytes = method_29().GetBytes(text);
				if (string_2 != null && string_2.Length != 0)
				{
					byte_0 = method_29().GetBytes(string_2);
				}
				encoding_2 = method_29();
				return bytes;
			}
			encoding_2 = encoding_1;
			if (string_2 != null && string_2.Length != 0)
			{
				byte[] bytes2 = encoding_1.GetBytes(string_2);
				string string2 = encoding_1.GetString(bytes2, 0, bytes2.Length);
				if (string2 != Comment)
				{
					bytes = method_29().GetBytes(text);
					byte_0 = method_29().GetBytes(string_2);
					encoding_2 = method_29();
					return bytes;
				}
				byte_0 = bytes2;
				return bytes;
			}
			return bytes;
		}
		case Enum33.const_3:
			if (string_2 != null && string_2.Length != 0)
			{
				byte_0 = method_29().GetBytes(string_2);
			}
			encoding_2 = method_29();
			return method_29().GetBytes(text);
		}
	}

	private bool method_72()
	{
		if (long_2 < 16)
		{
			return false;
		}
		if (short_7 == 0)
		{
			return false;
		}
		if (method_14() == Enum42.const_0)
		{
			return false;
		}
		if (long_0 < long_2)
		{
			return false;
		}
		if (enum30_0 == Enum30.const_2 && !stream_1.CanSeek)
		{
			return false;
		}
		if (class743_1 != null && method_16() - 12 <= method_17())
		{
			return false;
		}
		return true;
	}

	private void method_73(int int_6)
	{
		if (int_6 > 1)
		{
			short_7 = 0;
		}
		else if (method_18())
		{
			short_7 = 0;
		}
		else
		{
			if (enum30_0 == Enum30.const_3)
			{
				return;
			}
			if (enum30_0 == Enum30.const_2)
			{
				if (stream_1 != null && stream_1.CanSeek)
				{
					long length = stream_1.Length;
					if (length == 0)
					{
						short_7 = 0;
						return;
					}
				}
			}
			else if (enum30_0 == Enum30.const_1 && Class742.smethod_0(method_9()) == 0)
			{
				short_7 = 0;
				return;
			}
			if (method_27() != null)
			{
				method_15(method_27()(method_9(), string_1));
			}
			if (method_14() == Enum42.const_0 && method_12() == Enum29.const_1)
			{
				short_7 = 0;
			}
		}
	}

	internal void method_74(Stream stream_3, int int_6)
	{
		long_5 = (stream_3 as Stream3)?.method_4() ?? stream_3.Position;
		int num = 0;
		int num2 = 0;
		byte[] array = new byte[30];
		num2 = 0 + 1;
		array[0] = 80;
		num2 = 1 + 1;
		array[1] = 75;
		num2 = 2 + 1;
		array[2] = 3;
		num2 = 3 + 1;
		array[3] = 4;
		bool_12 = class751_0.method_2() == Enum32.const_3 || (class751_0.method_2() == Enum32.const_2 && !stream_3.CanSeek);
		short num3 = (short)(bool_12 ? 45 : 20);
		array[num2++] = (byte)((uint)num3 & 0xFFu);
		array[num2++] = (byte)((num3 & 0xFF00) >> 8);
		byte[] array2 = method_71();
		short num4 = (short)array2.Length;
		if (enum24_0 == Enum24.const_0)
		{
			short_6 &= -2;
		}
		else
		{
			short_6 |= 1;
		}
		if (encoding_2.CodePage == Encoding.UTF8.CodePage)
		{
			short_6 |= 2048;
		}
		if (!method_18() && int_6 != 99)
		{
			if (!stream_3.CanSeek)
			{
				short_6 |= 8;
			}
		}
		else
		{
			short_6 &= -9;
			short_6 &= -2;
			method_21(Enum24.const_0);
			Password = null;
		}
		array[num2++] = (byte)((uint)short_6 & 0xFFu);
		array[num2++] = (byte)((short_6 & 0xFF00) >> 8);
		if (long_3 == -1)
		{
			long_0 = 0L;
			bool_5 = false;
		}
		method_73(int_6);
		array[num2++] = (byte)((uint)short_7 & 0xFFu);
		array[num2++] = (byte)((short_7 & 0xFF00) >> 8);
		if (int_6 == 99)
		{
			method_83();
		}
		int_1 = Class742.smethod_13(method_2());
		array[num2++] = (byte)((uint)int_1 & 0xFFu);
		array[num2++] = (byte)((int_1 & 0xFF00) >> 8);
		array[num2++] = (byte)((int_1 & 0xFF0000) >> 16);
		array[num2++] = (byte)((int_1 & 0xFF000000u) >> 24);
		array[num2++] = (byte)((uint)int_2 & 0xFFu);
		array[num2++] = (byte)((int_2 & 0xFF00) >> 8);
		array[num2++] = (byte)((int_2 & 0xFF0000) >> 16);
		array[num2++] = (byte)((int_2 & 0xFF000000u) >> 24);
		if (bool_12)
		{
			for (num = 0; num < 8; num++)
			{
				array[num2++] = byte.MaxValue;
			}
		}
		else
		{
			array[num2++] = (byte)(long_0 & 0xFF);
			array[num2++] = (byte)((long_0 & 0xFF00) >> 8);
			array[num2++] = (byte)((long_0 & 0xFF0000) >> 16);
			array[num2++] = (byte)((long_0 & 0xFF000000u) >> 24);
			array[num2++] = (byte)(long_2 & 0xFF);
			array[num2++] = (byte)((long_2 & 0xFF00) >> 8);
			array[num2++] = (byte)((long_2 & 0xFF0000) >> 16);
			array[num2++] = (byte)((long_2 & 0xFF000000u) >> 24);
		}
		array[num2++] = (byte)((uint)num4 & 0xFFu);
		array[num2++] = (byte)((num4 & 0xFF00) >> 8);
		byte_1 = method_69(bool_14: false);
		short num5 = (short)((byte_1 != null) ? byte_1.Length : 0);
		array[num2++] = (byte)((uint)num5 & 0xFFu);
		array[num2++] = (byte)((num5 & 0xFF00) >> 8);
		byte[] array3 = new byte[num2 + num4 + num5];
		Buffer.BlockCopy(array, 0, array3, 0, num2);
		Buffer.BlockCopy(array2, 0, array3, num2, array2.Length);
		num2 += array2.Length;
		if (byte_1 != null)
		{
			Buffer.BlockCopy(byte_1, 0, array3, num2, byte_1.Length);
			num2 += byte_1.Length;
		}
		int_3 = num2;
		Stream7 stream = stream_3 as Stream7;
		if (stream != null)
		{
			stream.method_1(bool_2: true);
			uint num6 = stream.method_7(num2);
			if (num6 != stream.method_2())
			{
				long_5 = 0L;
			}
			else
			{
				long_5 = stream.Position;
			}
			uint_0 = num6;
		}
		if (class751_0.method_2() == Enum32.const_0 && (uint)long_4 >= uint.MaxValue)
		{
			throw new Exception1("Offset within the zip archive exceeds 0xFFFFFFFF. Consider setting the UseZip64WhenSaving property on the ZipFile instance.");
		}
		stream_3.Write(array3, 0, num2);
		stream?.method_1(bool_2: false);
		byte_2 = array3;
	}

	private int method_75()
	{
		if (!bool_5)
		{
			Stream stream = null;
			if (enum30_0 == Enum30.const_4)
			{
				Stream1 stream2 = new Stream1(Stream.Null);
				delegate0_0(FileName, stream2);
				int_2 = stream2.method_1();
			}
			else if (enum30_0 != Enum30.const_3)
			{
				if (enum30_0 == Enum30.const_2)
				{
					method_76();
					stream = stream_1;
				}
				else if (enum30_0 == Enum30.const_5)
				{
					if (stream_1 == null)
					{
						stream_1 = delegate1_0(FileName);
					}
					method_76();
					stream = stream_1;
				}
				else if (enum30_0 != Enum30.const_6)
				{
					stream = File.Open(method_9(), FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
				}
				Class741 @class = new Class741();
				int_2 = @class.method_2(stream);
				if (stream_1 == null)
				{
					stream.Dispose();
				}
			}
			bool_5 = true;
		}
		return int_2;
	}

	private void method_76()
	{
		if (stream_1 == null)
		{
			throw new Exception1($"The input stream is null for entry '{FileName}'.");
		}
		if (nullable_0.HasValue)
		{
			stream_1.Position = nullable_0.Value;
		}
		else if (stream_1.CanSeek)
		{
			nullable_0 = stream_1.Position;
		}
		else if (method_20() == Enum24.const_1 && enum30_0 != Enum30.const_3 && (short_6 & 8) != 8)
		{
			throw new Exception1("It is not possible to use PKZIP encryption on a non-seekable input stream");
		}
	}

	internal void method_77(Class744 class744_0)
	{
		long_3 = class744_0.long_3;
		method_13(class744_0.method_12());
		short_8 = class744_0.short_8;
		long_1 = class744_0.long_1;
		long_2 = class744_0.long_2;
		short_6 = class744_0.short_6;
		enum30_0 = class744_0.enum30_0;
		dateTime_0 = class744_0.dateTime_0;
		dateTime_1 = class744_0.dateTime_1;
		dateTime_2 = class744_0.dateTime_2;
		dateTime_3 = class744_0.dateTime_3;
		bool_0 = class744_0.bool_0;
		bool_2 = class744_0.bool_2;
		bool_1 = class744_0.bool_1;
	}

	private void method_78(long long_7, long long_8)
	{
		if (class751_0.method_0() != null)
		{
			bool_11 = class751_0.method_0().method_49(this, long_7, long_8);
		}
	}

	private void method_79(Stream stream_3)
	{
		Stream stream_4 = null;
		long num = -1L;
		try
		{
			num = stream_3.Position;
		}
		catch (Exception)
		{
		}
		try
		{
			long num2 = method_80(ref stream_4);
			Stream3 stream = new Stream3(stream_3);
			Stream stream2;
			Stream stream_5;
			if (num2 != 0)
			{
				stream2 = method_86(stream);
				stream_5 = method_85(stream2, num2);
			}
			else
			{
				stream2 = (stream_5 = stream);
			}
			Stream1 stream3 = new Stream1(stream_5, bool_1: true);
			if (enum30_0 == Enum30.const_4)
			{
				delegate0_0(FileName, stream3);
			}
			else
			{
				byte[] array = new byte[method_3()];
				int count;
				while ((count = Class742.smethod_16(stream_4, array, 0, array.Length, FileName)) != 0)
				{
					stream3.Write(array, 0, count);
					method_78(stream3.method_0(), num2);
					if (bool_11)
					{
						break;
					}
				}
			}
			method_81(stream_3, stream, stream2, stream_5, stream3);
		}
		finally
		{
			if (enum30_0 == Enum30.const_5)
			{
				if (delegate2_0 != null)
				{
					delegate2_0(FileName, stream_4);
				}
			}
			else if (stream_4 is FileStream)
			{
				stream_4.Dispose();
			}
		}
		if (!bool_11)
		{
			long_3 = num;
			method_82(stream_3);
		}
	}

	private long method_80(ref Stream stream_3)
	{
		long result = -1L;
		if (enum30_0 == Enum30.const_2)
		{
			method_76();
			stream_3 = stream_1;
			try
			{
				result = stream_1.Length;
			}
			catch (NotSupportedException)
			{
			}
		}
		else if (enum30_0 == Enum30.const_3)
		{
			string string_ = ((enum24_1 == Enum24.const_0) ? null : (string_3 ?? class751_0.Password));
			stream_1 = method_40(string_);
			method_76();
			stream_3 = stream_1;
			result = stream_1.Length;
		}
		else if (enum30_0 == Enum30.const_5)
		{
			if (stream_1 == null)
			{
				stream_1 = delegate1_0(FileName);
			}
			method_76();
			stream_3 = stream_1;
			try
			{
				result = stream_1.Length;
			}
			catch (NotSupportedException)
			{
			}
		}
		else if (enum30_0 == Enum30.const_1)
		{
			stream_3 = File.Open(method_9(), FileMode.Open, FileAccess.Read, FileShare.ReadWrite | FileShare.Delete);
			result = stream_3.Length;
		}
		return result;
	}

	internal void method_81(Stream stream_3, Stream3 stream3_0, Stream stream_4, Stream stream_5, Stream1 stream1_0)
	{
		if (stream1_0 != null)
		{
			stream1_0.Close();
			if (stream_5 is Stream8)
			{
				stream_5.Close();
			}
			else if (stream_5 is Stream10)
			{
				stream_5.Close();
			}
			stream_4.Flush();
			stream_4.Close();
			int_4 = 0;
			long_2 = stream1_0.method_0();
			long_1 = stream3_0.method_1();
			long_0 = long_1;
			int_2 = stream1_0.method_1();
			method_88();
		}
	}

	internal void method_82(Stream stream_3)
	{
		Stream3 stream = stream_3 as Stream3;
		if (long_2 == 0 && long_0 == 0)
		{
			if (enum30_0 == Enum30.const_6)
			{
				return;
			}
			if (string_3 != null)
			{
				int num = 0;
				if (method_20() == Enum24.const_1)
				{
					num = 12;
				}
				if (enum30_0 == Enum30.const_6 && !stream_3.CanSeek)
				{
					throw new Exception1("Zero bytes written, encryption in use, and non-seekable output.");
				}
				if (method_20() != 0)
				{
					stream_3.Seek(-1 * num, SeekOrigin.Current);
					stream_3.SetLength(stream_3.Position);
					stream?.method_3(num);
					int_3 -= num;
					long_3 -= num;
				}
				string_3 = null;
				short_6 &= -2;
				byte[] array = byte_2;
				_ = 6 + 1;
				array[6] = (byte)((uint)short_6 & 0xFFu);
				byte[] array2 = byte_2;
				_ = 7 + 1;
				array2[7] = (byte)((short_6 & 0xFF00) >> 8);
			}
			method_13(Enum29.const_0);
			method_21(Enum24.const_0);
		}
		else if (class743_1 != null && method_20() == Enum24.const_1)
		{
			long_0 += 12L;
		}
		int num2 = 8;
		byte[] array3 = byte_2;
		num2 = 8 + 1;
		array3[8] = (byte)((uint)short_7 & 0xFFu);
		byte[] array4 = byte_2;
		num2 = 9 + 1;
		array4[9] = (byte)((short_7 & 0xFF00) >> 8);
		num2 = 14;
		byte[] array5 = byte_2;
		num2 = 14 + 1;
		array5[14] = (byte)((uint)int_2 & 0xFFu);
		byte[] array6 = byte_2;
		num2 = 15 + 1;
		array6[15] = (byte)((int_2 & 0xFF00) >> 8);
		byte[] array7 = byte_2;
		num2 = 16 + 1;
		array7[16] = (byte)((int_2 & 0xFF0000) >> 16);
		byte[] array8 = byte_2;
		num2 = 17 + 1;
		array8[17] = (byte)((int_2 & 0xFF000000u) >> 24);
		method_83();
		short num3 = (short)(byte_2[26] + byte_2[27] * 256);
		short num4 = (short)(byte_2[28] + byte_2[29] * 256);
		if (nullable_2.Value)
		{
			byte_2[4] = 45;
			byte_2[5] = 0;
			for (int i = 0; i < 8; i++)
			{
				byte_2[num2++] = byte.MaxValue;
			}
			num2 = 30 + num3;
			byte_2[num2++] = 1;
			byte_2[num2++] = 0;
			num2 += 2;
			Array.Copy(BitConverter.GetBytes(long_2), 0, byte_2, num2, 8);
			num2 += 8;
			Array.Copy(BitConverter.GetBytes(long_0), 0, byte_2, num2, 8);
		}
		else
		{
			byte_2[4] = 20;
			byte_2[5] = 0;
			num2 = 18;
			byte[] array9 = byte_2;
			num2 = 18 + 1;
			array9[18] = (byte)(long_0 & 0xFF);
			byte[] array10 = byte_2;
			num2 = 19 + 1;
			array10[19] = (byte)((long_0 & 0xFF00) >> 8);
			byte[] array11 = byte_2;
			num2 = 20 + 1;
			array11[20] = (byte)((long_0 & 0xFF0000) >> 16);
			byte[] array12 = byte_2;
			num2 = 21 + 1;
			array12[21] = (byte)((long_0 & 0xFF000000u) >> 24);
			byte[] array13 = byte_2;
			num2 = 22 + 1;
			array13[22] = (byte)(long_2 & 0xFF);
			byte[] array14 = byte_2;
			num2 = 23 + 1;
			array14[23] = (byte)((long_2 & 0xFF00) >> 8);
			byte[] array15 = byte_2;
			num2 = 24 + 1;
			array15[24] = (byte)((long_2 & 0xFF0000) >> 16);
			byte[] array16 = byte_2;
			num2 = 25 + 1;
			array16[25] = (byte)((long_2 & 0xFF000000u) >> 24);
			if (num4 != 0)
			{
				num2 = 30 + num3;
				short num5 = (short)(byte_2[num2 + 2] + byte_2[num2 + 3] * 256);
				if (num5 == 16)
				{
					byte_2[num2++] = 153;
					byte_2[num2++] = 153;
				}
			}
		}
		if ((short_6 & 8) != 8 || (enum30_0 == Enum30.const_6 && stream_3.CanSeek))
		{
			if (stream_3 is Stream7 stream2 && uint_0 != stream2.method_2())
			{
				using Stream stream3 = Stream7.smethod_2(class751_0.method_0().Name, uint_0);
				stream3.Seek(long_4, SeekOrigin.Begin);
				stream3.Write(byte_2, 0, byte_2.Length);
			}
			else
			{
				stream_3.Seek(long_4, SeekOrigin.Begin);
				stream_3.Write(byte_2, 0, byte_2.Length);
				stream?.method_3(byte_2.Length);
				stream_3.Seek(long_0, SeekOrigin.Current);
			}
		}
		if ((short_6 & 8) == 8 && !method_18())
		{
			byte[] array17 = new byte[16 + (nullable_2.Value ? 8 : 0)];
			num2 = 0;
			Array.Copy(BitConverter.GetBytes(134695760), 0, array17, 0, 4);
			num2 = 0 + 4;
			Array.Copy(BitConverter.GetBytes(int_2), 0, array17, 4, 4);
			num2 = 4 + 4;
			if (nullable_2.Value)
			{
				Array.Copy(BitConverter.GetBytes(long_0), 0, array17, num2, 8);
				num2 += 8;
				Array.Copy(BitConverter.GetBytes(long_2), 0, array17, num2, 8);
				num2 += 8;
			}
			else
			{
				array17[num2++] = (byte)(long_0 & 0xFF);
				array17[num2++] = (byte)((long_0 & 0xFF00) >> 8);
				array17[num2++] = (byte)((long_0 & 0xFF0000) >> 16);
				array17[num2++] = (byte)((long_0 & 0xFF000000u) >> 24);
				array17[num2++] = (byte)(long_2 & 0xFF);
				array17[num2++] = (byte)((long_2 & 0xFF00) >> 8);
				array17[num2++] = (byte)((long_2 & 0xFF0000) >> 16);
				array17[num2++] = (byte)((long_2 & 0xFF000000u) >> 24);
			}
			stream_3.Write(array17, 0, array17.Length);
			int_4 += array17.Length;
		}
	}

	private void method_83()
	{
		nullable_1 = long_0 >= uint.MaxValue || long_2 >= uint.MaxValue || long_4 >= uint.MaxValue;
		if (class751_0.method_2() == Enum32.const_0 && nullable_1.Value)
		{
			throw new Exception1("Compressed or Uncompressed size, or offset exceeds the maximum value. Consider setting the UseZip64WhenSaving property on the ZipFile instance.");
		}
		nullable_2 = class751_0.method_2() == Enum32.const_3 || nullable_1.Value;
	}

	internal void method_84(Stream s, long streamLength, out Stream3 outputCounter, out Stream encryptor, out Stream compressor, out Stream1 output)
	{
		outputCounter = new Stream3(s);
		if (streamLength != 0)
		{
			encryptor = method_86(outputCounter);
			compressor = method_85(encryptor, streamLength);
		}
		else
		{
			encryptor = (compressor = outputCounter);
		}
		output = new Stream1(compressor, bool_1: true);
	}

	private Stream method_85(Stream stream_3, long long_7)
	{
		if (short_7 == 8 && method_14() != 0)
		{
			if (class751_0.method_6() != 0 && (long_7 <= class751_0.method_6() || class751_0.method_6() <= 0))
			{
				Stream8 stream = new Stream8(stream_3, Enum44.const_0, method_14(), bool_1: true);
				if (class751_0.method_8() > 0)
				{
					stream.method_0(class751_0.method_8());
				}
				stream.method_1(class751_0.method_9());
				return stream;
			}
			if (class751_0.method_4() == null)
			{
				class751_0.method_5(new Stream10(stream_3, method_14(), class751_0.method_9(), bool_5: true));
				if (class751_0.method_8() > 0)
				{
					class751_0.method_4().method_3(class751_0.method_8());
				}
				if (class751_0.method_7() > 0)
				{
					class751_0.method_4().method_2(class751_0.method_7());
				}
			}
			Stream10 stream2 = class751_0.method_4();
			stream2.Reset(stream_3);
			return stream2;
		}
		return stream_3;
	}

	private Stream method_86(Stream stream_3)
	{
		if (method_20() == Enum24.const_1)
		{
			return new Stream4(stream_3, class743_1, Enum27.const_0);
		}
		return stream_3;
	}

	private void method_87(Exception exception_0)
	{
		if (class751_0.method_0() != null)
		{
			bool_11 = class751_0.method_0().method_63(this, exception_0);
		}
	}

	internal void Write(Stream stream_3)
	{
		Stream3 stream = stream_3 as Stream3;
		Stream7 stream2 = stream_3 as Stream7;
		bool flag = false;
		do
		{
			try
			{
				if (enum30_0 == Enum30.const_3 && !bool_7)
				{
					method_91(stream_3);
					break;
				}
				if (method_18())
				{
					method_74(stream_3, 1);
					method_88();
					nullable_1 = long_4 >= uint.MaxValue;
					nullable_2 = class751_0.method_2() == Enum32.const_3 || nullable_1.Value;
					if (stream2 != null)
					{
						uint_0 = stream2.method_2();
					}
					break;
				}
				bool flag2 = true;
				int num = 0;
				do
				{
					num++;
					method_74(stream_3, num);
					method_90(stream_3);
					method_79(stream_3);
					long_6 = int_3 + long_1 + int_4;
					flag2 = num <= 1 && stream_3.CanSeek && method_72();
					if (flag2)
					{
						if (stream2 != null)
						{
							stream2.method_10(uint_0, long_4);
						}
						else
						{
							stream_3.Seek(long_4, SeekOrigin.Begin);
						}
						stream_3.SetLength(stream_3.Position);
						stream?.method_3(long_6);
					}
				}
				while (flag2);
				bool_9 = false;
				flag = true;
			}
			catch (Exception ex)
			{
				Enum31 enum31_ = method_24();
				int num2 = 0;
				while (true)
				{
					if (method_24() != 0)
					{
						if (method_24() != Enum31.const_1 && method_24() != Enum31.const_2)
						{
							if (num2 <= 0)
							{
								if (method_24() == Enum31.const_3)
								{
									method_87(ex);
									if (bool_11)
									{
										flag = true;
										break;
									}
								}
								num2++;
								continue;
							}
							throw;
						}
						long num3 = stream?.method_4() ?? stream_3.Position;
						long num4 = num3 - long_5;
						if (num4 > 0)
						{
							stream_3.Seek(num4, SeekOrigin.Current);
							long position = stream_3.Position;
							stream_3.SetLength(stream_3.Position);
							stream?.method_3(num3 - position);
						}
						if (method_24() == Enum31.const_1)
						{
							method_45("Skipping file {0} (exception: {1})", new object[2]
							{
								method_9(),
								ex.ToString()
							});
							bool_9 = true;
							flag = true;
						}
						else
						{
							method_25(enum31_);
						}
						break;
					}
					throw;
				}
			}
		}
		while (!flag);
	}

	internal void method_88()
	{
		long_4 = long_5;
	}

	internal void method_89()
	{
		enum24_1 = enum24_0;
		short_8 = short_7;
		bool_7 = false;
		bool_6 = false;
		enum30_0 = Enum30.const_3;
	}

	internal void method_90(Stream stream_3)
	{
		if (method_20() == Enum24.const_0)
		{
			return;
		}
		string password = string_3;
		if (enum30_0 == Enum30.const_3 && password == null)
		{
			password = class751_0.Password;
		}
		if (password == null)
		{
			class743_1 = null;
		}
		else if (method_20() == Enum24.const_1)
		{
			class743_1 = Class743.smethod_0(password);
			Random random = new Random();
			byte[] array = new byte[12];
			random.NextBytes(array);
			if ((short_6 & 8) == 8)
			{
				int_1 = Class742.smethod_13(method_2());
				array[11] = (byte)((uint)(int_1 >> 8) & 0xFFu);
			}
			else
			{
				method_75();
				array[11] = (byte)((uint)(int_2 >> 24) & 0xFFu);
			}
			byte[] array2 = class743_1.method_2(array, array.Length);
			stream_3.Write(array2, 0, array2.Length);
			int_3 += array2.Length;
		}
	}

	private void method_91(Stream stream_3)
	{
		if (method_38() == 0)
		{
			throw new Exception4("Bad header length.");
		}
		if (bool_6 || method_35() is Stream7 || stream_3 is Stream7 || (bool_10 && class751_0.method_10() == Enum32.const_0) || (!bool_10 && class751_0.method_10() == Enum32.const_3))
		{
			method_92(stream_3);
		}
		else
		{
			method_93(stream_3);
		}
		nullable_1 = long_0 >= uint.MaxValue || long_2 >= uint.MaxValue || long_4 >= uint.MaxValue;
		nullable_2 = class751_0.method_2() == Enum32.const_3 || nullable_1.Value;
	}

	private void method_92(Stream stream_3)
	{
		byte[] array = new byte[method_3()];
		Stream3 stream = new Stream3(method_35());
		long num = long_4;
		int num2 = method_38();
		method_74(stream_3, 0);
		method_88();
		if (!FileName.EndsWith("/"))
		{
			long num3 = num + num2;
			int num4 = smethod_6(enum24_1);
			num3 -= num4;
			int_3 += num4;
			stream.Seek(num3, SeekOrigin.Begin);
			long num5 = long_0;
			while (num5 > 0)
			{
				num4 = (int)((num5 > array.Length) ? array.Length : num5);
				int num6 = stream.Read(array, 0, num4);
				stream_3.Write(array, 0, num6);
				num5 -= num6;
				method_78(stream.method_2(), long_0);
				if (bool_11)
				{
					break;
				}
			}
			if ((short_6 & 8) == 8)
			{
				int num7 = 16;
				if (bool_10)
				{
					num7 += 8;
				}
				byte[] buffer = new byte[num7];
				stream.Read(buffer, 0, num7);
				if (bool_10 && class751_0.method_10() == Enum32.const_0)
				{
					stream_3.Write(buffer, 0, 8);
					if (long_0 > uint.MaxValue)
					{
						throw new InvalidOperationException("ZIP64 is required");
					}
					stream_3.Write(buffer, 8, 4);
					if (long_2 > uint.MaxValue)
					{
						throw new InvalidOperationException("ZIP64 is required");
					}
					stream_3.Write(buffer, 16, 4);
					int_4 -= 8;
				}
				else if (!bool_10 && class751_0.method_10() == Enum32.const_3)
				{
					byte[] buffer2 = new byte[4];
					stream_3.Write(buffer, 0, 8);
					stream_3.Write(buffer, 8, 4);
					stream_3.Write(buffer2, 0, 4);
					stream_3.Write(buffer, 12, 4);
					stream_3.Write(buffer2, 0, 4);
					int_4 += 8;
				}
				else
				{
					stream_3.Write(buffer, 0, num7);
				}
			}
		}
		long_6 = int_3 + long_1 + int_4;
	}

	private void method_93(Stream stream_3)
	{
		byte[] array = new byte[method_3()];
		Stream3 stream = new Stream3(method_35());
		stream.Seek(long_4, SeekOrigin.Begin);
		if (long_6 == 0)
		{
			long_6 = int_3 + long_1 + int_4;
		}
		long_4 = (stream_3 as Stream3)?.method_4() ?? stream_3.Position;
		long num = long_6;
		while (num > 0)
		{
			int count = (int)((num > array.Length) ? array.Length : num);
			int num2 = stream.Read(array, 0, count);
			stream_3.Write(array, 0, num2);
			num -= num2;
			method_78(stream.method_2(), long_6);
			if (bool_11)
			{
				break;
			}
		}
	}
}
