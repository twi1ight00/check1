using System.Collections;
using x6c95d9cf46ff5f25;

namespace xfc5388ad7dff404f;

internal class x37e34a3456bf5150
{
	private x37e34a3456bf5150()
	{
	}

	public static void x6210059f049f0d48(xada461b17cdccac0 xdcc37f62bf5b7d37, bool x5b792b12c6888eeb)
	{
		xf69e3cf19f0625a0(xdcc37f62bf5b7d37, xdcc37f62bf5b7d37.xadb7000bed559a9a, "", x5b792b12c6888eeb);
		ArrayList arrayList = new ArrayList();
		foreach (xa2f1c3dcbd86f20a item in (IEnumerable)xdcc37f62bf5b7d37.xd6abb2ab950b4d22)
		{
			if (item.xadb7000bed559a9a.xd44988f225497f3a > 0)
			{
				arrayList.Add(item);
			}
		}
		foreach (xa2f1c3dcbd86f20a item2 in arrayList)
		{
			xf69e3cf19f0625a0(xdcc37f62bf5b7d37, item2.xadb7000bed559a9a, item2.x759aa16c2016a289, x5b792b12c6888eeb);
		}
	}

	private static void xf69e3cf19f0625a0(xada461b17cdccac0 xdcc37f62bf5b7d37, x13a141f958daf286 x8b7997d01a099e87, string xbda579af315c6893, bool x5b792b12c6888eeb)
	{
		int num = xbda579af315c6893.LastIndexOf('/');
		string text = xbda579af315c6893.Substring(0, num + 1);
		string arg = xbda579af315c6893.Substring(num + 1);
		string partName = string.Format("{0}{1}_rels/{2}.rels", text.StartsWith("/") ? "" : "/", text, arg);
		xa2f1c3dcbd86f20a xa2f1c3dcbd86f20a2 = new xa2f1c3dcbd86f20a(partName, "application/vnd.openxmlformats-package.relationships+xml");
		x3c74b3c4f21844f9 x3c74b3c4f21844f = new x3c74b3c4f21844f9(xa2f1c3dcbd86f20a2.xb8a774e0111d0fbe, x5b792b12c6888eeb);
		x3c74b3c4f21844f.x9b9ed0109b743e3b("Relationships");
		x3c74b3c4f21844f.xff520a0047c27122("xmlns", "http://schemas.openxmlformats.org/package/2006/relationships");
		foreach (x5b6f1954712b741f item in (IEnumerable)x8b7997d01a099e87)
		{
			x3c74b3c4f21844f.x2307058321cdb62f("Relationship");
			x3c74b3c4f21844f.xff520a0047c27122("Id", item.xea1e81378298fa81);
			x3c74b3c4f21844f.xff520a0047c27122("Type", item.x3146d638ec378671);
			x3c74b3c4f21844f.xff520a0047c27122("Target", item.x42f4c234c9358072);
			if (item.x0552da4f5c09bde5)
			{
				x3c74b3c4f21844f.xff520a0047c27122("TargetMode", "External");
			}
			x3c74b3c4f21844f.x2dfde153f4ef96d0();
		}
		x3c74b3c4f21844f.xa0dfc102c691b11f();
		xdcc37f62bf5b7d37.xd6abb2ab950b4d22.xd6b6ed77479ef68c(xa2f1c3dcbd86f20a2);
	}
}
