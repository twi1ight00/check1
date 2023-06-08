using System;
using ns322;
using ns323;
using ns73;

namespace ns326;

internal class Class7571 : Class7456
{
	private static readonly Type type_0 = typeof(Class3680);

	protected internal override Type Type => type_0;

	protected override Type InheritedType => typeof(Class3679);

	public override void Initialize()
	{
		method_10("setFloatValue");
		method_10("getFloatValue");
		method_10("setStringValue");
		method_10("getStringValue");
		method_10("getCounterValue");
		method_10("getRectValue");
		method_10("getRGBColorValue");
		method_11("primitiveType", Enum983.flag_0);
	}

	protected override Class7397 vmethod_1(string function, Class7397 instance, Class7397[] parameters)
	{
		Class3680 @class = (Class3680)instance.Value;
		switch (function)
		{
		case "get_primitiveType":
			return method_5(@class.PrimitiveType);
		case "setFloatValue":
			if (parameters.Length != 2)
			{
				throw new Exception89("invalid arguments count.");
			}
			@class.vmethod_0(Convert.ToInt16(parameters[0].vmethod_4()), (float)parameters[1].vmethod_3());
			goto IL_015e;
		case "getFloatValue":
			if (parameters.Length != 1)
			{
				throw new Exception89("invalid arguments count.");
			}
			return method_5(@class.vmethod_1(Convert.ToInt16(parameters[0].vmethod_4())));
		case "setStringValue":
			if (parameters.Length != 2)
			{
				throw new Exception89("invalid arguments count.");
			}
			@class.vmethod_2(Convert.ToInt16(parameters[0].vmethod_4()), parameters[1].ToString());
			goto IL_015e;
		case "getStringValue":
			return method_3(@class.vmethod_3());
		case "getCounterValue":
			return method_2(@class.vmethod_4(), typeof(Class3698));
		case "getRectValue":
			return method_2(@class.vmethod_5(), typeof(Class4257));
		default:
			throw new Exception89("unknown function");
		case "getRGBColorValue":
			{
				return method_2(@class.vmethod_6(), typeof(Interface94));
			}
			IL_015e:
			return base.Undefined;
		}
	}

	protected override void vmethod_2(Class7397 instance)
	{
		method_12(instance, "CSS_UNKNOWN", method_5(0.0));
		method_12(instance, "CSS_NUMBER", method_5(1.0));
		method_12(instance, "CSS_PERCENTAGE", method_5(2.0));
		method_12(instance, "CSS_EMS", method_5(3.0));
		method_12(instance, "CSS_EXS", method_5(4.0));
		method_12(instance, "CSS_PX", method_5(5.0));
		method_12(instance, "CSS_CM", method_5(6.0));
		method_12(instance, "CSS_MM", method_5(7.0));
		method_12(instance, "CSS_IN", method_5(8.0));
		method_12(instance, "CSS_PT", method_5(9.0));
		method_12(instance, "CSS_PC", method_5(10.0));
		method_12(instance, "CSS_DEG", method_5(11.0));
		method_12(instance, "CSS_RAD", method_5(12.0));
		method_12(instance, "CSS_GRAD", method_5(13.0));
		method_12(instance, "CSS_MS", method_5(14.0));
		method_12(instance, "CSS_S", method_5(15.0));
		method_12(instance, "CSS_HZ", method_5(16.0));
		method_12(instance, "CSS_KHZ", method_5(17.0));
		method_12(instance, "CSS_DIMENSION", method_5(18.0));
		method_12(instance, "CSS_STRING", method_5(19.0));
		method_12(instance, "CSS_URI", method_5(20.0));
		method_12(instance, "CSS_IDENT", method_5(21.0));
		method_12(instance, "CSS_ATTR", method_5(22.0));
		method_12(instance, "CSS_COUNTER", method_5(23.0));
		method_12(instance, "CSS_RECT", method_5(24.0));
		method_12(instance, "CSS_RGBCOLOR", method_5(25.0));
		base.vmethod_2(instance);
	}
}
