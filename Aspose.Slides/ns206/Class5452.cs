using System.Collections;
using ns183;
using ns184;

namespace ns206;

internal class Class5452 : ArrayList
{
	public void method_0(Class5730 fontInfo)
	{
		Interface208 @interface = new Class5495(this);
		while (@interface.imethod_0())
		{
			Class5451 @class = (Class5451)@interface.imethod_1();
			Class5450 class2 = @class.method_1();
			Class5732 class3 = class2.method_9(fontInfo);
			if (class3 != null)
			{
				string internalFontKey = fontInfo.method_21(class3);
				Class5450 class4 = @class.method_0();
				ArrayList arrayList = class4.method_10();
				Interface208 interface2 = new Class5495(arrayList);
				while (interface2.imethod_0())
				{
					Class5732 triplet = (Class5732)interface2.imethod_1();
					fontInfo.method_4(internalFontKey, triplet);
				}
			}
		}
	}
}
