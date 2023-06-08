using System;
using System.IO;

namespace ns130;

internal class Class4594
{
	public Class4595 class4595_0;

	public byte[] byte_0;

	public byte[] byte_1;

	public Class4594(Stream input)
	{
		if (input == null)
		{
			throw new ArgumentNullException("Input stream can not be null", "input");
		}
		class4595_0 = new Class4595();
		method_2(input);
	}

	public Class4594(string inputPath)
	{
		if (inputPath == null)
		{
			throw new ArgumentNullException("Input path can not be empty", "inputPath");
		}
		using Stream input = File.OpenRead(inputPath);
		class4595_0 = new Class4595();
		method_2(input);
	}

	public void method_0(Stream output)
	{
		if (output == null)
		{
			throw new ArgumentNullException("Output stream can not be null", "output");
		}
		byte[] array = new byte[byte_1.Length];
		Buffer.BlockCopy(byte_1, 0, array, 0, byte_1.Length);
		if ((class4595_0.Flags & Enum649.flag_6) == Enum649.flag_6)
		{
			smethod_0(array);
		}
		if ((class4595_0.Flags & Enum649.flag_1) == Enum649.flag_1)
		{
			array = smethod_1(array);
		}
		output.Write(array, 0, array.Length);
	}

	public void method_1(string outputPath)
	{
		if (outputPath == null)
		{
			throw new ArgumentNullException("Output path can not be empty", "outputPath");
		}
		using Stream output = File.OpenWrite(outputPath);
		method_0(output);
	}

	private void method_2(Stream input)
	{
		BinaryReader binaryReader = new BinaryReader(input);
		class4595_0.method_0(binaryReader);
		if (class4595_0.Version.ushort_0 == 2 && class4595_0.Version.ushort_1 == 2)
		{
			byte_0 = binaryReader.ReadBytes((int)class4595_0.EudcFontSize);
		}
		byte_1 = binaryReader.ReadBytes((int)class4595_0.FontDataSize);
	}

	private static void smethod_0(byte[] data)
	{
		for (int i = 0; i < data.Length; i++)
		{
			data[i] = (byte)(data[i] ^ 0x50u);
		}
	}

	private static byte[] smethod_1(byte[] data)
	{
		Class4559 @class = new Class4559(new Class4583(data));
		return @class.method_0();
	}
}
