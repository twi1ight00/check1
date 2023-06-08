using ns171;
using ns176;

namespace ns187;

internal abstract class Class5034 : Class5024, Interface181, Interface182
{
	internal class Class5068 : Class5052
	{
		public const int int_2 = 72;

		public Class5068(int propId)
			: base(propId)
		{
		}

		public override Class5024 vmethod_11(Class5024 p, Class5634 propertyList, Class5094 fo)
		{
			if (p is Class5042)
			{
				return new Class5035(p);
			}
			if (p is Class5034)
			{
				return p;
			}
			if (p is Class5048)
			{
				float num = propertyList.method_0().method_2().method_38();
				return Class5036.smethod_0(p.vmethod_10().imethod_1(), "px", 72f / num);
			}
			Interface182 @interface = p.vmethod_0();
			if (@interface != null)
			{
				return (Class5024)@interface;
			}
			return vmethod_12(p, propertyList, fo);
		}
	}

	public abstract double imethod_1();

	public abstract double imethod_2(Interface172 context);

	public int imethod_3()
	{
		return 1;
	}

	public abstract bool imethod_4();

	public abstract int imethod_5();

	public abstract int imethod_6(Interface172 context);

	public override Interface181 vmethod_10()
	{
		return this;
	}

	public override Interface182 vmethod_0()
	{
		return this;
	}

	public override object vmethod_12()
	{
		return this;
	}
}
