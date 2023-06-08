using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using ns218;
using ns224;
using ns233;
using ns234;
using ns236;
using ns264;

namespace ns235;

internal class Class6220 : Class6204
{
	internal const float float_0 = 32767f;

	private PointF pointF_0 = PointF.Empty;

	private SizeF sizeF_0 = SizeF.Empty;

	private byte[] byte_0;

	private Class6145 class6145_0;

	private Class6270 class6270_0;

	private Class6140 class6140_0;

	public PointF Origin
	{
		get
		{
			return pointF_0;
		}
		set
		{
			pointF_0 = value;
		}
	}

	public SizeF Size
	{
		get
		{
			return sizeF_0;
		}
		set
		{
			sizeF_0 = value;
		}
	}

	public RectangleF Bounds => new RectangleF(pointF_0, sizeF_0);

	public byte[] ImageBytes
	{
		get
		{
			return byte_0;
		}
		set
		{
			byte_0 = value;
		}
	}

	public Enum788 ImageType => Class6148.smethod_0(byte_0);

	public Class6145 Crop
	{
		get
		{
			return class6145_0;
		}
		set
		{
			class6145_0 = value;
		}
	}

	public Class6270 Hyperlink
	{
		get
		{
			return class6270_0;
		}
		set
		{
			class6270_0 = value;
		}
	}

	public Class6140 ChromaKey
	{
		get
		{
			return class6140_0;
		}
		set
		{
			class6140_0 = value;
		}
	}

	public Class6220(PointF origin, SizeF size, byte[] imageBytes)
		: this(origin, size, imageBytes, null)
	{
	}

	public Class6220(PointF origin, SizeF size, byte[] imageBytes, Class6145 crop, Class6140 chromaKey)
		: this(origin, size, imageBytes, crop)
	{
		class6140_0 = chromaKey;
	}

	public Class6220(PointF origin, SizeF size, byte[] imageBytes, Class6145 crop)
	{
		pointF_0 = origin;
		sizeF_0 = size;
		class6145_0 = crop;
		byte_0 = Class6150.smethod_3(imageBytes);
	}

	public static Class6220 smethod_0(Class6220 src)
	{
		Class6220 @class = src.Clone();
		@class.ImageBytes = Class5964.smethod_15();
		@class.Crop = null;
		return @class;
	}

	public static Class6220 smethod_1(Class6220 stencilMask, Class5990 brush)
	{
		Class6150 @class = new Class6150(stencilMask.byte_0);
		@class.method_17();
		using Bitmap bitmap = new Bitmap(@class.Width, @class.Height, PixelFormat.Format32bppArgb);
		using Graphics graphics = Graphics.FromImage(bitmap);
		Class6217 class2 = Class6217.smethod_1(new RectangleF(PointF.Empty, new SizeF(@class.Width, @class.Height)));
		class2.Brush = brush;
		Class6190 class3 = new Class6190();
		class3.method_0(class2, graphics);
		BitmapData bitmapData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
		int num = bitmapData.Stride * bitmapData.Height;
		byte[] array = new byte[num];
		Marshal.Copy(bitmapData.Scan0, array, 0, num);
		Class6004 class4 = @class.method_15(isConvertTo1Bpp: false, isAllowTransparencyToColorHack: false);
		byte[] colorValues = class4.ColorValues;
		int num2 = 3;
		for (int i = 0; i < colorValues.Length; i += 3)
		{
			if (colorValues[i] == 0)
			{
				array[num2] = 0;
			}
			num2 += 4;
		}
		Marshal.Copy(array, 0, bitmapData.Scan0, num);
		bitmap.UnlockBits(bitmapData);
		using MemoryStream memoryStream = new MemoryStream();
		bitmap.Save(memoryStream, ImageFormat.Png);
		return new Class6220(stencilMask.Origin, stencilMask.Size, memoryStream.ToArray(), stencilMask.Crop, stencilMask.ChromaKey);
	}

	private Class6220 Clone()
	{
		return (Class6220)MemberwiseClone();
	}

	public static Class6220 smethod_2(PointF origin, SizeF size, string fileName)
	{
		FileStream fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
		try
		{
			byte[] imageBytes = Class5964.smethod_11(fileStream);
			return new Class6220(origin, size, imageBytes);
		}
		finally
		{
			fileStream.Close();
		}
	}

	public override void vmethod_0(Class6176 visitor)
	{
		visitor.vmethod_11(this);
	}

	internal Class6220 method_0(Class6176 visitor, Class6482 metafilesCache, bool scaleForPdf, bool isRenderMetafileToBitmap)
	{
		switch (ImageType)
		{
		case Enum788.const_1:
		case Enum788.const_2:
			return method_1(isRenderMetafileToBitmap, metafilesCache, scaleForPdf, visitor);
		default:
			return smethod_0(this);
		case Enum788.const_0:
		case Enum788.const_4:
		case Enum788.const_5:
		case Enum788.const_6:
		case Enum788.const_7:
		case Enum788.const_8:
			return this;
		}
	}

	private Class6220 method_1(bool isRenderMetafileToBitmap, Class6482 metafilesCache, bool scaleForPdf, Class6176 visitor)
	{
		if (isRenderMetafileToBitmap)
		{
			return method_2();
		}
		Class6483 @class = new Class6483();
		Class6213 class2;
		try
		{
			class2 = metafilesCache.method_0(this, @class);
			if (scaleForPdf)
			{
				smethod_3(class2);
			}
		}
		catch (Exception)
		{
			return null;
		}
		if (@class.IsUnsupportedRecordMet)
		{
			return method_2();
		}
		class2.vmethod_0(visitor);
		return null;
	}

	private Class6220 method_2()
	{
		try
		{
			Class6220 @class = Clone();
			@class.ImageBytes = Class6148.smethod_40(ImageBytes);
			return @class;
		}
		catch
		{
			return null;
		}
	}

	private static void smethod_3(Class6213 metafileCanvas)
	{
		float num = smethod_4(metafileCanvas);
		if (!(num >= 1f))
		{
			Class6186 @class = new Class6186();
			@class.ScaleFontSize = true;
			@class.method_1(metafileCanvas, num);
			if (metafileCanvas.RenderTransform == null)
			{
				metafileCanvas.RenderTransform = new Class6002();
			}
			metafileCanvas.RenderTransform.method_5(1f / num, 1f / num, MatrixOrder.Prepend);
		}
	}

	private static float smethod_4(Class6213 metafileCanvas)
	{
		Class6187 @class = new Class6187();
		@class.method_0(metafileCanvas);
		if (!@class.AreStatisticsCalculated)
		{
			return 1f;
		}
		float num = Math.Max(Math.Abs(@class.MaxFloatValue), Math.Abs(@class.MinFloatValue));
		if (num < 32767f)
		{
			return 1f;
		}
		return 32766f / num;
	}
}
