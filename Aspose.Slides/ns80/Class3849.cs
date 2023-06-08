using System;
using ns73;
using ns76;
using ns79;
using ns84;
using ns88;

namespace ns80;

internal class Class3849 : Class3771
{
	public override string PropertyName => "text-shadow";

	public override Enum600 PropertyType => Enum600.const_257;

	public override bool IsInheritedProperty => false;

	public override Class3679 vmethod_1()
	{
		return new Class3691(Class3700.Class3702.class3689_4);
	}

	public override Class3679 vmethod_0(Interface99 lu, Class3726 engine)
	{
		Class3691 @class = new Class3691();
		Interface99 @interface = lu;
		int num = 0;
		while (@interface != null)
		{
			switch (num)
			{
			case 0:
				if (35 != @interface.LexicalUnitType)
				{
					@class.Add(base.vmethod_0(@interface, engine));
					break;
				}
				if (!"none".Equals(@interface.imethod_5(), StringComparison.InvariantCultureIgnoreCase))
				{
					throw method_0(lu.imethod_5());
				}
				@class.Add(Class3700.Class3702.class3689_4);
				return @class;
			case 1:
				@class.Add(base.vmethod_0(@interface, engine));
				break;
			case 2:
				if (35 == @interface.LexicalUnitType)
				{
					@class.Add(engine.method_6(Enum600.const_71).vmethod_0(@interface, engine));
				}
				else
				{
					@class.Add(base.vmethod_0(@interface, engine));
				}
				break;
			case 3:
				@class.Add(engine.method_6(Enum600.const_71).vmethod_0(@interface, engine));
				break;
			default:
				throw Class4246.smethod_11(lu.LexicalUnitType);
			}
			@interface = @interface.NextLexicalUnit;
			num++;
		}
		return @class;
	}
}
