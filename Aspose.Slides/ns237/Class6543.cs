using System;

namespace ns237;

internal class Class6543 : Class6511
{
	private Class6527 class6527_0;

	private Class6515 class6515_0;

	private Class6514 class6514_0;

	internal Class6543(Class6672 context, Class6527 parentFont)
		: base(context)
	{
		class6527_0 = parentFont;
		switch (parentFont.FontType)
		{
		default:
			throw new InvalidOperationException("Unexpected font type.");
		case Enum873.const_0:
		case Enum873.const_1:
			class6515_0 = new Class6517(context, "/CIDFontType0C");
			break;
		case Enum873.const_2:
			class6515_0 = new Class6516(context);
			break;
		case Enum873.const_3:
			break;
		}
		if (class6672_0.PdfaCompliant)
		{
			class6514_0 = new Class6514(context);
		}
	}

	public override void vmethod_0(Class6679 writer)
	{
		method_1(writer);
		if (class6515_0 != null)
		{
			class6527_0.vmethod_2(class6515_0.BaseStream);
			class6515_0.vmethod_0(writer);
		}
		if (class6672_0.PdfaCompliant)
		{
			class6514_0.WriteByte(128);
			class6514_0.vmethod_0(writer);
		}
	}

	private void method_1(Class6679 writer)
	{
		writer.method_29(this);
		writer.method_6();
		writer.method_8("/Type", "/FontDescriptor");
		writer.method_8("/FontName", $"/{class6527_0.BaseFontName}");
		writer.method_18("/StemV", 80);
		writer.method_18("/Descent", class6527_0.Descent);
		writer.method_18("/Ascent", class6527_0.Ascent);
		writer.method_18("/CapHeight", class6527_0.CapHeight);
		writer.method_18("/Flags", class6527_0.Flags);
		writer.method_19("/ItalicAngle", class6527_0.ItalicAngle);
		writer.method_16("/FontBBox", class6527_0.BBox);
		if (class6672_0.PdfaCompliant)
		{
			writer.method_8("/CIDSet", class6514_0.IndirectReference);
		}
		if (class6515_0 != null)
		{
			writer.method_8(class6515_0.FontFileDictionaryEntryName, class6515_0.IndirectReference);
		}
		writer.method_7();
		writer.method_30();
	}
}
