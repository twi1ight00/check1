using ns171;
using ns186;

namespace ns187;

internal class Class5077 : Class5042.Class5075
{
	public Class5077(int propId)
		: base(propId)
	{
	}

	public override Class5024 vmethod_8(Class5634 pList, string value, Class5094 fo)
	{
		if ("inherit".Equals(value))
		{
			return base.vmethod_8(pList, value, fo);
		}
		string value2 = method_15(value);
		Class5024 @class = vmethod_10(value2);
		int num = @class?.imethod_0() ?? (-1);
		switch (num)
		{
		case -1:
			@class = Class5388.smethod_5(value, new Class5750(this, pList));
			break;
		case 167:
		case 168:
		{
			Class5024 class2 = pList.method_4(108);
			if (num == 167)
			{
				switch ((Enum679)class2.imethod_0())
				{
				case Enum679.const_256:
					@class = Class5042.smethod_0(170, "200");
					break;
				case Enum679.const_257:
					@class = Class5042.smethod_0(171, "300");
					break;
				case Enum679.const_258:
					@class = Class5042.smethod_0(172, "400");
					break;
				case Enum679.const_259:
					@class = Class5042.smethod_0(173, "500");
					break;
				case Enum679.const_260:
					@class = Class5042.smethod_0(174, "600");
					break;
				case Enum679.const_261:
					@class = Class5042.smethod_0(175, "700");
					break;
				case Enum679.const_262:
					@class = Class5042.smethod_0(176, "800");
					break;
				case Enum679.const_263:
				case Enum679.const_264:
					@class = Class5042.smethod_0(177, "900");
					break;
				}
			}
			else
			{
				switch ((Enum679)class2.imethod_0())
				{
				case Enum679.const_256:
				case Enum679.const_257:
					@class = Class5042.smethod_0(169, "100");
					break;
				case Enum679.const_258:
					@class = Class5042.smethod_0(170, "200");
					break;
				case Enum679.const_259:
					@class = Class5042.smethod_0(171, "300");
					break;
				case Enum679.const_260:
					@class = Class5042.smethod_0(172, "400");
					break;
				case Enum679.const_261:
					@class = Class5042.smethod_0(173, "500");
					break;
				case Enum679.const_262:
					@class = Class5042.smethod_0(174, "600");
					break;
				case Enum679.const_263:
					@class = Class5042.smethod_0(175, "700");
					break;
				case Enum679.const_264:
					@class = Class5042.smethod_0(176, "800");
					break;
				}
			}
			break;
		}
		}
		if (@class != null)
		{
			@class = vmethod_11(@class, pList, fo);
		}
		return @class;
	}
}
