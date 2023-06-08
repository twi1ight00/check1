using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Xml;
using System.Xml.Schema;
using Aspose.Slides;
using ns276;
using ns33;
using ns42;

namespace ns43;

internal class Class834
{
	private class Class835
	{
		public byte[] byte_0;

		public string string_0;

		public Class835(byte[] data, string contentType)
		{
			byte_0 = data;
			string_0 = contentType;
		}
	}

	internal const string string_0 = "application/vnd.openxmlformats-package.relationships+xml";

	private const string string_1 = "Aspose.Slides.DOM.resources";

	internal const string string_2 = "/[Content_Types].xml";

	internal const string string_3 = "application/vnd.openxmlformats-officedocument.spreadsheetml.worksheet+xml";

	internal const string string_4 = "application/vnd.openxmlformats-officedocument.spreadsheetml.sharedStrings+xml";

	internal const string string_5 = "application/vnd.openxmlformats-officedocument.spreadsheetml.table+xml";

	internal const string string_6 = "application/vnd.openxmlformats-officedocument.spreadsheetml.styles+xml";

	internal const string string_7 = "application/vnd.openxmlformats-officedocument.vmlDrawing";

	private int int_0;

	internal static byte[] byte_0;

	private static string string_8;

	internal Class1090 class1090_0;

	private static XmlSchemaCollection xmlSchemaCollection_0;

	private static XmlSchemaCollection xmlSchemaCollection_1;

	private static XmlSchemaCollection xmlSchemaCollection_2;

	private static XmlSchemaCollection xmlSchemaCollection_3;

	private static XmlSchemaCollection xmlSchemaCollection_4;

	private static XmlSchemaCollection xmlSchemaCollection_5;

	private static XmlSchemaCollection xmlSchemaCollection_6;

	internal string[] string_9;

	internal string[] string_10;

	internal Class6752 class6752_0;

	internal SortedList<string, Class1086> sortedList_0;

	private List<string> list_0;

	internal Class1083 class1083_0;

	internal List<Class827> list_1;

	internal Class826 class826_0;

	internal Class823 class823_0;

	internal Class824 class824_0;

	static Class834()
	{
		string_8 = "";
		xmlSchemaCollection_2 = null;
		xmlSchemaCollection_3 = null;
		xmlSchemaCollection_4 = null;
		xmlSchemaCollection_5 = null;
		xmlSchemaCollection_6 = null;
		SortedList<string, byte[]> sortedList = new SortedList<string, byte[]>();
		using (Stream zipStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("Aspose.Slides.DOM.resources.schemas.zip"))
		{
			using Class6752 @class = Class6752.Read(zipStream);
			IEnumerator enumerator = @class.method_75();
			while (enumerator.MoveNext())
			{
				Class6751 class2 = (Class6751)enumerator.Current;
				if (class2.IsDirectory)
				{
					continue;
				}
				using Stream stream = class2.method_19();
				byte[] array = new byte[class2.UncompressedSize];
				int num;
				for (int i = 0; i < array.Length; i += num)
				{
					num = stream.Read(array, i, array.Length - i);
					if (num == 0)
					{
						break;
					}
				}
				if (class2.FileName.StartsWith("http"))
				{
					sortedList.Add("http://" + class2.FileName.Substring(5), array);
				}
				else
				{
					sortedList.Add("http://zip/" + class2.FileName, array);
				}
			}
		}
		ValidationEventHandler validationEventHandler = smethod_2;
		Class1088 resolver = new Class1088(sortedList);
		xmlSchemaCollection_0 = smethod_0("opc-contentTypes.xsd", sortedList, resolver, validationEventHandler);
		xmlSchemaCollection_1 = smethod_0("opc-relationships.xsd", sortedList, resolver, validationEventHandler);
		Stream manifestResourceStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("Aspose.Slides.DOM.resources.templates.zip");
		using Class6752 class3 = Class6752.Read(manifestResourceStream);
		byte_0 = Class1086.smethod_0(class3, class3["emptySheet.xml"]);
	}

	private static XmlSchemaCollection smethod_0(string schemaName, SortedList<string, byte[]> unpacked, XmlResolver resolver, ValidationEventHandler validationEventHandler)
	{
		return smethod_1(new string[1] { schemaName }, unpacked, resolver, validationEventHandler);
	}

	private static XmlSchemaCollection smethod_1(string[] schemaNames, SortedList<string, byte[]> unpacked, XmlResolver resolver, ValidationEventHandler validationEventHandler)
	{
		XmlSchemaCollection xmlSchemaCollection = new XmlSchemaCollection();
		try
		{
			foreach (string text in schemaNames)
			{
				string text2 = (string_8 = text);
				if (text2.IndexOf(':') < 0)
				{
					text2 = "http://zip/" + text2;
				}
				byte[] buffer = unpacked[text2];
				XmlSchema schema = XmlSchema.Read(new XmlTextReader(text2, new MemoryStream(buffer, writable: false)), validationEventHandler);
				xmlSchemaCollection.Add(schema, resolver);
			}
			return xmlSchemaCollection;
		}
		catch (Exception ex)
		{
			Class1165.smethod_28(ex);
			return null;
		}
	}

	private static void smethod_2(object sender, ValidationEventArgs e)
	{
	}

	private void method_0()
	{
		sortedList_0 = new SortedList<string, Class1086>(StringComparer.InvariantCultureIgnoreCase);
		list_0 = new List<string>();
		foreach (Class6751 item in (IEnumerable)class6752_0)
		{
			if (!item.IsDirectory)
			{
				Class1086 class2 = new Class1086(item);
				sortedList_0.Add(class2.string_0, class2);
			}
		}
		class1083_0 = new Class1083();
		method_1(class1083_0, "/[Content_Types].xml", xmlSchemaCollection_0);
		Class1085 types = class1083_0.Types;
		List<string> list = new List<string>();
		List<string> list2 = new List<string>();
		foreach (XmlNode item2 in types)
		{
			if (!(item2 is Class1082 class3))
			{
				continue;
			}
			string text = "." + class3.Extension;
			list.Add(text);
			string contentType = class3.ContentType;
			list2.Add(contentType);
			foreach (Class1086 value in sortedList_0.Values)
			{
				if (value.string_0.EndsWith(text))
				{
					value.string_1 = contentType;
				}
			}
		}
		string_9 = list.ToArray();
		string_10 = list2.ToArray();
		foreach (XmlNode item3 in types)
		{
			if (item3 is Class1084 class4)
			{
				Class1086 class5 = sortedList_0[class4.PartName];
				class5.string_1 = class4.ContentType;
			}
		}
		list_0.Add("/[Content_Types].xml");
		foreach (Class1086 value2 in sortedList_0.Values)
		{
			if (value2.string_1 == "application/vnd.openxmlformats-package.relationships+xml")
			{
				value2.class1090_0 = method_6(value2.string_0);
			}
		}
		list_1 = new List<Class827>();
		foreach (Class1086 value3 in sortedList_0.Values)
		{
			switch (value3.string_1)
			{
			case "application/vnd.openxmlformats-officedocument.spreadsheetml.styles+xml":
				class824_0 = new Class824();
				method_1(class824_0, value3.string_0, xmlSchemaCollection_6);
				value3.class822_0 = class824_0;
				break;
			case "application/vnd.openxmlformats-officedocument.spreadsheetml.table+xml":
			{
				Class825 class7 = new Class825(this);
				method_1(class7, value3.string_0, xmlSchemaCollection_5);
				value3.class822_0 = class7;
				break;
			}
			case "application/vnd.openxmlformats-officedocument.spreadsheetml.sharedStrings+xml":
				class823_0 = new Class823(this);
				method_1(class823_0, value3.string_0, xmlSchemaCollection_4);
				value3.class822_0 = class823_0;
				break;
			case "application/vnd.openxmlformats-officedocument.spreadsheetml.worksheet+xml":
			{
				Class827 class6 = new Class827(this);
				method_1(class6, value3.string_0, xmlSchemaCollection_2);
				list_1.Add(class6);
				value3.class822_0 = class6;
				break;
			}
			default:
				if (value3.string_1 == null)
				{
					value3.string_1 = "unknown";
				}
				break;
			}
		}
		class1090_0 = method_4("/");
		if (class1090_0 == null)
		{
			throw new PptxReadException(string.Format("Error reading pptx presentation: can't find \"{0}\" entry.", smethod_4("/")));
		}
		string target = class1090_0.method_5("officeDocument")[0].Target;
		class826_0 = new Class826(this);
		method_1(class826_0, target, xmlSchemaCollection_3);
		foreach (string item4 in list_0)
		{
			sortedList_0.Remove(item4);
		}
		list_0 = null;
	}

	internal Class834(Stream stream, bool privateStream)
	{
		if (!privateStream)
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
			stream = memoryStream;
		}
		try
		{
			class6752_0 = Class6752.Read(stream);
			method_0();
		}
		catch (Exception61 exception)
		{
			throw new PptxUnsupportedFormatException("Unknown file format.", exception);
		}
		catch (Exception exception2)
		{
			throw new PptxUnsupportedFormatException("Not a Microsoft Excel 2007 workbook.", exception2);
		}
	}

	internal void method_1(XmlDocument document, string fileName, XmlSchemaCollection schemaCollection)
	{
		method_2(document, fileName, schemaCollection, preserveSpaces: false, hideConditionalComments: false);
	}

	internal void method_2(XmlDocument document, string fileName, XmlSchemaCollection schemaCollection, bool preserveSpaces, bool hideConditionalComments)
	{
		bool flag = schemaCollection == null && preserveSpaces;
		if (document is Class822)
		{
			Class822 @class = (Class822)document;
			@class.Relationships = method_4(fileName);
			@class.class1086_0 = sortedList_0[fileName];
			@class.class1086_0.class822_0 = @class;
			@class.xmlSchemaCollection_0 = schemaCollection;
			@class.bool_2 = preserveSpaces;
		}
		try
		{
			Stream stream = null;
			Class1086 class2 = sortedList_0[fileName];
			bool flag2 = false;
			if (class2.byte_0 != null)
			{
				stream = new MemoryStream(class2.byte_0, writable: false);
			}
			else
			{
				stream = method_3(class2.string_0);
				flag2 = true;
			}
			if (stream == null)
			{
				throw new PptxReadException($"Error reading pptx presentation: can't find \"{fileName}\" entry.");
			}
			if (hideConditionalComments)
			{
				stream = Class822.smethod_0(stream);
				if (document is Class822)
				{
					Class822 class3 = (Class822)document;
					class3.bool_0 = true;
				}
			}
			Class1092.Class1094 builder;
			if (stream.CanSeek)
			{
				long position = stream.Position;
				builder = Class822.smethod_3(stream, flag);
				stream.Seek(position, SeekOrigin.Begin);
			}
			else
			{
				if (!flag2)
				{
					throw new PptxException("Internal exception: unknown stream.");
				}
				builder = Class822.smethod_3(stream, flag);
				stream = method_3(class2.string_0);
			}
			document.Load(smethod_3(new Class1092(stream, builder), schemaCollection));
			if (flag && document.DocumentElement != null)
			{
				document.DocumentElement.RemoveAttribute("xml:space");
				document.DocumentElement.RemoveAttribute("xmlns:xml");
			}
			if (document is Class822)
			{
				((Class822)document).vmethod_0();
			}
		}
		catch (Exception exception)
		{
			throw new PptxReadException("Error reading \"" + fileName + "\" xml part", exception);
		}
	}

	private Stream method_3(string name)
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

	private static XmlReader smethod_3(TextReader reader, XmlSchemaCollection schemaCollection)
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

	private Class1090 method_4(string fileName)
	{
		string name = smethod_4(fileName);
		Class1086 @class = method_5(name);
		if (@class == null)
		{
			return new Class1090();
		}
		return @class.class1090_0;
	}

	internal Class1086 method_5(string name)
	{
		sortedList_0.TryGetValue(name, out var value);
		return value;
	}

	internal static string smethod_4(string fileName)
	{
		int num = fileName.LastIndexOf('/');
		string text = "";
		string text2 = fileName;
		if (num >= 0)
		{
			text = fileName.Substring(0, num + 1);
			text2 = fileName.Substring(num + 1);
		}
		return text + "_rels/" + text2 + ".rels";
	}

	private Class1090 method_6(string relFileName)
	{
		Stream stream = method_3(relFileName);
		int num = relFileName.LastIndexOf('/');
		string dir = "";
		if (num >= 0)
		{
			dir = relFileName.Substring(0, num - 6);
		}
		if (stream == null)
		{
			return null;
		}
		try
		{
			XmlReader reader = smethod_3(new StreamReader(stream, detectEncodingFromByteOrderMarks: true), xmlSchemaCollection_1);
			Class1090 @class = new Class1090();
			@class.Read(reader, dir);
			return @class;
		}
		catch (Exception exception)
		{
			throw new PptxReadException("Error reading \"" + relFileName + "\" relationships part", exception);
		}
	}

	internal void method_7(Class1086 part)
	{
		sortedList_0.Add(part.string_0, part);
	}

	internal int method_8()
	{
		lock (this)
		{
			return int_0++;
		}
	}

	internal static void smethod_5(Class822 document)
	{
		smethod_6(document, byte_0);
	}

	internal static void smethod_6(Class822 document, byte[] slideData)
	{
		MemoryStream stream = new MemoryStream(slideData, writable: false);
		XmlReader xmlReader = smethod_3(new StreamReader(stream, detectEncodingFromByteOrderMarks: true), xmlSchemaCollection_2);
		document.Load(xmlReader);
		xmlReader.Close();
	}
}
