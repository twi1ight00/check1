using System;
using ns281;
using ns304;
using ns305;
using ns322;
using ns323;

namespace ns324;

internal class Class7591 : Class7456
{
	private static readonly Type type_0 = typeof(Class7046);

	protected internal override Type Type => type_0;

	protected override Type InheritedType => typeof(Class6976);

	public override void Initialize()
	{
		method_10("normalizeDocument");
		method_10("renameNode");
		method_10("createElement");
		method_10("createDocumentFragment");
		method_10("createTextNode");
		method_10("createComment");
		method_10("createCDATASection");
		method_10("createProcessingInstruction");
		method_10("createAttribute");
		method_10("createEntityReference");
		method_10("getElementsByTagName");
		method_10("importNode");
		method_10("createElementNS");
		method_10("createAttributeNS");
		method_10("getElementsByTagNameNS");
		method_10("getElementById");
		method_10("adoptNode");
		method_10("createEvent");
		method_11("doctype", Enum983.flag_0);
		method_11("implementation", Enum983.flag_0);
		method_11("documentElement", Enum983.flag_0);
		method_11("inputEncoding", Enum983.flag_0);
		method_11("xmlEncoding", Enum983.flag_0);
		method_11("xmlStandalone", Enum983.flag_0 | Enum983.flag_1);
		method_11("xmlVersion", Enum983.flag_0 | Enum983.flag_1);
		method_11("strictErrorChecking", Enum983.flag_0 | Enum983.flag_1);
		method_11("documentURI", Enum983.flag_0 | Enum983.flag_1);
		method_11("domConfig", Enum983.flag_0);
		method_11("defaultView", Enum983.flag_0);
	}

	protected override Class7397 vmethod_1(string function, Class7397 instance, Class7397[] parameters)
	{
		Class7046 @class = (Class7046)instance.Value;
		switch (function)
		{
		case "get_domConfig":
			return method_2(@class.DomConfig, typeof(Class7073));
		case "normalizeDocument":
			@class.method_4();
			goto case "set_documentURI";
		case "renameNode":
		{
			if (parameters.Length != 3)
			{
				throw new Exception89("invalid arguments count.");
			}
			Class6976 class5 = @class.method_41((Class6976)parameters[0].vmethod_5(), parameters[1].ToString(), parameters[2].ToString());
			return method_2(class5, class5.GetType());
		}
		case "get_doctype":
			return method_2(@class.Doctype, typeof(Class7049));
		case "get_implementation":
			return method_2(@class.Implementation, typeof(Class7097));
		case "get_documentElement":
		{
			Class6976 documentElement = @class.DocumentElement;
			if (documentElement == null)
			{
				return base.Undefined;
			}
			return method_2(documentElement, documentElement.GetType());
		}
		case "createElement":
		{
			if (parameters.Length != 1)
			{
				throw new Exception89("invalid arguments count.");
			}
			Class6976 class4 = @class.CreateElement(parameters[0].ToString());
			return method_2(class4, class4.GetType());
		}
		case "createDocumentFragment":
			return method_2(@class.method_20(), typeof(Class7048));
		case "createTextNode":
			if (parameters.Length != 1)
			{
				throw new Exception89("invalid arguments count.");
			}
			return method_2(@class.method_21(parameters[0].ToString()), typeof(Class6980));
		case "createComment":
			if (parameters.Length != 1)
			{
				throw new Exception89("invalid arguments count.");
			}
			return method_2(@class.method_22(parameters[0].ToString()), typeof(Class6979));
		case "createCDATASection":
			if (parameters.Length != 1)
			{
				throw new Exception89("invalid arguments count.");
			}
			return method_2(@class.method_23(parameters[0].ToString()), typeof(Class6978));
		case "createProcessingInstruction":
			if (parameters.Length != 2)
			{
				throw new Exception89("invalid arguments count.");
			}
			return method_2(@class.method_24(parameters[0].ToString(), parameters[1].ToString()), typeof(Class7053));
		case "createAttribute":
			if (parameters.Length != 1)
			{
				throw new Exception89("invalid arguments count.");
			}
			return method_2(@class.method_25(parameters[0].ToString()), typeof(Class7045));
		case "createEntityReference":
			if (parameters.Length != 1)
			{
				throw new Exception89("invalid arguments count.");
			}
			return method_2(@class.method_28(parameters[0].ToString()), typeof(Class7052));
		case "getElementsByTagName":
		{
			if (parameters.Length != 1)
			{
				throw new Exception89("invalid arguments count.");
			}
			Class7075 value = @class.method_31(parameters[0].ToString());
			Class7397 class7 = method_2(value, typeof(Class7075));
			class7.Indexer = method_0(typeof(Class7670)) as Interface403;
			return class7;
		}
		case "importNode":
		{
			if (parameters.Length != 2)
			{
				throw new Exception89("invalid arguments count.");
			}
			Class6976 class6 = @class.method_35((Class6976)parameters[0].vmethod_5(), parameters[1].vmethod_2());
			if (class6 == null)
			{
				return base.Undefined;
			}
			return method_2(class6, class6.GetType());
		}
		case "createElementNS":
		{
			if (parameters.Length != 2)
			{
				throw new Exception89("invalid arguments count.");
			}
			Class6981 class3 = @class.method_36(parameters[0].ToString(), parameters[1].ToString());
			return method_2(class3, class3.GetType());
		}
		case "createAttributeNS":
		{
			if (parameters.Length != 2)
			{
				throw new Exception89("invalid arguments count.");
			}
			Class7045 class10 = @class.method_37(parameters[0].ToString(), parameters[1].ToString());
			return method_2(class10, class10.GetType());
		}
		case "getElementsByTagNameNS":
		{
			if (parameters.Length != 2)
			{
				throw new Exception89("invalid arguments count.");
			}
			Class7075 value2 = @class.method_38(parameters[0].ToString(), parameters[1].ToString());
			Class7397 class9 = method_2(value2, typeof(Class7075));
			class9.Indexer = method_0(typeof(Class7670)) as Interface403;
			return class9;
		}
		case "getElementById":
		{
			if (parameters.Length != 1)
			{
				throw new Exception89("invalid arguments count.");
			}
			Class6981 class8 = @class.method_39(parameters[0].ToString());
			if (class8 == null)
			{
				return base.Undefined;
			}
			return method_2(class8, class8.GetType());
		}
		case "get_inputEncoding":
			return method_3(@class.InputEncoding);
		case "get_xmlEncoding":
			return method_3(@class.XmlEncoding);
		case "get_xmlStandalone":
			return method_6(@class.XmlStandalone);
		case "set_xmlStandalone":
			if (parameters.Length != 1)
			{
				throw new Exception89("invalid arguments count.");
			}
			@class.XmlStandalone = parameters[0].vmethod_2();
			goto case "set_documentURI";
		case "get_xmlVersion":
			return method_3(@class.XmlVersion);
		case "set_xmlVersion":
			if (parameters.Length != 1)
			{
				throw new Exception89("invalid arguments count.");
			}
			@class.XmlVersion = parameters[0].ToString();
			goto case "set_documentURI";
		case "get_strictErrorChecking":
			return method_6(@class.StrictErrorChecking);
		case "set_strictErrorChecking":
			if (parameters.Length != 1)
			{
				throw new Exception89("invalid arguments count.");
			}
			@class.StrictErrorChecking = parameters[0].vmethod_2();
			goto case "set_documentURI";
		case "get_documentURI":
			return method_3(@class.DocumentURI);
		case "set_documentURI":
			return base.Undefined;
		case "adoptNode":
		{
			if (parameters.Length != 1)
			{
				throw new Exception89("invalid arguments count.");
			}
			Class6976 class2 = @class.method_40((Class6976)parameters[0].vmethod_5());
			if (class2 == null)
			{
				return base.Undefined;
			}
			return method_2(class2, class2.GetType());
		}
		case "createEvent":
			if (parameters.Length != 1)
			{
				throw new Exception89("invalid arguments count.");
			}
			return method_2(new Class7059(), typeof(Class7059));
		default:
			throw new Exception89("unknown function");
		}
	}
}
