using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using ns218;
using ns272;

namespace ns271;

internal class Class6636 : Class6634
{
	private class Class6722
	{
		public ushort ushort_0;

		public ushort ushort_1;

		public int int_0;

		public byte[] byte_0;

		public uint uint_0;

		public Class6644 class6644_0;

		public Class6722(ushort platformID, ushort platformSpecificID, int format, Class6634 baseTable)
		{
			ushort_0 = platformID;
			ushort_1 = platformSpecificID;
			int_0 = format;
			class6644_0 = new Class6648(platformID, platformSpecificID, baseTable);
		}

		public void method_0()
		{
			using MemoryStream memoryStream = new MemoryStream();
			Class5951 ttfWriter = new Class5951(memoryStream);
			class6644_0.Save(ttfWriter);
			memoryStream.Flush();
			memoryStream.Position = 0L;
			byte_0 = memoryStream.ToArray();
			uint_0 = (uint)byte_0.Length;
		}
	}

	private const int int_0 = 4;

	public const int int_1 = 0;

	public const int int_2 = 1;

	public const int int_3 = 3;

	public const int int_4 = 0;

	public const int int_5 = 1;

	public const int int_6 = 10;

	public const int int_7 = 0;

	public const int int_8 = 1;

	public const int int_9 = 2;

	public const int int_10 = 3;

	public const int int_11 = 25;

	public const int int_12 = 1033;

	public const int int_13 = 0;

	public const string string_0 = "cmap";

	public const string string_1 = "cmap";

	private string string_2 = "{0}_{1}";

	private Hashtable hashtable_0 = new Hashtable();

	internal bool IsSymbolicFont => method_1(3, 0).Length > 0;

	public Class6636(Class5950 reader)
	{
		int num = (int)reader.BaseStream.Position;
		if (reader.method_3() != 0)
		{
			throw new InvalidOperationException("Unexpected cmap table version.");
		}
		int num2 = reader.method_3();
		for (int i = 0; i < num2; i++)
		{
			ushort num3 = reader.method_3();
			ushort num4 = reader.method_3();
			int num5 = reader.method_0();
			int num6 = (int)reader.BaseStream.Position;
			reader.BaseStream.Position = num + num5;
			ushort num7 = reader.method_3();
			if (num7 > 6)
			{
				reader.method_3();
			}
			Class6644 @class = null;
			switch (num7)
			{
			case 10:
				@class = new Class6646(num3, num4, this);
				break;
			case 2:
				@class = new Class6647(num3, num4, this);
				break;
			case 4:
				if (num3 == 0 || (num3 == 3 && (num4 == 1 || num4 == 0)))
				{
					@class = new Class6648(num3, num4, this);
				}
				break;
			case 6:
				@class = new Class6649(num3, num4, this);
				break;
			}
			if (@class != null)
			{
				@class.vmethod_0(reader);
				Class6722 item = new Class6722(num3, num4, num7, this)
				{
					class6644_0 = @class
				};
				string key = method_7(num3, num4);
				if (!hashtable_0.ContainsKey(key))
				{
					hashtable_0[key] = new List<Class6722>();
				}
				((List<Class6722>)hashtable_0[key]).Add(item);
			}
			reader.BaseStream.Position = num6;
		}
		if (hashtable_0.Count == 0)
		{
			throw new InvalidOperationException("Cannot find a required cmap table.");
		}
	}

	public Class6644[] method_1(ushort platformID, ushort platformSpecificID)
	{
		string key = method_7(platformID, platformSpecificID);
		if (!hashtable_0.ContainsKey(key))
		{
			return new Class6644[0];
		}
		Class6722[] array = ((List<Class6722>)hashtable_0[key]).ToArray();
		List<Class6644> list = new List<Class6644>();
		Class6722[] array2 = array;
		foreach (Class6722 @class in array2)
		{
			list.Add(@class.class6644_0);
		}
		return list.ToArray();
	}

	internal Class6735 method_2(Class6728 hMetrics)
	{
		Class6644 @class = method_4();
		if (@class != null)
		{
			return @class.vmethod_2(hMetrics);
		}
		@class = method_5();
		if (@class != null)
		{
			return @class.vmethod_2(hMetrics);
		}
		return new Class6735(IsSymbolicFont);
	}

	internal void method_3(Class5967 charsToNewGlyphIndexes)
	{
		Class6644 @class = method_4();
		if (@class != null)
		{
			((Class6648)@class).method_1(charsToNewGlyphIndexes);
			return;
		}
		Class6648 class2 = new Class6648(3, 1, this);
		class2.method_1(charsToNewGlyphIndexes);
		Class6722 class3 = new Class6722(3, 1, 4, this);
		class3.class6644_0 = class2;
		string key = method_7(3, 1);
		if (!hashtable_0.ContainsKey(key))
		{
			hashtable_0[key] = new List<Class6722>();
		}
		((List<Class6722>)hashtable_0[key]).Add(class3);
	}

	public Class6644 method_4()
	{
		List<Class6644> list = new List<Class6644>();
		bool flag = false;
		foreach (string key in hashtable_0.Keys)
		{
			foreach (Class6722 item in (List<Class6722>)hashtable_0[key])
			{
				Class6644 class6644_ = item.class6644_0;
				switch (class6644_.PlatformID)
				{
				case 0:
					list.Add(class6644_);
					break;
				case 2:
					list.Add(class6644_);
					break;
				case 3:
					if (class6644_.PlatformSpecificID == 0)
					{
						list.Insert(0, class6644_);
						flag = true;
					}
					else if (class6644_.PlatformSpecificID == 1)
					{
						list.Insert(0, class6644_);
						flag = true;
					}
					else if (class6644_.PlatformSpecificID == 10)
					{
						list.Add(class6644_);
					}
					else if (class6644_.PlatformSpecificID == 4)
					{
						list.Add(class6644_);
					}
					break;
				}
				if (flag)
				{
					break;
				}
			}
			if (flag)
			{
				break;
			}
		}
		if (list.Count > 0)
		{
			return list[0];
		}
		return null;
	}

	public Class6644 method_5()
	{
		foreach (DictionaryEntry item in hashtable_0)
		{
			List<Class6722> list = (List<Class6722>)item.Value;
			if (list.Count != 0)
			{
				Class6722 @class = list[0];
				return @class.class6644_0;
			}
		}
		return null;
	}

	internal override void Write(Class5951 writer)
	{
		Class6644 @class = method_4();
		if (@class != null)
		{
			Class6722[] array = new Class6722[1] { method_6(@class) };
			writer.method_3(0);
			writer.method_3((ushort)array.Length);
			int num = 0;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].method_0();
				writer.method_3(array[i].ushort_0);
				writer.method_3(array[i].ushort_1);
				int value = 4 + array.Length * 8 + num;
				writer.method_0(value);
				num += (int)array[i].uint_0;
			}
			for (int j = 0; j < array.Length; j++)
			{
				writer.method_4(array[j].byte_0, 0, array[j].byte_0.Length);
			}
		}
	}

	private Class6722 method_6(Class6644 table)
	{
		foreach (string key in hashtable_0.Keys)
		{
			foreach (Class6722 item in (List<Class6722>)hashtable_0[key])
			{
				if (object.ReferenceEquals(item.class6644_0, table))
				{
					return item;
				}
			}
		}
		return null;
	}

	private string method_7(ushort platformID, ushort platformSpecificID)
	{
		return string.Format(string_2, platformID, platformSpecificID);
	}
}
