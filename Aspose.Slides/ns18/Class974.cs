using System;
using Aspose.Slides;
using ns16;
using ns24;
using ns56;

namespace ns18;

internal class Class974
{
	public static void smethod_0(IPictureFillFormat pictureFillFormat, Class1810 blipElementData, Class1341 deserializationContext)
	{
		if (blipElementData == null)
		{
			return;
		}
		Class346 pPTXUnsupportedProps = ((PictureFillFormat)pictureFillFormat).PPTXUnsupportedProps;
		Class977.smethod_0(pictureFillFormat.Picture, blipElementData.Blip, deserializationContext);
		if (blipElementData.SrcRect != null)
		{
			pictureFillFormat.CropLeft = blipElementData.SrcRect.L;
			pictureFillFormat.CropTop = blipElementData.SrcRect.T;
			pictureFillFormat.CropRight = blipElementData.SrcRect.R;
			pictureFillFormat.CropBottom = blipElementData.SrcRect.B;
		}
		pictureFillFormat.Dpi = ((blipElementData.Dpi == uint.MaxValue) ? (-1) : ((int)blipElementData.Dpi));
		pictureFillFormat.PictureFillMode = PictureFillMode.Stretch;
		pPTXUnsupportedProps.StretchFillRectangle.Reset();
		if (blipElementData.FillModeProperties != null)
		{
			switch (blipElementData.FillModeProperties.Name)
			{
			case "stretch":
			{
				Class1927 class2 = (Class1927)blipElementData.FillModeProperties.Object;
				pictureFillFormat.PictureFillMode = PictureFillMode.Stretch;
				Class981.smethod_0(pPTXUnsupportedProps.StretchFillRectangle, class2.FillRect);
				break;
			}
			case "tile":
			{
				Class1974 @class = (Class1974)blipElementData.FillModeProperties.Object;
				pictureFillFormat.PictureFillMode = PictureFillMode.Tile;
				pPTXUnsupportedProps.TileOffsetX = (double.IsNaN(@class.Tx) ? 0.0 : @class.Tx);
				pPTXUnsupportedProps.TileOffsetY = (double.IsNaN(@class.Ty) ? 0.0 : @class.Ty);
				pPTXUnsupportedProps.TileScaleX = (float.IsNaN(@class.Sx) ? 1f : (@class.Sx / 100f));
				pPTXUnsupportedProps.TileScaleY = (float.IsNaN(@class.Sy) ? 1f : (@class.Sy / 100f));
				pPTXUnsupportedProps.TileFlip = ((@class.Flip != TileFlip.NotDefined) ? @class.Flip : TileFlip.NoFlip);
				pPTXUnsupportedProps.TileAlign = ((@class.Algn != RectangleAlignment.NotDefined) ? @class.Algn : RectangleAlignment.TopLeft);
				break;
			}
			default:
				throw new Exception("Unknown element \"" + blipElementData.FillModeProperties.Name + "\"");
			}
		}
	}

	public static void smethod_1(IPictureFillFormat pictureFillFormat, Class1810 blipElementData, Class1346 serializationContext)
	{
		Class346 pPTXUnsupportedProps = ((PictureFillFormat)pictureFillFormat).PPTXUnsupportedProps;
		blipElementData.Dpi = ((pictureFillFormat.Dpi == -1) ? uint.MaxValue : ((uint)pictureFillFormat.Dpi));
		Class977.smethod_1(pictureFillFormat.Picture, blipElementData.delegate1306_0, serializationContext);
		if (pPTXUnsupportedProps.SrcRect.method_3())
		{
			blipElementData.delegate1612_0();
			blipElementData.SrcRect.L = pictureFillFormat.CropLeft;
			blipElementData.SrcRect.T = pictureFillFormat.CropTop;
			blipElementData.SrcRect.R = pictureFillFormat.CropRight;
			blipElementData.SrcRect.B = pictureFillFormat.CropBottom;
		}
		if (pictureFillFormat.PictureFillMode == PictureFillMode.Tile)
		{
			Class1974 @class = (Class1974)blipElementData.delegate2773_0("tile").Object;
			@class.Tx = pPTXUnsupportedProps.TileOffsetX;
			@class.Ty = pPTXUnsupportedProps.TileOffsetY;
			@class.Sx = pPTXUnsupportedProps.TileScaleX * 100f;
			@class.Sy = pPTXUnsupportedProps.TileScaleY * 100f;
			@class.Flip = pPTXUnsupportedProps.TileFlip;
			@class.Algn = pPTXUnsupportedProps.TileAlign;
		}
		else if (pictureFillFormat.PictureFillMode == PictureFillMode.Stretch)
		{
			Class1927 class2 = (Class1927)blipElementData.delegate2773_0("stretch").Object;
			Class981.smethod_1(pPTXUnsupportedProps.StretchFillRectangle, class2.delegate1612_0);
		}
	}
}
