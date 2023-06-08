using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using ns218;
using ns221;
using ns264;

namespace ns233;

internal static class Class6148
{
	private const double double_0 = 39.37007874015748;

	public const float float_0 = 96f;

	public const int int_0 = 300;

	[Attribute1]
	public static Enum788 smethod_0(byte[] data)
	{
		if (data != null && data.Length != 0)
		{
			try
			{
				if (smethod_12(data))
				{
					return Enum788.const_2;
				}
				if (smethod_13(data))
				{
					return Enum788.const_2;
				}
				if (smethod_15(data))
				{
					return Enum788.const_1;
				}
				if (smethod_6(data))
				{
					return Enum788.const_4;
				}
				if (smethod_7(data))
				{
					return Enum788.const_5;
				}
				if (smethod_8(data))
				{
					return Enum788.const_6;
				}
				if (smethod_10(data))
				{
					return Enum788.const_3;
				}
				if (smethod_9(data))
				{
					return Enum788.const_7;
				}
				if (smethod_5(data))
				{
					return Enum788.const_8;
				}
			}
			catch (Exception)
			{
			}
			return Enum788.const_0;
		}
		return Enum788.const_0;
	}

	public static string smethod_1(Enum788 imageType)
	{
		return imageType switch
		{
			Enum788.const_1 => "emf", 
			Enum788.const_2 => "wmf", 
			Enum788.const_3 => "pict", 
			Enum788.const_4 => "jpeg", 
			Enum788.const_5 => "png", 
			Enum788.const_6 => "bmp", 
			Enum788.const_7 => "gif", 
			Enum788.const_8 => "tif", 
			_ => throw new InvalidOperationException("Cannot convert image type to string."), 
		};
	}

	public static Enum788 smethod_2(string path)
	{
		string extension = Path.GetExtension(path);
		if (!Class5964.smethod_20(extension))
		{
			return Enum788.const_0;
		}
		switch (extension.Substring(1).ToLower())
		{
		case "bmp":
			return Enum788.const_6;
		case "emf":
			return Enum788.const_1;
		case "jpg":
		case "jpeg":
			return Enum788.const_4;
		case "png":
			return Enum788.const_5;
		case "wmf":
			return Enum788.const_2;
		case "pict":
		case "pct":
			return Enum788.const_3;
		case "gif":
			return Enum788.const_7;
		case "tif":
		case "tiff":
			return Enum788.const_8;
		default:
			return Enum788.const_0;
		}
	}

	public static Class6147 smethod_3(byte[] imageBytes)
	{
		return smethod_4(imageBytes, smethod_0(imageBytes));
	}

	[Attribute1]
	public static Class6147 smethod_4(byte[] imageBytes, Enum788 imageType)
	{
		return imageType switch
		{
			Enum788.const_1 => smethod_34(imageBytes), 
			Enum788.const_2 => smethod_32(imageBytes), 
			Enum788.const_3 => smethod_35(imageBytes), 
			Enum788.const_4 => smethod_27(imageBytes), 
			Enum788.const_5 => smethod_26(imageBytes), 
			Enum788.const_6 => smethod_24(imageBytes), 
			Enum788.const_7 => smethod_25(imageBytes), 
			Enum788.const_8 => smethod_31(imageBytes), 
			_ => Class6147.smethod_1(100, 100, 96.0, 96.0), 
		};
	}

	public static bool smethod_5(byte[] data)
	{
		return Class6149.smethod_0(data);
	}

	public static bool smethod_6(byte[] data)
	{
		using MemoryStream input = new MemoryStream(data);
		BinaryReader binaryReader = new BinaryReader(input);
		uint num = binaryReader.ReadUInt16();
		if (num != 55551)
		{
			return false;
		}
		return true;
	}

	public static bool smethod_7(byte[] data)
	{
		using MemoryStream input = new MemoryStream(data);
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

	public static bool smethod_8(byte[] data)
	{
		using MemoryStream input = new MemoryStream(data);
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

	public static bool smethod_9(byte[] data)
	{
		using MemoryStream input = new MemoryStream(data);
		BinaryReader binaryReader = new BinaryReader(input);
		int num = binaryReader.ReadInt32() & 0xFFFFFF;
		return num == 4606279;
	}

	public static bool smethod_10(byte[] data)
	{
		using MemoryStream input = new MemoryStream(data);
		BinaryReader binaryReader = new BinaryReader(input);
		binaryReader.ReadUInt16();
		binaryReader.ReadUInt16();
		binaryReader.ReadUInt16();
		binaryReader.ReadUInt16();
		binaryReader.ReadUInt16();
		switch (Class5952.smethod_3(binaryReader.ReadUInt16()))
		{
		case 273:
			return true;
		case 17:
		{
			int num = Class5952.smethod_3(binaryReader.ReadUInt16());
			if (num == 767)
			{
				return true;
			}
			break;
		}
		}
		return false;
	}

	public static bool smethod_11(byte[] data)
	{
		using MemoryStream input = new MemoryStream(data);
		BinaryReader binaryReader = new BinaryReader(input);
		uint num = binaryReader.ReadUInt16();
		if (num != 40)
		{
			return false;
		}
		return true;
	}

	public static bool smethod_12(byte[] imageBytes)
	{
		using MemoryStream input = new MemoryStream(imageBytes);
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

	public static bool smethod_13(byte[] imageBytes)
	{
		using MemoryStream input = new MemoryStream(imageBytes);
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

	public static bool smethod_14(byte[] imageBytes)
	{
		if (!smethod_12(imageBytes))
		{
			return smethod_13(imageBytes);
		}
		return true;
	}

	public static bool smethod_15(byte[] imageBytes)
	{
		using MemoryStream input = new MemoryStream(imageBytes);
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

	public static bool smethod_16(Enum788 imageType)
	{
		if (imageType != Enum788.const_2)
		{
			return imageType == Enum788.const_1;
		}
		return true;
	}

	public static bool smethod_17(byte[] imageBytes)
	{
		return smethod_16(smethod_0(imageBytes));
	}

	public static Enum868 smethod_18(byte[] imageBytes)
	{
		if (smethod_15(imageBytes))
		{
			using (MemoryStream input = new MemoryStream(imageBytes))
			{
				BinaryReader binaryReader = new BinaryReader(input);
				binaryReader.ReadUInt32();
				uint num = binaryReader.ReadUInt32();
				binaryReader.BaseStream.Position = num;
				uint num2 = binaryReader.ReadUInt32();
				if (num2 != 70)
				{
					return Enum868.const_3;
				}
				binaryReader.ReadInt32();
				binaryReader.ReadInt32();
				int num3 = binaryReader.ReadInt32();
				if (num3 == 726027589)
				{
					int num4 = binaryReader.ReadUInt16();
					if (num4 != 16385)
					{
						return Enum868.const_3;
					}
					int num5 = binaryReader.ReadUInt16();
					if ((num5 & 1) == 1)
					{
						return Enum868.const_5;
					}
					return Enum868.const_4;
				}
				return Enum868.const_3;
			}
		}
		return Enum868.const_0;
	}

	public static Enum868 smethod_19(byte[] imageBytes)
	{
		if (smethod_12(imageBytes))
		{
			return Enum868.const_1;
		}
		if (smethod_13(imageBytes))
		{
			return Enum868.const_2;
		}
		return smethod_18(imageBytes);
	}

	public static Enum868 smethod_20(Stream stream)
	{
		stream.Position = 0L;
		return smethod_19(Class5964.smethod_8(stream, 512));
	}

	public static byte[] smethod_21(BinaryReader reader, int dibLength)
	{
		int num = (int)reader.BaseStream.Position;
		Class6137 @class = new Class6137();
		@class.Read(reader);
		reader.BaseStream.Position = num;
		byte[] array = new byte[14 + dibLength];
		using MemoryStream output = new MemoryStream(array);
		BinaryWriter binaryWriter = new BinaryWriter(output);
		Class6136 class2 = new Class6136();
		class2.uint_0 = (uint)(14 + dibLength);
		class2.uint_1 = (uint)(54 + @class.ColorTableSize);
		class2.Write(binaryWriter);
		binaryWriter.Flush();
		reader.Read(array, 14, dibLength);
		return array;
	}

	public static byte[] smethod_22(BinaryReader reader, int headerLength, int bmpLength)
	{
		int num = (int)reader.BaseStream.Position;
		Class6137 @class = new Class6137();
		@class.Read(reader);
		int num2 = 40 + @class.ColorTableSize;
		byte[] buffer = reader.ReadBytes(@class.ColorTableSize);
		reader.BaseStream.Position = num + headerLength;
		byte[] array = new byte[14 + num2 + bmpLength];
		using MemoryStream output = new MemoryStream(array);
		BinaryWriter binaryWriter = new BinaryWriter(output);
		Class6136 class2 = new Class6136();
		class2.uint_0 = (uint)(14 + num2 + bmpLength);
		class2.uint_1 = (uint)(14 + num2);
		class2.Write(binaryWriter);
		@class.Write(binaryWriter);
		binaryWriter.Write(buffer);
		binaryWriter.Flush();
		reader.Read(array, 14 + num2, bmpLength);
		return array;
	}

	public static byte[] smethod_23(int width, int height, int pixelsPerMeterX, int pixelsPerMeterY, int planes, int bitsPerPixel, int ddbWidthData, byte[] ddbData)
	{
		if (planes != 1)
		{
			throw new InvalidOperationException("Expected 1 plane only here.");
		}
		if (bitsPerPixel != 1)
		{
			throw new InvalidOperationException("Expected 1 bit per pixel only here.");
		}
		int num = 62 + ddbData.Length * 2;
		byte[] array = new byte[num];
		using MemoryStream output = new MemoryStream(array);
		BinaryWriter binaryWriter = new BinaryWriter(output);
		Class6136 @class = new Class6136();
		@class.uint_0 = (uint)num;
		@class.uint_1 = 62u;
		@class.Write(binaryWriter);
		Class6137 class2 = new Class6137();
		class2.int_2 = width;
		class2.int_3 = height;
		class2.ushort_0 = (ushort)planes;
		class2.ushort_1 = (ushort)bitsPerPixel;
		class2.int_4 = pixelsPerMeterX;
		class2.int_5 = pixelsPerMeterY;
		class2.Write(binaryWriter);
		binaryWriter.Write(0);
		binaryWriter.Write(16777215);
		binaryWriter.Flush();
		int num2 = Class5964.smethod_6(ddbWidthData, 4);
		int num3 = num2 - ddbWidthData;
		int num4 = (int)@class.uint_1;
		for (int num5 = height - 1; num5 >= 0; num5--)
		{
			for (int i = 0; i < ddbWidthData; i++)
			{
				int num6 = num5 * ddbWidthData + i;
				array[num4] = ddbData[num6];
				num4++;
			}
			for (int j = 0; j < num3; j++)
			{
				array[num4] = 0;
				num4++;
			}
		}
		return array;
	}

	public static Class6147 smethod_24(byte[] imageBytes)
	{
		using MemoryStream memoryStream = new MemoryStream(imageBytes);
		memoryStream.Position = 14L;
		BinaryReader reader = new BinaryReader(memoryStream);
		Class6137 @class = new Class6137();
		@class.Read(reader);
		return Class6147.smethod_1(@class.int_2, Math.Abs(@class.int_3), smethod_44(@class.int_4), smethod_44(@class.int_5));
	}

	public static Class6147 smethod_25(byte[] imageBytes)
	{
		using MemoryStream memoryStream = new MemoryStream(imageBytes);
		memoryStream.Position = 6L;
		BinaryReader binaryReader = new BinaryReader(memoryStream);
		ushort width = binaryReader.ReadUInt16();
		ushort height = binaryReader.ReadUInt16();
		return Class6147.smethod_1(width, height, 0.0, 0.0);
	}

	public static Class6147 smethod_26(byte[] imageBytes)
	{
		using MemoryStream memoryStream = new MemoryStream(imageBytes);
		Class5950 @class = new Class5950(memoryStream);
		memoryStream.Position = 8L;
		int width = 0;
		int height = 0;
		double hRes = 0.0;
		double vRes = 0.0;
		bool flag = false;
		while (!flag && memoryStream.Position < memoryStream.Length)
		{
			uint num = @class.method_1();
			switch (new string(@class.method_10(4)))
			{
			case "IEND":
				flag = true;
				break;
			case "pHYs":
			{
				int pixelsPerMeter = (int)@class.method_1();
				int pixelsPerMeter2 = (int)@class.method_1();
				short num2 = @class.ReadByte();
				if (num2 == 1)
				{
					hRes = smethod_44(pixelsPerMeter);
					vRes = smethod_44(pixelsPerMeter2);
				}
				flag = true;
				break;
			}
			case "IHDR":
				width = @class.method_0();
				height = @class.method_0();
				memoryStream.Seek(-8L, SeekOrigin.Current);
				break;
			}
			memoryStream.Seek(num + 4, SeekOrigin.Current);
		}
		return Class6147.smethod_1(width, height, hRes, vRes);
	}

	public static Class6147 smethod_27(byte[] imageBytes)
	{
		using MemoryStream memoryStream = new MemoryStream(imageBytes);
		Class5950 @class = new Class5950(memoryStream);
		@class.method_3();
		ushort num = @class.method_3();
		PointF resolution = PointF.Empty;
		while ((num & 0xFFF0) != 65472 || num == 65476 || num == 65484)
		{
			if (!smethod_28(num, @class, ref resolution))
			{
				ushort num2 = @class.method_3();
				memoryStream.Seek(num2 - 2, SeekOrigin.Current);
			}
			num = @class.method_3();
		}
		memoryStream.Seek(3L, SeekOrigin.Current);
		int height = @class.method_3();
		int width = @class.method_3();
		return Class6147.smethod_1(width, height, resolution.X, resolution.Y);
	}

	private static bool smethod_28(ushort marker, Class5950 reader, ref PointF resolution)
	{
		switch (marker)
		{
		case 65504:
			smethod_29(reader, ref resolution);
			return true;
		case 65505:
			smethod_30(reader, ref resolution);
			return true;
		default:
			return false;
		}
	}

	private static void smethod_29(Class5950 reader, ref PointF resolution)
	{
		ushort num = reader.method_3();
		reader.BaseStream.Seek(7L, SeekOrigin.Current);
		short num2 = reader.ReadByte();
		ushort num3 = reader.method_3();
		ushort num4 = reader.method_3();
		switch (num2)
		{
		case 1:
			resolution = new PointF((int)num3, (int)num4);
			break;
		case 2:
			resolution = new PointF((float)((double)(int)num3 * 2.54), (float)((double)(int)num4 * 2.54));
			break;
		}
		reader.BaseStream.Seek(num - 14, SeekOrigin.Current);
	}

	private static void smethod_30(Class5950 reader, ref PointF resolution)
	{
		long position = reader.BaseStream.Position;
		ushort num = reader.method_3();
		string text = new string(reader.method_10(6));
		if (text.StartsWith("Exif"))
		{
			Class6149 @class = new Class6149(reader);
			if (@class.ImageXResolution > 0.0 && @class.ImageYResolution > 0.0)
			{
				resolution = new PointF((float)@class.ImageXResolution, (float)@class.ImageYResolution);
			}
		}
		reader.BaseStream.Position = position + num;
	}

	public static Class6147 smethod_31(byte[] imageBytes)
	{
		Class6149 @class = new Class6149(imageBytes);
		return Class6147.smethod_1(@class.ImageWidth, @class.ImageHeight, @class.ImageXResolution, @class.ImageYResolution);
	}

	public static Class6147 smethod_32(byte[] imageBytes)
	{
		if (smethod_12(imageBytes))
		{
			return smethod_33(imageBytes);
		}
		if (smethod_13(imageBytes))
		{
			using (MemoryStream input = new MemoryStream(imageBytes))
			{
				BinaryReader reader = new BinaryReader(input);
				Class6500 @class = new Class6500();
				@class.Read(reader);
				RectangleF bounds = @class.Bounds;
				Class6147 class2 = Class6147.smethod_2((int)bounds.Left, (int)bounds.Top, (int)bounds.Right, (int)bounds.Bottom, @class.Inch, @class.Inch);
				if (class2.Width <= 0 && class2.Height <= 0)
				{
					return smethod_33(imageBytes);
				}
				return class2;
			}
		}
		throw new InvalidOperationException("Unexpected image type.");
	}

	private static Class6147 smethod_33(byte[] imageBytes)
	{
		Class6496 @class = new Class6496(imageBytes);
		return Class6147.smethod_1((int)@class.SizePixels.Width, (int)@class.SizePixels.Height, @class.HorizontalResolution, @class.VerticalResolution);
	}

	public static Class6147 smethod_34(byte[] imageBytes)
	{
		using MemoryStream input = new MemoryStream(imageBytes);
		BinaryReader reader = new BinaryReader(input);
		Class6497 @class = new Class6497();
		@class.Read(reader);
		Rectangle boundsPixels = @class.BoundsPixels;
		return Class6147.smethod_2(boundsPixels.Left, boundsPixels.Top, boundsPixels.Right, boundsPixels.Bottom, @class.HorizontalResolution, @class.VerticalResolution);
	}

	public static Class6147 smethod_35(byte[] imageBytes)
	{
		using MemoryStream input = new MemoryStream(imageBytes);
		BinaryReader binaryReader = new BinaryReader(input);
		binaryReader.ReadUInt16();
		int num = Class5952.smethod_3(binaryReader.ReadUInt16());
		int num2 = Class5952.smethod_3(binaryReader.ReadUInt16());
		int num3 = Class5952.smethod_3(binaryReader.ReadUInt16());
		int num4 = Class5952.smethod_3(binaryReader.ReadUInt16());
		int widthEmus = Class5955.smethod_38(num4 - num2);
		int heightEmus = Class5955.smethod_38(num3 - num);
		return Class6147.smethod_3(num2, num, num4, num3, widthEmus, heightEmus);
	}

	public static byte[] smethod_36(byte[] imageBytes, Class6147 imageSize)
	{
		using MemoryStream memoryStream = new MemoryStream();
		BinaryWriter binaryWriter = new BinaryWriter(memoryStream, Encoding.Unicode);
		int num = 0;
		binaryWriter.Write((ushort)52695);
		num = 52695;
		binaryWriter.Write((ushort)39622);
		num = 22289;
		binaryWriter.Write((short)0);
		num = 22289;
		binaryWriter.Write((short)imageSize.Left);
		num = 0x5711 ^ imageSize.Left;
		binaryWriter.Write((short)imageSize.Top);
		num ^= imageSize.Top;
		binaryWriter.Write((short)imageSize.Right);
		num ^= imageSize.Right;
		binaryWriter.Write((short)imageSize.Bottom);
		num ^= imageSize.Bottom;
		binaryWriter.Write((short)imageSize.HorizontalResolution);
		num ^= (int)imageSize.HorizontalResolution;
		binaryWriter.Write((short)0);
		num = num;
		binaryWriter.Write((short)0);
		num = num;
		binaryWriter.Write((ushort)num);
		binaryWriter.Write(imageBytes);
		return memoryStream.ToArray();
	}

	public static byte[] smethod_37(byte[] imageBytes)
	{
		if (smethod_13(imageBytes))
		{
			byte[] array = new byte[imageBytes.Length - 22];
			Array.Copy(imageBytes, 22, array, 0, array.Length);
			return array;
		}
		return imageBytes;
	}

	public static byte[] smethod_38(byte[] bmpBytes)
	{
		MemoryStream memoryStream = new MemoryStream(bmpBytes);
		BinaryReader reader = new BinaryReader(memoryStream);
		Class6136 @class = new Class6136();
		@class.Read(reader);
		Class6137 class2 = new Class6137();
		class2.Read(reader);
		memoryStream.Seek(-40L, SeekOrigin.Current);
		byte[] array = new byte[bmpBytes.Length - 14];
		memoryStream.Read(array, 0, array.Length);
		int num = (array.Length + 26 + 1) / 2;
		MemoryStream memoryStream2 = new MemoryStream();
		BinaryWriter binaryWriter = new BinaryWriter(memoryStream2);
		binaryWriter.Write((ushort)1);
		binaryWriter.Write((ushort)9);
		binaryWriter.Write((ushort)768);
		binaryWriter.Write((uint)(30 + num + 4 + 3));
		binaryWriter.Write((ushort)0);
		binaryWriter.Write((uint)num);
		binaryWriter.Write((ushort)0);
		binaryWriter.Write(4u);
		binaryWriter.Write((ushort)259);
		binaryWriter.Write((ushort)8);
		binaryWriter.Write(5u);
		binaryWriter.Write((ushort)523);
		binaryWriter.Write((ushort)0);
		binaryWriter.Write((ushort)0);
		binaryWriter.Write(5u);
		binaryWriter.Write((ushort)524);
		binaryWriter.Write((ushort)(class2.int_3 + 1));
		binaryWriter.Write((ushort)(class2.int_2 + 1));
		binaryWriter.Write(3u);
		binaryWriter.Write((ushort)30);
		binaryWriter.Write(4u);
		binaryWriter.Write((ushort)263);
		binaryWriter.Write((ushort)4);
		binaryWriter.Write((uint)num);
		binaryWriter.Write((ushort)2881);
		binaryWriter.Write(13369376u);
		binaryWriter.Write((ushort)class2.int_3);
		binaryWriter.Write((ushort)class2.int_2);
		binaryWriter.Write((ushort)0);
		binaryWriter.Write((ushort)0);
		binaryWriter.Write((ushort)class2.int_3);
		binaryWriter.Write((ushort)class2.int_2);
		binaryWriter.Write((ushort)0);
		binaryWriter.Write((ushort)0);
		binaryWriter.Write(array);
		if (Class5964.smethod_4(array.Length))
		{
			binaryWriter.Write((byte)0);
		}
		binaryWriter.Write(4u);
		binaryWriter.Write((ushort)295);
		binaryWriter.Write(ushort.MaxValue);
		binaryWriter.Write(3u);
		binaryWriter.Write((ushort)0);
		binaryWriter.Close();
		return memoryStream2.ToArray();
	}

	public static byte[] smethod_39(int width, int height)
	{
		MemoryStream memoryStream = new MemoryStream();
		BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
		binaryWriter.Write((ushort)1);
		binaryWriter.Write((ushort)9);
		binaryWriter.Write((ushort)768);
		binaryWriter.Write(26u);
		binaryWriter.Write((ushort)0);
		binaryWriter.Write(5u);
		binaryWriter.Write((ushort)0);
		binaryWriter.Write(4u);
		binaryWriter.Write((ushort)259);
		binaryWriter.Write((ushort)8);
		binaryWriter.Write(5u);
		binaryWriter.Write((ushort)523);
		binaryWriter.Write((ushort)0);
		binaryWriter.Write((ushort)0);
		binaryWriter.Write(5u);
		binaryWriter.Write((ushort)524);
		binaryWriter.Write((ushort)(width + 1));
		binaryWriter.Write((ushort)(height + 1));
		binaryWriter.Write(3u);
		binaryWriter.Write((ushort)0);
		binaryWriter.Close();
		return memoryStream.ToArray();
	}

	public static byte[] smethod_40(byte[] imageBytes)
	{
		Class6147 @class = smethod_3(imageBytes);
		SizeF resolution = new SizeF((float)@class.HorizontalResolution, (float)@class.VerticalResolution);
		if (resolution.Height == 0f && resolution.Width != 0f)
		{
			resolution = new SizeF(resolution.Width, resolution.Width);
		}
		else if (resolution.Height != 0f && resolution.Width == 0f)
		{
			resolution = new SizeF(resolution.Height, resolution.Height);
		}
		else if (resolution.Height == 0f && resolution.Width == 0f)
		{
			resolution = new SizeF(96f, 96f);
		}
		return smethod_41(imageBytes, resolution);
	}

	public static byte[] smethod_41(byte[] imageBytes, SizeF resolution)
	{
		using Image image = Image.FromStream(new MemoryStream(imageBytes));
		int num = 300;
		int width;
		int height;
		while (true)
		{
			float num2 = (float)num / resolution.Height;
			float num3 = (float)num / resolution.Width;
			width = (int)((float)image.Size.Width * num3);
			height = (int)((float)image.Size.Height * num2);
			if (!smethod_43(width, height))
			{
				break;
			}
			num /= 2;
		}
		using Bitmap bitmap = new Bitmap(width, height);
		bitmap.SetResolution(num, num);
		using (Graphics graphics = smethod_42(bitmap))
		{
			graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
			graphics.DrawImage(image, 0, 0);
		}
		using MemoryStream memoryStream = new MemoryStream();
		bitmap.Save(memoryStream, ImageFormat.Png);
		return Class5964.smethod_11(memoryStream);
	}

	public static Graphics smethod_42(Image image)
	{
		return Graphics.FromImage(image);
	}

	public static bool smethod_43(int width, int height)
	{
		return width * height > 20971520;
	}

	internal static double smethod_44(int pixelsPerMeter)
	{
		return (double)pixelsPerMeter / 39.37007874015748;
	}

	internal static int smethod_45(double dpi)
	{
		return (int)(dpi * 39.37007874015748);
	}
}
