using System;
using ns217;
using ns322;
using ns323;

namespace ns215;

internal class Class7558 : Class7456
{
	internal static readonly Type type_0 = typeof(Class5780);

	protected internal override Type Type => type_0;

	protected override Type InheritedType => Class7557.type_0;

	public override void Initialize()
	{
		method_10("resolveNode");
		method_10("resolveNodes");
		method_11("all", Enum983.flag_0);
		method_11("classAll", Enum983.flag_0);
		method_11("classIndex", Enum983.flag_0);
		method_11("index", Enum983.flag_0);
		method_11("name", Enum983.flag_0 | Enum983.flag_1);
		method_11("nodes", Enum983.flag_0);
		method_11("parent", Enum983.flag_0);
		method_11("somExpression", Enum983.flag_0);
	}

	protected override Class7397 vmethod_1(string function, Class7397 instance, Class7397[] parameters)
	{
		Class5780 @class = (Class5780)instance.Value;
		switch (function)
		{
		case "resolveNode":
		{
			Class5781 class3 = @class.method_0(parameters[0].ToString());
			if (class3 == null)
			{
				return base.Undefined;
			}
			return method_2(class3, class3.GetType());
		}
		case "resolveNodes":
		{
			Class5908 class2 = @class.method_3(parameters[0].ToString());
			return method_2(class2, class2.GetType());
		}
		case "get_all":
			return base.Undefined;
		case "get_classAll":
			return base.Undefined;
		case "get_classIndex":
			return base.Undefined;
		case "get_name":
			return method_3(@class.Name);
		case "get_index":
			return method_5(@class.Index);
		case "set_name":
			@class.Name = parameters[0].ToString();
			return base.Undefined;
		case "get_nodes":
			return method_2(@class.Nodes, @class.Nodes.GetType());
		case "get_parent":
			return method_2(@class.Parent, @class.Parent.GetType());
		default:
			throw new Exception89("unknown function");
		case "get_somExpression":
			return method_3(@class.SomExpression);
		}
	}
}
