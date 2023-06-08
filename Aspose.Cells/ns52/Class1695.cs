using System;
using System.Runtime.CompilerServices;

namespace ns52;

internal class Class1695
{
	private byte[] byte_0;

	private byte[] byte_1;

	internal int int_0;

	internal byte byte_2;

	internal byte byte_3;

	private Class1696 class1696_0;

	private ushort ushort_0;

	private short short_0;

	internal byte byte_4 = byte.MaxValue;

	internal uint Length
	{
		get
		{
			if (method_6() == null)
			{
				return 0u;
			}
			return (uint)(method_8() + method_6().Length);
		}
	}

	[SpecialName]
	internal byte[] method_0()
	{
		return byte_0;
	}

	[SpecialName]
	internal void method_1(byte[] byte_5)
	{
		byte_0 = byte_5;
	}

	internal Class1695(Class1696 class1696_1, byte[] byte_5, int int_1)
	{
		class1696_0 = class1696_1;
		byte_1 = byte_5;
		byte_2 = 0;
		byte_3 = 254;
		int_0 = int_1;
		switch (class1696_0.method_11())
		{
		case 2:
			ushort_0 = 61466;
			short_0 = 980;
			break;
		case 3:
			ushort_0 = 61467;
			short_0 = 534;
			break;
		default:
			throw new ArgumentException("Unsupported image format.");
		case 5:
			ushort_0 = 61469;
			short_0 = 1130;
			break;
		case 6:
			ushort_0 = 61470;
			short_0 = 1760;
			break;
		case 7:
			ushort_0 = 61471;
			short_0 = 1960;
			break;
		}
	}

	internal Class1695(Class1696 class1696_1)
	{
		class1696_0 = class1696_1;
	}

	internal void Copy(Class1695 class1695_0)
	{
		if (class1695_0.byte_1 == null)
		{
			byte_1 = null;
		}
		else
		{
			byte_1 = new byte[class1695_0.byte_1.Length];
			Array.Copy(class1695_0.byte_1, 0, byte_1, 0, byte_1.Length);
		}
		byte_2 = class1695_0.byte_2;
		byte_3 = class1695_0.byte_3;
		int_0 = class1695_0.int_0;
		ushort_0 = class1695_0.ushort_0;
		short_0 = class1695_0.short_0;
		if (class1695_0.byte_0 != null)
		{
			byte_0 = new byte[class1695_0.byte_0.Length];
			Array.Copy(class1695_0.byte_0, byte_0, class1695_0.byte_0.Length);
		}
		else
		{
			byte_0 = null;
		}
	}

	[SpecialName]
	internal ushort method_2()
	{
		return ushort_0;
	}

	[SpecialName]
	internal void method_3(ushort ushort_1)
	{
		ushort_0 = ushort_1;
	}

	[SpecialName]
	internal short method_4()
	{
		return short_0;
	}

	[SpecialName]
	internal void method_5(short short_1)
	{
		short_0 = short_1;
	}

	[SpecialName]
	internal byte[] method_6()
	{
		return byte_1;
	}

	[SpecialName]
	internal void method_7(byte[] byte_5)
	{
		byte_1 = byte_5;
	}

	[SpecialName]
	internal int method_8()
	{
		if (method_6() == null)
		{
			return 0;
		}
		int num = 0;
		if (byte_0 != null)
		{
			num += 16;
		}
		if (method_9())
		{
			return num + 50;
		}
		return num + 17;
	}

	[SpecialName]
	internal bool method_9()
	{
		switch (class1696_0.method_11())
		{
		default:
			return false;
		case 2:
		case 3:
		case 4:
			return true;
		}
	}
}
