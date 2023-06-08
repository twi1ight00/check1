using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using Aspose.Slides;
using Aspose.Slides.Odp;
using ns276;

namespace ns28;

internal class Class476
{
	internal const string string_0 = "text/xml";

	internal const string string_1 = "image/jpeg";

	internal const string string_2 = "image/png";

	internal const string string_3 = "image/gif";

	internal const string string_4 = "image/tiff";

	internal const string string_5 = "image/x-emf";

	internal const string string_6 = "image/x-wmf";

	internal const string string_7 = "document-meta";

	internal const string string_8 = "document-settings";

	internal const string string_9 = "document-styles";

	internal const string string_10 = "document-content";

	internal Class6752 class6752_0;

	internal SortedList<string, Class480> sortedList_0;

	private List<string> list_0;

	internal int int_0;

	internal readonly string string_11 = new StringBuilder("META-INF/manifest.xml").ToString();

	internal Class475 class475_0;

	internal Class463 class463_0;

	internal Class464 class464_0;

	internal Class465 class465_0;

	internal Class462 class462_0;

	private static XmlSchemaCollection xmlSchemaCollection_0;

	private static XmlSchemaCollection xmlSchemaCollection_1;

	private static XmlSchemaCollection xmlSchemaCollection_2;

	private static XmlSchemaCollection xmlSchemaCollection_3;

	private static XmlSchemaCollection xmlSchemaCollection_4;

	internal List<Class472> list_1 = new List<Class472>();

	internal List<IPPImage> list_2 = new List<IPPImage>();

	private Dictionary<IShape, object> dictionary_0 = new Dictionary<IShape, object>();

	private int int_1;

	internal Class478 class478_0 = new Class478();

	private void method_0()
	{
		sortedList_0 = new SortedList<string, Class480>(StringComparer.InvariantCultureIgnoreCase);
		list_0 = new List<string>();
		foreach (Class6751 item in (IEnumerable)class6752_0)
		{
			if (!item.IsDirectory)
			{
				Class480 class2 = new Class480(item);
				sortedList_0.Add(class2.string_0, class2);
			}
		}
		class475_0 = new Class475();
		method_4(class475_0, string_11, xmlSchemaCollection_0);
		Class408 manifests = class475_0.Manifests;
		foreach (XmlNode item2 in manifests)
		{
			Class407 class3 = item2 as Class407;
			if (class3 != null && class3.ManifestMediaType != "")
			{
				foreach (Class480 value in sortedList_0.Values)
				{
					if (value.string_0 == class3.ManifestFullPath)
					{
						value.string_1 = class3.ManifestMediaType;
					}
				}
			}
			if (class3 == null || !(class3.ManifestMediaType == "") || !Path.GetExtension(class3.ManifestFullPath).ToLower().Equals(".wmf"))
			{
				continue;
			}
			foreach (Class480 value2 in sortedList_0.Values)
			{
				if (value2.string_0 == class3.ManifestFullPath)
				{
					value2.string_1 = "image/x-wmf";
				}
			}
		}
		list_0.Add(string_11);
		foreach (Class480 value3 in sortedList_0.Values)
		{
			switch (value3.string_1)
			{
			case "text/xml":
			{
				string text = method_3(value3);
				if (text != "")
				{
					value3.string_1 = text;
				}
				switch (value3.string_1)
				{
				case "document-content":
					if (value3.string_0.ToLower().IndexOf("object") == -1)
					{
						class462_0 = new Class462(this);
						value3.class461_0 = class462_0;
					}
					else
					{
						int index3 = class478_0.method_0(value3);
						class478_0[index3].class462_0 = new Class462(this);
						value3.class461_0 = class478_0[index3].class462_0;
					}
					method_4(value3.class461_0, value3.string_0, xmlSchemaCollection_4);
					break;
				case "document-styles":
					if (value3.string_0.ToLower().IndexOf("object") == -1)
					{
						class465_0 = new Class465(this);
						value3.class461_0 = class465_0;
					}
					else
					{
						int index2 = class478_0.method_0(value3);
						class478_0[index2].class465_0 = new Class465(this);
						value3.class461_0 = class478_0[index2].class465_0;
					}
					method_4(value3.class461_0, value3.string_0, xmlSchemaCollection_3);
					break;
				case "document-settings":
					class464_0 = new Class464(this);
					value3.class461_0 = class464_0;
					method_4(value3.class461_0, value3.string_0, xmlSchemaCollection_2);
					break;
				case "document-meta":
					if (value3.string_0.ToLower().IndexOf("object") == -1)
					{
						class463_0 = new Class463(this);
						value3.class461_0 = class463_0;
					}
					else
					{
						int index = class478_0.method_0(value3);
						class478_0[index].class463_0 = new Class463(this);
						value3.class461_0 = class478_0[index].class463_0;
					}
					method_4(value3.class461_0, value3.string_0, xmlSchemaCollection_1);
					break;
				}
				break;
			}
			case "image/png":
			case "image/jpeg":
			case "image/gif":
			case "image/tiff":
			case "image/x-emf":
			case "image/x-wmf":
				list_1.Add(new Class472(value3, this));
				break;
			}
		}
		method_2();
	}

	internal void method_1(Class480 part)
	{
		sortedList_0.Add(part.string_0, part);
	}

	internal void method_2()
	{
		string namespaceURI = "urn:oasis:names:tc:opendocument:xmlns:drawing:1.0";
		string namespaceURI2 = "urn:oasis:names:tc:opendocument:xmlns:style:1.0";
		foreach (Class416 item in class462_0.GetElementsByTagName("page", namespaceURI))
		{
			if (item.StyleNameStr != "")
			{
				foreach (Class437 item2 in class462_0.GetElementsByTagName("style", namespaceURI2))
				{
					if (item2.Name == item.StyleNameStr)
					{
						item.StyleName = item2;
						break;
					}
				}
			}
			if (item.PresentationPageLayoutNameStr != "")
			{
				foreach (Class428 item3 in class465_0.GetElementsByTagName("presentation-page-layout", namespaceURI2))
				{
					if (item3.Name == item.PresentationPageLayoutNameStr)
					{
						item.PresentationPageLayoutName = item3;
						break;
					}
				}
			}
			if (!(item.MasterPageNameStr != ""))
			{
				continue;
			}
			foreach (Class410 item4 in class465_0.GetElementsByTagName("master-page", namespaceURI2))
			{
				if (item4.Name == item.MasterPageNameStr)
				{
					item.MasterPageName = item4;
					break;
				}
			}
		}
		foreach (Class410 item5 in class465_0.GetElementsByTagName("master-page", namespaceURI2))
		{
			if (item5.PageLayoutNameStr != "")
			{
				foreach (Class413 item6 in class465_0.GetElementsByTagName("page-layout", namespaceURI2))
				{
					if (item6.Name == item5.PageLayoutNameStr)
					{
						item5.PageLayoutName = item6;
						break;
					}
				}
			}
			if (!(item5.StyleNameStr != ""))
			{
				continue;
			}
			foreach (Class437 item7 in class465_0.GetElementsByTagName("style", namespaceURI2))
			{
				if (item7.Name == item5.StyleNameStr)
				{
					item5.StyleName = item7;
					break;
				}
			}
		}
		foreach (Class437 item8 in class465_0.GetElementsByTagName("style", namespaceURI2))
		{
			if (!(item8.ParentStyleNameStr != ""))
			{
				continue;
			}
			foreach (Class437 item9 in class465_0.GetElementsByTagName("style", namespaceURI2))
			{
				if (item9.Name == item8.ParentStyleNameStr)
				{
					item8.ParentStyleName = item9;
					break;
				}
			}
		}
		foreach (Class437 item10 in class462_0.GetElementsByTagName("style", namespaceURI2))
		{
			if (!(item10.ParentStyleNameStr != ""))
			{
				continue;
			}
			foreach (Class437 item11 in class465_0.GetElementsByTagName("style", namespaceURI2))
			{
				if (item11.Name == item10.ParentStyleNameStr)
				{
					item10.ParentStyleName = item11;
					break;
				}
			}
		}
	}

	internal string method_3(Class480 pentry)
	{
		Stream stream = method_6(pentry.string_0);
		if (stream == null)
		{
			return null;
		}
		XmlDocument xmlDocument = new XmlDocument();
		try
		{
			xmlDocument.Load(stream);
			return xmlDocument.DocumentElement.LocalName;
		}
		catch (Exception exception)
		{
			throw new PptReadException("Error reading \"" + pentry.string_0 + "\"  part", exception);
		}
	}

	internal void method_4(XmlDocument document, string fileName, XmlSchemaCollection schemaCollection)
	{
		method_5(document, fileName, schemaCollection, hideConditionalComments: true);
	}

	internal void method_5(XmlDocument document, string fileName, XmlSchemaCollection schemaCollection, bool hideConditionalComments)
	{
		if (document is Class461)
		{
			Class461 @class = (Class461)document;
			@class.class480_0 = sortedList_0[fileName];
			@class.class480_0.class461_0 = @class;
		}
		try
		{
			Stream stream = null;
			Class480 class2 = sortedList_0[fileName];
			stream = ((class2.byte_0 == null) ? method_6(class2.string_0) : new MemoryStream(class2.byte_0, writable: false));
			if (stream == null)
			{
				throw new OdpReadException($"Error reading Open Office presentation: can't find \"{fileName}\" entry.");
			}
			if (hideConditionalComments)
			{
				stream = Class461.smethod_0(stream);
			}
			document.PreserveWhitespace = true;
			document.Load(stream);
			if (document is Class461)
			{
				((Class461)document).vmethod_0();
			}
		}
		catch (Exception exception)
		{
			throw new OdpReadException("Error reading \"" + fileName + "\" xml part", exception);
		}
	}

	private static XmlReader smethod_0(TextReader reader, XmlSchemaCollection schemaCollection)
	{
		XmlReader xmlReader = new XmlTextReader(reader);
		if (schemaCollection != null)
		{
			XmlValidatingReader xmlValidatingReader = new XmlValidatingReader(xmlReader);
			xmlValidatingReader.Schemas.Add(schemaCollection);
			xmlReader = xmlValidatingReader;
		}
		return xmlReader;
	}

	private Stream method_6(string name)
	{
		if (name[0] == '/')
		{
			name = name.Substring(1);
		}
		Class6751 @class = class6752_0[name];
		if (@class != null)
		{
			MemoryStream memoryStream = new MemoryStream();
			@class.method_8(memoryStream);
			memoryStream.Seek(0L, SeekOrigin.Begin);
			return memoryStream;
		}
		return null;
	}

	public Class476(Stream stream)
	{
		byte[] array = new byte[4096];
		long num = 0L;
		if (stream.CanSeek)
		{
			num = stream.Length - stream.Position;
		}
		if (num > 32767L || num < 0L)
		{
			num = 0L;
		}
		MemoryStream memoryStream = new MemoryStream((int)num);
		while (true)
		{
			int num2 = stream.Read(array, 0, array.Length);
			if (num2 == 0)
			{
				break;
			}
			memoryStream.Write(array, 0, num2);
		}
		memoryStream.Seek(0L, SeekOrigin.Begin);
		try
		{
			class6752_0 = Class6752.Read(memoryStream);
			method_0();
		}
		catch (Exception61 exception)
		{
			throw new PptUnsupportedFormatException("Unknown file format.", exception);
		}
		catch (Exception exception2)
		{
			throw new PptUnsupportedFormatException("Not a Open Office presentation.", exception2);
		}
	}

	public static bool smethod_1(Stream stream)
	{
		byte[] array = new byte[4096];
		long num = 0L;
		if (stream.CanSeek)
		{
			num = stream.Length - stream.Position;
		}
		if (num > 32767L || num < 0L)
		{
			num = 0L;
		}
		MemoryStream memoryStream = new MemoryStream((int)num);
		while (true)
		{
			int num2 = stream.Read(array, 0, array.Length);
			if (num2 == 0)
			{
				break;
			}
			memoryStream.Write(array, 0, num2);
		}
		memoryStream.Seek(0L, SeekOrigin.Begin);
		try
		{
			string text = "application/vnd.oasis.opendocument.presentation";
			Class6752 @class = Class6752.Read(memoryStream);
			if (@class["mimetype"] != null)
			{
				using (Stream stream2 = @class["mimetype"].method_19())
				{
					byte[] array2 = new byte[text.Length];
					stream2.Read(array2, 0, text.Length);
					string @string = Encoding.Default.GetString(array2);
					if (text != @string)
					{
						throw new PptUnsupportedFormatException("Not a Open Office presentation");
					}
					return true;
				}
			}
			return false;
		}
		catch (Exception61 exception)
		{
			throw new PptUnsupportedFormatException("Unknown file format.", exception);
		}
	}

	public static bool smethod_2(Stream stream)
	{
		try
		{
			XmlDocument xmlDocument = new XmlDocument();
			stream.Seek(0L, SeekOrigin.Begin);
			using (Class6752 @class = Class6752.Read(stream))
			{
				Class6751 class2 = @class["META-INF/manifest.xml"];
				if (class2 == null)
				{
					return false;
				}
				using Stream stream2 = new MemoryStream();
				class2.method_8(stream2);
				stream2.Seek(0L, SeekOrigin.Begin);
				xmlDocument.Load(stream2);
			}
			XmlNamespaceManager xmlNamespaceManager = new XmlNamespaceManager(xmlDocument.NameTable);
			xmlNamespaceManager.AddNamespace("manifest", "urn:oasis:names:tc:opendocument:xmlns:manifest:1.0");
			XmlNodeList xmlNodeList = xmlDocument.SelectNodes("/manifest:manifest/manifest:file-entry[@manifest:full-path=\"content.xml\"]/manifest:encryption-data", xmlNamespaceManager);
			return xmlNodeList != null && xmlNodeList.Count > 0;
		}
		catch (Exception ex)
		{
			throw new OdpReadException(ex.Message, ex);
		}
	}

	internal int method_7(string imageName)
	{
		int num = 0;
		while (true)
		{
			if (num < list_1.Count)
			{
				if (Path.GetFileName(list_1[num].partName) == Path.GetFileName(imageName))
				{
					break;
				}
				num++;
				continue;
			}
			return -1;
		}
		return num;
	}

	internal void method_8()
	{
		if (list_2.Count > 0)
		{
			class475_0.method_0("", "Pictures\\");
		}
		for (int i = 0; i < list_2.Count; i++)
		{
			PPImage pPImage = (PPImage)list_2[i];
			string text = smethod_3(i, pPImage);
			Class480 @class = new Class480(text, pPImage.data);
			@class.string_1 = pPImage.ContentType;
			method_1(@class);
			class475_0.method_0(@class.string_1, text.Replace("/", "\\"));
		}
	}

	internal string method_9(IPPImage image)
	{
		int i;
		for (i = 0; i < list_2.Count && list_2[i] != image; i++)
		{
		}
		if (i == list_2.Count)
		{
			list_2.Add(image);
		}
		return smethod_3(i, image);
	}

	private static string smethod_3(int index, IPPImage image)
	{
		return $"Pictures/image{index}.{ImageCollection.smethod_0(image.ContentType)}";
	}

	internal void method_10(Shape shape, Class369 shapeElem)
	{
		string namespaceURI = "urn:oasis:names:tc:opendocument:xmlns:drawing:1.0";
		dictionary_0.TryGetValue(shape, out var value);
		if (value != null && value is string)
		{
			shapeElem.SetAttribute("id", namespaceURI, (string)value);
		}
		dictionary_0[shape] = shapeElem;
	}

	internal string method_11(IShape shape)
	{
		if (!dictionary_0.TryGetValue(shape, out var value))
		{
			string text = "id" + int_1++;
			dictionary_0[shape] = text;
			return text;
		}
		if (value is string)
		{
			return (string)value;
		}
		string namespaceURI = "urn:oasis:names:tc:opendocument:xmlns:drawing:1.0";
		Class369 @class = (Class369)value;
		string text2 = @class.GetAttribute("id", namespaceURI);
		if (text2 == null || text2 == "")
		{
			text2 = "id" + int_1++;
			@class.SetAttribute("id", namespaceURI, text2);
		}
		return text2;
	}
}
