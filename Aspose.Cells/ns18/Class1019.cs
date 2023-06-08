using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using ns22;

namespace ns18;

internal class Class1019
{
	private static readonly byte[] byte_0;

	private static readonly Hashtable hashtable_0;

	private static readonly object object_0;

	private Class1019()
	{
	}

	static Class1019()
	{
		hashtable_0 = new Hashtable();
		object_0 = new object();
		byte_0 = Class1186.smethod_3();
	}

	internal static byte[] smethod_0(HatchBrush hatchBrush_0)
	{
		string key = smethod_2(hatchBrush_0);
		byte[] array;
		lock (object_0)
		{
			array = (byte[])hashtable_0[key];
		}
		if (array == null)
		{
			lock (object_0)
			{
				array = (byte[])hashtable_0[key];
				if (array == null)
				{
					array = smethod_1(hatchBrush_0);
					hashtable_0[key] = array;
				}
			}
		}
		return array;
	}

	private static byte[] smethod_1(HatchBrush hatchBrush_0)
	{
		byte[] array = new byte[8];
		Array.Copy(byte_0, (int)hatchBrush_0.HatchStyle * 8, array, 0, 8);
		using Class1021 @class = new Class1021(8, 8);
		for (int i = 0; i < 8; i++)
		{
			for (int j = 0; j < 8; j++)
			{
				Color color_ = (((array[i] & (128 >> j)) > 0) ? hatchBrush_0.ForegroundColor : hatchBrush_0.BackgroundColor);
				@class.method_1(j, 7 - i, color_);
			}
		}
		MemoryStream stream_ = new MemoryStream();
		@class.Save(stream_, Enum200.const_5);
		return Class936.smethod_1(stream_, bool_0: false);
	}

	private static string smethod_2(HatchBrush hatchBrush_0)
	{
		return $"{hatchBrush_0.HatchStyle}{Class1025.smethod_6(hatchBrush_0.BackgroundColor.ToArgb())}{Class1025.smethod_6(hatchBrush_0.ForegroundColor.ToArgb())}";
	}
}
