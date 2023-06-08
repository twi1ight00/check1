using System;
using System.Collections;
using System.IO;
using System.Text;
using ns225;
using ns226;
using ns228;
using ns229;
using ns230;
using ns231;

namespace ns227;

internal class Class6020
{
	private enum Enum750
	{
		const_0 = 0,
		const_1 = 4,
		const_2 = 6,
		const_3 = 8,
		const_4 = 10,
		const_5 = 12,
		const_6 = 12,
		const_7 = 0,
		const_8 = 4,
		const_9 = 8,
		const_10 = 12,
		const_11 = 16
	}

	public enum Enum751
	{
		const_0 = -1,
		const_1,
		const_2,
		const_3,
		const_4,
		const_5
	}

	public enum Enum752
	{
		const_0 = -1,
		const_1,
		const_2,
		const_3,
		const_4,
		const_5,
		const_6
	}

	public enum Enum753
	{
		const_0 = -1,
		const_1 = 0,
		const_2 = 1,
		const_3 = 2,
		const_4 = 3,
		const_5 = 4,
		const_6 = 5,
		const_7 = 6,
		const_8 = 10
	}

	public enum Enum754
	{
		const_0 = -1,
		const_1,
		const_2,
		const_3,
		const_4,
		const_5,
		const_6,
		const_7,
		const_8,
		const_9,
		const_10,
		const_11,
		const_12,
		const_13,
		const_14,
		const_15,
		const_16,
		const_17,
		const_18,
		const_19,
		const_20,
		const_21,
		const_22,
		const_23,
		const_24,
		const_25,
		const_26,
		const_27,
		const_28,
		const_29,
		const_30,
		const_31,
		const_32,
		const_33
	}

	internal class Class6021
	{
		private Hashtable hashtable_0;

		private Class6022 class6022_0;

		private int int_0 = Class6020.int_0;

		private int int_1;

		private int int_2;

		private int int_3;

		private int int_4;

		private Hashtable hashtable_1;

		private byte[] byte_0;

		private Class6021(Class6022 factory)
		{
			class6022_0 = factory;
			hashtable_0 = new Hashtable();
		}

		private void method_0(StreamReader @is)
		{
			if (@is == null)
			{
				throw new IOException("No input stream for font.");
			}
			Class6018 @class = null;
			try
			{
				@class = new Class6018(@is);
				ArrayList headers = method_15(@class);
				hashtable_1 = smethod_7(headers, @class);
				hashtable_0 = smethod_3(hashtable_1);
			}
			finally
			{
				@class.Is.Close();
			}
		}

		private void method_1(Class6017 wfd, int offsetToOffsetTable)
		{
			if (wfd == null)
			{
				throw new IOException("No data for font.");
			}
			ArrayList headers = method_16(wfd, offsetToOffsetTable);
			hashtable_1 = smethod_8(headers, wfd);
			hashtable_0 = smethod_3(hashtable_1);
		}

		internal static Class6021 smethod_0(Class6022 factory, StreamReader @is)
		{
			Class6021 @class = new Class6021(factory);
			@class.method_0(@is);
			return @class;
		}

		internal static Class6021 smethod_1(Class6022 factory, Class6017 wfd, int offsetToOffsetTable)
		{
			Class6021 @class = new Class6021(factory);
			@class.method_1(wfd, offsetToOffsetTable);
			return @class;
		}

		internal static Class6021 smethod_2(Class6022 factory)
		{
			return new Class6021(factory);
		}

		public Class6022 method_2()
		{
			return class6022_0;
		}

		public bool method_3()
		{
			if (hashtable_0 == null && hashtable_1 != null && hashtable_1.Count > 0)
			{
				return true;
			}
			foreach (Class6026.Class6055 value in hashtable_0.Values)
			{
				if (!value.method_5())
				{
					return false;
				}
			}
			return true;
		}

		public Class6020 method_4()
		{
			Hashtable hashtable = null;
			Class6020 @class = new Class6020(int_0, byte_0);
			if (hashtable_0.Count > 0)
			{
				hashtable = smethod_5(@class, hashtable_0);
			}
			@class.hashtable_0 = hashtable;
			hashtable_0 = null;
			hashtable_1 = null;
			return @class;
		}

		public void method_5(byte[] digest)
		{
			byte_0 = digest;
		}

		public void method_6()
		{
			hashtable_0.Clear();
		}

		public bool method_7(int tag)
		{
			return hashtable_0.ContainsKey(tag);
		}

		public Class6026.Class6055 method_8(int tag)
		{
			return (Class6026.Class6055)hashtable_0[tag];
		}

		public Class6026.Class6055 method_9(int tag)
		{
			Class6110 @class = new Class6110(tag);
			Class6026.Class6055 class2 = Class6026.Class6055.smethod_0(@class, null);
			hashtable_0.Add(@class.method_0(), class2);
			return class2;
		}

		public Class6026.Class6055 method_10(int tag, Class6016 srcData)
		{
			Class6017 @class = Class6017.smethod_1(srcData.method_2());
			srcData.CopyTo(@class);
			Class6110 header = new Class6110(tag, @class.method_2());
			Class6026.Class6055 class2 = Class6026.Class6055.smethod_0(header, @class);
			hashtable_0.Add(tag, class2);
			return class2;
		}

		public Hashtable method_11()
		{
			return hashtable_0;
		}

		public Class6026.Class6055 method_12(int tag)
		{
			Class6026.Class6055 result = (Class6026.Class6055)hashtable_0[tag];
			hashtable_0.Remove(tag);
			return result;
		}

		public int method_13()
		{
			return hashtable_0.Count;
		}

		private int method_14()
		{
			return 12 + 16 * hashtable_0.Count;
		}

		private static Hashtable smethod_3(Hashtable tableData)
		{
			Hashtable hashtable = new Hashtable();
			foreach (Class6110 key in tableData.Keys)
			{
				Class6026.Class6055 value = smethod_4(key, (Class6017)tableData[key]);
				hashtable.Add(key.method_0(), value);
			}
			smethod_6(hashtable);
			return hashtable;
		}

		private static Class6026.Class6055 smethod_4(Class6110 header, Class6017 data)
		{
			return Class6026.Class6055.smethod_0(header, data);
		}

		private static Hashtable smethod_5(Class6020 font, Hashtable builderMap)
		{
			Hashtable hashtable = new Hashtable();
			smethod_6(builderMap);
			long num = 0L;
			bool flag = false;
			Class6031.Class6060 @class = null;
			foreach (Class6026.Class6055 value in builderMap.Values)
			{
				Class6026 class3 = null;
				if (Class6116.smethod_5(value.method_16().method_0()))
				{
					@class = (Class6031.Class6060)value;
					continue;
				}
				if (value.method_5())
				{
					flag |= value.method_8();
					class3 = (Class6026)value.vmethod_0();
				}
				if (class3 != null)
				{
					long num2 = class3.method_5();
					num += num2;
					hashtable.Add(class3.method_6().method_0(), class3);
					continue;
				}
				throw new Exception("Unable to build table - " + value);
			}
			Class6026 class4 = null;
			if (@class != null)
			{
				if (flag)
				{
					@class.method_18(num);
				}
				if (@class.method_5())
				{
					flag |= @class.method_8();
					class4 = (Class6026)@class.vmethod_0();
				}
				if (class4 == null)
				{
					throw new Exception("Unable to build table - " + @class);
				}
				num += class4.method_5();
				hashtable.Add(class4.method_6().method_0(), class4);
			}
			font.long_0 = num & 0xFFFFFFFFL;
			return hashtable;
		}

		private static void smethod_6(Hashtable builderMap)
		{
			Class6031.Class6060 @class = (Class6031.Class6060)builderMap[Class6116.int_2];
			Class6033.Class6062 class2 = (Class6033.Class6062)builderMap[Class6116.int_3];
			Class6035.Class6064 class3 = (Class6035.Class6064)builderMap[Class6116.int_5];
			Class6040.Class6072 class4 = (Class6040.Class6072)builderMap[Class6116.int_12];
			Class6034.Class6063 class5 = (Class6034.Class6063)builderMap[Class6116.int_4];
			Class6032.Class6061 class6 = (Class6032.Class6061)builderMap[Class6116.int_26];
			if (class5 != null)
			{
				if (class3 != null)
				{
					class5.method_19(class3.method_20());
				}
				if (class2 != null)
				{
					class5.method_18(class2.method_42());
				}
			}
			if (class4 != null)
			{
				if (class3 != null)
				{
					class4.method_28(class3.method_20());
				}
				if (@class != null)
				{
					class4.method_23(@class.method_58());
				}
			}
			if (class6 != null && class3 != null)
			{
				class6.method_18(class3.method_20());
			}
		}

		private ArrayList method_15(Class6018 fis)
		{
			ArrayList arrayList = new ArrayList();
			int_0 = fis.method_8();
			int_1 = fis.method_2();
			int_2 = fis.method_2();
			int_3 = fis.method_2();
			int_4 = fis.method_2();
			for (int i = 0; i < int_1; i++)
			{
				Class6110 value = new Class6110(fis.method_6(), fis.method_5(), fis.method_6(), fis.method_6());
				arrayList.Add(value);
			}
			arrayList.Sort(Class6110.class6111_0);
			return arrayList;
		}

		private static Hashtable smethod_7(ArrayList headers, Class6018 fis)
		{
			Hashtable hashtable = new Hashtable();
			foreach (Class6110 header in headers)
			{
				fis.method_10(header.method_1() - fis.method_0());
				Class6018 class2 = new Class6018(fis.Is, header.method_3());
				Class6017 class3 = Class6017.smethod_1(header.method_3());
				class3.CopyFrom(class2.Is, header.method_3());
				hashtable.Add(header, class3);
			}
			return hashtable;
		}

		private ArrayList method_16(Class6016 fd, int offset)
		{
			ArrayList arrayList = new ArrayList();
			int_0 = fd.method_23(offset);
			int_1 = fd.method_16(offset + 4);
			int_2 = fd.method_16(offset + 6);
			int_3 = fd.method_16(offset + 8);
			int_4 = fd.method_16(offset + 10);
			int num = offset + 12;
			int num2 = 0;
			while (num2 < int_1)
			{
				Class6110 value = new Class6110(fd.method_20(num), fd.method_19(num + 4), fd.method_20(num + 8), fd.method_20(num + 12));
				arrayList.Add(value);
				num2++;
				num += 16;
			}
			arrayList.Sort(Class6110.class6111_0);
			return arrayList;
		}

		private static Hashtable smethod_8(ArrayList headers, Class6017 fd)
		{
			Hashtable hashtable = new Hashtable(headers.Count);
			foreach (Class6110 header in headers)
			{
				Class6017 value = (Class6017)fd.vmethod_0(header.method_1(), header.method_3());
				hashtable.Add(header, value);
			}
			return hashtable;
		}
	}

	private static ArrayList arrayList_0;

	private static ArrayList arrayList_1;

	public static int int_0;

	private int int_1;

	private byte[] byte_0;

	private long long_0;

	private Hashtable hashtable_0;

	static Class6020()
	{
		arrayList_0 = new ArrayList();
		arrayList_1 = new ArrayList();
		int_0 = Class6023.smethod_2(1, 0);
		int[] array = new int[8]
		{
			Class6116.int_2,
			Class6116.int_3,
			Class6116.int_5,
			Class6116.int_7,
			Class6116.int_6,
			Class6116.int_1,
			Class6116.int_8,
			Class6116.int_14
		};
		int[] array2 = array;
		foreach (int num in array2)
		{
			arrayList_0.Add(num);
		}
		int[] array3 = new int[20]
		{
			Class6116.int_2,
			Class6116.int_3,
			Class6116.int_5,
			Class6116.int_7,
			Class6116.int_4,
			Class6116.int_28,
			Class6116.int_30,
			Class6116.int_26,
			Class6116.int_1,
			Class6116.int_10,
			Class6116.int_13,
			Class6116.int_9,
			Class6116.int_12,
			Class6116.int_11,
			Class6116.int_27,
			Class6116.int_6,
			Class6116.int_8,
			Class6116.int_25,
			Class6116.int_29,
			Class6116.int_24
		};
		int[] array4 = array3;
		foreach (int num2 in array4)
		{
			arrayList_1.Add(num2);
		}
	}

	private Class6020(int sfntVersion, byte[] digest)
	{
		int_1 = sfntVersion;
		byte_0 = digest;
	}

	public int method_0()
	{
		return int_1;
	}

	public byte[] method_1()
	{
		if (byte_0 == null)
		{
			return null;
		}
		byte[] array = new byte[byte_0.Length];
		Array.Copy(byte_0, array, byte_0.Length);
		return array;
	}

	public long method_2()
	{
		return long_0;
	}

	public int method_3()
	{
		return hashtable_0.Count;
	}

	public Interface256 method_4()
	{
		return new Class6011(hashtable_0.Values);
	}

	public bool method_5(int tag)
	{
		return hashtable_0.ContainsKey(tag);
	}

	public Class6026 method_6(int tag)
	{
		return (Class6026)hashtable_0[tag];
	}

	public Hashtable method_7()
	{
		return hashtable_0;
	}

	public string method_8()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("digest = ");
		byte[] array = method_1();
		if (array != null)
		{
			for (int i = 0; i < array.Length; i++)
			{
				int num = 0xFF & array[i];
				if (num < 16)
				{
					stringBuilder.Append("0");
				}
				stringBuilder.Append($"{num:x}");
			}
		}
		stringBuilder.Append("\n[");
		stringBuilder.Append(Class6023.smethod_3(int_1));
		stringBuilder.Append(", ");
		stringBuilder.Append(method_3());
		stringBuilder.Append("]\n");
		Interface256 @interface = method_4();
		while (@interface.imethod_0())
		{
			Class6025 value = (Class6025)@interface.imethod_1();
			stringBuilder.Append("\t");
			stringBuilder.Append(value);
			stringBuilder.Append("\n");
		}
		return stringBuilder.ToString();
	}

	internal void method_9(StreamWriter os, ArrayList tableOrdering)
	{
		ArrayList tableOrdering2 = method_13(tableOrdering);
		ArrayList tableHeaders = method_10(tableOrdering2);
		Class6019 fos = new Class6019(os);
		method_11(fos, tableHeaders);
		method_12(fos, tableHeaders);
	}

	private ArrayList method_10(ArrayList tableOrdering)
	{
		ArrayList arrayList = method_13(tableOrdering);
		ArrayList arrayList2 = new ArrayList(method_3());
		int num = 12 + method_3() * 16;
		foreach (int item in arrayList)
		{
			Class6026 @class = (Class6026)hashtable_0[item];
			if (@class != null)
			{
				arrayList2.Add(new Class6110(item, @class.method_5(), num, @class.method_6().method_3()));
				num += (@class.method_2() + 3) & -4;
			}
		}
		return arrayList2;
	}

	private void method_11(Class6019 fos, ArrayList tableHeaders)
	{
		fos.method_7(int_1);
		fos.method_2(tableHeaders.Count);
		int num = Class6024.smethod_0(tableHeaders.Count);
		int num2 = 2 << num - 1 + 4;
		fos.method_2(num2);
		fos.method_2(num);
		fos.method_2(tableHeaders.Count * 16 - num2);
		ArrayList arrayList = new ArrayList(tableHeaders);
		arrayList.Sort(Class6110.class6112_0);
		foreach (Class6110 item in arrayList)
		{
			fos.method_5(item.method_0());
			fos.method_5(item.method_5());
			fos.method_5(item.method_1());
			fos.method_5(item.method_3());
		}
	}

	private void method_12(Class6019 fos, ArrayList tableHeaders)
	{
		foreach (Class6110 tableHeader in tableHeaders)
		{
			Class6026 class2 = method_6(tableHeader.method_0());
			if (class2 != null)
			{
				int num = class2.method_3(fos.Out);
				int num2 = ((num + 3) & -4) - num;
				for (int i = 0; i < num2; i++)
				{
					fos.Write(0);
				}
				continue;
			}
			throw new IOException("Table out of sync with font header.");
		}
	}

	private ArrayList method_13(ArrayList defaultTableOrdering)
	{
		ArrayList arrayList = new ArrayList(hashtable_0.Count);
		if (defaultTableOrdering == null)
		{
			defaultTableOrdering = method_14();
		}
		ArrayList arrayList2 = new ArrayList();
		foreach (int key in hashtable_0.Keys)
		{
			arrayList2.Add(key);
		}
		foreach (int item in defaultTableOrdering)
		{
			if (method_5(item))
			{
				arrayList.Add(item);
				arrayList2.Remove(item);
			}
		}
		foreach (int item2 in arrayList2)
		{
			arrayList.Add(item2);
		}
		return arrayList;
	}

	private ArrayList method_14()
	{
		if (method_5(Class6116.int_14))
		{
			return arrayList_0;
		}
		return arrayList_1;
	}
}
