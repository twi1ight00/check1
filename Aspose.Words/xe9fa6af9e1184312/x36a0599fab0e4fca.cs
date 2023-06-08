using System.Text;
using x1c8faa688b1f0b0c;

namespace xe9fa6af9e1184312;

internal class x36a0599fab0e4fca : xf51865b83a7a0b3b
{
	private readonly StringBuilder x08de3ae40531cc51 = new StringBuilder();

	internal static string xeb041f5f206e58f9(x4fdf549af9de6b97 xda5bf54deb817e37)
	{
		x36a0599fab0e4fca x36a0599fab0e4fca2 = new x36a0599fab0e4fca();
		xda5bf54deb817e37.Accept(x36a0599fab0e4fca2);
		return x36a0599fab0e4fca2.x08de3ae40531cc51.ToString();
	}

	public override void VisitGlyphs(xcc8c7739d82c63ba glyphs)
	{
		x08de3ae40531cc51.Append(glyphs.Text);
	}
}
