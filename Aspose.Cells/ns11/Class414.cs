using System;
using System.Runtime.CompilerServices;
using ns2;

namespace ns11;

internal class Class414
{
	internal string string_0;

	internal byte[] byte_0;

	internal byte[] byte_1;

	internal int int_0 = 100000;

	[SpecialName]
	internal int method_0()
	{
		if (string_0 == null && byte_0 != null)
		{
			return BitConverter.ToUInt16(byte_0, 0);
		}
		return 0;
	}

	[SpecialName]
	internal void method_1(int int_1)
	{
		byte_0 = BitConverter.GetBytes((ushort)int_1);
		string_0 = null;
		byte_1 = null;
	}

	internal void Copy(Class414 class414_0)
	{
		string_0 = class414_0.string_0;
		byte_0 = class414_0.byte_0;
		byte_1 = class414_0.byte_1;
		int_0 = class414_0.int_0;
	}

	internal bool method_2(string string_1)
	{
		if (string_0 == null)
		{
			int num = method_0();
			if (string_1 != null && !(string_1 == ""))
			{
				if (num == (ushort)Class1652.smethod_0(string_1))
				{
					return true;
				}
				return false;
			}
			return num == 0;
		}
		return Class1115.smethod_0(string_1, string_0, byte_0, byte_1, int_0);
	}
}
