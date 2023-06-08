using System.Collections;
using System.Drawing;
using ns265;

namespace ns237;

internal class Class6539 : Class6511, Interface320
{
	private readonly RectangleF rectangleF_0 = RectangleF.Empty;

	private readonly Class6504 class6504_0;

	internal Class6539(Class6672 context, RectangleF activeRect, Class6504 action)
		: base(context)
	{
		rectangleF_0 = activeRect;
		class6504_0 = action;
	}

	public override void vmethod_0(Class6679 writer)
	{
		writer.method_29(this);
		writer.method_6();
		writer.method_8("/Type", "/Annot");
		writer.method_8("/Subtype", "/Link");
		if (class6672_0.PdfaCompliant)
		{
			writer.method_18("/F", 28);
		}
		writer.method_16("/Rect", rectangleF_0);
		if (!class6672_0.Options.IsShowHyperlinkRects)
		{
			writer.method_8("/BS", "<</Type/Border/S/S/W 0>>");
		}
		if (class6504_0 != null)
		{
			class6504_0.vmethod_0(writer);
		}
		writer.method_7();
		writer.method_30();
	}

	void Interface320.imethod_0(Class6679 writer, IDictionary destinations, IDictionary pageDestinations)
	{
		if (class6504_0 != null)
		{
			(class6504_0 as Class6507)?.vmethod_1(pageDestinations);
			(class6504_0 as Class6506)?.vmethod_1(destinations);
		}
		vmethod_0(writer);
	}
}
