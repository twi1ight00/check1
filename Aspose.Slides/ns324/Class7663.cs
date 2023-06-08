using System;
using ns282;
using ns286;
using ns304;
using ns305;
using ns322;
using ns323;

namespace ns324;

internal class Class7663 : Class7456
{
	private static readonly Type type_0 = typeof(Class6976);

	protected internal override Type Type => type_0;

	public override void Initialize()
	{
		method_10("isSameNode");
		method_10("lookupPrefix");
		method_10("isDefaultNamespace");
		method_10("lookupNamespaceURI");
		method_10("isEqualNode");
		method_10("getFeature");
		method_10("setUserData");
		method_10("getUserData");
		method_10("insertBefore");
		method_10("replaceChild");
		method_10("removeChild");
		method_10("appendChild");
		method_10("hasChildNodes");
		method_10("cloneNode");
		method_10("normalize");
		method_10("isSupported");
		method_10("hasAttributes");
		method_10("compareDocumentPosition");
		method_10("addEventListener");
		method_10("removeEventListener");
		method_10("dispatchEvent");
		method_11("nodeName", Enum983.flag_0);
		method_11("nodeValue", Enum983.flag_0 | Enum983.flag_1);
		method_11("nodeType", Enum983.flag_0);
		method_11("parentNode", Enum983.flag_0);
		method_11("childNodes", Enum983.flag_0);
		method_11("firstChild", Enum983.flag_0);
		method_11("lastChild", Enum983.flag_0);
		method_11("previousSibling", Enum983.flag_0);
		method_11("nextSibling", Enum983.flag_0);
		method_11("attributes", Enum983.flag_0);
		method_11("ownerDocument", Enum983.flag_0);
		method_11("namespaceURI", Enum983.flag_0);
		method_11("prefix", Enum983.flag_0 | Enum983.flag_1);
		method_11("localName", Enum983.flag_0);
		method_11("baseURI", Enum983.flag_0);
		method_11("textContent", Enum983.flag_0 | Enum983.flag_1);
	}

	protected override Class7397 vmethod_1(string function, Class7397 instance, Class7397[] parameters)
	{
		Class6976 @class = (Class6976)instance.Value;
		switch (function)
		{
		case "set_textContent":
			@class.TextContent = parameters[0].ToString();
			goto IL_075e;
		case "isSameNode":
			if (parameters.Length != 1)
			{
				throw new Exception89("invalid arguments count.");
			}
			return method_6(@class.vmethod_3((Class6976)parameters[0].vmethod_5()));
		case "lookupPrefix":
			if (parameters.Length != 1)
			{
				throw new Exception89("invalid arguments count.");
			}
			return method_3(@class.method_8(parameters[0].ToString()));
		case "isDefaultNamespace":
			if (parameters.Length != 1)
			{
				throw new Exception89("invalid arguments count.");
			}
			return method_6(@class.method_9(parameters[0].ToString()));
		case "lookupNamespaceURI":
			if (parameters.Length != 1)
			{
				throw new Exception89("invalid arguments count.");
			}
			return method_3(@class.method_10(parameters[0].ToString()));
		case "isEqualNode":
			if (parameters.Length != 1)
			{
				throw new Exception89("invalid arguments count.");
			}
			return method_6(@class.method_11((Class6976)parameters[0].vmethod_5()));
		case "getFeature":
			if (parameters.Length != 2)
			{
				throw new Exception89("invalid arguments count.");
			}
			return method_7(@class.method_12(parameters[0].ToString(), parameters[0].ToString()));
		case "setUserData":
			if (parameters.Length != 3)
			{
				throw new Exception89("invalid arguments count.");
			}
			return method_7(@class.method_13(parameters[0].ToString(), parameters[1].vmethod_5(), (Interface374)parameters[2].vmethod_5()));
		case "getUserData":
			if (parameters.Length != 1)
			{
				throw new Exception89("invalid arguments count.");
			}
			return method_7(@class.method_14(parameters[0].ToString()));
		case "get_nodeName":
			return method_3(@class.NodeName);
		case "get_nodeValue":
			return method_3(@class.NodeValue);
		case "set_nodeValue":
			if (parameters.Length != 1)
			{
				throw new Exception89("invalid arguments count.");
			}
			@class.NodeValue = parameters[0].ToString();
			goto IL_075e;
		case "get_nodeType":
			return method_5((int)@class.NodeType);
		case "get_parentNode":
		{
			Class6976 parentNode = @class.ParentNode;
			if (parentNode == null)
			{
				return base.Undefined;
			}
			return method_2(parentNode, parentNode.GetType());
		}
		case "get_childNodes":
			return method_2(@class.ChildNodes, typeof(Class7075));
		case "get_firstChild":
		{
			Class6976 firstChild = @class.FirstChild;
			if (firstChild == null)
			{
				return base.Undefined;
			}
			return method_2(firstChild, firstChild.GetType());
		}
		case "get_lastChild":
		{
			Class6976 lastChild = @class.LastChild;
			if (lastChild == null)
			{
				return base.Undefined;
			}
			return method_2(lastChild, lastChild.GetType());
		}
		case "get_previousSibling":
		{
			Class6976 previousSibling = @class.PreviousSibling;
			if (previousSibling == null)
			{
				return base.Undefined;
			}
			return method_2(previousSibling, previousSibling.GetType());
		}
		case "get_nextSibling":
		{
			Class6976 nextSibling = @class.NextSibling;
			if (nextSibling == null)
			{
				return base.Undefined;
			}
			return method_2(nextSibling, nextSibling.GetType());
		}
		case "get_attributes":
			return method_2(@class.Attributes, typeof(Class7062));
		case "get_ownerDocument":
		{
			Class6976 ownerDocument = @class.OwnerDocument;
			if (ownerDocument == null)
			{
				return base.Undefined;
			}
			return method_2(ownerDocument, ownerDocument.GetType());
		}
		case "insertBefore":
		{
			if (parameters.Length != 2)
			{
				throw new Exception89("invalid arguments count.");
			}
			Class6976 class2 = @class.method_0((Class6976)parameters[0].vmethod_5(), (Class6976)parameters[1].vmethod_5());
			if (class2 == null)
			{
				return base.Undefined;
			}
			return method_2(class2, class2.GetType());
		}
		case "replaceChild":
		{
			if (parameters.Length != 2)
			{
				throw new Exception89("invalid arguments count.");
			}
			Class6976 class6 = @class.method_1((Class6976)parameters[0].vmethod_5(), (Class6976)parameters[1].vmethod_5());
			if (class6 == null)
			{
				return base.Undefined;
			}
			return method_2(class6, class6.GetType());
		}
		case "removeChild":
		{
			if (parameters.Length != 1)
			{
				throw new Exception89("invalid arguments count.");
			}
			Class6976 class5 = @class.method_2((Class6976)parameters[0].vmethod_5());
			if (class5 == null)
			{
				return base.Undefined;
			}
			return method_2(class5, class5.GetType());
		}
		case "appendChild":
		{
			if (parameters.Length != 1)
			{
				throw new Exception89("invalid arguments count.");
			}
			Class6976 class4 = @class.vmethod_1((Class6976)parameters[0].vmethod_5());
			if (class4 == null)
			{
				return base.Undefined;
			}
			return method_2(class4, class4.GetType());
		}
		case "hasChildNodes":
			return method_6(@class.method_3());
		case "cloneNode":
		{
			if (parameters.Length != 1)
			{
				throw new Exception89("invalid arguments count.");
			}
			Class6976 class3 = @class.vmethod_2(parameters[0].vmethod_2());
			if (class3 == null)
			{
				return base.Undefined;
			}
			return method_2(class3, class3.GetType());
		}
		case "normalize":
			@class.method_4();
			goto IL_075e;
		case "isSupported":
			if (parameters.Length != 2)
			{
				throw new Exception89("invalid arguments count.");
			}
			return method_6(@class.method_5(parameters[0].ToString(), parameters[1].ToString()));
		case "get_namespaceURI":
			return method_3(@class.NamespaceURI);
		case "get_prefix":
			return method_3(@class.Prefix);
		case "set_prefix":
			@class.Prefix = parameters[0].ToString();
			goto IL_075e;
		case "get_localName":
			return method_3(@class.LocalName);
		case "hasAttributes":
			return method_6(@class.method_6());
		case "get_baseURI":
			return method_3(@class.BaseURI);
		case "compareDocumentPosition":
			if (parameters.Length != 1)
			{
				throw new Exception89("invalid arguments count.");
			}
			return method_5((double)@class.method_7((Class6976)parameters[0].vmethod_5()));
		case "get_textContent":
			return method_3(@class.TextContent);
		case "addEventListener":
		{
			if (parameters.Length != 3)
			{
				throw new Exception89("invalid arguments count.");
			}
			string type2 = parameters[0].ToString();
			Class7397 function3 = parameters[1];
			bool useCapture2 = parameters[2].vmethod_2();
			Interface365 listener2 = new Class6768(Class6805.Current.ScriptEngine, method_2(@class, @class.GetType()), function3);
			@class.imethod_0(type2, listener2, useCapture2);
			return base.Undefined;
		}
		case "removeEventListener":
		{
			if (parameters.Length != 3)
			{
				throw new Exception89("invalid arguments count.");
			}
			string type = parameters[0].ToString();
			Class7397 function2 = parameters[1];
			bool useCapture = parameters[2].vmethod_2();
			Interface365 listener = new Class6768(Class6805.Current.ScriptEngine, method_2(@class, @class.GetType()), function2);
			@class.imethod_0(type, listener, useCapture);
			return base.Undefined;
		}
		case "dispatchEvent":
		{
			if (parameters.Length != 1)
			{
				throw new Exception89("invalid arguments count.");
			}
			Class7059 @event = (Class7059)parameters[0].vmethod_5();
			return method_6(@class.imethod_1(@event));
		}
		default:
			{
				throw new Exception89("unknown function");
			}
			IL_075e:
			return base.Undefined;
		}
	}
}
