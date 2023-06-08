using System.Drawing;
using ns224;
using ns243;
using ns244;

namespace ns242;

internal class Class6240
{
	protected Class5999 class5999_0;

	protected Class5998 class5998_0;

	protected Class6239 class6239_0;

	public Class6240(Class5999 font, Class5998 color, Class6239 creator)
	{
		class5999_0 = font;
		class5998_0 = color;
		class6239_0 = creator;
	}

	public virtual Class6235[] vmethod_0(string text, Class6227 parent)
	{
		return class6239_0.TextComposer.vmethod_1(text, parent.vmethod_0().Width, class5998_0, class5999_0);
	}

	public virtual Class6228 CreateParagraph(Struct220 margin, float lineSpace, Class6227 parent)
	{
		return new Class6228(parent.vmethod_0().Width, margin, lineSpace, class6239_0);
	}

	public virtual Class6234 vmethod_1(Image image, Struct220 margin, Class6227 parent)
	{
		return new Class6234(image, margin);
	}

	public virtual Class6229 vmethod_2(int columnCount, Struct220 margin, Class6227 parent)
	{
		return new Class6229(parent.vmethod_0().Width, margin, columnCount, class6239_0);
	}

	public virtual Class6232 vmethod_3(int cellCount, Class6227 parent)
	{
		return new Class6232(parent.vmethod_0().Width, Struct220.Zero, cellCount, class6239_0);
	}

	public virtual Class6231 vmethod_4(Class6232 parent)
	{
		return new Class6231(parent.vmethod_0().Width / (float)parent.CellCount, Struct220.Zero, class6239_0);
	}

	public virtual Class6233 vmethod_5(SizeF size, Struct220 margin)
	{
		return new Class6233(size, margin, class6239_0);
	}

	public virtual Class6230 vmethod_6(Struct220 margin, Class6227 parent)
	{
		return new Class6230(parent.vmethod_0().Width, margin, class6239_0);
	}

	public virtual Class6234 vmethod_7(Image image, Struct220 margin)
	{
		return new Class6234(image, margin);
	}

	public virtual Class6237 vmethod_8()
	{
		return new Class6237();
	}

	public void method_0(Class5998 fgColor)
	{
		class5998_0 = fgColor;
	}

	public void method_1(Class5999 font)
	{
		class5999_0 = font;
	}
}
