using System.Runtime.CompilerServices;
using Aspose.Cells;

namespace ns2;

internal class Class1119
{
	internal CellArea cellArea_0;

	internal int int_0;

	internal int int_1;

	internal int int_2;

	internal int int_3;

	private byte byte_0;

	[SpecialName]
	internal byte method_0()
	{
		return byte_0;
	}

	[SpecialName]
	internal void method_1(byte byte_1)
	{
		byte_0 = byte_1;
	}

	[SpecialName]
	internal void method_2(bool bool_0)
	{
		if (bool_0)
		{
			byte_0 |= 1;
		}
		else
		{
			byte_0 &= 254;
		}
	}

	[SpecialName]
	internal bool method_3()
	{
		return (byte_0 & 0x10) != 0;
	}

	[SpecialName]
	internal void method_4(bool bool_0)
	{
		if (bool_0)
		{
			byte_0 |= 16;
		}
		else
		{
			byte_0 &= 239;
		}
	}

	[SpecialName]
	internal bool method_5()
	{
		return (byte_0 & 0x20) != 0;
	}

	[SpecialName]
	internal void method_6(bool bool_0)
	{
		if (bool_0)
		{
			byte_0 |= 32;
		}
		else
		{
			byte_0 &= 223;
		}
	}

	[SpecialName]
	internal bool method_7()
	{
		return (byte_0 & 8) != 0;
	}

	[SpecialName]
	internal void method_8(bool bool_0)
	{
		if (bool_0)
		{
			byte_0 |= 8;
		}
		else
		{
			byte_0 &= 247;
		}
	}

	[SpecialName]
	internal bool method_9()
	{
		if (!method_7())
		{
			return (byte_0 & 4) != 0;
		}
		return true;
	}

	[SpecialName]
	internal void method_10(bool bool_0)
	{
		if (bool_0)
		{
			byte_0 |= 4;
		}
		else
		{
			byte_0 &= 251;
		}
	}

	[SpecialName]
	internal bool method_11()
	{
		if (!method_7())
		{
			return (byte_0 & 4) == 0;
		}
		return true;
	}

	[SpecialName]
	internal string method_12()
	{
		if (method_9())
		{
			if (int_0 != 65535 && int_1 != 65535)
			{
				return CellsHelper.CellIndexToName(int_0, int_1);
			}
			return "#REF!";
		}
		return null;
	}

	[SpecialName]
	internal void method_13(string string_0)
	{
		CellsHelper.CellNameToIndex(string_0, out int_0, out int_1);
	}

	[SpecialName]
	internal string method_14()
	{
		if (method_11())
		{
			if (int_3 != 65535 && int_2 != 65535)
			{
				return CellsHelper.CellIndexToName(int_2, int_3);
			}
			return "#REF!";
		}
		return null;
	}

	[SpecialName]
	internal void method_15(string string_0)
	{
		CellsHelper.CellNameToIndex(string_0, out int_2, out int_3);
	}
}
