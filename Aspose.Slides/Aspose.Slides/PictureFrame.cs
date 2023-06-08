using System;
using System.Collections.Generic;
using ns11;
using ns24;
using ns7;

namespace Aspose.Slides;

public class PictureFrame : GeometryShape, IPresentationComponent, ISlideComponent, IHyperlinkContainer, IShape, IGeometryShape, IPictureFrame
{
	internal readonly PictureFillFormat pictureFillFormat_0;

	internal static readonly Dictionary<ShapeType, ShapeType> dictionary_0 = GeometryShape.smethod_3(true, ShapeType.Line, ShapeType.StraightConnector1, ShapeType.BentConnector2, ShapeType.BentConnector3, ShapeType.BentConnector4, ShapeType.BentConnector5, ShapeType.CurvedConnector2, ShapeType.CurvedConnector3, ShapeType.CurvedConnector4, ShapeType.CurvedConnector5);

	internal new Class282 PPTXUnsupportedProps => (Class282)base.PPTXUnsupportedProps;

	public new IPictureFrameLock ShapeLock => (IPictureFrameLock)base.ShapeLock;

	public override ShapeType ShapeType
	{
		get
		{
			return base.ShapeType;
		}
		set
		{
			if (!dictionary_0.ContainsKey(value))
			{
				throw new PptxEditException("Incorrect ShapeType value for PictureFrame specified: " + value);
			}
			base.ShapeType = value;
		}
	}

	public IPictureFillFormat PictureFormat => pictureFillFormat_0;

	public float RelativeScaleHeight
	{
		get
		{
			return (float)Math.Round(base.Height / (72f / ((PPImage)PictureFormat.Picture.Image).Dpi.Y * (float)PictureFormat.Picture.Image.Height), 2);
		}
		set
		{
			base.Height = 72f / ((PPImage)PictureFormat.Picture.Image).Dpi.Y * (float)PictureFormat.Picture.Image.Height * value;
		}
	}

	public float RelativeScaleWidth
	{
		get
		{
			return (float)Math.Round(base.Width / (72f / ((PPImage)PictureFormat.Picture.Image).Dpi.X * (float)PictureFormat.Picture.Image.Width), 2);
		}
		set
		{
			base.Width = 72f / ((PPImage)PictureFormat.Picture.Image).Dpi.X * (float)PictureFormat.Picture.Image.Width * value;
		}
	}

	IGeometryShape IPictureFrame.AsIGeometryShape => this;

	internal PictureFrame(IBaseSlide parent, Class282 pptxUnsupportedProps)
		: base(parent, pptxUnsupportedProps)
	{
		pictureFillFormat_0 = new PictureFillFormat(this);
		base.ShapeLock = new PictureFrameLock();
	}

	internal PictureFrame(IBaseSlide parent)
		: this(parent, new Class282())
	{
	}

	internal override void vmethod_4(Class159 canvas, Class169 rc)
	{
		if (base.Hidden)
		{
			return;
		}
		if (base.HyperlinkClick != null)
		{
			canvas.vmethod_16(base.HyperlinkClick);
		}
		ShapeFrame shapeFrame = method_4();
		float x = shapeFrame.X;
		float y = shapeFrame.Y;
		float width = shapeFrame.Width;
		float height = shapeFrame.Height;
		if (float.IsNaN(x) || float.IsNaN(y) || float.IsNaN(width) || float.IsNaN(height))
		{
			return;
		}
		canvas.Transform = Shape.smethod_0(shapeFrame);
		Shape[] array = method_2();
		Class540 geometry = base.Geometry;
		if (geometry.Preset == ShapeType.NotDefined)
		{
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i] is GeometryShape geometryShape && geometryShape.Geometry.Preset != ShapeType.NotDefined)
				{
					geometry = geometryShape.Geometry;
					break;
				}
			}
		}
		ShapeElement[] elems = geometry.CreateShapeElements(this, x, y, width, height);
		method_17(canvas, rc, elems, shapeFrame, FillFormat, array);
		method_17(canvas, rc, elems, shapeFrame, PictureFormat, array);
		method_18(canvas, rc, elems, shapeFrame, array);
		if (base.HyperlinkClick != null)
		{
			canvas.vmethod_17();
		}
	}
}
