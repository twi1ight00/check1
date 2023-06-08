using System.Text;
using x1a3e96f4b89a7a77;
using x55b2bd426d41d30c;
using xbe73d5820f7f4ae3;

namespace xa2462df43988ffad;

internal class x9c77c7e782b62883 : x873451caae5ad4ae
{
	internal x9c77c7e782b62883(x0ca5e8b532953a51 part, bool isPrettyFormat)
		: base(part.xb8a774e0111d0fbe, new UTF8Encoding(encoderShouldEmitUTF8Identifier: false), isPrettyFormat, useOnOff: false)
	{
	}

	internal void xd752bfc8559f7490()
	{
		x9b9ed0109b743e3b("office:document-content");
		x4aa5bf9ba55adbc9();
	}

	internal void xa4f71b437449ecdc()
	{
		x9b9ed0109b743e3b("office:document-styles");
		x4aa5bf9ba55adbc9();
	}

	internal void xea077c7b3b428a58()
	{
		x9b9ed0109b743e3b("office:document-meta");
		xf2b939c78a6a9b1c();
	}

	internal void x56de5194528bd68b()
	{
		x9b9ed0109b743e3b("office:document-settings");
		xea871010e415c194();
		xff520a0047c27122("xmlns:config", "urn:oasis:names:tc:opendocument:xmlns:config:1.0");
	}

	internal void x054f32d44328bd1f()
	{
		x9b9ed0109b743e3b("manifest:manifest");
		xff520a0047c27122("xmlns:manifest", "urn:oasis:names:tc:opendocument:xmlns:manifest:1.0");
	}

	private void x4aa5bf9ba55adbc9()
	{
		xf2b939c78a6a9b1c();
		xff520a0047c27122("xmlns:style", "urn:oasis:names:tc:opendocument:xmlns:style:1.0");
		xff520a0047c27122("xmlns:text", "urn:oasis:names:tc:opendocument:xmlns:text:1.0");
		xff520a0047c27122("xmlns:table", "urn:oasis:names:tc:opendocument:xmlns:table:1.0");
		xff520a0047c27122("xmlns:draw", "urn:oasis:names:tc:opendocument:xmlns:drawing:1.0");
		xff520a0047c27122("xmlns:fo", "urn:oasis:names:tc:opendocument:xmlns:xsl-fo-compatible:1.0");
		xff520a0047c27122("xmlns:number", "urn:oasis:names:tc:opendocument:xmlns:datastyle:1.0");
		xff520a0047c27122("xmlns:svg", "urn:oasis:names:tc:opendocument:xmlns:svg-compatible:1.0");
		xff520a0047c27122("xmlns:chart", "urn:oasis:names:tc:opendocument:xmlns:chart:1.0");
		xff520a0047c27122("xmlns:dr3d", "urn:oasis:names:tc:opendocument:xmlns:dr3d:1.0");
		xff520a0047c27122("xmlns:math", "http://www.w3.org/1998/Math/MathML");
		xff520a0047c27122("xmlns:form", "urn:oasis:names:tc:opendocument:xmlns:form:1.0");
		xff520a0047c27122("xmlns:script", "urn:oasis:names:tc:opendocument:xmlns:script:1.0");
		xff520a0047c27122("xmlns:ooow", "http://openoffice.org/2004/writer");
		xff520a0047c27122("xmlns:oooc", "http://openoffice.org/2004/calc");
		xff520a0047c27122("xmlns:dom", "http://www.w3.org/2001/xml-events");
	}

	private void xf2b939c78a6a9b1c()
	{
		xea871010e415c194();
		xff520a0047c27122("xmlns:dc", "http://purl.org/dc/elements/1.1/");
		xff520a0047c27122("xmlns:meta", "urn:oasis:names:tc:opendocument:xmlns:meta:1.0");
	}

	private void xea871010e415c194()
	{
		xff520a0047c27122("office:version", "1.1");
		xff520a0047c27122("xmlns:office", "urn:oasis:names:tc:opendocument:xmlns:office:1.0");
		xff520a0047c27122("xmlns:xlink", "http://www.w3.org/1999/xlink");
		xff520a0047c27122("xmlns:ooo", "http://openoffice.org/2004/office");
	}

	internal void x5a3f5d78674f78e4(string x121383aa64985888)
	{
		xd52401bdf5aacef6($"<{x121383aa64985888} ");
	}

	internal void xf3cbeec41f083290(string x121383aa64985888)
	{
		xd52401bdf5aacef6($"</{x121383aa64985888}>");
	}

	internal void x19b0790c272bbe88(string xb591dc602a67d872, string x14ce39bb4fe9496c)
	{
		if (x14ce39bb4fe9496c != null)
		{
			x3d1be38abe5723e3(string.Format("{0}=\"{1}\" ", xb591dc602a67d872, x14ce39bb4fe9496c.Replace("\"", "")));
		}
	}

	internal void x53e7651cce580e9f(string xb591dc602a67d872, string x14ce39bb4fe9496c)
	{
		x19b0790c272bbe88(xb591dc602a67d872, x14ce39bb4fe9496c);
		xd52401bdf5aacef6(">");
	}

	internal void xa10744432d06325a(string xbd5a2e7a4ff749c9)
	{
		string text = xbb857c9fc36f5054.x127fca996f5c76e4(xbd5a2e7a4ff749c9);
		string text2 = xbb857c9fc36f5054.x94045081801bb82d(xbd5a2e7a4ff749c9);
		x943f6be3acf634db("style:name", text);
		if (text2 != text)
		{
			x943f6be3acf634db("style:display-name", text2);
		}
	}
}
