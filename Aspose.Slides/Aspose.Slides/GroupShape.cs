using System;
using System.Collections.Generic;
using System.Drawing;
using ns11;
using ns224;
using ns24;
using ns33;
using ns4;
using ns7;

namespace Aspose.Slides;

public class GroupShape : Shape, IPresentationComponent, ISlideComponent, IHyperlinkContainer, IShape, IGroupShape
{
	internal readonly ShapeCollection shapeCollection_1;

	internal new Class292 PPTXUnsupportedProps => (Class292)base.PPTXUnsupportedProps;

	public override ILineFormat LineFormat => null;

	public new IGroupShapeLock ShapeLock => (IGroupShapeLock)base.ShapeLock;

	internal new Class155 RawFrameImpl
	{
		get
		{
			return (Class155)base.RawFrameImpl;
		}
		set
		{
			Class155 @class = (Class155)base.RawFrameImpl;
			@class.method_1(value.X, value.Y, value.Width, value.Height, value.Rotation, value.FlipH, value.FlipV);
			@class.method_5(value.ChildX, value.ChildY, value.ChildWidth, value.ChildHeight);
		}
	}

	public IShapeCollection Shapes => shapeCollection_1;

	public IShape AsIShape => this;

	internal override PointF[] ConnectionPointsInternal => Shape.pointF_0;

	internal GroupShape(IBaseSlide parent)
		: base(parent, new Class292())
	{
		shapeCollection_1 = new ShapeCollection(this);
		effectFormat_0 = new EffectFormat(this);
		threeDFormat_0 = new ThreeDFormat(this);
		base.Transform2DInternal = new Class155();
		base.ShapeLock = new GroupShapeLock();
	}

	internal RectangleF method_14()
	{
		if (Shapes.Count == 0)
		{
			return RectangleF.Empty;
		}
		RectangleF rectangleF = ((Shape)shapeCollection_1[0]).ShapeRectangleRotated;
		for (int i = 1; i < shapeCollection_1.Count; i++)
		{
			rectangleF = RectangleF.Union(rectangleF, ((Shape)shapeCollection_1[i]).ShapeRectangleRotated);
		}
		return rectangleF;
	}

	internal PointF method_15(PointF point, PointF lastRef)
	{
		method_16(out var sx, out var sy);
		Class154 rawFrameImpl = RawFrameImpl;
		double num = (((double)lastRef.X - RawFrameImpl.ReferrenceCenterX) * sx + (double)point.X - (double)lastRef.X) * (double)((rawFrameImpl.FlipH != NullableBool.True) ? 1 : (-1));
		double num2 = (((double)lastRef.Y - RawFrameImpl.ReferrenceCenterY) * sy + (double)point.Y - (double)lastRef.Y) * (double)((rawFrameImpl.FlipV != NullableBool.True) ? 1 : (-1));
		float num3 = rawFrameImpl.Rotation;
		if (float.IsNaN(num3))
		{
			num3 = 0f;
		}
		double num4 = (double)(num3 / 180f) * Math.PI;
		double num5 = Math.Cos(num4);
		double num6 = Math.Sin(num4);
		return new PointF((float)(num * num5 - num2 * num6 + RawFrameImpl.CenterX), (float)(num * num6 + num2 * num5 + RawFrameImpl.CenterY));
	}

	internal void method_16(out double sx, out double sy)
	{
		bool flag = base.SwapXY;
		sx = RawFrameImpl.ScaleX;
		sy = RawFrameImpl.ScaleY;
		for (GroupShape parentGroupInternal = base.ParentGroupInternal; parentGroupInternal != null; parentGroupInternal = parentGroupInternal.ParentGroupInternal)
		{
			if (flag)
			{
				sx *= parentGroupInternal.RawFrameImpl.ScaleY;
				sy *= parentGroupInternal.RawFrameImpl.ScaleX;
			}
			else
			{
				sx *= parentGroupInternal.RawFrameImpl.ScaleX;
				sy *= parentGroupInternal.RawFrameImpl.ScaleY;
			}
			flag ^= parentGroupInternal.SwapXY;
		}
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
		bool flag = base.Slide is Slide || base.Slide is NotesSlide;
		List<GroupShape> list = null;
		if (shapeCollection_1.Count > 0)
		{
			list = new List<GroupShape>();
			for (GroupShape groupShape = this; groupShape != null; groupShape = ((groupShape.shapeCollection_0 != null) ? (groupShape.shapeCollection_0.ParentGroup as GroupShape) : null))
			{
				list.Add(groupShape);
			}
			list.Reverse();
		}
		Interface2 drawingControl = rc.DrawingControl;
		for (int i = 0; i < shapeCollection_1.Count; i++)
		{
			Shape shape = (Shape)shapeCollection_1[i];
			if (!flag && shape.IsTextHolder)
			{
				continue;
			}
			Enum12 @enum = drawingControl.imethod_0(shape, list);
			bool flag2 = false;
			if (@enum == Enum12.const_1)
			{
				flag2 = true;
				rc.DrawingControl = Class165.class165_0;
			}
			if (@enum == Enum12.const_0 || (@enum == Enum12.const_2 && shape is GroupShape))
			{
				flag2 = true;
			}
			if (flag2)
			{
				rc.ShapeDrawingCallback.imethod_0(shape);
				try
				{
					shape.vmethod_4(canvas, rc);
				}
				catch (Exception ex)
				{
					Class1165.smethod_28(ex);
				}
				rc.ShapeDrawingCallback.imethod_1(shape);
			}
			rc.DrawingControl = drawingControl;
		}
		if (base.HyperlinkClick != null)
		{
			canvas.vmethod_17();
		}
	}

	internal override void vmethod_8()
	{
		foreach (Shape item in shapeCollection_1)
		{
			item.vmethod_8();
		}
		base.vmethod_8();
	}

	internal void method_17()
	{
		if (shapeCollection_0 != null && Shapes.Count > 0)
		{
			lock (this)
			{
				method_18(method_14());
			}
		}
	}

	private void method_18(RectangleF contRect)
	{
		Class155 rawFrameImpl = RawFrameImpl;
		if (shapeCollection_0 != null && Shapes.Count > 0)
		{
			double value = ((double)(contRect.X + contRect.Width / 2f) - rawFrameImpl.ReferrenceCenterX) * (double)((rawFrameImpl.FlipH != NullableBool.True) ? 1 : (-1));
			double value2 = ((double)(contRect.Y + contRect.Height / 2f) - rawFrameImpl.ReferrenceCenterY) * (double)((rawFrameImpl.FlipV != NullableBool.True) ? 1 : (-1));
			if (Math.Abs(value) + Math.Abs(value2) > 0.0001)
			{
				ShapeFrame frameRect = new ShapeFrame((double)contRect.X + (double)contRect.Width / 2.0, (double)contRect.Y + (double)contRect.Height / 2.0, 0.0, 0.0, NullableBool.False, NullableBool.False, 0f);
				ShapeFrame value3 = ((Shape)Shapes[0]).method_5(frameRect);
				Class154 @class = method_8(value3);
				double x = @class.X;
				double y = @class.Y;
				double num = rawFrameImpl.ScaleX * (double)contRect.Width;
				double num2 = rawFrameImpl.ScaleY * (double)contRect.Height;
				double x2 = x - num / 2.0;
				double y2 = y - num2 / 2.0;
				rawFrameImpl.vmethod_0(x2, y2, num, num2);
				rawFrameImpl.ChildRect = contRect;
			}
		}
	}

	internal Class63 method_19(Class6002 userToDevice, Class169 rc)
	{
		if (FillFormat.FillType == FillType.Group)
		{
			if (base.IsGrouped)
			{
				return base.ParentGroupInternal.method_19(userToDevice, rc);
			}
			return null;
		}
		return new Class63(new Class67(base.Frame, userToDevice, null, base.Slide, rc), FillFormat);
	}

	internal FillFormatEffectiveData method_20()
	{
		if (FillFormat.FillType == FillType.Group)
		{
			if (base.IsGrouped)
			{
				return base.ParentGroupInternal.method_20();
			}
		}
		else if (FillFormat.FillType != FillType.NotDefined)
		{
			return new FillFormatEffectiveData(FillFormat, base.SlideInternal, FloatColor.floatColor_1);
		}
		FillFormatEffectiveData fillFormatEffectiveData = new FillFormatEffectiveData();
		fillFormatEffectiveData.fillType_0 = FillType.NoFill;
		return fillFormatEffectiveData;
	}
}
