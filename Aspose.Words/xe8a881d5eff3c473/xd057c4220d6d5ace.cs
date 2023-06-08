using System.Collections;
using System.IO;
using x1c8faa688b1f0b0c;
using x6c95d9cf46ff5f25;
using xaf73fad8cede26de;

namespace xe8a881d5eff3c473;

internal class xd057c4220d6d5ace
{
	private int xf51d7fbd0ad7745b = 1;

	private readonly x49c255776a98e55d x58733fe814e2e57f;

	private x04dfbda002f0cf6a xc4cc21b78abf1fcf;

	private readonly x5e2e30bcd1453aea x9d709e8b07adca71;

	private readonly ArrayList x3bb434db1f3ba858 = new ArrayList();

	public x04dfbda002f0cf6a x38f1a5c6c8faf5b1 => xc4cc21b78abf1fcf;

	public xfaf91ffd88d78c15 xb444c09fa044bbca => x9d709e8b07adca71.xb444c09fa044bbca;

	public xd057c4220d6d5ace(Stream outputStream, string resourcesFolderPath, string resourcesFolderAlias, x54b98d0096d7251a warningCallback)
	{
		x58733fe814e2e57f = new x49c255776a98e55d(outputStream, isPrettyFormat: true);
		x9d709e8b07adca71 = new x5e2e30bcd1453aea(resourcesFolderPath, resourcesFolderAlias, warningCallback);
		xc8b972d76c12678f();
	}

	public void xb0882cca5e6880d3()
	{
		x58733fe814e2e57f.xa0dfc102c691b11f();
		x9d709e8b07adca71.xa04e23b676ea0cc9();
	}

	public void x804b2039ae4e9b33(float x9b0739496f8b5475, float x4d5aabc7a55b12ba)
	{
		x58733fe814e2e57f.x2307058321cdb62f("PageContent");
		xc4cc21b78abf1fcf = new x04dfbda002f0cf6a(x9d709e8b07adca71, x58733fe814e2e57f, isXps: false);
		xc4cc21b78abf1fcf.x804b2039ae4e9b33(xf51d7fbd0ad7745b, x9b0739496f8b5475, x4d5aabc7a55b12ba);
	}

	public void xa0cf4a18229be519()
	{
		xc4cc21b78abf1fcf.xa0cf4a18229be519();
		x58733fe814e2e57f.x2dfde153f4ef96d0();
		xf51d7fbd0ad7745b++;
	}

	public void x7db09d025a6abf05(x9a66d03de2ff27e1 xa490ad5ef1682691)
	{
		if (!x3bb434db1f3ba858.Contains(xa490ad5ef1682691.x759aa16c2016a289))
		{
			xc4cc21b78abf1fcf.x7db09d025a6abf05(x9d709e8b07adca71.x94f739530d38cc0a(xa490ad5ef1682691.x759aa16c2016a289), xa490ad5ef1682691.xc22eade24b085d91);
			x3bb434db1f3ba858.Add(xa490ad5ef1682691.x759aa16c2016a289);
		}
	}

	private void xc8b972d76c12678f()
	{
		x58733fe814e2e57f.x9b9ed0109b743e3b("FixedDocument");
		x58733fe814e2e57f.xff520a0047c27122("xmlns", "http://schemas.microsoft.com/winfx/2006/xaml/presentation");
	}
}
