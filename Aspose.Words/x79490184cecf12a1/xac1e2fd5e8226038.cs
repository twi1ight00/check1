using System.Collections;
using Aspose.Words.Markup;
using x38d3ef1c1d247e82;
using x6c95d9cf46ff5f25;
using xfc5388ad7dff404f;

namespace x79490184cecf12a1;

internal class xac1e2fd5e8226038
{
	private static readonly x94c83b1ca7961561 x7e9fe8bd7cff8e17;

	private xac1e2fd5e8226038()
	{
	}

	internal static void x06b0e25aa6ad68a9(x13a141f958daf286 x8b7997d01a099e87, xada461b17cdccac0 xdcc37f62bf5b7d37, CustomPartCollection x58ef006116d45b2c)
	{
		foreach (x5b6f1954712b741f item in (IEnumerable)x8b7997d01a099e87)
		{
			if (!x7e9fe8bd7cff8e17.x263d579af1d0d43f(item.x3146d638ec378671))
			{
				CustomPart customPart = xbbf0b42b871f1848(item, x8b7997d01a099e87.xd1accc61de11e4ae, xdcc37f62bf5b7d37);
				if (customPart != null)
				{
					x58ef006116d45b2c.Add(customPart);
				}
			}
		}
	}

	private static CustomPart xbbf0b42b871f1848(x5b6f1954712b741f x3203320ef44c211d, string x3705fee1ea1193c4, xada461b17cdccac0 xdcc37f62bf5b7d37)
	{
		CustomPart customPart = new CustomPart();
		customPart.RelationshipType = x3203320ef44c211d.x3146d638ec378671;
		customPart.IsExternal = x3203320ef44c211d.x0552da4f5c09bde5;
		if (x3203320ef44c211d.x0552da4f5c09bde5)
		{
			customPart.Name = x3203320ef44c211d.x42f4c234c9358072;
		}
		else
		{
			xa2f1c3dcbd86f20a xa2f1c3dcbd86f20a = xdcc37f62bf5b7d37.x7bd3b08f3e0470ca(xada461b17cdccac0.x653bf8787d72d626(x3705fee1ea1193c4, x3203320ef44c211d.x42f4c234c9358072));
			if (xa2f1c3dcbd86f20a == null)
			{
				return null;
			}
			customPart.Name = xa2f1c3dcbd86f20a.x759aa16c2016a289;
			customPart.ContentType = xa2f1c3dcbd86f20a.x0b93856f95be30d0;
			customPart.Data = x0d299f323d241756.xa0aed4cd3b3d5d92(xa2f1c3dcbd86f20a.xb8a774e0111d0fbe);
		}
		return customPart;
	}

	static xac1e2fd5e8226038()
	{
		x7e9fe8bd7cff8e17 = new x94c83b1ca7961561();
		x7e9fe8bd7cff8e17.xd6b6ed77479ef68c("http://schemas.openxmlformats.org/officeDocument/2006/relationships/officeDocument");
		x7e9fe8bd7cff8e17.xd6b6ed77479ef68c("http://schemas.openxmlformats.org/package/2006/relationships/metadata/core-properties");
		x7e9fe8bd7cff8e17.xd6b6ed77479ef68c("http://schemas.openxmlformats.org/officeDocument/2006/relationships/custom-properties");
		x7e9fe8bd7cff8e17.xd6b6ed77479ef68c("http://schemas.openxmlformats.org/officeDocument/2006/relationships/extended-properties");
		x7e9fe8bd7cff8e17.xd6b6ed77479ef68c("http://schemas.openxmlformats.org/package/2006/relationships/digital-signature/origin");
		x7e9fe8bd7cff8e17.xd6b6ed77479ef68c("http://schemas.openxmlformats.org/package/2006/relationships/metadata/thumbnail");
	}
}
