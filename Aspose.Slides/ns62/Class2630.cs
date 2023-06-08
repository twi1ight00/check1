using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using ns33;

namespace ns62;

internal abstract class Class2630 : Class2629
{
	private byte byte_1;

	public byte Tag
	{
		get
		{
			return byte_1;
		}
		set
		{
			byte_1 = value;
		}
	}

	internal Class2630(ushort headerType, short headerInstance)
		: base(headerType, 0)
	{
		base.Header.Type = headerType;
		base.Header.Instance = headerInstance;
		Tag = byte.MaxValue;
	}

	public static Class2630 smethod_1(Bitmap bitmap)
	{
		Class2630 @class;
		ImageFormat format;
		if (bitmap.RawFormat.Equals(ImageFormat.Jpeg))
		{
			@class = new Class2633();
			format = ImageFormat.Jpeg;
		}
		else
		{
			@class = new Class2632();
			format = ImageFormat.Png;
		}
		MemoryStream memoryStream = new MemoryStream();
		bitmap.Save(memoryStream, format);
		memoryStream.Close();
		@class.BLIPFileData = memoryStream.ToArray();
		@class.method_1(@class.BLIPFileData);
		@class.Header.Length = @class.RgbUid.ToByteArray().Length + 1;
		return @class;
	}

	public static Class2630 smethod_2(MemoryStream stream)
	{
		return smethod_4(stream, ignoreImageReadingErrors: false, Enum389.const_1);
	}

	public static Class2630 smethod_3(MemoryStream stream, Enum389 defaultBlipType)
	{
		return smethod_4(stream, ignoreImageReadingErrors: true, defaultBlipType);
	}

	private static Class2630 smethod_4(MemoryStream stream, bool ignoreImageReadingErrors, Enum389 defaultBlipType)
	{
		Class2630 @class = null;
		Class1158 class2 = new Class1158(stream);
		bool flag = true;
		if (class2.method_0())
		{
			int format = class2.Format;
			if (format == Class1158.int_0 || format == Class1158.int_1 || format == Class1158.int_2)
			{
				if (format == Class1158.int_0)
				{
					@class = new Class2633();
				}
				else if (format == Class1158.int_2 || format == Class1158.int_1)
				{
					@class = new Class2632();
				}
				@class.BLIPFileData = stream.ToArray();
				@class.method_1(@class.BLIPFileData);
				@class.Header.Length = @class.RgbUid.ToByteArray().Length + 1;
				flag = false;
			}
		}
		if (flag)
		{
			@class = new Class2632();
			try
			{
				stream.Position = 0L;
				Bitmap bitmap = new Bitmap(stream);
				MemoryStream memoryStream = new MemoryStream();
				bitmap.Save(memoryStream, ImageFormat.Png);
				memoryStream.Close();
				bitmap.Dispose();
				@class.BLIPFileData = memoryStream.ToArray();
				@class.method_1(@class.BLIPFileData);
				@class.Header.Length = @class.RgbUid.ToByteArray().Length + 1;
			}
			catch (ArgumentException ex)
			{
				if (!ignoreImageReadingErrors)
				{
					throw;
				}
				Class1165.smethod_28(ex);
				@class = defaultBlipType switch
				{
					Enum389.const_5 => new Class2633(), 
					Enum389.const_6 => new Class2632(), 
					Enum389.const_7 => new Class2631(), 
					_ => throw new NotImplementedException(), 
				};
				@class.BLIPFileData = stream.ToArray();
				@class.method_1(@class.BLIPFileData);
				@class.Header.Length = @class.RgbUid.ToByteArray().Length + 1;
			}
		}
		return @class;
	}

	public override void vmethod_5(Stream stream)
	{
		byte[] array = vmethod_6();
		stream.Write(array, 0, array.Length);
	}

	public override byte[] vmethod_6()
	{
		if (base.BlipType == Enum389.const_7)
		{
			return Class2619.smethod_0(base.BLIPFileData);
		}
		return base.BLIPFileData;
	}

	public override Image vmethod_7(SizeF size)
	{
		try
		{
			byte[] buffer = ((base.BlipType != Enum389.const_7) ? base.BLIPFileData : Class2619.smethod_0(base.BLIPFileData));
			MemoryStream memoryStream = new MemoryStream(buffer, writable: false);
			Bitmap bitmap = new Bitmap(memoryStream);
			Image result = (size.IsEmpty ? new Bitmap(bitmap) : new Bitmap(bitmap, size.ToSize()));
			bitmap.Dispose();
			memoryStream.Close();
			return result;
		}
		catch (Exception ex)
		{
			Class1165.smethod_28(ex);
			return null;
		}
	}

	protected override void vmethod_0(BinaryReader reader)
	{
		base.RgbUid = Class2629.smethod_0(reader);
		Tag = reader.ReadByte();
		int num = 1;
		if ((base.Header.Instance & 1) > 0)
		{
			reader.ReadBytes(16);
			num += 16;
			base.Header.Instance &= -2;
		}
		int count = base.Header.Length - 16 - num;
		base.BLIPFileData = reader.ReadBytes(count);
	}

	public override void vmethod_1(BinaryWriter writer)
	{
		writer.Write(base.RgbUid.ToByteArray());
		writer.Write(Tag);
		writer.Write(base.BLIPFileData);
	}

	public override int vmethod_2()
	{
		return base.RgbUid.ToByteArray().Length + 1 + base.BLIPFileData.Length;
	}
}
