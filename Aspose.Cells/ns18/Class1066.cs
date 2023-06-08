using System.Drawing;

namespace ns18;

internal class Class1066
{
	private Class1066()
	{
	}

	public static void Write(Class1009 class1009_0, SizeF sizeF_0, bool bool_0)
	{
		smethod_1(class1009_0);
		smethod_2(class1009_0, sizeF_0);
		smethod_3(class1009_0, bool_0);
		class1009_0.method_2();
	}

	public static void smethod_0(Class1009 class1009_0)
	{
		smethod_1(class1009_0);
		class1009_0.method_2();
	}

	private static void smethod_1(Class1009 class1009_0)
	{
		class1009_0.method_1("psf:PrintTicket");
		class1009_0.method_9("version", "1");
		class1009_0.method_9("xmlns:psf", "http://schemas.microsoft.com/windows/2003/08/printing/printschemaframework");
		class1009_0.method_9("xmlns:xsi", "http://www.w3.org/2001/XMLSchema-instance");
		class1009_0.method_9("xmlns:xsd", "http://www.w3.org/2001/XMLSchema");
		class1009_0.method_9("xmlns:ns0000", "http://schemas.microsoft.com/windows/2006/06/printing/printschemakeywords/microsoftxpsdocumentwriter");
		class1009_0.method_9("xmlns:psk", "http://schemas.microsoft.com/windows/2003/08/printing/printschemakeywords");
	}

	private static void smethod_2(Class1009 class1009_0, SizeF sizeF_0)
	{
		bool flag;
		int num = ((flag = sizeF_0.Width > sizeF_0.Height) ? Class1395.smethod_1(sizeF_0.Height) : Class1395.smethod_1(sizeF_0.Width));
		int num2 = (flag ? Class1395.smethod_1(sizeF_0.Width) : Class1395.smethod_1(sizeF_0.Height));
		smethod_4(class1009_0, "psk:PageMediaSize");
		smethod_5(class1009_0, Class1065.smethod_0(sizeF_0));
		smethod_6(class1009_0, "psk:MediaSizeWidth");
		smethod_7(class1009_0, "xsd:integer", num.ToString());
		class1009_0.method_4();
		smethod_6(class1009_0, "psk:MediaSizeHeight");
		smethod_7(class1009_0, "xsd:integer", num2.ToString());
		class1009_0.method_4();
		class1009_0.method_4();
		class1009_0.method_4();
		smethod_4(class1009_0, "psk:PageOrientation");
		smethod_5(class1009_0, flag ? "psk:Landscape" : "psk:Portrait");
		class1009_0.method_4();
		class1009_0.method_4();
	}

	private static void smethod_3(Class1009 class1009_0, bool bool_0)
	{
		smethod_4(class1009_0, bool_0 ? "psk:PageInputBin" : "psk:JobInputBin");
		smethod_5(class1009_0, "psk:AutoSelect");
		class1009_0.method_4();
		class1009_0.method_4();
	}

	private static void smethod_4(Class1009 class1009_0, string string_0)
	{
		class1009_0.method_3("psf:Feature");
		class1009_0.method_9("name", string_0);
	}

	private static void smethod_5(Class1009 class1009_0, string string_0)
	{
		class1009_0.method_3("psf:Option");
		class1009_0.method_9("name", string_0);
	}

	private static void smethod_6(Class1009 class1009_0, string string_0)
	{
		class1009_0.method_3("psf:ScoredProperty");
		class1009_0.method_9("name", string_0);
	}

	private static void smethod_7(Class1009 class1009_0, string string_0, string string_1)
	{
		class1009_0.method_3("psf:Value");
		class1009_0.method_9("xsi:type", string_0);
		class1009_0.method_8(string_1);
		class1009_0.method_4();
	}
}
