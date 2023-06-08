using ns171;

namespace ns187;

internal class Class5050 : Class5024
{
	internal class Class5085 : Class5052
	{
		public Class5085(int propId)
			: base(propId)
		{
		}

		public override Class5024 vmethod_8(Class5634 propertyList, string value, Class5094 fo)
		{
			int num = value.Length - 1;
			if (num > 0)
			{
				char c = value[0];
				if ((c == '"' || c == '\'') && value[num] == c)
				{
					return new Class5050(value.Substring(1, num));
				}
				string text = method_15(value);
				if (text != null)
				{
					value = text;
				}
			}
			return smethod_0(value);
		}
	}

	private static Class5749 class5749_0 = new Class5749();

	public static Class5050 class5050_0 = new Class5050(string.Empty);

	private string string_1;

	private Class5050(string str)
	{
		string_1 = str;
	}

	public static Class5050 smethod_0(string str)
	{
		if (string.IsNullOrEmpty(str))
		{
			return class5050_0;
		}
		return (Class5050)class5749_0.method_0(new Class5050(str));
	}

	public override object vmethod_12()
	{
		return string_1;
	}

	public override string vmethod_13()
	{
		return string_1;
	}

	public override bool Equals(object obj)
	{
		if (this == obj)
		{
			return true;
		}
		if (obj is Class5050 @class)
		{
			if (!(@class.string_1 == string_1))
			{
				return @class.string_1.Equals(string_1);
			}
			return true;
		}
		return false;
	}

	public override int GetHashCode()
	{
		return string_1.GetHashCode();
	}
}
