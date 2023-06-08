using System.Globalization;
using ns171;
using ns176;

namespace ns187;

internal class Class5066 : Class5046.Class5065
{
	private CultureInfo cultureInfo_0 = CultureInfo.CreateSpecificCulture("en-US");

	public Class5066(int propId)
		: base(propId)
	{
	}

	public override Class5024 vmethod_8(Class5634 propertyList, string value, Class5094 fo)
	{
		Class5024 @class = base.vmethod_8(propertyList, value, fo);
		@class.vmethod_5().method_12(Class5042.smethod_0(118, "RETAIN"), bIsDefault: true);
		@class.vmethod_5().method_11(Class5042.smethod_0(53, "FORCE"), bIsDefault: true);
		return @class;
	}

	protected override Class5024 vmethod_13(Class5634 propertyList)
	{
		Class5024 @class = propertyList.method_7(int_0);
		if (@class != null)
		{
			string text = @class.method_1();
			if (text != null)
			{
				return vmethod_8(propertyList, text, propertyList.method_1());
			}
		}
		return null;
	}

	public override Class5024 vmethod_11(Class5024 p, Class5634 propertyList, Class5094 fo)
	{
		Interface181 @interface = p.vmethod_10();
		if (@interface != null && @interface.imethod_3() == 0)
		{
			if (vmethod_5(propertyList) is Class5743)
			{
				Interface182 interface2 = ((Class5743)vmethod_5(propertyList)).method_0();
				p = ((interface2 == null || !interface2.imethod_4()) ? ((Class5034)new Class5037(@interface.imethod_1(), vmethod_5(propertyList))) : ((Class5034)Class5036.smethod_2(@interface.imethod_1() * interface2.imethod_1())));
			}
			Class5024 @class = base.vmethod_11(p, propertyList, fo);
			@class.method_0(@interface.imethod_1().ToString(cultureInfo_0));
			return @class;
		}
		return base.vmethod_11(p, propertyList, fo);
	}
}
