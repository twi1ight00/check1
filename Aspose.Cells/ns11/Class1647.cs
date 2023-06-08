using System;
using System.Runtime.CompilerServices;

namespace ns11;

internal class Class1647
{
	private bool bool_0;

	private ulong ulong_0;

	private ushort ushort_0;

	private Class1650 class1650_0;

	private ushort[] ushort_1;

	private byte[] byte_0;

	private Class1651 class1651_0;

	internal byte[] byte_1;

	internal byte[] byte_2;

	internal string string_0;

	public Class1647(string string_1, byte[] byte_3, byte[] byte_4, byte[] byte_5)
	{
		if (byte_3.Length == 16 && byte_4.Length == 16 && byte_5.Length == 16)
		{
			if (string_1.Length == 0 || string_1.Length > 15)
			{
				throw new ArgumentException("Invalid password length: should be 1-15 characters.");
			}
			ushort_0 = 0;
			bool_0 = false;
			ulong_0 = 4294967295uL;
			class1651_0 = new Class1651();
			ushort_1 = new ushort[16];
			byte_0 = new byte[16];
			class1650_0 = new Class1650();
			method_3(string_1, byte_3, byte_4, byte_5);
			return;
		}
		throw new ArgumentException();
	}

	private void Update(Class1651 class1651_1, ushort ushort_2)
	{
		if (bool_0)
		{
			uint num = class1651_1.method_1();
			if (ulong_0 != num || ushort_0 != ushort_2)
			{
				method_1(ulong_0, num, ushort_2);
				ulong_0 = num;
				ushort_0 = ushort_2;
			}
		}
	}

	internal byte[] method_0(byte[] byte_3, ushort ushort_2, ushort ushort_3, uint uint_0)
	{
		if (byte_3 != null && ushort_3 > 0 && ushort_2 + ushort_3 <= byte_3.Length)
		{
			byte[] array = new byte[ushort_3];
			class1651_0.method_0(byte_3, ushort_2, uint_0);
			if (bool_0)
			{
				Update(class1651_0, ushort_0);
				method_2(class1651_0, array, ushort_3);
				ulong_0 = class1651_0.method_1();
			}
			else
			{
				class1651_0.Read(array, 0, ushort_3);
			}
			return array;
		}
		throw new ArgumentException();
	}

	private void method_1(ulong ulong_1, ulong ulong_2, ushort ushort_2)
	{
		if (ulong_2 != ulong_1)
		{
			uint num = method_4(ulong_1);
			ushort num2 = method_5(ulong_1);
			uint num3 = method_4(ulong_2);
			ushort num4 = method_5(ulong_2);
			if (num3 != num || num4 < num2)
			{
				class1650_0.method_2(num3);
				num2 = 0;
			}
			if (num4 > num2)
			{
				class1650_0.method_4((uint)(num4 - num2));
			}
		}
	}

	private ushort method_2(Class1651 class1651_1, byte[] byte_3, ushort ushort_2)
	{
		ushort num = 0;
		ushort num2 = 0;
		ushort num3 = ushort_2;
		while (num3 > 0)
		{
			ushort val = (ushort)(1024 - method_5(class1651_1.method_1()));
			ushort num4 = Math.Min(num3, val);
			num = (ushort)(num + (ushort)class1651_1.Read(byte_3, num2, num4));
			class1650_0.method_3(byte_3, num2, num4, byte_3, num2, num4);
			if (method_5(class1651_1.method_1()) == 0)
			{
				class1650_0.method_2(method_4(class1651_1.method_1()));
			}
			num2 = (ushort)(num2 + num4);
			num3 = (ushort)(num3 - num4);
		}
		return num;
	}

	private void method_3(string string_1, byte[] byte_3, byte[] byte_4, byte[] byte_5)
	{
		int length = string_1.Length;
		Array.Clear(ushort_1, 0, ushort_1.Length);
		for (int i = 0; i < length; i++)
		{
			ushort_1[i] = string_1[i];
		}
		Array.Copy(byte_3, byte_0, byte_3.Length);
		class1650_0.method_0(ushort_1, byte_0);
		class1650_0.method_1(byte_4, byte_5);
		bool_0 = true;
		byte_1 = byte_4;
		byte_2 = byte_5;
		string_0 = string_1;
	}

	private uint method_4(ulong ulong_1)
	{
		return (uint)(ulong_1 / 1024uL);
	}

	private ushort method_5(ulong ulong_1)
	{
		return (ushort)(ulong_1 % 1024uL);
	}

	[SpecialName]
	internal byte[] method_6()
	{
		return byte_0;
	}
}
