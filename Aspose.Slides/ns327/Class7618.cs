using System;
using System.Collections.Generic;
using System.Text;
using ns281;
using ns284;
using ns286;
using ns287;
using ns305;
using ns322;
using ns323;
using ns73;

namespace ns327;

internal class Class7618 : Class7456
{
	private static readonly Dictionary<Class7046, Class6766> dictionary_0 = new Dictionary<Class7046, Class6766>();

	private static readonly object object_0 = new object();

	private static readonly Type type_0 = typeof(Class7047);

	protected internal override Type Type => type_0;

	protected override Type InheritedType => typeof(Class7046);

	public override void Initialize()
	{
		method_10("open");
		method_10("close");
		method_10("write");
		method_10("writeln");
		method_10("getElementsByName");
		method_10("normalizeDocument");
		method_11("title", Enum983.flag_0 | Enum983.flag_1);
		method_11("referrer", Enum983.flag_0);
		method_11("domain", Enum983.flag_0);
		method_11("URL", Enum983.flag_0);
		method_11("body", Enum983.flag_0 | Enum983.flag_1);
		method_11("images", Enum983.flag_0);
		method_11("applets", Enum983.flag_0);
		method_11("links", Enum983.flag_0);
		method_11("forms", Enum983.flag_0);
		method_11("anchors", Enum983.flag_0);
		method_11("cookie", Enum983.flag_0 | Enum983.flag_1);
		method_11("defaultView", Enum983.flag_0);
	}

	protected override Class7397 vmethod_1(string function, Class7397 instance, Class7397[] parameters)
	{
		Class7047 @class = (Class7047)instance.Value;
		switch (function)
		{
		case "get_title":
			return method_3(@class.Title);
		case "set_title":
			@class.Title = parameters[0].ToString();
			break;
		case "get_referrer":
			return method_3(@class.Referrer);
		case "get_domain":
			return method_3(@class.Domain);
		case "get_URL":
			return method_3(@class.URL);
		case "get_body":
			return method_2(@class.Body, typeof(Class7001));
		case "set_body":
			if (parameters.Length != 1)
			{
				throw new Exception89("invalid arguments count.");
			}
			@class.Body = (Class7001)parameters[0].Value;
			break;
		case "get_images":
			return method_2(@class.Images, typeof(Class7078));
		case "get_applets":
			return method_2(@class.Applets, typeof(Class7078));
		case "get_links":
			return method_2(@class.Links, typeof(Class7078));
		case "get_forms":
			return method_2(@class.Forms, typeof(Class7078));
		case "get_anchors":
			return method_2(@class.Anchors, typeof(Class7078));
		case "get_cookie":
			return method_3(@class.Cookie);
		case "set_cookie":
			if (parameters.Length != 1)
			{
				throw new Exception89("invalid arguments count.");
			}
			@class.Cookie = parameters[0].ToString();
			break;
		case "get_defaultView":
			return method_2(@class.DefaultView, typeof(Interface56));
		case "write":
			if (parameters.Length < 1)
			{
				throw new Exception89("invalid arguments count.");
			}
			foreach (Class7397 class4 in parameters)
			{
				if (class4.Value != null)
				{
					string text = class4.ToString();
					if (!string.IsNullOrEmpty(text))
					{
						Write(text);
					}
				}
			}
			break;
		case "writeln":
		{
			if (parameters.Length < 1)
			{
				throw new Exception89("invalid arguments count.");
			}
			StringBuilder stringBuilder = new StringBuilder();
			foreach (Class7397 class3 in parameters)
			{
				string value = class3.ToString();
				if (!string.IsNullOrEmpty(value))
				{
					stringBuilder.AppendLine(value);
					Write(stringBuilder.ToString());
					stringBuilder.Remove(0, stringBuilder.Length);
				}
			}
			break;
		}
		case "getElementsByName":
		{
			if (parameters.Length != 1)
			{
				throw new Exception89("invalid arguments count.");
			}
			Class7397 class2 = method_2(@class.method_45(parameters[0].ToString()), typeof(Class7075));
			class2.Indexer = method_0(typeof(Class7670)) as Interface403;
			return class2;
		}
		default:
			throw new Exception89("unknown function");
		case "open":
		case "close":
		case "normalizeDocument":
			break;
		}
		return base.Undefined;
	}

	private static void Write(string html)
	{
		Class6805 current = Class6805.Current;
		if (current == null)
		{
			throw new ApplicationException("ScriptExecutionContext is not created.");
		}
		Class6983 currentProcessingElement = current.CurrentProcessingElement;
		if (currentProcessingElement == null)
		{
			return;
		}
		Class7046 ownerDocument = currentProcessingElement.OwnerDocument;
		lock (object_0)
		{
			if (!dictionary_0.ContainsKey(ownerDocument))
			{
				dictionary_0.Add(ownerDocument, new Class6766(current.GlobalSettings, current.ResourceLoadingCallback));
			}
		}
		Class6766 @class = dictionary_0[ownerDocument];
		Class6976 class2 = @class.Write(html);
		if (class2 == null)
		{
			return;
		}
		List<Class6976> list = new List<Class6976>(class2.ChildNodes);
		foreach (Class6976 item in list)
		{
			Class6976 newChild = ownerDocument.method_35(item, deep: true);
			currentProcessingElement.ParentElement.vmethod_1(newChild);
		}
	}
}
