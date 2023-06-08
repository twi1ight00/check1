using System;
using System.IO;
using ns218;
using ns221;
using ns224;
using ns233;
using ns234;

namespace ns237;

internal class Class6521 : Class6519
{
	private byte[] byte_0;

	private Class6145 class6145_0;

	private Enum891 enum891_0;

	private Class6147 class6147_0;

	private Class6670 class6670_0;

	private int int_1;

	private Class6518 class6518_0;

	private Class6514 class6514_0;

	private int int_2;

	private readonly Class6140 class6140_0;

	internal Class6521(Class6672 context, byte[] imageBytes, Class6145 crop, Class6140 chromaKey)
		: base(context)
	{
		byte_0 = method_12(imageBytes);
		class6145_0 = crop;
		enum891_0 = class6672_0.Options.ImageCompression;
		class6140_0 = chromaKey;
		if (enum891_0 == Enum891.const_0)
		{
			enum891_0 = method_13();
		}
	}

	private byte[] method_12(byte[] image)
	{
		if (base.Context.Options.ApplyImageTransparent && base.Context.Options.ImageTransparentColor != null)
		{
			using Class6150 @class = new Class6150(image);
			@class.method_20(base.Context.Options.ImageTransparentColor);
			using MemoryStream memoryStream = new MemoryStream();
			if (@class.ImageType == Enum788.const_4)
			{
				@class.Save(memoryStream, Enum788.const_4);
			}
			else
			{
				@class.Save(memoryStream, Enum788.const_5);
			}
			image = memoryStream.ToArray();
		}
		return image;
	}

	private Enum891 method_13()
	{
		if (class6672_0.PdfaCompliant)
		{
			if (Class6148.smethod_0(byte_0) != Enum788.const_4)
			{
				return Enum891.const_3;
			}
			return Enum891.const_6;
		}
		using Class6150 class3 = method_16();
		Class6147 @class = class6147_0;
		Class6670 class2 = class6670_0;
		int num = int_1;
		class6147_0 = Class6147.smethod_1(class3.Width, class3.Height, class3.HorizontalResolution, class3.VerticalResolution);
		Class6004 class4 = class3.method_15(isConvertTo1Bpp: false, isAllowTransparencyToColorHack: false);
		class6670_0 = Class6670.smethod_0(class4.ColorModel);
		int_1 = class4.BitsPerComponent;
		Enum891 @enum = Enum891.const_6;
		long num2;
		using (MemoryStream memoryStream = new MemoryStream())
		{
			class3.method_9(memoryStream, class6672_0.Options.JpegQuality);
			num2 = method_14(memoryStream.ToArray(), @enum);
		}
		long num3 = method_14(class4.ColorValues, Enum891.const_3);
		if (num3 < num2)
		{
			num2 = num3;
			@enum = Enum891.const_3;
		}
		num3 = method_14(class4.ColorValues, Enum891.const_4);
		if (num3 < num2)
		{
			num2 = num3;
			@enum = Enum891.const_4;
		}
		class6147_0 = @class;
		class6670_0 = class2;
		int_1 = num;
		return @enum;
	}

	private long method_14(byte[] imageBytes, Enum891 compression)
	{
		Enum891 @enum = enum891_0;
		enum891_0 = compression;
		Class6662 @class = vmethod_3();
		try
		{
			using MemoryStream outputStream = new MemoryStream();
			using Stream stream = @class.vmethod_0(outputStream);
			stream.Write(imageBytes, 0, imageBytes.Length);
			return stream.Length;
		}
		finally
		{
			enum891_0 = @enum;
		}
	}

	public override void vmethod_0(Class6679 writer)
	{
		try
		{
			method_15(writer);
		}
		catch (Exception)
		{
			byte_0 = Class5964.smethod_15();
			class6145_0 = null;
			method_15(writer);
		}
	}

	private void method_15(Class6679 writer)
	{
		using (Class6150 @class = method_16())
		{
			class6147_0 = Class6147.smethod_1(@class.Width, @class.Height, @class.HorizontalResolution, @class.VerticalResolution);
			if (@class.method_1() == Enum786.const_1)
			{
				method_20(@class.method_14());
				if (enum891_0 == Enum891.const_6)
				{
					enum891_0 = Enum891.const_3;
				}
			}
			method_17(@class);
		}
		base.vmethod_0(writer);
		if (class6514_0 != null)
		{
			class6514_0.vmethod_0(writer);
			class6514_0 = null;
		}
		if (class6518_0 != null)
		{
			class6518_0.vmethod_0(writer);
			class6518_0 = null;
		}
	}

	private Class6150 method_16()
	{
		if (class6145_0 != null && class6145_0.HasPositiveCrop)
		{
			return class6145_0.method_3(byte_0);
		}
		return new Class6150(byte_0);
	}

	[Attribute7(true)]
	private void method_17(Class6150 bitmap)
	{
		switch (enum891_0)
		{
		default:
			method_19(bitmap, isConvertTo1Bpp: false);
			break;
		case Enum891.const_6:
			method_18(bitmap);
			break;
		case Enum891.const_7:
		case Enum891.const_8:
			method_19(bitmap, isConvertTo1Bpp: true);
			break;
		}
	}

	private void method_18(Class6150 bitmap)
	{
		bitmap.method_9(base.BaseStream, class6672_0.Options.JpegQuality);
		bool flag;
		bool isAllowTransparencyToColorHack = !(flag = !class6672_0.PdfaCompliant);
		Class6004 @class = bitmap.method_15(isConvertTo1Bpp: false, isAllowTransparencyToColorHack);
		if (@class.HasTransparentPixels && flag)
		{
			class6518_0 = new Class6518(class6672_0, @class.AlphaValues, class6147_0.Width, class6147_0.Height);
		}
		switch (bitmap.method_1())
		{
		case Enum786.const_0:
			class6670_0 = Class6670.DeviceRgb;
			int_1 = 8;
			break;
		default:
			throw new InvalidOperationException("Unexpected color model.");
		case Enum786.const_2:
			class6670_0 = Class6670.DeviceGray;
			int_1 = 8;
			break;
		}
	}

	private void method_19(Class6150 bitmap, bool isConvertTo1Bpp)
	{
		bool flag;
		bool isAllowTransparencyToColorHack = !(flag = !class6672_0.PdfaCompliant);
		Class6004 @class = bitmap.method_15(isConvertTo1Bpp, isAllowTransparencyToColorHack);
		Write(@class.ColorValues, 0, @class.ColorValues.Length);
		class6670_0 = Class6670.smethod_0(@class.ColorModel);
		int_1 = @class.BitsPerComponent;
		if (@class.HasTransparentPixels && flag)
		{
			class6518_0 = new Class6518(class6672_0, @class.AlphaValues, class6147_0.Width, class6147_0.Height);
		}
	}

	private void method_20(Class5998[] colorTable)
	{
		class6514_0 = new Class6514(class6672_0);
		int_2 = colorTable.Length;
		for (int i = 0; i < int_2; i++)
		{
			class6514_0.WriteByte((byte)colorTable[i].R);
			class6514_0.WriteByte((byte)colorTable[i].G);
			class6514_0.WriteByte((byte)colorTable[i].B);
		}
	}

	internal override Class6662 vmethod_3()
	{
		switch (enum891_0)
		{
		default:
			throw new InvalidOperationException("Unknown image compression filter type.");
		case Enum891.const_1:
			return null;
		case Enum891.const_2:
			return new Class6667();
		case Enum891.const_3:
			return new Class6665();
		case Enum891.const_4:
		case Enum891.const_5:
		{
			Class6666 @class = new Class6666();
			@class.BitsPerComponent = int_1;
			@class.Columns = class6147_0.Width;
			@class.Colors = class6670_0.Components;
			@class.IsBaselinePredictor = enum891_0 == Enum891.const_4;
			return @class;
		}
		case Enum891.const_6:
			return new Class6664();
		case Enum891.const_7:
		case Enum891.const_8:
			return new Class6663(enum891_0, class6147_0);
		}
	}

	internal override void vmethod_2(Class6679 writer)
	{
		writer.method_8("/Type", "/XObject");
		writer.method_8("/Subtype", "/Image");
		writer.method_18("/Width", class6147_0.Width);
		writer.method_18("/Height", class6147_0.Height);
		if (class6140_0 != null)
		{
			int[] value = new int[6]
			{
				class6140_0.LowColor.R,
				class6140_0.HighColor.R,
				class6140_0.LowColor.G,
				class6140_0.HighColor.G,
				class6140_0.LowColor.B,
				class6140_0.HighColor.B
			};
			writer.method_12("/Mask", value);
		}
		if (class6670_0 == Class6670.Indexed)
		{
			writer.method_8("/ColorSpace", $"[/{class6670_0.FullName}/DeviceRGB {int_2 - 1} {class6514_0.IndirectReference}]");
		}
		else
		{
			writer.method_8("/ColorSpace", $"/{class6670_0.FullName}");
		}
		writer.method_18("/BitsPerComponent", int_1);
		if (class6518_0 != null)
		{
			writer.method_8("/SMask", class6518_0.IndirectReference);
		}
	}
}
