using ns143;
using ns99;

namespace ns101;

internal class Class4691 : Interface114
{
	private Class4411 class4411_0;

	private char[] char_0;

	internal Class4691(Class4411 font)
	{
		class4411_0 = font;
	}

	public char imethod_0(Class4506 gid)
	{
		Class4508 @class = gid as Class4508;
		if (@class != null)
		{
			Class4625 class2 = class4411_0.TTFTables.CMapTable.method_4();
			if (class2 != null && (class2.PlatformID != 3 || class2.PlatformSpecificID != 0))
			{
				if (char_0 == null)
				{
					char_0 = new char[class4411_0.TTFTables.MaxpTable.NumGlyphs];
					for (char c = '\0'; c <= '\uffff'; c = (char)(c + 1))
					{
						int num = class2.vmethod_2(c);
						if (num != 0)
						{
							char_0[num] = c;
						}
						if (c >= '\uffff')
						{
							break;
						}
					}
				}
				if (@class.Value >= 0 && @class.Value < class4411_0.TTFTables.MaxpTable.NumGlyphs)
				{
					return char_0[@class.Value];
				}
			}
			else if (class4411_0.TTFTables.PostTable != null)
			{
				string text = class4411_0.TTFTables.PostTable.method_2(@class.Value);
				if (text != ".notdef")
				{
					return Class4479.Instance.imethod_5(text);
				}
			}
		}
		return '\0';
	}

	public void imethod_1(ushort gid, char charCode)
	{
		class4411_0.TTFTables.CMapTable.method_5(charCode, gid);
	}

	public Class4506 imethod_2(char unicode)
	{
		return imethod_3(unicode);
	}

	public Class4506 imethod_3(char unicode)
	{
		Class4508 result = null;
		Class4625 @class = class4411_0.TTFTables.CMapTable.method_4();
		if (@class != null)
		{
			int num = @class.vmethod_2(unicode);
			if (num < class4411_0.NumGlyphs)
			{
				if (num == 0 && unicode < 'Ā')
				{
					num = @class.vmethod_2((char)(61440 + unicode));
				}
			}
			else
			{
				num = 0;
			}
			result = new Class4508(num);
		}
		return result;
	}

	public Class4506 imethod_4(Interface129 parameters, char charCode)
	{
		Class4508 result = null;
		if (parameters is Class4686 @class)
		{
			Class4625[] array = class4411_0.TTFTables.CMapTable.method_3(@class.PlatformID, @class.PlatformSpecificID);
			result = new Class4508(array[0].vmethod_2(charCode));
		}
		return result;
	}
}
