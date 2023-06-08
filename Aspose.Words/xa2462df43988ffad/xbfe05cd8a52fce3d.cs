namespace xa2462df43988ffad;

internal class xbfe05cd8a52fce3d
{
	private readonly x9c77c7e782b62883 x800085dd555f7711;

	private readonly xdb0bf9f81de4b38c x9b287b671d592594;

	internal xbfe05cd8a52fce3d(xdb0bf9f81de4b38c writer)
	{
		x9b287b671d592594 = writer;
		x800085dd555f7711 = writer.x082c3925d43afdad("/META-INF/manifest.xml");
	}

	internal void x6210059f049f0d48(string xe1d3286d17e44a37)
	{
		x800085dd555f7711.x054f32d44328bd1f();
		x800085dd555f7711.xc049ea80ee267201("manifest:file-entry", "manifest:media-type", xe1d3286d17e44a37, "manifest:full-path", "/");
		xce26e429ab648a64("text/xml", "content.xml");
		xce26e429ab648a64("text/xml", "styles.xml");
		xce26e429ab648a64("text/xml", "meta.xml");
		xce26e429ab648a64("text/xml", "settings.xml");
		if (x9b287b671d592594.x862b4148836ee29c.Count > 0)
		{
			xce26e429ab648a64("", "Pictures/");
		}
		foreach (x03305f81beb3a033 item in x9b287b671d592594.x862b4148836ee29c)
		{
			xce26e429ab648a64(item.xea0d040d38d75a91, item.x632b457a1248cdb1);
		}
		if (x9b287b671d592594.x23c93f2a46f812b5.Count > 0)
		{
			xce26e429ab648a64("", "ObjectReplacements/");
		}
		foreach (x03305f81beb3a033 item2 in x9b287b671d592594.x23c93f2a46f812b5)
		{
			xce26e429ab648a64(item2.xea0d040d38d75a91, item2.x632b457a1248cdb1);
		}
		foreach (x03305f81beb3a033 item3 in x9b287b671d592594.xdb9a725c50caafe9)
		{
			xce26e429ab648a64("application/vnd.oasis.opendocument.formula", item3.x632b457a1248cdb1);
			xce26e429ab648a64(item3.xea0d040d38d75a91, $"{item3.x632b457a1248cdb1}{item3.x3d75ee2af8ab22ab}");
		}
		x800085dd555f7711.xa0dfc102c691b11f();
	}

	internal void xce26e429ab648a64(string x9c1b9627c9a8cad5, string x34af798817dca2e0)
	{
		x800085dd555f7711.x2307058321cdb62f("manifest:file-entry");
		x800085dd555f7711.xff520a0047c27122("manifest:media-type", x9c1b9627c9a8cad5);
		x800085dd555f7711.x943f6be3acf634db("manifest:full-path", x34af798817dca2e0);
		x800085dd555f7711.x2dfde153f4ef96d0("manifest:file-entry");
	}
}
