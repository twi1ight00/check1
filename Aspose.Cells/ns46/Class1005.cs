using System;
using System.Collections;
using System.Security.Cryptography.Xml;
using System.Xml;
using ns16;

namespace ns46;

internal class Class1005
{
	public static Hashtable hashtable_0 = new Hashtable();

	internal static string smethod_0(XmlNode xmlNode_0, string string_0)
	{
		if (xmlNode_0.Attributes != null && xmlNode_0.Attributes.Count > 0)
		{
			foreach (XmlAttribute attribute in xmlNode_0.Attributes)
			{
				if (attribute.Name == string_0)
				{
					return attribute.Value;
				}
			}
		}
		return "";
	}

	public static void smethod_1()
	{
		hashtable_0.Clear();
	}

	public static void smethod_2(XmlElement xmlElement_0, ref string string_0)
	{
		string_0 = string_0 + "<" + xmlElement_0.Name;
		if (!hashtable_0.ContainsKey(xmlElement_0.NamespaceURI))
		{
			string_0 = string_0 + " xmlns=\"" + xmlElement_0.NamespaceURI + "\"";
			hashtable_0[xmlElement_0.NamespaceURI] = 0;
		}
		if (xmlElement_0.HasAttributes)
		{
			ArrayList arrayList = new ArrayList();
			Hashtable hashtable = new Hashtable();
			foreach (XmlAttribute attribute in xmlElement_0.Attributes)
			{
				char c = attribute.Name[0];
				string text = attribute.Name;
				if (c < 'a')
				{
					text = "z" + text;
				}
				hashtable[text] = attribute.Name;
				arrayList.Add(text);
			}
			arrayList.Sort();
			foreach (string item in arrayList)
			{
				string name = (string)hashtable[item];
				XmlAttribute xmlAttribute2 = xmlElement_0.Attributes[name];
				if (xmlAttribute2.Name.StartsWith("xmlns"))
				{
					if (!hashtable_0.ContainsKey(xmlAttribute2.Value))
					{
						string text2 = string_0;
						string_0 = text2 + " " + xmlAttribute2.Name + "=\"" + xmlAttribute2.Value + "\"";
						hashtable_0[xmlAttribute2.Value] = 0;
					}
				}
				else
				{
					string text3 = string_0;
					string_0 = text3 + " " + xmlAttribute2.Name + "=\"" + xmlAttribute2.Value + "\"";
				}
			}
		}
		string_0 += ">";
		XmlNodeList childNodes = xmlElement_0.ChildNodes;
		foreach (XmlNode item2 in childNodes)
		{
			if (item2.NodeType == XmlNodeType.Text)
			{
				string_0 += ((XmlText)item2).Value;
			}
			else
			{
				smethod_2((XmlElement)item2, ref string_0);
			}
		}
		string_0 = string_0 + "</" + xmlElement_0.Name + ">";
	}

	public static string smethod_3(SignedInfo signedInfo_0)
	{
		string text = "";
		text += "<SignedInfo xmlns=\"http://www.w3.org/2000/09/xmldsig#\">";
		text += "<CanonicalizationMethod Algorithm=\"http://www.w3.org/TR/2001/REC-xml-c14n-20010315\"></CanonicalizationMethod>";
		text += "<SignatureMethod Algorithm=\"http://www.w3.org/2000/09/xmldsig#rsa-sha1\"></SignatureMethod>";
		foreach (Reference reference in signedInfo_0.References)
		{
			string text2 = text;
			text = text2 + "<Reference Type=\"" + reference.Type + "\" URI=\"" + reference.Uri + "\">";
			text = text + "<DigestMethod Algorithm=\"http://www.w3.org/2000/09/xmldsig#sha1\"></DigestMethod><DigestValue>" + Convert.ToBase64String(reference.DigestValue) + "</DigestValue>";
			text += "</Reference>";
		}
		return text + "</SignedInfo>";
	}

	internal static void smethod_4(string string_0, ref string string_1)
	{
		XmlDocument xmlDocument = new XmlDocument();
		xmlDocument.LoadXml("<?xml version=\"1.0\" encoding=\"UTF-8\"?><B xmlns=\"http://www.w3.org/2000/09/xmldsig#\">" + string_0 + "</B>");
		XmlElement xmlElement_ = (XmlElement)xmlDocument.ChildNodes[1].FirstChild;
		smethod_2(xmlElement_, ref string_1);
	}

	internal static void smethod_5(string string_0, ref string string_1, Class746 class746_0)
	{
		XmlDocument xmlDocument = new XmlDocument();
		xmlDocument.LoadXml("<?xml version=\"1.0\" encoding=\"UTF-8\"?><Fix xmlns:mdssi=\"http://schemas.openxmlformats.org/package/2006/digital-signature\">" + string_0 + "</Fix>");
		XmlElement xmlElement_ = (XmlElement)xmlDocument.ChildNodes[1];
		smethod_6(xmlElement_, ref string_1, class746_0);
	}

	internal static void smethod_6(XmlElement xmlElement_0, ref string string_0, Class746 class746_0)
	{
		ArrayList arrayList = new ArrayList();
		foreach (XmlElement childNode in xmlElement_0.FirstChild.FirstChild.FirstChild.ChildNodes)
		{
			arrayList.Add(smethod_0(childNode, "SourceId"));
		}
		arrayList.Sort();
		Class1003 @class = new Class1003("Relationships", "");
		@class.arrayList_1.Add(new Class998("xmlns", "http://schemas.openxmlformats.org/package/2006/relationships"));
		string text = "_rels/.rels";
		text = ((XmlElement)xmlElement_0.FirstChild).GetAttribute("URI");
		text = text.Substring(0, text.IndexOf('?'));
		Class744 class2 = class746_0[text.TrimStart('/')];
		if (class2 == null)
		{
			return;
		}
		XmlDocument xmlDocument = new XmlDocument();
		xmlDocument.Load(class746_0.method_39(class2));
		foreach (string item in arrayList)
		{
			foreach (XmlElement childNode2 in xmlDocument.LastChild.ChildNodes)
			{
				if (childNode2.GetAttribute("Id") == item)
				{
					Class1003 class3 = new Class1003("Relationship", "");
					class3.arrayList_1.Add(new Class998("Id", item));
					class3.arrayList_1.Add(new Class998("Target", childNode2.GetAttribute("Target")));
					class3.arrayList_1.Add(new Class998("TargetMode", "Internal"));
					class3.arrayList_1.Add(new Class998("Type", childNode2.GetAttribute("Type")));
					@class.Add(class3);
				}
			}
		}
		@class.vmethod_1(ref string_0);
	}
}
