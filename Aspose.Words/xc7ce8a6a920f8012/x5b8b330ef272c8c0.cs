using System.IO;
using System.Text;
using x6c95d9cf46ff5f25;

namespace xc7ce8a6a920f8012;

internal class x5b8b330ef272c8c0 : x0096796e2eb81db6
{
	public x5b8b330ef272c8c0(x34b34bf589d8ec1e context)
		: base(context)
	{
	}

	public void xb957ffdf5627f75a(xfaf91ffd88d78c15 x8d3f74e5f925679c)
	{
		base.x28fcdc775a1d069c.xbbf9a1ead81dd3a1(x6d058fdf61831c39.x42daab0e7e499260, "Only Title, Description, GeneratorName, Creator and CreationDate properties will be output to SWF all other built-in and custom document properties will be lost.");
		xb4e6bcae51300e9c xb4e6bcae51300e9c2 = new xb4e6bcae51300e9c(base.x28fcdc775a1d069c);
		xb4e6bcae51300e9c2.xacf4b9ddf32bef06();
		base.x5aa326f374b3d0ef.xf2c2dbac0bb24ba0(xb511fce2d7b43fa0(x8d3f74e5f925679c));
		xb4e6bcae51300e9c2.xc463dec5a3ab6e2d(xf066f1f57515a14c.x9cbb8cfdfe94924d);
	}

	private static string xb511fce2d7b43fa0(xfaf91ffd88d78c15 x8d3f74e5f925679c)
	{
		using MemoryStream memoryStream = new MemoryStream();
		Encoding encoding = new UTF8Encoding(encoderShouldEmitUTF8Identifier: false);
		x3c74b3c4f21844f9 x3c74b3c4f21844f = new x3c74b3c4f21844f9(memoryStream, encoding, isPrettyFormat: false);
		x3c74b3c4f21844f.x9b9ed0109b743e3b("rdf:RDF");
		x3c74b3c4f21844f.xff520a0047c27122("xmlns:rdf", "http://www.w3.org/1999/02/22-rdf-syntax-ns#");
		x3c74b3c4f21844f.x2307058321cdb62f("rdf:Description");
		x3c74b3c4f21844f.xff520a0047c27122("rdf:about", "");
		x3c74b3c4f21844f.xff520a0047c27122("xmlns:dc", "http://purl.org/dc/elements/1.1");
		x3c74b3c4f21844f.x6b73ce92fd8e3f2c("dc:format", "application/x-shockwave-flash");
		x3c74b3c4f21844f.x6b73ce92fd8e3f2c("dc:title", x8d3f74e5f925679c.x238bf167ccfdd282);
		x3c74b3c4f21844f.x6b73ce92fd8e3f2c("dc:description", x8d3f74e5f925679c.x3d235fc95c355365);
		x3c74b3c4f21844f.x6b73ce92fd8e3f2c("dc:publisher", x8d3f74e5f925679c.xc605b5c8a6696acf);
		x3c74b3c4f21844f.x6b73ce92fd8e3f2c("dc:creator", x8d3f74e5f925679c.x1d3fdaa19c46dec0);
		x3c74b3c4f21844f.x6b73ce92fd8e3f2c("dc:date", x8d3f74e5f925679c.x01fda47aa971692d.ToShortDateString());
		x3c74b3c4f21844f.x2dfde153f4ef96d0();
		x3c74b3c4f21844f.xa0dfc102c691b11f();
		return encoding.GetString(memoryStream.GetBuffer(), 0, (int)memoryStream.Length);
	}
}
