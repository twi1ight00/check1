using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Effects;
using ns11;
using ns224;
using ns33;
using ns5;

namespace ns4;

internal class Class55 : IPictureEffectiveData, IEffectiveData
{
	internal string string_0;

	internal PPImage ppimage_0;

	private Class46 class46_0;

	public IPPImage Image => ppimage_0;

	public string LinkPathLong => string_0;

	public IImageTransformOCollectionEffectiveData ImageTransform => class46_0;

	internal Class55()
	{
	}

	internal void method_0(ISlidesPicture source)
	{
		string_0 = source.LinkPathLong;
		ppimage_0 = (PPImage)source.Image;
		class46_0 = new Class46();
		foreach (ImageTransformOperation item in source.ImageTransform)
		{
			class46_0.Add(item);
		}
	}

	internal void method_1(IBaseSlide slide, FloatColor styleColor)
	{
		foreach (EffectEffectiveDataPVITemp item in class46_0)
		{
			item.vmethod_2(slide, styleColor);
		}
	}

	internal void method_2(Class55 source)
	{
		string_0 = source.LinkPathLong;
		ppimage_0 = (PPImage)source.Image;
		class46_0 = new Class46();
		foreach (ImageTransformOperation item in source.ImageTransform)
		{
			class46_0.Add(item);
		}
	}

	internal Class64 method_3(Class6002 transform, SizeF tileSize, Class169 rc)
	{
		Class64 @class = method_4(rc);
		if (rc != null && !float.IsInfinity(rc.SufficientDpi) && (!rc.PreserveBitmapAnimation || !@class.IsAnimatedGif))
		{
			float num = float.PositiveInfinity;
			float num2 = float.PositiveInfinity;
			if (transform != null)
			{
				PointF[] array = new PointF[2]
				{
					new PointF(1f, 0f),
					new PointF(0f, 1f)
				};
				Class1170.smethod_7(transform, array);
				num = (float)((double)rc.SufficientDpi / Math.Sqrt(array[0].X * array[0].X + array[0].Y * array[0].Y));
				num2 = (float)((double)rc.SufficientDpi / Math.Sqrt(array[1].X * array[1].X + array[1].Y * array[1].Y));
			}
			else
			{
				num = (num2 = rc.SufficientDpi);
			}
			double num3 = Math.Sqrt(2.0);
			double num4 = 1.0;
			double num5 = (double)(tileSize.Width * num / 72f) * num3;
			double num6 = (double)(tileSize.Height * num2 / 72f) * num3;
			while ((double)((float)@class.Width / (float)num4) > num5)
			{
				num4 *= num3;
			}
			double num7 = 1.0;
			while ((double)((float)@class.Height / (float)num7) > num6)
			{
				num7 *= num3;
			}
			if (num4 == num3 * num7)
			{
				num4 = num7;
			}
			else if (num7 == num3 * num4)
			{
				num7 = num4;
			}
			if (num4 == 1.0 && num7 == 1.0)
			{
				return @class;
			}
			string text = $"{@class.Code}_shrink{num4}_{num7}";
			Class64 class2 = rc.method_0(text);
			if (class2 == null)
			{
				Image image = @class.Image;
				Size newSize = new Size((int)Math.Round((float)image.Width / (float)num4), (int)Math.Round((float)image.Height / (float)num7));
				class2 = new Class64(new Bitmap(image, newSize), text);
				rc.method_1(text, class2);
			}
			return class2;
		}
		return @class;
	}

	private Class64 method_4(Class169 rc)
	{
		Class64 @class = null;
		string text = ppimage_0.Guid.ToString() + ':' + class46_0.method_0() + "PVITemp";
		float num = 3000000f;
		if (rc != null)
		{
			@class = rc.method_0(text);
			num = rc.MaxMetafileRasterizationPixels;
		}
		if (@class != null)
		{
			return @class;
		}
		@class = new Class64(Image.BinaryData, text);
		bool flag = false;
		if (rc != null && (flag = rc.CheckTransparencyOfAllImages && (!rc.PreserveBitmapAnimation || !@class.IsAnimatedGif)) && @class.IsMetafile)
		{
			flag &= rc.RasterizeMetafiles;
		}
		if (class46_0.Count != 0 || flag)
		{
			Size size = @class.Image.Size;
			bool flag2 = false;
			if (@class.IsMetafile && (float)size.Width * (float)size.Height > num)
			{
				flag2 = true;
				float num2 = (float)Math.Sqrt(num / (float)size.Width / (float)size.Height);
				size = new Size((int)Math.Round((float)size.Width * num2), (int)Math.Round((float)size.Height * num2));
				if (size.Width < 1)
				{
					size.Width = 1;
				}
				if (size.Height < 1)
				{
					size.Height = 1;
				}
			}
			Bitmap bitmap = new Bitmap(@class.Image, size.Width, size.Height);
			if (flag2)
			{
				bitmap.SetResolution(@class.Image.HorizontalResolution * (float)bitmap.Width / (float)@class.Image.Width, @class.Image.VerticalResolution * (float)bitmap.Height / (float)@class.Image.Height);
			}
			@class.Dispose();
			@class = new Class64(class46_0.method_1(bitmap, flag), text);
		}
		rc?.method_1(text, @class);
		return @class;
	}

	public override bool Equals(object obj)
	{
		if (!(obj is Class55 obj2))
		{
			return false;
		}
		return method_5(obj2);
	}

	internal bool method_5(Class55 obj)
	{
		if (obj == null)
		{
			return false;
		}
		if (!ppimage_0.Equals(obj.ppimage_0))
		{
			return false;
		}
		if (!class46_0.method_2(obj.class46_0))
		{
			return false;
		}
		if (string_0 != obj.string_0)
		{
			return false;
		}
		return true;
	}

	internal bool method_6(IPictureEffectiveData obj)
	{
		if (obj == null)
		{
			return false;
		}
		if (!ppimage_0.Equals(obj.Image))
		{
			return false;
		}
		if (!class46_0.method_3(obj.ImageTransform))
		{
			return false;
		}
		if (string_0 != obj.LinkPathLong)
		{
			return false;
		}
		return true;
	}

	public override int GetHashCode()
	{
		return 23454;
	}
}
