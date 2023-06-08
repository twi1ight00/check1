using System.Collections;
using System.Drawing;

namespace ns237;

internal class Class6532 : Class6511, Interface320
{
	private readonly Class6533 class6533_0;

	private readonly RectangleF rectangleF_0 = RectangleF.Empty;

	private readonly Class6546 class6546_0;

	internal Class6533 SigDictionary => class6533_0;

	internal Class6532(Class6672 context, RectangleF activeRect, Class6546 hostpage)
		: base(context)
	{
		rectangleF_0 = activeRect;
		class6533_0 = new Class6533(context);
		class6546_0 = hostpage;
	}

	void Interface320.imethod_0(Class6679 writer, IDictionary destinations, IDictionary pageDestinations)
	{
		vmethod_0(writer);
	}

	public override void vmethod_0(Class6679 writer)
	{
		writer.method_28(method_0());
		writer.method_29(this);
		writer.method_6();
		writer.method_8("/Type", "/Annot");
		writer.method_8("/Subtype", "/Widget");
		writer.method_8("/FT", "/Sig");
		writer.method_8("/DR", "<<>>");
		writer.method_18("/F", 132);
		writer.method_16("/Rect", rectangleF_0);
		writer.method_8("/V", class6533_0.IndirectReference);
		writer.method_8("/P", class6546_0.IndirectReference);
		writer.method_13("/T", "AsposeDigitalSignature");
		writer.method_7();
		writer.method_30();
		class6533_0.vmethod_0(writer);
	}
}
