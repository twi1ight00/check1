using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using ns218;
using ns224;
using ns233;
using ns234;

namespace ns237;

internal class Class6526 : Class6525
{
	private const int int_1 = 1;

	private const int int_2 = 3;

	private byte[] byte_0;

	private int int_3;

	private int int_4;

	private bool bool_0;

	private Class6002 class6002_1;

	private int int_5;

	private int int_6;

	protected override int PatternType => 1;

	protected override Class6002 BrushTransform => class6002_1;

	internal Class6526(Class6672 context, Class5995 brush)
		: base(context)
	{
		using Class6150 @class = new Class6150(brush);
		if (@class.ImageType == Enum788.const_4)
		{
			byte_0 = brush.ImageBytes;
		}
		else
		{
			MemoryStream memoryStream = new MemoryStream();
			@class.Save(memoryStream, Enum788.const_5);
			byte_0 = Class5964.smethod_11(memoryStream);
		}
		byte_0 = method_13(byte_0);
		int_3 = @class.Width;
		int_4 = @class.Height;
		bool_0 = true;
		class6002_1 = brush.Transform;
		if (brush.WrapMode == WrapMode.Clamp)
		{
			int_5 = (int)(Math.Max(context.Document.Page.Width, int_3) * 2f);
			int_6 = (int)(Math.Max(context.Document.Page.Height, int_4) * 2f);
		}
		else
		{
			int_5 = int_3;
			int_6 = int_4;
		}
	}

	internal Class6526(Class6672 context, Class5996 brush)
		: base(context)
	{
		byte_0 = method_13(Class6141.smethod_0(brush));
		int_3 = 8;
		int_5 = 8;
		int_4 = 8;
		int_6 = 8;
	}

	internal override void vmethod_2(Class6679 writer)
	{
		base.vmethod_2(writer);
		writer.method_18("/PaintType", 1);
		writer.method_18("/TilingType", 3);
		writer.method_16("/BBox", new RectangleF(0f, 0f, int_3, int_4));
		writer.method_18("/XStep", int_5);
		writer.method_18("/YStep", int_6);
		writer.Write("/Resources");
		writer.method_6();
		class6683_0.method_5(writer);
		writer.method_7();
		method_12(writer);
	}

	public override void vmethod_0(Class6679 writer)
	{
		class6677_0.method_3(byte_0, null, new RectangleF(0f, 0f, int_3, int_4), null, bool_0);
		base.vmethod_0(writer);
	}

	private byte[] method_13(byte[] image)
	{
		if (base.Context.Options.ApplyImageTransparent || base.Context.Options.ImageTransparentColor == null)
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
}
