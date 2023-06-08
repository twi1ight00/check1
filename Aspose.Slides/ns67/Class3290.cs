using System.Collections.Generic;

namespace ns67;

internal abstract class Class3290 : Class3280
{
	internal override Class3069[] vmethod_2(List<Class3376> paragraphs)
	{
		Class3381[] array = method_2();
		Class3376 @class = Class3376.smethod_0(paragraphs);
		return method_3(@class.Contours, @class.ActualBounds, array[0], array[1]);
	}
}
