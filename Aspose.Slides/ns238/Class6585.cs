using System.Drawing.Drawing2D;
using ns218;
using ns224;
using ns235;
using ns271;

namespace ns238;

internal class Class6585 : Class6568
{
	public Class6585(Class6567 context)
		: base(context)
	{
	}

	public void method_0(Class6219 glyphs, short characterId)
	{
		Class6584 @class = new Class6584(base.Context);
		@class.method_0();
		base.Writer.method_1(characterId);
		base.Writer.method_13(Class5955.smethod_29(glyphs.Bounds.Left), Class5955.smethod_29(glyphs.Bounds.Right), Class5955.smethod_29(glyphs.Bounds.Top), Class5955.smethod_29(glyphs.Bounds.Bottom));
		Class6002 class2 = new Class6002();
		class2.method_7(Class5955.smethod_29(glyphs.Origin.X), Class5955.smethod_29(glyphs.Origin.Y), MatrixOrder.Prepend);
		base.Writer.method_14(class2);
		Class6730 trueTypeFont = glyphs.Font.TrueTypeFont;
		Class6586 class3 = base.Context.method_4(trueTypeFont);
		int[] array = new int[glyphs.Text.Length];
		int[] array2 = new int[glyphs.Text.Length];
		for (int i = 0; i < glyphs.Text.Length; i++)
		{
			int num = class3.method_1(glyphs.Text[i]);
			array[i] = num;
			array2[i] = class3.method_4(glyphs.Text[i], glyphs.Font.SizePoints);
		}
		int num2 = Class6566.smethod_0(array);
		int num3 = Class6566.smethod_0(array2);
		base.Writer.WriteByte((byte)num2);
		base.Writer.WriteByte((byte)num3);
		base.Writer.method_6(1, 1, closeByte: false);
		base.Writer.method_6(0, 3, closeByte: false);
		base.Writer.method_6(1, 1, closeByte: false);
		base.Writer.method_6(1, 1, closeByte: false);
		base.Writer.method_6(0, 1, closeByte: false);
		base.Writer.method_6(0, 1, closeByte: false);
		base.Writer.method_1(base.Context.method_3(trueTypeFont));
		base.Writer.method_10(glyphs.Color);
		base.Writer.method_1((short)Class5955.smethod_29(glyphs.Font.SizePoints));
		base.Writer.WriteByte((byte)array.Length);
		for (int j = 0; j < array.Length; j++)
		{
			base.Writer.method_6(array[j], num2, closeByte: false);
			base.Writer.method_5(array2[j], num3, closeByte: false);
		}
		base.Writer.method_6(0, 8, closeByte: false);
		base.Writer.Flush();
		@class.method_1(Enum878.const_10);
	}
}
