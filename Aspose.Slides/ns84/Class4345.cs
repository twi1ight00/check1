using System.Collections.Generic;
using System.Drawing;
using ns305;
using ns72;
using ns73;
using ns85;
using ns86;
using ns87;

namespace ns84;

internal abstract class Class4345
{
	private static Class3546<Enum600, Interface98<Class6981>> class3546_0;

	internal abstract Class3679 vmethod_0(Enum600 type);

	internal abstract Class3679 vmethod_1(Enum600 type, string pseudoElement);

	internal T method_0<T>(Enum600 type) where T : struct
	{
		Class3679 @class = vmethod_0(type);
		if (@class.CSSValueType == 1)
		{
			return Class4342.smethod_0<T>().imethod_3(@class.CSSText);
		}
		IEnumerator<Class3679> enumerator = ((Class3691)@class).GetEnumerator();
		Interface54 @interface = Class4342.smethod_0<T>();
		enumerator.MoveNext();
		int num = (int)@interface.imethod_1(enumerator.Current.CSSText);
		while (enumerator.MoveNext())
		{
			num |= (int)@interface.imethod_1(enumerator.Current.CSSText);
		}
		return (T)(object)num;
	}

	internal Color method_1(Enum600 type)
	{
		return ((Class3680)vmethod_0(type)).vmethod_6().method_0();
	}

	internal Class4338 method_2(Enum600 type)
	{
		return Class4338.smethod_4(vmethod_0(type));
	}

	public bool method_3(Enum600 property, Class6981 element)
	{
		if (class3546_0 == null)
		{
			class3546_0 = smethod_0();
		}
		if (class3546_0.ContainsKey(property))
		{
			return class3546_0.method_1(property).imethod_0(element);
		}
		return true;
	}

	private static Class3546<Enum600, Interface98<Class6981>> smethod_0()
	{
		Class3546<Enum600, Interface98<Class6981>> @class = new Class3546<Enum600, Interface98<Class6981>>();
		@class.method_0(Enum600.const_38, new Class4150(Enum630.const_6, Enum630.const_7));
		@class.method_0(Enum600.const_55, new Class4150(Enum630.const_6, Enum630.const_7));
		Enum633[] position = new Enum633[1];
		@class.method_0(Enum600.const_64, Class4146<Class6981>.smethod_2(new Class4148(position)));
		@class.method_0(Enum600.const_68, new Class4150(Enum630.const_15));
		@class.method_0(Enum600.const_69, new Class4150(Enum630.const_1, Enum630.const_2, Enum630.const_6));
		@class.method_0(Enum600.const_70, new Class4148(Enum633.const_2, Enum633.const_3));
		@class.method_0(Enum600.const_100, new Class4150(Enum630.const_14));
		Enum633[] position2 = new Enum633[1];
		@class.method_0(Enum600.const_149, new Class4148(position2).method_2());
		@class.method_0(Enum600.const_158, new Class4150(Enum630.const_2));
		@class.method_0(Enum600.const_159, new Class4150(Enum630.const_2));
		@class.method_0(Enum600.const_160, new Class4150(Enum630.const_2));
		@class.method_0(Enum600.const_157, new Class4150(Enum630.const_2));
		@class.method_0(Enum600.const_161, new Class4150(Enum630.const_1, Enum630.const_0, Enum630.const_3, Enum630.const_7, Enum630.const_2, Enum630.const_21, Enum630.const_4, Enum630.const_6, Enum630.const_15));
		@class.method_0(Enum600.const_162, new Class4150(Enum630.const_1, Enum630.const_0, Enum630.const_3, Enum630.const_7, Enum630.const_2, Enum630.const_21, Enum630.const_4, Enum630.const_6, Enum630.const_15));
		@class.method_0(Enum600.const_163, new Class4150(Enum630.const_1, Enum630.const_0, Enum630.const_3, Enum630.const_7, Enum630.const_2, Enum630.const_21, Enum630.const_4, Enum630.const_6, Enum630.const_15));
		@class.method_0(Enum600.const_164, new Class4150(Enum630.const_1, Enum630.const_0, Enum630.const_3, Enum630.const_7, Enum630.const_2, Enum630.const_21, Enum630.const_4, Enum630.const_6, Enum630.const_15));
		@class.method_0(Enum600.const_165, new Class4150(Enum630.const_1, Enum630.const_0, Enum630.const_3, Enum630.const_7, Enum630.const_2, Enum630.const_21, Enum630.const_4, Enum630.const_6, Enum630.const_15));
		@class.method_0(Enum600.const_172, Class4146<Class6981>.smethod_2(new Class4150(Enum630.const_6, Enum630.const_15, Enum630.const_13, Enum630.const_12, Enum630.const_10, Enum630.const_9, Enum630.const_7, Enum630.const_11, Enum630.const_8)));
		@class.method_0(Enum600.const_173, Class4146<Class6981>.smethod_2(new Class4150(Enum630.const_6, Enum630.const_15, Enum630.const_13, Enum630.const_12, Enum630.const_10, Enum630.const_9, Enum630.const_7, Enum630.const_11, Enum630.const_8)));
		@class.method_0(Enum600.const_174, Class4146<Class6981>.smethod_2(new Class4150(Enum630.const_6, Enum630.const_15, Enum630.const_13, Enum630.const_12, Enum630.const_10, Enum630.const_9, Enum630.const_7, Enum630.const_11, Enum630.const_8)));
		@class.method_0(Enum600.const_175, Class4146<Class6981>.smethod_2(new Class4150(Enum630.const_6, Enum630.const_15, Enum630.const_13, Enum630.const_12, Enum630.const_10, Enum630.const_9, Enum630.const_7, Enum630.const_11, Enum630.const_8)));
		@class.method_0(Enum600.const_186, new Class4150(Enum630.const_1, Enum630.const_2, Enum630.const_6));
		@class.method_0(Enum600.const_192, new Class4150(Enum630.const_1, Enum630.const_2, Enum630.const_6));
		@class.method_0(Enum600.const_197, new Class4150(Enum630.const_11, Enum630.const_9, Enum630.const_10, Enum630.const_11, Enum630.const_12, Enum630.const_13).method_2());
		@class.method_0(Enum600.const_198, new Class4150(Enum630.const_11, Enum630.const_9, Enum630.const_10, Enum630.const_11, Enum630.const_12, Enum630.const_13).method_2());
		@class.method_0(Enum600.const_199, new Class4150(Enum630.const_11, Enum630.const_9, Enum630.const_10, Enum630.const_11, Enum630.const_12, Enum630.const_13).method_2());
		@class.method_0(Enum600.const_200, new Class4150(Enum630.const_11, Enum630.const_9, Enum630.const_10, Enum630.const_11, Enum630.const_12, Enum630.const_13).method_2());
		@class.method_0(Enum600.const_201, new Class4150(Enum630.const_11, Enum630.const_9, Enum630.const_10, Enum630.const_11, Enum630.const_12, Enum630.const_13).method_2());
		Enum633[] position3 = new Enum633[1];
		@class.method_0(Enum600.const_221, new Class4148(position3).method_2());
		@class.method_0(Enum600.const_237, new Class4150(Enum630.const_6, Enum630.const_7));
		@class.method_0(Enum600.const_239, new Class4150(Enum630.const_1, Enum630.const_2, Enum630.const_6, Enum630.const_14));
		@class.method_0(Enum600.const_253, new Class4150(Enum630.const_1, Enum630.const_2, Enum630.const_6));
		Enum633[] position4 = new Enum633[1];
		@class.method_0(Enum600.const_261, new Class4148(position4).method_2());
		@class.method_0(Enum600.const_271, new Class4150(Enum630.const_0, Enum630.const_7, Enum630.const_3, Enum630.const_14));
		@class.method_0(Enum600.const_253, new Class4150(Enum630.const_1, Enum630.const_2, Enum630.const_6));
		@class.method_0(Enum600.const_283, new Class4150(Enum630.const_1, Enum630.const_2, Enum630.const_6));
		Enum633[] position5 = new Enum633[1];
		@class.method_0(Enum600.const_288, new Class4148(position5).method_2());
		return @class;
	}
}
