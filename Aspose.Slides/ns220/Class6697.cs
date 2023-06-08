using System.IO;
using ns218;
using ns233;
using ns234;

namespace ns220;

internal static class Class6697
{
	internal static byte[] smethod_0(Class6150 palImage)
	{
		MemoryStream memoryStream = new MemoryStream();
		switch (palImage.ImageType)
		{
		default:
			palImage.method_9(memoryStream, 100);
			break;
		case Enum788.const_7:
			palImage.Save(memoryStream, Enum788.const_5);
			break;
		case Enum788.const_4:
		case Enum788.const_5:
		case Enum788.const_8:
			palImage.Save(memoryStream, palImage.ImageType);
			break;
		}
		return Class5964.smethod_11(memoryStream);
	}

	internal static byte[] smethod_1(byte[] imageBytes)
	{
		if (smethod_2(imageBytes))
		{
			return imageBytes;
		}
		try
		{
			using Class6150 palImage = new Class6150(imageBytes);
			return smethod_0(palImage);
		}
		catch
		{
			return Class5964.smethod_15();
		}
	}

	private static bool smethod_2(byte[] imageBytes)
	{
		return Class6148.smethod_0(imageBytes) switch
		{
			Enum788.const_4 => smethod_3(imageBytes), 
			Enum788.const_5 => smethod_4(imageBytes), 
			Enum788.const_8 => smethod_5(imageBytes), 
			_ => false, 
		};
	}

	internal static bool smethod_3(byte[] imageBytes)
	{
		using (MemoryStream memoryStream = new MemoryStream(imageBytes))
		{
			Class5950 @class = new Class5950(memoryStream);
			@class.method_3();
			ushort num = @class.method_3();
			while ((num & 0xFFF0) != 65472 || num == 65476 || num == 65484)
			{
				switch (num)
				{
				case 65504:
				case 65505:
				case 65506:
				case 65517:
				case 65518:
					return true;
				}
				ushort num2 = @class.method_3();
				memoryStream.Seek(num2 - 2, SeekOrigin.Current);
				num = @class.method_3();
			}
		}
		return false;
	}

	internal static bool smethod_4(byte[] imageBytes)
	{
		using MemoryStream memoryStream = new MemoryStream(imageBytes);
		Class5950 @class = new Class5950(memoryStream);
		memoryStream.Position = 8L;
		string text = string.Empty;
		string text2 = string.Empty;
		bool flag = true;
		while (memoryStream.Position <= memoryStream.Length - 8L)
		{
			uint num = @class.method_1();
			string text3 = new string(@class.method_10(4));
			if (flag)
			{
				text = text3;
				flag = false;
			}
			text2 = text3;
			memoryStream.Seek(num + 4, SeekOrigin.Current);
		}
		return text == "IHDR" && text2 == "IEND";
	}

	internal static bool smethod_5(byte[] imageBytes)
	{
		Class6149 @class = new Class6149(imageBytes);
		return @class.IsConformXpsSpecification;
	}
}
