using x28925c9b27b37a46;

namespace x611adfb9b9d21a97;

internal class x78efcb58d03c2f11 : xb00f4ba8788bbec8
{
	internal x78efcb58d03c2f11(string documentBaseName, x8556eed81191af11 saveInfo)
		: base("META-INF/container.xml", documentBaseName, saveInfo)
	{
	}

	internal void x95d1f647e5465823()
	{
		base.x5222f4285e37d66b.WriteStartDocument();
		x2307058321cdb62f("container");
		xff520a0047c27122("xmlns", "urn:oasis:names:tc:opendocument:xmlns:container");
		xff520a0047c27122("version", "1.0");
		x2307058321cdb62f("rootfiles");
		x2307058321cdb62f("rootfile");
		xff520a0047c27122("full-path", base.x38b59ec08314c0f0);
		xff520a0047c27122("media-type", "application/oebps-package+xml");
		x2dfde153f4ef96d0();
		x538f0e0fb2bf15ab();
		xa0dfc102c691b11f();
	}
}
