using System.Collections.Generic;
using ns73;
using ns74;
using ns76;
using ns84;
using ns88;

namespace ns79;

internal abstract class Class3770
{
	public abstract string PropertyName { get; }

	public abstract Enum600 PropertyType { get; }

	public abstract bool IsInheritedProperty { get; }

	public abstract Class3679 vmethod_0(Interface99 lu, Class3726 engine);

	public abstract Class3679 vmethod_1();

	public virtual Class3679 vmethod_2(Interface91 element, Class3726 engine, string pseudoElement, Class4074 map, Class3679 value, int propertyIndex)
	{
		if (value == null)
		{
			return vmethod_1();
		}
		return value;
	}

	protected Exception11 method_0(string ident)
	{
		return Class4246.smethod_7(ident);
	}

	protected Exception11 method_1(short type)
	{
		return Class4246.smethod_11(type);
	}

	protected Exception11 method_2(Interface99 unit)
	{
		return Class4246.smethod_13(unit.ToString());
	}

	protected Exception11 method_3(string value)
	{
		return Class4246.smethod_13(value);
	}

	protected Exception11 method_4(string name)
	{
		return Class4246.smethod_15(name);
	}

	protected bool method_5(Class3679 cssValue)
	{
		if (cssValue.CSSValueType != 1)
		{
			return false;
		}
		return ((Class3680)cssValue).PrimitiveType == 21;
	}

	protected bool method_6(Class3679 cssValue, short type)
	{
		if (cssValue.CSSValueType != 1)
		{
			return false;
		}
		return ((Class3680)cssValue).PrimitiveType == type;
	}

	protected static IList<T> smethod_0<T>(IList<T> value)
	{
		T[] array = new T[4];
		value.CopyTo(array, 0);
		switch (value.Count)
		{
		case 1:
			array[1] = (array[2] = (array[3] = value[0]));
			break;
		case 2:
			array[2] = value[0];
			array[3] = value[1];
			break;
		case 3:
			array[3] = value[1];
			break;
		}
		return array;
	}
}
