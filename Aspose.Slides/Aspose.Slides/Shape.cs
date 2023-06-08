using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Threading;
using ns11;
using ns22;
using ns224;
using ns24;
using ns33;
using ns4;
using ns7;

namespace Aspose.Slides;

public class Shape : IPresentationComponent, ISlideComponent, IHyperlinkContainer, IShape
{
	internal delegate void Delegate1(Shape which);

	private BaseSlide baseSlide_0;

	private Class280 class280_0 = new Class280();

	private Class273 class273_0 = new Class273();

	private IBaseShapeLock ibaseShapeLock_0;

	internal LineFormat lineFormat_0;

	internal ThreeDFormat threeDFormat_0;

	internal FillFormat fillFormat_0;

	internal EffectFormat effectFormat_0;

	private Class154 class154_0;

	private Placeholder placeholder_0;

	private CustomData customData_0;

	private string string_0;

	private string string_1;

	private Hyperlink hyperlink_0;

	private Hyperlink hyperlink_1;

	private HyperlinkManager hyperlinkManager_0;

	private bool bool_0;

	private string string_2 = "";

	private string string_3 = "";

	internal ShapeCollection shapeCollection_0;

	internal uint uint_0;

	internal uint uint_1 = uint.MaxValue;

	private Delegate1 delegate1_0;

	internal static readonly PointF[] pointF_0 = new PointF[0];

	private int int_0 = -1;

	public bool IsTextHolder => placeholder_0 != null;

	public IPlaceholder Placeholder => placeholder_0;

	[Obsolete("Use CustomData.Tags instead. Will be removed after 01.09.2014.")]
	public ITagCollection Tags => customData_0.Tags;

	public ICustomData CustomData => customData_0;

	public IShapeFrame RawFrame
	{
		get
		{
			vmethod_6();
			Class154 rawFrameImpl = RawFrameImpl;
			return new ShapeFrame(rawFrameImpl.X, rawFrameImpl.Y, rawFrameImpl.Width, rawFrameImpl.Height, rawFrameImpl.FlipH, rawFrameImpl.FlipV, rawFrameImpl.Rotation);
		}
		set
		{
			class154_0.method_1(value.X, value.Y, value.Width, value.Height, value.Rotation, value.FlipH, value.FlipV);
			method_13();
		}
	}

	internal virtual Class154 RawFrameImpl
	{
		get
		{
			return class154_0;
		}
		set
		{
			if (class154_0 == null)
			{
				class154_0 = new Class154();
			}
			class154_0.method_1(value.X, value.Y, value.Width, value.Height, value.Rotation, value.FlipH, value.FlipV);
		}
	}

	internal Class154 Transform2DInternal
	{
		set
		{
			class154_0 = value;
		}
	}

	public IShapeFrame Frame
	{
		get
		{
			vmethod_6();
			return FrameImpl;
		}
		set
		{
			if (float.IsNaN(value.X) || float.IsNaN(value.Y) || float.IsNaN(value.Width) || float.IsNaN(value.Height) || value.FlipH == NullableBool.NotDefined || value.FlipV == NullableBool.NotDefined || float.IsNaN(value.Rotation))
			{
				throw new ArgumentException("Value of each property of the assigned IShapeFrame instance must be not undefined (must be not NaN or NotDefined).");
			}
			FrameImpl = (ShapeFrame)value;
			method_13();
		}
	}

	internal ShapeFrame FrameImpl
	{
		get
		{
			return method_4();
		}
		set
		{
			method_6(value);
		}
	}

	public virtual ILineFormat LineFormat => lineFormat_0;

	public virtual IThreeDFormat ThreeDFormat => threeDFormat_0;

	public virtual IEffectFormat EffectFormat => effectFormat_0;

	public virtual IFillFormat FillFormat => fillFormat_0;

	public IHyperlink HyperlinkClick
	{
		get
		{
			return hyperlink_0;
		}
		set
		{
			hyperlink_0 = (Hyperlink)value;
		}
	}

	[Obsolete("Use HyperlinkClick property instead. Property will be removed after 01.09.2013.")]
	public Hyperlink HLinkClick
	{
		get
		{
			return hyperlink_0;
		}
		set
		{
			hyperlink_0 = value;
		}
	}

	public IHyperlink HyperlinkMouseOver
	{
		get
		{
			return hyperlink_1;
		}
		set
		{
			hyperlink_1 = (Hyperlink)value;
		}
	}

	[Obsolete("Use HyperlinkMouseOver property instead. Property will be removed after 01.09.2013.")]
	public Hyperlink HLinkMouseOver
	{
		get
		{
			return hyperlink_1;
		}
		set
		{
			hyperlink_1 = value;
		}
	}

	public IHyperlinkManager HyperlinkManager => hyperlinkManager_0;

	internal Class280 PPTXUnsupportedProps => class280_0;

	internal Class273 PPTUnsupportedProps => class273_0;

	public bool Hidden
	{
		get
		{
			return bool_0;
		}
		set
		{
			bool_0 = value;
		}
	}

	internal PointF[] ConnectionPoints
	{
		get
		{
			PointF[] connectionPointsInternal = ConnectionPointsInternal;
			IShapeFrame frame = Frame;
			if (connectionPointsInternal != null && connectionPointsInternal.Length != 0)
			{
				PointF[] array = new PointF[connectionPointsInternal.Length];
				for (int i = 0; i < connectionPointsInternal.Length; i++)
				{
					ref PointF reference = ref array[i];
					reference = new PointF(frame.X + connectionPointsInternal[i].X * frame.Width, frame.Y + connectionPointsInternal[i].Y * frame.Height);
				}
				return array;
			}
			return pointF_0;
		}
	}

	internal virtual PointF[] ConnectionPointsInternal => null;

	internal bool ConnectionPointsDefined => ConnectionPointsInternal == null;

	public virtual int ZOrderPosition
	{
		get
		{
			int result = 0;
			if (shapeCollection_0 != null)
			{
				result = shapeCollection_0.IndexOf(this);
			}
			return result;
		}
	}

	public float Rotation
	{
		get
		{
			return FrameImpl.Rotation;
		}
		set
		{
			IShapeFrame frame = Frame;
			value = ShapeFrame.smethod_0(value);
			if ((double)Math.Abs(frame.Rotation - value) > 0.0001)
			{
				Frame = new ShapeFrame(frame.X, frame.Y, frame.Width, frame.Height, frame.FlipH, frame.FlipV, value);
				method_13();
			}
		}
	}

	internal bool SwapXY
	{
		get
		{
			float num = ShapeFrame.smethod_0(class154_0.Rotation);
			if (num > 45f && !(num >= 135f))
			{
				return true;
			}
			if (num > 225f)
			{
				return num < 315f;
			}
			return false;
		}
	}

	internal RectangleF ShapeRectangleRotated
	{
		get
		{
			ShapeFrame shapeFrame = method_1();
			if (SwapXY)
			{
				float num = shapeFrame.X + shapeFrame.Width / 2f;
				float num2 = shapeFrame.Y + shapeFrame.Height / 2f;
				return new RectangleF(num - shapeFrame.Height / 2f, num2 - shapeFrame.Width / 2f, shapeFrame.Height, shapeFrame.Width);
			}
			return shapeFrame.Rectangle;
		}
	}

	public float X
	{
		get
		{
			return Frame.X;
		}
		set
		{
			IShapeFrame frame = Frame;
			if ((double)Math.Abs(frame.X - value) > 0.0001)
			{
				Frame = new ShapeFrame(value, frame.Y, frame.Width, frame.Height, frame.FlipH, frame.FlipV, frame.Rotation);
				method_13();
			}
		}
	}

	public float Y
	{
		get
		{
			return Frame.Y;
		}
		set
		{
			IShapeFrame frame = Frame;
			if ((double)Math.Abs(frame.Y - value) > 0.0001)
			{
				Frame = new ShapeFrame(frame.X, value, frame.Width, frame.Height, frame.FlipH, frame.FlipV, frame.Rotation);
				method_13();
			}
		}
	}

	public float Width
	{
		get
		{
			return Frame.Width;
		}
		set
		{
			IShapeFrame frame = Frame;
			if ((double)Math.Abs(frame.Width - value) > 0.0001)
			{
				Frame = new ShapeFrame(frame.X, frame.Y, value, frame.Height, frame.FlipH, frame.FlipV, frame.Rotation);
				method_13();
			}
		}
	}

	public float Height
	{
		get
		{
			return Frame.Height;
		}
		set
		{
			IShapeFrame frame = Frame;
			if ((double)Math.Abs(frame.Height - value) > 0.0001)
			{
				Frame = new ShapeFrame(frame.X, frame.Y, frame.Width, value, frame.FlipH, frame.FlipV, frame.Rotation);
				method_13();
			}
		}
	}

	[Obsolete]
	internal virtual uint ShapeId => PPTXUnsupportedProps.ShapeId;

	public uint UniqueId
	{
		get
		{
			if (int_0 == -1)
			{
				int_0 = (int)((Presentation)Presentation).method_1();
			}
			return (uint)int_0;
		}
	}

	public virtual string AlternativeText
	{
		get
		{
			return string_3;
		}
		set
		{
			string_3 = value;
		}
	}

	public virtual string Name
	{
		get
		{
			return string_2;
		}
		set
		{
			if (value == null)
			{
				throw new ArgumentNullException("Must be not null. Use empty string value.");
			}
			string_2 = value;
		}
	}

	public IBaseShapeLock ShapeLock
	{
		get
		{
			return ibaseShapeLock_0;
		}
		protected set
		{
			ibaseShapeLock_0 = value;
		}
	}

	internal virtual uint Version_OldMode => uint_0;

	public bool IsGrouped
	{
		get
		{
			if (shapeCollection_0 != null)
			{
				return shapeCollection_0.groupShape_0.shapeCollection_0 != null;
			}
			return false;
		}
	}

	public IGroupShape ParentGroup => ParentGroupInternal;

	internal GroupShape ParentGroupInternal
	{
		get
		{
			if (shapeCollection_0 == null)
			{
				return null;
			}
			return shapeCollection_0.groupShape_0;
		}
	}

	internal string GeometryTextFont
	{
		get
		{
			return string_0;
		}
		set
		{
			string_0 = value;
		}
	}

	internal string GeometryText
	{
		get
		{
			return string_1;
		}
		set
		{
			string_1 = value;
		}
	}

	public IBaseSlide Slide => baseSlide_0;

	internal BaseSlide SlideInternal => baseSlide_0;

	public IPresentation Presentation
	{
		get
		{
			if (baseSlide_0 == null)
			{
				return null;
			}
			return baseSlide_0.ParentPresentation;
		}
	}

	IHyperlinkContainer IShape.AsIHyperlinkContainer => this;

	IPresentationComponent ISlideComponent.AsIPresentationComponent => this;

	ISlideComponent IShape.AsISlideComponent => this;

	internal event Delegate1 m_shapeRemoved
	{
		add
		{
			Delegate1 @delegate = delegate1_0;
			Delegate1 delegate2;
			do
			{
				delegate2 = @delegate;
				Delegate1 value2 = (Delegate1)Delegate.Combine(delegate2, value);
				@delegate = Interlocked.CompareExchange(ref delegate1_0, value2, delegate2);
			}
			while ((object)@delegate != delegate2);
		}
		remove
		{
			Delegate1 @delegate = delegate1_0;
			Delegate1 delegate2;
			do
			{
				delegate2 = @delegate;
				Delegate1 value2 = (Delegate1)Delegate.Remove(delegate2, value);
				@delegate = Interlocked.CompareExchange(ref delegate1_0, value2, delegate2);
			}
			while ((object)@delegate != delegate2);
		}
	}

	internal void method_0(Orientation orientation, PlaceholderSize size, PlaceholderType type, uint index, bool hasCustomPrompt)
	{
		placeholder_0 = new Placeholder(orientation, size, type, index, hasCustomPrompt);
		if (Slide != null)
		{
			((BaseSlide)Slide).class518_0.AddPlaceholder(this);
		}
	}

	public void RemovePlaceholder()
	{
		if (placeholder_0 != null)
		{
			((BaseSlide)Slide).class518_0.RemovePlaceholder(this);
		}
		placeholder_0 = null;
	}

	public IPlaceholder AddPlaceholder(IPlaceholder placeholderToCopyFrom)
	{
		if (IsGrouped)
		{
			throw new InvalidOperationException("Grouped shape cannot be a placeholder.");
		}
		if (placeholder_0 == null)
		{
			placeholder_0 = new Placeholder();
			((BaseSlide)Slide).class518_0.AddPlaceholder(this);
		}
		placeholder_0.method_1((Placeholder)placeholderToCopyFrom);
		return placeholder_0;
	}

	internal ShapeFrame method_1()
	{
		Shape[] array = method_2();
		vmethod_6();
		Class154 rawFrameImpl = RawFrameImpl;
		double num = rawFrameImpl.X;
		double num2 = rawFrameImpl.Y;
		double num3 = rawFrameImpl.Width;
		double num4 = rawFrameImpl.Height;
		float num5 = rawFrameImpl.Rotation;
		NullableBool nullableBool = rawFrameImpl.FlipH;
		NullableBool nullableBool2 = rawFrameImpl.FlipV;
		if (double.IsNaN(num) || double.IsNaN(num2) || double.IsNaN(num3) || double.IsNaN(num4) || float.IsNaN(num5) || nullableBool == NullableBool.NotDefined || nullableBool2 == NullableBool.NotDefined)
		{
			foreach (Shape shape in array)
			{
				IShapeFrame frame = shape.Frame;
				if (double.IsNaN(num))
				{
					num = frame.X;
				}
				if (double.IsNaN(num2))
				{
					num2 = frame.Y;
				}
				if (double.IsNaN(num3))
				{
					num3 = frame.Width;
				}
				if (double.IsNaN(num4))
				{
					num4 = frame.Height;
				}
				if (float.IsNaN(num5))
				{
					num5 = frame.Rotation;
				}
				if (nullableBool == NullableBool.NotDefined)
				{
					nullableBool = frame.FlipH;
				}
				if (nullableBool2 == NullableBool.NotDefined)
				{
					nullableBool2 = frame.FlipV;
				}
				if (!double.IsNaN(num) && !double.IsNaN(num2) && !double.IsNaN(num3) && !double.IsNaN(num4) && !float.IsNaN(num5) && nullableBool != NullableBool.NotDefined && nullableBool2 != NullableBool.NotDefined)
				{
					break;
				}
			}
		}
		if (double.IsNaN(num))
		{
			num = 0.0;
		}
		if (double.IsNaN(num2))
		{
			num2 = 0.0;
		}
		if (double.IsNaN(num3))
		{
			num3 = 0.0;
		}
		if (double.IsNaN(num4))
		{
			num4 = 0.0;
		}
		if (float.IsNaN(num5))
		{
			num5 = 0f;
		}
		if (nullableBool == NullableBool.NotDefined)
		{
			nullableBool = NullableBool.False;
		}
		if (nullableBool2 == NullableBool.NotDefined)
		{
			nullableBool2 = NullableBool.False;
		}
		return new ShapeFrame(num, num2, num3, num4, nullableBool, nullableBool2, num5);
	}

	internal Shape[] method_2()
	{
		if (baseSlide_0 != null && placeholder_0 != null)
		{
			return baseSlide_0.vmethod_0(placeholder_0);
		}
		return BaseSlide.shape_0;
	}

	internal Shape method_3()
	{
		if (baseSlide_0 != null && placeholder_0 != null)
		{
			if (baseSlide_0 is Slide)
			{
				Slide slide = (Slide)baseSlide_0;
				LayoutSlide layoutSlideInternal = slide.LayoutSlideInternal;
				if (layoutSlideInternal == null)
				{
					return null;
				}
				MasterSlide masterSlide = (MasterSlide)layoutSlideInternal.MasterSlide;
				if (placeholder_0.Index == uint.MaxValue)
				{
					Shape result = null;
					if (masterSlide != null)
					{
						result = masterSlide.class518_0.method_1(placeholder_0, null);
					}
					return result;
				}
				return layoutSlideInternal.class518_0.method_0(placeholder_0);
			}
			if (baseSlide_0 is LayoutSlide)
			{
				LayoutSlide layoutSlide = (LayoutSlide)baseSlide_0;
				return ((MasterSlide)layoutSlide.MasterSlide)?.class518_0.method_1(placeholder_0, null);
			}
			if (baseSlide_0 is NotesSlide)
			{
				if (Presentation != null && Presentation.MasterNotesSlideManager.MasterNotesSlide != null)
				{
					return ((BaseSlide)Presentation.MasterNotesSlideManager.MasterNotesSlide).class518_0.method_1(placeholder_0, null);
				}
				return null;
			}
			return null;
		}
		return null;
	}

	internal ShapeFrame method_4()
	{
		return method_5(method_1());
	}

	internal ShapeFrame method_5(IShapeFrame frameRect)
	{
		bool flag;
		bool flag2 = (flag = SwapXY);
		bool flag3 = frameRect.FlipH == NullableBool.True;
		bool flag4 = frameRect.FlipV == NullableBool.True;
		float num = frameRect.Rotation;
		PointF pointF = new PointF(frameRect.CenterX, frameRect.CenterY);
		PointF lastRef = pointF;
		double num2 = frameRect.Width;
		double num3 = frameRect.Height;
		GroupShape parentGroupInternal = ParentGroupInternal;
		while (parentGroupInternal.shapeCollection_0 != null || parentGroupInternal.PPTXUnsupportedProps.ParentShape != null)
		{
			if (parentGroupInternal.shapeCollection_0 != null)
			{
				Class154 rawFrameImpl = parentGroupInternal.RawFrameImpl;
				if (!flag)
				{
					num2 *= parentGroupInternal.RawFrameImpl.ScaleX;
					num3 *= parentGroupInternal.RawFrameImpl.ScaleY;
				}
				else
				{
					num2 *= parentGroupInternal.RawFrameImpl.ScaleY;
					num3 *= parentGroupInternal.RawFrameImpl.ScaleX;
				}
				if (!(flag ^ flag2))
				{
					flag3 ^= rawFrameImpl.FlipH == NullableBool.True;
					flag4 ^= rawFrameImpl.FlipV == NullableBool.True;
				}
				else
				{
					flag3 ^= rawFrameImpl.FlipV == NullableBool.True;
					flag4 ^= rawFrameImpl.FlipH == NullableBool.True;
				}
				if ((rawFrameImpl.FlipH == NullableBool.True) ^ (rawFrameImpl.FlipV == NullableBool.True))
				{
					num = 0f - num;
				}
				num += rawFrameImpl.Rotation;
				flag ^= parentGroupInternal.SwapXY;
				pointF = parentGroupInternal.method_15(pointF, lastRef);
				lastRef = new PointF((float)parentGroupInternal.RawFrameImpl.CenterX, (float)parentGroupInternal.RawFrameImpl.CenterY);
				parentGroupInternal = parentGroupInternal.ParentGroupInternal;
			}
			else
			{
				Class154 rawFrameImpl2 = ((Shape)parentGroupInternal.PPTXUnsupportedProps.ParentShape).RawFrameImpl;
				if (!(flag ^ flag2))
				{
					flag3 ^= rawFrameImpl2.FlipH == NullableBool.True;
					flag4 ^= rawFrameImpl2.FlipV == NullableBool.True;
				}
				else
				{
					flag3 ^= rawFrameImpl2.FlipV == NullableBool.True;
					flag4 ^= rawFrameImpl2.FlipH == NullableBool.True;
				}
				flag ^= parentGroupInternal.SwapXY;
				pointF = new PointF((float)((double)pointF.X + rawFrameImpl2.X), (float)((double)pointF.Y + rawFrameImpl2.Y));
				lastRef = new PointF((float)rawFrameImpl2.X, (float)rawFrameImpl2.Y);
				parentGroupInternal = ((Shape)parentGroupInternal.PPTXUnsupportedProps.ParentShape).ParentGroupInternal;
			}
		}
		return new ShapeFrame((float)((double)pointF.X - num2 / 2.0), (float)((double)pointF.Y - num3 / 2.0), (float)num2, (float)num3, flag3 ? NullableBool.True : NullableBool.False, flag4 ? NullableBool.True : NullableBool.False, ShapeFrame.smethod_0(num));
	}

	internal void method_6(ShapeFrame value)
	{
		RawFrameImpl = method_8(value);
		method_7();
	}

	private void method_7()
	{
		List<GroupShape> list = new List<GroupShape>();
		GroupShape parentGroupInternal = ParentGroupInternal;
		while (parentGroupInternal.shapeCollection_0 != null)
		{
			list.Add(parentGroupInternal);
			parentGroupInternal = parentGroupInternal.ParentGroupInternal;
		}
		for (int i = 0; i < list.Count; i++)
		{
			list[i].method_17();
		}
	}

	internal Class154 method_8(ShapeFrame value)
	{
		float num = value.Rotation;
		bool flag = false;
		bool flag2 = false;
		bool flag3 = false;
		double num2 = value.CenterX;
		double num3 = value.CenterY;
		double num4 = value.Width;
		double num5 = value.Height;
		double num6 = 1.0;
		double num7 = 1.0;
		GroupShape parentGroupInternal = ParentGroupInternal;
		List<GroupShape> list = new List<GroupShape>();
		while (parentGroupInternal.shapeCollection_0 != null)
		{
			list.Add(parentGroupInternal);
			parentGroupInternal = parentGroupInternal.ParentGroupInternal;
		}
		for (int num8 = list.Count - 1; num8 >= 0; num8--)
		{
			parentGroupInternal = list[num8];
			Class154 rawFrameImpl = parentGroupInternal.RawFrameImpl;
			num -= rawFrameImpl.Rotation;
			if ((rawFrameImpl.FlipH == NullableBool.True) ^ (rawFrameImpl.FlipV == NullableBool.True))
			{
				num = 0f - num;
			}
			flag ^= parentGroupInternal.SwapXY;
			if (parentGroupInternal.SwapXY)
			{
				double num9 = num6;
				num6 = num7;
				num7 = num9;
				bool flag4 = flag2;
				flag2 = flag3;
				flag3 = flag4;
			}
			flag2 ^= rawFrameImpl.FlipH == NullableBool.True;
			flag3 ^= rawFrameImpl.FlipV == NullableBool.True;
			num6 *= parentGroupInternal.RawFrameImpl.ScaleX;
			num7 *= parentGroupInternal.RawFrameImpl.ScaleY;
			double num10 = (double)((0f - rawFrameImpl.Rotation) / 180f) * Math.PI;
			double num11 = Math.Cos(num10);
			double num12 = Math.Sin(num10);
			double num13 = num2 - parentGroupInternal.RawFrameImpl.CenterX;
			double num14 = num3 - parentGroupInternal.RawFrameImpl.CenterY;
			if (num8 > 0)
			{
				GroupShape groupShape = list[num8 - 1];
				double centerX = groupShape.RawFrameImpl.CenterX;
				double centerY = groupShape.RawFrameImpl.CenterY;
				num2 = (num13 * num11 - num14 * num12) * (double)((rawFrameImpl.FlipH != NullableBool.True) ? 1 : (-1)) - (centerX - parentGroupInternal.RawFrameImpl.ReferrenceCenterX) * num6 + centerX;
				num3 = (num13 * num12 + num14 * num11) * (double)((rawFrameImpl.FlipV != NullableBool.True) ? 1 : (-1)) - (centerY - parentGroupInternal.RawFrameImpl.ReferrenceCenterY) * num7 + centerY;
			}
			else
			{
				num2 = (num13 * num11 - num14 * num12) * (double)((rawFrameImpl.FlipH != NullableBool.True) ? 1 : (-1)) / num6 + parentGroupInternal.RawFrameImpl.ReferrenceCenterX;
				num3 = (num13 * num12 + num14 * num11) * (double)((rawFrameImpl.FlipV != NullableBool.True) ? 1 : (-1)) / num7 + parentGroupInternal.RawFrameImpl.ReferrenceCenterY;
			}
		}
		num = ShapeFrame.smethod_0(num);
		if (!(flag = (num > 45f && !(num >= 135f)) || (num > 225f && num < 315f)))
		{
			num4 /= num6;
			num5 /= num7;
		}
		else
		{
			num4 /= num7;
			num5 /= num6;
			bool flag5 = flag2;
			flag2 = flag3;
			flag3 = flag5;
		}
		flag2 ^= value.FlipH == NullableBool.True;
		flag3 ^= value.FlipV == NullableBool.True;
		return new Class154((float)(num2 - num4 / 2.0), (float)(num3 - num5 / 2.0), (float)num4, (float)num5, num, flag2 ? NullableBool.True : NullableBool.False, flag3 ? NullableBool.True : NullableBool.False);
	}

	public ILineFormatEffectiveData CreateLineFormatEffective()
	{
		return vmethod_0();
	}

	public IFillFormatEffectiveData CreateFillFormatEffective()
	{
		return vmethod_1();
	}

	public IEffectFormatEffectiveData CreateEffectFormatEffective()
	{
		return vmethod_2();
	}

	public IThreeDFormatEffectiveData CreateThreeDFormatEffective()
	{
		return vmethod_3();
	}

	internal virtual LineFormatEffectiveData vmethod_0()
	{
		return null;
	}

	internal virtual FillFormatEffectiveData vmethod_1()
	{
		return null;
	}

	internal virtual EffectFormatEffectiveData vmethod_2()
	{
		return null;
	}

	internal virtual ThreeDFormatEffectiveData vmethod_3()
	{
		return null;
	}

	public Bitmap GetThumbnail()
	{
		return GetThumbnail(ShapeThumbnailBounds.Shape, 1f, 1f);
	}

	public Bitmap GetThumbnail(ShapeThumbnailBounds bounds, float scaleX, float scaleY)
	{
		float num = ((Presentation.SlideSize.Size.Width > Width) ? Presentation.SlideSize.Size.Width : Width);
		float num2 = ((Presentation.SlideSize.Size.Height > Height) ? Presentation.SlideSize.Size.Height : Height);
		float num3 = X;
		float num4 = Y;
		float num5 = Width;
		float num6 = Height;
		float x = X;
		float y = Y;
		float rotation = class154_0.Rotation;
		if (bounds == ShapeThumbnailBounds.Shape)
		{
			class154_0.Rotation = 0f;
			X = 0f;
			Y = 0f;
			num3 = 0f;
			num4 = 0f;
			if (lineFormat_0 != null && (lineFormat_0.Alignment == LineAlignment.Center || lineFormat_0.Alignment == LineAlignment.NotDefined) && lineFormat_0.FillFormat != null && lineFormat_0.FillFormat.FillType != 0 && !double.IsNaN(lineFormat_0.Width))
			{
				X += (float)lineFormat_0.Width / 2f;
				Y += (float)lineFormat_0.Width / 2f;
				num5 += (float)lineFormat_0.Width;
				num6 += (float)lineFormat_0.Width;
				num += (float)lineFormat_0.Width;
				num2 += (float)lineFormat_0.Width;
			}
		}
		Bitmap bitmap = new Bitmap((int)Math.Round(num * scaleX), (int)Math.Round(num2 * scaleY), PixelFormat.Format32bppArgb);
		try
		{
			bitmap.MakeTransparent(Color.White);
			bitmap.SetResolution(96f, 96f);
			using (Class160 canvas = new Class160(bitmap, (int)Math.Round(num), (int)Math.Round(num2)))
			{
				Dictionary<string, Class64> imageCache = new Dictionary<string, Class64>();
				Class170 renderingOptions = new Class170();
				Class169 rc = new Class169(Slide, imageCache, renderingOptions);
				vmethod_4(canvas, rc);
			}
			if (bounds == ShapeThumbnailBounds.Shape)
			{
				Bitmap bitmap2 = new Bitmap((int)(num5 * scaleX), (int)(num6 * scaleY), PixelFormat.Format32bppArgb);
				using (Graphics graphics = Graphics.FromImage(bitmap2))
				{
					RectangleF srcRect = new RectangleF(num3 * scaleY, num4 * scaleY, num5 * scaleX, num6 * scaleY);
					RectangleF destRect = new RectangleF(0f, 0f, bitmap2.Width, bitmap2.Height);
					graphics.DrawImage(bitmap, destRect, srcRect, GraphicsUnit.Pixel);
				}
				bitmap.Dispose();
				bitmap = bitmap2;
			}
			if (bounds == ShapeThumbnailBounds.Appearance)
			{
				Bitmap bitmap3 = Class1159.smethod_9(bitmap);
				bitmap.Dispose();
				bitmap = bitmap3;
			}
			if (Class1179.smethod_1() == Enum179.const_0)
			{
				Class151 @class = new Class151((Presentation)Presentation, 72f);
				@class.FontBold = true;
				@class.FontColor = Color.FromArgb(192, 255, 216, 207);
				@class.FontShadow = true;
				@class.FontName = "Arial";
				@class.FontHeight = 26;
				string s = string.Format("Evaluation only. Created with {0} {1}. Copyright 2004-{2} Aspose Pty Ltd.", "Aspose.Slides for .NET 4.0", "15.1.0.0", "2015.01.30".Substring(0, 4));
				using Graphics graphics2 = Graphics.FromImage(bitmap);
				Font font = new Font("Arial", 26f);
				graphics2.DrawString(s, font, new SolidBrush(Color.FromArgb(192, 255, 216, 207)), new RectangleF(0f, 0f, bitmap.Width, bitmap.Height));
			}
			return bitmap;
		}
		catch
		{
			bitmap.Dispose();
			throw;
		}
		finally
		{
			class154_0.Rotation = rotation;
			X = x;
			Y = y;
		}
	}

	internal Shape(IBaseSlide parent)
		: this(parent, new Class280(), new Class273())
	{
		ibaseShapeLock_0 = new BaseShapeLock();
	}

	internal Shape(IBaseSlide parent, Class280 pptxUnsupportedProps)
	{
		class280_0 = pptxUnsupportedProps;
		baseSlide_0 = (BaseSlide)parent;
		method_12();
		fillFormat_0 = new FillFormat(this);
		customData_0 = new CustomData();
		hyperlinkManager_0 = new HyperlinkManager(this);
	}

	internal Shape(IBaseSlide parent, Class280 pptxUnsupportedProps, Class273 pptUnsupportedProps)
		: this(parent, pptxUnsupportedProps)
	{
		class273_0 = pptUnsupportedProps;
	}

	internal virtual void vmethod_4(Class159 canvas, Class169 rc)
	{
	}

	internal static Class6002 smethod_0(IShapeFrame frame)
	{
		Class6002 @class = new Class6002((frame.FlipH != NullableBool.True) ? 1 : (-1), 0f, 0f, (frame.FlipV != NullableBool.True) ? 1 : (-1), (frame.FlipH == NullableBool.True) ? (frame.CenterX * 2f) : 0f, (frame.FlipV == NullableBool.True) ? (frame.CenterY * 2f) : 0f);
		if (!float.IsNaN(frame.Rotation))
		{
			@class.method_13(((frame.FlipH == NullableBool.True) ^ (frame.FlipV == NullableBool.True)) ? (0f - frame.Rotation) : frame.Rotation, new PointF(frame.CenterX, frame.CenterY), MatrixOrder.Prepend);
		}
		return @class;
	}

	internal static bool smethod_1(float x1, float y1, float x2, float y2, float x3, float y3)
	{
		return x1 * (y2 - y3) + x2 * (y3 - y1) + x3 * (y1 - y2) > 0f;
	}

	internal virtual void vmethod_5(Enum11 cmd)
	{
	}

	internal void method_9(string value)
	{
		if (int.TryParse(value, out int_0) && int_0 >= 0)
		{
			int_0 = (int)((Presentation)Presentation).method_2((uint)int_0);
		}
		else
		{
			int_0 = (int)((Presentation)Presentation).method_1();
		}
	}

	internal void method_10(uint id)
	{
		if (PPTXUnsupportedProps.ShapeId != 0)
		{
			throw new InvalidOperationException("ShapeId had been initialized already.");
		}
		method_11(id);
	}

	internal void method_11(uint id)
	{
		_ = PPTXUnsupportedProps.ShapeId;
		if (baseSlide_0.NextShapeId <= id)
		{
			baseSlide_0.method_11(id + 1, check: true);
		}
		PPTXUnsupportedProps.ShapeId = id;
	}

	internal uint method_12()
	{
		if (PPTXUnsupportedProps.ShapeId != 0)
		{
			throw new InvalidOperationException("ShapeId had been created already.");
		}
		uint num = baseSlide_0.method_10();
		method_10(num);
		return num;
	}

	internal virtual void vmethod_6()
	{
	}

	internal void method_13()
	{
		uint_0++;
	}

	internal virtual void vmethod_7()
	{
	}

	internal virtual void vmethod_8()
	{
		if (delegate1_0 != null)
		{
			delegate1_0(this);
		}
		shapeCollection_0 = null;
		RemovePlaceholder();
	}

	internal void ResetFrame()
	{
		class154_0.Reset();
		method_13();
	}
}
