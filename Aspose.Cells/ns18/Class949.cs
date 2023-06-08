using System;
using System.IO;
using System.Text;

namespace ns18;

internal class Class949 : Class938
{
	private string string_1;

	private string string_2;

	private byte[] byte_0;

	private MemoryStream memoryStream_0;

	private DateTime dateTime_0;

	public Class949(Class1440 class1440_1, DateTime dateTime_1, string string_3, string string_4)
		: base(class1440_1)
	{
		dateTime_0 = dateTime_1;
		string_2 = string_3;
		string_1 = string_4;
		byte_0 = new byte[1500];
		memoryStream_0 = new MemoryStream(byte_0);
		memoryStream_0.Position = 0L;
		if (!(dateTime_1 == DateTime.MinValue))
		{
			string text = "<?xpacket begin=\"";
			memoryStream_0.Write(Encoding.ASCII.GetBytes(text), 0, text.Length);
			memoryStream_0.WriteByte(239);
			memoryStream_0.WriteByte(187);
			memoryStream_0.WriteByte(191);
			text = "\" id=\"W5M0MpCehiHzreSzNTczkc9d\"?><x:xmpmeta xmlns:x=\"adobe:ns:meta/\" x:xmptk=\"Aspose.Cells\"><rdf:RDF xmlns:rdf=\"http://www.w3.org/1999/02/22-rdf-syntax-ns#\">";
			text += "<rdf:Description rdf:about=\"\" xmlns:xmp=\"http://ns.adobe.com/xap/1.0/\"><xmp:CreateDate>XXXX</xmp:CreateDate><xmp:ModifyDate>XXXX</xmp:ModifyDate>";
			text += "<xmp:CreatorTool>Aspose.Cells</xmp:CreatorTool></rdf:Description><rdf:Description rdf:about=\"\" xmlns:dc=\"http://purl.org/dc/elements/1.1/\">";
			text += "<dc:format>application/pdf</dc:format><dc:title><rdf:Alt><rdf:li xml:lang=\"x-default\"></rdf:li></rdf:Alt></dc:title><dc:creator><rdf:Seq><rdf:li>AUTHOR</rdf:li>";
			text += "</rdf:Seq></dc:creator></rdf:Description><rdf:Description rdf:about=\"\" xmlns:pdf=\"http://ns.adobe.com/pdf/1.3/\"><pdf:Producer>YYYY</pdf:Producer>";
			text += "</rdf:Description><rdf:Description rdf:about=\"\" xmlns:pdfaid=\"http://www.aiim.org/pdfa/ns/id/\"><pdfaid:part>1</pdfaid:part><pdfaid:conformance>B</pdfaid:conformance>";
			text += "</rdf:Description></rdf:RDF></x:xmpmeta><?xpacket end=\"w\"?>";
			text = text.Replace("XXXX", Class1446.smethod_7(dateTime_0));
			text = text.Replace("YYYY", string_2);
			text = text.Replace("AUTHOR", string_1);
			memoryStream_0.Write(Encoding.ASCII.GetBytes(text), 0, text.Length);
		}
	}

	public override void vmethod_1(Class1447 class1447_0)
	{
		class1447_0.method_24(this);
		class1447_0.method_9();
		class1447_0.method_11("/Type", "/Metadata");
		class1447_0.method_11("/Subtype", "/XML");
		class1447_0.method_17("/Length", memoryStream_0.Position);
		class1447_0.method_10();
		class1447_0.Write("stream\r\n");
		class1447_0.Write(byte_0, 0, (int)memoryStream_0.Position);
		class1447_0.Write("\r\nendstream\r\n");
		class1447_0.method_25();
	}
}
