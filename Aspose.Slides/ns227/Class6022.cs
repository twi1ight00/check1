using System;
using System.Collections;
using System.IO;
using System.Security.Cryptography;
using ns226;

namespace ns227;

internal class Class6022
{
	private enum Enum755
	{
		const_0 = 0,
		const_1 = 4,
		const_2 = 8,
		const_3 = 12,
		const_4 = 0,
		const_5 = 4,
		const_6 = 8
	}

	private static int int_0 = 4;

	private bool bool_0;

	private ArrayList arrayList_0;

	private Class6022()
	{
	}

	public static Class6022 smethod_0()
	{
		return new Class6022();
	}

	public void method_0(bool fingerprint)
	{
		bool_0 = fingerprint;
	}

	public bool method_1()
	{
		return bool_0;
	}

	public Class6020[] method_2(StreamReader @is)
	{
		if (smethod_1(@is))
		{
			return method_5(@is);
		}
		return new Class6020[1] { method_4(@is) };
	}

	public Class6020.Class6021[] method_3(StreamReader @is)
	{
		if (smethod_1(@is))
		{
			return method_7(@is);
		}
		return new Class6020.Class6021[1] { method_6(@is) };
	}

	private Class6020 method_4(StreamReader @is)
	{
		return method_6(@is).method_4();
	}

	private Class6020[] method_5(StreamReader @is)
	{
		Class6020.Class6021[] array = method_7(@is);
		Class6020[] array2 = new Class6020[array.Length];
		for (int i = 0; i < array2.Length; i++)
		{
			array2[i] = array[i].method_4();
		}
		return array2;
	}

	private Class6020.Class6021 method_6(StreamReader @is)
	{
		if (method_1())
		{
			try
			{
				new SHA1Managed();
			}
			catch (Exception innerException)
			{
				throw new IOException("Unable to get requested message digest algorithm.", innerException);
			}
		}
		return Class6020.Class6021.smethod_0(this, @is);
	}

	private Class6020.Class6021[] method_7(StreamReader @is)
	{
		Class6017 @class = Class6017.smethod_1((int)@is.BaseStream.Length);
		@class.CopyFrom(@is);
		return method_13(@class);
	}

	private static bool smethod_1(StreamReader pbis)
	{
		byte[] array = new byte[4];
		pbis.BaseStream.Read(array, 0, array.Length);
		pbis.BaseStream.Position -= 4L;
		return Class6116.int_0 == Class6116.smethod_1(array);
	}

	public Class6020[] method_8(byte[] b)
	{
		Class6017 @class = Class6017.smethod_2(b);
		if (smethod_2(@class))
		{
			return method_11(@class);
		}
		return new Class6020[1] { method_10(@class) };
	}

	public Class6020.Class6021[] method_9(byte[] b)
	{
		Class6017 @class = Class6017.smethod_2(b);
		if (smethod_2(@class))
		{
			return method_13(@class);
		}
		return new Class6020.Class6021[1] { method_12(@class, 0) };
	}

	private Class6020 method_10(Class6017 wfd)
	{
		return method_12(wfd, 0).method_4();
	}

	private Class6020[] method_11(Class6017 wfd)
	{
		Class6020.Class6021[] array = method_13(wfd);
		Class6020[] array2 = new Class6020[array.Length];
		for (int i = 0; i < array2.Length; i++)
		{
			array2[i] = array[i].method_4();
		}
		return array2;
	}

	private Class6020.Class6021 method_12(Class6017 wfd, int offsetToOffsetTable)
	{
		method_1();
		return Class6020.Class6021.smethod_1(this, wfd, offsetToOffsetTable);
	}

	private Class6020.Class6021[] method_13(Class6017 wfd)
	{
		wfd.method_20(0);
		wfd.method_23(4);
		int num = wfd.method_20(8);
		Class6020.Class6021[] array = new Class6020.Class6021[num];
		int num2 = 12;
		int num3 = 0;
		while (num3 < num)
		{
			int offsetToOffsetTable = wfd.method_20(num2);
			array[num3] = method_12(wfd, offsetToOffsetTable);
			num3++;
			num2 += 4;
		}
		return array;
	}

	private static bool smethod_2(Class6016 rfd)
	{
		byte[] array = new byte[4];
		rfd.method_14(0, array, 0, array.Length);
		return Class6116.int_0 == Class6116.smethod_1(array);
	}

	public void method_14(Class6020 font, StreamWriter os)
	{
		font.method_9(os, arrayList_0);
	}

	public void method_15(ArrayList tableOrdering)
	{
		arrayList_0 = new ArrayList(tableOrdering);
	}

	public Class6020.Class6021 method_16()
	{
		return Class6020.Class6021.smethod_2(this);
	}
}
