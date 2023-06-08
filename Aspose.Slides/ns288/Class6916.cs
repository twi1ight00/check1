using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using ns183;
using ns271;
using ns277;
using ns284;
using ns287;
using ns297;
using ns301;
using ns302;
using ns305;
using ns73;
using ns76;
using ns84;
using ns87;

namespace ns288;

internal abstract class Class6916 : Interface339
{
	private readonly Class6964 class6964_0;

	private readonly Interface322 interface322_0;

	private readonly Interface355 interface355_0;

	public Interface355 Settings => interface355_0;

	protected Interface322 ResourceLoadingCallback => interface322_0;

	internal Class6964 StyleProvider => class6964_0;

	protected Class6916(Class6964 styleProvider, Interface355 settings, Interface322 resourceLoading)
	{
		Class6892.smethod_0(styleProvider, "styleProvider");
		Class6892.smethod_0(settings, "settings");
		Class6892.smethod_0(resourceLoading, "resourceLoading");
		class6964_0 = styleProvider;
		interface322_0 = resourceLoading;
		interface355_0 = settings;
	}

	protected internal abstract Class7047 vmethod_0(string rawHtml);

	public Class7047 method_0(Stream stream)
	{
		Class6892.smethod_0(stream, "stream");
		Class6961 @class = new Class6961(null, interface355_0.CharSet);
		Class7047 document = (Class7047)method_8(@class.method_1(stream));
		return method_1(document);
	}

	public Class7047 imethod_0(string rawHtml)
	{
		Class6892.smethod_1(rawHtml, "rawHtml");
		Class6961 @class = new Class6961(rawHtml, interface355_0.CharSet);
		Class7047 document = (Class7047)method_8(@class.method_0());
		return method_1(document);
	}

	private Class7047 method_1(Class7047 document)
	{
		method_7(document.DocumentElement as Class6983);
		method_2(document);
		if (document.FrameSet != null)
		{
			method_5(document.FrameSet);
		}
		method_4(document);
		return document;
	}

	private void method_2(Class7047 document)
	{
		foreach (Interface76 styleSheet in document.StyleSheets)
		{
			foreach (Interface59 cSSRule in styleSheet.CSSRules)
			{
				if (cSSRule.Type != 5)
				{
					continue;
				}
				Class4144 @class = Class4144.smethod_0((Interface60)cSSRule);
				string text = null;
				foreach (Class4145 item in @class.Src)
				{
					if ((item.Format != null && (item.Format.EndsWith(".ttf", StringComparison.OrdinalIgnoreCase) || item.Format.EndsWith(".woff", StringComparison.OrdinalIgnoreCase))) || (item.URI != null && (item.URI.EndsWith(".ttf", StringComparison.OrdinalIgnoreCase) || item.URI.EndsWith(".woff", StringComparison.OrdinalIgnoreCase))))
					{
						text = item.URI;
						break;
					}
				}
				if (text == null)
				{
					continue;
				}
				Class6814 class2 = method_3(text, cSSRule);
				if (class2.ExceptionIfAny != null || class2.Data == null)
				{
					continue;
				}
				byte[] array = class2.Data;
				if (text.EndsWith(".woff", StringComparison.OrdinalIgnoreCase))
				{
					using MemoryStream woff = new MemoryStream(array);
					using MemoryStream memoryStream = new MemoryStream();
					Class6736 class3 = new Class6736();
					class3.method_0(woff, memoryStream);
					array = memoryStream.ToArray();
				}
				Class5939.Instance.method_0(@class.FontFamily, Class4342.smethod_2(@class.Style), smethod_0(@class.FontWeight), array);
			}
		}
	}

	private Class6814 method_3(string path, Interface59 rule)
	{
		Uri uri = new Uri(path, UriKind.RelativeOrAbsolute);
		if (uri.IsAbsoluteUri)
		{
			return interface322_0.imethod_0(this, new EventArgs13(path));
		}
		if (rule.ParentStyleSheet != null)
		{
			path = Path.Combine(Path.GetDirectoryName(rule.ParentStyleSheet.Href), path);
		}
		Class6814 @class = interface322_0.imethod_0(this, new EventArgs13(path));
		if (@class.ExceptionIfAny == null)
		{
			return @class;
		}
		return interface322_0.imethod_0(this, new EventArgs13(Path.Combine(interface355_0.BasePath, path)));
	}

	private static int smethod_0(Class4226 weight)
	{
		return weight.Value;
	}

	private void method_4(Class7047 document)
	{
		Class7075 @class = document.method_45("IFRAME");
		foreach (Class6976 item in @class)
		{
			if (item is Class7016 class2)
			{
				class2.ContentDocument = method_6(class2.Src);
			}
		}
	}

	private void method_5(Class7011 frameSet)
	{
		IList<Class7010> frames = frameSet.Frames;
		foreach (Class7010 item in frames)
		{
			item.ContentDocument = method_6(item.Src);
		}
	}

	private Class7047 method_6(string src)
	{
		string text = src;
		if (string.IsNullOrEmpty(text))
		{
			return null;
		}
		text = Path.Combine(interface355_0.BasePath, text);
		Class6814 @class = interface322_0.imethod_0(this, new EventArgs13(text));
		if (@class.ExceptionIfAny == null && @class.Data != null)
		{
			string @string = Encoding.UTF8.GetString(@class.Data);
			return vmethod_0(@string);
		}
		return null;
	}

	private void method_7(Class6983 element)
	{
		element.Style = new Class6818(Class4347.smethod_1(element), element, Settings);
		foreach (Class6976 childNode in element.ChildNodes)
		{
			if (childNode.NodeType == Enum969.const_0 && !(childNode is Class7012))
			{
				method_7(childNode as Class6983);
			}
		}
	}

	protected Class7046 method_8(Class6908 documentNode)
	{
		Class7057 factory = new Class7058();
		string text = interface355_0.HtmlVersion ?? "html";
		Class7090 @class = new Class7090(factory, text);
		@class.Add(new Class7099(factory, text));
		Class7097 class2 = @class.method_0("HTML+CSS");
		Class7049 doctype = null;
		if (documentNode.FirstChild != null && documentNode.FirstChild.NodeType == Enum944.const_2)
		{
			string comment = ((Class6910)documentNode.FirstChild).Comment;
			doctype = method_9(comment, class2);
		}
		Class7047 class3 = (Class7047)class2.imethod_0("http://www.w3.org/1999/xhtml", string.Empty, doctype);
		Class4340 class4 = new Class4340();
		class4.Device.MediaType = interface355_0.Device.MediaType;
		class4.Device.Orientation = interface355_0.Device.Orientation;
		class4.Device.Resolution = interface355_0.Device.Resolution;
		class4.Device.ScreenSize = interface355_0.Device.ScreenSize;
		class4.Device.Scan = interface355_0.Device.Scan;
		class4.Device.WindowSize = interface355_0.Device.WindowSize;
		class4.CaseSensitive = text.Equals("XHTML", StringComparison.OrdinalIgnoreCase);
		class3.Engine = new Class3730().method_0(class3, new Class3723(new Class6777(interface322_0), class4));
		class6964_0.method_1(class3, class6964_0.DefaultStyle);
		foreach (Class6908 childNode in documentNode.ChildNodes)
		{
			Class6976 class6 = smethod_1(class3, childNode);
			if (class6 != null)
			{
				class6 = class3.vmethod_1(class6);
				class3.NamespaceManager.PushScope();
				method_10(class3, class6, childNode);
				class3.NamespaceManager.PopScope();
			}
		}
		class3.vmethod_7();
		class3.Engine.imethod_8(class3);
		return class3;
	}

	private Class7049 method_9(string doctypeString, Class7097 implementation)
	{
		if (!doctypeString.StartsWith("<!DOCTYPE"))
		{
			return null;
		}
		int num = doctypeString.IndexOf(' ');
		if (num == -1)
		{
			return null;
		}
		int num2 = doctypeString.Length - 1;
		int num3 = doctypeString.IndexOf(' ', num + 1);
		if (num3 == -1 && num != num2)
		{
			num3 = num2;
		}
		string qualifiedName = doctypeString.Substring(num + 1, num3 - num - 1);
		num = num3;
		string publicId = string.Empty;
		string empty = string.Empty;
		num3 = doctypeString.IndexOf(' ', num + 1);
		if (num3 == -1 && num != num2)
		{
			num3 = num2;
		}
		if (num3 != -1)
		{
			switch (doctypeString.Substring(num + 1, num3 - num - 1).ToUpper())
			{
			case "SYSTEM":
				num = num3;
				num3 = doctypeString.IndexOf('"', num + 2);
				if (num3 != -1)
				{
					publicId = doctypeString.Substring(num + 2, num3 - num - 2);
				}
				break;
			case "PUBLIC":
				num = num3;
				num3 = doctypeString.IndexOf('"', num + 2);
				if (num3 != -1)
				{
					publicId = doctypeString.Substring(num + 2, num3 - num - 2);
				}
				break;
			}
		}
		return implementation.imethod_2(qualifiedName, publicId, empty);
	}

	protected static Class6976 smethod_1(Class7046 document, Class6908 adapteeNode)
	{
		Class6976 @class = null;
		switch (adapteeNode.NodeType)
		{
		case Enum944.const_1:
			foreach (Class6901 attribute in adapteeNode.Attributes)
			{
				Class7045 class3 = document.method_25(attribute.Name);
				if (class3.Prefix.Equals("xmlns"))
				{
					document.NamespaceManager.AddNamespace(class3.LocalName, attribute.Value);
					break;
				}
			}
			@class = document.CreateElement(adapteeNode.Name);
			break;
		case Enum944.const_2:
			@class = document.method_22(((Class6910)adapteeNode).Comment);
			break;
		case Enum944.const_3:
			if (adapteeNode.NodeType == Enum944.const_3 && adapteeNode.InnerText.IndexOf('\u00a0') == -1 && string.IsNullOrEmpty(adapteeNode.InnerHtml.Trim()))
			{
				return null;
			}
			@class = document.method_21(((Class6909)adapteeNode).Text);
			break;
		}
		if (adapteeNode.Attributes != null && adapteeNode.Attributes.Count != 0)
		{
			foreach (Class6901 attribute2 in adapteeNode.Attributes)
			{
				Class7045 class5 = document.method_25(attribute2.Name);
				class5.Value = attribute2.Value;
				@class.Attributes.method_12(class5);
			}
		}
		return @class;
	}

	protected void method_10(Class7046 document, Class6976 node, Class6908 adapteeNode)
	{
		foreach (Class6908 childNode in adapteeNode.ChildNodes)
		{
			Class6976 class2 = smethod_1(document, childNode);
			if (class2 != null)
			{
				class2 = node.vmethod_1(class2);
				document.NamespaceManager.PushScope();
				method_10(document, class2, childNode);
				document.NamespaceManager.PopScope();
			}
		}
	}
}
