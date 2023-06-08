using ns187;

namespace ns171;

internal class Class5378 : Class5376
{
	protected override Class5024 vmethod_0(int propId, Class5024 property, Class5052 maker, Class5634 propertyList)
	{
		string text = Class5735.smethod_5(propId);
		Class5024 @class = null;
		int count = property.vmethod_8().Count;
		if (text.IndexOf("-top") >= 0)
		{
			@class = method_0(property, 0);
		}
		else if (text.IndexOf("-right") >= 0)
		{
			@class = method_0(property, (count > 1) ? 1 : 0);
		}
		else if (text.IndexOf("-bottom") >= 0)
		{
			@class = method_0(property, (count > 2) ? 2 : 0);
		}
		else if (text.IndexOf("-left") >= 0)
		{
			@class = method_0(property, (count > 3) ? 3 : ((count > 1) ? 1 : 0));
		}
		if (@class != null)
		{
			return maker.method_14(propertyList, @class, null);
		}
		return @class;
	}
}
