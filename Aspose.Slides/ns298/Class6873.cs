using System;
using System.IO;
using ns233;
using ns234;
using ns276;
using ns292;
using ns293;

namespace ns298;

internal class Class6873
{
	public enum Enum932
	{
		const_0,
		const_1,
		const_2
	}

	private readonly string string_0;

	private readonly string string_1;

	private int int_0 = 1;

	public Class6873(string filesFolder)
	{
		string_0 = filesFolder;
		string_1 = string_0.Substring(string_0.LastIndexOf('\\') + 1);
	}

	internal string method_0()
	{
		return "img_" + int_0++.ToString("00");
	}

	public Enum922 method_1(byte[] rawData, Enum932 format)
	{
		if (format == Enum932.const_0)
		{
			Class6150 @class = new Class6150(rawData);
			if (@class.ImageType == Enum788.const_5)
			{
				return Enum922.const_1;
			}
			if (@class.ImageType == Enum788.const_4)
			{
				return Enum922.const_0;
			}
			if (@class.ImageType == Enum788.const_7)
			{
				return Enum922.const_3;
			}
			if (@class.ImageType == Enum788.const_6)
			{
				return Enum922.const_2;
			}
			if (@class.ImageType == Enum788.const_8)
			{
				return Enum922.const_4;
			}
		}
		else
		{
			switch (format)
			{
			case Enum932.const_1:
				return Enum922.const_5;
			case Enum932.const_2:
				return Enum922.const_6;
			}
		}
		throw new InvalidOperationException("Unsupported image type");
	}

	public string method_2(byte[] rawData, Enum932 format, out Enum922 imageType)
	{
		imageType = method_1(rawData, format);
		return method_0() + Class6792.smethod_1(imageType);
	}

	public void Save(byte[] rawData, Enum932 format, out string imagePath)
	{
		Enum922 imageType;
		string text = method_2(rawData, format, out imageType);
		using (FileStream fileStream = new FileStream(Path.Combine(string_0, text), FileMode.Create))
		{
			if (format == Enum932.const_2)
			{
				using Stream9 stream = new Stream9(fileStream, Enum916.const_0);
				stream.Write(rawData, 0, rawData.Length);
			}
			else
			{
				fileStream.Write(rawData, 0, rawData.Length);
			}
		}
		imagePath = string_1 + "/" + text;
	}
}
