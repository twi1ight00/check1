using ns221;

namespace ns237;

internal class Class6672
{
	private int int_0;

	private readonly Class6674 class6674_0;

	private readonly Class6676 class6676_0;

	private readonly Class6680 class6680_0;

	private Class6561 class6561_0;

	internal Class6680 Options => class6680_0;

	internal Class6683 Resources => class6674_0.Resources;

	internal Class6547 Pages => class6674_0.Pages;

	internal Class6669 Annotations => class6674_0.Annotations;

	internal Class6681 Outline => class6674_0.Outline;

	internal Class5956 Info => class6674_0.Info;

	internal Class6534 AcroForm => class6674_0.AcroForm;

	internal Class6512 EncryptionDictionary => class6674_0.EncryptionDictionary;

	internal Class6676 GraphicStateWriter => class6676_0;

	internal bool PdfaCompliant => class6680_0.PdfaCompliant;

	internal Class6674 Document => class6674_0;

	internal Class6561 SupportedFeatures => class6561_0;

	public Class6672(Class6674 doc, Class6680 options)
	{
		class6674_0 = doc;
		class6676_0 = new Class6676(this);
		class6680_0 = options;
		class6561_0 = new Class6561();
	}

	internal int method_0()
	{
		return ++int_0;
	}
}
