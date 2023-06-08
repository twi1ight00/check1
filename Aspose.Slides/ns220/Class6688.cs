using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using ns218;
using ns221;
using ns233;
using ns234;
using ns271;

namespace ns220;

internal abstract class Class6688
{
	private int int_0;

	private int int_1;

	private readonly StringBuilder stringBuilder_0 = new StringBuilder();

	private readonly string string_0;

	private readonly Hashtable hashtable_0 = new Hashtable();

	private readonly Hashtable hashtable_1 = new Hashtable();

	private readonly Class5968 class5968_0 = new Class5968();

	private readonly Hashtable hashtable_2 = new Hashtable();

	private readonly Hashtable hashtable_3 = new Hashtable();

	private Class5956 class5956_0 = new Class5956();

	private List<Class5974> list_0 = new List<Class5974>();

	internal Class5956 Info
	{
		get
		{
			return class5956_0;
		}
		set
		{
			class5956_0 = value;
		}
	}

	internal Class5968 FontSubsets => class5968_0;

	internal IList<Class5974> Warnings => list_0;

	protected Hashtable ImageResources => hashtable_0;

	protected Class6688(string resourcesFolderAlias)
	{
		string_0 = resourcesFolderAlias;
	}

	internal virtual string vmethod_0(Class6730 font)
	{
		return method_6(font);
	}

	internal virtual Class6696 AddImage(byte[] imageBytes, Class6145 crop)
	{
		imageBytes = method_3(imageBytes);
		int num = Class6145.smethod_1(imageBytes, crop);
		Class6696 @class = (Class6696)hashtable_0[num];
		if (@class == null)
		{
			if (crop != null && crop.HasPositiveCrop)
			{
				using Class6150 palImage = crop.method_3(imageBytes);
				imageBytes = Class6697.smethod_0(palImage);
			}
			@class = new Class6696(method_5(imageBytes), Class6148.smethod_3(imageBytes), imageBytes);
			hashtable_0[num] = @class;
		}
		return @class;
	}

	[Attribute7(true)]
	internal virtual void vmethod_1()
	{
	}

	internal string method_0(string originalName)
	{
		string text = (string)hashtable_3[originalName];
		if (text != null)
		{
			return text;
		}
		text = $"bookmark_{int_0++}";
		hashtable_3[originalName] = text;
		return text;
	}

	internal string method_1(Class6730 font, string text)
	{
		Class6733 @class = method_4(font);
		stringBuilder_0.Length = 0;
		for (int i = 0; i < text.Length; i++)
		{
			if (@class.method_0(text[i]) >= 0)
			{
				stringBuilder_0.Append(text[i]);
			}
		}
		return stringBuilder_0.ToString();
	}

	internal void method_2(Enum743 warningType, string description)
	{
		list_0.Add(new Class5974(warningType, description));
	}

	private byte[] method_3(byte[] imageBytes)
	{
		int hashCode = imageBytes.GetHashCode();
		byte[] array = (byte[])hashtable_1[hashCode];
		if (array == null)
		{
			array = Class6697.smethod_1(imageBytes);
			hashtable_1[hashCode] = array;
		}
		return array;
	}

	private Class6733 method_4(Class6730 font)
	{
		string key = method_6(font);
		Class6733 @class = (Class6733)class5968_0[key];
		if (@class == null)
		{
			@class = new Class6733(font, isFullEmbedding: false);
			class5968_0[key] = @class;
		}
		return @class;
	}

	private string method_5(byte[] imageBytes)
	{
		Enum788 imageType = Class6148.smethod_0(imageBytes);
		string fileName = $"image{method_8()}.{Class6148.smethod_1(imageType)}";
		return method_7(fileName);
	}

	private string method_6(Class6730 font)
	{
		string text = hashtable_2[font.Data] as string;
		if (text == null)
		{
			byte[] array = new byte[16];
			Class5964.smethod_1(smethod_0(font.FamilyName), array, 0);
			Class5964.smethod_1((int)font.Style, array, 4);
			string arg = new Guid(array).ToString("D");
			text = method_7(string.Format("{0}.{1}", arg, "odttf"));
			hashtable_2.Add(font.Data, text);
		}
		return text;
	}

	private string method_7(string fileName)
	{
		return Class5973.smethod_12(string_0, fileName);
	}

	private static int smethod_0(string str)
	{
		int num = 352654597;
		int num2 = 352654597;
		int num3 = 0;
		for (int num4 = str.Length; num4 > 0; num4 -= 4)
		{
			int num5 = str[num3];
			int num6 = 0;
			if (num4 > 1)
			{
				num6 = str[num3 + 1];
			}
			int num7 = 0;
			if (num4 > 2)
			{
				num7 = str[num3 + 2];
			}
			int num8 = 0;
			if (num4 > 3)
			{
				num8 = str[num3 + 3];
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

	private int method_8()
	{
		return ++int_1;
	}
}
