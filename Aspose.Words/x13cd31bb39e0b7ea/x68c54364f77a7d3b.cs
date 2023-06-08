using System.Collections;
using Aspose.Words;
using Aspose.Words.Drawing;
using Aspose.Words.Lists;
using x011d489fb9df7027;
using x28925c9b27b37a46;
using x38d3ef1c1d247e82;
using x6c95d9cf46ff5f25;

namespace x13cd31bb39e0b7ea;

internal class x68c54364f77a7d3b
{
	private readonly x8556eed81191af11 xb36c250515e408ad;

	private readonly ArrayList x520423a112cac65c = new ArrayList();

	private readonly ArrayList x8cde65cae117f25f = new ArrayList();

	private readonly Hashtable x95e648c2fdfa3e1c = new Hashtable();

	private readonly x94c83b1ca7961561 x972933743147c995 = new x94c83b1ca7961561();

	internal x68c54364f77a7d3b(x8556eed81191af11 saveInfo)
	{
		xb36c250515e408ad = saveInfo;
		ListCollection lists = saveInfo.x2c8c6741422a1298.Lists;
		for (int i = 0; i < lists.xe10f375b4290d48f; i++)
		{
			Shape x5770cdefd8931aa = lists.x4916e8670feefe58(i);
			xfdd6c9bd3eff16bf(x5770cdefd8931aa, xe7d7afd9c3c7235a: false);
		}
	}

	internal void xa0dfc102c691b11f()
	{
		int num = 1025;
		if (xb36c250515e408ad.x2c8c6741422a1298.BackgroundShape != null)
		{
			xb36c250515e408ad.x2c8c6741422a1298.BackgroundShape.xea1e81378298fa81 = num++;
		}
		foreach (ShapeBase item in x520423a112cac65c)
		{
			x17047098d616a1cd(item, num++);
		}
		int num2 = x0d299f323d241756.x8b2ecf3d830a9342(num, 1024);
		num = num2 + 1;
		foreach (ShapeBase item2 in x8cde65cae117f25f)
		{
			x17047098d616a1cd(item2, num++);
		}
		foreach (xa1e2a8ed32a026dd item3 in xb36c250515e408ad.x2c8c6741422a1298.x245aa7750b4a8072)
		{
			foreach (ShapeBase childNode in item3.GetChildNodes(NodeType.Shape, isDeep: true))
			{
				x17047098d616a1cd(childNode, num++);
			}
		}
		x3cb314c1e14d1c6f();
	}

	internal void xfdd6c9bd3eff16bf(ShapeBase x5770cdefd8931aa9, bool xe7d7afd9c3c7235a)
	{
		if (xe7d7afd9c3c7235a)
		{
			x8cde65cae117f25f.Add(x5770cdefd8931aa9);
		}
		else
		{
			x520423a112cac65c.Add(x5770cdefd8931aa9);
		}
		if (!x5770cdefd8931aa9.xa170cce2bc40bdf5)
		{
			return;
		}
		xd142dcacd7ddc9dd x58932c7e6fa3b = ((Shape)x5770cdefd8931aa9).OleFormat.x58932c7e6fa3b905;
		if (x58932c7e6fa3b != null)
		{
			while (x972933743147c995.x263d579af1d0d43f(x58932c7e6fa3b.xea1e81378298fa81))
			{
				x58932c7e6fa3b.xea1e81378298fa81++;
			}
			x972933743147c995.xd6b6ed77479ef68c(x58932c7e6fa3b.xea1e81378298fa81);
		}
	}

	private void x3cb314c1e14d1c6f()
	{
		foreach (ShapeBase value in x95e648c2fdfa3e1c.Values)
		{
			int xdf3d5f8941ea27a = value.xdf3d5f8941ea27a6;
			value.xf26165853f0b9b77(138);
			if (xdf3d5f8941ea27a != 0)
			{
				ShapeBase shapeBase2 = (ShapeBase)x95e648c2fdfa3e1c[xdf3d5f8941ea27a];
				if (shapeBase2 != null)
				{
					value.xdf3d5f8941ea27a6 = shapeBase2.xea1e81378298fa81;
					xb36c250515e408ad.xa2c21fc178d67af8.xd6b6ed77479ef68c(value.xea1e81378298fa81);
					xb36c250515e408ad.xa2c21fc178d67af8.xd6b6ed77479ef68c(shapeBase2.xea1e81378298fa81);
				}
			}
		}
	}

	private void x17047098d616a1cd(ShapeBase x5770cdefd8931aa9, int xeaf1b27180c0557b)
	{
		x5770cdefd8931aa9.xf26165853f0b9b77(128);
		if (x5770cdefd8931aa9.xea1e81378298fa81 == x5770cdefd8931aa9.xdf3d5f8941ea27a6)
		{
			x5770cdefd8931aa9.xf26165853f0b9b77(138);
		}
		if (!x5770cdefd8931aa9.IsInline && x95e648c2fdfa3e1c[x5770cdefd8931aa9.xea1e81378298fa81] == null)
		{
			x95e648c2fdfa3e1c[x5770cdefd8931aa9.xea1e81378298fa81] = x5770cdefd8931aa9;
		}
		x5770cdefd8931aa9.xea1e81378298fa81 = xeaf1b27180c0557b;
		xb36c250515e408ad.xe42bd130f1e95570[xeaf1b27180c0557b] = x5770cdefd8931aa9;
	}
}
