using ns171;
using ns184;

namespace ns187;

internal class Class5717
{
	private static Class5749 class5749_0 = new Class5749();

	private int int_0;

	public Class5050 class5050_0;

	public Class5050 class5050_1;

	public Class5050 class5050_2;

	public Class5042 class5042_0;

	public Class5039 class5039_0;

	public Class5048 class5048_0;

	public Class5048 class5048_1;

	private static char char_0 = '-';

	private static char char_1 = '−';

	private Class5717(Class5050 language, Class5050 country, Class5050 script, Class5042 hyphenate, Class5039 hyphenationCharacter, Class5048 hyphenationPushCharacterCount, Class5048 hyphenationRemainCharacterCount)
	{
		class5050_0 = language;
		class5050_1 = country;
		class5050_2 = script;
		class5042_0 = hyphenate;
		class5039_0 = hyphenationCharacter;
		class5048_0 = hyphenationPushCharacterCount;
		class5048_1 = hyphenationRemainCharacterCount;
	}

	public static Class5717 smethod_0(Class5634 propertyList)
	{
		Class5050 language = (Class5050)propertyList.method_5(134);
		Class5050 country = (Class5050)propertyList.method_5(81);
		Class5050 script = (Class5050)propertyList.method_5(218);
		Class5042 hyphenate = (Class5042)propertyList.method_5(116);
		Class5039 hyphenationCharacter = (Class5039)propertyList.method_5(117);
		Class5048 hyphenationPushCharacterCount = (Class5048)propertyList.method_5(120);
		Class5048 hyphenationRemainCharacterCount = (Class5048)propertyList.method_5(121);
		Class5717 obj = new Class5717(language, country, script, hyphenate, hyphenationCharacter, hyphenationPushCharacterCount, hyphenationRemainCharacterCount);
		return (Class5717)class5749_0.method_0(obj);
	}

	public char method_0(Class5729 font)
	{
		char c = class5039_0.vmethod_7();
		if (font.method_15(c))
		{
			return c;
		}
		char c2 = c;
		if (font.method_15(char_0))
		{
			c2 = char_0;
		}
		else if (font.method_15(char_1))
		{
			c2 = char_1;
			Interface161 @interface = font.method_0();
			Class4986 @class = @interface as Class4986;
			if (@interface != null && !"SymbolEncoding".Equals(@class.vmethod_0()))
			{
			}
		}
		else
		{
			c2 = ' ';
			Interface161 interface2 = font.method_0();
			if (interface2 is Class4986)
			{
				Class4986 class2 = (Class4986)interface2;
				"ZapfDingbatsEncoding".Equals(class2.vmethod_0());
			}
		}
		return c2;
	}

	public int method_1(Class5729 font)
	{
		char c = method_0(font);
		return font.method_16(c);
	}

	public override bool Equals(object obj)
	{
		if (obj == this)
		{
			return true;
		}
		if (obj is Class5717 @class)
		{
			if (@class.class5050_0 == class5050_0 && @class.class5050_1 == class5050_1 && @class.class5050_2 == class5050_2 && @class.class5042_0 == class5042_0 && @class.class5039_0 == class5039_0 && @class.class5048_0 == class5048_0)
			{
				return @class.class5048_1 == class5048_1;
			}
			return false;
		}
		return false;
	}

	public override int GetHashCode()
	{
		if (int_0 == 0)
		{
			int num = 17;
			num = 629 + ((class5050_0 != null) ? class5050_0.GetHashCode() : 0);
			num = 37 * num + ((class5050_2 != null) ? class5050_2.GetHashCode() : 0);
			num = 37 * num + ((class5050_1 != null) ? class5050_1.GetHashCode() : 0);
			num = 37 * num + ((class5042_0 != null) ? class5042_0.GetHashCode() : 0);
			num = 37 * num + ((class5039_0 != null) ? class5039_0.GetHashCode() : 0);
			num = 37 * num + ((class5048_0 != null) ? class5048_0.GetHashCode() : 0);
			num = 37 * num + ((class5048_1 != null) ? class5048_1.GetHashCode() : 0);
			int_0 = num;
		}
		return int_0;
	}
}
