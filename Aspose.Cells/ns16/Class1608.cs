using System.Collections;
using System.Xml;
using Aspose.Cells;

namespace ns16;

internal class Class1608
{
	private static string string_0;

	private static IComparer icomparer_0 = new Class1609();

	internal static ArrayList smethod_0(XmlTextReader xmlTextReader_0)
	{
		smethod_2(xmlTextReader_0);
		if (xmlTextReader_0.IsEmptyElement)
		{
			return null;
		}
		ArrayList arrayList = new ArrayList();
		xmlTextReader_0.Read();
		while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
		{
			xmlTextReader_0.MoveToContent();
			if (xmlTextReader_0.NodeType != XmlNodeType.Element)
			{
				xmlTextReader_0.Skip();
			}
			else if (xmlTextReader_0.LocalName == "Relationship" && object.ReferenceEquals(xmlTextReader_0.NamespaceURI, string_0))
			{
				Class1564 value = smethod_1(xmlTextReader_0);
				arrayList.Add(value);
			}
			else
			{
				xmlTextReader_0.Skip();
			}
		}
		return arrayList;
	}

	internal static Hashtable Read(XmlTextReader xmlTextReader_0)
	{
		smethod_2(xmlTextReader_0);
		if (xmlTextReader_0.IsEmptyElement)
		{
			return null;
		}
		Hashtable hashtable = new Hashtable();
		xmlTextReader_0.Read();
		while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
		{
			xmlTextReader_0.MoveToContent();
			if (xmlTextReader_0.NodeType != XmlNodeType.Element)
			{
				xmlTextReader_0.Skip();
			}
			else if (xmlTextReader_0.LocalName == "Relationship" && object.ReferenceEquals(xmlTextReader_0.NamespaceURI, string_0))
			{
				Class1564 @class = smethod_1(xmlTextReader_0);
				hashtable.Add(@class.string_1, @class);
			}
			else
			{
				xmlTextReader_0.Skip();
			}
		}
		return hashtable;
	}

	private static Class1564 smethod_1(XmlTextReader xmlTextReader_0)
	{
		if (!xmlTextReader_0.HasAttributes)
		{
			throw new CellsException(ExceptionType.InvalidData, "Invalid Relationship element");
		}
		Class1564 @class = new Class1564();
		while (xmlTextReader_0.MoveToNextAttribute())
		{
			if (!(xmlTextReader_0.NamespaceURI != ""))
			{
				if (xmlTextReader_0.LocalName == "Id")
				{
					@class.string_1 = xmlTextReader_0.Value;
				}
				else if (xmlTextReader_0.LocalName == "Type")
				{
					@class.string_2 = xmlTextReader_0.Value;
				}
				else if (xmlTextReader_0.LocalName == "Target")
				{
					@class.string_3 = xmlTextReader_0.Value;
				}
				else if (xmlTextReader_0.LocalName == "TargetMode")
				{
					@class.string_4 = xmlTextReader_0.Value;
				}
			}
		}
		xmlTextReader_0.MoveToElement();
		xmlTextReader_0.Skip();
		return @class;
	}

	private static void smethod_2(XmlTextReader xmlTextReader_0)
	{
		xmlTextReader_0.WhitespaceHandling = WhitespaceHandling.Significant;
		XmlNameTable nameTable = xmlTextReader_0.NameTable;
		string_0 = nameTable.Add("http://schemas.openxmlformats.org/package/2006/relationships");
		xmlTextReader_0.MoveToContent();
		if (xmlTextReader_0.NodeType != XmlNodeType.Element || !object.ReferenceEquals(xmlTextReader_0.NamespaceURI, string_0) || !(xmlTextReader_0.LocalName == "Relationships"))
		{
			throw new CellsException(ExceptionType.InvalidData, "Relationships root element eror");
		}
	}

	internal static string smethod_3(Hashtable hashtable_0, string string_1)
	{
		if (hashtable_0 != null && hashtable_0.Count != 0)
		{
			IEnumerator enumerator = hashtable_0.Values.GetEnumerator();
			Class1564 @class;
			do
			{
				if (enumerator.MoveNext())
				{
					@class = (Class1564)enumerator.Current;
					continue;
				}
				return null;
			}
			while (!@class.string_2.Equals(string_1));
			return @class.string_3;
		}
		return null;
	}

	internal static Class1564 smethod_4(Hashtable hashtable_0, string string_1)
	{
		if (hashtable_0 != null && hashtable_0.Count != 0)
		{
			IEnumerator enumerator = hashtable_0.Values.GetEnumerator();
			Class1564 @class;
			do
			{
				if (enumerator.MoveNext())
				{
					@class = (Class1564)enumerator.Current;
					continue;
				}
				return null;
			}
			while (!@class.string_2.Equals(string_1));
			return @class;
		}
		return null;
	}

	internal static Class1564 smethod_5(Hashtable hashtable_0, string string_1)
	{
		if (hashtable_0 != null && hashtable_0.Count != 0)
		{
			IEnumerator enumerator = hashtable_0.Values.GetEnumerator();
			Class1564 @class;
			do
			{
				if (enumerator.MoveNext())
				{
					@class = (Class1564)enumerator.Current;
					continue;
				}
				return null;
			}
			while (!(@class.string_1 == string_1));
			return @class;
		}
		return null;
	}

	internal static Class1564 smethod_6(ArrayList arrayList_0, string string_1)
	{
		if (arrayList_0 != null && arrayList_0.Count != 0)
		{
			IEnumerator enumerator = arrayList_0.GetEnumerator();
			Class1564 @class;
			do
			{
				if (enumerator.MoveNext())
				{
					@class = (Class1564)enumerator.Current;
					continue;
				}
				return null;
			}
			while (!(@class.string_1 == string_1));
			return @class;
		}
		return null;
	}

	internal static ArrayList smethod_7(Hashtable hashtable_0, string string_1)
	{
		ArrayList arrayList = new ArrayList();
		if (hashtable_0 != null && hashtable_0.Count != 0)
		{
			IEnumerator enumerator = hashtable_0.Values.GetEnumerator();
			while (enumerator.MoveNext())
			{
				Class1564 @class = (Class1564)enumerator.Current;
				if (@class.string_2 != null && @class.string_2.Equals(string_1))
				{
					arrayList.Add(@class);
				}
			}
			arrayList.Sort(icomparer_0);
			return arrayList;
		}
		return arrayList;
	}

	internal static void smethod_8(Hashtable hashtable_0, ArrayList arrayList_0, string string_1)
	{
		if (hashtable_0 == null || hashtable_0.Count == 0 || arrayList_0 == null)
		{
			return;
		}
		IEnumerator enumerator = hashtable_0.Values.GetEnumerator();
		while (enumerator.MoveNext())
		{
			Class1564 @class = (Class1564)enumerator.Current;
			if (@class.string_2.Equals(string_1))
			{
				arrayList_0.Add(@class);
			}
		}
	}
}
