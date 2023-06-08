using ns171;

namespace ns187;

internal class Class5071 : Class5034.Class5068
{
	public Class5071(int propId)
		: base(propId)
	{
	}

	public override Class5024 vmethod_4(int subpropId, Class5634 propertyList, bool tryInherit, bool tryDefault)
	{
		Class5024 @class = base.vmethod_4(0, propertyList, tryInherit, tryDefault);
		Class5094 class2 = propertyList.method_0();
		string value = ((int_0 == 183) ? class2.method_2().method_40() : class2.method_2().method_41());
		if (@class.imethod_0() == 64)
		{
			int propId = ((int_0 == 183) ? 186 : 183);
			int num = propertyList.method_5(267).imethod_0();
			int num2 = propertyList.method_5(197).vmethod_10().imethod_5();
			if (propertyList.vmethod_0(propId) != null && propertyList.vmethod_0(propId).imethod_0() == 64)
			{
				if ((num != 140 && (num2 == 0 || num2 == 180 || num2 == -180)) || (num == 140 && (num2 == 90 || num2 == 270 || num2 == -270)))
				{
					if (int_0 == 186)
					{
						return vmethod_8(propertyList, value, class2);
					}
				}
				else if (int_0 == 183)
				{
					return vmethod_8(propertyList, value, class2);
				}
			}
		}
		else if (@class.method_2())
		{
			return vmethod_8(propertyList, value, class2);
		}
		return @class;
	}
}
