using System;
using System.Collections.Generic;
using System.Text;
using ns4;

namespace ns45;

internal class Class1109
{
	private const int int_0 = 128;

	public const byte byte_0 = 0;

	public const byte byte_1 = 1;

	public const byte byte_2 = 2;

	public const byte byte_3 = 3;

	public const byte byte_4 = 4;

	public const byte byte_5 = 5;

	private Class1107 class1107_0;

	private Interface36 interface36_0;

	public Class1107 RootFolder
	{
		get
		{
			return class1107_0;
		}
		set
		{
			class1107_0 = value;
		}
	}

	public void method_0(Interface36 reader)
	{
		interface36_0 = reader;
		Class1103 @class = reader.imethod_0();
		Class1101 sat = reader.imethod_4();
		Class1106 dirStream = new Class1106((int)@class.method_18(), sat, reader);
		class1107_0 = (Class1107)method_1(method_21(0, dirStream), dirStream);
		dirStream = null;
		reader = null;
	}

	private Class1105 method_1(byte[] entry, Class1106 dirStream)
	{
		Class1107 @class = method_2(entry);
		List<byte[]> list = method_10(method_16(entry), dirStream);
		for (int i = 0; i < list.Count; i++)
		{
			byte[] entry2 = list[i];
			byte b = method_13(entry2);
			if (b != 1 && b != 5)
			{
				@class.Add(method_3(entry2));
			}
			else
			{
				@class.Add(method_1(entry2, dirStream));
			}
		}
		return @class;
	}

	private Class1107 method_2(byte[] entry)
	{
		Class1107 @class = new Class1107();
		@class.EntryName = method_20(entry);
		@class.SId = method_18(entry);
		@class.Size = method_19(entry);
		@class.UId = method_17(entry);
		return @class;
	}

	private Class1106 method_3(byte[] entry)
	{
		Class1103 @class = interface36_0.imethod_0();
		Class1106 class2 = new Class1106(method_19(entry));
		class2.SId = method_18(entry);
		class2.EntryName = method_20(entry);
		class2.Size = method_19(entry);
		class2.UId = method_17(entry);
		_ = class2.Size;
		@class.method_20();
		return class2;
	}

	private Class1105 method_4(List<Class1105> entries)
	{
		if (entries.Count == 0)
		{
			return null;
		}
		for (int i = 0; i < entries.Count; i++)
		{
			Class1105 @class = entries[i];
			@class.RootEntry = null;
			@class.LeftEntry = null;
			@class.RightEntry = null;
		}
		Class1105 class2 = entries[0];
		for (int j = 1; j < entries.Count; j++)
		{
			method_12(class2, entries[j]);
		}
		return class2;
	}

	public List<Class1105> method_5()
	{
		return method_9(class1107_0);
	}

	public void method_6()
	{
	}

	public Class1106 method_7()
	{
		class1107_0.TypeEntry = 5;
		List<Class1105> list = method_9(class1107_0);
		for (int i = 0; i < list.Count; i++)
		{
			Class1105 @class = list[i];
			@class.DId = i;
		}
		Class1106 class2 = new Class1106();
		for (int j = 0; j < list.Count; j++)
		{
			class2.method_1(method_8(list[j]));
		}
		return class2;
	}

	private byte[] method_8(Class1105 entry)
	{
		byte[] array = new byte[128];
		string s = ((entry.EntryName.Length > 31) ? entry.EntryName.Substring(0, 31) : entry.EntryName);
		UnicodeEncoding unicodeEncoding = new UnicodeEncoding();
		byte[] bytes = unicodeEncoding.GetBytes(s);
		Array.Copy(bytes, 0, array, 0, bytes.Length);
		array[64] = (byte)(bytes.Length + 2);
		array[65] = 0;
		array[66] = (byte)entry.TypeEntry;
		if (entry.LeftEntry != null)
		{
			array[68] = (byte)((uint)entry.LeftEntry.DId & 0xFFu);
			array[69] = (byte)((uint)(entry.LeftEntry.DId >> 8) & 0xFFu);
			array[70] = (byte)((uint)(entry.LeftEntry.DId >> 16) & 0xFFu);
			array[71] = (byte)((uint)(entry.LeftEntry.DId >> 24) & 0xFFu);
		}
		else
		{
			array[68] = byte.MaxValue;
			array[69] = byte.MaxValue;
			array[70] = byte.MaxValue;
			array[71] = byte.MaxValue;
		}
		if (entry.RightEntry != null)
		{
			array[72] = (byte)((uint)entry.RightEntry.DId & 0xFFu);
			array[73] = (byte)((uint)(entry.RightEntry.DId >> 8) & 0xFFu);
			array[74] = (byte)((uint)(entry.RightEntry.DId >> 16) & 0xFFu);
			array[75] = (byte)((uint)(entry.RightEntry.DId >> 24) & 0xFFu);
		}
		else
		{
			array[72] = byte.MaxValue;
			array[73] = byte.MaxValue;
			array[74] = byte.MaxValue;
			array[75] = byte.MaxValue;
		}
		if (entry.RootEntry != null)
		{
			array[76] = (byte)((uint)entry.RootEntry.DId & 0xFFu);
			array[77] = (byte)((uint)(entry.RootEntry.DId >> 8) & 0xFFu);
			array[78] = (byte)((uint)(entry.RootEntry.DId >> 16) & 0xFFu);
			array[79] = (byte)((uint)(entry.RootEntry.DId >> 24) & 0xFFu);
		}
		else
		{
			array[76] = byte.MaxValue;
			array[77] = byte.MaxValue;
			array[78] = byte.MaxValue;
			array[79] = byte.MaxValue;
		}
		byte[] uId = entry.UId;
		if (uId != null)
		{
			for (int i = 0; i < 16; i++)
			{
				array[80 + i] = uId[i];
			}
		}
		array[116] = (byte)((uint)entry.SId & 0xFFu);
		array[117] = (byte)((uint)(entry.SId >> 8) & 0xFFu);
		array[118] = (byte)((uint)(entry.SId >> 16) & 0xFFu);
		array[119] = (byte)((uint)(entry.SId >> 24) & 0xFFu);
		array[120] = (byte)((uint)entry.Size & 0xFFu);
		array[121] = (byte)((uint)(entry.Size >> 8) & 0xFFu);
		array[122] = (byte)((uint)(entry.Size >> 16) & 0xFFu);
		array[123] = (byte)((uint)(entry.Size >> 24) & 0xFFu);
		return array;
	}

	private List<Class1105> method_9(Class1107 root)
	{
		List<Class1105> list = new List<Class1105>();
		List<Class1105> list2 = root.method_3();
		Class1105 rootEntry = method_4(list2);
		root.RootEntry = rootEntry;
		list.Add(root);
		for (int i = 0; i < list2.Count; i++)
		{
			Class1105 @class = list2[i];
			if (@class is Class1107)
			{
				list.AddRange(method_9((Class1107)@class));
			}
			else
			{
				list.Add(@class);
			}
		}
		return list;
	}

	private List<byte[]> method_10(int rootDID, Class1106 dirStream)
	{
		List<byte[]> list = new List<byte[]>(1);
		if (rootDID < 0)
		{
			return list;
		}
		byte[] array = method_21(rootDID, dirStream);
		list.Add(array);
		int num = method_14(array);
		int num2 = method_15(array);
		if (num > -1)
		{
			list.AddRange(method_10(num, dirStream));
		}
		if (num2 > -1)
		{
			list.AddRange(method_10(num2, dirStream));
		}
		return list;
	}

	public int method_11(Interface36 reader)
	{
		Class1103 @class = reader.imethod_0();
		Class1101 sat = reader.imethod_4();
		@class = reader.imethod_0();
		Class1106 dirStream = new Class1106((int)@class.method_18(), sat, reader);
		Class1107 class2 = method_2(method_21(0, dirStream));
		return class2.SId;
	}

	private void method_12(Class1105 root, Class1105 entry)
	{
		if (root.CompareTo(entry) > 0)
		{
			if (root.LeftEntry != null)
			{
				method_12(root.LeftEntry, entry);
			}
			else
			{
				root.LeftEntry = entry;
			}
		}
		else if (root.RightEntry != null)
		{
			method_12(root.RightEntry, entry);
		}
		else
		{
			root.RightEntry = entry;
		}
	}

	private byte method_13(byte[] entry)
	{
		return entry[66];
	}

	private int method_14(byte[] entry)
	{
		return Class1162.smethod_6(entry, 68);
	}

	private int method_15(byte[] entry)
	{
		return Class1162.smethod_6(entry, 72);
	}

	private int method_16(byte[] entry)
	{
		return Class1162.smethod_6(entry, 76);
	}

	private byte[] method_17(byte[] entry)
	{
		byte[] array = new byte[16];
		for (int i = 0; i < 16; i++)
		{
			array[i] = entry[80 + i];
		}
		return array;
	}

	private int method_18(byte[] entry)
	{
		return Class1162.smethod_6(entry, 116);
	}

	private int method_19(byte[] entry)
	{
		return Class1162.smethod_6(entry, 120);
	}

	private string method_20(byte[] entry)
	{
		int num = entry[64];
		UnicodeEncoding unicodeEncoding = new UnicodeEncoding();
		return unicodeEncoding.GetString(entry, 0, num - 2);
	}

	private byte[] method_21(int did, Class1106 dirStream)
	{
		byte[] array = new byte[128];
		Array.Copy(dirStream.method_7(), did * 128, array, 0, 128);
		return array;
	}
}
