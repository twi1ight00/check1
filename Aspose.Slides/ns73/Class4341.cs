using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Xml;

namespace ns73;

internal sealed class Class4341
{
	private Class4341()
	{
	}

	public static string smethod_0(string content, string tagName)
	{
		Regex regex = new Regex("<" + tagName + "[^>]*>(?<content>.+)</" + tagName + ">");
		Match match = regex.Match(content);
		return match.Groups["content"].Value;
	}

	public static List<XmlAttribute> smethod_1(string content, string tagName, XmlDocument document)
	{
		List<XmlAttribute> list = new List<XmlAttribute>();
		content = content + "</" + tagName + ">";
		if (content.Replace("<", string.Empty).Replace(">", string.Empty).Trim() == string.Empty)
		{
			return list;
		}
		XmlTextReader xmlTextReader = new XmlTextReader(new StringReader(content));
		try
		{
			while (xmlTextReader.Read())
			{
				if (xmlTextReader.HasAttributes)
				{
					for (int i = 0; i < xmlTextReader.AttributeCount; i++)
					{
						xmlTextReader.MoveToAttribute(i);
						XmlAttribute xmlAttribute = document.CreateAttribute(xmlTextReader.Name.ToLowerInvariant());
						xmlAttribute.Value = xmlTextReader.Value;
						list.Add(xmlAttribute);
					}
					break;
				}
			}
		}
		catch
		{
		}
		return list;
	}
}
