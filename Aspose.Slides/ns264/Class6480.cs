using System.Collections;
using System.Drawing;
using System.Drawing.Drawing2D;
using ns224;
using ns234;
using ns235;

namespace ns264;

internal class Class6480 : Class6479
{
	private PointF pointF_0 = PointF.Empty;

	private readonly Class6485 class6485_0;

	private Class6217 class6217_0;

	private bool bool_0;

	private Class6218 class6218_0;

	private readonly Class6213 class6213_0;

	private Class6213 class6213_1;

	private readonly Stack stack_0 = new Stack();

	internal Class6213 RootCanvas => class6213_0;

	public static Class6213 smethod_0(byte[] imageBytes, SizeF size, Class6483 context)
	{
		return smethod_1(new Class6496(imageBytes), size, context);
	}

	public static Class6213 smethod_1(Class6496 metafileInfo, SizeF size, Class6483 context)
	{
		Class6485 @class = Class6485.smethod_0(metafileInfo.MetafileType);
		Class6480 class2 = new Class6480(metafileInfo, @class, size);
		@class.method_1(metafileInfo, class2, context);
		return class2.RootCanvas;
	}

	private Class6480(Class6496 metafileInfo, Class6485 player, SizeF dstSize)
	{
		class6485_0 = player;
		class6213_0 = new Class6213();
		Class6213 node = new Class6213();
		class6213_0.Add(node);
		class6213_1 = node;
		RectangleF boundsPixels = metafileInfo.BoundsPixels;
		float m = dstSize.Width / boundsPixels.Width;
		float m2 = dstSize.Height / boundsPixels.Height;
		class6213_1.RenderTransform = new Class6002(m, 0f, 0f, m2, 0f, 0f);
		class6213_1.RenderTransform.method_7(0f - boundsPixels.X, 0f - boundsPixels.Y, MatrixOrder.Prepend);
	}

	internal override void vmethod_0()
	{
		SizeF sizePixels = class6485_0.MetafileInfo.SizePixels;
		class6485_0.method_6(sizePixels);
		class6485_0.DC.method_3(sizePixels);
	}

	internal override void vmethod_23(PointF origin, string text)
	{
		AddText(origin, text);
	}

	internal override void vmethod_9(PointF origin, string text)
	{
		AddText(origin, text);
	}

	private void AddText(PointF origin, string text)
	{
		bool flag;
		if ((flag = (class6485_0.DC.TextAlign & Enum845.flag_1) != 0) && origin == pointF_0)
		{
			origin = class6485_0.CurrentPosition;
		}
		pointF_0 = origin;
		Class6490 dC = class6485_0.DC;
		SizeF size = dC.method_0(text);
		Class6219 @class = new Class6219(dC.Font, dC.TextColor, Class5998.class5998_141, origin, text, size, dC.CharacterExtra);
		PointF[] array = new PointF[1] { origin };
		@class.RenderTransform = dC.method_7(array, size, @class.Font);
		@class.Origin = array[0];
		method_9(@class);
		class6213_1.Add(@class);
		if (flag)
		{
			class6485_0.CurrentPosition = new PointF(origin.X + size.Width, origin.Y);
		}
	}

	internal override void vmethod_21(PointF position, Class5998 color)
	{
		Class6217 @class = Class6217.smethod_3(position, position);
		@class.Pen = new Class6003(color);
		method_6(@class, isStroke: false, isFill: false);
	}

	internal override void vmethod_12(PointF endPoint)
	{
		if (bool_0)
		{
			method_10();
			PointF[] points = new PointF[2] { class6485_0.CurrentPosition, endPoint };
			class6218_0.method_1(points);
		}
		else
		{
			Class6217 path = Class6217.smethod_3(class6485_0.CurrentPosition, endPoint);
			method_6(path, isStroke: true, isFill: false);
		}
	}

	internal override void vmethod_19(RectangleF bounds)
	{
		Class6217 path = Class6217.smethod_1(bounds);
		method_6(path, isStroke: true, isFill: true);
	}

	internal void method_0(RectangleF bounds)
	{
		Class6217 path = Class6217.smethod_1(bounds);
		method_6(path, isStroke: true, isFill: false);
	}

	internal override void vmethod_10(RectangleF bounds)
	{
		Class6217 path = Class6217.smethod_1(bounds);
		method_6(path, isStroke: false, isFill: true);
	}

	internal override void vmethod_24(RectangleF bounds)
	{
		Class6217 path = Class6217.smethod_1(bounds);
		method_7(path, isStroke: false, isFill: true, isFillWithBackground: true);
	}

	internal override void vmethod_11(Class6499 region, Class6003 pen, Class5990 brush)
	{
		Class6217 @class = new Class6217();
		for (int i = 0; i < region.Scans.Count; i++)
		{
			@class.Add(Class6218.smethod_2(region.Scans[i]));
		}
		method_8(@class, pen, brush);
	}

	internal override void vmethod_16(PointF[] points)
	{
		if (points.Length > 0)
		{
			if (bool_0)
			{
				method_10();
				class6218_0.method_1(points);
			}
			else
			{
				Class6217 path = Class6484.smethod_0(points, closed: false);
				method_6(path, isStroke: true, isFill: false);
			}
		}
	}

	internal override void vmethod_14(PointF[] points)
	{
		if (points.Length > 0)
		{
			if (bool_0)
			{
				method_10();
				class6218_0.method_4(points);
			}
			else
			{
				Class6217 path = Class6484.smethod_2(points);
				method_6(path, isStroke: true, isFill: false);
			}
		}
	}

	internal override void vmethod_18(PointF[][] pointsPoints)
	{
		if (pointsPoints.Length < 0)
		{
			return;
		}
		if (bool_0)
		{
			foreach (PointF[] points in pointsPoints)
			{
				method_10();
				class6218_0.method_1(points);
				vmethod_35(closed: false);
			}
		}
		else
		{
			Class6217 path = Class6484.smethod_1(pointsPoints, closed: false);
			method_6(path, isStroke: true, isFill: false);
		}
	}

	internal override void vmethod_15(PointF[] points)
	{
		if (points.Length > 0)
		{
			if (bool_0)
			{
				method_10();
				class6218_0.method_1(points);
				vmethod_35(closed: true);
			}
			else
			{
				Class6217 path = Class6484.smethod_0(points, closed: true);
				method_6(path, isStroke: true, isFill: true);
			}
		}
	}

	internal void method_1(PointF[] points)
	{
		if (points.Length > 0)
		{
			Class6217 path = Class6484.smethod_0(points, closed: true);
			method_6(path, isStroke: false, isFill: true);
		}
	}

	internal void method_2(PointF[] points)
	{
		if (points.Length > 0)
		{
			Class6217 path = Class6484.smethod_0(points, closed: true);
			method_6(path, isStroke: true, isFill: false);
		}
	}

	internal override void vmethod_17(PointF[][] pointsPoints)
	{
		if (pointsPoints.Length <= 0)
		{
			return;
		}
		if (bool_0)
		{
			foreach (PointF[] points in pointsPoints)
			{
				method_10();
				class6218_0.method_1(points);
				vmethod_35(closed: true);
			}
		}
		else
		{
			Class6217 path = Class6484.smethod_1(pointsPoints, closed: true);
			method_6(path, isStroke: true, isFill: true);
		}
	}

	internal override void vmethod_6(RectangleF bounds, PointF start, PointF end)
	{
		Class6217 path = Class6484.smethod_3(bounds, start, end);
		method_6(path, isStroke: true, isFill: false);
	}

	internal override void vmethod_8(RectangleF bounds)
	{
		Class6217 path = Class6484.smethod_5(bounds);
		method_6(path, isStroke: true, isFill: true);
	}

	internal void method_3(RectangleF bounds)
	{
		Class6217 path = Class6484.smethod_5(bounds);
		method_6(path, isStroke: true, isFill: false);
	}

	internal void method_4(RectangleF bounds)
	{
		Class6217 path = Class6484.smethod_5(bounds);
		method_6(path, isStroke: false, isFill: true);
	}

	internal override void vmethod_13(RectangleF bounds, PointF start, PointF end)
	{
		Class6217 path = Class6484.smethod_6(bounds, start, end);
		method_6(path, isStroke: true, isFill: true);
	}

	internal void method_5(RectangleF bounds, float startAngle, float sweepAngle)
	{
		Class6217 path = Class6484.smethod_7(bounds, startAngle, sweepAngle);
		method_6(path, isStroke: true, isFill: false);
	}

	internal override void vmethod_7(RectangleF bounds, PointF start, PointF end)
	{
		Class6217 path = Class6484.smethod_8(bounds, start, end);
		method_6(path, isStroke: true, isFill: true);
	}

	internal override void vmethod_20(RectangleF bounds, SizeF ellipse)
	{
		Class6217 path = Class6484.smethod_9(bounds, ellipse);
		method_6(path, isStroke: true, isFill: true);
	}

	internal override void vmethod_22(RectangleF srcBounds, RectangleF dstBounds, byte[] imageBytes)
	{
		Class6213 @class = new Class6213();
		PointF origin = new PointF(dstBounds.Left, dstBounds.Top);
		SizeF size = new SizeF(dstBounds.Width, dstBounds.Height);
		Class6220 node = new Class6220(origin, size, imageBytes);
		@class.Add(node);
		@class.RenderTransform = class6485_0.DC.Transform.Clone();
		class6213_1.Add(@class);
	}

	internal override void vmethod_25(RectangleF srcBounds, RectangleF dstBounds, Class6002 matrix, Class5998 bkColor, Enum862 dwRop, byte[] imageBytes)
	{
		Class6213 @class = new Class6213();
		PointF origin = new PointF(dstBounds.Left, dstBounds.Top);
		SizeF size = new SizeF(dstBounds.Width, dstBounds.Height);
		Class6220 node = new Class6220(origin, size, imageBytes);
		@class.Add(node);
		@class.RenderTransform = class6485_0.DC.Transform.Clone();
		@class.RenderTransform.method_9(matrix, MatrixOrder.Prepend);
		class6213_1.Add(@class);
	}

	private void method_6(Class6217 path, bool isStroke, bool isFill)
	{
		method_7(path, isStroke, isFill, isFillWithBackground: false);
	}

	private void method_7(Class6217 path, bool isStroke, bool isFill, bool isFillWithBackground)
	{
		Class6490 dC = class6485_0.DC;
		Class6003 pen = (isStroke ? dC.Pen : null);
		Class5990 @class = (isFill ? dC.Brush : null);
		if (isFillWithBackground && @class != null)
		{
			@class = new Class5997(dC.BackgroundColor);
		}
		method_8(path, pen, @class);
	}

	private void method_8(Class6217 path, Class6003 pen, Class5990 brush)
	{
		if (pen != null || brush != null)
		{
			path.Pen = pen;
			path.Brush = brush;
			Class6490 dC = class6485_0.DC;
			path.FillMode = Class6485.smethod_1(dC.FillMode);
			path.RenderTransform = dC.Transform.Clone();
			class6213_1.Add(path);
		}
	}

	internal override void vmethod_34(Enum844 mode)
	{
		if (bool_0)
		{
			class6217_0.FillMode = Class6485.smethod_1(class6485_0.DC.FillMode);
		}
	}

	private void method_9(Class6219 glyphs)
	{
		RectangleF rect = new RectangleF(glyphs.Origin, glyphs.Size);
		Class6217 @class = Class6217.smethod_1(rect);
		@class.Brush = new Class5997(class6485_0.DC.BackgroundColor);
		@class.RenderTransform = glyphs.RenderTransform.Clone();
		@class.RenderTransform.method_7(0f, 0f - glyphs.Font.AscentPoints, MatrixOrder.Prepend);
		class6213_1.Add(@class);
	}

	private void method_10()
	{
		if (class6218_0 == null)
		{
			class6218_0 = new Class6218();
		}
	}

	internal override void vmethod_29()
	{
		vmethod_35(closed: true);
	}

	internal override void vmethod_27()
	{
		bool_0 = true;
		class6217_0 = new Class6217();
	}

	internal override void vmethod_28()
	{
		vmethod_35(closed: false);
		method_11();
		bool_0 = false;
	}

	internal override void vmethod_26()
	{
		method_11();
	}

	private void method_11()
	{
		if (bool_0 && class6217_0.RenderTransform == null)
		{
			class6217_0.RenderTransform = class6485_0.DC.Transform.Clone();
		}
	}

	public override void vmethod_35(bool closed)
	{
		if (class6218_0 != null)
		{
			class6218_0.IsClosed = closed;
			class6217_0.Add(class6218_0);
			class6218_0 = null;
		}
	}

	internal override void vmethod_30()
	{
		Class5990 brush = class6485_0.DC.Brush;
		if (class6217_0 != null && brush != null)
		{
			vmethod_35(closed: true);
			class6217_0.Brush = brush;
			method_12();
		}
	}

	internal override void vmethod_31()
	{
		Class6003 pen = class6485_0.DC.Pen;
		if (class6217_0 != null && pen != null)
		{
			vmethod_35(closed: false);
			class6217_0.Pen = pen;
			method_12();
		}
	}

	internal override void vmethod_32()
	{
		Class5990 brush = class6485_0.DC.Brush;
		Class6003 pen = class6485_0.DC.Pen;
		if (class6217_0 != null && (brush != null || pen != null))
		{
			vmethod_35(closed: false);
			class6217_0.Brush = brush;
			class6217_0.Pen = pen;
			method_12();
		}
	}

	private void method_12()
	{
		class6213_1.Add(class6217_0);
		class6217_0 = null;
	}

	internal override void vmethod_33(Enum864 mode)
	{
		if (class6217_0 != null)
		{
			vmethod_35(closed: true);
			method_13(class6217_0);
			class6217_0 = null;
		}
	}

	internal override void vmethod_1()
	{
		stack_0.Push(class6213_1);
		Class6213 node = new Class6213();
		class6213_1.Add(node);
		class6213_1 = node;
	}

	internal override void vmethod_2(RectangleF rect)
	{
		vmethod_5();
		class6485_0.DC.ClipRegion.Intersect(rect);
	}

	internal override void vmethod_3(RectangleF rect)
	{
		vmethod_5();
		class6485_0.DC.ClipRegion.Exclude(rect);
	}

	internal override void vmethod_5()
	{
		method_14();
		method_15();
	}

	internal override void vmethod_4()
	{
		method_14();
		class6213_1 = (Class6213)stack_0.Pop();
	}

	private void method_13(Class6217 clipPath)
	{
		if (clipPath.RenderTransform != null)
		{
			clipPath.method_3(clipPath.RenderTransform);
			clipPath.RenderTransform = null;
		}
		class6213_1.Clip = clipPath;
	}

	private void method_14()
	{
		Class6490 dC = class6485_0.DC;
		if (dC.HasClipRegion && (class6213_1.Clip == null || class6213_1.Clip.Count == 0))
		{
			Class6217 clipPath = Class6164.smethod_2(dC.ClipRegion);
			method_13(clipPath);
		}
	}

	private void method_15()
	{
		Class6213 @class = new Class6213();
		Class6212 class2 = (Class6212)class6213_1.Parent;
		@class.RenderTransform = class6213_1.RenderTransform;
		class2?.Add(@class);
		class6213_1 = @class;
	}
}
