using System;
using ns322;
using ns323;

namespace ns215;

internal class Class7556 : Class7456
{
	internal static readonly Type type_0 = typeof(Class5910);

	protected internal override Type Type => type_0;

	public override void Initialize()
	{
		method_10("absPage");
		method_10("absPageCount");
		method_10("absPageSpan");
		method_10("h");
		method_10("page");
		method_10("pageContent");
		method_10("pageCount");
		method_10("pageSpan");
		method_10("relayout");
		method_10("relayoutPageArea");
		method_10("w");
		method_10("x");
		method_10("y");
		method_11("ready", Enum983.flag_0);
	}

	protected override Class7397 vmethod_1(string function, Class7397 instance, Class7397[] parameters)
	{
		Class5910 @class = (Class5910)instance.Value;
		switch (function)
		{
		case "absPage":
		case "page":
			if (!@class.IsReady)
			{
				return base.Undefined;
			}
			return method_5(@class.method_3((Interface252)parameters[0].vmethod_5()));
		case "absPageCount":
		case "pageCount":
			return method_5(@class.PageCount);
		case "absPageSpan":
		case "pageSpan":
			if (!@class.IsReady)
			{
				return base.Undefined;
			}
			return method_5(@class.method_4((Interface252)parameters[0].vmethod_5()));
		case "pageContent":
			return base.Undefined;
		case "h":
			return base.Undefined;
		case "relayout":
			return base.Undefined;
		case "relayoutPageArea":
			return base.Undefined;
		case "w":
			return base.Undefined;
		case "x":
			return base.Undefined;
		case "y":
			return base.Undefined;
		default:
			throw new Exception89("unknown function");
		case "get_ready":
			return method_6(@class.IsReady);
		}
	}
}
