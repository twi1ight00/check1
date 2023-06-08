using System.Collections;
using System.Runtime.CompilerServices;

namespace ns45;

internal class Class1162
{
	internal ushort ushort_0;

	internal ushort ushort_1 = 1024;

	internal ArrayList arrayList_0 = new ArrayList();

	internal bool bool_0;

	internal bool bool_1;

	internal bool bool_2;

	internal bool bool_3;

	internal bool bool_4;

	internal bool bool_5;

	internal bool bool_6;

	internal bool bool_7;

	internal bool bool_8;

	internal bool bool_9;

	internal bool bool_10;

	internal bool bool_11;

	internal bool bool_12;

	internal bool bool_13;

	internal ushort Function
	{
		get
		{
			ushort num = 0;
			if (bool_0)
			{
				num = (ushort)(num | 1u);
			}
			if (bool_1)
			{
				num = (ushort)(num | 2u);
			}
			if (bool_2)
			{
				num = (ushort)(num | 4u);
			}
			if (bool_3)
			{
				num = (ushort)(num | 8u);
			}
			if (bool_4)
			{
				num = (ushort)(num | 0x10u);
			}
			if (bool_5)
			{
				num = (ushort)(num | 0x20u);
			}
			if (bool_6)
			{
				num = (ushort)(num | 0x40u);
			}
			if (bool_7)
			{
				num = (ushort)(num | 0x80u);
			}
			if (bool_8)
			{
				num = (ushort)(num | 0x100u);
			}
			if (bool_9)
			{
				num = (ushort)(num | 0x200u);
			}
			if (bool_10)
			{
				num = (ushort)(num | 0x400u);
			}
			if (bool_11)
			{
				num = (ushort)(num | 0x800u);
			}
			if (bool_12)
			{
				num = (ushort)(num | 0x1000u);
			}
			if (bool_13)
			{
				num = (ushort)(num | 0x4000u);
			}
			return num;
		}
		set
		{
			method_0();
			if ((value & 1) > 0)
			{
				bool_0 = true;
			}
			if ((value & 2) > 0)
			{
				bool_1 = true;
			}
			if ((value & 4) > 0)
			{
				bool_2 = true;
			}
			if ((value & 8) > 0)
			{
				bool_3 = true;
			}
			if ((value & 0x10) > 0)
			{
				bool_4 = true;
			}
			if ((value & 0x20) > 0)
			{
				bool_5 = true;
			}
			if ((value & 0x40) > 0)
			{
				bool_6 = true;
			}
			if ((value & 0x80) > 0)
			{
				bool_7 = true;
			}
			if ((value & 0x100) > 0)
			{
				bool_8 = true;
			}
			if ((value & 0x200) > 0)
			{
				bool_9 = true;
			}
			if ((value & 0x400) > 0)
			{
				bool_10 = true;
			}
			if ((value & 0x800) > 0)
			{
				bool_11 = true;
			}
			if ((value & 0x1000) > 0)
			{
				bool_12 = true;
			}
			if ((value & 0x4000) > 0)
			{
				bool_13 = true;
			}
		}
	}

	private void method_0()
	{
		bool_0 = false;
		bool_1 = false;
		bool_2 = false;
		bool_3 = false;
		bool_4 = false;
		bool_5 = false;
		bool_6 = false;
		bool_7 = false;
		bool_8 = false;
		bool_9 = false;
		bool_10 = false;
		bool_11 = false;
		bool_12 = false;
		bool_13 = false;
	}

	[SpecialName]
	internal ushort method_1()
	{
		ushort num = (ushort)(ushort_1 & 0x3FFu);
		if (num > 255)
		{
			return (ushort)65534;
		}
		return num;
	}

	[SpecialName]
	internal void method_2(ushort ushort_2)
	{
		ushort_1 |= (ushort)(ushort_2 & 0x3FF);
	}

	[SpecialName]
	internal void method_3(byte byte_0)
	{
		ushort_0 |= byte_0;
	}

	[SpecialName]
	internal void method_4(byte byte_0)
	{
		ushort_0 |= (ushort)(byte_0 << 6);
	}

	[SpecialName]
	internal bool method_5()
	{
		return (ushort_1 & 0x400) > 0;
	}

	[SpecialName]
	internal void method_6(bool bool_14)
	{
		if (bool_14)
		{
			ushort_1 |= 1024;
		}
		else
		{
			ushort_1 &= (ushort)64511;
		}
	}
}
