using System.Drawing;
using ns24;

namespace Aspose.Slides;

public class PictureFillFormatEffectiveData : IFillParamSource, IPictureFillFormatEffectiveData, IEffectiveData
{
	internal PictureEffectiveData pictureEffectiveData_0;

	internal Class1148 class1148_0 = new Class1148();

	internal PictureFillMode pictureFillMode_0;

	internal Class1148 class1148_1 = new Class1148();

	private double double_0;

	private double double_1;

	private float float_0 = 1f;

	private float float_1 = 1f;

	private TileFlip tileFlip_0;

	private RectangleAlignment rectangleAlignment_0;

	internal int int_0;

	public int Dpi => int_0;

	public PictureFillMode PictureFillMode => pictureFillMode_0;

	public IPictureEffectiveData Picture => pictureEffectiveData_0;

	internal Class1148 StretchFillRectangle => class1148_1;

	internal double TileOffsetX => double_0;

	internal double TileOffsetY => double_1;

	internal float TileScaleX => float_0;

	internal float TileScaleY => float_1;

	internal TileFlip TileFlip => tileFlip_0;

	internal RectangleAlignment TileAlign => rectangleAlignment_0;

	public float CropLeft => class1148_0.Left * 100f;

	public float CropTop => class1148_0.Top * 100f;

	public float CropRight => (1f - class1148_0.Right) * 100f;

	public float CropBottom => (1f - class1148_0.Bottom) * 100f;

	internal RectangleF SourceRectangle => class1148_0.method_1(new RectangleF(0f, 0f, pictureEffectiveData_0.Image.Width, pictureEffectiveData_0.Image.Height));

	IFillParamSource IPictureFillFormatEffectiveData.AsIFillParamSource => this;

	internal PictureFillFormatEffectiveData()
	{
	}

	internal PictureFillFormatEffectiveData(PictureFillFormat format, BaseSlide slide, FloatColor styleColor)
		: this()
	{
		method_0(format, slide, styleColor);
	}

	internal void method_0(PictureFillFormat source, BaseSlide slide, FloatColor styleColor)
	{
		if (source != null)
		{
			pictureEffectiveData_0 = new PictureEffectiveData(source.Picture, slide, styleColor);
			class1148_0.method_0(source.PPTXUnsupportedProps.SrcRect);
			pictureFillMode_0 = source.PictureFillMode;
			class1148_1.method_0(source.PPTXUnsupportedProps.StretchFillRectangle);
			double_0 = source.TileOffsetX;
			double_1 = source.TileOffsetY;
			float_0 = source.TileScaleX;
			float_1 = source.TileScaleY;
			tileFlip_0 = source.TileFlip;
			rectangleAlignment_0 = source.TileAlign;
			int_0 = source.Dpi;
		}
	}

	internal void method_1(PictureFillFormat source, BaseSlide slide, FloatColor styleColor)
	{
		if (source != null)
		{
			pictureEffectiveData_0 = new PictureEffectiveData(source.Picture, slide, styleColor);
			class1148_0.method_0(source.PPTXUnsupportedProps.SrcRect);
			pictureFillMode_0 = source.PictureFillMode;
			class1148_1.method_0(source.PPTXUnsupportedProps.StretchFillRectangle);
			if (!double.IsNaN(source.TileOffsetX))
			{
				double_0 = source.TileOffsetX;
			}
			if (!double.IsNaN(source.TileOffsetY))
			{
				double_1 = source.TileOffsetY;
			}
			if (!float.IsNaN(source.TileScaleX))
			{
				float_0 = source.TileScaleX;
			}
			if (!float.IsNaN(source.TileScaleY))
			{
				float_1 = source.TileScaleY;
			}
			if (source.TileFlip != TileFlip.NotDefined)
			{
				tileFlip_0 = source.TileFlip;
			}
			if (source.TileAlign != RectangleAlignment.NotDefined)
			{
				rectangleAlignment_0 = source.TileAlign;
			}
			int_0 = source.Dpi;
		}
	}

	public override bool Equals(object obj)
	{
		if (!(obj is PictureFillFormatEffectiveData obj2))
		{
			return false;
		}
		return method_2(obj2);
	}

	internal bool method_2(PictureFillFormatEffectiveData obj)
	{
		if (obj == null)
		{
			return false;
		}
		if (!pictureEffectiveData_0.method_0(obj.Picture))
		{
			return false;
		}
		if (!class1148_0.method_4(obj.class1148_0))
		{
			return false;
		}
		if (!class1148_1.method_4(obj.class1148_1))
		{
			return false;
		}
		if (pictureFillMode_0 != obj.pictureFillMode_0)
		{
			return false;
		}
		if (double_0 != obj.TileOffsetX)
		{
			return false;
		}
		if (double_1 != obj.TileOffsetY)
		{
			return false;
		}
		if (float_0 != obj.TileScaleX)
		{
			return false;
		}
		if (float_1 != obj.TileScaleY)
		{
			return false;
		}
		if (tileFlip_0 != obj.TileFlip)
		{
			return false;
		}
		if (rectangleAlignment_0 != obj.TileAlign)
		{
			return false;
		}
		if (int_0 != obj.int_0)
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
