using System;
using System.Text;
using ns218;
using ns221;

namespace ns237;

internal class Class6524 : Class6514
{
	public Class6524(Class6672 context)
		: base(context)
	{
	}

	internal static string smethod_0(string tagName, string inlineAttr, string value)
	{
		if (!Class5964.smethod_20(value))
		{
			return string.Empty;
		}
		return "<" + tagName + ((inlineAttr.Length == 0) ? string.Empty : (" " + inlineAttr)) + ">" + (value.StartsWith("<") ? "\n" : string.Empty) + value + (value.EndsWith(">") ? "\n" : string.Empty) + "</" + tagName + ">\n";
	}

	internal static string smethod_1(string tagName, string value)
	{
		return smethod_0(tagName, string.Empty, value);
	}

	internal static string smethod_2(string tagName, DateTime value)
	{
		if (!(value == DateTime.MinValue))
		{
			return smethod_0(tagName, string.Empty, value.ToString("s") + "Z");
		}
		return string.Empty;
	}

	private static string smethod_3(string s)
	{
		if (!Class5964.smethod_20(s))
		{
			return s;
		}
		return s.Replace("&", "&amp;").Replace("<", "&lt;").Replace(">", "&gt;");
	}

	public override void vmethod_0(Class6679 writer)
	{
		string text = $"<?xpacket begin=\"{Encoding.UTF8.GetString(new byte[3] { 239, 187, 191 })}\" id=\"W5M0MpCehiHzreSzNTczkc9d\"?>\n";
		Class5956 info = class6672_0.Info;
		string text2 = smethod_0("rdf:Description", "rdf:about=\"\" xmlns:xmp=\"http://ns.adobe.com/xap/1.0/\"", smethod_2("xmp:CreateDate", info.CreationDate) + smethod_2("xmp:ModifyDate", info.ModifiedDate) + smethod_1("xmp:CreatorTool", smethod_3(info.Creator)));
		string text3 = smethod_0("rdf:Description", "rdf:about=\"\" xmlns:dc=\"http://purl.org/dc/elements/1.1/\"", smethod_1("dc:format", "application/pdf") + smethod_1("dc:title", smethod_1("rdf:Alt", smethod_0("rdf:li", "xml:lang=\"x-default\"", smethod_3(info.Title)))) + smethod_1("dc:creator", smethod_1("rdf:Seq", smethod_1("rdf:li", smethod_3(info.Author)))) + smethod_1("dc:description", smethod_1("rdf:Alt", smethod_0("rdf:li", "xml:lang=\"x-default\"", smethod_3(info.Subject)))));
		string text4 = smethod_0("rdf:Description", "rdf:about=\"\" xmlns:pdf=\"http://ns.adobe.com/pdf/1.3/\"", smethod_1("pdf:Keywords", smethod_3(info.Keywords)) + smethod_1("pdf:Producer", smethod_3(info.GeneratorName)));
		string text5 = (class6672_0.PdfaCompliant ? smethod_0("rdf:Description", "rdf:about=\"\" xmlns:pdfaid=\"http://www.aiim.org/pdfa/ns/id/\"", smethod_1("pdfaid:part", "1") + smethod_1("pdfaid:conformance", smethod_4(class6672_0.Options.Compliance))) : string.Empty);
		string value = smethod_0("rdf:RDF", "xmlns:rdf=\"http://www.w3.org/1999/02/22-rdf-syntax-ns#\"", text2 + text3 + text4 + text5);
		string s = text + smethod_0("x:xmpmeta", "xmlns:x=\"adobe:ns:meta/\" x:xmptk=\"PDFNet\"", value) + "<?xpacket end=\"w\"?>\n";
		byte[] bytes = Encoding.UTF8.GetBytes(s);
		Write(bytes, 0, bytes.Length);
		base.vmethod_0(writer);
	}

	private static string smethod_4(Enum883 compliance)
	{
		return compliance switch
		{
			Enum883.const_1 => "A", 
			Enum883.const_2 => "B", 
			_ => throw new ArgumentOutOfRangeException("compliance"), 
		};
	}

	internal override void vmethod_2(Class6679 writer)
	{
		writer.method_8("/Type", "/Metadata");
		writer.method_8("/Subtype", "/XML");
	}
}
