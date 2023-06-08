using System;

namespace ns45;

internal class Class1172
{
	internal string string_0;

	internal byte[] byte_0;

	internal ushort ushort_0;

	internal bool IsSelected
	{
		get
		{
			return ushort_0 == 0;
		}
		set
		{
			if (value)
			{
				ushort_0 = 0;
			}
			else
			{
				ushort_0 = 1;
			}
		}
	}

	internal Class1172(string string_1)
	{
		string_0 = string_1;
		ushort_0 = 0;
		byte_0 = new byte[14]
		{
			0, 0, 1, 0, 1, 0, 0, 0, 0, 0,
			2, 0, 16, 0
		};
	}

	internal Class1172()
	{
		string_0 = "";
		ushort_0 = 0;
		byte_0 = new byte[14]
		{
			0, 0, 1, 0, 1, 0, 0, 0, 0, 0,
			2, 0, 16, 0
		};
	}

	internal void Copy(Class1172 class1172_0)
	{
		string_0 = class1172_0.string_0;
		if (class1172_0.byte_0 != null)
		{
			byte_0 = new byte[class1172_0.byte_0.Length];
			Array.Copy(class1172_0.byte_0, 0, byte_0, 0, byte_0.Length);
		}
		ushort_0 = class1172_0.ushort_0;
	}
}
