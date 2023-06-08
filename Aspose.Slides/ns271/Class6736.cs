using System;
using System.Collections;
using System.IO;
using ns218;
using ns276;

namespace ns271;

internal class Class6736
{
	private class Class6737
	{
		internal uint uint_0;

		internal uint uint_1;

		internal uint uint_2;

		internal uint uint_3;

		internal uint uint_4;

		internal uint uint_5;

		internal void Read(Class5950 reader)
		{
			uint_0 = reader.method_1();
			uint_1 = reader.method_1();
			uint_2 = reader.method_1();
			uint_3 = reader.method_1();
			uint_4 = reader.method_1();
		}
	}

	private class Class6738 : IComparer
	{
		public int Compare(object x, object y)
		{
			Class6737 @class = x as Class6737;
			Class6737 class2 = y as Class6737;
			return @class.uint_0.CompareTo(class2.uint_0);
		}
	}

	private class Class6739
	{
		internal uint uint_0;

		internal uint uint_1;

		internal uint uint_2;

		internal ushort ushort_0;

		internal uint uint_3;

		internal ushort ushort_1;

		internal ushort ushort_2;

		internal uint uint_4;

		internal uint uint_5;

		internal uint uint_6;

		internal uint uint_7;

		internal uint uint_8;

		internal void Read(Class5950 reader)
		{
			uint_0 = reader.method_1();
			if (uint_0 != 2001684038)
			{
				throw new NotSupportedException("Unsupported woff signature version.");
			}
			uint_1 = reader.method_1();
			uint_2 = reader.method_1();
			ushort_0 = reader.method_3();
			reader.method_3();
			uint_3 = reader.method_1();
			ushort_1 = reader.method_3();
			ushort_2 = reader.method_3();
			uint_4 = reader.method_1();
			uint_5 = reader.method_1();
			uint_6 = reader.method_1();
			uint_7 = reader.method_1();
			uint_8 = reader.method_1();
		}
	}

	private static int smethod_0(int value)
	{
		return (value + 3) & -4;
	}

	private static int smethod_1(int max)
	{
		int i;
		for (i = 0; Math.Pow(2.0, i) < (double)max; i++)
		{
		}
		return i - 1;
	}

	public void method_0(Stream woff, Stream ttf)
	{
		Class5950 reader = new Class5950(woff);
		BinaryWriter binaryWriter = new BinaryWriter(ttf);
		Class6739 @class = new Class6739();
		@class.Read(reader);
		Class6737[] array = new Class6737[@class.ushort_0];
		for (int i = 0; i < array.Length; i++)
		{
			Class6737 class2 = new Class6737();
			class2.Read(reader);
			array[i] = class2;
		}
		Array.Sort(array, new Class6738());
		int value = 12 + @class.ushort_0 * 16;
		Class6737[] array2 = array;
		foreach (Class6737 class3 in array2)
		{
			value = (int)((class3.uint_5 = (uint)smethod_0(value)) + class3.uint_3);
		}
		binaryWriter.Write(Class5952.smethod_1(@class.uint_1));
		ushort ushort_ = @class.ushort_0;
		binaryWriter.Write(Class5952.smethod_3(ushort_));
		ushort num = (ushort)smethod_1(ushort_);
		ushort num2 = (ushort)(num * 16);
		binaryWriter.Write(Class5952.smethod_3(num2));
		binaryWriter.Write(Class5952.smethod_3(num));
		binaryWriter.Write(Class5952.smethod_3((ushort)(ushort_ * 16 - num2)));
		Class6737[] array3 = array;
		foreach (Class6737 class4 in array3)
		{
			binaryWriter.Write(Class5952.smethod_1(class4.uint_0));
			binaryWriter.Write(Class5952.smethod_1(class4.uint_4));
			binaryWriter.Write(Class5952.smethod_1(class4.uint_5));
			binaryWriter.Write(Class5952.smethod_1(class4.uint_3));
		}
		Class6737[] array4 = array;
		foreach (Class6737 class5 in array4)
		{
			int num3 = (int)(class5.uint_5 - binaryWriter.BaseStream.Position);
			if (num3 > 0)
			{
				binaryWriter.Write(new byte[num3]);
			}
			binaryWriter.Write(smethod_2(reader, class5));
		}
		ttf.Flush();
	}

	private static byte[] smethod_2(Class5950 reader, Class6737 entry)
	{
		reader.BaseStream.Seek(entry.uint_1, SeekOrigin.Begin);
		byte[] array = reader.method_8((int)entry.uint_2);
		if (entry.uint_3 > entry.uint_2)
		{
			Stream12 stream = new Stream12(new MemoryStream(array), Enum916.const_1);
			byte[] array2 = new byte[entry.uint_3];
			stream.Read(array2, 0, array2.Length);
			array = array2;
		}
		return array;
	}
}
