using System.Collections.Generic;
using System.Text;
using ns72;
using ns73;
using ns74;
using ns76;
using ns79;
using ns84;
using ns88;

namespace ns80;

internal class Class3900 : Class3899
{
	public override string PropertyName => "font-family";

	public override Enum600 PropertyType => Enum600.const_113;

	public override bool IsInheritedProperty => true;

	public override Class3679 vmethod_1()
	{
		return new Class3691();
	}

	public override Class3548<Class3679> vmethod_3()
	{
		return null;
	}

	public override Class3679 vmethod_0(Interface99 lu, Class3726 engine)
	{
		List<Class3679> list = new List<Class3679>();
		StringBuilder stringBuilder = new StringBuilder();
		do
		{
			switch (lu.LexicalUnitType)
			{
			case 0:
				if (stringBuilder.Length != 0)
				{
					list.Add(Class3689.smethod_1(stringBuilder.ToString()));
					stringBuilder = new StringBuilder();
				}
				break;
			case 35:
				if (stringBuilder.Length != 0)
				{
					stringBuilder.Append(" ").Append(lu.imethod_5());
				}
				else
				{
					stringBuilder.Append(lu.imethod_5());
				}
				break;
			case 36:
				list.Add(Class3689.smethod_1(lu.imethod_5()));
				break;
			default:
				throw method_1(lu.LexicalUnitType);
			case 12:
				return Class3700.Class3702.class3695_0;
			}
			lu = lu.NextLexicalUnit;
		}
		while (lu != null);
		if (stringBuilder.Length != 0)
		{
			list.Add(Class3689.smethod_1(stringBuilder.ToString()));
		}
		return new Class3691(list);
	}
}
