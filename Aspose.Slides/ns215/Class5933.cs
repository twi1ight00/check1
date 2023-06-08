using System;
using System.Drawing;
using System.Text;
using System.Xml;
using Aspose.XfaConverter.Elements;
using ns216;
using ns217;
using ns322;
using ns323;

namespace ns215;

internal class Class5933
{
	private int int_0;

	private int int_1;

	public static Class7685 smethod_0()
	{
		Class7685 @class = new Class7685();
		@class.method_5(new Class7557());
		@class.method_5(new Class7558());
		@class.method_5(new Class7559());
		@class.method_5(new Class7552());
		@class.method_5(new Class7555());
		@class.method_5(new Class7556());
		@class.method_5(new Class7553());
		@class.method_5(new Class7546());
		@class.method_5(new Class7547());
		@class.method_5(new Class7548());
		@class.method_5(new Class7549());
		@class.method_5(new Class7550());
		@class.method_5(new Class7551());
		@class.method_5(new Class7554());
		@class.method_5(new Class7459());
		@class.method_5(new Class7460());
		@class.method_5(new Class7461());
		@class.method_5(new Class7462());
		@class.method_5(new Class7463());
		@class.method_5(new Class7464());
		@class.method_5(new Class7465());
		@class.method_5(new Class7466());
		@class.method_5(new Class7467());
		@class.method_5(new Class7468());
		@class.method_5(new Class7499());
		@class.method_5(new Class7469());
		@class.method_5(new Class7470());
		@class.method_5(new Class7471());
		@class.method_5(new Class7472());
		@class.method_5(new Class7473());
		@class.method_5(new Class7474());
		@class.method_5(new Class7475());
		@class.method_5(new Class7476());
		@class.method_5(new Class7477());
		@class.method_5(new Class7478());
		@class.method_5(new Class7479());
		@class.method_5(new Class7480());
		@class.method_5(new Class7481());
		@class.method_5(new Class7482());
		@class.method_5(new Class7483());
		@class.method_5(new Class7484());
		@class.method_5(new Class7485());
		@class.method_5(new Class7486());
		@class.method_5(new Class7487());
		@class.method_5(new Class7488());
		@class.method_5(new Class7489());
		@class.method_5(new Class7490());
		@class.method_5(new Class7491());
		@class.method_5(new Class7492());
		@class.method_5(new Class7493());
		@class.method_5(new Class7494());
		@class.method_5(new Class7495());
		@class.method_5(new Class7496());
		@class.method_5(new Class7497());
		@class.method_5(new Class7498());
		@class.method_5(new Class7500());
		@class.method_5(new Class7501());
		@class.method_5(new Class7502());
		@class.method_5(new Class7503());
		@class.method_5(new Class7504());
		@class.method_5(new Class7505());
		@class.method_5(new Class7506());
		@class.method_5(new Class7507());
		@class.method_5(new Class7508());
		@class.method_5(new Class7509());
		@class.method_5(new Class7510());
		@class.method_5(new Class7511());
		@class.method_5(new Class7512());
		@class.method_5(new Class7513());
		@class.method_5(new Class7514());
		@class.method_5(new Class7515());
		@class.method_5(new Class7516());
		@class.method_5(new Class7517());
		@class.method_5(new Class7518());
		@class.method_5(new Class7519());
		@class.method_5(new Class7520());
		@class.method_5(new Class7521());
		@class.method_5(new Class7522());
		@class.method_5(new Class7523());
		@class.method_5(new Class7524());
		@class.method_5(new Class7525());
		@class.method_5(new Class7526());
		@class.method_5(new Class7527());
		@class.method_5(new Class7528());
		@class.method_5(new Class7541());
		@class.method_5(new Class7529());
		@class.method_5(new Class7530());
		@class.method_5(new Class7531());
		@class.method_5(new Class7532());
		@class.method_5(new Class7533());
		@class.method_5(new Class7534());
		@class.method_5(new Class7535());
		@class.method_5(new Class7536());
		@class.method_5(new Class7537());
		@class.method_5(new Class7538());
		@class.method_5(new Class7539());
		@class.method_5(new Class7540());
		@class.method_5(new Class7542());
		@class.method_5(new Class7543());
		@class.method_5(new Class7544());
		@class.method_5(new Class7545());
		return @class;
	}

	private static string smethod_1(string value)
	{
		return value.Replace("&amp;", "&").Replace("&lt;", "<").Replace("&gt;", ">");
	}

	private void method_0(Class5781 node, Class7685 javaScriptEngine, StringBuilder variablesContent, int level)
	{
		StringBuilder stringBuilder = new StringBuilder(variablesContent.ToString());
		smethod_2(node, stringBuilder);
		if (node.method_0("#calculate.#script") is Class5885 @class && @class.Value != null)
		{
			bool flag = (string)@class.Attributes["contentType"].Value == "application/x-javascript";
			string text = @class.Value;
			if (!flag)
			{
				text = text.Replace("$.", "this.").Replace("$ =", "this.rawValue =").Replace("$=", "this.rawValue =");
			}
			stringBuilder.Append(smethod_1(text));
			for (int i = 0; i < level; i++)
			{
				stringBuilder.Append('}');
			}
			try
			{
				javaScriptEngine.method_3(stringBuilder.ToString());
				int_0++;
			}
			catch (Exception)
			{
				int_1++;
			}
		}
		Class5885 class2 = node.method_0("#event.#script") as Class5885;
		try
		{
			if (class2 != null && class2.Value != null && (string)class2.Attributes["contentType"].Value == "application/x-javascript" && ((XfaEnums.Activity)class2.Parent.Attributes["activity"].Value == XfaEnums.Activity.Iinitialize || (XfaEnums.Activity)class2.Parent.Attributes["activity"].Value == XfaEnums.Activity.Ready))
			{
				stringBuilder.Append(smethod_1(class2.Value));
				for (int j = 0; j < level; j++)
				{
					stringBuilder.Append('}');
				}
				try
				{
					javaScriptEngine.method_3(stringBuilder.ToString());
					int_0++;
					return;
				}
				catch (Exception)
				{
					int_1++;
					return;
				}
			}
		}
		catch (Exception value)
		{
			Console.WriteLine(value);
		}
	}

	private static void smethod_2(Class5781 node, StringBuilder variablesContent)
	{
		string arg = $"xfa.resolveNode('{node.SomExpression}')";
		variablesContent.AppendFormat("with({0})", arg).Append("{ ").AppendLine($"this = {arg};");
	}

	private void method_1(Class5908 nodes, Class7685 javaScriptEngine, StringBuilder variablesContent, int level)
	{
		foreach (Class5781 item in nodes.List)
		{
			method_0(item, javaScriptEngine, variablesContent, level);
		}
		foreach (Class5781 item2 in nodes.List)
		{
			StringBuilder stringBuilder = new StringBuilder(variablesContent.ToString());
			smethod_2(item2, stringBuilder);
			if (item2.method_0("#variables.#script") is Class5885 @class && (string)@class.Attributes["contentType"].Value == "application/x-javascript")
			{
				if (@class.Parent is Class5857 && @class.Value != null && !string.IsNullOrEmpty(@class.Name))
				{
					javaScriptEngine.method_5(new Class7455(@class.Name, @class, smethod_1(@class.Value)));
					int_0++;
				}
				else
				{
					stringBuilder.Append(@class.Value);
				}
			}
			method_1(item2.Nodes, javaScriptEngine, stringBuilder, level + 1);
		}
	}

	internal Class5910 method_2(XmlDocument template, XmlDocument datasets, SizeF size, Class7685 javaScriptEngine)
	{
		XmlNamespaceManager xmlNamespaceManager = new XmlNamespaceManager(template.NameTable);
		string namespaceURI = template.DocumentElement.NamespaceURI;
		xmlNamespaceManager.AddNamespace("tpl", namespaceURI);
		Class5932 @class = new Class5932(xmlNamespaceManager, javaScriptEngine);
		Class5784 class2 = new Class5784();
		Class5910 class3 = new Class5910(class2);
		javaScriptEngine.method_5(new Class7455("xfa", class2));
		class2.vmethod_5(@class, template);
		foreach (Class5782 prototypedElement in @class.PrototypedElements)
		{
			string text = prototypedElement.Attributes["use"].Value.ToString();
			if (!text.StartsWith("#"))
			{
				if (!text.StartsWith(".") && !text.StartsWith("xfa."))
				{
					text = ".." + text;
				}
				if (class2.method_0(text) is Class5782 class4 && class4.ClassName == prototypedElement.ClassName)
				{
					prototypedElement.vmethod_6(class4);
				}
			}
		}
		StringBuilder stringBuilder = new StringBuilder();
		method_1(class2.Nodes, javaScriptEngine, stringBuilder, 1);
		method_6(datasets, class2);
		Class5848 subform = (Class5848)class2.method_0("template.#subform");
		method_7(subform, class3, size);
		class3.IsReady = true;
		stringBuilder.Length = 0;
		stringBuilder.Capacity = 0;
		method_1(class2.Nodes, javaScriptEngine, stringBuilder, 1);
		return class3;
	}

	internal void method_3(Class5912 documentBuilder, Class5910 layoutsModel, Class7685 javaScriptEngine)
	{
		for (int i = 0; i < layoutsModel.Layouts.Count; i++)
		{
			documentBuilder.method_0(layoutsModel.PageSizes[i]);
			layoutsModel.Layouts[i].method_6(documentBuilder);
			documentBuilder.method_8();
		}
	}

	private void method_4(Class5781 node)
	{
		Console.Out.WriteLine(node.SomExpression);
		foreach (Class5781 item in node.Nodes.List)
		{
			method_4(item);
		}
	}

	private void method_5(Class5896 node, Class5784 xfa, bool setValues)
	{
		if ((setValues && node is Class5897) || (!setValues && !(node is Class5897)))
		{
			node.vmethod_5(xfa);
		}
		foreach (Class5781 item in node.Nodes.List)
		{
			method_5((Class5896)item, xfa, setValues);
		}
	}

	internal void method_6(XmlDocument datasets, Class5784 xfa)
	{
		XmlNamespaceManager xmlNamespaceManager = new XmlNamespaceManager(datasets.NameTable);
		string namespaceURI = datasets.DocumentElement.NamespaceURI;
		xmlNamespaceManager.AddNamespace("dt", namespaceURI);
		XmlNodeList xmlNodeList = datasets.DocumentElement.SelectNodes("dt:data", xmlNamespaceManager);
		Class5896 @class = new Class5896(Class5784.Tag);
		Class5896 class2 = new Class5896(Class5852.Tag);
		@class.Nodes.method_0(class2);
		class2.Parent = @class;
		class2.vmethod_4(xmlNodeList[0]);
		method_5(class2, xfa, setValues: false);
		method_5(class2, xfa, setValues: true);
	}

	internal void method_7(Class5848 subform, Class5910 pseudoModel, SizeF size)
	{
		Class5916 commonLayout = Class5928.smethod_0(subform, isCommon: true);
		commonLayout.vmethod_3();
		Class5925 pageContentProvider = new Class5925(subform.method_6(Class5835.Tag) as Class5835);
		commonLayout.method_4(pageContentProvider);
		Class5908 @class = subform.method_3("..#pageArea[*]");
		foreach (Class5834 item in @class.List)
		{
			SizeF pageSize = size;
			Class5832 class3 = item.method_6(Class5832.Tag) as Class5832;
			int num = -1;
			if (class3 != null)
			{
				num = class3.Max;
			}
			if (item.method_6(Class5879.Tag) is Class5879 class4)
			{
				switch (class4.Orientation)
				{
				case XfaEnums.Enum736.const_0:
					if (class4.L != 0f)
					{
						pageSize.Height = class4.L;
					}
					if (class4.S != 0f)
					{
						pageSize.Width = class4.S;
					}
					break;
				case XfaEnums.Enum736.const_1:
					if (class4.L != 0f)
					{
						pageSize.Width = class4.L;
					}
					if (class4.S != 0f)
					{
						pageSize.Height = class4.S;
					}
					break;
				}
			}
			int num2 = 0;
			while (num != 0 && commonLayout != null)
			{
				Class5791 @break = commonLayout.Break;
				if (@break == null && commonLayout.NativeObj.Equals(subform))
				{
					foreach (Class5914 item2 in commonLayout.arrayList_0)
					{
						if (!item2.IsHidden)
						{
							if (item2 is Class5916 class6)
							{
								@break = class6.Break;
							}
							break;
						}
					}
				}
				if (@break != null)
				{
					string text = @break.BeforeTarget.Trim(' ').Trim('#');
					if (@break.Before == XfaEnums.Enum688.const_2)
					{
						if (!string.IsNullOrEmpty(text) && item.Id != text && item.Name != text)
						{
							break;
						}
						@break.Processed = true;
					}
					else if (@break.After == XfaEnums.Enum688.const_2)
					{
						if (!(item.Id != text))
						{
							@break.Processed = true;
							break;
						}
						if (!@break.Processed)
						{
							break;
						}
					}
					else
					{
						@break.Processed = true;
					}
				}
				Class5834 class7 = item;
				if (num2 > 0)
				{
					class7 = (Class5834)item.Clone();
					item.Parent.Nodes.method_0(class7);
				}
				Class5919 class8 = (Class5919)Class5928.smethod_0(class7, isCommon: false);
				class8.method_7(ref commonLayout, class7);
				pseudoModel.method_1(class8, class7, pageSize);
				num--;
				num2++;
			}
			if (commonLayout == null)
			{
				break;
			}
		}
		pseudoModel.method_2(subform);
	}
}
