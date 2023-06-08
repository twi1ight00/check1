using System;
using ns154;
using ns99;

namespace ns102;

internal class Class4738 : Interface114, Interface115
{
	private Class4485 class4485_0;

	private Class4413 class4413_0;

	private Class4716 class4716_0;

	private Interface123 interface123_0;

	private object object_0 = new object();

	private object object_1 = new object();

	internal Class4716 EncodingArray => class4716_0;

	internal Interface123 UnicodeList
	{
		get
		{
			if (interface123_0 == null)
			{
				lock (object_0)
				{
					if (interface123_0 == null)
					{
						interface123_0 = Class4479.Instance;
					}
				}
			}
			return interface123_0;
		}
		set
		{
			interface123_0 = value;
		}
	}

	internal Class4738(Class4413 font)
	{
		class4716_0 = new Class4716();
		class4413_0 = font;
	}

	public Class4506 imethod_3(char charCode)
	{
		string value = EncodingArray[charCode];
		return new Class4507(value);
	}

	public Class4506 imethod_4(Interface129 parameters, char charCode)
	{
		throw new NotSupportedException();
	}

	public void imethod_1(ushort gid, char charCode)
	{
		throw new NotSupportedException();
	}

	public char imethod_0(Class4506 gid)
	{
		Class4507 @class = gid as Class4507;
		if (@class != null)
		{
			return UnicodeList.imethod_5(@class.Value);
		}
		return '\0';
	}

	public Class4506 imethod_2(char unicode)
	{
		int num = UnicodeList.imethod_0(unicode);
		int num2 = 0;
		string text;
		while (true)
		{
			if (num2 < num)
			{
				text = UnicodeList.imethod_1(unicode, num2);
				if (imethod_5().ContainsKey(text) && imethod_5()[text] != 0)
				{
					break;
				}
				num2++;
				continue;
			}
			return Class4507.class4507_0;
		}
		return new Class4507(text);
	}

	public Class4485 imethod_5()
	{
		if (class4485_0 == null)
		{
			lock (object_1)
			{
				if (class4485_0 == null)
				{
					class4485_0 = new Class4485();
					for (int i = 0; i < 256; i++)
					{
						if (EncodingArray[i] != null && !class4485_0.ContainsKey(EncodingArray[i]))
						{
							class4485_0.Add(EncodingArray[i], i);
						}
					}
				}
			}
		}
		return class4485_0;
	}
}
