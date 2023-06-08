using ns100;
using ns135;
using ns99;

namespace ns140;

internal abstract class Class4619 : Interface144
{
	private Interface138 interface138_0;

	internal Class4619(Interface138 painter)
	{
		interface138_0 = painter;
	}

	public void imethod_0(Interface113 font, int glyphIndex)
	{
		imethod_1(font, glyphIndex, new Class4509());
	}

	public void imethod_1(Interface113 font, int glyphIndex, Class4509 glyphPlacementMatrix)
	{
		imethod_3(font, new Class4508(glyphIndex), glyphPlacementMatrix);
	}

	public void imethod_2(Interface113 font, Class4506 glyphId)
	{
		imethod_3(font, glyphId, new Class4509());
	}

	public void imethod_3(Interface113 font, Class4506 glyphId, Class4509 glyphPlacementMatrix)
	{
		Class4509 @class = new Class4509();
		@class.A = glyphPlacementMatrix.A;
		@class.B = glyphPlacementMatrix.B;
		@class.C = glyphPlacementMatrix.C;
		@class.D = glyphPlacementMatrix.D;
		@class.TX = glyphPlacementMatrix.TX;
		@class.TY = glyphPlacementMatrix.TY;
		@class = ((font.FontType != Enum639.const_2) ? font.Metrics.FontMatrix.method_4(@class) : ((Class4466)font.Metrics).method_1(glyphId).method_4(@class));
		Class4480 class2 = smethod_0(font, glyphId, @class);
		if (class2 != null)
		{
			vmethod_0(@class, class2, interface138_0);
		}
	}

	private static Class4480 smethod_0(Interface113 font, Class4506 glyphId, Class4509 finalMatrix)
	{
		return font.imethod_0(glyphId);
	}

	internal abstract void vmethod_0(Class4509 final_matrix, Class4480 glyph, Interface138 glyphPainter);
}
