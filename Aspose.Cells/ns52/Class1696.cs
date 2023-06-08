using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.CompilerServices;
using ns18;
using ns2;
using ns22;

namespace ns52;

internal class Class1696
{
	private byte byte_0 = 5;

	private Class1704 class1704_0;

	private Class1695 class1695_0;

	private int int_0;

	private int int_1;

	private int int_2;

	public ImageFormat ImageFormat
	{
		get
		{
			if (method_4() != null && method_4().method_6() != null)
			{
				switch (method_11())
				{
				default:
					return ImageFormat.Bmp;
				case 253:
					return ImageFormat.Gif;
				case 252:
				case 254:
					return ImageFormat.Bmp;
				case 0:
				case 1:
				case 32:
				case byte.MaxValue:
					return GetFormat(method_4().method_6());
				case 2:
					return ImageFormat.Emf;
				case 3:
					return ImageFormat.Wmf;
				case 4:
					return ImageFormat.Emf;
				case 5:
					return ImageFormat.Jpeg;
				case 6:
					return ImageFormat.Png;
				case 7:
					return ImageFormat.Bmp;
				}
			}
			return ImageFormat.Bmp;
		}
	}

	internal byte[] ImageData
	{
		get
		{
			if (method_4().method_6() == null)
			{
				return null;
			}
			switch (method_11())
			{
			default:
				return null;
			case 253:
				return method_4().method_6();
			case 252:
			case 254:
				return method_4().method_6();
			case 0:
			case 1:
			case 32:
			case byte.MaxValue:
				return method_4().method_6();
			case 2:
				return Class766.smethod_1(bool_0: false, bool_1: false, Width, Height, method_9(), method_4().method_6(), method_4().int_0);
			case 3:
				return Class766.smethod_1(bool_0: true, bool_1: false, Width, Height, method_9(), method_4().method_6(), method_4().int_0);
			case 4:
				return Class766.smethod_1(bool_0: false, bool_1: true, Width, Height, method_9(), method_4().method_6(), method_4().int_0);
			case 5:
				return method_4().method_6();
			case 6:
				return method_4().method_6();
			case 7:
				return smethod_1(method_4().method_6());
			}
		}
	}

	internal uint Length
	{
		get
		{
			uint length = class1695_0.Length;
			if (length != 0)
			{
				return length + 8 + 36;
			}
			return 36u;
		}
	}

	internal int Width
	{
		get
		{
			return int_0;
		}
		set
		{
			int_0 = value;
		}
	}

	internal int Height
	{
		get
		{
			return int_1;
		}
		set
		{
			int_1 = value;
		}
	}

	internal Class1696(byte[] byte_1, int int_3)
	{
		method_0(byte_1, int_3, int_3);
	}

	internal Class1696()
	{
		int_2 = 96;
		class1704_0 = new Class1704();
		class1695_0 = new Class1695(this);
	}

	internal void method_0(byte[] byte_1, int int_3, int int_4)
	{
		int num = byte_1.Length;
		MemoryStream memoryStream = new MemoryStream(byte_1);
		int[] array = smethod_0(memoryStream, int_3, int_4);
		byte b = (byte)array[0];
		int num2 = array[1];
		int num3 = array[2];
		switch (b)
		{
		default:
		{
			b = 6;
			MemoryStream memoryStream4 = new MemoryStream();
			Bitmap bitmap2 = (Bitmap)Image.FromStream(memoryStream);
			if (array[4] == 0)
			{
				bitmap2.SetResolution(96f, 96f);
			}
			bitmap2.Save(memoryStream4, ImageFormat.Png);
			bitmap2.Dispose();
			byte_1 = memoryStream4.ToArray();
			if (array[4] == 0)
			{
				Class1403 class3 = Class1404.smethod_23(byte_1);
				num2 = (int)(class3.method_0() * (double)int_3 / 72.0 + 0.5);
				num3 = (int)(class3.method_1() * (double)int_4 / 72.0 + 0.5);
			}
			memoryStream4.Close();
			break;
		}
		case 253:
		{
			b = 6;
			MemoryStream memoryStream2 = new MemoryStream();
			Bitmap bitmap = (Bitmap)Image.FromStream(memoryStream);
			if (array[4] == 0)
			{
				bitmap.SetResolution(96f, 96f);
			}
			bitmap.Save(memoryStream2, ImageFormat.Png);
			bitmap.Dispose();
			if (array[4] == 0)
			{
				byte[] array2 = memoryStream2.ToArray();
				Class1403 @class = Class1404.smethod_23(array2);
				num2 = (int)(@class.method_0() * (double)int_3 / 72.0 + 0.5);
				num3 = (int)(@class.method_1() * (double)int_4 / 72.0 + 0.5);
			}
			memoryStream2.Position = 0L;
			MemoryStream memoryStream3 = new MemoryStream();
			Class769 class2 = new Class769(byte_1, memoryStream3);
			class2.vmethod_0(memoryStream2);
			memoryStream2.Close();
			byte_1 = memoryStream3.ToArray();
			memoryStream3.Close();
			break;
		}
		case 2:
		case 3:
		case 4:
			num = (int)(memoryStream.Length - memoryStream.Position);
			byte_1 = new byte[num];
			memoryStream.Read(byte_1, 0, byte_1.Length);
			byte_1 = Class766.smethod_0(byte_1);
			break;
		case 5:
		case 6:
			byte_1 = new byte[(int)memoryStream.Length];
			memoryStream.Read(byte_1, 0, byte_1.Length);
			break;
		}
		byte[] byte_2 = Class1026.smethod_0(byte_1);
		class1704_0 = new Class1704();
		class1704_0.byte_2 = byte_2;
		byte_0 = b;
		class1704_0.byte_0 = b;
		class1704_0.byte_1 = b;
		class1695_0 = new Class1695(this, byte_1, num);
		int_2 = array[3];
		int_1 = num3;
		int_0 = num2;
		int_2 = array[3];
	}

	internal static int[] smethod_0(Stream stream_0, int int_3, int int_4)
	{
		int[] array = new int[5] { 1, 0, 0, 0, 0 };
		byte[] array2 = null;
		try
		{
			array2 = new byte[(int)stream_0.Length];
			stream_0.Read(array2, 0, array2.Length);
			Enum200 @enum = Class1404.smethod_1(array2);
			Class1403 @class = Class1404.smethod_4(array2);
			switch (@enum)
			{
			case Enum200.const_0:
				array[0] = 1;
				break;
			case Enum200.const_1:
				array[0] = 2;
				break;
			case Enum200.const_2:
				array[0] = 3;
				break;
			case Enum200.const_3:
				array[0] = 4;
				break;
			case Enum200.const_4:
				array[0] = 5;
				break;
			case Enum200.const_5:
				array[0] = 6;
				break;
			case Enum200.const_6:
				array[0] = 254;
				break;
			case Enum200.const_7:
				array[0] = 253;
				break;
			case Enum200.const_8:
				array[0] = 1;
				break;
			}
			array[1] = (int)(@class.method_0() * (double)int_3 / 72.0 + 0.5);
			array[2] = (int)(@class.method_1() * (double)int_3 / 72.0 + 0.5);
			array[3] = (int)@class.HorizontalResolution;
			array[4] = ((array[3] != 96) ? 1 : 0);
		}
		catch (Exception)
		{
			return array;
		}
		if (stream_0.CanSeek)
		{
			if (array[0] == 3)
			{
				if (array2 != null)
				{
					if (BitConverter.ToInt32(array2, 0) == -1698247209)
					{
						stream_0.Seek(22L, SeekOrigin.Begin);
					}
					else
					{
						stream_0.Seek(0L, SeekOrigin.Begin);
					}
				}
				else
				{
					stream_0.Seek(22L, SeekOrigin.Begin);
				}
			}
			else
			{
				stream_0.Seek(0L, SeekOrigin.Begin);
			}
		}
		return array;
	}

	internal static ImageFormat GetFormat(byte[] byte_1)
	{
		MemoryStream stream = new MemoryStream(byte_1);
		Image image = Image.FromStream(stream);
		return image.RawFormat;
	}

	internal static byte[] smethod_1(byte[] byte_1)
	{
		if (byte_1[0] == 66 && byte_1[1] == 77)
		{
			return byte_1;
		}
		try
		{
			BitConverter.ToInt32(byte_1, 20);
			byte[] array = new byte[byte_1.Length + 54];
			array[0] = 66;
			array[1] = 77;
			Array.Copy(BitConverter.GetBytes(array.Length), 0, array, 2, 4);
			array[10] = 54;
			Array.Copy(byte_1, 0, array, 14, byte_1.Length);
			return array;
		}
		catch
		{
			return byte_1;
		}
	}

	internal void Copy(Class1696 class1696_0)
	{
		class1704_0 = new Class1704();
		class1704_0.Copy(class1696_0.method_5());
		byte_0 = class1696_0.byte_0;
		class1695_0 = new Class1695(this);
		class1695_0.Copy(class1696_0.class1695_0);
		int_1 = class1696_0.int_1;
		int_0 = class1696_0.int_0;
	}

	[SpecialName]
	internal int method_1()
	{
		if (method_4().method_6() == null)
		{
			return 36;
		}
		return class1695_0.method_8() + 8 + 36;
	}

	internal void SetHeader(byte[] byte_1)
	{
		ushort num = 2;
		num = (ushort)(2u | (ushort)(byte_0 << 4));
		Array.Copy(BitConverter.GetBytes(num), 0, byte_1, 0, 2);
		byte_1[2] = 7;
		byte_1[3] = 240;
		uint length = method_4().Length;
		if (length == 0)
		{
			Array.Copy(BitConverter.GetBytes(length + 36), 0, byte_1, 4, 4);
		}
		else
		{
			Array.Copy(BitConverter.GetBytes(length + 8 + 36), 0, byte_1, 4, 4);
		}
		int num2 = 8;
		byte_1[8] = class1704_0.byte_0;
		byte_1[8 + 1] = class1704_0.byte_1;
		num2 = 8 + 2;
		Array.Copy(class1704_0.byte_2, 0, byte_1, 10, 16);
		num2 = 10 + 16;
		Array.Copy(BitConverter.GetBytes(class1704_0.short_0), 0, byte_1, 26, 2);
		Array.Copy(BitConverter.GetBytes(length + 8), 0, byte_1, 26 + 2, 4);
		Array.Copy(BitConverter.GetBytes(class1704_0.int_0), 0, byte_1, 26 + 6, 4);
		byte_1[26 + 14] = class1704_0.byte_3;
		byte_1[26 + 15] = 0;
		num2 = 26 + 18;
		if (method_4().method_6() == null)
		{
			return;
		}
		num = (ushort)(method_4().method_4() << 4);
		Array.Copy(BitConverter.GetBytes(num), 0, byte_1, num2, 2);
		num = method_4().method_2();
		Array.Copy(BitConverter.GetBytes(num), 0, byte_1, num2 + 2, 2);
		Array.Copy(BitConverter.GetBytes(length), 0, byte_1, num2 + 4, 4);
		num2 += 8;
		if (class1695_0.method_0() != null)
		{
			Array.Copy(class1695_0.method_0(), 0, byte_1, num2, class1695_0.method_0().Length);
			num2 += class1695_0.method_0().Length;
		}
		Array.Copy(class1704_0.byte_2, 0, byte_1, num2, 16);
		num2 += 16;
		if (method_4().method_9())
		{
			Array.Copy(BitConverter.GetBytes(method_4().int_0), 0, byte_1, num2, 4);
			num2 += 4;
			Array.Copy(BitConverter.GetBytes(0), 0, byte_1, num2, 4);
			Array.Copy(BitConverter.GetBytes(0), 0, byte_1, num2 + 4, 4);
			int num3 = Width;
			if (method_11() == 3 && int_2 != 96)
			{
				num3 = (int)((double)((float)(num3 * int_2) / 96f) + 0.5);
			}
			Array.Copy(BitConverter.GetBytes(num3), 0, byte_1, num2 + 8, 4);
			num3 = Height;
			if (method_11() == 3 && int_2 != 96)
			{
				num3 = (int)((double)((float)(num3 * int_2) / 96f) + 0.5);
			}
			Array.Copy(BitConverter.GetBytes(num3), 0, byte_1, num2 + 12, 4);
			num2 += 16;
			num3 = (int)((double)((float)Width / 96f * 914400f) + 0.5);
			Array.Copy(BitConverter.GetBytes(num3), 0, byte_1, num2, 4);
			num3 = (int)((double)((float)Height / 96f * 914400f) + 0.5);
			Array.Copy(BitConverter.GetBytes(num3), 0, byte_1, num2 + 4, 4);
			num2 += 8;
			num3 = method_4().method_6().Length;
			Array.Copy(BitConverter.GetBytes(num3), 0, byte_1, num2, 4);
			num2 += 4;
			byte_1[num2] = method_4().byte_2;
			byte_1[num2 + 1] = method_4().byte_3;
			num2 += 2;
		}
		else
		{
			byte_1[num2] = method_4().byte_4;
			num2++;
		}
	}

	[SpecialName]
	internal byte[] method_2()
	{
		uint length = method_4().Length;
		byte[] array = new byte[length + 8];
		int num = 0;
		ushort value = (ushort)(method_4().method_4() << 4);
		Array.Copy(BitConverter.GetBytes(value), 0, array, 0, 2);
		value = method_4().method_2();
		Array.Copy(BitConverter.GetBytes(value), 0, array, 0 + 2, 2);
		Array.Copy(BitConverter.GetBytes(length), 0, array, 0 + 4, 4);
		num = 0 + 8;
		if (class1695_0.method_0() != null)
		{
			Array.Copy(class1695_0.method_0(), 0, array, num, class1695_0.method_0().Length);
			num += class1695_0.method_0().Length;
		}
		Array.Copy(class1704_0.byte_2, 0, array, num, 16);
		num += 16;
		if (method_4().method_9())
		{
			Array.Copy(BitConverter.GetBytes(method_4().int_0), 0, array, num, 4);
			num += 4;
			Array.Copy(BitConverter.GetBytes(0), 0, array, num, 4);
			Array.Copy(BitConverter.GetBytes(0), 0, array, num + 4, 4);
			int num2 = Width;
			if (method_11() == 3 && int_2 != 96)
			{
				num2 = (int)((double)((float)(num2 * int_2) / 96f) + 0.5);
			}
			Array.Copy(BitConverter.GetBytes(num2), 0, array, num + 8, 4);
			num2 = Height;
			if (method_11() == 3 && int_2 != 96)
			{
				num2 = (int)((double)((float)(num2 * int_2) / 96f) + 0.5);
			}
			Array.Copy(BitConverter.GetBytes(num2), 0, array, num + 12, 4);
			num += 16;
			num2 = (int)((double)((float)Width / 96f * 914400f) + 0.5);
			Array.Copy(BitConverter.GetBytes(num2), 0, array, num, 4);
			num2 = (int)((double)((float)Height / 96f * 914400f) + 0.5);
			Array.Copy(BitConverter.GetBytes(num2), 0, array, num + 4, 4);
			num += 8;
			num2 = method_4().method_6().Length;
			Array.Copy(BitConverter.GetBytes(num2), 0, array, num, 4);
			num += 4;
			array[num] = method_4().byte_2;
			array[num + 1] = method_4().byte_3;
			num += 2;
		}
		else
		{
			array[num] = method_4().byte_4;
			num++;
		}
		if (method_4().method_6() != null)
		{
			Array.Copy(method_4().method_6(), 0, array, num, method_4().method_6().Length);
		}
		return array;
	}

	internal void method_3(byte[] byte_1, int int_3)
	{
		int_2 = int_3;
		class1704_0 = new Class1704();
		class1695_0 = new Class1695(this);
		int num = 0;
		Class1695 @class = class1695_0;
		@class.method_5((short)(BitConverter.ToUInt16(byte_1, 0) >> 4));
		@class.method_3(BitConverter.ToUInt16(byte_1, 0 + 2));
		switch (@class.method_4())
		{
		case 1130:
		case 1131:
			method_12(5);
			break;
		case 980:
		case 981:
			method_12(2);
			break;
		case 534:
		case 535:
			method_12(3);
			break;
		case 1960:
		case 1961:
			method_12(6);
			break;
		case 1760:
		case 1761:
			method_12(6);
			break;
		case 1346:
		case 1347:
			method_12(6);
			break;
		}
		BitConverter.ToInt32(byte_1, num + 4);
		num += 8;
		bool flag = false;
		switch (method_11())
		{
		case 4:
			flag = (@class.method_4() ^ 0x542) == 1;
			break;
		case 6:
			flag = (@class.method_4() ^ 0x6E0) == 1;
			break;
		case 7:
			flag = (@class.method_4() ^ 0x7A8) == 1;
			break;
		}
		if (@class.method_9())
		{
			num += 16;
			if (flag)
			{
				@class.method_1(new byte[16]);
				Array.Copy(byte_1, num, @class.method_0(), 0, 16);
				num += 16;
			}
			@class.int_0 = BitConverter.ToInt32(byte_1, num);
			num += 4;
			int num2 = BitConverter.ToInt32(byte_1, num + 8) - BitConverter.ToInt32(byte_1, num);
			num += 16;
			Width = (int)((double)(BitConverter.ToInt32(byte_1, num) * int_3 / 914400) + 0.5);
			Height = (int)((double)(BitConverter.ToInt32(byte_1, num + 4) * int_3 / 914400) + 0.5);
			if (method_11() == 3 && Width != 0)
			{
				method_10(num2 * 96 / Width);
			}
			num += 8;
			num += 4;
			@class.byte_2 = byte_1[num];
			@class.byte_3 = byte_1[num + 1];
			num += 2;
		}
		else
		{
			if (flag)
			{
				@class.method_1(new byte[16]);
				Array.Copy(byte_1, num, @class.method_0(), 0, 16);
				num += 16;
			}
			@class.byte_4 = byte_1[num + 16];
			num += 17;
		}
		int num3 = byte_1.Length - num;
		@class.method_7(new byte[num3]);
		Array.Copy(byte_1, num, @class.method_6(), 0, num3);
		byte[] byte_2 = Class1026.smethod_0(@class.method_6());
		method_5().byte_2 = byte_2;
		if (method_4().method_9())
		{
			return;
		}
		byte b = method_11();
		if (b == 7)
		{
			Width = BitConverter.ToInt32(@class.method_6(), 4);
			Height = BitConverter.ToInt32(@class.method_6(), 8);
			return;
		}
		try
		{
			int[] array = Class1181.smethod_0(method_11() == 254, @class.method_6(), int_3);
			Width = array[0];
			Height = array[1];
		}
		catch
		{
		}
	}

	[SpecialName]
	internal Class1695 method_4()
	{
		return class1695_0;
	}

	[SpecialName]
	internal Class1704 method_5()
	{
		return class1704_0;
	}

	[SpecialName]
	internal byte[] method_6()
	{
		return class1704_0.byte_2;
	}

	internal void method_7()
	{
		method_5().int_0++;
	}

	internal void method_8()
	{
		method_5().int_0++;
	}

	[SpecialName]
	internal int method_9()
	{
		return int_2;
	}

	[SpecialName]
	internal void method_10(int int_3)
	{
		int_2 = int_3;
	}

	[SpecialName]
	internal byte method_11()
	{
		return byte_0;
	}

	[SpecialName]
	internal void method_12(byte byte_1)
	{
		byte_0 = byte_1;
	}
}
