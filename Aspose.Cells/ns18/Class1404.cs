using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using ns22;

namespace ns18;

internal class Class1404
{
	public static float float_0 = 96f;

	private Class1404()
	{
	}

	public static Enum200 smethod_0(Stream stream_0)
	{
		stream_0.Position = 0L;
		byte[] array = new byte[64];
		stream_0.Read(array, 0, array.Length);
		stream_0.Position = 0L;
		return smethod_1(array);
	}

	public static Enum200 smethod_1(byte[] byte_0)
	{
		if (smethod_12(byte_0))
		{
			return Enum200.const_2;
		}
		if (smethod_13(byte_0))
		{
			return Enum200.const_2;
		}
		if (smethod_14(byte_0))
		{
			return Enum200.const_1;
		}
		if (smethod_7(byte_0))
		{
			return Enum200.const_4;
		}
		if (smethod_8(byte_0))
		{
			return Enum200.const_5;
		}
		if (smethod_9(byte_0))
		{
			return Enum200.const_6;
		}
		if (smethod_11(byte_0))
		{
			return Enum200.const_3;
		}
		if (smethod_10(byte_0))
		{
			return Enum200.const_7;
		}
		if (smethod_6(byte_0))
		{
			return Enum200.const_8;
		}
		return Enum200.const_0;
	}

	public static string smethod_2(Enum200 enum200_0)
	{
		return enum200_0 switch
		{
			Enum200.const_1 => "emf", 
			Enum200.const_2 => "wmf", 
			Enum200.const_3 => "pict", 
			Enum200.const_4 => "jpeg", 
			Enum200.const_5 => "png", 
			Enum200.const_6 => "bmp", 
			Enum200.const_7 => "gif", 
			Enum200.const_8 => "tif", 
			_ => throw new InvalidOperationException("Cannot convert image type to string."), 
		};
	}

	public static Enum200 smethod_3(ImageFormat imageFormat_0)
	{
		if (imageFormat_0.Equals(ImageFormat.Jpeg))
		{
			return Enum200.const_4;
		}
		if (imageFormat_0.Equals(ImageFormat.Png))
		{
			return Enum200.const_5;
		}
		if (imageFormat_0.Equals(ImageFormat.Emf))
		{
			return Enum200.const_1;
		}
		if (imageFormat_0.Equals(ImageFormat.Wmf))
		{
			return Enum200.const_2;
		}
		if (imageFormat_0.Equals(ImageFormat.Bmp))
		{
			return Enum200.const_6;
		}
		if (imageFormat_0.Equals(ImageFormat.Gif))
		{
			return Enum200.const_7;
		}
		if (imageFormat_0.Equals(ImageFormat.Tiff))
		{
			return Enum200.const_8;
		}
		return Enum200.const_0;
	}

	public static Class1403 smethod_4(byte[] byte_0)
	{
		return smethod_5(byte_0, smethod_1(byte_0));
	}

	public static Class1403 smethod_5(byte[] byte_0, Enum200 enum200_0)
	{
		return enum200_0 switch
		{
			Enum200.const_1 => smethod_33(byte_0), 
			Enum200.const_2 => smethod_31(byte_0), 
			Enum200.const_3 => smethod_34(byte_0), 
			Enum200.const_4 => smethod_24(byte_0), 
			Enum200.const_5 => smethod_23(byte_0), 
			Enum200.const_6 => smethod_21(byte_0), 
			Enum200.const_7 => smethod_22(byte_0), 
			_ => Class1403.smethod_1(100, 100, float_0, float_0), 
		};
	}

	public static bool smethod_6(byte[] byte_0)
	{
		using MemoryStream input = new MemoryStream(byte_0);
		BinaryReader binaryReader = new BinaryReader(input);
		int num = binaryReader.ReadInt16();
		return num == 18761 || num == 19789;
	}

	public static bool smethod_7(byte[] byte_0)
	{
		using MemoryStream input = new MemoryStream(byte_0);
		BinaryReader binaryReader = new BinaryReader(input);
		uint num = binaryReader.ReadUInt16();
		if (num != 55551)
		{
			return false;
		}
		return true;
	}

	public static bool smethod_8(byte[] byte_0)
	{
		using MemoryStream input = new MemoryStream(byte_0);
		BinaryReader binaryReader = new BinaryReader(input);
		uint num = binaryReader.ReadUInt32();
		if (num != 1196314761)
		{
			return false;
		}
		uint num2 = binaryReader.ReadUInt32();
		if (num2 != 169478669)
		{
			return false;
		}
		return true;
	}

	public static bool smethod_9(byte[] byte_0)
	{
		using MemoryStream input = new MemoryStream(byte_0);
		BinaryReader binaryReader = new BinaryReader(input);
		uint num = binaryReader.ReadUInt16();
		if (num != 19778)
		{
			return false;
		}
		uint num2 = binaryReader.ReadUInt32();
		binaryReader.ReadUInt32();
		uint num3 = binaryReader.ReadUInt32();
		if (num2 != 0 && num3 > num2)
		{
			return false;
		}
		uint num4 = binaryReader.ReadUInt32();
		bool flag;
		if (!(flag = num4 == 12) && num4 < 16)
		{
			return false;
		}
		if (flag)
		{
			binaryReader.ReadUInt32();
		}
		else
		{
			binaryReader.ReadInt32();
			binaryReader.ReadInt32();
		}
		uint num5 = binaryReader.ReadUInt16();
		if (num5 != 1)
		{
			return false;
		}
		uint num6 = binaryReader.ReadUInt16();
		if (num6 != 1 && num6 != 4 && num6 != 8 && num6 != 16 && num6 != 24 && num6 != 32)
		{
			return false;
		}
		return true;
	}

	public static bool smethod_10(byte[] byte_0)
	{
		using MemoryStream input = new MemoryStream(byte_0);
		BinaryReader binaryReader = new BinaryReader(input);
		int num = binaryReader.ReadInt32() & 0xFFFFFF;
		return num == 4606279;
	}

	public static bool smethod_11(byte[] byte_0)
	{
		using MemoryStream input = new MemoryStream(byte_0);
		BinaryReader binaryReader = new BinaryReader(input);
		binaryReader.ReadUInt16();
		binaryReader.ReadUInt16();
		binaryReader.ReadUInt16();
		binaryReader.ReadUInt16();
		binaryReader.ReadUInt16();
		switch (Class1015.smethod_3(binaryReader.ReadUInt16()))
		{
		case 273:
			return true;
		case 17:
		{
			int num = Class1015.smethod_3(binaryReader.ReadUInt16());
			if (num == 767)
			{
				return true;
			}
			break;
		}
		}
		return false;
	}

	public static bool smethod_12(byte[] byte_0)
	{
		using MemoryStream input = new MemoryStream(byte_0);
		BinaryReader binaryReader = new BinaryReader(input);
		int num = binaryReader.ReadInt16();
		if (num != 0 && num != 1)
		{
			return false;
		}
		int num2 = binaryReader.ReadInt16();
		if (num2 != 9)
		{
			return false;
		}
		binaryReader.ReadInt16();
		binaryReader.ReadInt32();
		binaryReader.ReadInt16();
		binaryReader.ReadInt32();
		if (binaryReader.ReadInt16() != 0)
		{
			return false;
		}
		return true;
	}

	public static bool smethod_13(byte[] byte_0)
	{
		using MemoryStream input = new MemoryStream(byte_0);
		BinaryReader binaryReader = new BinaryReader(input);
		uint num = binaryReader.ReadUInt32();
		if (num != 2596720087u)
		{
			return false;
		}
		if (binaryReader.ReadInt16() != 0)
		{
			return false;
		}
		return true;
	}

	public static bool smethod_14(byte[] byte_0)
	{
		using MemoryStream input = new MemoryStream(byte_0);
		BinaryReader binaryReader = new BinaryReader(input);
		uint num = binaryReader.ReadUInt32();
		if (num != 1)
		{
			return false;
		}
		binaryReader.BaseStream.Position = 40L;
		uint num2 = binaryReader.ReadUInt32();
		if (num2 != 1179469088)
		{
			return false;
		}
		return true;
	}

	public static Enum202 smethod_15(byte[] byte_0)
	{
		if (smethod_14(byte_0))
		{
			using (MemoryStream input = new MemoryStream(byte_0))
			{
				BinaryReader binaryReader = new BinaryReader(input);
				binaryReader.ReadUInt32();
				uint num = binaryReader.ReadUInt32();
				binaryReader.BaseStream.Position = num;
				uint num2 = binaryReader.ReadUInt32();
				if (num2 != 70)
				{
					return Enum202.const_3;
				}
				binaryReader.ReadInt32();
				binaryReader.ReadInt32();
				int num3 = binaryReader.ReadInt32();
				if (num3 == 726027589)
				{
					int num4 = binaryReader.ReadUInt16();
					if (num4 != 16385)
					{
						return Enum202.const_3;
					}
					int num5 = binaryReader.ReadUInt16();
					if ((num5 & 1) == 1)
					{
						return Enum202.const_5;
					}
					return Enum202.const_4;
				}
				return Enum202.const_3;
			}
		}
		return Enum202.const_0;
	}

	public static byte[] smethod_16(byte[] byte_0)
	{
		using MemoryStream input = new MemoryStream(byte_0);
		BinaryReader binaryReader_ = new BinaryReader(input);
		return smethod_17(binaryReader_, byte_0.Length);
	}

	private static byte[] smethod_17(BinaryReader binaryReader_0, int int_0)
	{
		int num = (int)binaryReader_0.BaseStream.Position;
		Class1401 @class = new Class1401();
		@class.Read(binaryReader_0);
		binaryReader_0.BaseStream.Position = num;
		byte[] array = new byte[14 + int_0];
		using MemoryStream output = new MemoryStream(array);
		BinaryWriter binaryWriter = new BinaryWriter(output);
		Class1400 class2 = new Class1400();
		class2.uint_0 = (uint)(14 + int_0);
		class2.uint_1 = (uint)(54 + @class.method_0());
		class2.Write(binaryWriter);
		binaryWriter.Flush();
		binaryReader_0.Read(array, 14, int_0);
		return array;
	}

	public static byte[] smethod_18(BinaryReader binaryReader_0, int int_0, int int_1)
	{
		int num = (int)binaryReader_0.BaseStream.Position;
		Class1401 @class = new Class1401();
		@class.Read(binaryReader_0);
		int num2 = 40 + @class.method_0();
		byte[] buffer = binaryReader_0.ReadBytes(@class.method_0());
		binaryReader_0.BaseStream.Position = num + int_0;
		byte[] array = new byte[14 + num2 + int_1];
		using MemoryStream output = new MemoryStream(array);
		BinaryWriter binaryWriter = new BinaryWriter(output);
		Class1400 class2 = new Class1400();
		class2.uint_0 = (uint)(14 + num2 + int_1);
		class2.uint_1 = (uint)(14 + num2);
		class2.Write(binaryWriter);
		@class.Write(binaryWriter);
		binaryWriter.Write(buffer);
		binaryWriter.Flush();
		binaryReader_0.Read(array, 14 + num2, int_1);
		return array;
	}

	public static Bitmap smethod_19(BinaryReader binaryReader_0, int int_0)
	{
		MemoryStream stream = new MemoryStream(smethod_17(binaryReader_0, int_0));
		return (Bitmap)Image.FromStream(stream);
	}

	public static Bitmap smethod_20(BinaryReader binaryReader_0, int int_0, int int_1)
	{
		MemoryStream stream = new MemoryStream(smethod_18(binaryReader_0, int_0, int_1));
		Bitmap result = null;
		try
		{
			result = (Bitmap)Image.FromStream(stream);
		}
		catch
		{
		}
		return result;
	}

	public static Class1403 smethod_21(byte[] byte_0)
	{
		using MemoryStream memoryStream = new MemoryStream(byte_0);
		memoryStream.Position = 14L;
		BinaryReader binaryReader_ = new BinaryReader(memoryStream);
		Class1401 @class = new Class1401();
		@class.Read(binaryReader_);
		Class1403 class2 = Class1403.smethod_1(@class.int_0, @class.int_1, (double)@class.int_2 / 39.37007874015748, (double)@class.int_3 / 39.37007874015748);
		if (class2.HorizontalResolution == 0.0)
		{
			class2.HorizontalResolution = float_0;
		}
		if (class2.VerticalResolution == 0.0)
		{
			class2.VerticalResolution = float_0;
		}
		return class2;
	}

	public static Class1403 smethod_22(byte[] byte_0)
	{
		using MemoryStream memoryStream = new MemoryStream(byte_0);
		memoryStream.Position = 6L;
		BinaryReader binaryReader = new BinaryReader(memoryStream);
		ushort int_ = binaryReader.ReadUInt16();
		ushort int_2 = binaryReader.ReadUInt16();
		return Class1403.smethod_1(int_, int_2, float_0, float_0);
	}

	public static Class1403 smethod_23(byte[] byte_0)
	{
		Class1403 @class = Class1403.smethod_0();
		using MemoryStream memoryStream = new MemoryStream(byte_0);
		Class1393 class2 = new Class1393(memoryStream);
		memoryStream.Position = 8L;
		bool flag = false;
		while (!flag && memoryStream.Position < memoryStream.Length)
		{
			uint num = class2.method_2();
			switch (new string(class2.method_6(4)))
			{
			case "IEND":
				flag = true;
				break;
			case "pHYs":
			{
				uint num2 = class2.method_2();
				uint num3 = class2.method_2();
				byte b = class2.ReadByte();
				if (b == 1)
				{
					@class.HorizontalResolution = (double)num2 / 39.37007874015748;
					@class.VerticalResolution = (double)num3 / 39.37007874015748;
				}
				flag = true;
				break;
			}
			case "IHDR":
				@class.Width = class2.method_1();
				@class.Height = class2.method_1();
				memoryStream.Seek(-8L, SeekOrigin.Current);
				break;
			}
			memoryStream.Seek(num + 4, SeekOrigin.Current);
		}
		return @class;
	}

	public static Class1403 smethod_24(byte[] byte_0)
	{
		using MemoryStream memoryStream = new MemoryStream(byte_0);
		Class1403 @class = Class1403.smethod_0();
		Class1393 class2 = new Class1393(memoryStream);
		class2.method_4();
		ushort num = class2.method_4();
		while ((num & 0xFFF0) != 65472 || num == 65476 || num == 65484)
		{
			if (!smethod_25(num, class2, @class))
			{
				ushort num2 = class2.method_4();
				memoryStream.Seek(num2 - 2, SeekOrigin.Current);
			}
			num = class2.method_4();
		}
		if (@class.HorizontalResolution == 0.0)
		{
			@class.HorizontalResolution = 96.0;
		}
		if (@class.VerticalResolution == 0.0)
		{
			@class.VerticalResolution = 96.0;
		}
		memoryStream.Seek(3L, SeekOrigin.Current);
		@class.Height = class2.method_4();
		@class.Width = class2.method_4();
		return @class;
	}

	private static bool smethod_25(ushort ushort_0, Class1393 class1393_0, Class1403 class1403_0)
	{
		switch (ushort_0)
		{
		case 65504:
			smethod_26(class1393_0, class1403_0);
			return true;
		case 65505:
			smethod_27(class1393_0, class1403_0);
			return true;
		default:
			return false;
		}
	}

	private static void smethod_26(Class1393 class1393_0, Class1403 class1403_0)
	{
		ushort num = class1393_0.method_4();
		class1393_0.method_0().Seek(7L, SeekOrigin.Current);
		byte b = class1393_0.ReadByte();
		ushort num2 = class1393_0.method_4();
		ushort num3 = class1393_0.method_4();
		switch (b)
		{
		case 1:
			class1403_0.HorizontalResolution = (int)num2;
			class1403_0.VerticalResolution = (int)num3;
			break;
		case 2:
			class1403_0.HorizontalResolution = (double)(int)num2 * 2.54;
			class1403_0.VerticalResolution = (double)(int)num3 * 2.54;
			break;
		}
		if (class1403_0.HorizontalResolution == 0.0)
		{
			class1403_0.HorizontalResolution = 96.0;
		}
		if (class1403_0.VerticalResolution == 0.0)
		{
			class1403_0.VerticalResolution = 96.0;
		}
		class1393_0.method_0().Seek(num - 14, SeekOrigin.Current);
	}

	private static void smethod_27(Class1393 class1393_0, Class1403 class1403_0)
	{
		long position = class1393_0.method_0().Position;
		ushort num = class1393_0.method_4();
		string text = new string(class1393_0.method_6(6));
		if (text.StartsWith("Exif"))
		{
			long position2 = class1393_0.method_0().Position;
			short num2 = class1393_0.method_3();
			bool bool_ = num2 == 19789;
			smethod_29(class1393_0, bool_);
			uint num3 = smethod_30(class1393_0, bool_);
			class1393_0.method_0().Seek(num3 - 8, SeekOrigin.Current);
			ushort num4 = smethod_29(class1393_0, bool_);
			for (int i = 0; i < num4; i++)
			{
				ushort num5 = smethod_29(class1393_0, bool_);
				smethod_29(class1393_0, bool_);
				smethod_30(class1393_0, bool_);
				uint num6 = smethod_30(class1393_0, bool_);
				if (num5 == 282)
				{
					class1403_0.HorizontalResolution = smethod_28(class1393_0, position2 + num6, bool_);
				}
				if (num5 == 283)
				{
					class1403_0.VerticalResolution = smethod_28(class1393_0, position2 + num6, bool_);
				}
			}
		}
		class1393_0.method_0().Position = position + num;
	}

	private static double smethod_28(Class1393 class1393_0, long long_0, bool bool_0)
	{
		long position = class1393_0.method_0().Position;
		class1393_0.method_0().Position = long_0;
		uint num = smethod_30(class1393_0, bool_0);
		uint num2 = smethod_30(class1393_0, bool_0);
		class1393_0.method_0().Position = position;
		return num / num2;
	}

	private static ushort smethod_29(Class1393 class1393_0, bool bool_0)
	{
		ushort num = class1393_0.method_4();
		if (!bool_0)
		{
			num = Class1015.smethod_3(num);
		}
		return num;
	}

	private static uint smethod_30(Class1393 class1393_0, bool bool_0)
	{
		uint num = class1393_0.method_2();
		if (!bool_0)
		{
			num = Class1015.smethod_1(num);
		}
		return num;
	}

	public static Class1403 smethod_31(byte[] byte_0)
	{
		if (smethod_12(byte_0))
		{
			return smethod_32(byte_0);
		}
		if (smethod_13(byte_0))
		{
			using (MemoryStream input = new MemoryStream(byte_0))
			{
				BinaryReader binaryReader_ = new BinaryReader(input);
				Class1423 @class = new Class1423();
				@class.Read(binaryReader_);
				Class1403 class2 = Class1403.smethod_2(@class.method_2().Left, @class.method_2().Top, @class.method_2().Right, @class.method_2().Bottom, @class.method_3(), @class.method_3());
				if (class2.Width <= 0 && class2.Height <= 0)
				{
					return smethod_32(byte_0);
				}
				return class2;
			}
		}
		throw new InvalidOperationException("Unexpected image type.");
	}

	private static Class1403 smethod_32(byte[] byte_0)
	{
		Class1414 @class = new Class1414(byte_0);
		return Class1403.smethod_1((int)@class.Size.Width, (int)@class.Size.Height, @class.HorizontalResolution, @class.VerticalResolution);
	}

	public static Class1403 smethod_33(byte[] byte_0)
	{
		using MemoryStream input = new MemoryStream(byte_0);
		BinaryReader binaryReader_ = new BinaryReader(input);
		Class1417 @class = new Class1417();
		@class.Read(binaryReader_);
		return Class1403.smethod_2((int)Math.Ceiling(@class.method_1().Left), (int)Math.Ceiling(@class.method_1().Top), (int)Math.Ceiling(@class.method_1().Right), (int)Math.Ceiling(@class.method_1().Bottom), @class.HorizontalResolution, @class.VerticalResolution);
	}

	public static Class1403 smethod_34(byte[] byte_0)
	{
		using MemoryStream input = new MemoryStream(byte_0);
		BinaryReader binaryReader = new BinaryReader(input);
		binaryReader.ReadUInt16();
		int num = Class1015.smethod_3(binaryReader.ReadUInt16());
		int num2 = Class1015.smethod_3(binaryReader.ReadUInt16());
		int num3 = Class1015.smethod_3(binaryReader.ReadUInt16());
		int num4 = Class1015.smethod_3(binaryReader.ReadUInt16());
		int int_ = Class1395.smethod_6(num4 - num2);
		int int_2 = Class1395.smethod_6(num3 - num);
		return Class1403.smethod_3(num2, num, num4, num3, int_, int_2);
	}

	public static Bitmap smethod_35(int int_0, int int_1)
	{
		Bitmap bitmap = new Bitmap(int_0, int_1, PixelFormat.Format32bppArgb);
		bitmap.SetResolution(float_0, float_0);
		return bitmap;
	}

	internal static Bitmap smethod_36(Bitmap bitmap_0)
	{
		Bitmap bitmap = smethod_35(bitmap_0.Width, bitmap_0.Height);
		bitmap.SetResolution(bitmap_0.HorizontalResolution, bitmap_0.VerticalResolution);
		Graphics graphics = Graphics.FromImage(bitmap);
		graphics.Clear(Color.White);
		graphics.DrawImage(bitmap_0, 0, 0);
		return bitmap;
	}

	[Attribute0(true)]
	internal static void smethod_37(Image image_0, Stream stream_0)
	{
		Bitmap bitmap = smethod_35(image_0.Width, image_0.Height);
		bitmap.SetResolution(image_0.HorizontalResolution, image_0.VerticalResolution);
		Graphics graphics = Graphics.FromImage(bitmap);
		graphics.Clear(Color.White);
		graphics.DrawImage(image_0, 0, 0);
		bitmap.Save(stream_0, ImageFormat.Bmp);
	}

	[Attribute0(true)]
	internal static void smethod_38(Image image_0, Stream stream_0)
	{
		Bitmap bitmap = smethod_35(image_0.Width, image_0.Height);
		bitmap.MakeTransparent();
		bitmap.SetResolution(image_0.HorizontalResolution, image_0.VerticalResolution);
		Graphics graphics = Graphics.FromImage(bitmap);
		graphics.DrawImage(image_0, 0, 0);
		bitmap.Save(stream_0, ImageFormat.Png);
		graphics.Dispose();
	}

	public static ImageCodecInfo smethod_39(string string_0)
	{
		ImageCodecInfo[] imageEncoders = ImageCodecInfo.GetImageEncoders();
		int num = 0;
		while (true)
		{
			if (num < imageEncoders.Length)
			{
				if (imageEncoders[num].MimeType == string_0)
				{
					break;
				}
				num++;
				continue;
			}
			return null;
		}
		return imageEncoders[num];
	}

	[Attribute0(true)]
	public static void smethod_40(Image image_0, Stream stream_0, long long_0)
	{
		EncoderParameter encoderParameter = new EncoderParameter(Encoder.Quality, long_0);
		ImageCodecInfo encoder = smethod_39("image/jpeg");
		EncoderParameters encoderParameters = new EncoderParameters(1);
		encoderParameters.Param[0] = encoderParameter;
		image_0.Save(stream_0, encoder, encoderParameters);
	}

	public static Image smethod_41(Image image_0)
	{
		Bitmap bitmap = smethod_35(image_0.Width, image_0.Height);
		bitmap.SetResolution(image_0.HorizontalResolution, image_0.VerticalResolution);
		Graphics graphics = Graphics.FromImage(bitmap);
		graphics.Clear(Color.White);
		graphics.DrawImage(image_0, new Point(0, 0));
		return bitmap;
	}

	public static Bitmap smethod_42(Bitmap bitmap_0, double double_0)
	{
		double_0 = ((double_0 > 1.0) ? 1.0 : double_0);
		double_0 = ((double_0 < 0.5) ? 0.5 : double_0);
		Bitmap bitmap = new Bitmap(bitmap_0.Width, bitmap_0.Height, PixelFormat.Format24bppRgb);
		Graphics graphics = Graphics.FromImage(bitmap);
		if (double_0 == 0.5)
		{
			graphics.CompositingQuality = CompositingQuality.HighSpeed;
			graphics.SmoothingMode = SmoothingMode.HighSpeed;
			graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
		}
		if (double_0 == 1.0)
		{
			graphics.CompositingQuality = CompositingQuality.HighQuality;
			graphics.SmoothingMode = SmoothingMode.HighQuality;
			graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
		}
		else
		{
			graphics.CompositingQuality = CompositingQuality.HighQuality;
			graphics.SmoothingMode = SmoothingMode.HighQuality;
			graphics.InterpolationMode = InterpolationMode.HighQualityBilinear;
		}
		Rectangle rect = new Rectangle(0, 0, bitmap_0.Width, bitmap_0.Height);
		graphics.DrawImage(bitmap_0, rect);
		Bitmap result = new Bitmap(bitmap);
		graphics.Dispose();
		bitmap.Dispose();
		bitmap_0.Dispose();
		return result;
	}

	public static Bitmap smethod_43(int int_0, int int_1)
	{
		return new Bitmap(int_0, int_1, PixelFormat.Format32bppArgb);
	}
}
