using System;
using System.Collections;
using System.IO;
using System.Text;
using Aspose.Words;
using x6c95d9cf46ff5f25;
using xb92b7270f78a4e8d;

namespace xcf014befd8b52c3b;

internal class xd855f141beac193d
{
	private readonly xd8c3135513b9115b x435daba16a6b8f42;

	private readonly xe7be411416cfcd54 xcc9961d45a5ef5b9;

	private ArrayList x11bd064afd783d61;

	private static readonly byte[] x7a98826d119cd794 = new byte[76]
	{
		60, 0, 0, 0, 77, 0, 105, 0, 99, 0,
		114, 0, 111, 0, 115, 0, 111, 0, 102, 0,
		116, 0, 46, 0, 67, 0, 111, 0, 110, 0,
		116, 0, 97, 0, 105, 0, 110, 0, 101, 0,
		114, 0, 46, 0, 68, 0, 97, 0, 116, 0,
		97, 0, 83, 0, 112, 0, 97, 0, 99, 0,
		101, 0, 115, 0, 1, 0, 0, 0, 1, 0,
		0, 0, 1, 0, 0, 0
	};

	private static readonly byte[] x1e2443b2fc93bf3b = new byte[112]
	{
		8, 0, 0, 0, 1, 0, 0, 0, 104, 0,
		0, 0, 1, 0, 0, 0, 0, 0, 0, 0,
		32, 0, 0, 0, 69, 0, 110, 0, 99, 0,
		114, 0, 121, 0, 112, 0, 116, 0, 101, 0,
		100, 0, 80, 0, 97, 0, 99, 0, 107, 0,
		97, 0, 103, 0, 101, 0, 50, 0, 0, 0,
		83, 0, 116, 0, 114, 0, 111, 0, 110, 0,
		103, 0, 69, 0, 110, 0, 99, 0, 114, 0,
		121, 0, 112, 0, 116, 0, 105, 0, 111, 0,
		110, 0, 68, 0, 97, 0, 116, 0, 97, 0,
		83, 0, 112, 0, 97, 0, 99, 0, 101, 0,
		0, 0
	};

	private static readonly byte[] xe71931e98783bbe7 = new byte[64]
	{
		8, 0, 0, 0, 1, 0, 0, 0, 50, 0,
		0, 0, 83, 0, 116, 0, 114, 0, 111, 0,
		110, 0, 103, 0, 69, 0, 110, 0, 99, 0,
		114, 0, 121, 0, 112, 0, 116, 0, 105, 0,
		111, 0, 110, 0, 84, 0, 114, 0, 97, 0,
		110, 0, 115, 0, 102, 0, 111, 0, 114, 0,
		109, 0, 0, 0
	};

	private static readonly byte[] x9c361ca68f7030e3 = new byte[200]
	{
		88, 0, 0, 0, 1, 0, 0, 0, 76, 0,
		0, 0, 123, 0, 70, 0, 70, 0, 57, 0,
		65, 0, 51, 0, 70, 0, 48, 0, 51, 0,
		45, 0, 53, 0, 54, 0, 69, 0, 70, 0,
		45, 0, 52, 0, 54, 0, 49, 0, 51, 0,
		45, 0, 66, 0, 68, 0, 68, 0, 53, 0,
		45, 0, 53, 0, 65, 0, 52, 0, 49, 0,
		67, 0, 49, 0, 68, 0, 48, 0, 55, 0,
		50, 0, 52, 0, 54, 0, 125, 0, 78, 0,
		0, 0, 77, 0, 105, 0, 99, 0, 114, 0,
		111, 0, 115, 0, 111, 0, 102, 0, 116, 0,
		46, 0, 67, 0, 111, 0, 110, 0, 116, 0,
		97, 0, 105, 0, 110, 0, 101, 0, 114, 0,
		46, 0, 69, 0, 110, 0, 99, 0, 114, 0,
		121, 0, 112, 0, 116, 0, 105, 0, 111, 0,
		110, 0, 84, 0, 114, 0, 97, 0, 110, 0,
		115, 0, 102, 0, 111, 0, 114, 0, 109, 0,
		0, 0, 1, 0, 0, 0, 1, 0, 0, 0,
		1, 0, 0, 0, 0, 0, 0, 0, 0, 0,
		0, 0, 0, 0, 0, 0, 4, 0, 0, 0
	};

	internal xd855f141beac193d(xd8c3135513b9115b fs)
	{
		x435daba16a6b8f42 = fs;
		xcc9961d45a5ef5b9 = fs.x29e7ace4c90f74cd.x6ebb4c69c3381310("\u0006DataSpaces");
		x53e7e683cac517f3();
		x5bb0e52b97bd7cb7();
	}

	internal bool xb5153263347a0278()
	{
		if (x11bd064afd783d61.Count != 1)
		{
			return false;
		}
		xa73639a2c19c3814 xa73639a2c19c3815 = (xa73639a2c19c3814)x11bd064afd783d61[0];
		if (xa73639a2c19c3815.xcbe8bdc3909c536b != "StrongEncryptionDataSpace")
		{
			return false;
		}
		if (xa73639a2c19c3815.x2e89a831600652c8.Count != 1)
		{
			return false;
		}
		if ((string)xa73639a2c19c3815.x2e89a831600652c8[0] != "EncryptedPackage")
		{
			return false;
		}
		return true;
	}

	private static void xb0809c2c18ba538b(xd8c3135513b9115b x84378c276c4cd7e2)
	{
		xe7be411416cfcd54 xe7be411416cfcd = new xe7be411416cfcd54();
		xe7be411416cfcd.xd6b6ed77479ef68c("StrongEncryptionDataSpace", new MemoryStream(xe71931e98783bbe7));
		xe7be411416cfcd54 xe7be411416cfcd2 = new xe7be411416cfcd54();
		xe7be411416cfcd2.xd6b6ed77479ef68c("\u0006Primary", new MemoryStream(x9c361ca68f7030e3));
		xe7be411416cfcd54 xe7be411416cfcd3 = new xe7be411416cfcd54();
		xe7be411416cfcd3.xd6b6ed77479ef68c("StrongEncryptionTransform", xe7be411416cfcd2);
		xe7be411416cfcd54 xe7be411416cfcd4 = new xe7be411416cfcd54();
		xe7be411416cfcd4.xd6b6ed77479ef68c("DataSpaceInfo", xe7be411416cfcd);
		xe7be411416cfcd4.xd6b6ed77479ef68c("DataSpaceMap", new MemoryStream(x1e2443b2fc93bf3b));
		xe7be411416cfcd4.xd6b6ed77479ef68c("Version", new MemoryStream(x7a98826d119cd794));
		xe7be411416cfcd4.xd6b6ed77479ef68c("TransformInfo", xe7be411416cfcd3);
		x84378c276c4cd7e2.x29e7ace4c90f74cd.xd6b6ed77479ef68c("\u0006DataSpaces", xe7be411416cfcd4);
	}

	internal static xd8c3135513b9115b x246b032720dd4c0d(Stream xcf18e5243f8d5fd3, string xe8e4b5871d71a79a)
	{
		xd8c3135513b9115b xd8c3135513b9115b = new xd8c3135513b9115b(new Guid("00000000-0000-0000-0000-000000000000"));
		xb0809c2c18ba538b(xd8c3135513b9115b);
		x557c047c56f10b18 x557c047c56f10b19 = new xd2ae640ae2465835();
		MemoryStream memoryStream = new MemoryStream();
		MemoryStream memoryStream2 = new MemoryStream();
		x557c047c56f10b19.x246b032720dd4c0d(memoryStream, xcf18e5243f8d5fd3, memoryStream2, xe8e4b5871d71a79a);
		xd8c3135513b9115b.x29e7ace4c90f74cd.xd6b6ed77479ef68c("EncryptionInfo", memoryStream);
		xd8c3135513b9115b.x29e7ace4c90f74cd.xd6b6ed77479ef68c("EncryptedPackage", memoryStream2);
		return xd8c3135513b9115b;
	}

	internal MemoryStream xcc381ffa3ede662f(string xe8e4b5871d71a79a)
	{
		x696fbbe34227f39a();
		Stream x2fe2b17d7bd979f = x435daba16a6b8f42.x29e7ace4c90f74cd.xb3b34047219bdc2a("EncryptionInfo");
		Stream x303b0227e3017b6b = x435daba16a6b8f42.x29e7ace4c90f74cd.xb3b34047219bdc2a("EncryptedPackage");
		x557c047c56f10b18 x557c047c56f10b19 = x4ff197cb52a94cdf(x2fe2b17d7bd979f);
		MemoryStream memoryStream = new MemoryStream();
		x557c047c56f10b19.xcc381ffa3ede662f(x2fe2b17d7bd979f, x303b0227e3017b6b, memoryStream, xe8e4b5871d71a79a);
		return memoryStream;
	}

	private static x557c047c56f10b18 x4ff197cb52a94cdf(Stream x2fe2b17d7bd979f2)
	{
		BinaryReader binaryReader = new BinaryReader(x2fe2b17d7bd979f2);
		x557c047c56f10b18 result;
		switch ((xa28da04a3e363556)binaryReader.ReadInt32())
		{
		case xa28da04a3e363556.xd4a83f9d5c663199:
		case xa28da04a3e363556.x51a3b752f386bc73:
			result = new xd2ae640ae2465835();
			break;
		case xa28da04a3e363556.xe63a25f3f4dee9d4:
		case xa28da04a3e363556.x8c5555e2e401c86a:
			throw new UnsupportedFileFormatException("The document is encrypted using the Extensible Encryption and this is not currently supported.");
		case xa28da04a3e363556.x514edb0a2900cc19:
			result = new x9c22ad4a98e0ba4b();
			break;
		default:
			throw new InvalidOperationException("Unexpected encryption version.");
		}
		x2fe2b17d7bd979f2.Position = 0L;
		return result;
	}

	private void x696fbbe34227f39a()
	{
		string[] array = xc0f0b62cedc60867("StrongEncryptionDataSpace");
		if (array.Length != 1 || array[0] != "StrongEncryptionTransform")
		{
			throw new InvalidOperationException("Unexpected transform references.");
		}
		xe7be411416cfcd54 xe7be411416cfcd = xcc9961d45a5ef5b9.x6ebb4c69c3381310("TransformInfo");
		xe7be411416cfcd54 xe7be411416cfcd2 = xe7be411416cfcd.x6ebb4c69c3381310(array[0]);
		BinaryReader binaryReader = new BinaryReader(xe7be411416cfcd2.xb3b34047219bdc2a("\u0006Primary"));
		binaryReader.ReadInt32();
		int num = binaryReader.ReadInt32();
		if (num != 1)
		{
			throw new InvalidOperationException("Unexpected transform type.");
		}
		string text = x1c859f1450ed3318(binaryReader);
		if (text != "{FF9A3F03-56EF-4613-BDD5-5A41C1D07246}")
		{
			throw new InvalidOperationException("Unexpected transform id.");
		}
		string text2 = x1c859f1450ed3318(binaryReader);
		if (text2 != "Microsoft.Container.EncryptionTransform")
		{
			throw new InvalidOperationException("Unexpected transform name.");
		}
		x9aeab65fa044a521(binaryReader);
	}

	private string[] xc0f0b62cedc60867(string x2d43d34432ff8054)
	{
		xe7be411416cfcd54 xe7be411416cfcd = xcc9961d45a5ef5b9.x6ebb4c69c3381310("DataSpaceInfo");
		BinaryReader binaryReader = new BinaryReader(xe7be411416cfcd.xb3b34047219bdc2a(x2d43d34432ff8054));
		int num = binaryReader.ReadInt32();
		if (num != 8)
		{
			throw new InvalidOperationException("Unexpected header length.");
		}
		int num2 = binaryReader.ReadInt32();
		string[] array = new string[num2];
		for (int i = 0; i < num2; i++)
		{
			array[i] = x1c859f1450ed3318(binaryReader);
		}
		return array;
	}

	private void x53e7e683cac517f3()
	{
		BinaryReader xe134235b3526fa = new BinaryReader(xcc9961d45a5ef5b9.xb3b34047219bdc2a("Version"));
		if (x1c859f1450ed3318(xe134235b3526fa) != "Microsoft.Container.DataSpaces")
		{
			throw new InvalidOperationException("Unexpected FeatureIdentifier.");
		}
		x9aeab65fa044a521(xe134235b3526fa);
	}

	private static void x9aeab65fa044a521(BinaryReader xe134235b3526fa75)
	{
		int num = xe134235b3526fa75.ReadInt32();
		if (num != 1)
		{
			throw new InvalidOperationException("Unexpected reader version.");
		}
		int num2 = xe134235b3526fa75.ReadInt32();
		if (num2 != 1)
		{
			throw new InvalidOperationException("Unexpected updated version.");
		}
		int num3 = xe134235b3526fa75.ReadInt32();
		if (num3 != 1)
		{
			throw new InvalidOperationException("Unexpected writer version.");
		}
	}

	private static string x1c859f1450ed3318(BinaryReader xe134235b3526fa75)
	{
		int count = xe134235b3526fa75.ReadInt32();
		byte[] bytes = xe134235b3526fa75.ReadBytes(count);
		x0d299f323d241756.xb66a70c14b63a912(xe134235b3526fa75.BaseStream, 4);
		return Encoding.Unicode.GetString(bytes);
	}

	private static string xc1ce69c8f047ee23(BinaryReader xe134235b3526fa75)
	{
		int count = xe134235b3526fa75.ReadInt32();
		byte[] bytes = xe134235b3526fa75.ReadBytes(count);
		x0d299f323d241756.xb66a70c14b63a912(xe134235b3526fa75.BaseStream, 4);
		return Encoding.UTF8.GetString(bytes);
	}

	private void x5bb0e52b97bd7cb7()
	{
		BinaryReader binaryReader = new BinaryReader(xcc9961d45a5ef5b9.xb3b34047219bdc2a("DataSpaceMap"));
		int num = binaryReader.ReadInt32();
		if (num != 8)
		{
			throw new InvalidOperationException("Unexpected header length.");
		}
		x11bd064afd783d61 = new ArrayList();
		int num2 = binaryReader.ReadInt32();
		for (int i = 0; i < num2; i++)
		{
			xa73639a2c19c3814 value = xece8d2a2c10111b0(binaryReader);
			x11bd064afd783d61.Add(value);
		}
	}

	private static xa73639a2c19c3814 xece8d2a2c10111b0(BinaryReader xe134235b3526fa75)
	{
		xa73639a2c19c3814 xa73639a2c19c3815 = new xa73639a2c19c3814();
		xe134235b3526fa75.ReadInt32();
		int num = xe134235b3526fa75.ReadInt32();
		for (int i = 0; i < num; i++)
		{
			xe134235b3526fa75.ReadInt32();
			string value = x1c859f1450ed3318(xe134235b3526fa75);
			xa73639a2c19c3815.x2e89a831600652c8.Add(value);
		}
		xa73639a2c19c3815.xcbe8bdc3909c536b = x1c859f1450ed3318(xe134235b3526fa75);
		return xa73639a2c19c3815;
	}
}
