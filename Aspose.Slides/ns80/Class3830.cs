using System.Collections.Generic;
using ns73;
using ns76;
using ns79;
using ns84;
using ns88;

namespace ns80;

internal class Class3830 : Class3829
{
	public override string PropertyName => "border-spacing";

	public override Enum600 PropertyType => Enum600.const_55;

	public override bool IsInheritedProperty => true;

	public override Class3679 vmethod_1()
	{
		Class3691 @class = new Class3691();
		@class.Add(Class3700.Class3702.class3685_0);
		return @class;
	}

	public override Class3679 vmethod_0(Interface99 lu, Class3726 engine)
	{
		List<Class3679> list = new List<Class3679>();
		do
		{
			list.Add(base.vmethod_0(lu, engine));
			lu = lu.NextLexicalUnit;
		}
		while (lu != null);
		if (list.Count == 1)
		{
			list.Add(list[0]);
		}
		if (list.Count > 2)
		{
			throw method_3(list[2].ToString());
		}
		return new Class3691(list);
	}
}
