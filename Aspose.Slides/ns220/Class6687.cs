using System.Drawing;
using ns218;

namespace ns220;

internal static class Class6687
{
	public static void Write(Class5946 builder, SizeF pageSize, bool isPage)
	{
		smethod_1(builder);
		smethod_2(builder, pageSize);
		smethod_3(builder, isPage);
		builder.method_1();
	}

	public static void smethod_0(Class5946 builder)
	{
		smethod_1(builder);
		builder.method_1();
	}

	private static void smethod_1(Class5946 builder)
	{
		builder.method_0("psf:PrintTicket");
		builder.method_14("version", "1");
		builder.method_14("xmlns:psf", "http://schemas.microsoft.com/windows/2003/08/printing/printschemaframework");
		builder.method_14("xmlns:xsi", "http://www.w3.org/2001/XMLSchema-instance");
		builder.method_14("xmlns:xsd", "http://www.w3.org/2001/XMLSchema");
		builder.method_14("xmlns:ns0000", "http://schemas.microsoft.com/windows/2006/06/printing/printschemakeywords/microsoftxpsdocumentwriter");
		builder.method_14("xmlns:psk", "http://schemas.microsoft.com/windows/2003/08/printing/printschemakeywords");
	}

	private static void smethod_2(Class5946 builder, SizeF size)
	{
		bool flag;
		int num = ((flag = size.Width > size.Height) ? Class5955.smethod_7(size.Height) : Class5955.smethod_7(size.Width));
		int num2 = (flag ? Class5955.smethod_7(size.Width) : Class5955.smethod_7(size.Height));
		smethod_4(builder, "psk:PageMediaSize");
		smethod_5(builder, Class6686.smethod_0(size));
		smethod_6(builder, "psk:MediaSizeWidth");
		smethod_7(builder, "xsd:integer", num.ToString());
		builder.method_3();
		smethod_6(builder, "psk:MediaSizeHeight");
		smethod_7(builder, "xsd:integer", num2.ToString());
		builder.method_3();
		builder.method_3();
		builder.method_3();
		smethod_4(builder, "psk:PageOrientation");
		smethod_5(builder, flag ? "psk:Landscape" : "psk:Portrait");
		builder.method_3();
		builder.method_3();
	}

	private static void smethod_3(Class5946 builder, bool isPage)
	{
		smethod_4(builder, isPage ? "psk:PageInputBin" : "psk:JobInputBin");
		smethod_5(builder, "psk:AutoSelect");
		builder.method_3();
		builder.method_3();
	}

	private static void smethod_4(Class5946 builder, string featureName)
	{
		builder.method_2("psf:Feature");
		builder.method_14("name", featureName);
	}

	private static void smethod_5(Class5946 builder, string optionName)
	{
		builder.method_2("psf:Option");
		builder.method_14("name", optionName);
	}

	private static void smethod_6(Class5946 builder, string propertyName)
	{
		builder.method_2("psf:ScoredProperty");
		builder.method_14("name", propertyName);
	}

	private static void smethod_7(Class5946 builder, string valyeType, string value)
	{
		builder.method_2("psf:Value");
		builder.method_14("xsi:type", valyeType);
		builder.method_13(value);
		builder.method_3();
	}
}
