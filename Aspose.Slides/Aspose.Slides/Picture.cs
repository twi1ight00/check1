using System;
using System.Drawing;
using Aspose.Slides.Effects;
using ns11;
using ns224;
using ns24;
using ns33;
using ns4;

namespace Aspose.Slides;

public class Picture : IPresentationComponent, ISlidesPicture
{
	private string string_0;

	private PPImage ppimage_0;

	private IPresentationComponent ipresentationComponent_0;

	private Class347 class347_0 = new Class347();

	private uint uint_0;

	private ImageTransformOperationCollection imageTransformOperationCollection_0;

	internal Class347 PPTXUnsupportedProps => class347_0;

	public IPPImage Image
	{
		get
		{
			return ppimage_0;
		}
		set
		{
			if (value == null)
			{
				uint_0 = Version;
			}
			method_4();
			ppimage_0 = (PPImage)value;
			if (ppimage_0 != null && ppimage_0.Presentation != null && Presentation != null && ppimage_0.Presentation != Presentation)
			{
				throw new PptxEditException("Can't assign an image from the other presentation.");
			}
		}
	}

	public string LinkPathLong
	{
		get
		{
			return string_0;
		}
		set
		{
			string_0 = value;
			if (value != null && value.Length == 0)
			{
				string_0 = null;
			}
			method_4();
		}
	}

	public IImageTransformOperationCollection ImageTransform => imageTransformOperationCollection_0;

	public IBaseSlide Slide
	{
		get
		{
			if (!(ipresentationComponent_0 is ISlideComponent slideComponent))
			{
				return null;
			}
			return slideComponent.Slide;
		}
	}

	IPresentationComponent ISlidesPicture.AsIPresentationComponent => this;

	public IPresentation Presentation
	{
		get
		{
			if (ipresentationComponent_0 == null)
			{
				return null;
			}
			return ipresentationComponent_0.Presentation;
		}
	}

	internal uint Version => uint_0 + ((ppimage_0 != null) ? ppimage_0.Version : 0) + imageTransformOperationCollection_0.Version;

	internal Picture(IPresentationComponent parent)
	{
		ipresentationComponent_0 = parent;
		imageTransformOperationCollection_0 = new ImageTransformOperationCollection(parent);
	}

	internal Picture(IPresentationComponent parent, Picture pic)
	{
		ipresentationComponent_0 = parent;
		ppimage_0 = pic.ppimage_0;
		imageTransformOperationCollection_0 = new ImageTransformOperationCollection(parent);
		foreach (ImageTransformOperation item in pic.imageTransformOperationCollection_0)
		{
			imageTransformOperationCollection_0.Add(item);
		}
	}

	internal void method_0(Picture source)
	{
		string_0 = source.string_0;
		ppimage_0 = source.ppimage_0;
		imageTransformOperationCollection_0.Clear();
		foreach (ImageTransformOperation item in source.imageTransformOperationCollection_0)
		{
			imageTransformOperationCollection_0.Add(item);
		}
		method_4();
	}

	internal void method_1(PictureEffectiveData source)
	{
		if (source != null)
		{
			string_0 = source.string_0;
			ppimage_0 = source.ppimage_0;
			method_4();
		}
	}

	internal Class64 method_2(Class6002 transform, SizeF tileSize, Class169 rc, IBaseSlide slide, FloatColor styleColor)
	{
		Class64 @class = method_3(rc, slide, styleColor);
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

	internal Class64 method_3(Class169 rc, IBaseSlide slide, FloatColor styleColor)
	{
		Class64 @class = null;
		string text = ppimage_0.Guid.ToString() + ':' + imageTransformOperationCollection_0.method_0(slide, styleColor);
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
		if (imageTransformOperationCollection_0.Count != 0 || flag)
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
			@class = new Class64(imageTransformOperationCollection_0.method_1(slide, styleColor, bitmap, flag), text);
		}
		rc?.method_1(text, @class);
		return @class;
	}

	private void method_4()
	{
		uint_0++;
	}
}
