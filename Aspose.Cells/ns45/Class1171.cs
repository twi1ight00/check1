using System.Collections;
using System.Runtime.CompilerServices;

namespace ns45;

internal class Class1171
{
	internal byte byte_0;

	internal byte byte_1;

	internal ushort ushort_0;

	internal ushort ushort_1;

	internal ArrayList arrayList_0;

	internal byte byte_2;

	internal byte byte_3;

	internal byte byte_4;

	internal byte byte_5;

	internal bool bool_0;

	internal Class1171()
	{
		arrayList_0 = new ArrayList();
		byte_1 = byte.MaxValue;
		ushort_0 = 528;
		ushort_1 = 0;
	}

	[SpecialName]
	internal bool method_0()
	{
		return (ushort_0 & 0x200) != 0;
	}

	[SpecialName]
	internal void method_1(bool bool_1)
	{
		if (bool_1)
		{
			ushort_0 |= 512;
		}
		else
		{
			ushort_0 &= (ushort)65023;
		}
	}

	[SpecialName]
	internal bool method_2()
	{
		return (ushort_0 & 0x400) != 0;
	}

	[SpecialName]
	internal void method_3(bool bool_1)
	{
		if (bool_1)
		{
			ushort_0 |= 1024;
		}
		else
		{
			ushort_0 &= (ushort)64511;
		}
	}

	[SpecialName]
	internal bool method_4()
	{
		return (ushort_0 & 0x800) != 0;
	}

	[SpecialName]
	internal void method_5(bool bool_1)
	{
		if (bool_1)
		{
			ushort_0 |= 2048;
		}
		else
		{
			ushort_0 &= (ushort)63487;
		}
	}

	[SpecialName]
	internal bool method_6()
	{
		return (ushort_0 & 0x1000) != 0;
	}

	[SpecialName]
	internal void method_7(bool bool_1)
	{
		if (bool_1)
		{
			ushort_0 |= 4096;
		}
		else
		{
			ushort_0 &= (ushort)61439;
		}
	}

	[SpecialName]
	internal bool method_8()
	{
		return (ushort_0 & 0x4000) != 0;
	}

	[SpecialName]
	internal void method_9(bool bool_1)
	{
		if (bool_1)
		{
			ushort_0 |= 16384;
		}
		else
		{
			ushort_0 &= (ushort)49151;
		}
	}

	[SpecialName]
	internal byte method_10()
	{
		return (byte)(ushort_0 & 0xFu);
	}

	[SpecialName]
	internal void method_11(byte byte_6)
	{
		ushort_0 |= byte_6;
	}

	[SpecialName]
	internal byte method_12()
	{
		return (byte)((ushort_0 & 0xF0) >> 4);
	}

	[SpecialName]
	internal void method_13(byte byte_6)
	{
		ushort_0 &= 65295;
		ushort_0 |= (ushort)(byte_6 << 4);
	}

	[SpecialName]
	internal bool method_14()
	{
		return (ushort_1 & 1) != 0;
	}

	[SpecialName]
	internal void method_15(bool bool_1)
	{
		if (bool_1)
		{
			ushort_0 |= 1;
		}
		else
		{
			ushort_0 &= (ushort)65534;
		}
	}

	[SpecialName]
	internal bool method_16()
	{
		return (ushort_0 & 0x100) != 0;
	}

	[SpecialName]
	internal void method_17(bool bool_1)
	{
		if (bool_1)
		{
			ushort_0 |= 256;
		}
		else
		{
			ushort_0 &= (ushort)65279;
		}
	}
}
