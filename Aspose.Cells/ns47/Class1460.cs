using System;
using System.Collections;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using ns16;

namespace ns47;

internal class Class1460
{
	private Class1454 class1454_0;

	private string string_0;

	private string string_1;

	private string string_2;

	private string string_3;

	private string string_4;

	private Class1464 class1464_0;

	private FontStyle fontStyle_0;

	private int int_0;

	private int int_1;

	private int int_2;

	private int int_3;

	private int int_4;

	private int int_5;

	private int int_6;

	private int int_7;

	private int int_8;

	private int int_9;

	private int int_10;

	private int int_11;

	private int int_12;

	private int int_13;

	private int int_14;

	private float float_0;

	private int int_15;

	private ushort ushort_0;

	private Class1459 class1459_0;

	private Class1459 class1459_1;

	private Class1076 class1076_0;

	private bool bool_0;

	private Class1457 class1457_0;

	private bool bool_1;

	private Class1070 class1070_0;

	private bool bool_2;

	private bool bool_3;

	internal ArrayList arrayList_0 = new ArrayList();

	private static Hashtable hashtable_0 = Hashtable.Synchronized(new Hashtable());

	private static Hashtable hashtable_1 = Hashtable.Synchronized(new Hashtable());

	public string FileName
	{
		get
		{
			return string_4;
		}
		set
		{
			string_4 = value;
		}
	}

	public FontStyle Style
	{
		get
		{
			return fontStyle_0;
		}
		set
		{
			fontStyle_0 = value;
		}
	}

	public int Height => int_1 + int_2;

	[SpecialName]
	public string method_0()
	{
		return string_0;
	}

	[SpecialName]
	public void method_1(string string_5)
	{
		string_0 = string_5;
	}

	[SpecialName]
	public void method_2(string string_5)
	{
		string_1 = string_5;
	}

	[SpecialName]
	public string method_3()
	{
		return string_2;
	}

	[SpecialName]
	public void method_4(string string_5)
	{
		string_2 = string_5;
	}

	[SpecialName]
	public string method_5()
	{
		return string_3;
	}

	[SpecialName]
	public void method_6(string string_5)
	{
		string_3 = string_5;
	}

	[SpecialName]
	public Class1464 method_7()
	{
		return class1464_0;
	}

	[SpecialName]
	public void method_8(Class1464 class1464_1)
	{
		class1464_0 = class1464_1;
	}

	[SpecialName]
	public int method_9()
	{
		return int_0;
	}

	[SpecialName]
	public void method_10(int int_16)
	{
		int_0 = int_16;
	}

	[SpecialName]
	public int method_11()
	{
		return int_1;
	}

	[SpecialName]
	public void method_12(int int_16)
	{
		int_1 = int_16;
	}

	[SpecialName]
	public int method_13()
	{
		return int_2;
	}

	[SpecialName]
	public void method_14(int int_16)
	{
		int_2 = int_16;
	}

	[SpecialName]
	public int method_15()
	{
		return int_3;
	}

	[SpecialName]
	public void method_16(int int_16)
	{
		int_3 = int_16;
	}

	public float method_17(float float_1)
	{
		return method_46(method_15(), float_1);
	}

	[SpecialName]
	public void method_18(int int_16)
	{
		int_4 = int_16;
	}

	public float method_19(float float_1)
	{
		return method_46(method_13(), float_1);
	}

	[SpecialName]
	public void method_20(int int_16)
	{
		int_6 = int_16;
	}

	[SpecialName]
	public void method_21(int int_16)
	{
		int_7 = int_16;
	}

	[SpecialName]
	public void method_22(int int_16)
	{
		int_8 = int_16;
	}

	[SpecialName]
	public void method_23(int int_16)
	{
		int_9 = int_16;
	}

	[SpecialName]
	public void method_24(int int_16)
	{
		int_5 = int_16;
	}

	[SpecialName]
	public int method_25()
	{
		return int_10;
	}

	[SpecialName]
	public void method_26(int int_16)
	{
		int_10 = int_16;
	}

	[SpecialName]
	internal Class1070 method_27()
	{
		return class1070_0;
	}

	[SpecialName]
	internal void method_28(Class1070 class1070_1)
	{
		class1070_0 = class1070_1;
	}

	[SpecialName]
	public int method_29()
	{
		return int_11;
	}

	[SpecialName]
	public void method_30(int int_16)
	{
		int_11 = int_16;
	}

	[SpecialName]
	public int method_31()
	{
		return int_12;
	}

	[SpecialName]
	public void method_32(int int_16)
	{
		int_12 = int_16;
	}

	[SpecialName]
	public int method_33()
	{
		return int_13;
	}

	[SpecialName]
	public void method_34(int int_16)
	{
		int_13 = int_16;
	}

	[SpecialName]
	public int method_35()
	{
		return int_14;
	}

	[SpecialName]
	public void method_36(int int_16)
	{
		int_14 = int_16;
	}

	[SpecialName]
	public float method_37()
	{
		return float_0;
	}

	[SpecialName]
	public void method_38(float float_1)
	{
		float_0 = float_1;
	}

	public int method_39(char char_0)
	{
		return class1464_0.method_1(char_0).method_1();
	}

	public int method_40(string string_5)
	{
		int num = 0;
		for (int i = 0; i < string_5.Length; i++)
		{
			Class1463 @class = class1464_0.method_1(string_5[i]);
			num += @class.method_2();
		}
		return num;
	}

	public float method_41(char char_0, float float_1)
	{
		Class1463 @class = class1464_0.method_1(char_0);
		return (float)@class.method_2() * float_1 / (float)method_9() * 1.3334f;
	}

	public float method_42(char char_0, float float_1)
	{
		int num = (int)((float_1 * 20f * 96f + 720f) / 1440f);
		num = ~num + 1;
		return method_61(-num, char_0, (int)float_1).int_6;
	}

	public float method_43(string string_5, float float_1)
	{
		int num = (int)((float_1 * 20f * 96f + 720f) / 1440f);
		num = ~num + 1;
		int num2 = 0;
		foreach (char char_ in string_5)
		{
			num2 += method_61(-num, char_, (int)float_1).int_6;
		}
		return (float)num2 / 1.3333f;
	}

	public int method_44(string string_5, float float_1)
	{
		int num = (int)((float_1 * 20f * 96f + 720f) / 1440f);
		num = ~num + 1;
		int num2 = 0;
		foreach (char char_ in string_5)
		{
			num2 += method_61(-num, char_, (int)float_1).int_6;
		}
		return num2;
	}

	public float method_45(string string_5, float float_1)
	{
		return method_46(method_40(string_5), float_1);
	}

	public float method_46(float float_1, float float_2)
	{
		float num = (float)method_9() / float_2;
		return float_1 / num;
	}

	[SpecialName]
	public Class1454 method_47()
	{
		return class1454_0;
	}

	[SpecialName]
	public void method_48(Class1454 class1454_1)
	{
		class1454_0 = class1454_1;
	}

	[SpecialName]
	public int method_49()
	{
		return int_15;
	}

	[SpecialName]
	public void method_50(int int_16)
	{
		int_15 = int_16;
	}

	[SpecialName]
	public void method_51(ushort ushort_1)
	{
		ushort_0 = ushort_1;
	}

	[SpecialName]
	internal void method_52(Class1457 class1457_1)
	{
		class1457_0 = class1457_1;
	}

	[SpecialName]
	internal Class1076 method_53()
	{
		return class1076_0;
	}

	[SpecialName]
	internal void method_54(Class1076 class1076_1)
	{
		class1076_0 = class1076_1;
	}

	[SpecialName]
	internal void method_55(bool bool_4)
	{
		bool_0 = bool_4;
	}

	[SpecialName]
	internal void method_56(Class1459 class1459_2)
	{
		class1459_0 = class1459_2;
	}

	[SpecialName]
	internal Class1459 method_57()
	{
		return class1459_1;
	}

	[SpecialName]
	internal void method_58(Class1459 class1459_2)
	{
		class1459_1 = class1459_2;
	}

	[SpecialName]
	internal bool method_59()
	{
		return bool_1;
	}

	[SpecialName]
	internal void method_60(bool bool_4)
	{
		bool_1 = bool_4;
	}

	internal Struct76 method_61(int int_16, char char_0, int int_17)
	{
		Struct76 result = default(Struct76);
		int num = int_16;
		int num2 = int_16;
		if (num >= 65535)
		{
			num = 65535;
		}
		if (num2 >= 65535)
		{
			num2 = 65535;
		}
		num <<= 6;
		num2 <<= 6;
		int num3;
		int num4 = (num3 = method_9());
		int num5 = num;
		int num6 = num2;
		result.int_0 = Class1075.smethod_1(num5, num4);
		result.int_1 = Class1075.smethod_1(num6, num3);
		result.ushort_0 = (ushort)(num5 + 32 >> 6);
		result.ushort_1 = (ushort)(num6 + 32 >> 6);
		result.int_2 = Class1075.smethod_4(Class1075.smethod_0(method_11(), result.int_1));
		result.int_3 = Class1075.smethod_2(Class1075.smethod_0(-method_13(), result.int_1));
		result.int_4 = Class1075.smethod_3(Class1075.smethod_0(Height, result.int_1));
		result.int_5 = Class1075.smethod_3(Class1075.smethod_0(method_49(), result.int_0));
		method_57();
		int int_18 = method_39(char_0);
		int num7 = smethod_1(int_18, int_16, method_53());
		if (num7 > 0)
		{
			int num8 = num7 << 6;
			num8 = Class1075.smethod_3(num8);
			result.int_6 = num8 + 63 >> 6;
		}
		else
		{
			Class1463 @class = method_7().method_1(char_0);
			int num8 = @class.method_2();
			num8 = Class1075.smethod_0(num8, result.int_0);
			num8 = Class1075.smethod_3(num8);
			result.int_6 = num8 + 63 >> 6;
			byte[] array = method_63(method_0(), int_17, Style);
			if (array != null && array.Length > 0 && char_0 <= '\u007f' && char_0 >= ' ')
			{
				int num9 = array[(int_17 - 2) * 96 + char_0 - 32];
				if (num9 > 128)
				{
					num9 -= 256;
				}
				result.int_6 += num9;
			}
		}
		result.int_2 = result.int_2 + 32 >> 6;
		result.int_3 = Math.Abs(result.int_3) + 32 >> 6;
		result.int_4 = result.int_2 + result.int_3 + 1;
		return result;
	}

	internal static Size smethod_0(string string_5, int int_16, string string_6, FontStyle fontStyle_1)
	{
		int num = (int_16 * 20 * 96 + 720) / 1440;
		num = ~num + 1;
		Class1460 @class = Class1462.smethod_3(string_5, fontStyle_1, bool_0: false);
		Size result = default(Size);
		foreach (char char_ in string_6)
		{
			Struct76 @struct = @class.method_61(-num, char_, int_16);
			result.Width += @struct.int_6;
			int int_17 = -1;
			if (@class.method_62(string_5, int_16, fontStyle_1, ref int_17))
			{
				@struct.int_4 = int_17;
			}
			else
			{
				@struct.int_4 = (int)(@class.method_46(@class.method_15(), int_16) * 1.3333f);
			}
			if (result.Height < @struct.int_4)
			{
				result.Height = @struct.int_4;
			}
		}
		return result;
	}

	internal bool method_62(string string_5, int int_16, FontStyle fontStyle_1, ref int int_17)
	{
		if (int_16 >= 2 && int_16 <= 33)
		{
			string key = string_5 + int_16 + fontStyle_1;
			lock (hashtable_0)
			{
				object obj = hashtable_0[key];
				if (obj == null)
				{
					Class744 @class = Class1462.class746_0.method_38(string_5 + ".dat");
					if (@class == null)
					{
						hashtable_0[key] = -1;
						return false;
					}
					BinaryReader binaryReader = new BinaryReader(Class1462.class746_0.method_39(@class));
					int num = 0;
					if ((fontStyle_1 & FontStyle.Bold) != 0)
					{
						num = 32;
					}
					byte[] array = binaryReader.ReadBytes(64);
					int_17 = array[int_16 + num - 2];
					hashtable_0[string_5 + int_16 + fontStyle_1] = int_17;
				}
				else
				{
					if ((int)obj == -1)
					{
						return false;
					}
					int_17 = (int)hashtable_0[key];
				}
			}
			return true;
		}
		return false;
	}

	private byte[] method_63(string string_5, int int_16, FontStyle fontStyle_1)
	{
		if (int_16 >= 2 && int_16 <= 33)
		{
			switch (fontStyle_1)
			{
			case FontStyle.Regular:
				string_5 += "_Regular.diff";
				break;
			case FontStyle.Bold:
				string_5 += "_Bold.diff";
				break;
			case FontStyle.Italic:
				string_5 += "_Bold.diff";
				break;
			case FontStyle.Bold | FontStyle.Italic:
				string_5 += "_Bold, Italic.diff";
				break;
			}
			byte[] array = null;
			lock (hashtable_1)
			{
				if (hashtable_1[string_5] == null)
				{
					Class744 @class = Class1462.class746_0.method_38(string_5);
					if (@class == null)
					{
						array = new byte[0];
						hashtable_1[string_5] = array;
						return array;
					}
					BinaryReader binaryReader = new BinaryReader(Class1462.class746_0.method_39(@class));
					array = new byte[(int)@class.Size];
					binaryReader.Read(array, 0, array.Length);
					hashtable_1[string_5] = array;
				}
				else
				{
					array = (byte[])hashtable_1[string_5];
				}
			}
			return array;
		}
		return null;
	}

	private static int smethod_1(int int_16, int int_17, Class1076 class1076_1)
	{
		if (class1076_1.struct77_0 != null && class1076_1.struct77_0.Length > 0)
		{
			Struct77[] struct77_ = class1076_1.struct77_0;
			for (int i = 0; i < struct77_.Length; i++)
			{
				Struct77 @struct = struct77_[i];
				if (@struct.byte_0 == int_17 && int_16 < @struct.byte_2.Length)
				{
					return @struct.byte_2[int_16];
				}
			}
		}
		return -1;
	}

	[SpecialName]
	internal bool method_64()
	{
		return bool_2;
	}

	[SpecialName]
	internal void method_65(bool bool_4)
	{
		bool_2 = bool_4;
	}

	[SpecialName]
	internal void method_66(bool bool_4)
	{
		bool_3 = bool_4;
	}

	[SpecialName]
	public int method_67()
	{
		return int_0;
	}
}
