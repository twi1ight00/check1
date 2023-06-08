using ns73;
using ns74;

namespace ns76;

internal class Class3718 : Class3716
{
	private Class4074 class4074_0;

	public Class3718(Class4074 map, Class3726 engine)
		: base(engine)
	{
		class4074_0 = map;
		int num = engine.method_3();
		for (int i = 0; i < num; i++)
		{
			Class3679 @class = map.method_0(i);
			if (@class != null)
			{
				bool important = map.method_2(i);
				vmethod_2(i, @class, important);
			}
		}
	}

	public override void vmethod_2(int propertyIndex, Class3679 value, bool important)
	{
		base.vmethod_2(propertyIndex, value, important);
		class4074_0.method_5(propertyIndex, value: false);
	}
}
