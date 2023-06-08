using System;
using ns171;
using ns176;

namespace ns187;

internal class Class5032 : Class5024, Interface237
{
	internal class Class5061 : Class5060
	{
		public Class5061(int propId)
			: base(propId)
		{
		}

		public override Class5024 vmethod_3()
		{
			return new Class5032();
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

	private Class5024 class5024_0;

	private Class5042 class5042_0;

	private bool bool_0;

	private int int_0 = -1;

	public virtual void imethod_1(int cmpId, Class5024 cmpnValue, bool bIsDefault)
	{
		if (bool_0)
		{
			throw new Exception("CondLengthProperty.setComponent() called on a cached value!");
		}
		switch (cmpId)
		{
		case 2048:
			class5024_0 = cmpnValue;
			break;
		case 1024:
			class5042_0 = (Class5042)cmpnValue;
			break;
		}
	}

	public virtual Class5024 imethod_2(int cmpId)
	{
		return cmpId switch
		{
			2048 => class5024_0, 
			1024 => class5042_0, 
			_ => null, 
		};
	}

	public virtual Class5024 vmethod_14()
	{
		return class5042_0;
	}

	public virtual Class5024 vmethod_15()
	{
		return class5024_0;
	}

	public virtual bool vmethod_16()
	{
		return class5042_0.imethod_0() == 32;
	}

	public virtual int vmethod_17()
	{
		return class5024_0.vmethod_0().imethod_5();
	}

	public virtual int vmethod_18(Interface172 context)
	{
		return class5024_0.vmethod_0().imethod_6(context);
	}

	public override string ToString()
	{
		return "CondLength[" + class5024_0.vmethod_12().ToString() + ", " + (vmethod_16() ? class5042_0.ToString().ToLower() : class5042_0.ToString()) + "]";
	}

	public override Class5032 vmethod_2()
	{
		if (class5024_0.vmethod_0().imethod_4())
		{
			Class5032 @class = (Class5032)class5749_0.method_0(this);
			if (@class == this)
			{
				bool_0 = true;
			}
			return @class;
		}
		return this;
	}

	public override Interface182 vmethod_0()
	{
		return class5024_0.vmethod_0();
	}

	public override object vmethod_12()
	{
		return this;
	}

	public override bool Equals(object obj)
	{
		if (this == obj)
		{
			return true;
		}
		if (obj is Class5032 @class)
		{
			if (class5024_0 == @class.class5024_0)
			{
				return class5042_0 == @class.class5042_0;
			}
			return false;
		}
		return false;
	}

	public override int GetHashCode()
	{
		if (int_0 == -1)
		{
			int num = 17;
			num = 629 + ((class5024_0 != null) ? class5024_0.GetHashCode() : 0);
			num = 37 * num + ((class5042_0 != null) ? class5042_0.GetHashCode() : 0);
			int_0 = num;
		}
		return int_0;
	}
}
