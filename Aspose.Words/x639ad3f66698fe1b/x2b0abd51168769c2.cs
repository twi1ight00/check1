using x28925c9b27b37a46;
using x556d8f9846e43329;
using xf989f31a236ff98c;

namespace x639ad3f66698fe1b;

internal class x2b0abd51168769c2
{
	private x9cb1edcd9725c81e x700b37a2d2434021;

	private readonly x21f0d20d41203be1 x8cedcaa9a62c6e39;

	private readonly xbfd162a6d47f59a4 x800085dd555f7711;

	internal static bool x492f529cee830a40;

	internal x2b0abd51168769c2(x21f0d20d41203be1 context)
	{
		x8cedcaa9a62c6e39 = context;
		x800085dd555f7711 = context.xe1410f585439c7d4;
	}

	internal void x6210059f049f0d48(x9cb1edcd9725c81e xb2e122499d93a089, bool x6d06576acbe8f10a)
	{
		x700b37a2d2434021 = xb2e122499d93a089;
		if (x6d06576acbe8f10a)
		{
			xd62cb8fdba40000c(x30187f754ccc677c: false, x370968c2ea974ce4: false);
		}
		else if (x700b37a2d2434021.x10da5e0a6e84ba64.Count != 0 || x700b37a2d2434021.x009293a054486e8d.Count != 0)
		{
			if (x700b37a2d2434021.xcedf9c82728ad579 == x1eec46d494a92718.xbbad6bbe73c6b1dc && x700b37a2d2434021.xd4e922ceeed89b74 == x1eec46d494a92718.x236cb0a4295bc034)
			{
				x17c397e2e155b0ed("\\ltrch", x60be0c9791e6242a: false, "\\rtlch", x542ed72298bc9814: true);
			}
			else if ((x700b37a2d2434021.xcedf9c82728ad579 == x1eec46d494a92718.x236cb0a4295bc034 && x700b37a2d2434021.xd4e922ceeed89b74 == x1eec46d494a92718.x236cb0a4295bc034) || (x700b37a2d2434021.xcedf9c82728ad579 == x1eec46d494a92718.x12642456c7bf0815 && x700b37a2d2434021.xd4e922ceeed89b74 == x1eec46d494a92718.x236cb0a4295bc034))
			{
				x17c397e2e155b0ed("\\rtlch", x60be0c9791e6242a: true, "\\ltrch", x542ed72298bc9814: false);
			}
			else if (x700b37a2d2434021.xcedf9c82728ad579 == x1eec46d494a92718.x236cb0a4295bc034 && x700b37a2d2434021.xd4e922ceeed89b74 == x1eec46d494a92718.xbbad6bbe73c6b1dc)
			{
				x17c397e2e155b0ed("\\fcs0", x60be0c9791e6242a: false, "\\fcs1", x542ed72298bc9814: true);
			}
			else if (x700b37a2d2434021.xcedf9c82728ad579 == x1eec46d494a92718.x236cb0a4295bc034 && x700b37a2d2434021.xd4e922ceeed89b74 == x1eec46d494a92718.x12642456c7bf0815)
			{
				x17c397e2e155b0ed("\\fcs1", x60be0c9791e6242a: true, "\\fcs0", x542ed72298bc9814: false);
			}
			else if (x700b37a2d2434021.xcedf9c82728ad579 == x1eec46d494a92718.x12642456c7bf0815 && x700b37a2d2434021.xd4e922ceeed89b74 == x1eec46d494a92718.x12642456c7bf0815)
			{
				x17c397e2e155b0ed("\\rtlch\\fcs1", x60be0c9791e6242a: true, "\\ltrch\\fcs0", x542ed72298bc9814: false);
			}
			else if (x700b37a2d2434021.xcedf9c82728ad579 == x1eec46d494a92718.x12642456c7bf0815 && x700b37a2d2434021.xd4e922ceeed89b74 == x1eec46d494a92718.xbbad6bbe73c6b1dc)
			{
				x17c397e2e155b0ed("\\rtlch\\fcs0", x60be0c9791e6242a: false, "\\ltrch\\fcs1", x542ed72298bc9814: true);
			}
			else if (x700b37a2d2434021.xcedf9c82728ad579 == x1eec46d494a92718.xbbad6bbe73c6b1dc && x700b37a2d2434021.xd4e922ceeed89b74 == x1eec46d494a92718.x12642456c7bf0815)
			{
				x17c397e2e155b0ed("\\ltrch\\fcs1", x60be0c9791e6242a: false, "\\rtlch\\fcs0", x542ed72298bc9814: true);
			}
			else if (x700b37a2d2434021.xcedf9c82728ad579 == x1eec46d494a92718.xbbad6bbe73c6b1dc && x700b37a2d2434021.xd4e922ceeed89b74 == x1eec46d494a92718.xbbad6bbe73c6b1dc)
			{
				x17c397e2e155b0ed("\\ltrch\\fcs0", x60be0c9791e6242a: false, "\\ltrch\\fcs1", x542ed72298bc9814: true);
			}
			else
			{
				xd62cb8fdba40000c(x30187f754ccc677c: false, x370968c2ea974ce4: false);
			}
		}
	}

	private void x17c397e2e155b0ed(string x2ff13daa8f1536ed, bool x60be0c9791e6242a, string xa1bdc56a50209fc9, bool x542ed72298bc9814)
	{
		x800085dd555f7711.x4d14ee33f46b5913(x2ff13daa8f1536ed);
		xd62cb8fdba40000c(x30187f754ccc677c: true, x60be0c9791e6242a);
		x800085dd555f7711.x4d14ee33f46b5913(xa1bdc56a50209fc9);
		xd62cb8fdba40000c(x30187f754ccc677c: false, x542ed72298bc9814);
	}

	private void xd62cb8fdba40000c(bool x30187f754ccc677c, bool x370968c2ea974ce4)
	{
		foreach (xfd5f3842a71dd76e item in x370968c2ea974ce4 ? x700b37a2d2434021.x009293a054486e8d : x700b37a2d2434021.x10da5e0a6e84ba64)
		{
			object xd2f68ee6f47e9dfb = item.xd2f68ee6f47e9dfb;
			switch (item.xb66f90d7e750b49e)
			{
			case 230:
			case 270:
				if (x30187f754ccc677c)
				{
					x800085dd555f7711.x4d14ee33f46b5913("\\af", x8cedcaa9a62c6e39.xc4e3012717edc490((string)xd2f68ee6f47e9dfb));
				}
				break;
			case 340:
			case 380:
				if (x30187f754ccc677c)
				{
					x800085dd555f7711.x4d14ee33f46b5913("\\alang", (int)xd2f68ee6f47e9dfb);
					break;
				}
				x800085dd555f7711.x4d14ee33f46b5913("\\lang", x700b37a2d2434021.x4709d73d132a99cb ? 1024 : ((int)xd2f68ee6f47e9dfb));
				x800085dd555f7711.x4d14ee33f46b5913("\\langnp", (int)xd2f68ee6f47e9dfb);
				break;
			case 390:
				if (!x30187f754ccc677c)
				{
					x800085dd555f7711.x4d14ee33f46b5913("\\langfe", x700b37a2d2434021.x4709d73d132a99cb ? 1024 : ((int)xd2f68ee6f47e9dfb));
					x800085dd555f7711.x4d14ee33f46b5913("\\langfenp", (int)xd2f68ee6f47e9dfb);
				}
				break;
			case 190:
			case 350:
				x800085dd555f7711.x4d14ee33f46b5913(x30187f754ccc677c ? "\\afs" : "\\fs", (int)xd2f68ee6f47e9dfb);
				break;
			case 60:
			case 250:
				x800085dd555f7711.xaf432784cda9acfa(x30187f754ccc677c ? "\\ab" : "\\b", ((x9b28b1f7f0cc963f)xd2f68ee6f47e9dfb).x4e98cd0cf854343f());
				break;
			case 70:
			case 260:
				x800085dd555f7711.xaf432784cda9acfa(x30187f754ccc677c ? "\\ai" : "\\i", ((x9b28b1f7f0cc963f)xd2f68ee6f47e9dfb).x4e98cd0cf854343f());
				break;
			}
		}
	}
}
