using ns171;
using ns176;

namespace ns187;

internal class Class5025 : Class5024
{
	internal class Class5053 : Class5052
	{
		public Class5053(int propId)
			: base(propId)
		{
		}

		public override Class5024 vmethod_11(Class5024 p, Class5634 propertyList, Class5094 fo)
		{
			if (p is Class5025)
			{
				return p;
			}
			if (p.imethod_0() == 9)
			{
				return new Class5025();
			}
			return vmethod_12(p, propertyList, fo);
		}
	}

	protected Class4925 class4925_0;

	private readonly bool bool_0;

	public bool Auto => bool_0;

	public static Class5025 smethod_0(Class5634 propertyList)
	{
		return propertyList.method_6(Enum679.const_72) as Class5025;
	}

	public static Class5025 smethod_1(Interface182 top, Interface182 right, Interface182 bottom, Interface182 left)
	{
		return new Class5025(new Class4925(top, right, bottom, left));
	}

	private Class5025(Class4925 value)
	{
		class4925_0 = value;
		bool_0 = false;
	}

	private Class5025()
	{
		bool_0 = true;
	}

	public Class4925 method_3()
	{
		return class4925_0;
	}

	public override string ToString()
	{
		if (Auto)
		{
			return "auto";
		}
		return class4925_0.ToString();
	}

	public override int GetHashCode()
	{
		if (bool_0)
		{
			return bool_0.GetHashCode();
		}
		return class4925_0.GetHashCode();
	}
}
