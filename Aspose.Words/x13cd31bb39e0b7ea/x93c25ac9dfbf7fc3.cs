using System;
using Aspose.Words;
using x28925c9b27b37a46;
using x6c95d9cf46ff5f25;

namespace x13cd31bb39e0b7ea;

internal class x93c25ac9dfbf7fc3 : DocumentVisitor
{
	private const int xa93fc3834a596fff = 12;

	private int x63ded15001b5aaaf = 12;

	private int x9d719275331d41d1;

	public override VisitorAction VisitDocumentStart(Document doc)
	{
		Style style = doc.Styles.xf21e14e2c9db279a(StyleIdentifier.Normal, x988fcf605f8efa7e: true);
		int num = (style.xeedad81aaed42a76.x263d579af1d0d43f(190) ? style.xeedad81aaed42a76.x437e3b626c0fdd43 : ((!style.xeedad81aaed42a76.x263d579af1d0d43f(350)) ? ((int)xeedad81aaed42a76.x0095b789d636f3ae(190)) : style.xeedad81aaed42a76.xa7229a54449aaf49));
		x9d719275331d41d1 = x4574ea26106f0edb.x88bf16f2386d633e(num) / 2;
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitSectionStart(Section section)
	{
		x704ea28be0f90278 xdc363bd6e5544a = section.xfc72d4c9b765cad7.xdc363bd6e5544a03;
		x63ded15001b5aaaf = ((xdc363bd6e5544a == x704ea28be0f90278.xb9715d2f06b63cf0) ? x4574ea26106f0edb.x88bf16f2386d633e(12.0) : section.xfc72d4c9b765cad7.x33678aed4fb5e764);
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitParagraphStart(Paragraph para)
	{
		x94b9d0ec2b45a160(para.x1a78664fa10a3755, 1205, 1200, x63ded15001b5aaaf);
		x94b9d0ec2b45a160(para.x1a78664fa10a3755, 1225, 1220, x63ded15001b5aaaf);
		x94b9d0ec2b45a160(para.x1a78664fa10a3755, 1175, 1170, x9d719275331d41d1);
		x94b9d0ec2b45a160(para.x1a78664fa10a3755, 1155, 1150, x9d719275331d41d1);
		x1bf5ea0a6e4f72cf(para.x1a78664fa10a3755);
		return VisitorAction.Continue;
	}

	private static void x94b9d0ec2b45a160(x1a78664fa10a3755 x062aae8c9613eeaa, int xdbecc04c31819c87, int x22f46c13fcb6b3b3, int xc2a0c3e573b44b5b)
	{
		int num = (int)x062aae8c9613eeaa.xfe91eeeafcb3026a(xdbecc04c31819c87);
		if (num != 0)
		{
			int num2 = (int)Math.Round((double)num / 100.0 * (double)xc2a0c3e573b44b5b);
			x062aae8c9613eeaa.xae20093bed1e48a8(x22f46c13fcb6b3b3, num2);
		}
	}

	private void x1bf5ea0a6e4f72cf(x1a78664fa10a3755 x062aae8c9613eeaa)
	{
		int num = (int)x062aae8c9613eeaa.xfe91eeeafcb3026a(1165);
		if (num != 0)
		{
			int num2 = (int)Math.Round((double)num / 100.0 * (double)x9d719275331d41d1);
			if (x062aae8c9613eeaa.xc7d7e186f0ace1e0 < 0)
			{
				num2 += -x062aae8c9613eeaa.xc7d7e186f0ace1e0;
			}
			x062aae8c9613eeaa.xae20093bed1e48a8(1160, num2);
		}
	}
}
