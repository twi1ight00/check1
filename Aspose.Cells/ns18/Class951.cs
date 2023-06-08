using Aspose.Cells.Rendering;

namespace ns18;

internal class Class951 : Class938
{
	private Class961 class961_0;

	private Class1449 class1449_0;

	internal Class961 Pages => class961_0;

	internal Class1449 Outline => class1449_0;

	internal Class951(Class1440 class1440_1)
		: base(class1440_1)
	{
		class1440_0 = class1440_1;
		class961_0 = new Class961(class1440_1);
		class1449_0 = new Class1449(class1440_1);
	}

	public override void vmethod_1(Class1447 class1447_0)
	{
		class1447_0.method_24(this);
		class1447_0.method_9();
		class1447_0.method_11("/Type", "/Catalog");
		class1447_0.method_11("/Pages", class961_0.method_1());
		if (!class1449_0.method_2())
		{
			class1447_0.method_11("/PageMode", "/UseOutlines");
			class1447_0.method_11("/Outlines", class1449_0.method_3());
		}
		if (class1440_0.method_1().Compliance == PdfCompliance.PdfA1b)
		{
			class1447_0.method_11("/Metadata", class1440_0.method_4().method_1());
			class1447_0.Write("/OutputIntents  [<</Type /OutputIntent/Info (sRGB IEC61966-2.1)/S /GTS_PDFA1/OutputConditionIdentifier (Custom)/DestOutputProfile ");
			class1447_0.Write(class1440_0.method_5().method_1());
			class1447_0.Write(">>]");
		}
		class1447_0.method_10();
		class1447_0.method_25();
		class961_0.vmethod_1(class1447_0);
		class1449_0.method_1(class1447_0);
		if (class1440_0.method_1().Compliance == PdfCompliance.PdfA1b)
		{
			class1440_0.method_4().vmethod_1(class1447_0);
			class1440_0.method_5().vmethod_1(class1447_0);
		}
	}
}
