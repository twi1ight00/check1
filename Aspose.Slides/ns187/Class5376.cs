using ns171;

namespace ns187;

internal class Class5376 : Interface179
{
	protected Class5024 method_0(Class5024 list, int index)
	{
		if (list.vmethod_8().Count > index)
		{
			return (Class5024)list.vmethod_8()[index];
		}
		return null;
	}

	public virtual Class5024 imethod_0(int propId, Class5024 property, Class5052 maker, Class5634 propertyList)
	{
		if (property.vmethod_8().Count == 1)
		{
			string text = method_0(property, 0).vmethod_13();
			if (text != null && text.Equals("inherit"))
			{
				return propertyList.method_8(propId);
			}
		}
		return vmethod_0(propId, property, maker, propertyList);
	}

	protected virtual Class5024 vmethod_0(int propId, Class5024 property, Class5052 maker, Class5634 propertyList)
	{
		Class5024 @class = null;
		foreach (Class5024 item in property.vmethod_8())
		{
			@class = maker.method_14(propertyList, item, null);
			if (@class != null)
			{
				break;
			}
		}
		return @class;
	}
}
