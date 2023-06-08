using System.IO;
using System.Net;
using System.Reflection;
using ns18;

namespace ns22;

internal class Class1186
{
	internal static byte[] smethod_0()
	{
		Stream stream_ = smethod_7("Aspose.Cells.Book1.xls");
		return Class936.smethod_1(stream_, bool_0: true);
	}

	internal static byte[] smethod_1()
	{
		Stream stream_ = smethod_7("Aspose.Cells.Theme2007.dat");
		return Class936.smethod_1(stream_, bool_0: true);
	}

	internal static byte[] smethod_2()
	{
		Stream stream_ = smethod_7("Aspose.Cells.OleObject.dat");
		return Class936.smethod_1(stream_, bool_0: true);
	}

	internal static byte[] smethod_3()
	{
		using Stream stream_ = Class1028.smethod_0("Aspose.Cells.PatternMasks.dat");
		return Class936.smethod_1(stream_, bool_0: false);
	}

	internal static byte[] smethod_4()
	{
		using Stream stream_ = Class1028.smethod_0("Aspose.Cells.PDF_A_DestOutputData.dat");
		return Class936.smethod_1(stream_, bool_0: false);
	}

	[Attribute0(true)]
	public static Stream smethod_5()
	{
		return smethod_7("Aspose.Cells.NoImage.png");
	}

	[Attribute0(true)]
	public static byte[] smethod_6()
	{
		using Stream stream_ = smethod_5();
		return Class936.smethod_1(stream_, bool_0: false);
	}

	internal static Stream smethod_7(string string_0)
	{
		return Assembly.GetCallingAssembly().GetManifestResourceStream(string_0);
	}

	internal static Stream smethod_8(string string_0)
	{
		WebRequest webRequest = WebRequest.Create(string_0);
		WebResponse response = webRequest.GetResponse();
		MemoryStream memoryStream = new MemoryStream();
		using (Stream stream_ = response.GetResponseStream())
		{
			Class1015.smethod_9(stream_, memoryStream);
		}
		memoryStream.Position = 0L;
		return memoryStream;
	}
}
