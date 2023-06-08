using System.IO;
using ns218;
using ns233;
using ns234;

namespace ns238;

internal static class Class6587
{
	internal static byte[] smethod_0(byte[] imageBytes, int jpegQuality)
	{
		if (smethod_2(imageBytes))
		{
			return imageBytes;
		}
		try
		{
			using Class6150 palImage = new Class6150(imageBytes);
			return smethod_1(palImage, jpegQuality);
		}
		catch
		{
			return Class5964.smethod_15();
		}
	}

	private static byte[] smethod_1(Class6150 palImage, int jpegQuality)
	{
		MemoryStream memoryStream = new MemoryStream();
		switch (palImage.ImageType)
		{
		default:
			palImage.method_9(memoryStream, jpegQuality);
			break;
		case Enum788.const_5:
		case Enum788.const_7:
			palImage.Save(memoryStream, palImage.ImageType);
			break;
		}
		return Class5964.smethod_11(memoryStream);
	}

	private static bool smethod_2(byte[] imageBytes)
	{
		switch (Class6148.smethod_0(imageBytes))
		{
		default:
			return false;
		case Enum788.const_5:
		case Enum788.const_7:
			return true;
		}
	}
}
