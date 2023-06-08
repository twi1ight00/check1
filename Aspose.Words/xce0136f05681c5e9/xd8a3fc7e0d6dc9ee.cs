using System;
using System.IO;
using Aspose.Words;
using Aspose.Words.Saving;
using x13cd31bb39e0b7ea;
using x28925c9b27b37a46;

namespace xce0136f05681c5e9;

internal class xd8a3fc7e0d6dc9ee : x2e1772435f9b2289
{
	private readonly HtmlSaveOptions x1cb867f3d40f3203;

	internal xd8a3fc7e0d6dc9ee()
	{
		x1cb867f3d40f3203 = HtmlSaveOptions.x18b62f13f9c822a8();
	}

	internal xd8a3fc7e0d6dc9ee(HtmlSaveOptions saveOptions)
	{
		x1cb867f3d40f3203 = saveOptions;
	}

	public string xa45b9f6fb2389318(Node xda5bf54deb817e37)
	{
		if (xda5bf54deb817e37.NodeType == NodeType.GlossaryDocument)
		{
			throw new InvalidOperationException("GlossaryDocument isn't supported!");
		}
		if (xda5bf54deb817e37.Document.NodeType == NodeType.GlossaryDocument)
		{
			throw new InvalidOperationException("Children nodes of GlossaryDocument aren't supported!");
		}
		using Stream stream = new MemoryStream();
		Document document = (Document)xda5bf54deb817e37.Document;
		x8556eed81191af11 x8556eed81191af = new x8556eed81191af11(document, stream, null, x1cb867f3d40f3203);
		xcc0b5baa75272714 xcc0b5baa = new xcc0b5baa75272714();
		xcc0b5baa.x18dfca7c5fd2402f(x8556eed81191af);
		x754017e579b6a8ff x754017e579b6a8ff2 = new x754017e579b6a8ff(document, stream, null, x1cb867f3d40f3203, x8556eed81191af.x158c955c749c5e5b, null, null);
		if (xcc0b5baa.x22ff8ac1bb608a92.ContainsKey(xda5bf54deb817e37))
		{
			xda5bf54deb817e37 = (Node)xcc0b5baa.x22ff8ac1bb608a92[xda5bf54deb817e37];
		}
		x754017e579b6a8ff2.x9409daed2a2588c0(xda5bf54deb817e37);
		xcc0b5baa.x3522790e002e1ba4();
		stream.Position = 0L;
		using StreamReader streamReader = new StreamReader(stream);
		return streamReader.ReadToEnd();
	}
}
