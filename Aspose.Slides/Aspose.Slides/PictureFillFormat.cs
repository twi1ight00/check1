using System;
using System.Drawing;
using ns24;
using ns28;
using ns33;

namespace Aspose.Slides;

public class PictureFillFormat : IAccessiblePVIObject<PictureFillFormatEffectiveDataPVITemp>, IFillParamSource, IPictureFillFormat, IPVIObject
{
	private readonly Picture picture_0;

	private PictureFillMode pictureFillMode_0;

	private int int_0;

	private IPresentationComponent ipresentationComponent_0;

	private readonly Class346 class346_0 = new Class346();

	internal PictureFillFormatEffectiveDataPVITemp pictureFillFormatEffectiveDataPVITemp_0;

	private uint uint_0;

	private static Class1155 class1155_0 = new Class1155(RectangleAlignment.TopLeft, Enum37.const_0, RectangleAlignment.Top, Enum37.const_1, RectangleAlignment.TopRight, Enum37.const_2, RectangleAlignment.Left, Enum37.const_3, RectangleAlignment.Center, Enum37.const_4, RectangleAlignment.Right, Enum37.const_5, RectangleAlignment.BottomLeft, Enum37.const_7, RectangleAlignment.Bottom, Enum37.const_7, RectangleAlignment.BottomRight, Enum37.const_8, RectangleAlignment.NotDefined, Enum37.const_0);

	internal Class346 PPTXUnsupportedProps => class346_0;

	public int Dpi
	{
		get
		{
			return int_0;
		}
		set
		{
			int_0 = Class1165.smethod_4(value, -1, 1000000);
			method_5();
		}
	}

	public PictureFillMode PictureFillMode
	{
		get
		{
			return pictureFillMode_0;
		}
		set
		{
			pictureFillMode_0 = value;
			method_5();
		}
	}

	public ISlidesPicture Picture => picture_0;

	internal Class1148 StretchFillRectangle => PPTXUnsupportedProps.StretchFillRectangle;

	internal double TileOffsetX => PPTXUnsupportedProps.TileOffsetX;

	internal double TileOffsetY => PPTXUnsupportedProps.TileOffsetY;

	internal float TileScaleX => PPTXUnsupportedProps.TileScaleX;

	internal float TileScaleY => PPTXUnsupportedProps.TileScaleY;

	internal TileFlip TileFlip => PPTXUnsupportedProps.TileFlip;

	internal RectangleAlignment TileAlign => PPTXUnsupportedProps.TileAlign;

	public float CropLeft
	{
		get
		{
			return PPTXUnsupportedProps.SrcRect.Left * 100f;
		}
		set
		{
			PPTXUnsupportedProps.SrcRect.Left = value / 100f;
			method_5();
		}
	}

	public float CropTop
	{
		get
		{
			return PPTXUnsupportedProps.SrcRect.Top * 100f;
		}
		set
		{
			PPTXUnsupportedProps.SrcRect.Top = value / 100f;
			method_5();
		}
	}

	public float CropRight
	{
		get
		{
			return (1f - PPTXUnsupportedProps.SrcRect.Right) * 100f;
		}
		set
		{
			PPTXUnsupportedProps.SrcRect.Right = 1f - value / 100f;
			method_5();
		}
	}

	public float CropBottom
	{
		get
		{
			return (1f - PPTXUnsupportedProps.SrcRect.Bottom) * 100f;
		}
		set
		{
			PPTXUnsupportedProps.SrcRect.Bottom = 1f - value / 100f;
			method_5();
		}
	}

	IPresentationComponent IAccessiblePVIObject<PictureFillFormatEffectiveDataPVITemp>.Parent => Parent;

	internal IPresentationComponent Parent => ipresentationComponent_0;

	uint IPVIObject.Version => Version;

	internal uint Version => uint_0 + picture_0.Version + class346_0.Version;

	IFillParamSource IPictureFillFormat.AsIFillParamSource => this;

	internal PictureFillFormat(IPresentationComponent parent)
	{
		ipresentationComponent_0 = parent;
		picture_0 = new Picture(parent);
		pictureFillFormatEffectiveDataPVITemp_0 = new PictureFillFormatEffectiveDataPVITemp(this);
	}

	internal RectangleF method_0(int imageWidth, int imageHeight)
	{
		return PPTXUnsupportedProps.SrcRect.method_1(new RectangleF(0f, 0f, imageWidth, imageHeight));
	}

	internal void method_1(PictureFillFormat source)
	{
		PPTXUnsupportedProps.method_0(source.PPTXUnsupportedProps);
		picture_0.method_0(source.picture_0);
		pictureFillMode_0 = source.pictureFillMode_0;
		int_0 = source.int_0;
		method_5();
	}

	internal void method_2(PictureFillFormatEffectiveData source)
	{
		picture_0.method_1(source.pictureEffectiveData_0);
		pictureFillMode_0 = source.pictureFillMode_0;
		int_0 = source.int_0;
		method_5();
	}

	internal void method_3(Class470 fillProp, Class476 package)
	{
		int num = package.method_7(package.class465_0.method_2(fillProp.FillImageName).Href);
		if (num != -1)
		{
			Picture.Image = ipresentationComponent_0.Presentation.Images[num];
		}
		if (fillProp.FillImageRenderingStyle == Enum38.const_2)
		{
			PictureFillMode = PictureFillMode.Stretch;
		}
		else
		{
			PictureFillMode = PictureFillMode.Tile;
			PPTXUnsupportedProps.TileAlign = (RectangleAlignment)class1155_0[fillProp.FillImageTileRefPoint];
			if (Picture.Image != null)
			{
				Image systemImage = Picture.Image.SystemImage;
				float horizontalResolution = systemImage.HorizontalResolution;
				float verticalResolution = systemImage.VerticalResolution;
				if (!double.IsNaN(fillProp.FillImageTileWidth) && fillProp.FillImageTileWidth != 0.0)
				{
					PPTXUnsupportedProps.TileScaleX = (float)(fillProp.FillImageTileWidth * (double)horizontalResolution / 96.0 / (double)systemImage.Width);
				}
				else
				{
					PPTXUnsupportedProps.TileScaleX = 1f;
				}
				if (!double.IsNaN(fillProp.FillImageTileWidth) && fillProp.FillImageTileHeight != 0.0)
				{
					PPTXUnsupportedProps.TileScaleY = (float)(fillProp.FillImageTileHeight * (double)verticalResolution / 96.0 / (double)systemImage.Height);
				}
				else
				{
					PPTXUnsupportedProps.TileScaleY = 1f;
				}
				float num2 = (float)(systemImage.Width * 96) / horizontalResolution * PPTXUnsupportedProps.TileScaleX;
				float num3 = (float)(systemImage.Height * 96) / verticalResolution * PPTXUnsupportedProps.TileScaleY;
				PPTXUnsupportedProps.TileOffsetX = (float)fillProp.FillImageTileOffsetX / 100f * num2;
				PPTXUnsupportedProps.TileOffsetY = (float)fillProp.FillImageTileOffsetY / 100f * num3;
			}
		}
		method_5();
	}

	internal void method_4(Class470 fillProp, BaseSlide slide, Class476 odpPackage)
	{
		switch (PictureFillMode)
		{
		default:
			fillProp.FillImageRenderingStyle = Enum38.const_0;
			break;
		case PictureFillMode.Tile:
		{
			fillProp.FillImageRenderingStyle = Enum38.const_1;
			fillProp.FillImageTileRefPoint = (Enum37)class1155_0[PPTXUnsupportedProps.TileAlign];
			Image systemImage = Picture.Image.SystemImage;
			float horizontalResolution = systemImage.HorizontalResolution;
			float verticalResolution = systemImage.VerticalResolution;
			fillProp.FillImageTileWidth = (float)(systemImage.Width * 96) / horizontalResolution * PPTXUnsupportedProps.TileScaleX;
			fillProp.FillImageTileHeight = (float)(systemImage.Height * 96) / verticalResolution * PPTXUnsupportedProps.TileScaleY;
			fillProp.FillImageTileOffsetX = (int)Math.Round(PPTXUnsupportedProps.TileOffsetX / fillProp.FillImageTileWidth * 100.0);
			fillProp.FillImageTileOffsetY = (int)Math.Round(PPTXUnsupportedProps.TileOffsetY / fillProp.FillImageTileHeight * 100.0);
			break;
		}
		case PictureFillMode.Stretch:
			fillProp.FillImageRenderingStyle = Enum38.const_2;
			break;
		}
		string imgName = (fillProp.FillImageName = "Img" + odpPackage.int_0++);
		odpPackage.class465_0.method_3(imgName, odpPackage.method_9(Picture.Image));
	}

	private void method_5()
	{
		uint_0++;
	}

	internal PictureFillFormatEffectiveDataPVITemp method_6()
	{
		pictureFillFormatEffectiveDataPVITemp_0.method_0();
		return pictureFillFormatEffectiveDataPVITemp_0;
	}
}
