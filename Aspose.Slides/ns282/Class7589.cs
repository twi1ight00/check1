using System;
using ns304;
using ns305;
using ns322;
using ns323;

namespace ns282;

internal class Class7589 : Class7456
{
	private static readonly Type type_0 = typeof(Class7059);

	protected internal override Type Type => type_0;

	public override void Initialize()
	{
		method_10("initEvent");
		method_10("preventDefault");
		method_10("stopPropagation");
		method_11("bubbles", Enum983.flag_0);
		method_11("cancelable", Enum983.flag_0);
		method_11("currentTarget", Enum983.flag_0);
		method_11("eventPhase", Enum983.flag_0);
		method_11("target", Enum983.flag_0);
		method_11("timeStamp", Enum983.flag_0);
		method_11("type", Enum983.flag_0);
	}

	protected override Class7397 vmethod_1(string function, Class7397 instance, Class7397[] parameters)
	{
		Class7059 @class = (Class7059)instance.Value;
		switch (function)
		{
		case "get_bubbles":
			return method_6(@class.Bubbles);
		case "get_cancelable":
			return method_6(@class.Cancelable);
		case "get_currentTarget":
			if (@class.Target is Class6976 class3)
			{
				return method_2(class3, class3.GetType());
			}
			return base.Undefined;
		case "get_eventPhase":
			return method_5((double)@class.Phase);
		case "get_target":
			if (@class.Target is Class6976 class2)
			{
				return method_2(class2, class2.GetType());
			}
			return base.Undefined;
		case "get_timeStamp":
			return method_5(@class.TimeStamp);
		case "get_type":
			return method_3(@class.Type);
		case "initEvent":
		{
			if (parameters.Length != 3)
			{
				throw new Exception89("invalid arguments count.");
			}
			string eventTypeArg = parameters[0].ToString();
			bool canBubbleArg = parameters[1].vmethod_2();
			bool cancelableArg = parameters[2].vmethod_2();
			@class.imethod_0(eventTypeArg, canBubbleArg, cancelableArg);
			return base.Undefined;
		}
		case "preventDefault":
			if (parameters.Length != 0)
			{
				throw new Exception89("invalid arguments count.");
			}
			@class.imethod_1();
			return base.Undefined;
		case "stopPropagation":
			if (parameters.Length != 0)
			{
				throw new Exception89("invalid arguments count.");
			}
			@class.imethod_2();
			return base.Undefined;
		default:
			throw new Exception89("unknown function");
		}
	}
}
