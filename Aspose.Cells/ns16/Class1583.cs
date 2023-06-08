using System;
using System.Collections;
using System.IO;
using System.Xml;
using Aspose.Cells;
using ns22;

namespace ns16;

internal class Class1583
{
	private Class1541 class1541_0;

	private XmlDocument xmlDocument_0;

	private string string_0;

	internal Class1583(Class1541 class1541_1, string string_1)
	{
		class1541_0 = class1541_1;
		string_0 = string_1;
	}

	internal void Write(Stream6 stream6_0, string string_1)
	{
		Class746 class746_ = class1541_0.class1540_0.class746_0;
		Class744 class744_ = class746_.method_38(string_1);
		Stream stream = class746_.method_39(class744_);
		xmlDocument_0 = Class1188.smethod_2(stream);
		stream.Close();
		method_0();
		method_1(stream6_0, string_1);
	}

	private void method_0()
	{
		new ArrayList();
		XmlNodeList childNodes = xmlDocument_0.DocumentElement.ChildNodes;
		for (int i = 0; i < childNodes.Count; i++)
		{
			object obj = childNodes[i];
			if (obj is XmlElement && ((XmlElement)obj).LocalName == "location")
			{
				XmlAttribute attributeNode = ((XmlElement)obj).GetAttributeNode("ref");
				if (attributeNode != null)
				{
					attributeNode.Value = string_0;
				}
			}
		}
	}

	private void method_1(Stream6 stream6_0, string string_1)
	{
		MemoryStream memoryStream = new MemoryStream();
		xmlDocument_0.Save(memoryStream);
		if (memoryStream.Length >= int.MaxValue)
		{
			throw new CellsException(ExceptionType.InvalidData, "Internal Error: PivotTable data too large...");
		}
		Class744 @class = stream6_0.method_18(string_1);
		@class.method_5(DateTime.Now);
		memoryStream.Position = 0L;
		byte[] array = new byte[1024];
		int num = 0;
		do
		{
			num = memoryStream.Read(array, 0, array.Length);
			stream6_0.Write(array, 0, num);
		}
		while (num > 0);
		stream6_0.Flush();
	}
}
