using ns171;
using ns176;

namespace ns187;

internal class Class5060 : Class5052
{
	private Class5052[] class5052_1 = new Class5052[11];

	private Class5052 class5052_2;

	public Class5060(int propId)
		: base(propId)
	{
	}

	public override void vmethod_0(Class5052 generic)
	{
		base.vmethod_0(generic);
		if (!(generic is Class5060 @class))
		{
			return;
		}
		for (int i = 0; i < 11; i++)
		{
			Class5052 class2 = @class.class5052_1[i];
			if (class2 != null)
			{
				vmethod_1((Class5052)class2.method_18());
			}
		}
	}

	public override void vmethod_1(Class5052 subproperty)
	{
		subproperty.int_0 &= -512;
		subproperty.int_0 |= int_0;
		class5052_1[smethod_0(subproperty.method_0())] = subproperty;
		if (class5052_2 == null && subproperty.bool_2)
		{
			class5052_2 = subproperty;
		}
	}

	public override Class5052 vmethod_2(int subpropertyId)
	{
		return class5052_1[smethod_0(subpropertyId)];
	}

	private static int smethod_0(int subpropertyId)
	{
		return ((subpropertyId & -512) >> 9) - 1;
	}

	internal override Class5024 vmethod_10(string value)
	{
		Class5024 @class = null;
		if (class5052_2 != null)
		{
			@class = class5052_2.vmethod_10(value);
		}
		if (@class == null)
		{
			@class = base.vmethod_10(value);
		}
		return @class;
	}

	public override Class5024 vmethod_4(int subpropertyId, Class5634 propertyList, bool tryInherit, bool tryDefault)
	{
		Class5024 @class = base.vmethod_4(subpropertyId, propertyList, tryInherit, tryDefault);
		if (subpropertyId != 0 && @class != null)
		{
			@class = method_13(@class, subpropertyId);
		}
		return @class;
	}

	public override Class5024 vmethod_11(Class5024 p, Class5634 propertyList, Class5094 fo)
	{
		p = class5052_2.vmethod_11(p, propertyList, fo);
		if (p != null)
		{
			Class5024 @class = method_19(propertyList);
			Interface237 @interface = (Interface237)@class.vmethod_12();
			for (int i = 0; i < 11; i++)
			{
				Class5052 class2 = class5052_1[i];
				if (class2 != null && class2.bool_2)
				{
					@interface.imethod_1(class2.method_0() & -512, p, bIsDefault: false);
				}
			}
			return @class;
		}
		return null;
	}

	public override Class5024 vmethod_7(Class5634 propertyList)
	{
		if (string_0 != null)
		{
			return vmethod_8(propertyList, string_0, propertyList.method_1());
		}
		return method_19(propertyList);
	}

	public override Class5024 vmethod_8(Class5634 propertyList, string value, Class5094 fo)
	{
		Class5024 p = base.vmethod_8(propertyList, value, fo);
		return vmethod_11(p, propertyList, fo);
	}

	public override Class5024 vmethod_9(Class5024 baseProperty, int subpropertyId, Class5634 propertyList, string value, Class5094 fo)
	{
		if (baseProperty == null)
		{
			baseProperty = method_19(propertyList);
		}
		Class5052 @class = vmethod_2(subpropertyId);
		if (@class != null)
		{
			Class5024 class2 = @class.vmethod_8(propertyList, value, fo);
			if (class2 != null)
			{
				return vmethod_6(baseProperty, subpropertyId & -512, class2);
			}
		}
		return baseProperty;
	}

	protected Class5024 method_19(Class5634 propertyList)
	{
		Class5024 @class = vmethod_3();
		Interface237 @interface = (Interface237)@class.vmethod_12();
		for (int i = 0; i < 11; i++)
		{
			Class5052 class2 = class5052_1[i];
			if (class2 != null)
			{
				Class5024 cmpnValue = class2.vmethod_7(propertyList);
				@interface.imethod_1(class2.method_0() & -512, cmpnValue, bIsDefault: true);
			}
		}
		return @class;
	}
}
