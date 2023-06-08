using System;
using ns305;
using ns322;
using ns323;

namespace ns324;

internal class Class7602 : Class7456
{
	private static readonly Type type_0 = typeof(Class6981);

	protected internal override Type Type => type_0;

	protected override Type InheritedType => typeof(Class6976);

	public override void Initialize()
	{
		method_10("getAttribute");
		method_10("setAttribute");
		method_10("removeAttribute");
		method_10("getAttributeNode");
		method_10("setAttributeNode");
		method_10("removeAttributeNode");
		method_10("getElementsByTagName");
		method_10("getAttributeNS");
		method_10("setAttributeNS");
		method_10("removeAttributeNS");
		method_10("getAttributeNodeNS");
		method_10("setAttributeNodeNS");
		method_10("getElementsByTagNameNS");
		method_10("hasAttribute");
		method_10("hasAttributeNS");
		method_10("setIdAttribute");
		method_10("setIdAttributeNS");
		method_10("setIdAttributeNode");
		method_11("tagName", Enum983.flag_0);
		method_11("schemaTypeInfo", Enum983.flag_0);
		method_11("firstElementChild", Enum983.flag_0);
		method_11("lastElementChild", Enum983.flag_0);
		method_11("previousElementSibling", Enum983.flag_0);
		method_11("nextElementSibling", Enum983.flag_0);
		method_11("childElementCount", Enum983.flag_0);
	}

	protected override Class7397 vmethod_1(string function, Class7397 instance, Class7397[] parameters)
	{
		Class6981 @class = (Class6981)instance.Value;
		switch (function)
		{
		case "get_tagName":
			return method_3(@class.TagName);
		case "getAttribute":
			if (parameters.Length != 1)
			{
				throw new Exception89("invalid arguments count.");
			}
			return method_3(@class.method_20(parameters[0].ToString()));
		case "setAttribute":
			if (parameters.Length != 2)
			{
				throw new Exception89("invalid arguments count.");
			}
			@class.method_21(parameters[0].ToString(), parameters[1].ToString());
			goto IL_0576;
		case "removeAttribute":
			if (parameters.Length != 1)
			{
				throw new Exception89("invalid arguments count.");
			}
			@class.method_22(parameters[0].ToString());
			goto IL_0576;
		case "getAttributeNode":
			if (parameters.Length != 1)
			{
				throw new Exception89("invalid arguments count.");
			}
			return method_2(@class.method_23(parameters[0].ToString()), typeof(Class7045));
		case "setAttributeNode":
			if (parameters.Length != 1)
			{
				throw new Exception89("invalid arguments count.");
			}
			return method_2(@class.method_24((Class7045)parameters[0].vmethod_5()), typeof(Class7045));
		case "removeAttributeNode":
			if (parameters.Length != 1)
			{
				throw new Exception89("invalid arguments count.");
			}
			return method_2(@class.method_25((Class7045)parameters[0].vmethod_5()), typeof(Class7045));
		case "getElementsByTagName":
		{
			if (parameters.Length != 1)
			{
				throw new Exception89("invalid arguments count.");
			}
			Class7075 value2 = @class.method_26(parameters[0].ToString());
			return method_2(value2, typeof(Class7075));
		}
		case "getAttributeNS":
			if (parameters.Length != 2)
			{
				throw new Exception89("invalid arguments count.");
			}
			return method_3(@class.method_28(parameters[0].ToString(), parameters[1].ToString()));
		case "setAttributeNS":
			if (parameters.Length != 3)
			{
				throw new Exception89("invalid arguments count.");
			}
			@class.method_29(parameters[0].ToString(), parameters[1].ToString(), parameters[2].ToString());
			goto IL_0576;
		case "removeAttributeNS":
			if (parameters.Length != 2)
			{
				throw new Exception89("invalid arguments count.");
			}
			@class.method_30(parameters[0].ToString(), parameters[1].ToString());
			goto IL_0576;
		case "getAttributeNodeNS":
			if (parameters.Length != 2)
			{
				throw new Exception89("invalid arguments count.");
			}
			return method_2(@class.method_31(parameters[0].ToString(), parameters[1].ToString()), typeof(Class7045));
		case "setAttributeNodeNS":
			if (parameters.Length != 1)
			{
				throw new Exception89("invalid arguments count.");
			}
			return method_2(@class.method_32((Class7045)parameters[0].vmethod_5()), typeof(Class7045));
		case "getElementsByTagNameNS":
		{
			if (parameters.Length != 2)
			{
				throw new Exception89("invalid arguments count.");
			}
			if (parameters.Length != 2)
			{
				throw new Exception89("invalid arguments count.");
			}
			Class7075 value = @class.method_33(parameters[0].ToString(), parameters[1].ToString());
			return method_2(value, typeof(Class7075));
		}
		case "hasAttribute":
			if (parameters.Length != 1)
			{
				throw new Exception89("invalid arguments count.");
			}
			return method_6(@class.method_34(parameters[0].ToString()));
		case "hasAttributeNS":
			if (parameters.Length != 2)
			{
				throw new Exception89("invalid arguments count.");
			}
			return method_6(@class.method_35(parameters[0].ToString(), parameters[1].ToString()));
		case "get_schemaTypeInfo":
			return method_2(@class.SchemaTypeInfo, typeof(Class7095));
		case "setIdAttribute":
			if (parameters.Length != 2)
			{
				throw new Exception89("invalid arguments count.");
			}
			@class.method_36(parameters[0].ToString(), parameters[1].vmethod_2());
			goto IL_0576;
		case "setIdAttributeNS":
			if (parameters.Length != 3)
			{
				throw new Exception89("invalid arguments count.");
			}
			@class.method_37(parameters[0].ToString(), parameters[1].ToString(), parameters[2].vmethod_2());
			goto IL_0576;
		case "setIdAttributeNode":
			if (parameters.Length != 2)
			{
				throw new Exception89("invalid arguments count.");
			}
			@class.method_38((Class7045)parameters[0].vmethod_5(), parameters[1].vmethod_2());
			goto IL_0576;
		case "get_firstElementChild":
		{
			Class6981 firstElementChild = @class.FirstElementChild;
			if (firstElementChild == null)
			{
				return base.Undefined;
			}
			return method_2(firstElementChild, firstElementChild.GetType());
		}
		case "get_lastElementChild":
		{
			Class6981 lastElementChild = @class.LastElementChild;
			if (lastElementChild == null)
			{
				return base.Undefined;
			}
			return method_2(lastElementChild, lastElementChild.GetType());
		}
		case "get_previousElementSibling":
		{
			Class6981 previousElementSibling = @class.PreviousElementSibling;
			if (previousElementSibling == null)
			{
				return base.Undefined;
			}
			return method_2(previousElementSibling, previousElementSibling.GetType());
		}
		case "get_nextElementSibling":
		{
			Class6981 nextElementSibling = @class.NextElementSibling;
			if (nextElementSibling == null)
			{
				return base.Undefined;
			}
			return method_2(nextElementSibling, nextElementSibling.GetType());
		}
		default:
			throw new Exception89("unknown function");
		case "get_childElementCount":
			{
				return method_5(@class.ChildElementCount);
			}
			IL_0576:
			return base.Undefined;
		}
	}
}
