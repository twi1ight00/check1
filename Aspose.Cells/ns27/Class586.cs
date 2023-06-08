using System;
using System.Collections;
using System.IO;
using System.Text;
using System.Xml;
using Aspose.Cells;
using ns16;
using ns22;
using ns59;

namespace ns27;

internal class Class586 : Class538
{
	internal Class586()
	{
		method_2(2198);
	}

	private static XmlTextWriter smethod_0(string string_0, Stream6 stream6_0)
	{
		Class744 @class = stream6_0.method_18(string_0);
		@class.method_5(DateTime.Now);
		XmlTextWriter xmlTextWriter = new XmlTextWriter(stream6_0, Encoding.UTF8);
		xmlTextWriter.Formatting = Formatting.Indented;
		return xmlTextWriter;
	}

	private void method_4(Class746 class746_0, Stream6 stream6_0)
	{
		IEnumerator enumerator = class746_0.GetEnumerator();
		while (enumerator.MoveNext())
		{
			Class744 @class = (Class744)enumerator.Current;
			if (!@class.method_18())
			{
				CopyData(@class, @class.Name, class746_0, stream6_0);
			}
		}
	}

	private void CopyData(Class744 class744_0, string string_0, Class746 class746_0, Stream6 stream6_0)
	{
		Class744 @class = stream6_0.method_18(string_0);
		@class.method_5(DateTime.Now);
		byte[] array = new byte[1024];
		int num = 0;
		Stream stream = class746_0.method_39(class744_0);
		do
		{
			num = stream.Read(array, 0, array.Length);
			stream6_0.Write(array, 0, num);
		}
		while (num > 0);
		stream6_0.Flush();
	}

	internal void Write(Workbook workbook_0)
	{
		MemoryStream memoryStream = new MemoryStream();
		Stream6 stream = new Stream6(memoryStream);
		MemoryStream memoryStream2 = new MemoryStream();
		byte[] array = Class1186.smethod_1();
		memoryStream2.Write(array, 0, array.Length);
		memoryStream2.Seek(0L, SeekOrigin.Begin);
		Class746 class746_ = Class746.Read(memoryStream2);
		method_4(class746_, stream);
		XmlTextWriter xmlTextWriter = smethod_0("theme/theme/theme1.xml", stream);
		Class1591 @class = new Class1591(workbook_0);
		@class.Write(xmlTextWriter);
		xmlTextWriter.Flush();
		stream.method_22();
		if (memoryStream.Length + 16 <= 8224)
		{
			method_0((short)(memoryStream.Length + 16));
			byte_0 = new byte[base.Length];
			byte_0[0] = 150;
			byte_0[1] = 8;
			Array.Copy(memoryStream.GetBuffer(), 0, byte_0, 16, (int)memoryStream.Length);
		}
	}

	internal void method_5(Class1725 class1725_0)
	{
		if (base.Length != 0)
		{
			byte[] array = new byte[4];
			Array.Copy(BitConverter.GetBytes(method_1()), 0, array, 0, 2);
			Array.Copy(BitConverter.GetBytes(base.Length), 0, array, 2, 2);
			class1725_0.method_3(array);
			class1725_0.method_3(byte_0);
		}
	}
}
