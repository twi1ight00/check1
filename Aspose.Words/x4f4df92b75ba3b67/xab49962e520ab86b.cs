using System;
using System.Collections;
using System.Text;
using x6c95d9cf46ff5f25;

namespace x4f4df92b75ba3b67;

internal class xab49962e520ab86b : x4d8917c8186e8cb2
{
	private bool x3c97d5d78862a238;

	public bool x3cb9052d058ce73a
	{
		get
		{
			return x3c97d5d78862a238;
		}
		set
		{
			x3c97d5d78862a238 = value;
		}
	}

	public xab49962e520ab86b(x4882ae789be6e2ef context)
		: base(context)
	{
	}

	internal static string x62fd39f24ff49a56(string x91ef5ae2997ab6c4, string x98d0f8b8f48c57ca, string xbcea506a33cf9111)
	{
		if (!x0d299f323d241756.x5959bccb67bbf051(xbcea506a33cf9111))
		{
			return "";
		}
		return "<" + x91ef5ae2997ab6c4 + ((x98d0f8b8f48c57ca == string.Empty) ? "" : (" " + x98d0f8b8f48c57ca)) + ">" + (xbcea506a33cf9111.StartsWith("<") ? "\n" : "") + xbcea506a33cf9111 + (xbcea506a33cf9111.EndsWith(">") ? "\n" : "") + "</" + x91ef5ae2997ab6c4 + ">\n";
	}

	internal static string x62fd39f24ff49a56(string x91ef5ae2997ab6c4, string xbcea506a33cf9111)
	{
		return x62fd39f24ff49a56(x91ef5ae2997ab6c4, "", xbcea506a33cf9111);
	}

	internal static string x62fd39f24ff49a56(string x91ef5ae2997ab6c4, DateTime xbcea506a33cf9111)
	{
		if (!(xbcea506a33cf9111 == DateTime.MinValue))
		{
			return x62fd39f24ff49a56(x91ef5ae2997ab6c4, "", xbcea506a33cf9111.ToString("s") + "Z");
		}
		return string.Empty;
	}

	private static string xa8ac99a2a2475d27(string xe4115acdf4fbfccc)
	{
		if (!x0d299f323d241756.x5959bccb67bbf051(xe4115acdf4fbfccc))
		{
			return xe4115acdf4fbfccc;
		}
		return xe4115acdf4fbfccc.Replace("&", "&amp;").Replace("<", "&lt;").Replace(">", "&gt;");
	}

	public override void WriteToPdf(x4f40d990d5bf81a6 writer)
	{
		string text = $"<?xpacket begin=\"{Encoding.UTF8.GetString(new byte[3] { 239, 187, 191 })}\" id=\"W5M0MpCehiHzreSzNTczkc9d\"?>\n";
		xfaf91ffd88d78c15 xb444c09fa044bbca = x8cedcaa9a62c6e39.xb444c09fa044bbca;
		string text2 = x62fd39f24ff49a56("rdf:Description", "rdf:about=\"\" xmlns:xmp=\"http://ns.adobe.com/xap/1.0/\"", x62fd39f24ff49a56("xmp:CreateDate", xb444c09fa044bbca.x01fda47aa971692d) + x62fd39f24ff49a56("xmp:ModifyDate", xb444c09fa044bbca.xdd48db0e1a80d624) + x62fd39f24ff49a56("xmp:CreatorTool", xa8ac99a2a2475d27(xb444c09fa044bbca.x1d3fdaa19c46dec0)));
		string text3 = xa62d95bec515a677(xb444c09fa044bbca);
		string text4 = string.Empty;
		string text5 = string.Empty;
		string text6 = string.Empty;
		if (!x3c97d5d78862a238)
		{
			text4 = x62fd39f24ff49a56("rdf:Description", "rdf:about=\"\" xmlns:dc=\"http://purl.org/dc/elements/1.1/\"", x62fd39f24ff49a56("dc:format", "application/pdf") + x62fd39f24ff49a56("dc:title", x62fd39f24ff49a56("rdf:Alt", x62fd39f24ff49a56("rdf:li", "xml:lang=\"x-default\"", xa8ac99a2a2475d27(xb444c09fa044bbca.x238bf167ccfdd282)))) + x62fd39f24ff49a56("dc:creator", x62fd39f24ff49a56("rdf:Seq", x62fd39f24ff49a56("rdf:li", xa8ac99a2a2475d27(xb444c09fa044bbca.xb063bbfcfeade526)))) + x62fd39f24ff49a56("dc:description", x62fd39f24ff49a56("rdf:Alt", x62fd39f24ff49a56("rdf:li", "xml:lang=\"x-default\"", xa8ac99a2a2475d27(xb444c09fa044bbca.x191dcb88c409b8dd)))));
			text5 = x62fd39f24ff49a56("rdf:Description", "rdf:about=\"\" xmlns:pdf=\"http://ns.adobe.com/pdf/1.3/\"", x62fd39f24ff49a56("pdf:Keywords", xa8ac99a2a2475d27(xb444c09fa044bbca.x514c0ea24ce40ef0)) + x62fd39f24ff49a56("pdf:Producer", xa8ac99a2a2475d27(xb444c09fa044bbca.xc605b5c8a6696acf)));
			text6 = x62fd39f24ff49a56("rdf:Description", "rdf:about=\"\" xmlns:pdfaid=\"http://www.aiim.org/pdfa/ns/id/\"", x62fd39f24ff49a56("pdfaid:part", "1") + x62fd39f24ff49a56("pdfaid:conformance", "B"));
		}
		string xbcea506a33cf = x62fd39f24ff49a56("rdf:RDF", "xmlns:rdf=\"http://www.w3.org/1999/02/22-rdf-syntax-ns#\"", text2 + text4 + text5 + text6 + text3);
		string s = text + x62fd39f24ff49a56("x:xmpmeta", "xmlns:x=\"adobe:ns:meta/\" x:xmptk=\"PDFNet\"", xbcea506a33cf) + "<?xpacket end=\"w\"?>\n";
		byte[] bytes = Encoding.UTF8.GetBytes(s);
		x6210059f049f0d48(bytes, 0, bytes.Length);
		base.WriteToPdf(writer);
	}

	private static string xa62d95bec515a677(xfaf91ffd88d78c15 x8d3f74e5f925679c)
	{
		StringBuilder stringBuilder = new StringBuilder();
		foreach (DictionaryEntry item in x8d3f74e5f925679c.x3cf6307c7a72516d)
		{
			stringBuilder.Append(x62fd39f24ff49a56("custprops:" + xa8ac99a2a2475d27(item.Key.ToString()), xa8ac99a2a2475d27(item.Value.ToString())));
		}
		if (stringBuilder.Length != 0)
		{
			return x62fd39f24ff49a56("rdf:Description", "rdf:about=\"\" xmlns:custprops=\"http://aspose.com/\"", stringBuilder.ToString());
		}
		return string.Empty;
	}

	internal override void x0a2e1f2c2da67e52(x4f40d990d5bf81a6 xbdfb620b7167944b)
	{
		xbdfb620b7167944b.xa4dc0ad8886e23a2("/Type", "/Metadata");
		xbdfb620b7167944b.xa4dc0ad8886e23a2("/Subtype", "/XML");
	}

	internal override x4c746eafc29e5079 xf57599e513eb82be()
	{
		if (x8cedcaa9a62c6e39.x5ba9693d4c3c102e)
		{
			return null;
		}
		return base.xf57599e513eb82be();
	}
}
