using System;
using System.Collections;
using ns183;
using ns184;

namespace ns206;

internal class Class5450
{
	private Class5449 class5449_0;

	private Class5449 class5449_1;

	private Class5449 class5449_2;

	public void method_0(string fontFamily)
	{
		Class5449 @class = Class5449.smethod_0(fontFamily);
		if (@class != null)
		{
			class5449_0 = @class;
		}
	}

	public void method_1(string fontStyle)
	{
		Class5449 @class = Class5449.smethod_0(fontStyle);
		if (@class != null)
		{
			class5449_1 = @class;
		}
	}

	public void method_2(string fontWeight)
	{
		Class5449 @class = Class5449.smethod_0(fontWeight);
		if (@class == null)
		{
			return;
		}
		foreach (object item in @class)
		{
			if (item is string)
			{
				string text = ((string)item).Trim();
				try
				{
					Class5453.smethod_0(text);
				}
				catch (ArgumentException)
				{
					return;
				}
			}
		}
		class5449_2 = @class;
	}

	public Class5449 method_3()
	{
		return class5449_0;
	}

	public Class5449 method_4()
	{
		if (class5449_1 == null)
		{
			return Class5449.smethod_0(Class5729.string_0);
		}
		return class5449_1;
	}

	public Class5449 method_5()
	{
		if (class5449_2 == null)
		{
			return Class5449.smethod_0(Class5729.int_2.ToString());
		}
		return class5449_2;
	}

	public bool method_6()
	{
		return class5449_2 != null;
	}

	public bool method_7()
	{
		return class5449_1 != null;
	}

	protected ArrayList method_8(Class5730 fontInfo)
	{
		Class5449 arrayList = method_3();
		Class5449 arrayList2 = method_5();
		Class5449 arrayList3 = method_4();
		ArrayList arrayList4 = new ArrayList();
		Interface208 @interface = new Class5495(arrayList);
		while (@interface.imethod_0())
		{
			string text = (string)@interface.imethod_1();
			Hashtable hashtable = fontInfo.method_23();
			if (hashtable == null)
			{
				continue;
			}
			foreach (Class5732 key in hashtable.Keys)
			{
				string text2 = key.method_0();
				if (!text.ToLower().Equals(text2.ToLower()))
				{
					continue;
				}
				bool flag = false;
				int num = key.method_2();
				Interface208 interface2 = new Class5495(arrayList2);
				while (interface2.imethod_0())
				{
					object obj = interface2.imethod_1();
					if (obj is Class5454)
					{
						Class5454 class2 = (Class5454)obj;
						if (class2.method_0(num))
						{
							flag = true;
						}
					}
					else if (obj is string)
					{
						string text3 = (string)obj;
						int num2 = Class5453.smethod_0(text3);
						if (num2 == num)
						{
							flag = true;
						}
					}
					else if (obj is int num3 && num3 == num)
					{
						flag = true;
					}
				}
				bool flag2 = false;
				string text4 = key.method_1();
				Interface208 interface3 = new Class5495(arrayList3);
				while (interface3.imethod_0())
				{
					string value = (string)interface3.imethod_1();
					if (text4.Equals(value))
					{
						flag2 = true;
					}
				}
				if (flag && flag2)
				{
					arrayList4.Add(key);
				}
			}
		}
		return arrayList4;
	}

	internal Class5732 method_9(Class5730 fontInfo)
	{
		ArrayList arrayList = method_8(fontInfo);
		Class5732 @class = null;
		if (arrayList.Count == 1)
		{
			@class = (Class5732)arrayList[0];
		}
		else
		{
			Interface208 @interface = new Class5495(arrayList);
			while (@interface.imethod_0())
			{
				Class5732 class2 = (Class5732)@interface.imethod_1();
				if (@class == null)
				{
					@class = class2;
					continue;
				}
				int num = class2.method_3();
				if (num < @class.method_3())
				{
					@class = class2;
				}
			}
		}
		return @class;
	}

	public ArrayList method_10()
	{
		ArrayList arrayList = new ArrayList();
		Class5449 arrayList2 = method_3();
		Interface208 @interface = new Class5495(arrayList2);
		while (@interface.imethod_0())
		{
			string name = (string)@interface.imethod_1();
			Class5449 arrayList3 = method_4();
			Interface208 interface2 = new Class5495(arrayList3);
			while (interface2.imethod_0())
			{
				string style = (string)interface2.imethod_1();
				Class5449 arrayList4 = method_5();
				Interface208 interface3 = new Class5495(arrayList4);
				while (interface3.imethod_0())
				{
					object obj = interface3.imethod_1();
					if (obj is Class5454)
					{
						Class5454 @class = (Class5454)obj;
						int[] array = @class.method_1();
						for (int i = 0; i < array.Length; i++)
						{
							arrayList.Add(new Class5732(name, style, array[i], Class5729.int_6));
						}
					}
					else if (obj is string)
					{
						string text = (string)obj;
						int weight = Class5453.smethod_0(text);
						arrayList.Add(new Class5732(name, style, weight, Class5729.int_6));
					}
					else if (obj is int weight2)
					{
						arrayList.Add(new Class5732(name, style, weight2, Class5729.int_6));
					}
				}
			}
		}
		return arrayList;
	}

	public override string ToString()
	{
		string text = string.Empty;
		if (class5449_0 != null)
		{
			text = text + "font-family=" + class5449_0;
		}
		if (class5449_1 != null)
		{
			if (text.Length > 0)
			{
				text += ", ";
			}
			text = text + "font-style=" + class5449_1;
		}
		if (class5449_2 != null)
		{
			if (text.Length > 0)
			{
				text += ", ";
			}
			text = text + "font-weight=" + class5449_2;
		}
		return text;
	}
}
