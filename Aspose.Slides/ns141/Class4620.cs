using ns135;
using ns138;
using ns140;
using ns99;

namespace ns141;

internal class Class4620 : Class4619
{
	public Class4620(Interface139 painter)
		: base(painter)
	{
	}

	internal override void vmethod_0(Class4509 final_matrix, Class4480 glyph, Interface138 glyphPainter)
	{
		glyph.method_2(final_matrix);
		glyph.method_1(final_matrix.TX, final_matrix.TY);
		if (!(glyphPainter is Interface139 @interface))
		{
			return;
		}
		foreach (Interface143 segment in glyph.Path.Segments)
		{
			if (segment is Class4614 moveTo)
			{
				@interface.imethod_0(moveTo);
			}
			else if (segment is Class4613 lineTo)
			{
				@interface.imethod_1(lineTo);
			}
			else if (segment is Class4612 curveTo)
			{
				@interface.imethod_2(curveTo);
			}
			else if (segment is Class4611)
			{
				@interface.imethod_3();
			}
		}
	}
}
