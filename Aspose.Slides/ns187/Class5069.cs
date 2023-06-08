using ns171;

namespace ns187;

internal class Class5069 : Class5034.Class5068
{
	private int int_3;

	public Class5069(int propId)
		: base(propId)
	{
	}

	public void method_19(int borderStyleID)
	{
		int_3 = borderStyleID;
	}

	public override Class5024 vmethod_4(int subpropId, Class5634 propertyList, bool bTryInherit, bool bTryDefault)
	{
		Class5024 result = base.vmethod_4(subpropId, propertyList, bTryInherit, bTryDefault);
		Class5024 @class = propertyList.method_5(int_3);
		if (@class.imethod_0() == 95)
		{
			return Class5036.class5036_0;
		}
		return result;
	}
}
