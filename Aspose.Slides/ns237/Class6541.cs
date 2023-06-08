using System;

namespace ns237;

internal class Class6541 : Class6511
{
	private readonly Class6530 class6530_0;

	private readonly Class6543 class6543_0;

	internal Class6541(Class6672 context, Class6530 parentFont)
		: base(context)
	{
		class6530_0 = parentFont;
		class6543_0 = new Class6543(context, parentFont);
	}

	public override void vmethod_0(Class6679 writer)
	{
		writer.method_28(method_0());
		writer.method_29(this);
		writer.method_6();
		writer.method_8("/Type", "/Font");
		writer.method_8("/Subtype", method_1());
		writer.method_8("/BaseFont", $"/{class6530_0.BaseFontName}");
		writer.method_8("/CIDToGIDMap", "/Identity");
		writer.method_8("/FontDescriptor", class6543_0.IndirectReference);
		writer.method_18("/DW", 1000);
		writer.method_8("/W", class6530_0.method_4(1000));
		writer.Write("/CIDSystemInfo ");
		writer.method_6();
		writer.method_14("/Ordering", "Identity", isEscape: true);
		writer.method_14("/Registry", "Adobe", isEscape: true);
		writer.method_18("/Supplement", 0);
		writer.method_7();
		writer.method_7();
		writer.method_30();
		class6543_0.vmethod_0(writer);
	}

	private string method_1()
	{
		switch (class6530_0.FontType)
		{
		default:
			throw new InvalidOperationException("Unexpected font type.");
		case Enum873.const_0:
		case Enum873.const_1:
			return "/CIDFontType0";
		case Enum873.const_2:
			return "/CIDFontType2";
		}
	}
}
