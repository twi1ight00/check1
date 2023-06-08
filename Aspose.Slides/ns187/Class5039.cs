using ns171;

namespace ns187;

internal class Class5039 : Class5024
{
	internal class Class5072 : Class5052
	{
		public Class5072(int propId)
			: base(propId)
		{
		}

		public override Class5024 vmethod_8(Class5634 propertyList, string value, Class5094 fo)
		{
			char character = value[0];
			return smethod_0(character);
		}
	}

	private static Class5749 class5749_0 = new Class5749();

	private char char_0;

	private Class5039(char character)
	{
		char_0 = character;
	}

	public static Class5039 smethod_0(char character)
	{
		return (Class5039)class5749_0.method_0(new Class5039(character));
	}

	public override object vmethod_12()
	{
		return char_0;
	}

	public override char vmethod_7()
	{
		return char_0;
	}

	public override string vmethod_13()
	{
		return char_0.ToString();
	}

	public override bool Equals(object obj)
	{
		if (obj is Class5039 @class)
		{
			return char_0 == @class.char_0;
		}
		return false;
	}

	public override int GetHashCode()
	{
		return char_0;
	}
}
