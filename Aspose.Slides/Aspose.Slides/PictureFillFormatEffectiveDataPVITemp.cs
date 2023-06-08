using System;
using System.Drawing;
using ns24;
using ns4;

namespace Aspose.Slides;

internal class PictureFillFormatEffectiveDataPVITemp : Class20<PictureFillFormat, PictureFillFormatEffectiveDataPVITemp>, IFillParamSource, IPictureFillFormatEffectiveData
{
	private PictureFillFormat pictureFillFormat_0;

	private IEffectiveData ieffectiveData_0;

	private bool bool_1;

	private uint uint_1;

	internal Class55 class55_0;

	private Class1148 class1148_0 = new Class1148();

	internal PictureFillMode pictureFillMode_0;

	private Class1148 class1148_1 = new Class1148();

	private double double_0;

	private double double_1;

	private float float_0 = 1f;

	private float float_1 = 1f;

	private TileFlip tileFlip_0;

	private RectangleAlignment rectangleAlignment_0;

	internal int int_0;

	private static readonly PictureFillFormatEffectiveDataPVITemp pictureFillFormatEffectiveDataPVITemp_0 = smethod_0();

	public new uint ActualVersion => uint_1;

	internal override PictureFillFormatEffectiveDataPVITemp Default => pictureFillFormatEffectiveDataPVITemp_0;

	public int Dpi => int_0;

	public PictureFillMode PictureFillMode => pictureFillMode_0;

	public IPictureEffectiveData Picture => class55_0;

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

	internal RectangleF SourceRectangle => class1148_0.method_1(new RectangleF(0f, 0f, class55_0.Image.Width, class55_0.Image.Height));

	IFillParamSource IPictureFillFormatEffectiveData.AsIFillParamSource => this;

	internal PictureFillFormatEffectiveDataPVITemp(PictureFillFormat parentAccessablePVIObject)
		: base(parentAccessablePVIObject)
	{
		class55_0 = new Class55();
	}

	internal PictureFillFormatEffectiveDataPVITemp(FillFormatEffectiveDataPVITemp parentContainerEffectiveDataPVITemp)
		: base((Interface0)parentContainerEffectiveDataPVITemp)
	{
		class55_0 = new Class55();
	}

	internal override PictureFillFormatEffectiveDataPVITemp vmethod_3()
	{
		IPresentationComponent parent = pictureFillFormat_0.Parent;
		if (parent is Control)
		{
			return Default;
		}
		if (parent is OleObjectFrame)
		{
			return Default;
		}
		if (!(parent is PictureFrame))
		{
			throw new ArgumentException();
		}
		return Default;
	}

	private static PictureFillFormatEffectiveDataPVITemp smethod_0()
	{
		return new PictureFillFormatEffectiveDataPVITemp((PictureFillFormat)null);
	}

	internal override void vmethod_1(PictureFillFormat source)
	{
		if (source != null && source.Picture.Image != null)
		{
			class55_0.method_0(source.Picture);
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

	internal override void vmethod_2(IBaseSlide slide, FloatColor styleColor)
	{
		class55_0.method_1(slide, styleColor);
	}

	internal override void vmethod_0(PictureFillFormatEffectiveDataPVITemp source)
	{
		if (source != null)
		{
			class55_0.method_2(source.class55_0);
			class1148_0.method_0(source.class1148_0);
			pictureFillMode_0 = source.PictureFillMode;
			class1148_1.method_0(source.class1148_1);
			double_0 = source.TileOffsetX;
			double_1 = source.TileOffsetY;
			float_0 = source.TileScaleX;
			float_1 = source.TileScaleY;
			tileFlip_0 = source.TileFlip;
			rectangleAlignment_0 = source.TileAlign;
			int_0 = source.Dpi;
		}
	}

	internal RectangleF method_2(int imageWidth, int imageHeight)
	{
		return class1148_0.method_1(new RectangleF(0f, 0f, imageWidth, imageHeight));
	}

	public override bool Equals(object obj)
	{
		if (!(obj is PictureFillFormatEffectiveDataPVITemp obj2))
		{
			return false;
		}
		return method_3(obj2);
	}

	internal bool method_3(PictureFillFormatEffectiveDataPVITemp obj)
	{
		if (obj == null)
		{
			return false;
		}
		if (!class55_0.method_5(obj.class55_0))
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
		if (double_0 != obj.double_0)
		{
			return false;
		}
		if (double_1 != obj.double_1)
		{
			return false;
		}
		if (float_0 != obj.float_0)
		{
			return false;
		}
		if (float_1 != obj.float_1)
		{
			return false;
		}
		if (tileFlip_0 != obj.tileFlip_0)
		{
			return false;
		}
		if (rectangleAlignment_0 != obj.rectangleAlignment_0)
		{
			return false;
		}
		if (int_0 != obj.int_0)
		{
			return false;
		}
		return true;
	}

	internal bool method_4(PictureFillFormatEffectiveData obj)
	{
		if (obj == null)
		{
			return false;
		}
		if (!class55_0.method_6(obj.Picture))
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
