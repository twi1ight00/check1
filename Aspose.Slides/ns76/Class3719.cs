using ns305;
using ns73;
using ns74;

namespace ns76;

internal class Class3719 : Class3718
{
	private Class6976 class6976_0;

	public Class3719(Class4074 map, Class6976 element, Class3726 engine)
		: base(map, engine)
	{
		class6976_0 = element;
	}

	public override void vmethod_2(int propertyIndex, Class3679 value, bool important)
	{
		base.vmethod_2(propertyIndex, value, important);
		Class4074 @class = ((Interface91)class6976_0).imethod_0(null);
		if (@class != null)
		{
			@class.method_1(propertyIndex, value);
			@class.method_3(propertyIndex, important);
			@class.method_5(propertyIndex, value: false);
		}
	}

	protected override Class3716 vmethod_0(string content)
	{
		return (Class3716)base.Engine.imethod_6(content, class6976_0);
	}
}
