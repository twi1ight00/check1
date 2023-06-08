using System.Collections;
using System.IO;
using ns226;
using ns227;
using ns229;
using ns230;
using ns276;

namespace ns232;

internal class Class6133
{
	private class Class6134
	{
		public const int int_0 = 20;

		private long long_0;

		private long long_1;

		private long long_2;

		private byte[] byte_0;

		public void method_0(int tag)
		{
			long_0 = tag;
		}

		public void method_1(int origLength)
		{
			long_1 = origLength;
		}

		public void method_2(long origChecksum)
		{
			long_2 = origChecksum;
		}

		public void method_3(byte[] compTable)
		{
			byte_0 = compTable;
		}

		public int method_4()
		{
			return byte_0.Length;
		}

		public long method_5()
		{
			return long_1;
		}

		public int method_6(Class6017 writableFontData, int tableOffset, int start)
		{
			int num = start;
			num += writableFontData.method_41(num, long_0);
			num += writableFontData.method_41(num, tableOffset);
			num += writableFontData.method_41(num, byte_0.Length);
			num += writableFontData.method_41(num, long_1);
			num += writableFontData.method_41(num, long_2);
			return 20;
		}

		public int method_7(Class6017 writableFontData, int index)
		{
			writableFontData.method_31(index, byte_0, 0, byte_0.Length);
			return method_4();
		}
	}

	private const long long_0 = 2001684038L;

	private const int int_0 = 44;

	protected bool bool_0;

	public Class6017 method_0(Class6020 font)
	{
		ArrayList tableDirectoryEntries = method_1(font);
		int length = 44 + smethod_3(tableDirectoryEntries) + smethod_4(tableDirectoryEntries);
		Class6017 @class = Class6017.smethod_1(length);
		int num = 0;
		num = 0 + smethod_5(@class, 0, tableDirectoryEntries, font.method_0(), length, smethod_0(font), smethod_1(font));
		num += smethod_8(@class, num, tableDirectoryEntries);
		num += smethod_9(@class, num, tableDirectoryEntries);
		return @class;
	}

	private static int smethod_0(Class6020 font)
	{
		Class6031 @class = (Class6031)font.method_6(Class6116.int_2);
		return (@class.method_13() >> 16) & 0xFFFF;
	}

	private static int smethod_1(Class6020 sfntlyFont)
	{
		Class6031 @class = (Class6031)sfntlyFont.method_6(Class6116.int_2);
		return @class.method_13() & 0xFFFF;
	}

	private static int smethod_2(int value)
	{
		return (value + 3) & -4;
	}

	private static int smethod_3(ArrayList tableDirectoryEntries)
	{
		return 20 * tableDirectoryEntries.Count;
	}

	private static int smethod_4(ArrayList tableDirectoryEntries)
	{
		int num = 0;
		foreach (Class6134 tableDirectoryEntry in tableDirectoryEntries)
		{
			num += tableDirectoryEntry.method_4();
			num = smethod_2(num);
		}
		return num;
	}

	private static int smethod_5(Class6017 writableFontData, int start, ArrayList tableDirectoryEntries, int flavor, int length, int majorVersion, int minorVersion)
	{
		int num = start;
		num += writableFontData.method_41(num, 2001684038L);
		num += writableFontData.method_41(num, flavor);
		num += writableFontData.method_41(num, length);
		num += writableFontData.method_37(num, tableDirectoryEntries.Count);
		num += writableFontData.method_37(num, 0);
		num += writableFontData.method_41(num, smethod_7(tableDirectoryEntries) + smethod_6(tableDirectoryEntries));
		num += writableFontData.method_37(num, 1);
		num += writableFontData.method_37(num, 1);
		num += writableFontData.method_41(num, 0L);
		num += writableFontData.method_41(num, 0L);
		num += writableFontData.method_41(num, 0L);
		num += writableFontData.method_41(num, 0L);
		num += writableFontData.method_41(num, 0L);
		return 44;
	}

	private static int smethod_6(ArrayList tableDirectoryEntries)
	{
		return 12 + 16 * tableDirectoryEntries.Count;
	}

	private static int smethod_7(ArrayList tableDirectoryEntries)
	{
		int num = 0;
		foreach (Class6134 tableDirectoryEntry in tableDirectoryEntries)
		{
			num += (int)tableDirectoryEntry.method_5();
			num = smethod_2(num);
		}
		return num;
	}

	private static int smethod_8(Class6017 writableFontData, int start, ArrayList tableDirectoryEntries)
	{
		int num = start;
		int num2 = smethod_2(start + smethod_3(tableDirectoryEntries));
		foreach (Class6134 tableDirectoryEntry in tableDirectoryEntries)
		{
			num += tableDirectoryEntry.method_6(writableFontData, num2, num);
			num2 += tableDirectoryEntry.method_4();
			num2 = smethod_2(num2);
		}
		return smethod_3(tableDirectoryEntries);
	}

	private static int smethod_9(Class6017 writableFontData, int start, ArrayList tableDirectoryEntries)
	{
		int num = smethod_2(start);
		foreach (Class6134 tableDirectoryEntry in tableDirectoryEntries)
		{
			num += tableDirectoryEntry.method_7(writableFontData, num);
			num = smethod_2(num);
		}
		return num - start;
	}

	private ArrayList method_1(Class6020 font)
	{
		ArrayList arrayList = new ArrayList();
		ICollection keys = new SortedList(font.method_7()).Keys;
		foreach (int item in keys)
		{
			Class6026 @class = font.method_6(item);
			Class6134 class2 = new Class6134();
			class2.method_0(item);
			class2.method_1(@class.method_2());
			class2.method_2(@class.method_5());
			method_2(class2, @class);
			arrayList.Add(class2);
		}
		return arrayList;
	}

	private void method_2(Class6134 tableDirectoryEntry, Class6026 table)
	{
		int num = table.method_2();
		byte[] array = new byte[num];
		table.method_0().method_14(0, array, 0, num);
		if (bool_0 && (num < 100 || table.method_7() == Class6116.int_12))
		{
			tableDirectoryEntry.method_3(array);
			return;
		}
		byte[] array2;
		using (MemoryStream memoryStream = new MemoryStream())
		{
			Stream stream = new Stream12(memoryStream, Enum916.const_0, Enum914.const_12);
			using (stream)
			{
				stream.Write(array, 0, array.Length);
			}
			array2 = memoryStream.ToArray();
		}
		tableDirectoryEntry.method_3((array2.Length >= num) ? array : array2);
	}
}
