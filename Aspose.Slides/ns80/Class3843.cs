using ns73;
using ns76;
using ns79;
using ns84;
using ns88;

namespace ns80;

internal class Class3843 : Class3771
{
	public override string PropertyName => "border-top-right-radius";

	public override Enum600 PropertyType => Enum600.const_60;

	public override bool IsInheritedProperty => false;

	public override Class3679 vmethod_1()
	{
		return new Class3691(Class3700.Class3702.class3685_0);
	}

	public override Class3679 vmethod_0(Interface99 lu, Class3726 engine)
	{
		Class3691 @class = new Class3691();
		while (lu != null)
		{
			@class.Add(base.vmethod_0(lu, engine));
			lu = lu.NextLexicalUnit;
		}
		return @class;
	}
}
