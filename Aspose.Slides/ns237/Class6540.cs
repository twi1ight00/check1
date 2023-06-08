namespace ns237;

internal class Class6540 : Class6511
{
	private const Enum888 enum888_0 = Enum888.const_0;

	private const Enum889 enum889_0 = Enum889.const_0;

	private Class6548 class6548_0;

	private Enum888 enum888_1;

	private Enum889 enum889_1;

	private readonly Class6547 class6547_0;

	private readonly Class6681 class6681_0;

	private Class6523 class6523_0;

	private Class6524 class6524_0;

	private Class6534 class6534_0;

	internal Class6547 Pages => class6547_0;

	internal Class6681 Outline => class6681_0;

	internal Enum888 PageLayout
	{
		get
		{
			return enum888_1;
		}
		set
		{
			enum888_1 = value;
		}
	}

	internal Class6534 AcroForm
	{
		get
		{
			if (class6534_0 == null)
			{
				class6534_0 = new Class6534(class6672_0);
			}
			return class6534_0;
		}
	}

	private bool NeedToWriteAcroForm => class6534_0 != null;

	internal Class6548 ViewerPreferences
	{
		get
		{
			if (class6548_0 == null)
			{
				class6548_0 = new Class6548(class6672_0);
			}
			return class6548_0;
		}
	}

	internal Enum889 PageMode
	{
		get
		{
			return enum889_1;
		}
		set
		{
			enum889_1 = value;
		}
	}

	internal Class6540(Class6672 context)
		: base(context)
	{
		class6547_0 = new Class6547(context);
		class6681_0 = new Class6681(context);
		if (class6672_0.PdfaCompliant)
		{
			class6523_0 = new Class6523(class6672_0);
			class6524_0 = new Class6524(class6672_0);
		}
	}

	public override void vmethod_0(Class6679 writer)
	{
		writer.method_28(method_0());
		writer.method_29(this);
		writer.method_6();
		writer.method_8("/Type", "/Catalog");
		writer.method_8("/Pages", class6547_0.IndirectReference);
		writer.method_8("/Outlines", class6681_0.IndirectReference);
		if (!class6681_0.IsEmpty)
		{
			writer.method_8("/PageMode", "/UseOutlines");
		}
		if (class6548_0 != null)
		{
			writer.method_8("/ViewerPreferences", class6548_0.IndirectReference);
		}
		if (enum888_1 != 0)
		{
			writer.method_8("/PageLayout", Class6661.smethod_2(enum888_1));
		}
		if (enum889_1 != 0)
		{
			writer.method_8("/PageMode", Class6661.smethod_1(enum889_1));
			if (PageMode == Enum889.const_3)
			{
				ViewerPreferences.NeedToWriteFullScreenPdfPageMode = true;
			}
		}
		if (NeedToWriteAcroForm)
		{
			writer.method_8("/AcroForm", AcroForm.IndirectReference);
		}
		if (class6672_0.PdfaCompliant)
		{
			writer.method_8("/Metadata", class6524_0.IndirectReference);
			writer.method_8("/OutputIntents", " ");
			writer.Write("[");
			writer.method_6();
			writer.method_8("/Type", "/OutputIntent");
			writer.method_14("/Info", "sRGB IEC61966-2.1", isEscape: true);
			writer.method_8("/S", "/GTS_PDFA1");
			writer.method_14("/OutputConditionIdentifier", "Custom", isEscape: true);
			writer.method_8("/DestOutputProfile", class6523_0.IndirectReference);
			writer.method_7();
			writer.Write("]");
		}
		writer.method_7();
		writer.method_30();
		if (class6548_0 != null)
		{
			class6548_0.vmethod_0(writer);
		}
		if (NeedToWriteAcroForm)
		{
			AcroForm.vmethod_0(writer);
		}
		class6547_0.vmethod_0(writer);
		class6681_0.method_1(writer);
		if (class6672_0.PdfaCompliant)
		{
			class6523_0.vmethod_0(writer);
			class6524_0.vmethod_0(writer);
		}
	}
}
