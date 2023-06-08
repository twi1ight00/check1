using System;
using Aspose.Words.Saving;
using Aspose.Words.Tables;
using x28925c9b27b37a46;
using x6c95d9cf46ff5f25;
using x9db5f2e5af3d596e;
using xda075892eccab2ad;
using xf9a9481c3f63a419;

namespace x1a3e96f4b89a7a77;

internal class x31b31073210f038b
{
	private x31b31073210f038b()
	{
	}

	internal static void x6210059f049f0d48(xedb0eb766e25e0c9 xe9707cb1ec88db49, bool x97b4bbf66b3d8bc6, bool x37f701492043cfc5, xfe11bbc13ba649c3 x0f7b23d1c393aed9)
	{
		x6210059f049f0d48(xe9707cb1ec88db49, x97b4bbf66b3d8bc6, x37f701492043cfc5, x0f7b23d1c393aed9, OoxmlCompliance.Ecma376_2006);
	}

	internal static void x6210059f049f0d48(xedb0eb766e25e0c9 xe9707cb1ec88db49, bool x97b4bbf66b3d8bc6, bool x37f701492043cfc5, xfe11bbc13ba649c3 x0f7b23d1c393aed9, OoxmlCompliance xe6e5b1285a089d05)
	{
		if (xe9707cb1ec88db49 == null)
		{
			return;
		}
		x873451caae5ad4ae xe1410f585439c7d = x0f7b23d1c393aed9.xe1410f585439c7d4;
		x51364ccbfdb889a8 x51364ccbfdb889a9 = new x51364ccbfdb889a8(x47db130a4b1dae4c(xe9707cb1ec88db49), x37f701492043cfc5, x0f7b23d1c393aed9);
		xedb0eb766e25e0c9 xedb0eb766e25e0c = x0017fa7716eb722e(xe9707cb1ec88db49);
		if (xedb0eb766e25e0c != null && x51364ccbfdb889a9.x292ab95da92a6344 != null && (bool)x51364ccbfdb889a9.x292ab95da92a6344)
		{
			xedb0eb766e25e0c.x292ab95da92a6344 = true;
		}
		if (x97b4bbf66b3d8bc6)
		{
			xa9996397cffe9759(x51364ccbfdb889a9, xedb0eb766e25e0c, xe1410f585439c7d, x37f701492043cfc5, x0f7b23d1c393aed9, xe6e5b1285a089d05, x2a3d16971f522a0b: true);
			return;
		}
		if (x51364ccbfdb889a9.x325f1926b78ae5cd)
		{
			xe1410f585439c7d.x943f6be3acf634db("w:rsidR", x51364ccbfdb889a9.x4a02d6e0c76b8da8);
			xe1410f585439c7d.x943f6be3acf634db("w:rsidTr", x51364ccbfdb889a9.x95a824575f7410c3);
		}
		xc55be7f1f21cdaa1(x51364ccbfdb889a9, xedb0eb766e25e0c, xe1410f585439c7d, x37f701492043cfc5, x0f7b23d1c393aed9, xe6e5b1285a089d05, x2a3d16971f522a0b: true);
		x061c773cd5e4ed7e(x51364ccbfdb889a9, xedb0eb766e25e0c, xe1410f585439c7d, x37f701492043cfc5, x0f7b23d1c393aed9, xe6e5b1285a089d05, x2a3d16971f522a0b: true);
	}

	private static xedb0eb766e25e0c9 x47db130a4b1dae4c(xedb0eb766e25e0c9 xe9707cb1ec88db49)
	{
		xedb0eb766e25e0c9 xedb0eb766e25e0c = (xedb0eb766e25e0c9)xe9707cb1ec88db49.x8b61531c8ea35b85();
		xedb0eb766e25e0c.xcb395027497bc067();
		return xedb0eb766e25e0c;
	}

	private static xedb0eb766e25e0c9 x0017fa7716eb722e(xedb0eb766e25e0c9 xe9707cb1ec88db49)
	{
		if (xe9707cb1ec88db49.x0f53f53f15b61ef5)
		{
			x7f77ea92be0d9042 x7f77ea92be0d = (x7f77ea92be0d9042)xe9707cb1ec88db49.x8b61531c8ea35b85();
			x7f77ea92be0d9042 x7f77ea92be0d2 = x47db130a4b1dae4c(xe9707cb1ec88db49);
			for (int i = 0; i < x7f77ea92be0d2.xd44988f225497f3a; i++)
			{
				int xba08ce632055a1d = x7f77ea92be0d2.xf15263674eb297bb(i);
				if (((x09ce2c02826e31a6)x7f77ea92be0d).get_xe6d4b1b411ed94b5(xba08ce632055a1d) == ((x09ce2c02826e31a6)x7f77ea92be0d2).get_xe6d4b1b411ed94b5(xba08ce632055a1d))
				{
					x7f77ea92be0d.x52b190e626f65140(xba08ce632055a1d);
				}
			}
			x7f77ea92be0d.x52b190e626f65140(10010);
			if (x7f77ea92be0d.xd44988f225497f3a > 0)
			{
				x7f77ea92be0d.x5fb16e270c21db2e = xe9707cb1ec88db49.x5fb16e270c21db2e;
				return (xedb0eb766e25e0c9)x7f77ea92be0d;
			}
		}
		else if (xe9707cb1ec88db49.x0392c0938d22c790 || xe9707cb1ec88db49.xba4e1d8a3e3316c8)
		{
			return xe9707cb1ec88db49;
		}
		return null;
	}

	private static void xa9996397cffe9759(x51364ccbfdb889a8 x6fb410977fc72292, xedb0eb766e25e0c9 x1d7b2bcf97b5b5f6, x873451caae5ad4ae xd07ce4b74c5774a7, bool x37f701492043cfc5, xfe11bbc13ba649c3 x0f7b23d1c393aed9, OoxmlCompliance xe6e5b1285a089d05, bool x2a3d16971f522a0b)
	{
		if (x2a3d16971f522a0b)
		{
			xd07ce4b74c5774a7.x2307058321cdb62f("w:tblPr");
		}
		xf36e6c2240ea983f(x6fb410977fc72292, xd07ce4b74c5774a7, xe6e5b1285a089d05);
		if (x6fb410977fc72292.xf68b6aed44939b9a > 0)
		{
			x4858abfe7d832ad8(x6fb410977fc72292, xd07ce4b74c5774a7, x37f701492043cfc5);
		}
		x8b9dde54e020eef0("w:tblPrChange", x1d7b2bcf97b5b5f6, xd07ce4b74c5774a7, x37f701492043cfc5, x0f7b23d1c393aed9, xe6e5b1285a089d05, x0f7b23d1c393aed9.x325f1926b78ae5cd);
		if (x2a3d16971f522a0b)
		{
			xd07ce4b74c5774a7.x2dfde153f4ef96d0();
		}
	}

	private static void x061c773cd5e4ed7e(x51364ccbfdb889a8 x6fb410977fc72292, xedb0eb766e25e0c9 x1d7b2bcf97b5b5f6, x873451caae5ad4ae xd07ce4b74c5774a7, bool x37f701492043cfc5, xfe11bbc13ba649c3 x0f7b23d1c393aed9, OoxmlCompliance xe6e5b1285a089d05, bool x2a3d16971f522a0b)
	{
		if (x6fb410977fc72292.xe404f0479f85cd43 <= 0 && (x1d7b2bcf97b5b5f6 == null || (!x1d7b2bcf97b5b5f6.x0392c0938d22c790 && !x1d7b2bcf97b5b5f6.xba4e1d8a3e3316c8)))
		{
			return;
		}
		if (x2a3d16971f522a0b)
		{
			xd07ce4b74c5774a7.x2307058321cdb62f("w:trPr");
		}
		if (x6fb410977fc72292.x71e5b802707a5021 != 0)
		{
			xd07ce4b74c5774a7.x547195bcc386fe66("w:gridBefore", xca004f56614e2431.x754c3a5f03a2ce84(x6fb410977fc72292.x71e5b802707a5021));
		}
		if (x6fb410977fc72292.x7390fcf53e1bd984 > 0)
		{
			xd07ce4b74c5774a7.x547195bcc386fe66("w:gridAfter", xca004f56614e2431.x754c3a5f03a2ce84(x6fb410977fc72292.x7390fcf53e1bd984));
		}
		if (x6fb410977fc72292.x90aab2cbd2f48623 > 0)
		{
			xd07ce4b74c5774a7.xcdbc678d36159c69("w:wBefore", xca004f56614e2431.x754c3a5f03a2ce84(x6fb410977fc72292.x90aab2cbd2f48623));
		}
		if (x6fb410977fc72292.xd29e69906712391d > 0)
		{
			xd07ce4b74c5774a7.xcdbc678d36159c69("w:wAfter", xca004f56614e2431.x754c3a5f03a2ce84(x6fb410977fc72292.xd29e69906712391d));
		}
		if (x6fb410977fc72292.x96e55b5d052d1279)
		{
			xd07ce4b74c5774a7.xf68f9c3818e1f4b1("w:hidden");
		}
		if (!x6fb410977fc72292.x59255fe095c130d7)
		{
			xd07ce4b74c5774a7.xf68f9c3818e1f4b1("w:cantSplit");
		}
		xd07ce4b74c5774a7.xc049ea80ee267201("w:trHeight", x6fb410977fc72292.x325f1926b78ae5cd ? "w:hRule" : "w:h-rule", x6fb410977fc72292.x8663ce8a3c4af300, "w:val", x6fb410977fc72292.x36845bc9dc2cf9c6);
		if (x6fb410977fc72292.x17caeb7723171c51)
		{
			xd07ce4b74c5774a7.xf68f9c3818e1f4b1("w:tblHeader");
		}
		xd07ce4b74c5774a7.xcdbc678d36159c69("w:tblCellSpacing", x6fb410977fc72292.x5e90d05988677502);
		xd07ce4b74c5774a7.x547195bcc386fe66("w:jc", x6fb410977fc72292.xdb7d175cb29503bf);
		x8b9dde54e020eef0("w:trPrChange", x1d7b2bcf97b5b5f6, xd07ce4b74c5774a7, x37f701492043cfc5, x0f7b23d1c393aed9, xe6e5b1285a089d05, x0f7b23d1c393aed9.x325f1926b78ae5cd);
		if (x1d7b2bcf97b5b5f6 != null)
		{
			if (x1d7b2bcf97b5b5f6.x0392c0938d22c790)
			{
				xd07ce4b74c5774a7.xd0c5f01ab55153ce(x1d7b2bcf97b5b5f6.x83da691dd3d974a6, x0f7b23d1c393aed9.x28ee4b8b8f777b55());
				xd07ce4b74c5774a7.x44d8d13f25d44840();
			}
			if (x1d7b2bcf97b5b5f6.xba4e1d8a3e3316c8)
			{
				xd07ce4b74c5774a7.xd0c5f01ab55153ce(x1d7b2bcf97b5b5f6.x18bb4aa7903ffced, x0f7b23d1c393aed9.x28ee4b8b8f777b55());
				xd07ce4b74c5774a7.x44d8d13f25d44840();
			}
		}
		if (x2a3d16971f522a0b)
		{
			xd07ce4b74c5774a7.x2dfde153f4ef96d0();
		}
	}

	private static void xc55be7f1f21cdaa1(x51364ccbfdb889a8 x6fb410977fc72292, xedb0eb766e25e0c9 x1d7b2bcf97b5b5f6, x873451caae5ad4ae xd07ce4b74c5774a7, bool x37f701492043cfc5, xfe11bbc13ba649c3 x0f7b23d1c393aed9, OoxmlCompliance xe6e5b1285a089d05, bool x2a3d16971f522a0b)
	{
		if (x6fb410977fc72292.xf68b6aed44939b9a > 0)
		{
			if (x2a3d16971f522a0b)
			{
				xd07ce4b74c5774a7.x2307058321cdb62f("w:tblPrEx");
			}
			x4858abfe7d832ad8(x6fb410977fc72292, xd07ce4b74c5774a7, x37f701492043cfc5);
			x8b9dde54e020eef0("w:tblPrExChange", x1d7b2bcf97b5b5f6, xd07ce4b74c5774a7, x37f701492043cfc5, x0f7b23d1c393aed9, xe6e5b1285a089d05, x0f7b23d1c393aed9.x325f1926b78ae5cd);
			if (x2a3d16971f522a0b)
			{
				xd07ce4b74c5774a7.x2dfde153f4ef96d0();
			}
		}
	}

	private static void x8b9dde54e020eef0(string x91ef5ae2997ab6c4, xedb0eb766e25e0c9 x1d7b2bcf97b5b5f6, x873451caae5ad4ae xd07ce4b74c5774a7, bool x37f701492043cfc5, xfe11bbc13ba649c3 x0f7b23d1c393aed9, OoxmlCompliance xe6e5b1285a089d05, bool x2a3d16971f522a0b)
	{
		if (x1d7b2bcf97b5b5f6 == null || !x1d7b2bcf97b5b5f6.x0f53f53f15b61ef5)
		{
			return;
		}
		x51364ccbfdb889a8 x51364ccbfdb889a9 = new x51364ccbfdb889a8(x1d7b2bcf97b5b5f6, x37f701492043cfc5, x0f7b23d1c393aed9);
		switch (x91ef5ae2997ab6c4)
		{
		case "w:tblPrChange":
			if (x51364ccbfdb889a9.xf68b6aed44939b9a > 0)
			{
				xd07ce4b74c5774a7.xd0c5f01ab55153ce(x1d7b2bcf97b5b5f6.x5fb16e270c21db2e, x91ef5ae2997ab6c4, x0f7b23d1c393aed9.x28ee4b8b8f777b55());
				xa9996397cffe9759(x51364ccbfdb889a9, null, xd07ce4b74c5774a7, x37f701492043cfc5, x0f7b23d1c393aed9, xe6e5b1285a089d05, x2a3d16971f522a0b);
				xd07ce4b74c5774a7.x44d8d13f25d44840();
			}
			break;
		case "w:tblPrExChange":
			if (x51364ccbfdb889a9.xf68b6aed44939b9a > 0)
			{
				xd07ce4b74c5774a7.xd0c5f01ab55153ce(x1d7b2bcf97b5b5f6.x5fb16e270c21db2e, x91ef5ae2997ab6c4, x0f7b23d1c393aed9.x28ee4b8b8f777b55());
				xc55be7f1f21cdaa1(x51364ccbfdb889a9, null, xd07ce4b74c5774a7, x37f701492043cfc5, x0f7b23d1c393aed9, xe6e5b1285a089d05, x2a3d16971f522a0b);
				xd07ce4b74c5774a7.x44d8d13f25d44840();
			}
			break;
		case "w:trPrChange":
			if (x51364ccbfdb889a9.xe404f0479f85cd43 > 0)
			{
				xd07ce4b74c5774a7.xd0c5f01ab55153ce(x1d7b2bcf97b5b5f6.x5fb16e270c21db2e, x91ef5ae2997ab6c4, x0f7b23d1c393aed9.x28ee4b8b8f777b55());
				x061c773cd5e4ed7e(x51364ccbfdb889a9, null, xd07ce4b74c5774a7, x37f701492043cfc5, x0f7b23d1c393aed9, xe6e5b1285a089d05, x2a3d16971f522a0b);
				xd07ce4b74c5774a7.x44d8d13f25d44840();
			}
			break;
		default:
			throw new ArgumentException("Unexpected tag name.");
		}
	}

	private static void xf36e6c2240ea983f(x51364ccbfdb889a8 x6fb410977fc72292, x873451caae5ad4ae xd07ce4b74c5774a7, OoxmlCompliance xe6e5b1285a089d05)
	{
		xd07ce4b74c5774a7.x547195bcc386fe66("w:tblStyle", x6fb410977fc72292.x1bd44401d685915c);
		xd07ce4b74c5774a7.x547195bcc386fe66("w:tblStyleRowBandSize", x6fb410977fc72292.x56cde9dc3f6c8838);
		xd07ce4b74c5774a7.x547195bcc386fe66("w:tblStyleColBandSize", x6fb410977fc72292.xd0f3d9065ec530b6);
		if (x6fb410977fc72292.x325f1926b78ae5cd && xe6e5b1285a089d05 != 0)
		{
			xd07ce4b74c5774a7.x547195bcc386fe66("w:tblCaption", x6fb410977fc72292.xcef3e13053354501);
			xd07ce4b74c5774a7.x547195bcc386fe66("w:tblDescription", x6fb410977fc72292.x16ee896df46bcefa);
		}
		xd07ce4b74c5774a7.xc049ea80ee267201("w:tblpPr", "w:leftFromText", x6fb410977fc72292.x26095d7564fc96e5, "w:rightFromText", x6fb410977fc72292.xad88d3dd46749878, "w:topFromText", x6fb410977fc72292.xd386d6e78a8f86bb, "w:bottomFromText", x6fb410977fc72292.xfe68f6bb38fb6f71, "w:vertAnchor", x6fb410977fc72292.xf8e05ede78514093, "w:horzAnchor", x6fb410977fc72292.x094bb50702ffc46a, "w:tblpXSpec", x6fb410977fc72292.xb27a93f6225b838b, "w:tblpX", x6fb410977fc72292.xb99af2eea9de631f, "w:tblpYSpec", x6fb410977fc72292.x56f7e07d3eb9e917, "w:tblpY", x6fb410977fc72292.x8e6813d1269b38e0);
		if (!x6fb410977fc72292.x297c4b9799408e4a)
		{
			xd07ce4b74c5774a7.x547195bcc386fe66("w:tblOverlap", x6fb410977fc72292.x325f1926b78ae5cd ? "never" : "Never");
		}
		if (x6fb410977fc72292.xe68c5a6af2ad99fe)
		{
			xd07ce4b74c5774a7.xf68f9c3818e1f4b1("w:bidiVisual");
		}
	}

	private static void x4858abfe7d832ad8(x51364ccbfdb889a8 x6fb410977fc72292, x873451caae5ad4ae xd07ce4b74c5774a7, bool x37f701492043cfc5)
	{
		xd07ce4b74c5774a7.xcdbc678d36159c69("w:tblW", x6fb410977fc72292.xa655e905c2c23d43);
		xd07ce4b74c5774a7.x547195bcc386fe66("w:jc", x6fb410977fc72292.xdb7d175cb29503bf);
		xd07ce4b74c5774a7.xcdbc678d36159c69("w:tblCellSpacing", x6fb410977fc72292.x5e90d05988677502);
		xd07ce4b74c5774a7.xcdbc678d36159c69("w:tblInd", x6fb410977fc72292.x3ee36906f79c4fae);
		xd07ce4b74c5774a7.xa653462abd146df5("w:tblBorders", "w:top", x6fb410977fc72292.x6188bb17d3fa6122, "w:left", x6fb410977fc72292.xcb0c5e0ca87ddd7c, "w:bottom", x6fb410977fc72292.xadf6945de3f17a6a, "w:right", x6fb410977fc72292.x120beac34b17159b, "w:insideH", x6fb410977fc72292.x6d77c656b879ca53, "w:insideV", x6fb410977fc72292.x3aec10d81a685e0b);
		xd07ce4b74c5774a7.xbcea76c28b5e9461(x6fb410977fc72292.xbc9c2127d2bbf18f);
		if (!x37f701492043cfc5 && !(bool)x6fb410977fc72292.x292ab95da92a6344)
		{
			xd07ce4b74c5774a7.xc049ea80ee267201("w:tblLayout", "w:type", x6fb410977fc72292.x325f1926b78ae5cd ? "fixed" : "Fixed");
		}
		xd07ce4b74c5774a7.x99a8871fc05f6874("w:tblCellMar", x6fb410977fc72292.x60e3d97b97bb8c4b, x6fb410977fc72292.xc790aa4ad151a9a1, x6fb410977fc72292.xbec4ce2ebab55739, x6fb410977fc72292.x9d14ae04d4852341);
		if (!x6fb410977fc72292.x325f1926b78ae5cd && !x37f701492043cfc5)
		{
			if (x6fb410977fc72292.x79a6be1d1f13a42b == null)
			{
				xd07ce4b74c5774a7.x547195bcc386fe66("w:tblLook", xca004f56614e2431.x7c1a0f9da8274fe8(x4cf3b47199c96529.x48bdf8f97244c548(TableStyleOptions.Default)));
			}
			else if (x6fb410977fc72292.x79a6be1d1f13a42b != xca004f56614e2431.x7c1a0f9da8274fe8(x4cf3b47199c96529.x48bdf8f97244c548(TableStyleOptions.Default2003)))
			{
				xd07ce4b74c5774a7.x547195bcc386fe66("w:tblLook", x6fb410977fc72292.x79a6be1d1f13a42b);
			}
		}
		else
		{
			xd07ce4b74c5774a7.x547195bcc386fe66("w:tblLook", x6fb410977fc72292.x79a6be1d1f13a42b);
		}
	}
}
