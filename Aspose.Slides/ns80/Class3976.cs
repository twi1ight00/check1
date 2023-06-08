using System.Collections.Generic;
using ns76;
using ns79;
using ns84;
using ns88;

namespace ns80;

internal class Class3976 : Class3969
{
	public override string PropertyName => "border-radius";

	public override Enum600 PropertyType => Enum600.const_50;

	public override bool IsInheritedProperty => false;

	public override void vmethod_3(Class3726 engine, Interface100 propertyHandler, Interface99 lu, bool important)
	{
		IList<Interface99> list = new List<Interface99>();
		IList<Interface99> list2 = new List<Interface99>();
		IList<Interface99> list3 = Class4233.smethod_13(lu);
		IList<Interface99> list4 = list;
		foreach (Interface99 item in list3)
		{
			if (item.LexicalUnitType == 4)
			{
				if (list4 == list2)
				{
					throw method_1(item.LexicalUnitType);
				}
				list4 = list2;
			}
			else
			{
				list4.Add(item);
			}
		}
		list = Class3770.smethod_0(list);
		if (list2.Count != 0)
		{
			list2 = Class3770.smethod_0(list2);
		}
		if (list2.Count != 0)
		{
			method_8(propertyHandler, "border-top-left-radius", new Interface99[2]
			{
				list[0],
				list2[0]
			}, important);
			method_8(propertyHandler, "border-top-right-radius", new Interface99[2]
			{
				list[1],
				list2[1]
			}, important);
			method_8(propertyHandler, "border-bottom-right-radius", new Interface99[2]
			{
				list[2],
				list2[2]
			}, important);
			method_8(propertyHandler, "border-bottom-left-radius", new Interface99[2]
			{
				list[3],
				list2[3]
			}, important);
		}
		else
		{
			method_8(propertyHandler, "border-top-left-radius", new Interface99[1] { list[0] }, important);
			method_8(propertyHandler, "border-top-right-radius", new Interface99[1] { list[1] }, important);
			method_8(propertyHandler, "border-bottom-right-radius", new Interface99[1] { list[2] }, important);
			method_8(propertyHandler, "border-bottom-left-radius", new Interface99[1] { list[3] }, important);
		}
	}
}
