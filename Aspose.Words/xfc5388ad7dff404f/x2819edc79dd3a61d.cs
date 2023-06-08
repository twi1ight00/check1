using System.Collections;
using x6c95d9cf46ff5f25;

namespace xfc5388ad7dff404f;

internal class x2819edc79dd3a61d
{
	private x2819edc79dd3a61d()
	{
	}

	public static void x6210059f049f0d48(xe965bada78e2d6b1 xb47ec36353352bef, bool x5b792b12c6888eeb)
	{
		xd345c73dd1b16b74 xd345c73dd1b16b = new xd345c73dd1b16b74();
		xd345c73dd1b16b74 xd345c73dd1b16b2 = new xd345c73dd1b16b74();
		foreach (xa2f1c3dcbd86f20a item in (IEnumerable)xb47ec36353352bef.xd6abb2ab950b4d22)
		{
			switch (item.x0b93856f95be30d0)
			{
			case "image/bmp":
			case "image/x-emf":
			case "image/gif":
			case "image/jpeg":
			case "image/x-pcz":
			case "image/png":
			case "image/x-wmf":
			case "application/vnd.openxmlformats-officedocument.obfuscatedFont":
				xd345c73dd1b16b[item.x189167ca3b0a8e0b] = item.x0b93856f95be30d0;
				break;
			default:
				xd345c73dd1b16b2.Add(item.x759aa16c2016a289, item.x0b93856f95be30d0);
				break;
			case "application/vnd.openxmlformats-package.relationships+xml":
				break;
			}
		}
		xa2f1c3dcbd86f20a xa2f1c3dcbd86f20a3 = new xa2f1c3dcbd86f20a("/[Content_Types].xml", "");
		xb47ec36353352bef.xd6abb2ab950b4d22.xd6b6ed77479ef68c(xa2f1c3dcbd86f20a3);
		x3c74b3c4f21844f9 x3c74b3c4f21844f = new x3c74b3c4f21844f9(xa2f1c3dcbd86f20a3.xb8a774e0111d0fbe, x5b792b12c6888eeb);
		x3c74b3c4f21844f.x9b9ed0109b743e3b("Types");
		x3c74b3c4f21844f.xff520a0047c27122("xmlns", "http://schemas.openxmlformats.org/package/2006/content-types");
		foreach (DictionaryEntry item2 in xd345c73dd1b16b)
		{
			x14caa163f231606a((string)item2.Key, (string)item2.Value, x3c74b3c4f21844f);
		}
		x14caa163f231606a("rels", "application/vnd.openxmlformats-package.relationships+xml", x3c74b3c4f21844f);
		x14caa163f231606a("xml", "application/xml", x3c74b3c4f21844f);
		foreach (DictionaryEntry item3 in xd345c73dd1b16b2)
		{
			x0d51c8ce682e33f4((string)item3.Key, (string)item3.Value, x3c74b3c4f21844f);
		}
		x3c74b3c4f21844f.xa0dfc102c691b11f();
	}

	private static void x14caa163f231606a(string xca6cce6923124135, string xe1d3286d17e44a37, x3c74b3c4f21844f9 xd07ce4b74c5774a7)
	{
		xd07ce4b74c5774a7.x2307058321cdb62f("Default");
		xd07ce4b74c5774a7.xff520a0047c27122("Extension", xca6cce6923124135);
		xd07ce4b74c5774a7.xff520a0047c27122("ContentType", xe1d3286d17e44a37);
		xd07ce4b74c5774a7.x2dfde153f4ef96d0();
	}

	private static void x0d51c8ce682e33f4(string x69cb5ff2e6c23f47, string xe1d3286d17e44a37, x3c74b3c4f21844f9 xd07ce4b74c5774a7)
	{
		xd07ce4b74c5774a7.x2307058321cdb62f("Override");
		xd07ce4b74c5774a7.xff520a0047c27122("PartName", x69cb5ff2e6c23f47);
		xd07ce4b74c5774a7.xff520a0047c27122("ContentType", xe1d3286d17e44a37);
		xd07ce4b74c5774a7.x2dfde153f4ef96d0();
	}
}
