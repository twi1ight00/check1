using ns171;
using ns176;
using ns195;
using ns205;

namespace ns187;

internal class Class5045 : Class5024, Interface237
{
	internal class Class5064 : Class5060
	{
		public Class5064(int propId)
			: base(propId)
		{
		}

		public override Class5024 vmethod_3()
		{
			return new Class5045();
		}

		private static bool smethod_1(Interface182 len)
		{
			if (len is Class5037 && !(((Class5037)len).method_4() >= 0.0))
			{
				return true;
			}
			if (len.imethod_4())
			{
				return len.imethod_5() < 0;
			}
			return false;
		}

		public override Class5024 vmethod_11(Class5024 p, Class5634 propertyList, Class5094 fo)
		{
			if (p is Class5045)
			{
				return p;
			}
			if (int_0 != 17 && int_0 != 127)
			{
				return base.vmethod_11(p, propertyList, fo);
			}
			Interface182 @interface = p.vmethod_0();
			if (@interface != null && smethod_1(@interface))
			{
				p = Class5036.class5036_0;
			}
			Class5045 @class = (Class5045)base.vmethod_11(p, propertyList, fo);
			if (((uint)@class.int_3 & 2u) != 0)
			{
				@class.int_3 = 2;
			}
			return @class;
		}

		internal override Class5024 vmethod_6(Class5024 baseProperty, int subpropertyId, Class5024 subproperty)
		{
			Interface237 @interface = (Interface237)baseProperty.vmethod_12();
			if (int_0 == 17 || int_0 == 127)
			{
				Interface182 interface2 = subproperty.vmethod_0();
				if (interface2 != null && smethod_1(interface2))
				{
					@interface.imethod_1(subpropertyId, Class5036.class5036_0, bIsDefault: false);
					return baseProperty;
				}
			}
			@interface.imethod_1(subpropertyId, subproperty, bIsDefault: false);
			return baseProperty;
		}
	}

	private const int int_0 = 1;

	private const int int_1 = 2;

	private const int int_2 = 4;

	private Class5024 class5024_0;

	private Class5024 class5024_1;

	private Class5024 class5024_2;

	private int int_3;

	private bool bool_0;

	public Class5746 method_3(Interface172 context)
	{
		int num = ((!method_8(context).method_2()) ? method_8(context).vmethod_0().imethod_6(context) : 0);
		int opt = (method_10(context).method_2() ? num : method_10(context).vmethod_0().imethod_6(context));
		int max = (method_9(context).method_2() ? int.MaxValue : method_9(context).vmethod_0().imethod_6(context));
		return Class5746.smethod_0(num, opt, max);
	}

	public virtual void imethod_1(int cmpId, Class5024 cmpnValue, bool bIsDefault)
	{
		switch (cmpId)
		{
		case 3072:
			method_4(cmpnValue, bIsDefault);
			break;
		case 3584:
			method_6(cmpnValue, bIsDefault);
			break;
		case 2560:
			method_5(cmpnValue, bIsDefault);
			break;
		}
	}

	public virtual Class5024 imethod_2(int cmpId)
	{
		return cmpId switch
		{
			3072 => method_8(null), 
			3584 => method_10(null), 
			2560 => method_9(null), 
			_ => null, 
		};
	}

	protected void method_4(Class5024 minimum, bool bIsDefault)
	{
		class5024_0 = minimum;
		if (!bIsDefault)
		{
			int_3 |= 1;
		}
		bool_0 = false;
	}

	protected void method_5(Class5024 max, bool bIsDefault)
	{
		class5024_2 = max;
		if (!bIsDefault)
		{
			int_3 |= 4;
		}
		bool_0 = false;
	}

	protected void method_6(Class5024 opt, bool bIsDefault)
	{
		class5024_1 = opt;
		if (!bIsDefault)
		{
			int_3 |= 2;
		}
		bool_0 = false;
	}

	private void method_7(Interface172 context)
	{
		if (bool_0 || context == null)
		{
			return;
		}
		if (!class5024_0.method_2() && !class5024_2.method_2() && class5024_0.vmethod_0().imethod_6(context) > class5024_2.vmethod_0().imethod_6(context))
		{
			if (((uint)int_3 & (true ? 1u : 0u)) != 0)
			{
				class5024_2 = class5024_0;
			}
			else
			{
				class5024_0 = class5024_2;
			}
		}
		if (!class5024_1.method_2() && !class5024_2.method_2() && class5024_1.vmethod_0().imethod_6(context) > class5024_2.vmethod_0().imethod_6(context))
		{
			if (((uint)int_3 & 2u) != 0)
			{
				if (((uint)int_3 & 4u) != 0)
				{
					class5024_1 = class5024_2;
				}
				else
				{
					class5024_2 = class5024_1;
				}
			}
			else
			{
				class5024_1 = class5024_2;
			}
		}
		else if (!class5024_1.method_2() && !class5024_0.method_2() && class5024_1.vmethod_0().imethod_6(context) < class5024_0.vmethod_0().imethod_6(context))
		{
			if (((uint)int_3 & (true ? 1u : 0u)) != 0)
			{
				class5024_1 = class5024_0;
			}
			else
			{
				class5024_0 = class5024_1;
			}
		}
		bool_0 = true;
	}

	public Class5024 method_8(Interface172 context)
	{
		method_7(context);
		return class5024_0;
	}

	public Class5024 method_9(Interface172 context)
	{
		method_7(context);
		return class5024_2;
	}

	public Class5024 method_10(Interface172 context)
	{
		method_7(context);
		return class5024_1;
	}

	public override string ToString()
	{
		return string.Concat("LengthRange[min:", method_8(null).vmethod_12(), ", max:", method_9(null).vmethod_12(), ", opt:", method_10(null).vmethod_12(), "]");
	}

	public override Class5045 vmethod_3()
	{
		return this;
	}

	public override object vmethod_12()
	{
		return this;
	}

	public override int GetHashCode()
	{
		int num = 31;
		int num2 = 1;
		num2 = 31 + int_3;
		num2 = 31 * num2 + (bool_0 ? 1231 : 1237);
		num2 = num * num2 + Class5721.smethod_1(class5024_0);
		num2 = num * num2 + Class5721.smethod_1(class5024_1);
		return num * num2 + Class5721.smethod_1(class5024_2);
	}

	public override bool Equals(object obj)
	{
		if (this == obj)
		{
			return true;
		}
		if (!(obj is Class5045 @class))
		{
			return false;
		}
		if (int_3 == @class.int_3 && bool_0 == @class.bool_0 && Class5721.smethod_0(class5024_0, @class.class5024_0) && Class5721.smethod_0(class5024_1, @class.class5024_1))
		{
			return Class5721.smethod_0(class5024_2, @class.class5024_2);
		}
		return false;
	}
}
