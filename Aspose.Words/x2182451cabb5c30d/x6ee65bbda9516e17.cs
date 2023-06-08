using System;
using Aspose.Words.Properties;
using x556d8f9846e43329;
using x6c95d9cf46ff5f25;
using xf9a9481c3f63a419;

namespace x2182451cabb5c30d;

internal class x6ee65bbda9516e17 : x77fb5b1d5c73757b
{
	private string x38385f1e5a2e9b38;

	private string xb028d7caf00bc546;

	private string xec03d04534563779;

	private PropertyType x4a7ef32e5070e77b;

	internal x6ee65bbda9516e17(xe5e546ef5f0503b2 context)
		: base(context)
	{
	}

	internal override void xa4085ff83f9ddeeb()
	{
		if (base.x1a55de3a01c1c82d.x3146d638ec378671 == x25099a8bbbd55d1c.x8c31dccbd14607be)
		{
			xfb0ab2ca3bdb8d47();
		}
	}

	internal override void x1d4c43383d15306d()
	{
		if (base.x1a55de3a01c1c82d.x3146d638ec378671 == x25099a8bbbd55d1c.x4f52398a8225e3d4)
		{
			xfb0ab2ca3bdb8d47();
		}
	}

	internal override void xa2d8e36cb99ac0f4(x03f56b37a0050a82 x153c99a852375422)
	{
		if (x153c99a852375422.x1dafd189c5465293() == "\\proptype")
		{
			object obj = x1cf55bf1c1c040ec.x882e9e26d2730a0c(x153c99a852375422.xd6f9e3c5ae6509d7().ToString());
			if (obj != null)
			{
				x4a7ef32e5070e77b = (PropertyType)obj;
			}
		}
	}

	internal override void xbd6083b329527c4e(x03f56b37a0050a82 x153c99a852375422)
	{
		switch (base.x1a55de3a01c1c82d.x3146d638ec378671)
		{
		case x25099a8bbbd55d1c.x34bbb6ae17f92a08:
			xfb0ab2ca3bdb8d47();
			x38385f1e5a2e9b38 = x153c99a852375422.x9f1a6a3451a38d10();
			break;
		case x25099a8bbbd55d1c.x8c31dccbd14607be:
			xb028d7caf00bc546 = x153c99a852375422.x9f1a6a3451a38d10();
			break;
		case x25099a8bbbd55d1c.xae532d6137cd8e48:
			xec03d04534563779 = x153c99a852375422.x9f1a6a3451a38d10();
			break;
		}
	}

	private void xfb0ab2ca3bdb8d47()
	{
		if (!x0d299f323d241756.x5959bccb67bbf051(x38385f1e5a2e9b38))
		{
			return;
		}
		CustomDocumentProperties customDocumentProperties = x28fcdc775a1d069c.x2c8c6741422a1298.CustomDocumentProperties;
		switch (x4a7ef32e5070e77b)
		{
		case PropertyType.Number:
		{
			int num = xca004f56614e2431.x83da27b1750f1f84(xb028d7caf00bc546);
			if (num != int.MinValue)
			{
				customDocumentProperties.x1cd8943d02c5342f(x38385f1e5a2e9b38, num);
			}
			break;
		}
		case PropertyType.Double:
		{
			double num2 = xca004f56614e2431.x9af476c0811d07cd(xb028d7caf00bc546);
			if (!double.IsNaN(num2))
			{
				customDocumentProperties.x1cd8943d02c5342f(x38385f1e5a2e9b38, num2);
			}
			break;
		}
		case PropertyType.DateTime:
		{
			DateTime dateTime = xca004f56614e2431.x5fa9002eedbc901d(xb028d7caf00bc546);
			if (dateTime != DateTime.MinValue)
			{
				dateTime += TimeSpan.FromHours(12.0);
				customDocumentProperties.x1cd8943d02c5342f(x38385f1e5a2e9b38, dateTime);
			}
			break;
		}
		case PropertyType.Boolean:
			customDocumentProperties.x1cd8943d02c5342f(x38385f1e5a2e9b38, xb028d7caf00bc546 != "0");
			break;
		case PropertyType.String:
			if (xb028d7caf00bc546 != null)
			{
				DocumentProperty documentProperty = customDocumentProperties.x1cd8943d02c5342f(x38385f1e5a2e9b38, xb028d7caf00bc546);
				if (x0d299f323d241756.x5959bccb67bbf051(xec03d04534563779))
				{
					documentProperty.x1321c7b28b151682 = xec03d04534563779;
				}
			}
			break;
		}
		x38385f1e5a2e9b38 = null;
		xb028d7caf00bc546 = null;
		xec03d04534563779 = null;
		x4a7ef32e5070e77b = PropertyType.Other;
	}

	internal override x77fb5b1d5c73757b x3e0bce851c12a688(xbf575e106f2f2373 x8d3f74e5f925679c)
	{
		switch (x8d3f74e5f925679c.x3146d638ec378671)
		{
		case x25099a8bbbd55d1c.x34bbb6ae17f92a08:
		case x25099a8bbbd55d1c.x8c31dccbd14607be:
		case x25099a8bbbd55d1c.xae532d6137cd8e48:
			return this;
		default:
			return null;
		}
	}
}
