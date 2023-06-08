using ns171;
using ns195;

namespace ns187;

internal class Class5042 : Class5024
{
	internal class Class5075 : Class5052
	{
		public Class5075(int propId)
			: base(propId)
		{
		}

		internal override Class5024 vmethod_10(string value)
		{
			return base.vmethod_10(value);
		}

		public override Class5024 vmethod_11(Class5024 p, Class5634 propertyList, Class5094 fo)
		{
			if (p is Class5042)
			{
				return p;
			}
			return base.vmethod_11(p, propertyList, fo);
		}
	}

	private static Class5749 class5749_0 = new Class5749();

	private int int_0;

	private string string_1;

	private Class5042(int explicitValue, string text)
	{
		int_0 = explicitValue;
		string_1 = text;
	}

	public static Class5042 smethod_0(int explicitValue, string text)
	{
		return (Class5042)class5749_0.method_0(new Class5042(explicitValue, text));
	}

	public override int imethod_0()
	{
		return int_0;
	}

	public override object vmethod_12()
	{
		return string_1;
	}

	public override bool Equals(object obj)
	{
		if (obj is Class5042 @class)
		{
			if (int_0 == @class.int_0)
			{
				return Class5721.smethod_0(string_1, @class.string_1);
			}
			return false;
		}
		return false;
	}

	public override int GetHashCode()
	{
		return int_0 + string_1.GetHashCode();
	}
}
