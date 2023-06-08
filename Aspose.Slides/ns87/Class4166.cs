using ns73;
using ns74;
using ns84;

namespace ns87;

internal class Class4166 : Class4154
{
	private readonly Class4337 class4337_0;

	private readonly Class4337 class4337_1;

	private readonly Class4337 class4337_2;

	private readonly Class4337 class4337_3;

	public Class4337 Top => class4337_0;

	public Class4337 Right => class4337_1;

	public Class4337 Bottom => class4337_2;

	public Class4337 Left => class4337_3;

	internal Class4166(Class3679 cssValue)
		: base(cssValue)
	{
		Class3679[] array = ((cssValue.CSSValueType != 2) ? new Class3679[4] { cssValue, cssValue, cssValue, cssValue } : method_3(cssValue as Class3691));
		class4337_0 = Class4338.smethod_3((Class3681)array[0]);
		class4337_1 = Class4338.smethod_3((Class3681)array[1]);
		class4337_2 = Class4338.smethod_3((Class3681)array[2]);
		class4337_3 = Class4338.smethod_3((Class3681)array[3]);
	}

	private Class3679[] method_3(Class3691 values)
	{
		Class3679[] array = new Class3679[4];
		for (int i = 0; i < values.Length; i++)
		{
			array[i] = values[i];
		}
		switch (values.Length)
		{
		case 1:
			array[1] = (array[2] = (array[3] = array[0]));
			break;
		case 2:
			array[2] = array[0];
			array[3] = array[1];
			break;
		case 3:
			array[3] = array[1];
			break;
		}
		return array;
	}
}
