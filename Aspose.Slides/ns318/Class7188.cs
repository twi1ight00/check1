using System;
using System.Collections;
using System.IO;
using System.Xml;
using ns312;
using ns313;

namespace ns318;

internal static class Class7188
{
	public static void smethod_0(ref Hashtable nodeAttributes, string style)
	{
		string empty = string.Empty;
		string empty2 = string.Empty;
		string[] array = style.Split(new string[4] { ";", "\r", "\n", "\t" }, StringSplitOptions.RemoveEmptyEntries);
		string[] array2 = array;
		foreach (string text in array2)
		{
			string[] array3 = text.Split(new string[1] { ":" }, StringSplitOptions.RemoveEmptyEntries);
			if (array3.Length >= 2)
			{
				empty = array3[0].Trim();
				empty2 = array3[1].Trim();
				if (nodeAttributes.ContainsKey(empty))
				{
					nodeAttributes.Remove(empty);
				}
				nodeAttributes.Add(empty, empty2);
			}
		}
	}

	public static Class7167 smethod_1(string svgAreaBody)
	{
		Class7167 @class = new Class7167();
		svgAreaBody = svgAreaBody.Replace("xlink:href", "xlinkhref");
		try
		{
			Class7132 obj = (@class.class7132_0 = new Class7132("root", new Hashtable(), null));
			svgAreaBody = svgAreaBody.Substring(svgAreaBody.IndexOf("<svg"), svgAreaBody.Length - svgAreaBody.IndexOf("<svg"));
			XmlTextReader xmlTextReader = new XmlTextReader(new StringReader(svgAreaBody));
			Stack stack = new Stack();
			stack.Push(obj);
			while (xmlTextReader.Read())
			{
				Hashtable nodeAttributes = new Hashtable();
				if (xmlTextReader.HasAttributes)
				{
					string text = string.Empty;
					for (int i = 0; i < xmlTextReader.AttributeCount; i++)
					{
						xmlTextReader.MoveToAttribute(i);
						if (xmlTextReader.Name == "xlinkhref")
						{
							nodeAttributes.Add("xlink:href", xmlTextReader.Value);
						}
						else if (xmlTextReader.Name == "style")
						{
							text = xmlTextReader.GetAttribute("style");
						}
						else
						{
							nodeAttributes.Add(xmlTextReader.Name, xmlTextReader.Value);
						}
					}
					if (!string.IsNullOrEmpty(text))
					{
						smethod_0(ref nodeAttributes, text);
					}
					xmlTextReader.MoveToElement();
				}
				if (xmlTextReader.NodeType == XmlNodeType.Text || xmlTextReader.NodeType == XmlNodeType.Whitespace || xmlTextReader.NodeType == XmlNodeType.CDATA)
				{
					Class7132 class2 = new Class7132("rawText", nodeAttributes, (Class7132)stack.Peek(), ((Class7132)stack.Peek()).hashtable_4.Count);
					class2.string_1 = xmlTextReader.Value;
					if (xmlTextReader.Name != null && !xmlTextReader.Name.Equals("svg") && (Class7132)stack.Peek() != null)
					{
						((Class7132)stack.Peek()).hashtable_4.Add(((Class7132)stack.Peek()).hashtable_4.Count, class2);
					}
				}
				if (xmlTextReader.NodeType == XmlNodeType.Element)
				{
					string name;
					Class7132 class3 = (((name = xmlTextReader.Name) == null || !(name == "rect")) ? new Class7132(xmlTextReader.LocalName, nodeAttributes, (Class7132)stack.Peek(), ((Class7132)stack.Peek()).hashtable_4.Count) : new Class7133(xmlTextReader.LocalName, nodeAttributes, (Class7132)stack.Peek()));
					((Class7132)stack.Peek()).hashtable_4.Add(((Class7132)stack.Peek()).hashtable_4.Count, class3);
					if (!xmlTextReader.IsEmptyElement)
					{
						stack.Push(class3);
					}
				}
				if (xmlTextReader.NodeType == XmlNodeType.EndElement && xmlTextReader.Name == ((Class7132)stack.Peek()).string_0)
				{
					stack.Pop();
				}
			}
			return @class;
		}
		catch (Exception ex)
		{
			_ = ex.Message;
			return @class;
		}
	}
}
