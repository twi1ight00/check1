using ns73;
using ns74;

namespace ns87;

internal abstract class Class4154
{
	private Class3679 class3679_0;

	protected bool IsStringValue
	{
		get
		{
			if (CSSValue.CSSValueType == 1)
			{
				return ((Class3680)CSSValue).PrimitiveType == 19;
			}
			return false;
		}
	}

	protected bool IsStringOrURIValue
	{
		get
		{
			if (CSSValue.CSSValueType == 1)
			{
				if (((Class3680)CSSValue).PrimitiveType != 19)
				{
					return ((Class3680)CSSValue).PrimitiveType == 20;
				}
				return true;
			}
			return false;
		}
	}

	protected bool IsIdentValue
	{
		get
		{
			if (CSSValue.CSSValueType == 1)
			{
				return ((Class3680)CSSValue).PrimitiveType == 21;
			}
			return false;
		}
	}

	protected bool IsListValue => CSSValue.CSSValueType == 2;

	public Class3679 CSSValue => class3679_0;

	protected Class4154(Class3679 value)
	{
		class3679_0 = value;
	}

	public override string ToString()
	{
		return CSSValue.CSSText;
	}

	internal string method_0()
	{
		return ((Class3680)CSSValue).vmethod_3();
	}

	internal Class3685 method_1()
	{
		return (Class3685)CSSValue;
	}

	internal Class4343 method_2()
	{
		return ((Class3680)CSSValue).vmethod_6();
	}
}
