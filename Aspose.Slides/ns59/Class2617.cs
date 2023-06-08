using System;
using System.IO;
using System.Security.Cryptography;
using Aspose.Slides;
using ns4;

namespace ns59;

internal class Class2617
{
	public Struct135 struct135_0;

	public uint uint_0;

	public Class2612 class2612_0;

	public Class2613 class2613_0;

	public uint EncryptionHeaderFlags => class2612_0.struct134_0.uint_0;

	internal Class2617()
	{
	}

	internal Class2617(string password)
	{
		struct135_0 = default(Struct135);
		struct135_0.ushort_0 = 2;
		struct135_0.ushort_1 = 2;
		class2612_0 = new Class2612();
		uint_0 = class2612_0.uint_5;
		class2613_0 = new Class2613(password, class2612_0.uint_1);
	}

	internal int method_0()
	{
		return 12 + class2612_0.method_0() + class2613_0.method_0();
	}

	public void method_1(BinaryWriter writer)
	{
		struct135_0.method_0(writer);
		writer.Write((int)EncryptionHeaderFlags);
		writer.Write((int)uint_0);
		class2612_0.method_1(writer);
		class2613_0.method_1(writer);
	}

	public static Class2617 smethod_0(Stream stream)
	{
		Class2617 @class = new Class2617();
		@class.struct135_0 = Struct135.smethod_0(stream);
		Class1162.smethod_24(stream);
		@class.uint_0 = (uint)Class1162.smethod_24(stream);
		@class.class2612_0 = Class2612.smethod_0(stream, @class.uint_0);
		@class.class2613_0 = Class2613.smethod_0(stream, 20);
		return @class;
	}

	public Class2616 method_2(string password)
	{
		if (password.Length > 255)
		{
			throw new InvalidPasswordException("The password is too long.");
		}
		if (!class2612_0.method_2())
		{
			throw new PptReadException("Unsupported cryptographic hash algorytm.");
		}
		return new Class2616(password, class2613_0.byte_0, class2612_0.uint_1);
	}

	public bool method_3(Class2616 factory)
	{
		Class2615 @class = factory.method_0(0u);
		byte[] array = new byte[class2613_0.byte_1.Length + class2613_0.byte_2.Length];
		Array.Copy(class2613_0.byte_1, array, class2613_0.byte_1.Length);
		Array.Copy(class2613_0.byte_2, 0, array, class2613_0.byte_1.Length, class2613_0.byte_2.Length);
		byte[] array2 = @class.method_0(array);
		byte[] array3 = new byte[class2613_0.byte_1.Length];
		Array.Copy(array2, array3, array3.Length);
		using (SHA1 sHA = new SHA1CryptoServiceProvider())
		{
			byte[] array4 = sHA.ComputeHash(array3);
			for (int i = 0; i < array4.Length; i++)
			{
				if (array4[i] != array2[array3.Length + i])
				{
					return false;
				}
			}
		}
		return true;
	}
}
