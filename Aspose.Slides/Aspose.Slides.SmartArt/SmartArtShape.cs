using System;
using System.Collections.Generic;
using System.Drawing;
using ns8;

namespace Aspose.Slides.SmartArt;

public class SmartArtShape : IPresentationComponent, ISlideComponent, IHyperlinkContainer, IShape, IGeometryShape, ISmartArtShape
{
	private readonly Class837 class837_0;

	private readonly AutoShape autoShape_0;

	private FillFormat fillFormat_0;

	private LineFormat lineFormat_0;

	private ThreeDFormat threeDFormat_0;

	private EffectFormat effectFormat_0;

	public IShapeStyle ShapeStyle => autoShape_0.ShapeStyle;

	public ShapeType ShapeType
	{
		get
		{
			return autoShape_0.ShapeType;
		}
		set
		{
			switch (value)
			{
			case ShapeType.NotDefined:
				throw new ArgumentException("Can't set a NotDefined type for SmartArtShape");
			case ShapeType.Custom:
				throw new ArgumentException("Can't set a Custom type for SmartArtShape");
			}
			autoShape_0.ShapeType = value;
			class837_0.DataPoint.ShapeType = value;
		}
	}

	public IAdjustValueCollection Adjustments => autoShape_0.Adjustments;

	public bool IsTextHolder => autoShape_0.IsTextHolder;

	public IPlaceholder Placeholder => autoShape_0.Placeholder;

	public bool Hidden
	{
		get
		{
			return autoShape_0.Hidden;
		}
		set
		{
			autoShape_0.Hidden = value;
		}
	}

	public int ZOrderPosition => autoShape_0.ZOrderPosition;

	public ICustomData CustomData => autoShape_0.CustomData;

	public ILineFormat LineFormat => autoShape_0.LineFormat;

	public IThreeDFormat ThreeDFormat => autoShape_0.ThreeDFormat;

	public IEffectFormat EffectFormat => autoShape_0.EffectFormat;

	public IFillFormat FillFormat => autoShape_0.FillFormat;

	IShapeFrame IShape.RawFrame
	{
		get
		{
			throw new NotSupportedException("Getting RawFrame for SmartArtShape is not supported");
		}
		set
		{
			throw new NotSupportedException("Setting RawFrame for SmartArtShape is not supported");
		}
	}

	IShapeFrame IShape.Frame
	{
		get
		{
			throw new NotSupportedException("Getting Frame for SmartArtShape is not supported");
		}
		set
		{
			throw new NotSupportedException("Setting Frame for SmartArtShape is not supported");
		}
	}

	float IShape.Rotation
	{
		get
		{
			throw new NotSupportedException("Getting Rotation for SmartArtShape is not supported");
		}
		set
		{
			throw new NotSupportedException("Setting Rotation for SmartArtShape is not supported");
		}
	}

	float IShape.X
	{
		get
		{
			throw new NotSupportedException("Getting X for SmartArtShape is not supported");
		}
		set
		{
			throw new NotSupportedException("Setting X for SmartArtShape is not supported");
		}
	}

	float IShape.Y
	{
		get
		{
			throw new NotSupportedException("Getting Y for SmartArtShape is not supported");
		}
		set
		{
			throw new NotSupportedException("Setting Y for SmartArtShape is not supported");
		}
	}

	float IShape.Width
	{
		get
		{
			throw new NotSupportedException("Getting Width for SmartArtShape is not supported");
		}
		set
		{
			throw new NotSupportedException("Setting Width for SmartArtShape is not supported");
		}
	}

	float IShape.Height
	{
		get
		{
			throw new NotSupportedException("Getting Height for SmartArtShape is not supported");
		}
		set
		{
			throw new NotSupportedException("Setting Height for SmartArtShape is not supported");
		}
	}

	public string AlternativeText
	{
		get
		{
			return autoShape_0.AlternativeText;
		}
		set
		{
			autoShape_0.AlternativeText = value;
		}
	}

	public string Name
	{
		get
		{
			return autoShape_0.Name;
		}
		set
		{
			autoShape_0.Name = value;
		}
	}

	public IBaseShapeLock ShapeLock => autoShape_0.ShapeLock;

	public uint UniqueId => autoShape_0.UniqueId;

	public bool IsGrouped => autoShape_0.IsGrouped;

	public IGroupShape ParentGroup => autoShape_0.ParentGroup;

	public ISlideComponent AsISlideComponent => autoShape_0;

	public IBaseSlide Slide => autoShape_0.Slide;

	public IPresentationComponent AsIPresentationComponent => autoShape_0;

	public IPresentation Presentation => autoShape_0.Presentation;

	public IShape AsIShape => autoShape_0;

	public IGeometryShape AsIGeometryShape => autoShape_0;

	public IHyperlink HyperlinkClick
	{
		get
		{
			return autoShape_0.HyperlinkClick;
		}
		set
		{
			autoShape_0.HyperlinkClick = value;
		}
	}

	public IHyperlink HyperlinkMouseOver
	{
		get
		{
			return autoShape_0.HyperlinkMouseOver;
		}
		set
		{
			autoShape_0.HyperlinkMouseOver = value;
		}
	}

	public IHyperlinkManager HyperlinkManager => autoShape_0.HyperlinkManager;

	public IHyperlinkContainer AsIHyperlinkContainer => autoShape_0;

	internal AutoShape AutoShapeInternal => autoShape_0;

	internal bool IsFillFormatChanged
	{
		get
		{
			if (fillFormat_0 != null)
			{
				return !fillFormat_0.Equals(autoShape_0.fillFormat_0);
			}
			return false;
		}
	}

	internal bool IsLineFillFormatChanged
	{
		get
		{
			if (lineFormat_0 != null)
			{
				return !lineFormat_0.Equals(autoShape_0.lineFormat_0);
			}
			return false;
		}
	}

	internal bool IsThreeDFormatChanged
	{
		get
		{
			if (threeDFormat_0 != null)
			{
				return threeDFormat_0.Equals(autoShape_0.threeDFormat_0);
			}
			return false;
		}
	}

	internal bool IsEffectFormatChanged
	{
		get
		{
			if (effectFormat_0 != null)
			{
				return effectFormat_0.Equals(autoShape_0.effectFormat_0);
			}
			return false;
		}
	}

	public IShapeElement[] CreateShapeElements()
	{
		return autoShape_0.CreateShapeElements();
	}

	public IPlaceholder AddPlaceholder(IPlaceholder placeholderToCopyFrom)
	{
		return autoShape_0.AddPlaceholder(placeholderToCopyFrom);
	}

	public void RemovePlaceholder()
	{
		autoShape_0.RemovePlaceholder();
	}

	public ILineFormatEffectiveData CreateLineFormatEffective()
	{
		return autoShape_0.CreateLineFormatEffective();
	}

	public IFillFormatEffectiveData CreateFillFormatEffective()
	{
		return autoShape_0.CreateFillFormatEffective();
	}

	public IEffectFormatEffectiveData CreateEffectFormatEffective()
	{
		return autoShape_0.CreateEffectFormatEffective();
	}

	public IThreeDFormatEffectiveData CreateThreeDFormatEffective()
	{
		return autoShape_0.CreateThreeDFormatEffective();
	}

	public Bitmap GetThumbnail()
	{
		return autoShape_0.GetThumbnail();
	}

	public Bitmap GetThumbnail(ShapeThumbnailBounds bounds, float scaleX, float scaleY)
	{
		return autoShape_0.GetThumbnail(bounds, scaleX, scaleY);
	}

	internal SmartArtShape(IBaseSlide slide, Class851 container)
	{
		if (container == null)
		{
			throw new ArgumentNullException();
		}
		class837_0 = container.Target;
		autoShape_0 = new AutoShape(slide);
	}

	internal void method_0()
	{
		List<Class836> list = method_2();
		foreach (Class836 item in list)
		{
			item.DataPoint.method_1(this);
		}
	}

	internal void method_1()
	{
		if (fillFormat_0 == null)
		{
			fillFormat_0 = new FillFormat(autoShape_0);
		}
		if (lineFormat_0 == null)
		{
			lineFormat_0 = new LineFormat(autoShape_0);
		}
		if (threeDFormat_0 == null)
		{
			threeDFormat_0 = new ThreeDFormat(autoShape_0);
		}
		if (effectFormat_0 == null)
		{
			effectFormat_0 = new EffectFormat(autoShape_0);
		}
		fillFormat_0.method_0((FillFormat)autoShape_0.FillFormat);
		lineFormat_0.method_0((LineFormat)autoShape_0.LineFormat);
		threeDFormat_0.method_1((ThreeDFormat)autoShape_0.ThreeDFormat);
		effectFormat_0.method_0((EffectFormat)autoShape_0.EffectFormat);
	}

	private List<Class836> method_2()
	{
		List<Class836> list = new List<Class836>();
		if (class837_0.ConnectedWith.Count == 0)
		{
			list.Add(class837_0);
		}
		else
		{
			foreach (Class836 item in class837_0.ConnectedWith)
			{
				list.Add(item);
			}
		}
		return list;
	}
}
