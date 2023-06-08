using ns171;
using ns176;

namespace ns187;

internal class Class5043 : Class5024, Interface237
{
	internal class Class5062 : Class5060
	{
		public Class5062(int propId)
			: base(propId)
		{
		}

		public override Class5024 vmethod_3()
		{
			return new Class5043();
		}

		public override Class5024 vmethod_11(Class5024 p, Class5634 propertyList, Class5094 fo)
		{
			if (p is Class5043)
			{
				return p;
			}
			return base.vmethod_11(p, propertyList, fo);
		}
	}

	private static Class5749 class5749_0 = new Class5749();

	private bool bool_0;

	private Class5024 class5024_0;

	private Class5024 class5024_1;

	private Class5024 class5024_2;

	public void imethod_1(int cmpId, Class5024 cmpnValue, bool bIsDefault)
	{
		if (!bool_0)
		{
			switch (cmpId)
			{
			case 5120:
				method_3(cmpnValue, bIsDefault);
				break;
			case 4608:
				method_4(cmpnValue);
				break;
			case 5632:
				method_5(cmpnValue, bIsDefault);
				break;
			}
		}
	}

	public Class5024 imethod_2(int cmpId)
	{
		return cmpId switch
		{
			5120 => method_6(), 
			4608 => method_7(), 
			5632 => method_8(), 
			_ => null, 
		};
	}

	public void method_3(Class5024 withinLinE, bool bIsDefault)
	{
		class5024_0 = withinLinE;
	}

	protected void method_4(Class5024 withinColumN)
	{
		class5024_1 = withinColumN;
	}

	public void method_5(Class5024 withinPagE, bool bIsDefault)
	{
		class5024_2 = withinPagE;
	}

	public Class5024 method_6()
	{
		return class5024_0;
	}

	public Class5024 method_7()
	{
		return class5024_1;
	}

	public Class5024 method_8()
	{
		return class5024_2;
	}

	public override string ToString()
	{
		return string.Concat("Keep[withinLine:", method_6().vmethod_12(), ", withinColumn:", method_7().vmethod_12(), ", withinPage:", method_8().vmethod_12(), "]");
	}

	public override Class5043 vmethod_6()
	{
		Class5043 @class = (Class5043)class5749_0.method_0(this);
		@class.bool_0 = true;
		return @class;
	}

	public override object vmethod_12()
	{
		return this;
	}

	public override bool Equals(object o)
	{
		if (this == o)
		{
			return true;
		}
		if (o is Class5043 @class)
		{
			if (@class.class5024_1 == class5024_1 && @class.class5024_0 == class5024_0)
			{
				return @class.class5024_2 == class5024_2;
			}
			return false;
		}
		return false;
	}

	public override int GetHashCode()
	{
		int num = 17;
		num = 629 + ((class5024_1 != null) ? class5024_1.GetHashCode() : 0);
		num = 37 * num + ((class5024_0 != null) ? class5024_0.GetHashCode() : 0);
		return 37 * num + ((class5024_2 != null) ? class5024_2.GetHashCode() : 0);
	}
}
