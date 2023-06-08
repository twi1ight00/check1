using System;
using System.Collections;
using System.Drawing;
using System.IO;
using System.Text;
using Aspose.Cells;
using Microsoft.Win32;
using ns16;
using ns18;
using ns22;

namespace ns47;

internal class Class1462
{
	internal static ArrayList arrayList_0 = new ArrayList();

	internal static ArrayList arrayList_1 = new ArrayList();

	private static string string_0;

	internal Class1393 class1393_0;

	public SortedList sortedList_0;

	private Class1453 class1453_0;

	private Class1456 class1456_0;

	private Class1458 class1458_0;

	private Hashtable hashtable_0;

	private Class1454 class1454_0;

	private Class1457 class1457_0;

	private Class1070 class1070_0;

	private Class1069 class1069_0;

	private Class1394 class1394_0;

	private MemoryStream memoryStream_0;

	private MemoryStream memoryStream_1;

	private MemoryStream memoryStream_2;

	private static Hashtable hashtable_1 = Class1177.smethod_0();

	private static Hashtable hashtable_2 = Class1177.smethod_0();

	private static Hashtable hashtable_3 = Class1177.smethod_0();

	private static readonly Hashtable hashtable_4 = Class1177.smethod_0();

	private static readonly Hashtable hashtable_5 = Class1177.smethod_0();

	private static readonly Hashtable hashtable_6 = Class1177.smethod_0();

	private static readonly string[] string_1 = new string[9] { "head", "hhea", "maxp", "hmtx", "fpgm", "prep", "cvt ", "loca", "glyf" };

	private static readonly string[] string_2 = new string[4] { "OS/2", "name", "cmap", "post" };

	private static readonly int[] int_0 = new int[21]
	{
		0, 0, 1, 1, 2, 2, 2, 2, 3, 3,
		3, 3, 3, 3, 3, 3, 4, 4, 4, 4,
		4
	};

	private Class1398 class1398_0 = new Class1398();

	internal static Class746 class746_0 = null;

	internal static string smethod_0()
	{
		if (arrayList_0.Count == 0)
		{
			return "";
		}
		return (string)arrayList_0[0];
	}

	internal static void smethod_1(string string_3)
	{
		arrayList_0 = new ArrayList();
		arrayList_0.Add(string_3);
	}

	internal static Class1460 smethod_2(string string_3, FontStyle fontStyle_0, bool bool_0)
	{
		Class1461 @class;
		lock (hashtable_6)
		{
			@class = (Class1461)hashtable_6[string_3];
			if (@class == null)
			{
				@class = smethod_4(string_3);
				if (@class == null)
				{
					return null;
				}
				hashtable_6[string_3] = @class;
			}
		}
		return @class.method_0(fontStyle_0, bool_0);
	}

	internal static Class1460 smethod_3(string string_3, FontStyle fontStyle_0, bool bool_0)
	{
		Class1460 @class = null;
		try
		{
			if (string_3.StartsWith("UNHCR_Map_"))
			{
				string_3 = "Wingdings";
			}
			@class = smethod_2(smethod_5(string_3), fontStyle_0, bool_0);
		}
		catch
		{
			@class = smethod_2("Arial", fontStyle_0, bool_0);
		}
		if (@class == null)
		{
			if (Class1448.smethod_0())
			{
				@class = smethod_2("Arial Unicode MS", fontStyle_0, bool_0);
				if (@class == null)
				{
					@class = smethod_2("Arial", fontStyle_0, bool_0);
				}
			}
			else
			{
				@class = smethod_2("Arial", fontStyle_0, bool_0);
			}
			return @class;
		}
		return @class;
	}

	internal Class1460 Read(string string_3, string string_4)
	{
		Class1460 @class;
		lock (hashtable_5)
		{
			@class = (Class1460)hashtable_5[string_3 + string_4];
			if (@class == null)
			{
				@class = method_0(string_3, string_4);
				@class.FileName = string_3;
				@class.method_48(class1454_0);
				hashtable_5.Add(string_3 + string_4, @class);
			}
		}
		return @class;
	}

	internal Class1460 method_0(string string_3, string string_4)
	{
		long offset = 0L;
		string_0 = string_3;
		using Stream stream = File.OpenRead(string_3);
		class1393_0 = new Class1393(stream);
		if (string_3.ToLower().EndsWith("ttc"))
		{
			uint num = method_27(class1393_0);
			for (uint num2 = 0u; num2 < num; num2++)
			{
				offset = 12 + num2 * 4;
				stream.Seek(offset, SeekOrigin.Begin);
				offset = class1393_0.method_2();
				stream.Seek(offset, SeekOrigin.Begin);
				method_8();
				method_9();
				Hashtable hashtable = method_12();
				foreach (Hashtable value in hashtable.Values)
				{
					if (((string)value[4]).Equals(string_4))
					{
						stream.Seek(offset, SeekOrigin.Begin);
						method_8();
						method_9();
						method_13();
						method_14();
						method_10();
						method_11();
						method_15();
						method_16();
						return method_17();
					}
				}
			}
		}
		else
		{
			offset = 0L;
		}
		stream.Seek(offset, SeekOrigin.Begin);
		method_8();
		method_9();
		method_13();
		method_14();
		method_10();
		method_11();
		method_15();
		method_16();
		return method_17();
	}

	[Attribute0(true)]
	internal void method_1(Class1460 class1460_0, Class1398 class1398_1, Class1398 class1398_2, Stream stream_0, bool bool_0, bool bool_1)
	{
		if (class1460_0 == null)
		{
			throw new ArgumentNullException("font");
		}
		if (class1398_2 == null)
		{
			throw new ArgumentNullException("oldToNewGlyphIndexes");
		}
		if (stream_0 == null)
		{
			throw new ArgumentNullException("dstStream");
		}
		using Stream stream = File.OpenRead(class1460_0.FileName);
		class1393_0 = new Class1393(stream);
		long offset = 0L;
		if (class1460_0.FileName.ToLower().EndsWith("ttc"))
		{
			uint num = method_27(class1393_0);
			for (uint num2 = 0u; num2 < num; num2++)
			{
				offset = 12 + num2 * 4;
				stream.Seek(offset, SeekOrigin.Begin);
				offset = class1393_0.method_2();
				stream.Seek(offset, SeekOrigin.Begin);
				method_8();
				method_9();
				method_13();
				if (((string)hashtable_0[4]).Equals(class1460_0.method_0()))
				{
					break;
				}
			}
		}
		else
		{
			offset = 0L;
		}
		stream.Seek(offset, SeekOrigin.Begin);
		method_8();
		if (!bool_1 && !class1460_0.method_64())
		{
			method_9();
			method_10();
			method_11();
			method_15();
			if (bool_0)
			{
				method_16();
				method_7();
			}
			bool bool_2 = class1453_0.short_5 == 0;
			Class1455 @class = new Class1455(class1393_0, bool_2, class1457_0);
			ushort num3 = (ushort)@class.method_3(method_19("loca"), method_19("glyf"), class1398_2);
			if (num3 != class1398_2.Count)
			{
				throw new InvalidOperationException("Unexpected used glyphs count!");
			}
			memoryStream_0 = @class.method_0();
			memoryStream_1 = @class.method_1();
			memoryStream_2 = @class.method_2();
			class1458_0.ushort_0 = num3;
			class1456_0.ushort_1 = num3;
			if (bool_0)
			{
				class1070_0.method_3(class1398_1);
				class1069_0.method_1(class1398_2);
			}
			method_3(bool_0, stream_0);
		}
		else
		{
			Class1015.smethod_10(class1460_0.FileName, stream_0);
		}
	}

	internal void method_2(Class1460 class1460_0, Class1398 class1398_1, Stream stream_0, bool bool_0, bool bool_1)
	{
		if (class1460_0 == null)
		{
			throw new ArgumentNullException("font");
		}
		if (class1398_1 == null)
		{
			throw new ArgumentNullException("usedGlyphs");
		}
		if (stream_0 == null)
		{
			throw new ArgumentNullException("dstStream");
		}
		using Stream stream = File.OpenRead(class1460_0.FileName);
		class1393_0 = new Class1393(stream);
		long offset = 0L;
		if (class1460_0.FileName.ToLower().EndsWith("ttc"))
		{
			uint num = method_27(class1393_0);
			for (uint num2 = 0u; num2 < num; num2++)
			{
				offset = 12 + num2 * 4;
				stream.Seek(offset, SeekOrigin.Begin);
				offset = class1393_0.method_2();
				stream.Seek(offset, SeekOrigin.Begin);
				method_8();
				method_9();
				method_13();
				if (((string)hashtable_0[4]).Equals(class1460_0.method_0()))
				{
					break;
				}
			}
		}
		else
		{
			offset = 0L;
		}
		stream.Seek(offset, SeekOrigin.Begin);
		method_8();
		method_9();
		method_10();
		method_11();
		method_15();
		bool bool_2 = class1453_0.short_5 == 0;
		Class1455 @class = new Class1455(class1393_0, bool_2, class1457_0);
		ushort num3 = (ushort)@class.method_3(method_19("loca"), method_19("glyf"), class1398_1);
		memoryStream_0 = @class.method_0();
		memoryStream_1 = @class.method_1();
		memoryStream_2 = @class.method_2();
		class1458_0.ushort_0 = num3;
		class1456_0.ushort_1 = num3;
		class1394_0 = new Class1394(stream_0);
		int num4 = method_22();
		class1394_0.method_0().Position = num4;
		method_23();
		class1394_0.method_0().Position = 0L;
		method_22();
	}

	private void method_3(bool bool_0, Stream stream_0)
	{
		class1394_0 = new Class1394(stream_0);
		int num = method_4(bool_0);
		class1394_0.method_0().Position = num;
		method_6(bool_0);
		class1394_0.method_0().Position = 0L;
		method_4(bool_0);
	}

	private int method_4(bool bool_0)
	{
		class1394_0.method_1(65536);
		ArrayList arrayList = new ArrayList();
		method_5(string_1, arrayList);
		if (bool_0)
		{
			method_5(string_2, arrayList);
		}
		class1394_0.method_3(arrayList.Count);
		int num = int_0[arrayList.Count];
		int num2 = (1 << num) * 16;
		class1394_0.method_3(num2);
		class1394_0.method_3(num);
		int num3 = arrayList.Count * 16 - num2;
		class1394_0.method_3(num3);
		int result = (int)class1394_0.method_0().Position + arrayList.Count * 16;
		foreach (Class1459 item in arrayList)
		{
			item.Write(class1394_0);
		}
		return result;
	}

	private void method_5(string[] string_3, ArrayList arrayList_2)
	{
		foreach (string string_4 in string_3)
		{
			Class1459 @class = method_19(string_4);
			if (@class != null)
			{
				arrayList_2.Add(@class);
			}
		}
	}

	private void method_6(bool bool_0)
	{
		method_25("head");
		method_24("hhea", class1456_0.method_0());
		method_24("maxp", class1458_0.method_0());
		method_24("hmtx", memoryStream_2);
		method_25("fpgm");
		method_25("prep");
		method_25("cvt ");
		method_24("loca", memoryStream_0);
		method_24("glyf", memoryStream_1);
		if (bool_0)
		{
			method_25("OS/2");
			method_25("name");
			method_24("cmap", class1070_0.method_0());
			method_24("post", class1069_0.method_0());
		}
	}

	private void method_7()
	{
		method_18("post");
		class1069_0 = new Class1069(class1393_0);
	}

	internal static Class1461 smethod_4(string string_3)
	{
		Class1461 @class = new Class1461(string_3);
		foreach (string key in hashtable_4.Keys)
		{
			string text2 = key.Substring(0, key.IndexOf("*$"));
			if (!text2.Equals(string_3))
			{
				continue;
			}
			string text3 = (string)hashtable_4[key];
			string extension = Path.GetExtension(text3);
			if (Class1015.smethod_16(extension, ".ttf") || Class1015.smethod_16(extension, ".ttc") || Class1015.smethod_16(extension, ".otf"))
			{
				Class1462 class2 = new Class1462(bool_0: false);
				try
				{
					Class1460 class1460_ = class2.Read(text3, string_3);
					@class.Add(class1460_);
				}
				catch (Exception)
				{
				}
			}
		}
		return @class;
	}

	internal void method_8()
	{
		class1393_0.method_1();
		sortedList_0 = new SortedList();
		int num = class1393_0.method_4();
		class1393_0.method_4();
		class1393_0.method_4();
		class1393_0.method_4();
		for (int i = 0; i < num; i++)
		{
			Class1459 @class = new Class1459(class1393_0);
			sortedList_0.Add(@class.string_0, @class);
		}
	}

	internal void method_9()
	{
		method_18("head");
		class1453_0 = new Class1453(class1393_0);
	}

	internal void method_10()
	{
		method_18("hhea");
		class1456_0 = new Class1456(class1393_0);
	}

	internal void method_11()
	{
		method_18("maxp");
		class1458_0 = new Class1458(class1393_0);
	}

	internal Hashtable method_12()
	{
		method_18("name");
		int num = (int)class1393_0.method_0().Position;
		if (class1393_0.method_4() != 0)
		{
			throw new NotSupportedException("Unknown name table format.");
		}
		ushort num2 = class1393_0.method_4();
		ushort num3 = class1393_0.method_4();
		Hashtable hashtable = new Hashtable();
		Hashtable hashtable2 = null;
		for (int i = 0; i < num2; i++)
		{
			class1393_0.method_4();
			ushort num4 = class1393_0.method_4();
			ushort num5 = class1393_0.method_4();
			ushort num6 = class1393_0.method_4();
			ushort num7 = class1393_0.method_4();
			ushort num8 = class1393_0.method_4();
			if ((num4 == 1 || num4 == 0) && num5 != 0)
			{
				if (!hashtable.ContainsKey(num5))
				{
					hashtable2 = new Hashtable();
					hashtable[num5] = hashtable2;
				}
				else
				{
					hashtable2 = (Hashtable)hashtable[num5];
				}
				int num9 = (int)class1393_0.method_0().Position;
				class1393_0.method_0().Position = num + num3 + num8;
				byte[] bytes = class1393_0.method_5(num7);
				if (!hashtable2.Contains((int)num6))
				{
					hashtable2[(int)num6] = Encoding.BigEndianUnicode.GetString(bytes);
				}
				class1393_0.method_0().Position = num9;
			}
		}
		return hashtable;
	}

	internal void method_13()
	{
		method_18("name");
		int num = (int)class1393_0.method_0().Position;
		if (class1393_0.method_4() != 0)
		{
			throw new NotSupportedException("Unknown name table format.");
		}
		ushort num2 = class1393_0.method_4();
		ushort num3 = class1393_0.method_4();
		hashtable_0 = new Hashtable();
		for (int i = 0; i < num2; i++)
		{
			ushort num4 = class1393_0.method_4();
			ushort num5 = class1393_0.method_4();
			ushort num6 = class1393_0.method_4();
			ushort num7 = class1393_0.method_4();
			ushort num8 = class1393_0.method_4();
			ushort num9 = class1393_0.method_4();
			if (num4 == 3 && (num5 == 1 || num5 == 0) && num6 == 1033)
			{
				int num10 = (int)class1393_0.method_0().Position;
				class1393_0.method_0().Position = num + num3 + num9;
				byte[] bytes = class1393_0.method_5(num8);
				if (!hashtable_0.Contains((int)num7))
				{
					hashtable_0[(int)num7] = Encoding.BigEndianUnicode.GetString(bytes);
				}
				class1393_0.method_0().Position = num10;
			}
		}
	}

	internal void method_14()
	{
		method_18("OS/2");
		class1454_0 = new Class1454(class1393_0);
	}

	internal void method_15()
	{
		if (class1456_0 == null)
		{
			throw new InvalidOperationException("Need to read horizontal header first.");
		}
		if (class1458_0 == null)
		{
			throw new InvalidOperationException("Need to read maximum profile first.");
		}
		method_18("hmtx");
		class1457_0 = new Class1457(class1393_0, class1456_0.ushort_1, class1458_0.ushort_0);
	}

	internal void method_16()
	{
		method_18("cmap");
		class1070_0 = new Class1070(class1393_0);
	}

	internal Class1460 method_17()
	{
		Class1460 @class = new Class1460();
		@class.method_10(class1453_0.ushort_1);
		@class.method_26(class1453_0.short_0);
		@class.method_30(class1453_0.short_1);
		@class.method_32(class1453_0.short_2);
		@class.method_34(class1453_0.short_3);
		@class.method_1(method_21(Enum211.const_1));
		@class.method_2(method_21(Enum211.const_2));
		@class.method_4(method_21(Enum211.const_4));
		@class.method_6(method_20(Enum211.const_6));
		@class.method_12(class1456_0.short_0);
		@class.method_14(Math.Abs(class1456_0.short_1));
		@class.method_16(@class.method_11() + @class.method_13() + class1456_0.short_2);
		@class.method_38((float)((0.0 - Math.Atan2(class1456_0.short_7, class1456_0.short_6)) * 180.0 / Math.PI));
		@class.method_50(class1456_0.ushort_0);
		@class.method_51(class1453_0.ushort_0);
		@class.method_18(class1454_0.short_9);
		@class.method_24(class1454_0.short_10);
		@class.method_22(class1454_0.short_2);
		@class.method_23(class1454_0.short_4);
		@class.method_20(class1454_0.short_6);
		@class.method_21(class1454_0.short_8);
		@class.Style = class1454_0.Style;
		@class.method_36(class1454_0.short_16);
		@class.method_56(method_19("loca"));
		@class.method_58(method_19("glyf"));
		method_19("VDMX");
		@class.method_55(class1453_0.short_5 == 0);
		@class.method_8(class1070_0.method_2(class1457_0, @class.method_0()));
		@class.method_28(class1070_0);
		@class.method_54(new Class1076(class1393_0, method_19("hdmx"), @class.method_7().Count + 1));
		@class.method_52(class1457_0);
		Class1459 class2 = method_19("CFF ");
		if (class2 != null)
		{
			@class.method_65(bool_4: true);
			class1393_0.method_0().Position = class2.int_1;
			Class1068 class3 = new Class1068(class1393_0);
			@class.method_66(class3.method_1());
		}
		@class.method_60((class1454_0.ushort_3 & 4u) != 0 && (class1454_0.ushort_3 & 8) == 0);
		return @class;
	}

	internal void method_18(string string_3)
	{
		Class1459 @class = method_19(string_3);
		class1393_0.method_0().Position = @class.int_1;
	}

	internal Class1459 method_19(string string_3)
	{
		Class1459 @class = (Class1459)sortedList_0[string_3];
		if (@class == null)
		{
			return null;
		}
		return @class;
	}

	internal string method_20(Enum211 enum211_0)
	{
		return (string)hashtable_0[(int)enum211_0];
	}

	internal string method_21(Enum211 enum211_0)
	{
		string text = method_20(enum211_0);
		if (text == null)
		{
			throw new InvalidOperationException("Requested a name string that is not present in the font.");
		}
		return text;
	}

	internal int method_22()
	{
		class1394_0.method_1(65536);
		int num = string_1.Length;
		class1394_0.method_4((ushort)num);
		int num2 = int_0[num];
		int num3 = (1 << num2) * 16;
		class1394_0.method_4((ushort)num3);
		class1394_0.method_4((ushort)num2);
		int num4 = num * 16 - num3;
		class1394_0.method_4((ushort)num4);
		int result = (int)class1394_0.method_0().Position + num * 16;
		for (int i = 0; i < num; i++)
		{
			method_19(string_1[i])?.Write(class1394_0);
		}
		return result;
	}

	internal void method_23()
	{
		method_25("head");
		method_24("hhea", class1456_0.method_0());
		method_24("maxp", class1458_0.method_0());
		method_24("hmtx", memoryStream_2);
		method_25("fpgm");
		method_25("prep");
		method_25("cvt ");
		method_24("loca", memoryStream_0);
		method_24("glyf", memoryStream_1);
	}

	internal void method_24(string string_3, MemoryStream memoryStream_3)
	{
		Class1459 @class = method_19(string_3);
		@class.int_1 = (int)class1394_0.method_0().Position;
		class1394_0.method_5(memoryStream_3.GetBuffer(), 0, (int)memoryStream_3.Length);
		@class.int_0 = Class1459.smethod_0(memoryStream_3.GetBuffer(), 0, (int)memoryStream_3.Length);
		@class.int_2 = (int)memoryStream_3.Length;
		method_26();
	}

	internal void method_25(string string_3)
	{
		try
		{
			Class1459 @class = method_19(string_3);
			class1393_0.method_0().Position = @class.int_1;
			byte[] array = class1393_0.method_5(@class.int_2);
			@class.int_1 = (int)class1394_0.method_0().Position;
			class1394_0.method_5(array, 0, array.Length);
			method_26();
		}
		catch
		{
		}
	}

	internal void method_26()
	{
		Class1015.smethod_8(class1394_0.method_0(), 4);
	}

	internal uint method_27(Class1393 class1393_1)
	{
		class1393_1.method_5(8);
		return class1393_1.method_2();
	}

	internal ArrayList method_28(string string_3)
	{
		ArrayList arrayList = new ArrayList();
		string_0 = string_3;
		string text = "";
		string text2 = "";
		using Stream stream = File.OpenRead(string_3);
		class1393_0 = new Class1393(stream);
		Hashtable hashtable = null;
		switch (Path.GetExtension(string_3).ToLower())
		{
		case ".otf":
		case ".ttf":
			method_8();
			method_9();
			hashtable = method_12();
			if (hashtable.ContainsKey((ushort)1033))
			{
				text2 = (string)((Hashtable)hashtable[(ushort)1033])[1];
				try
				{
					if (Struct78.long_0 < stream.Length)
					{
						Hashtable hashtable4 = (Hashtable)hashtable[(ushort)1033];
						if (((string)hashtable4[2]).ToLower() == "regular")
						{
							Struct78.string_0 = (string)hashtable4[1];
							Struct78.long_0 = stream.Length;
							Struct78.string_1 = (string)hashtable4[2];
						}
					}
				}
				catch
				{
				}
			}
			foreach (Hashtable value in hashtable.Values)
			{
				_ = (string)value[2];
				string text4 = "";
				if (value[1] != null)
				{
					text4 = (string)value[1];
				}
				if (text4.Length > 0 && text4.Length > 0 && !text.Equals(text4))
				{
					if (!hashtable_2.ContainsKey(text2))
					{
						hashtable_2.Add(text2, new Hashtable());
					}
					Hashtable hashtable6 = (Hashtable)hashtable_2[text2];
					if (!text2.Equals(text4))
					{
						hashtable6[text4] = 0;
					}
					text = text4;
					arrayList.Add(text2 + "*$" + value[2]);
				}
			}
			break;
		case ".ttc":
		{
			uint num = method_27(class1393_0);
			for (uint num2 = 0u; num2 < num; num2++)
			{
				long offset = 12 + num2 * 4;
				stream.Seek(offset, SeekOrigin.Begin);
				offset = class1393_0.method_2();
				stream.Seek(offset, SeekOrigin.Begin);
				method_8();
				method_9();
				hashtable = method_12();
				if (hashtable.ContainsKey((ushort)1033))
				{
					text2 = (string)((Hashtable)hashtable[(ushort)1033])[1];
				}
				foreach (Hashtable value2 in hashtable.Values)
				{
					_ = (string)value2[2];
					string text3 = "";
					if (value2[1] != null)
					{
						text3 = (string)value2[1];
					}
					if (text3.Length > 0 && !text.Equals(text3))
					{
						if (!hashtable_2.ContainsKey(text2))
						{
							hashtable_2.Add(text2, new Hashtable());
						}
						Hashtable hashtable3 = (Hashtable)hashtable_2[text2];
						if (!text2.Equals(text3))
						{
							hashtable3[text3] = 0;
						}
						text = text3;
						arrayList.Add(text2 + "*$" + value2[2]);
					}
				}
			}
			break;
		}
		}
		return arrayList;
	}

	internal void method_29()
	{
		string text = "";
		if (arrayList_0.Count != 0)
		{
			foreach (string item in arrayList_0)
			{
				try
				{
					string[] files = Directory.GetFiles(item);
					foreach (string text2 in files)
					{
						text = text2;
						ArrayList arrayList = method_28(text2);
						foreach (object item2 in arrayList)
						{
							if (item2 != null && !hashtable_4.ContainsKey((string)item2))
							{
								hashtable_4[(string)item2] = text2;
							}
						}
					}
				}
				catch (Exception)
				{
				}
			}
		}
		if (arrayList_1.Count > 0)
		{
			try
			{
				foreach (string item3 in arrayList_1)
				{
					text = item3;
					ArrayList arrayList2 = method_28(item3);
					foreach (object item4 in arrayList2)
					{
						if (item4 != null && !hashtable_4.ContainsKey((string)item4))
						{
							hashtable_4[(string)item4] = item3;
						}
					}
				}
			}
			catch (Exception ex2)
			{
				throw new CellsException(ExceptionType.InvalidData, "Invalid Font filename" + text + " " + ex2.StackTrace);
			}
		}
		try
		{
			string directoryName = Path.GetDirectoryName(Environment.SystemDirectory);
			string path2 = Path.Combine(directoryName, "Fonts");
			using RegistryKey registryKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Fonts", writable: false);
			if (registryKey == null)
			{
				return;
			}
			string[] valueNames = registryKey.GetValueNames();
			string[] array = valueNames;
			foreach (string name in array)
			{
				string text4 = Path.Combine(path2, (string)registryKey.GetValue(name));
				text = text4;
				ArrayList arrayList3 = method_28(text4);
				foreach (object item5 in arrayList3)
				{
					if (item5 != null && !hashtable_4.ContainsKey((string)item5))
					{
						hashtable_4[(string)item5] = text4;
					}
				}
			}
		}
		catch (Exception)
		{
		}
	}

	internal static string smethod_5(string string_3)
	{
		lock (hashtable_1)
		{
			string text = string_3;
			char[] trimChars = new char[1];
			string_3 = text.Trim(trimChars);
			string text2 = (string)hashtable_1[string_3];
			if (text2 != null)
			{
				return text2;
			}
			foreach (string key in hashtable_2.Keys)
			{
				if (!key.ToLower().Equals(string_3.ToLower()))
				{
					Hashtable hashtable = (Hashtable)hashtable_2[key];
					if (hashtable.Count != 0 && hashtable.Contains(string_3))
					{
						text2 = key;
						break;
					}
					continue;
				}
				text2 = key;
				break;
			}
			if (text2 != null && text2.Length > 0)
			{
				hashtable_1[string_3] = text2;
				return text2;
			}
		}
		return string_3;
	}

	internal void method_30()
	{
		if (arrayList_0.Count != 0)
		{
			foreach (string item in arrayList_0)
			{
				try
				{
					string[] files = Directory.GetFiles(item);
					foreach (string text in files)
					{
						ArrayList arrayList = method_28(text);
						foreach (object item2 in arrayList)
						{
							if (item2 != null && !hashtable_4.ContainsKey((string)item2))
							{
								hashtable_4[(string)item2] = text;
							}
						}
					}
				}
				catch (Exception)
				{
				}
			}
		}
		if (arrayList_1.Count > 0)
		{
			foreach (string item3 in arrayList_1)
			{
				try
				{
					ArrayList arrayList2 = method_28(item3);
					foreach (object item4 in arrayList2)
					{
						if (item4 != null && !hashtable_4.ContainsKey((string)item4))
						{
							hashtable_4[(string)item4] = item3;
						}
					}
				}
				catch (Exception)
				{
				}
			}
		}
		try
		{
			DirectoryInfo directoryInfo = new DirectoryInfo("./fonts/");
			FileInfo[] files2 = directoryInfo.GetFiles();
			FileInfo[] array = files2;
			foreach (FileInfo fileInfo in array)
			{
				string fullName = fileInfo.FullName;
				ArrayList arrayList3 = method_28(fullName);
				foreach (object item5 in arrayList3)
				{
					hashtable_4[(string)item5] = fullName;
				}
			}
		}
		catch (Exception)
		{
		}
	}

	private void method_31()
	{
		Stream stream_ = Class1028.smethod_0("Aspose.Cells.font.zip");
		class746_0 = Class746.Read(stream_);
	}

	internal Class1462(bool bool_0)
	{
		lock (hashtable_4)
		{
			int num = 0;
			if (bool_0 || hashtable_4.Count == 0)
			{
				method_31();
				try
				{
					num = Environment.SystemDirectory.Length;
				}
				catch
				{
				}
				if (num < 2)
				{
					method_30();
				}
				else
				{
					method_29();
				}
			}
		}
	}

	internal static bool smethod_6(string string_3, FontStyle fontStyle_0, string string_4)
	{
		Class1460 @class = smethod_3(string_3, fontStyle_0, bool_0: false);
		if (@class.method_0() != smethod_5(string_3))
		{
			return false;
		}
		int num = 0;
		while (true)
		{
			if (num < string_4.Length)
			{
				if (string_4[num] != '\n' && string_4[num] != '\r' && !@class.method_7().ContainsKey(string_4[num]))
				{
					break;
				}
				num++;
				continue;
			}
			return true;
		}
		return false;
	}
}
