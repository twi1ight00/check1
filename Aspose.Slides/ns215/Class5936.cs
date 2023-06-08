using System.Collections;
using System.Globalization;
using System.IO;
using System.Xml;
using Aspose.XfaConverter.Elements;

namespace ns215;

internal class Class5936
{
	internal const string string_0 = "###EmbedAnchor";

	private static void smethod_0(XmlAttributeCollection xmlAttributes, Class5913 attributes)
	{
		CultureInfo cultureInfo = (CultureInfo)CultureInfo.CurrentCulture.Clone();
		cultureInfo.NumberFormat.CurrencyDecimalSeparator = ".";
		foreach (XmlAttribute xmlAttribute in xmlAttributes)
		{
			if (xmlAttribute.Name == "style" && !string.IsNullOrEmpty(xmlAttribute.Value))
			{
				string[] array = xmlAttribute.Value.Split(';');
				string[] array2 = array;
				foreach (string text in array2)
				{
					if (string.IsNullOrEmpty(text))
					{
						continue;
					}
					int num = text.IndexOf(':');
					if (num == -1)
					{
						continue;
					}
					string text2 = text.Substring(0, num).Replace(" ", string.Empty);
					string text3 = text.Substring(num + 1, text.Length - num - 1).Replace(" ", string.Empty);
					if (string.IsNullOrEmpty(text3))
					{
						continue;
					}
					switch (text2)
					{
					case "font-family":
						attributes.Add(Enum739.const_0, text3.Replace("'", string.Empty));
						break;
					case "font-size":
						attributes.Add(Enum739.const_1, Class5932.smethod_0(text3));
						break;
					case "line-height":
						attributes.Add(Enum739.const_4, Class5932.smethod_0(text3));
						break;
					case "font-style":
						if (text3 == "normal")
						{
							attributes.Add(Enum739.const_2, XfaEnums.Enum709.const_0);
						}
						else if (text3 == "italic")
						{
							attributes.Add(Enum739.const_2, XfaEnums.Enum709.const_1);
						}
						break;
					case "font-weight":
						if (text3 == "normal")
						{
							attributes.Add(Enum739.const_3, XfaEnums.Enum710.const_0);
						}
						else if (text3 == "bold")
						{
							attributes.Add(Enum739.const_3, XfaEnums.Enum710.const_1);
						}
						break;
					case "margin-left":
						attributes.Add(Enum739.const_9, Class5932.smethod_0(text3));
						break;
					case "margin-right":
						attributes.Add(Enum739.const_10, Class5932.smethod_0(text3));
						break;
					case "margin-top":
						attributes.Add(Enum739.const_11, Class5932.smethod_0(text3));
						break;
					case "margin-bottom":
						attributes.Add(Enum739.const_8, Class5932.smethod_0(text3));
						break;
					case "margin":
						attributes.Add(Enum739.const_7, Class5932.smethod_0(text3));
						break;
					case "text-indent":
						attributes.Add(Enum739.const_12, Class5932.smethod_0(text3));
						break;
					case "tab-interval":
						attributes.Add(Enum739.const_14, Class5932.smethod_0(text3));
						break;
					case "xfa-tab-count":
						attributes.Add(Enum739.const_13, int.Parse(text3));
						break;
					case "text-align":
						switch (text3)
						{
						case "justify-all":
							attributes.Add(Enum739.const_17, XfaEnums.Enum719.const_3);
							break;
						case "justify":
							attributes.Add(Enum739.const_17, XfaEnums.Enum719.const_2);
							break;
						case "right":
							attributes.Add(Enum739.const_17, XfaEnums.Enum719.const_5);
							break;
						case "center":
							attributes.Add(Enum739.const_17, XfaEnums.Enum719.const_1);
							break;
						case "left":
							attributes.Add(Enum739.const_17, XfaEnums.Enum719.const_0);
							break;
						}
						break;
					}
				}
			}
			else if (!string.IsNullOrEmpty(xmlAttribute.Value))
			{
				if (xmlAttribute.Name.Contains("embedType"))
				{
					attributes.Add(Enum739.const_19, xmlAttribute.Value);
				}
				else if (xmlAttribute.Name.Contains("embedMode"))
				{
					attributes.Add(Enum739.const_20, xmlAttribute.Value);
				}
				else if (xmlAttribute.Name.Contains("embed"))
				{
					attributes.Add(Enum739.const_21, xmlAttribute.Value);
				}
			}
		}
	}

	private static Class5913 smethod_1(XmlNode node, Class5913 attributeCollection)
	{
		Class5913 @class = new Class5913(attributeCollection);
		switch (node.Name)
		{
		case "br":
			@class.Add(Enum739.const_15, true);
			break;
		case "b":
			@class.Add(Enum739.const_3, XfaEnums.Enum710.const_1);
			break;
		case "i":
			@class.Add(Enum739.const_2, XfaEnums.Enum709.const_1);
			break;
		case "p":
			if (attributeCollection.method_0(Enum739.const_6))
			{
				attributeCollection.Add(Enum739.const_6, (int)attributeCollection[Enum739.const_6] + 1);
			}
			else
			{
				attributeCollection.Add(Enum739.const_6, 0);
			}
			@class = new Class5913(attributeCollection);
			break;
		}
		if (node.Attributes != null)
		{
			smethod_0(node.Attributes, @class);
		}
		return @class;
	}

	private static void smethod_2(XmlNode root, Class5913 attributeCollection, ArrayList parsedText)
	{
		if (root is XmlElement)
		{
			Class5913 @class = smethod_1(root, attributeCollection);
			if (root.Name == "br")
			{
				parsedText.Add(@class);
				return;
			}
			foreach (XmlNode childNode in root.ChildNodes)
			{
				smethod_2(childNode, @class, parsedText);
			}
			if (!root.HasChildNodes && @class.method_0(Enum739.const_21))
			{
				@class.Add(Enum739.const_16, "###EmbedAnchor");
				parsedText.Add(@class);
			}
		}
		else if (root is XmlText)
		{
			Class5913 class2 = smethod_1(root, attributeCollection);
			class2.Add(Enum739.const_16, root.Value);
			parsedText.Add(class2);
		}
	}

	internal static void smethod_3(string text, Class5913 textAttributes, ArrayList parsedText)
	{
		XmlDocument xmlDocument = new XmlDocument();
		xmlDocument.Load(new StringReader(text));
		for (XmlNode xmlNode = xmlDocument.DocumentElement.FirstChild; xmlNode != null; xmlNode = xmlNode.NextSibling)
		{
			smethod_2(xmlNode, textAttributes, parsedText);
		}
	}
}
