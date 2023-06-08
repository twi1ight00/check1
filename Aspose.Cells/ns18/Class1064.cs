using System.IO;
using ns22;

namespace ns18;

internal class Class1064
{
	private Class1064()
	{
	}

	internal static byte[] smethod_0(byte[] byte_0)
	{
		if (smethod_2(byte_0))
		{
			return byte_0;
		}
		try
		{
			using Class1021 class1021_ = new Class1021(byte_0);
			return smethod_1(class1021_);
		}
		catch
		{
			return Class1186.smethod_6();
		}
	}

	internal static byte[] smethod_1(Class1021 class1021_0)
	{
		MemoryStream stream_ = new MemoryStream();
		switch (class1021_0.ImageType)
		{
		default:
			class1021_0.method_2(stream_, 100);
			break;
		case Enum200.const_7:
			class1021_0.Save(stream_, Enum200.const_5);
			break;
		case Enum200.const_4:
		case Enum200.const_5:
		case Enum200.const_8:
			class1021_0.Save(stream_, class1021_0.ImageType);
			break;
		}
		return Class936.smethod_1(stream_, bool_0: false);
	}

	private static bool smethod_2(byte[] byte_0)
	{
		return Class1404.smethod_1(byte_0) switch
		{
			Enum200.const_4 => smethod_3(byte_0), 
			Enum200.const_5 => smethod_4(byte_0), 
			Enum200.const_8 => smethod_5(byte_0), 
			_ => false, 
		};
	}

	internal static bool smethod_3(byte[] byte_0)
	{
		using (MemoryStream memoryStream = new MemoryStream(byte_0))
		{
			Class1393 @class = new Class1393(memoryStream);
			@class.method_4();
			ushort num = @class.method_4();
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
				ushort num2 = @class.method_4();
				memoryStream.Seek(num2 - 2, SeekOrigin.Current);
				num = @class.method_4();
			}
		}
		return false;
	}

	internal static bool smethod_4(byte[] byte_0)
	{
		using MemoryStream memoryStream = new MemoryStream(byte_0);
		Class1393 @class = new Class1393(memoryStream);
		memoryStream.Position = 8L;
		string text = "";
		string text2 = "";
		bool flag = true;
		while (memoryStream.Position <= memoryStream.Length - 8)
		{
			uint num = @class.method_2();
			string text3 = new string(@class.method_6(4));
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

	internal static bool smethod_5(byte[] byte_0)
	{
		Class1020 @class = new Class1020(byte_0);
		return @class.method_1();
	}
}
