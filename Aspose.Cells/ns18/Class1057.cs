using System;
using System.Collections;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using ns22;
using ns47;

namespace ns18;

internal abstract class Class1057
{
	private int int_0;

	private int int_1;

	private readonly StringBuilder stringBuilder_0 = new StringBuilder();

	private readonly string string_0;

	private readonly Hashtable hashtable_0 = new Hashtable();

	private readonly Hashtable hashtable_1 = new Hashtable();

	private readonly Hashtable hashtable_2 = new Hashtable();

	private readonly Hashtable hashtable_3 = new Hashtable();

	private readonly Hashtable hashtable_4 = new Hashtable();

	private Class1012 class1012_0 = new Class1012();

	protected Class1057(string string_1)
	{
		string_0 = string_1;
	}

	internal virtual string vmethod_0(Class1460 class1460_0)
	{
		return method_5(class1460_0);
	}

	internal virtual Class1063 vmethod_1(byte[] byte_0)
	{
		byte_0 = method_1(byte_0);
		int num = Class1014.smethod_0(byte_0);
		Class1063 @class = (Class1063)hashtable_0[num];
		if (@class == null)
		{
			@class = new Class1063(method_4(byte_0), Class1404.smethod_4(byte_0), byte_0);
			hashtable_0[num] = @class;
		}
		return @class;
	}

	[Attribute0(true)]
	internal virtual void vmethod_2()
	{
	}

	internal string method_0(string string_1)
	{
		string text = (string)hashtable_4[string_1];
		if (text != null)
		{
			return text;
		}
		text = $"bookmark_{int_0++}";
		hashtable_4[string_1] = text;
		return text;
	}

	private byte[] method_1(byte[] byte_0)
	{
		int hashCode = byte_0.GetHashCode();
		byte[] array = (byte[])hashtable_1[hashCode];
		if (array == null)
		{
			array = Class1064.smethod_0(byte_0);
			hashtable_1[hashCode] = array;
		}
		return array;
	}

	internal string method_2(Class1460 class1460_0, string string_1)
	{
		Class1077 @class = method_3(class1460_0);
		stringBuilder_0.Length = 0;
		for (int i = 0; i < string_1.Length; i++)
		{
			if (@class.method_0(string_1[i]) >= 0)
			{
				stringBuilder_0.Append(string_1[i]);
			}
		}
		return stringBuilder_0.ToString();
	}

	private Class1077 method_3(Class1460 class1460_0)
	{
		string key = method_5(class1460_0);
		Class1077 @class = (Class1077)hashtable_2[key];
		if (@class == null)
		{
			@class = new Class1077(class1460_0, bool_0: false);
			hashtable_2[key] = @class;
		}
		return @class;
	}

	private string method_4(byte[] byte_0)
	{
		Enum200 enum200_ = Class1404.smethod_1(byte_0);
		string string_ = $"image{method_7()}.{Class1404.smethod_2(enum200_)}";
		return method_6(string_);
	}

	private string method_5(Class1460 class1460_0)
	{
		string text = (string)hashtable_3[class1460_0.FileName];
		if (text == null)
		{
			byte[] array = new byte[16];
			Class1015.smethod_4(smethod_0(class1460_0.method_0()), array, 0);
			Class1015.smethod_4((int)class1460_0.Style, array, 4);
			Guid guid = new Guid(array);
			string arg = "od" + Path.GetExtension(class1460_0.FileName).TrimStart('.').ToLower();
			string arg2 = guid.ToString("D");
			text = method_6($"{arg2}.{arg}");
			hashtable_3.Add(class1460_0.FileName, text);
		}
		return text;
	}

	private string method_6(string string_1)
	{
		return Class1399.smethod_5(string_0, string_1);
	}

	private static int smethod_0(string string_1)
	{
		int num = 352654597;
		int num2 = 352654597;
		int num3 = 0;
		for (int num4 = string_1.Length; num4 > 0; num4 -= 4)
		{
			int num5 = string_1[num3];
			int num6 = 0;
			if (num4 > 1)
			{
				num6 = string_1[num3 + 1];
			}
			int num7 = 0;
			if (num4 > 2)
			{
				num7 = string_1[num3 + 2];
			}
			int num8 = 0;
			if (num4 > 3)
			{
				num8 = string_1[num3 + 3];
			}
			int num9 = num6;
			num9 <<= 16;
			num9 += num5;
			int num10 = num8;
			num10 <<= 16;
			num10 += num7;
			num = ((num << 5) + num + (num >> 27)) ^ num9;
			if (num4 <= 2)
			{
				break;
			}
			num2 = ((num2 << 5) + num2 + (num2 >> 27)) ^ num10;
			num3 += 4;
		}
		return num + num2 * 1566083941;
	}

	private int method_7()
	{
		return ++int_1;
	}

	[SpecialName]
	internal Class1012 method_8()
	{
		return class1012_0;
	}

	[SpecialName]
	internal Hashtable method_9()
	{
		return hashtable_2;
	}

	[SpecialName]
	protected Hashtable method_10()
	{
		return hashtable_0;
	}
}
