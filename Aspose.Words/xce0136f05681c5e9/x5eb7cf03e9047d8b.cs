using System;
using Aspose.Words;
using x2697283ff424107e;
using x28925c9b27b37a46;
using x7c4557e104065fc9;

namespace xce0136f05681c5e9;

internal class x5eb7cf03e9047d8b
{
	private readonly xe2ff3c3cd396cfd9 x8e72ba7633bd501d;

	private Paragraph x7bc41579bb053885;

	private x4ef6b4f19b033b48 xff5ab9ce9225a10e;

	internal x4ef6b4f19b033b48 xd34a71082d00660c => xff5ab9ce9225a10e;

	internal x5eb7cf03e9047d8b(xe2ff3c3cd396cfd9 htmlWriter)
	{
		x8e72ba7633bd501d = htmlWriter;
	}

	internal void x4bf36104951aa017(Paragraph x41baca1d6c0c2e8e, x1a78664fa10a3755 x9e5248b49f0df7e8, bool x3c8d1bac4ee48d92)
	{
		if (xff5ab9ce9225a10e == x4ef6b4f19b033b48.x526d6c6f824cda87)
		{
			if (x04db34f4b75b79e0(x9e5248b49f0df7e8))
			{
				Paragraph paragraph = xfee61dcf032af05e(x41baca1d6c0c2e8e);
				if (x41baca1d6c0c2e8e != paragraph)
				{
					x7bc41579bb053885 = paragraph;
					xff5ab9ce9225a10e = x4ef6b4f19b033b48.x853425d3a03042f1;
					x8e72ba7633bd501d.xe1410f585439c7d4.x2307058321cdb62f("div");
					x8e72ba7633bd501d.xe1410f585439c7d4.xff520a0047c27122("style", x8882ada461baa09d(x41baca1d6c0c2e8e, x7bc41579bb053885, x3c8d1bac4ee48d92));
				}
			}
		}
		else
		{
			xff5ab9ce9225a10e = ((x41baca1d6c0c2e8e == x7bc41579bb053885) ? x4ef6b4f19b033b48.x89f4b67282edaf4a : x4ef6b4f19b033b48.x763219a89d453f55);
		}
	}

	internal void x7557112ace708bcd(Paragraph x41baca1d6c0c2e8e)
	{
		if (x41baca1d6c0c2e8e == x7bc41579bb053885)
		{
			x8e72ba7633bd501d.xe1410f585439c7d4.x538f0e0fb2bf15ab();
			xff5ab9ce9225a10e = x4ef6b4f19b033b48.x526d6c6f824cda87;
			x7bc41579bb053885 = null;
		}
	}

	private static string x8882ada461baa09d(Paragraph x6e379b9e2b4c4105, Paragraph x6136cc96924b0a93, bool x3c8d1bac4ee48d92)
	{
		ParagraphFormat paragraphFormat = x6e379b9e2b4c4105.ParagraphFormat;
		xa3fc7dcdc8182ff6 xa3fc7dcdc8182ff = new xa3fc7dcdc8182ff6();
		x30ff4cedcf2b2374.xa95bac7421a1a927(xa3fc7dcdc8182ff, paragraphFormat.Borders, x82fdb3b4231a1374: false);
		double num = paragraphFormat.LeftIndent - paragraphFormat.Borders.Left.DistanceFromText;
		double num2 = paragraphFormat.RightIndent - paragraphFormat.Borders.Right.DistanceFromText;
		if (paragraphFormat.Bidi)
		{
			double num3 = num2;
			num2 = num;
			num = num3;
		}
		if (!x3c8d1bac4ee48d92)
		{
			num = Math.Max(num, 0.0);
			num2 = Math.Max(num2, 0.0);
		}
		xa3fc7dcdc8182ff.xfd7a4669c14e659a("margin", paragraphFormat.SpaceBefore, num2, x6136cc96924b0a93.ParagraphFormat.SpaceAfter, num, x0ec035c4a2d07fb6.x560cf35c28bc5a84);
		return xa3fc7dcdc8182ff.x9a706f5d15bd6d95(xb39cf349cb3e0d91: false);
	}

	private static Paragraph xfee61dcf032af05e(Paragraph x31e6518f5e08db6c)
	{
		while (x31e6518f5e08db6c.x560c050862d2f9c7())
		{
			x31e6518f5e08db6c = (Paragraph)x31e6518f5e08db6c.xa6890a1cb2b8896e;
		}
		return x31e6518f5e08db6c;
	}

	private static bool x04db34f4b75b79e0(x1a78664fa10a3755 x9e5248b49f0df7e8)
	{
		if (!x9e5248b49f0df7e8.xa8c2637cc4888928.IsVisible && !x9e5248b49f0df7e8.xaea087ab32102492.IsVisible && !x9e5248b49f0df7e8.x79d902473861f242.IsVisible && !x9e5248b49f0df7e8.xd7a21e27974f626c.IsVisible)
		{
			return x9e5248b49f0df7e8.xa7c38e66f97ecee1.IsVisible;
		}
		return true;
	}
}
