using System.Collections;
using System.IO;
using System.Text;
using System.Xml;
using Aspose;

namespace xf9a9481c3f63a419;

[JavaManual("Manual porting by design.")]
internal class xd165c26d81eb4a1e
{
	private xd165c26d81eb4a1e()
	{
	}

	public static XmlTextWriter x93e8666599d1712d(Stream xcf18e5243f8d5fd3, Encoding xff3edc9aa5f0523b)
	{
		StreamWriter streamWriter = new StreamWriter(xcf18e5243f8d5fd3, xff3edc9aa5f0523b);
		streamWriter.NewLine = "\r\n";
		return new XmlTextWriter(streamWriter);
	}

	public static XmlTextReader x8bf3565aac7e7331(Stream xcf18e5243f8d5fd3)
	{
		XmlTextReader xmlTextReader = new XmlTextReader(xcf18e5243f8d5fd3);
		xmlTextReader.XmlResolver = null;
		return xmlTextReader;
	}

	public static XmlTextReader x8bf3565aac7e7331(string x536ee0b561cc97c2, Hashtable xf9b27a889ecc8d25)
	{
		NameTable nameTable = new NameTable();
		XmlNamespaceManager xmlNamespaceManager = new XmlNamespaceManager(nameTable);
		if (xf9b27a889ecc8d25 != null)
		{
			foreach (DictionaryEntry item in xf9b27a889ecc8d25)
			{
				xmlNamespaceManager.AddNamespace((string)item.Key, (string)item.Value);
			}
		}
		XmlParserContext context = new XmlParserContext(nameTable, xmlNamespaceManager, null, XmlSpace.Default);
		XmlTextReader xmlTextReader = new XmlTextReader(x536ee0b561cc97c2, XmlNodeType.Document, context);
		xmlTextReader.XmlResolver = null;
		return xmlTextReader;
	}

	[JavaThrows(true)]
	public static XmlDocument xbbd823d2b4dbb41a(string x536ee0b561cc97c2, bool x835fd5ade25a938d)
	{
		XmlDocument xmlDocument = new XmlDocument();
		xmlDocument.PreserveWhitespace = x835fd5ade25a938d;
		xmlDocument.LoadXml(x536ee0b561cc97c2);
		return xmlDocument;
	}

	[JavaThrows(true)]
	public static XmlDocument xbbd823d2b4dbb41a(Stream xcf18e5243f8d5fd3, bool x835fd5ade25a938d)
	{
		XmlDocument xmlDocument = new XmlDocument();
		xmlDocument.PreserveWhitespace = x835fd5ade25a938d;
		xmlDocument.Load(xcf18e5243f8d5fd3);
		return xmlDocument;
	}

	[JavaThrows(true)]
	public static void xbae2e52f4b257f3b(string xafe2f3653ee64ebc)
	{
		XmlDocument xmlDocument = new XmlDocument();
		xmlDocument.XmlResolver = null;
		xmlDocument.Load(xafe2f3653ee64ebc);
	}

	[JavaThrows(true)]
	public static void x8ebf37a8980eb562(XmlDocument x6beba47238e0ade6, Stream xcf18e5243f8d5fd3)
	{
		x6beba47238e0ade6.Save(xcf18e5243f8d5fd3);
	}

	[JavaThrows(true)]
	public static string x0c9679d333729bc5(XmlDocument x6beba47238e0ade6)
	{
		return x6beba47238e0ade6.OuterXml;
	}

	public static IList x478a82deb55cde7c(XmlElement x4bbc2c453c470189, string x7e81152f4b5e4c64, Hashtable xf9b27a889ecc8d25)
	{
		ArrayList arrayList = new ArrayList();
		XmlNodeList xmlNodeList;
		if (xf9b27a889ecc8d25 != null)
		{
			XmlNamespaceManager xmlNamespaceManager = new XmlNamespaceManager(new NameTable());
			foreach (DictionaryEntry item in xf9b27a889ecc8d25)
			{
				xmlNamespaceManager.AddNamespace((string)item.Key, (string)item.Value);
			}
			xmlNodeList = x4bbc2c453c470189.SelectNodes(x7e81152f4b5e4c64, xmlNamespaceManager);
		}
		else
		{
			xmlNodeList = x4bbc2c453c470189.SelectNodes(x7e81152f4b5e4c64);
		}
		foreach (XmlNode item2 in xmlNodeList)
		{
			arrayList.Add(item2);
		}
		return arrayList;
	}

	public static XmlNode x97bb330a631993a5(XmlElement x4bbc2c453c470189, string x7e81152f4b5e4c64, Hashtable xf9b27a889ecc8d25)
	{
		if (xf9b27a889ecc8d25 != null)
		{
			XmlNamespaceManager xmlNamespaceManager = new XmlNamespaceManager(new NameTable());
			foreach (DictionaryEntry item in xf9b27a889ecc8d25)
			{
				xmlNamespaceManager.AddNamespace((string)item.Key, (string)item.Value);
			}
			return x4bbc2c453c470189.SelectSingleNode(x7e81152f4b5e4c64, xmlNamespaceManager);
		}
		return x4bbc2c453c470189.SelectSingleNode(x7e81152f4b5e4c64);
	}
}
