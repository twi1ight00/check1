using System.Drawing;

namespace ns301;

internal sealed class Class6971
{
	private class Class6972
	{
		internal static readonly Class6971 class6971_0 = new Class6971();
	}

	private const string string_0 = "QWERTYUIOPASDFGHJKLZXCVBNM ";

	private readonly Bitmap bitmap_0;

	public static Class6971 Instance => Class6972.class6971_0;

	private Class6971()
	{
		bitmap_0 = new Bitmap(1, 1);
	}

	public SizeF method_0(string word, string fontFamily, float fontSize, FontStyle style)
	{
		Class6892.smethod_1(word, "word");
		Class6892.smethod_1(fontFamily, "fontFamily");
		using Graphics graphics = Graphics.FromImage(bitmap_0);
		using Font font = new Font(fontFamily, fontSize, style);
		SizeF sizeF = graphics.MeasureString(word, font);
		if (!Class6973.smethod_0(word.Trim()))
		{
			sizeF = smethod_0(graphics, word, font);
		}
		float width = Class6969.smethod_6(sizeF.Width);
		float height = Class6969.smethod_6(sizeF.Height);
		return new SizeF(width, height);
	}

	public SizeF method_1(string familyName, float fontSize, FontStyle fontStyle)
	{
		Class6892.smethod_1(familyName, "familyName");
		SizeF sizeF;
		using (Graphics graphics = Graphics.FromImage(bitmap_0))
		{
			using Font font = new Font(familyName, fontSize, fontStyle);
			sizeF = graphics.MeasureString("QWERTYUIOPASDFGHJKLZXCVBNM ", font);
		}
		float width = Class6969.smethod_6(sizeF.Width / (float)"QWERTYUIOPASDFGHJKLZXCVBNM ".Length);
		float height = Class6969.smethod_6(sizeF.Height);
		return new SizeF(width, height);
	}

	private static SizeF smethod_0(Graphics graphics, string text, Font font)
	{
		StringFormat stringFormat = new StringFormat(StringFormat.GenericTypographic);
		RectangleF layoutRect = new RectangleF(0f, 0f, 1000f, 1000f);
		CharacterRange[] measurableCharacterRanges = new CharacterRange[1]
		{
			new CharacterRange(0, text.Length)
		};
		stringFormat.SetMeasurableCharacterRanges(measurableCharacterRanges);
		Region[] array = graphics.MeasureCharacterRanges(text, font, layoutRect, stringFormat);
		RectangleF bounds = array[0].GetBounds(graphics);
		float x = bounds.X;
		float width = bounds.Width;
		return new SizeF(width - x, bounds.Height - bounds.Y);
	}

	public static float smethod_1(string fontFamilyName, float fontSize, FontStyle fontStyle)
	{
		using Font font = new Font(fontFamilyName, fontSize, fontStyle);
		float num = font.FontFamily.GetEmHeight(font.Style);
		float num2 = font.SizeInPoints / num;
		return (float)font.FontFamily.GetCellAscent(font.Style) * num2;
	}

	public static float smethod_2(string fontFamilyName, float fontSize, FontStyle fontStyle)
	{
		using Font font = new Font(fontFamilyName, fontSize, fontStyle);
		float num = font.FontFamily.GetEmHeight(font.Style);
		float num2 = font.SizeInPoints / num;
		return (float)font.FontFamily.GetCellDescent(font.Style) * num2;
	}
}
