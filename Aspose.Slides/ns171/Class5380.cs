using ns187;
using ns195;

namespace ns171;

internal class Class5380 : Class5376
{
	private const char char_0 = '-';

	public override Class5024 imethod_0(int propId, Class5024 property, Class5052 maker, Class5634 propertyList)
	{
		string text = property.vmethod_13();
		int num = text.IndexOf('-');
		switch (propId)
		{
		case 134:
			if (num == -1)
			{
				return property;
			}
			return Class5050.smethod_0(Class5479.smethod_0(text, 0, num));
		case 81:
			if (num != -1)
			{
				int num2 = text.IndexOf('-', num + 1);
				if (num2 != -1)
				{
					return Class5050.smethod_0(Class5479.smethod_0(text, num + 1, num2));
				}
				return Class5050.smethod_0(text.Substring(num + 1));
			}
			break;
		}
		return null;
	}
}
