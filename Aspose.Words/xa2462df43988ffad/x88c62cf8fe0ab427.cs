using Aspose.Words.Fonts;
using x6c95d9cf46ff5f25;
using xbe73d5820f7f4ae3;

namespace xa2462df43988ffad;

internal class x88c62cf8fe0ab427
{
	private readonly xdb0bf9f81de4b38c x9b287b671d592594;

	internal x88c62cf8fe0ab427(xdb0bf9f81de4b38c writer)
	{
		x9b287b671d592594 = writer;
	}

	internal void x6210059f049f0d48()
	{
		x9c77c7e782b62883 xe1410f585439c7d = x9b287b671d592594.xe1410f585439c7d4;
		xe1410f585439c7d.x2307058321cdb62f("office:font-face-decls");
		foreach (FontInfo fontInfo in x9b287b671d592594.x2c8c6741422a1298.FontInfos)
		{
			x3d7fa875b37aeaa3(fontInfo);
		}
		xe1410f585439c7d.x2dfde153f4ef96d0("office:font-face-decls");
	}

	private void x3d7fa875b37aeaa3(FontInfo xfa5e135bae569bda)
	{
		if (x0d299f323d241756.x5959bccb67bbf051(xfa5e135bae569bda.Name))
		{
			x9c77c7e782b62883 xe1410f585439c7d = x9b287b671d592594.xe1410f585439c7d4;
			xe1410f585439c7d.x2307058321cdb62f("style:font-face");
			xe1410f585439c7d.x943f6be3acf634db("style:name", xfa5e135bae569bda.Name);
			xe1410f585439c7d.x943f6be3acf634db("svg:font-family", $"{xfa5e135bae569bda.Name}");
			xe1410f585439c7d.x943f6be3acf634db("style:font-pitch", x0eb9a864413f34de.x385e8e614138cf3e(xfa5e135bae569bda.Pitch));
			xe1410f585439c7d.x943f6be3acf634db("style:font-family-generic", x0eb9a864413f34de.x9b80d04beca7775c(xfa5e135bae569bda.Family));
			if (xfa5e135bae569bda.Charset == 2)
			{
				xe1410f585439c7d.x943f6be3acf634db("style:font-charset", "x-symbol");
			}
			xe1410f585439c7d.x2dfde153f4ef96d0("style:font-face");
		}
	}
}
