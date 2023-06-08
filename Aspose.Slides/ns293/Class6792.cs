using System;
using ns292;

namespace ns293;

internal static class Class6792
{
	internal const string string_0 = "image/png";

	internal const string string_1 = "image/jpeg";

	internal const string string_2 = "image/gif";

	internal const string string_3 = "image/bmp";

	internal const string string_4 = "image/tiff";

	internal const string string_5 = "image/svg+xml";

	internal const string string_6 = ".png";

	internal const string string_7 = ".jpg";

	internal const string string_8 = ".gif";

	internal const string string_9 = ".bmp";

	internal const string string_10 = ".tiff";

	internal const string string_11 = ".svg";

	internal const string string_12 = ".svgz";

	internal static string smethod_0(Enum922 imageType)
	{
		switch (imageType)
		{
		default:
			throw new InvalidOperationException("Unknown image type");
		case Enum922.const_0:
			return "image/jpeg";
		case Enum922.const_1:
			return "image/png";
		case Enum922.const_2:
			return "image/bmp";
		case Enum922.const_3:
			return "image/gif";
		case Enum922.const_4:
			return "image/tiff";
		case Enum922.const_5:
		case Enum922.const_6:
			return "image/svg+xml";
		}
	}

	internal static string smethod_1(Enum922 imageType)
	{
		return imageType switch
		{
			Enum922.const_0 => ".jpg", 
			Enum922.const_1 => ".png", 
			Enum922.const_2 => ".bmp", 
			Enum922.const_3 => ".gif", 
			Enum922.const_4 => ".tiff", 
			Enum922.const_5 => ".svg", 
			Enum922.const_6 => ".svgz", 
			_ => throw new InvalidOperationException("Unknown image type"), 
		};
	}
}
