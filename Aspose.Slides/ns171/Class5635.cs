using ns187;

namespace ns171;

internal class Class5635 : Class5634
{
	private Class5024[] class5024_0;

	private Class5024[] class5024_1;

	public Class5635(Class5094 fObjToAttach, Class5634 parentPropertyList)
		: base(fObjToAttach, parentPropertyList)
	{
		class5024_0 = new Class5024[300];
		class5024_1 = new Class5024[300];
	}

	public override Class5024 vmethod_0(int propId)
	{
		return class5024_0[propId];
	}

	public override void vmethod_1(int propId, Class5024 value)
	{
		class5024_0[propId] = value;
		if (class5024_1[propId] != null)
		{
			class5024_1[propId] = value;
		}
	}

	public override Class5024 vmethod_2(int propId, bool bTryInherit, bool bTryDefault)
	{
		Class5024 @class = class5024_1[propId];
		if (@class == null)
		{
			@class = base.vmethod_2(propId, bTryInherit, bTryDefault);
			class5024_1[propId] = @class;
		}
		return @class;
	}
}
