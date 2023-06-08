using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Drawing2D;
using Aspose.Slides;
using Aspose.Slides.Charts;
using ns2;
using ns35;
using ns37;
using ns40;

namespace ns38;

internal class Class767 : IDisposable
{
	protected float float_0;

	protected float float_1;

	protected float float_2;

	protected float float_3;

	protected float float_4;

	protected float float_5;

	protected Class768[] class768_0;

	protected ArrayList arrayList_0 = new ArrayList();

	protected double[] double_0 = new double[0];

	protected Class747 class747_0;

	protected Color[] color_0 = new Color[12]
	{
		Color.Red,
		Color.Green,
		Color.Blue,
		Color.Yellow,
		Color.Purple,
		Color.Olive,
		Color.Navy,
		Color.Aqua,
		Color.Lime,
		Color.Maroon,
		Color.Teal,
		Color.Fuchsia
	};

	protected string[] string_0;

	protected Font font_0;

	protected Color color_1 = SystemColors.WindowText;

	protected float[] float_6 = new float[1];

	protected Enum138 enum138_0 = Enum138.const_1;

	protected float float_7 = 1f;

	protected Enum139 enum139_0;

	protected bool bool_0 = true;

	protected int int_0 = -1;

	private bool bool_1;

	internal Class768[] Slices => class768_0;

	public double[] Values
	{
		get
		{
			return double_0;
		}
		set
		{
			double_0 = value;
		}
	}

	public Class747 ChartPoints
	{
		get
		{
			return class747_0;
		}
		set
		{
			class747_0 = value;
		}
	}

	public Color[] Colors
	{
		set
		{
			color_0 = value;
		}
	}

	public string[] Texts
	{
		set
		{
			string_0 = value;
		}
	}

	public Font Font
	{
		get
		{
			return font_0;
		}
		set
		{
			font_0 = value;
		}
	}

	public Color ForeColor
	{
		get
		{
			return color_1;
		}
		set
		{
			color_1 = value;
		}
	}

	public Enum138 EdgeColorType
	{
		set
		{
			enum138_0 = value;
		}
	}

	public float EdgeLineWidth
	{
		set
		{
			float_7 = value;
		}
	}

	public float SliceRelativeHeight
	{
		set
		{
			float_4 = value;
		}
	}

	public float SliceRelativeDisplacement
	{
		set
		{
			float_6 = new float[1] { value };
		}
	}

	public float[] SliceRelativeDisplacements
	{
		set
		{
			float_6 = value;
		}
	}

	public SizeF ChartSize
	{
		set
		{
			float_2 = value.Width;
			float_3 = value.Height;
		}
	}

	public float Width
	{
		get
		{
			return float_2;
		}
		set
		{
			float_2 = value;
		}
	}

	public float Height
	{
		get
		{
			return float_3;
		}
		set
		{
			float_3 = value;
		}
	}

	public float Top => float_1;

	public float Bottom => float_1 + float_3;

	public float Left => float_0;

	public float Right => float_0 + float_2;

	public float X
	{
		get
		{
			return float_0;
		}
		set
		{
			float_0 = value;
		}
	}

	public float Y
	{
		get
		{
			return float_1;
		}
		set
		{
			float_1 = value;
		}
	}

	public Enum139 ShadowStyle
	{
		set
		{
			enum139_0 = value;
		}
	}

	public bool FitToBoundingRectangle
	{
		set
		{
			bool_0 = value;
		}
	}

	public float InitialAngle
	{
		set
		{
			float_5 = value % 360f;
			if (float_5 < 0f)
			{
				float_5 += 360f;
			}
		}
	}

	public int HighlightedIndex
	{
		set
		{
			int_0 = value;
		}
	}

	protected float LargestDisplacement
	{
		get
		{
			float num = 0f;
			for (int i = 0; i < float_6.Length && i < double_0.Length; i++)
			{
				if (float_6[i] > num)
				{
					num = float_6[i];
				}
			}
			return num;
		}
	}

	protected SizeF TopEllipseSize
	{
		get
		{
			float num = 1f + LargestDisplacement;
			float width = float_2 / num;
			float height = float_3 / num * (1f - float_4);
			return new SizeF(width, height);
		}
	}

	protected SizeF LargestDisplacementEllipseSize
	{
		get
		{
			float largestDisplacement = LargestDisplacement;
			float width = TopEllipseSize.Width * largestDisplacement;
			float height = TopEllipseSize.Height * largestDisplacement;
			return new SizeF(width, height);
		}
	}

	protected float PieHeight => float_3 / (1f + LargestDisplacement) * float_4;

	protected Class767()
	{
	}

	public Class767(float xBoundingRect, float yBoundingRect, float widthBoundingRect, float heightBoundingRect, double[] values)
		: this()
	{
		float_0 = xBoundingRect;
		float_1 = yBoundingRect;
		float_2 = widthBoundingRect;
		float_3 = heightBoundingRect;
		Values = values;
	}

	public Class767(float xBoundingRect, float yBoundingRect, float widthBoundingRect, float heightBoundingRect, double[] values, float sliceRelativeHeight)
		: this(xBoundingRect, yBoundingRect, widthBoundingRect, heightBoundingRect, values)
	{
		float_4 = sliceRelativeHeight;
	}

	public Class767(RectangleF boundingRectangle, double[] values, float sliceRelativeHeight)
		: this(boundingRectangle.X, boundingRectangle.Y, boundingRectangle.Width, boundingRectangle.Height, values, sliceRelativeHeight)
	{
	}

	public Class767(float xBoundingRect, float yBoundingRect, float widthBoundingRect, float heightBoundingRect, double[] values, Color[] sliceColors, float sliceRelativeHeight)
		: this(xBoundingRect, yBoundingRect, widthBoundingRect, heightBoundingRect, values, sliceRelativeHeight)
	{
		color_0 = sliceColors;
	}

	public Class767(RectangleF boundingRectangle, double[] values, Color[] sliceColors, float sliceRelativeHeight)
		: this(boundingRectangle, values, sliceRelativeHeight)
	{
		color_0 = sliceColors;
	}

	public Class767(float xBoundingRect, float yBoundingRect, float widthBoundingRect, float heightBoundingRect, double[] values, Color[] sliceColors, float sliceRelativeHeight, string[] texts)
		: this(xBoundingRect, yBoundingRect, widthBoundingRect, heightBoundingRect, values, sliceColors, sliceRelativeHeight)
	{
		string_0 = texts;
	}

	public Class767(float xBoundingRect, float yBoundingRect, float widthBoundingRect, float heightBoundingRect, double[] values, Color[] sliceColors, float sliceRelativeHeight, string[] texts, Class747 chartPoints)
		: this(xBoundingRect, yBoundingRect, widthBoundingRect, heightBoundingRect, values, sliceColors, sliceRelativeHeight, texts)
	{
		class747_0 = chartPoints;
	}

	public Class767(float xBoundingRect, float yBoundingRect, float widthBoundingRect, float heightBoundingRect, double[] values, float sliceRelativeHeight, string[] texts)
		: this(xBoundingRect, yBoundingRect, widthBoundingRect, heightBoundingRect, values, sliceRelativeHeight)
	{
		string_0 = texts;
	}

	~Class767()
	{
		Dispose(disposing: false);
	}

	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	protected virtual void Dispose(bool disposing)
	{
		if (bool_1)
		{
			return;
		}
		if (disposing)
		{
			Class768[] array = class768_0;
			foreach (Class768 @class in array)
			{
				@class.Dispose();
			}
		}
		bool_1 = true;
	}

	internal void method_0(Class759 aSeries)
	{
		Class747 pointsInternal = aSeries.PointsInternal;
		int rotation = aSeries.Chart.Rotation;
		InitialAngle = rotation - 90;
		float[] array = new float[pointsInternal.Count];
		for (int i = 0; i < pointsInternal.Count; i++)
		{
			array[i] = (float)pointsInternal[i].Explosion / 100f;
		}
		SliceRelativeDisplacements = array;
		Class750 dataLabelsInternal = aSeries.DataLabelsInternal;
		Font = dataLabelsInternal.ChartFrameInternal.TextFont;
		ForeColor = dataLabelsInternal.ChartFrameInternal.FontColor;
		vmethod_1();
		if (bool_0)
		{
			RectangleF newBoundingRectangle = method_14();
			method_15(newBoundingRectangle);
		}
	}

	public void method_1(Interface32 graphics)
	{
		method_18(graphics);
		if (float_4 > 0f)
		{
			method_17(graphics);
		}
		method_19(graphics);
	}

	public virtual void vmethod_0(Interface32 graphics, Class784 renderContext)
	{
		StringFormat stringFormat = new StringFormat();
		stringFormat.Alignment = StringAlignment.Center;
		stringFormat.LineAlignment = StringAlignment.Center;
		Class740 chart = class747_0.Chart;
		double num = 0.0;
		double[] array = double_0;
		foreach (double num2 in array)
		{
			num += num2;
		}
		using (new SolidBrush(color_1))
		{
			Class768[] array2 = class768_0;
			foreach (Class768 @class in array2)
			{
				if (@class == null || @class.Text.Length < 1)
				{
					continue;
				}
				Class748 chartPoint = @class.ChartPoint;
				Class759 aSeries = chartPoint.ChartPoints.ASeries;
				Class750 dataLabelsInternal = chartPoint.DataLabelsInternal;
				if (!dataLabelsInternal.IsShown)
				{
					continue;
				}
				double percent = ((num != 0.0) ? (Math.Abs(chartPoint.YValue) / num) : 0.01);
				float scaleWidth = ((!dataLabelsInternal.ChartFrameInternal.BorderInternal.IsVisible) ? ((float)chart.Width * 0.2f) : ((float)chart.Width * 0.175f));
				float scaleHeight = chart.Height;
				SizeF sizeF = Struct37.smethod_42(graphics, chart.NSeriesInternal, aSeries.Index, chartPoint.Index, percent, scaleWidth, scaleHeight, 0.0, renderContext);
				RectangleF empty = RectangleF.Empty;
				PointF point = PointF.Empty;
				bool flag = false;
				LegendDataLabelPosition legendDataLabelPosition = dataLabelsInternal.LabelPosition;
				float dlAngle;
				while (!flag)
				{
					switch (legendDataLabelPosition)
					{
					case LegendDataLabelPosition.BestFit:
					{
						point = @class.vmethod_1(0.5f, out dlAngle);
						method_3(@class, ref point, dlAngle, sizeF);
						RectangleF rect = new RectangleF(Struct41.smethod_3(point.X), Struct41.smethod_3(point.Y), Struct41.smethod_3(sizeF.Width), Struct41.smethod_3(sizeF.Height));
						chart.method_2(ref rect);
						dataLabelsInternal.ChartFrameInternal.rectangle_1 = Struct41.smethod_28(Rectangle.Round(rect));
						dataLabelsInternal.ChartFrameInternal.method_6();
						point = new PointF(dataLabelsInternal.ChartFrameInternal.rectangle_0.X, dataLabelsInternal.ChartFrameInternal.rectangle_0.Y);
						flag = true;
						continue;
					}
					case LegendDataLabelPosition.Center:
						point = @class.vmethod_1(0.25f, out dlAngle);
						point.X -= sizeF.Width / 2f;
						point.Y -= sizeF.Height / 2f;
						flag = true;
						continue;
					case LegendDataLabelPosition.InsideEnd:
					{
						float param_r = 0.485f;
						point = @class.vmethod_1(param_r, out dlAngle);
						method_4(@class, ref point, dlAngle, sizeF);
						flag = true;
						continue;
					}
					case LegendDataLabelPosition.OutsideEnd:
						point = @class.vmethod_1(0.5f, out dlAngle);
						method_3(@class, ref point, dlAngle, sizeF);
						flag = true;
						continue;
					}
					float param_r2 = 0.47f;
					point = @class.vmethod_1(param_r2, out dlAngle);
					method_4(@class, ref point, dlAngle, sizeF);
					if (method_8(graphics, @class, new RectangleF(point, sizeF)))
					{
						flag = true;
						continue;
					}
					PointF pointF = method_9(graphics, @class, sizeF, dlAngle);
					if (pointF.IsEmpty)
					{
						flag = false;
						legendDataLabelPosition = LegendDataLabelPosition.OutsideEnd;
					}
					else
					{
						point = pointF;
						flag = true;
					}
				}
				empty = new RectangleF(point, sizeF);
				chart.method_2(ref empty);
				Struct37.smethod_43(graphics, chart, aSeries.Index, chartPoint.Index, percent, empty, 0.0, renderContext);
				if (chartPoint.ChartPoints.ASeries.HasLeaderLines && (!dataLabelsInternal.ChartFrameInternal.IsXAuto || !dataLabelsInternal.ChartFrameInternal.IsYAuto))
				{
					PointF start = @class.vmethod_1(0.5f, out dlAngle);
					if (dlAngle >= 5f && dlAngle <= 175f)
					{
						start.Y += @class.SliceHeight;
					}
					method_5(graphics, @class, chartPoint.ChartPoints.ASeries.LeaderLinesInternal, empty, start);
				}
			}
		}
	}

	private PointF method_2(Class768 slice, SizeF dataLabelsSize)
	{
		float dlAngle;
		PointF point = slice.vmethod_1(0.5f, out dlAngle);
		method_3(slice, ref point, dlAngle, dataLabelsSize);
		return point;
	}

	private void method_3(Class768 slice, ref PointF point, float dlAngle, SizeF dataLabelsSize)
	{
		if ((double)dlAngle > 67.5 && (double)dlAngle < 112.5)
		{
			point.X = (float)((double)point.X - ((double)dlAngle - 67.5) * (double)dataLabelsSize.Width / 45.0);
		}
		else if ((double)dlAngle >= 112.5 && (double)dlAngle <= 247.5)
		{
			point.X -= dataLabelsSize.Width;
		}
		else if ((double)dlAngle > 247.5 && dlAngle < 270f)
		{
			double num = slice.SweepAngle;
			point.X = (float)((double)(point.X - dataLabelsSize.Width) + (double)dataLabelsSize.Width / num);
		}
		else if (dlAngle >= 270f && (double)dlAngle < 292.5)
		{
			point.X = (float)((double)(point.X - dataLabelsSize.Width) + ((double)dlAngle - 247.5) * (double)dataLabelsSize.Width / 45.0);
		}
		if (dlAngle >= 0f && dlAngle <= 90f)
		{
			point.Y += slice.SliceHeight * (dlAngle / 90f);
		}
		else if (dlAngle > 90f && dlAngle < 180f)
		{
			point.Y += slice.SliceHeight * ((dlAngle - 180f) * -1f / 90f);
		}
		else if (dlAngle < 225f && dlAngle > 180f)
		{
			point.Y -= (dlAngle - 135f) * dataLabelsSize.Height / 90f;
		}
		else if (dlAngle >= 225f && dlAngle <= 315f)
		{
			point.Y -= dataLabelsSize.Height;
		}
		else if (dlAngle > 315f && dlAngle <= 360f)
		{
			point.Y = point.Y - dataLabelsSize.Height + (dlAngle - 315f) * dataLabelsSize.Height / 90f;
		}
	}

	private void method_4(Class768 slice, ref PointF point, float dlAngle, SizeF dataLabelsSize)
	{
		if ((double)dlAngle > 67.5 && (double)dlAngle < 112.5)
		{
			point.X = (float)((double)point.X - (112.5 - (double)dlAngle) * (double)dataLabelsSize.Width / 45.0);
		}
		else if ((double)dlAngle > 247.5 && (double)dlAngle < 292.5)
		{
			point.X = (float)((double)point.X - ((double)dlAngle - 247.5) * (double)dataLabelsSize.Width / 45.0);
		}
		else if ((double)dlAngle <= 67.5 || (double)dlAngle >= 292.5)
		{
			point.X -= dataLabelsSize.Width;
		}
		if ((double)dlAngle < 22.5)
		{
			point.Y = point.Y - dataLabelsSize.Height / 2f - dlAngle * dataLabelsSize.Height / 45f;
		}
		else if ((double)dlAngle > 337.5)
		{
			point.Y = point.Y - dataLabelsSize.Height / 2f + (360f - dlAngle) * dataLabelsSize.Height / 45f;
		}
		else if ((double)dlAngle > 157.5 && (double)dlAngle < 202.5)
		{
			point.Y = (float)((double)point.Y - (202.5 - (double)dlAngle) * (double)dataLabelsSize.Height / 45.0);
		}
		else if ((double)dlAngle <= 157.5 && (double)dlAngle >= 22.5)
		{
			point.Y -= dataLabelsSize.Height;
		}
	}

	private void method_5(Interface32 g, Class768 slice, Class755 leaderLine, RectangleF rectDl, PointF start)
	{
		GraphicsPath path = method_7();
		float num = slice.BoundingRectangle.Width / 2f * 0.05f;
		RectangleF rectangleF = Class790.smethod_0(path);
		PointF pointF = new PointF(rectangleF.X + rectangleF.Width / 2f, rectangleF.Y + rectangleF.Height / 2f);
		PointF pointF2 = start;
		if (start.X < pointF.X)
		{
			pointF2.X -= 1f;
		}
		else
		{
			pointF2.X += 1f;
		}
		if (start.Y < pointF.Y)
		{
			pointF2.Y -= 1f;
		}
		else
		{
			pointF2.Y += 1f;
		}
		PointF pt = new PointF(rectDl.Left, rectDl.Top + rectDl.Height / 3f);
		PointF pt2 = new PointF(rectDl.Left + rectDl.Width / 3f, rectDl.Top);
		PointF pt3 = new PointF(rectDl.Right, rectDl.Top + rectDl.Height / 3f);
		PointF pt4 = new PointF(rectDl.Left + rectDl.Width / 3f, rectDl.Bottom);
		int num2 = method_6(start, rectDl);
		GraphicsPath graphicsPath = new GraphicsPath();
		Region region = null;
		PointF empty = PointF.Empty;
		switch (num2)
		{
		case 1:
		{
			empty = new PointF(pt3.X + num, pt3.Y);
			graphicsPath.AddLine(pt3, empty);
			graphicsPath.AddLine(empty, pointF2);
			Pen pen = leaderLine.method_9(graphicsPath);
			graphicsPath.Widen(pen);
			region = new Region(graphicsPath);
			region.Intersect(path);
			if (g.GraphicsTools.imethod_1(region) && empty.X <= start.X)
			{
				GraphicsPath graphicsPath7 = new GraphicsPath();
				graphicsPath7.AddLine(pt3, empty);
				graphicsPath7.AddLine(empty, start);
				pen = leaderLine.method_9(graphicsPath);
				g.imethod_45(pen, graphicsPath7);
			}
			break;
		}
		case 2:
		{
			empty = new PointF(pt3.X + num, pt3.Y);
			graphicsPath.AddLine(pt3, empty);
			graphicsPath.AddLine(empty, pointF2);
			Pen pen = leaderLine.method_9(graphicsPath);
			graphicsPath.Widen(pen);
			region = new Region(graphicsPath);
			region.Intersect(path);
			if (g.GraphicsTools.imethod_1(region) && empty.X <= start.X)
			{
				GraphicsPath graphicsPath8 = new GraphicsPath();
				graphicsPath8.AddLine(pt3, empty);
				graphicsPath8.AddLine(empty, start);
				pen = leaderLine.method_9(graphicsPath);
				g.imethod_45(pen, graphicsPath8);
				break;
			}
			graphicsPath = new GraphicsPath();
			empty = new PointF(pt4.X, pt4.Y + num);
			graphicsPath.AddLine(pt4, empty);
			graphicsPath.AddLine(empty, pointF2);
			pen = leaderLine.method_9(graphicsPath);
			graphicsPath.Widen(pen);
			region = new Region(graphicsPath);
			region.Intersect(path);
			if (g.GraphicsTools.imethod_1(region) && empty.Y <= start.Y)
			{
				GraphicsPath graphicsPath9 = new GraphicsPath();
				graphicsPath9.AddLine(pt4, empty);
				graphicsPath9.AddLine(empty, start);
				pen = leaderLine.method_9(graphicsPath);
				g.imethod_45(pen, graphicsPath9);
			}
			break;
		}
		case 3:
		{
			graphicsPath = new GraphicsPath();
			graphicsPath.AddLine(pointF2, new PointF(pointF2.X, pt4.Y));
			Pen pen = leaderLine.method_9(graphicsPath);
			graphicsPath.Widen(pen);
			region = new Region(graphicsPath);
			region.Intersect(path);
			if (g.GraphicsTools.imethod_1(region) && empty.Y <= start.Y)
			{
				GraphicsPath graphicsPath6 = new GraphicsPath();
				graphicsPath6.AddLine(pointF2, new PointF(pointF2.X, pt4.Y));
				pen = leaderLine.method_9(graphicsPath);
				g.imethod_45(pen, graphicsPath6);
			}
			break;
		}
		case 4:
		{
			graphicsPath = new GraphicsPath();
			empty = new PointF(pt.X - num, pt.Y);
			graphicsPath.AddLine(pt, empty);
			graphicsPath.AddLine(empty, pointF2);
			Pen pen = leaderLine.method_9(graphicsPath);
			graphicsPath.Widen(pen);
			region = new Region(graphicsPath);
			region.Intersect(path);
			if (g.GraphicsTools.imethod_1(region) && empty.X >= start.X)
			{
				GraphicsPath graphicsPath12 = new GraphicsPath();
				graphicsPath12.AddLine(pt, empty);
				graphicsPath12.AddLine(empty, start);
				pen = leaderLine.method_9(graphicsPath);
				g.imethod_45(pen, graphicsPath12);
				break;
			}
			graphicsPath = new GraphicsPath();
			empty = new PointF(pt4.X, pt4.Y + num);
			graphicsPath.AddLine(pt4, empty);
			graphicsPath.AddLine(empty, pointF2);
			pen = leaderLine.method_9(graphicsPath);
			graphicsPath.Widen(pen);
			region = new Region(graphicsPath);
			region.Intersect(path);
			if (g.GraphicsTools.imethod_1(region) && empty.Y <= start.Y)
			{
				GraphicsPath graphicsPath13 = new GraphicsPath();
				graphicsPath13.AddLine(pt4, empty);
				graphicsPath13.AddLine(empty, start);
				pen = leaderLine.method_9(graphicsPath);
				g.imethod_45(pen, graphicsPath13);
			}
			break;
		}
		case 5:
		{
			graphicsPath = new GraphicsPath();
			empty = new PointF(pt.X - num, pt.Y);
			graphicsPath.AddLine(pt, empty);
			graphicsPath.AddLine(empty, pointF2);
			Pen pen = leaderLine.method_9(graphicsPath);
			graphicsPath.Widen(pen);
			region = new Region(graphicsPath);
			region.Intersect(path);
			if (g.GraphicsTools.imethod_1(region) && empty.X >= start.X)
			{
				GraphicsPath graphicsPath10 = new GraphicsPath();
				graphicsPath10.AddLine(pt, empty);
				graphicsPath10.AddLine(empty, start);
				pen = leaderLine.method_9(graphicsPath);
				g.imethod_45(pen, graphicsPath10);
			}
			break;
		}
		case 6:
		{
			graphicsPath = new GraphicsPath();
			empty = new PointF(pt.X - num, pt.Y);
			graphicsPath.AddLine(pt, empty);
			graphicsPath.AddLine(empty, pointF2);
			Pen pen = leaderLine.method_9(graphicsPath);
			graphicsPath.Widen(pen);
			region = new Region(graphicsPath);
			region.Intersect(path);
			if (g.GraphicsTools.imethod_1(region) && empty.X >= start.X)
			{
				GraphicsPath graphicsPath4 = new GraphicsPath();
				graphicsPath4.AddLine(pt, empty);
				graphicsPath4.AddLine(empty, start);
				pen = leaderLine.method_9(graphicsPath);
				g.imethod_45(pen, graphicsPath4);
				break;
			}
			graphicsPath = new GraphicsPath();
			empty = new PointF(pt2.X, pt2.Y - num);
			graphicsPath.AddLine(pt2, empty);
			graphicsPath.AddLine(empty, pointF2);
			pen = leaderLine.method_9(graphicsPath);
			graphicsPath.Widen(pen);
			region = new Region(graphicsPath);
			region.Intersect(path);
			if (g.GraphicsTools.imethod_1(region) && empty.Y >= start.Y)
			{
				GraphicsPath graphicsPath5 = new GraphicsPath();
				graphicsPath5.AddLine(pt2, empty);
				graphicsPath5.AddLine(empty, start);
				pen = leaderLine.method_9(graphicsPath);
				g.imethod_45(pen, graphicsPath5);
			}
			break;
		}
		case 7:
		{
			graphicsPath = new GraphicsPath();
			empty = new PointF(pt2.X, pt2.Y - num);
			graphicsPath.AddLine(pointF2, new PointF(pointF2.X, pt2.Y));
			Pen pen = leaderLine.method_9(graphicsPath);
			graphicsPath.Widen(pen);
			region = new Region(graphicsPath);
			region.Intersect(path);
			if (g.GraphicsTools.imethod_1(region) && empty.Y >= start.Y)
			{
				GraphicsPath graphicsPath11 = new GraphicsPath();
				graphicsPath11.AddLine(pointF2, new PointF(pointF2.X, pt2.Y));
				pen = leaderLine.method_9(graphicsPath);
				g.imethod_45(pen, graphicsPath11);
			}
			break;
		}
		case 8:
		{
			graphicsPath = new GraphicsPath();
			empty = new PointF(pt3.X + num, pt3.Y);
			graphicsPath.AddLine(pt3, empty);
			graphicsPath.AddLine(empty, pointF2);
			Pen pen = leaderLine.method_9(graphicsPath);
			graphicsPath.Widen(pen);
			region = new Region(graphicsPath);
			region.Intersect(path);
			if (g.GraphicsTools.imethod_1(region) && empty.X <= start.X)
			{
				GraphicsPath graphicsPath2 = new GraphicsPath();
				graphicsPath2.AddLine(pt3, empty);
				graphicsPath2.AddLine(empty, start);
				pen = leaderLine.method_9(graphicsPath);
				g.imethod_45(pen, graphicsPath2);
				break;
			}
			graphicsPath = new GraphicsPath();
			empty = new PointF(pt2.X, pt2.Y - num);
			graphicsPath.AddLine(pt2, empty);
			graphicsPath.AddLine(empty, pointF2);
			pen = leaderLine.method_9(graphicsPath);
			graphicsPath.Widen(pen);
			region = new Region(graphicsPath);
			region.Intersect(path);
			if (g.GraphicsTools.imethod_1(region) && empty.Y >= start.Y)
			{
				GraphicsPath graphicsPath3 = new GraphicsPath();
				graphicsPath3.AddLine(pt2, empty);
				graphicsPath3.AddLine(empty, start);
				pen = leaderLine.method_9(graphicsPath);
				g.imethod_45(pen, graphicsPath3);
			}
			break;
		}
		}
	}

	private int method_6(PointF start, RectangleF rectDl)
	{
		int num = 0;
		if (rectDl.Right < start.X)
		{
			if (rectDl.Bottom < start.Y)
			{
				return 2;
			}
			if (rectDl.Top > start.Y)
			{
				return 8;
			}
			return 1;
		}
		if (rectDl.Left > start.X)
		{
			if (rectDl.Bottom < start.Y)
			{
				return 4;
			}
			if (rectDl.Top > start.Y)
			{
				return 6;
			}
			return 5;
		}
		if (rectDl.Bottom < start.Y)
		{
			return 3;
		}
		if (rectDl.Top > start.Y)
		{
			return 7;
		}
		return 0;
	}

	private GraphicsPath method_7()
	{
		GraphicsPath graphicsPath = new GraphicsPath();
		Class768[] array = class768_0;
		foreach (Class768 @class in array)
		{
			graphicsPath.AddPie(@class.BoundingRectangle.X, @class.BoundingRectangle.Y, @class.BoundingRectangle.Width, @class.BoundingRectangle.Height, @class.StartAngle, @class.SweepAngle);
			graphicsPath.AddPie(@class.BoundingRectangle.X, @class.BoundingRectangle.Y + @class.SliceHeight, @class.BoundingRectangle.Width, @class.BoundingRectangle.Height, @class.StartAngle, @class.SweepAngle);
		}
		return graphicsPath;
	}

	private bool method_8(Interface32 g, Class768 slice, RectangleF rectDl)
	{
		rectDl = new RectangleF(rectDl.X, rectDl.Y, rectDl.Width, rectDl.Height);
		GraphicsPath graphicsPath = new GraphicsPath();
		graphicsPath.AddRectangle(new RectangleF(float_0, float_1, float_2, float_3));
		GraphicsPath graphicsPath2 = new GraphicsPath();
		graphicsPath2.AddPie(slice.BoundingRectangle.X, slice.BoundingRectangle.Y, slice.BoundingRectangle.Width, slice.BoundingRectangle.Height, slice.StartAngle, slice.SweepAngle);
		Region region = new Region(graphicsPath);
		region.Xor(graphicsPath2);
		if (slice.ChartPoint.DataLabelsInternal.ChartFrameInternal.BorderInternal.Formatting == FillType.NoFill || slice.ChartPoint.DataLabelsInternal.ChartFrameInternal.BorderInternal.Color.IsEmpty)
		{
			rectDl.Inflate(-Struct28.int_0, -Struct28.int_0);
		}
		region.Intersect(rectDl);
		if (g.GraphicsTools.imethod_1(region))
		{
			return true;
		}
		return false;
	}

	private PointF method_9(Interface32 g, Class768 slice, SizeF dataLabelsSize, float dlAngle)
	{
		float num = 0f;
		float num2 = 0f;
		float num3 = 0.5f;
		bool flag = false;
		if (!(dlAngle < 90f) && (!(dlAngle >= 180f) || dlAngle >= 270f))
		{
			Class768 @class = method_10(slice, 0f);
			flag = false;
			while (@class.AcctualStartAngle > slice.AcctualStartAngle - slice.AcctualSweepAngle / 2f)
			{
				@class = method_10(@class, 0f - num3);
				RectangleF rectDl = method_11(@class, dataLabelsSize);
				num -= num3;
				if (method_8(g, slice, rectDl))
				{
					num2 -= num3;
					if (!flag)
					{
						flag = true;
					}
				}
				else if (flag)
				{
					@class = method_10(slice, 0f);
					@class = method_10(@class, num - num2 / 2f);
					return method_11(@class, dataLabelsSize).Location;
				}
			}
			@class = method_10(slice, 0f);
			flag = false;
			while (@class.AcctualStartAngle < slice.AcctualStartAngle + slice.AcctualSweepAngle / 2f)
			{
				@class = method_10(@class, num3);
				RectangleF rectDl2 = method_11(@class, dataLabelsSize);
				num += num3;
				if (method_8(g, slice, rectDl2))
				{
					num2 += num3;
					if (!flag)
					{
						flag = true;
					}
				}
				else if (flag)
				{
					@class = method_10(slice, 0f);
					@class = method_10(@class, num - num2 / 2f);
					return method_11(@class, dataLabelsSize).Location;
				}
			}
		}
		else
		{
			Class768 class2 = method_10(slice, 0f);
			flag = false;
			while (class2.AcctualStartAngle < slice.AcctualStartAngle + slice.AcctualSweepAngle / 2f)
			{
				class2 = method_10(class2, num3);
				RectangleF rectDl3 = method_11(class2, dataLabelsSize);
				num += num3;
				if (method_8(g, slice, rectDl3))
				{
					num2 += num3;
					if (!flag)
					{
						flag = true;
					}
				}
				else if (flag)
				{
					class2 = method_10(slice, 0f);
					class2 = method_10(class2, num - num2 / 2f);
					return method_11(class2, dataLabelsSize).Location;
				}
			}
			class2 = method_10(slice, 0f);
			flag = false;
			while (class2.AcctualStartAngle > slice.AcctualStartAngle - slice.AcctualSweepAngle / 2f)
			{
				class2 = method_10(class2, 0f - num3);
				RectangleF rectDl4 = method_11(class2, dataLabelsSize);
				num -= num3;
				if (method_8(g, slice, rectDl4))
				{
					num2 -= num3;
					if (!flag)
					{
						flag = true;
					}
				}
				else if (flag)
				{
					class2 = method_10(slice, 0f);
					class2 = method_10(class2, num - num2 / 2f);
					return method_11(class2, dataLabelsSize).Location;
				}
			}
		}
		return PointF.Empty;
	}

	private Class768 method_10(Class768 slice, float angle)
	{
		return slice.method_0(angle);
	}

	private RectangleF method_11(Class768 slice, SizeF dataLabelsSize)
	{
		float param_r = 0.485f;
		float dlAngle;
		PointF location = slice.vmethod_1(param_r, out dlAngle);
		if (dlAngle <= 90f || dlAngle >= 270f)
		{
			location.X -= dataLabelsSize.Width;
		}
		if (dlAngle >= 0f && dlAngle <= 180f)
		{
			location.Y -= dataLabelsSize.Height;
		}
		return new RectangleF(location, dataLabelsSize);
	}

	public int method_12(PointF point)
	{
		int num = 0;
		while (true)
		{
			if (num < class768_0.Length)
			{
				Class768 @class = class768_0[num];
				if (@class.method_14(point))
				{
					break;
				}
				num++;
				continue;
			}
			ArrayList arrayList = new ArrayList();
			arrayList.AddRange(class768_0);
			Class768[] array = class768_0[0].method_4(270f);
			if (array.Length > 1)
			{
				arrayList[0] = array[1];
				if (array[0].SweepAngle > 0f)
				{
					arrayList.Add(array[0]);
				}
			}
			Class768[] array2 = (Class768[])arrayList.ToArray(typeof(Class768));
			int num2 = -1;
			int num3 = 0;
			int num4 = array2.Length - 1;
			while (num3 <= num4)
			{
				Class768 class2 = array2[num4];
				float num5 = 270f - class2.StartAngle;
				Class768 class3 = array2[num3];
				float num6 = (class3.EndAngle + 90f) % 360f;
				if (num6 < num5)
				{
					if (class3.method_15(point))
					{
						num2 = num3;
					}
					num3++;
				}
				else
				{
					if (class2.method_15(point))
					{
						num2 = num4;
					}
					num4--;
				}
			}
			if (num2 < 0)
			{
				int num7 = method_13(array2);
				for (int i = num7; i < array2.Length; i++)
				{
					Class768 class4 = array2[i];
					if (class4.method_16(point))
					{
						num2 = i;
						break;
					}
				}
				if (num2 < 0)
				{
					int i = num7;
					while (i >= 0)
					{
						Class768 class5 = array2[i];
						if (!class5.method_17(point))
						{
							i--;
							continue;
						}
						num2 = i;
						break;
					}
				}
			}
			if (num2 < 0)
			{
				for (int j = 0; j < class768_0.Length; j++)
				{
					Class768 class6 = class768_0[j];
					if (class6.method_18(point))
					{
						return (int)arrayList_0[j];
					}
				}
			}
			if (num2 > -1)
			{
				num2 %= arrayList_0.Count;
				return (int)arrayList_0[num2];
			}
			return -1;
		}
		return (int)arrayList_0[num];
	}

	private int method_13(Class768[] pieSlices)
	{
		int num = 0;
		while (true)
		{
			if (num < pieSlices.Length)
			{
				Class768 @class = pieSlices[num];
				if ((@class.StartAngle <= 90f && @class.StartAngle + @class.SweepAngle >= 90f) || (@class.StartAngle + @class.SweepAngle > 360f && @class.StartAngle <= 450f && !(@class.StartAngle + @class.SweepAngle < 450f)))
				{
					break;
				}
				num++;
				continue;
			}
			return -1;
		}
		return num;
	}

	protected RectangleF method_14()
	{
		RectangleF rectangleF = class768_0[0].method_13();
		for (int i = 1; i < class768_0.Length; i++)
		{
			rectangleF = RectangleF.Union(rectangleF, class768_0[i].method_13());
		}
		return rectangleF;
	}

	protected void method_15(RectangleF newBoundingRectangle)
	{
		float num = float_2 / newBoundingRectangle.Width;
		float num2 = float_3 / newBoundingRectangle.Height;
		float num3 = newBoundingRectangle.X - float_0;
		float num4 = newBoundingRectangle.Y - float_1;
		Class768[] array = class768_0;
		foreach (Class768 @class in array)
		{
			float xBoundingRect = @class.BoundingRectangle.X - num3;
			float yBoundingRect = @class.BoundingRectangle.Y - num4;
			float widthBoundingRect = @class.BoundingRectangle.Width * num;
			float heightBoundingRect = @class.BoundingRectangle.Height * num2;
			float sliceHeight = @class.SliceHeight * num2;
			@class.method_6(xBoundingRect, yBoundingRect, widthBoundingRect, heightBoundingRect, sliceHeight);
		}
	}

	protected virtual void vmethod_1()
	{
		double num = 0.0;
		double[] array = double_0;
		foreach (double num2 in array)
		{
			num += num2;
		}
		SizeF topEllipseSize = TopEllipseSize;
		SizeF largestDisplacementEllipseSize = LargestDisplacementEllipseSize;
		int num3 = float_6.Length - 1;
		_ = LargestDisplacement;
		ArrayList arrayList = new ArrayList();
		arrayList_0.Clear();
		int num4 = 0;
		int num5 = -1;
		int num6 = 0;
		double num7 = float_5;
		for (int j = 0; j < double_0.Length; j++)
		{
			double num8 = double_0[j];
			double num9 = num8 / num * 360.0;
			float num10 = float_6[num6];
			float num11 = float_6[num6];
			if (num10 > 0f)
			{
				SizeF sizeF = method_16((float)(num7 + num9 / 2.0), float_6[num6]);
				num10 = sizeF.Width;
				num11 = sizeF.Height;
			}
			Class768 @class = null;
			if (j == int_0)
			{
				@class = vmethod_3(float_0 + largestDisplacementEllipseSize.Width / 2f + num10, float_1 + largestDisplacementEllipseSize.Height / 2f + num11, topEllipseSize.Width, topEllipseSize.Height, PieHeight, (float)(num7 % 360.0), (float)num9, color_0[num4], enum139_0, enum138_0, float_7);
			}
			else
			{
				Class748 chartPoint = ((class747_0 == null || j >= class747_0.Count) ? null : class747_0.method_0(j));
				@class = vmethod_2(float_0 + largestDisplacementEllipseSize.Width / 2f + num10, float_1 + largestDisplacementEllipseSize.Height / 2f + num11, topEllipseSize.Width, topEllipseSize.Height, PieHeight, (float)(num7 % 360.0), (float)num9, color_0[num4], enum139_0, enum138_0, float_7, chartPoint);
			}
			@class.Text = string_0[j];
			if (num5 <= -1 && (!(num7 <= 270.0) || !(num7 + num9 > 270.0)) && (!(num7 >= 270.0) || num7 + num9 <= 630.0))
			{
				arrayList.Add(@class);
				arrayList_0.Add(j);
			}
			else
			{
				num5++;
				arrayList.Insert(num5, @class);
				arrayList_0.Insert(num5, j);
			}
			if (num6 < num3)
			{
				num6++;
			}
			num4++;
			if (num4 >= color_0.Length)
			{
				num4 = 0;
			}
			num7 += num9;
			if (num7 > 360.0)
			{
				num7 -= 360.0;
			}
		}
		class768_0 = (Class768[])arrayList.ToArray(typeof(Class768));
	}

	protected virtual Class768 vmethod_2(float boundingRectLeft, float boundingRectTop, float boundingRectWidth, float boundingRectHeight, float sliceHeight, float startAngle, float sweepAngle, Color color, Enum139 shadowStyle, Enum138 edgeColorType, float edgeLineWidth, Class748 chartPoint)
	{
		return new Class768(boundingRectLeft, boundingRectTop, boundingRectWidth, boundingRectHeight, sliceHeight, startAngle % 360f, sweepAngle, color, shadowStyle, edgeColorType, edgeLineWidth, chartPoint);
	}

	protected virtual Class768 vmethod_3(float boundingRectLeft, float boundingRectTop, float boundingRectWidth, float boundingRectHeight, float sliceHeight, float startAngle, float sweepAngle, Color color, Enum139 shadowStyle, Enum138 edgeColorType, float edgeLineWidth)
	{
		Color surfaceColor = Struct32.smethod_0(color, Struct32.float_0);
		return new Class768(boundingRectLeft, boundingRectTop, boundingRectWidth, boundingRectHeight, sliceHeight, startAngle % 360f, sweepAngle, surfaceColor, shadowStyle, edgeColorType, edgeLineWidth);
	}

	protected SizeF method_16(float angle, float displacementFactor)
	{
		if (displacementFactor == 0f)
		{
			return SizeF.Empty;
		}
		float width = (float)((double)(TopEllipseSize.Width * displacementFactor / 2f) * Math.Cos((double)angle * Math.PI / 180.0));
		float height = (float)((double)(TopEllipseSize.Height * displacementFactor / 2f) * Math.Sin((double)angle * Math.PI / 180.0));
		return new SizeF(width, height);
	}

	protected void method_17(Interface32 graphics)
	{
		ArrayList arrayList = new ArrayList();
		arrayList.AddRange(class768_0);
		Class768 @class = null;
		if (class768_0[0].StartAngle > 90f && class768_0[0].StartAngle <= 270f && class768_0[0].StartAngle + class768_0[0].SweepAngle > 450f)
		{
			@class = (Class768)arrayList[0];
			Class768[] array = @class.method_4(0f);
			arrayList[0] = array[0];
			if (array[1].SweepAngle > 0f)
			{
				arrayList.Insert(1, array[1]);
			}
		}
		else if ((class768_0[0].StartAngle > 270f && class768_0[0].StartAngle + class768_0[0].SweepAngle > 450f) || (class768_0[0].StartAngle < 90f && class768_0[0].StartAngle + class768_0[0].SweepAngle > 270f))
		{
			@class = (Class768)arrayList[0];
			Class768[] array2 = @class.method_4(180f);
			arrayList[0] = array2[1];
			if (array2[1].SweepAngle > 0f)
			{
				arrayList.Add(array2[0]);
			}
		}
		@class = (Class768)arrayList[0];
		@class.method_3(graphics);
		int num = 1;
		int num2 = arrayList.Count - 1;
		while (num < num2)
		{
			Class768 class2 = (Class768)arrayList[num2];
			float num3 = class2.StartAngle - 90f;
			if (num3 > 180f || num3 < 0f)
			{
				num3 = 0f;
			}
			Class768 class3 = (Class768)arrayList[num];
			float num4 = (450f - class3.EndAngle) % 360f;
			if (num4 > 180f || num4 < 0f)
			{
				num4 = 0f;
			}
			if (num4 >= num3)
			{
				class3.method_3(graphics);
				num++;
			}
			else if (num4 < num3)
			{
				class2.method_3(graphics);
				num2--;
			}
		}
		@class = (Class768)arrayList[num2];
		@class.method_3(graphics);
	}

	protected void method_18(Interface32 graphics)
	{
		Class768[] array = class768_0;
		foreach (Class768 @class in array)
		{
			@class.method_11(graphics);
		}
	}

	protected void method_19(Interface32 graphics)
	{
		Class768[] array = class768_0;
		foreach (Class768 @class in array)
		{
			@class.method_12(graphics);
		}
	}

	private bool method_20(float[] displacements)
	{
		int num = 0;
		while (true)
		{
			if (num < displacements.Length)
			{
				float value = displacements[num];
				if (!method_21(value))
				{
					break;
				}
				num++;
				continue;
			}
			return true;
		}
		return false;
	}

	private bool method_21(float value)
	{
		if (value >= 0f)
		{
			return value <= 1f;
		}
		return false;
	}
}
