using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using Aspose.Slides.Charts;
using ns221;
using ns35;
using ns36;
using ns38;

namespace ns37;

internal class Class740 : Interface4, Interface5
{
	private Chart chart_0;

	private Interface32 interface32_0;

	private ChartType chartType_0;

	private Class757 class757_0;

	private Class746 class746_0;

	private Class746 class746_1;

	private bool bool_0;

	private bool bool_1;

	private bool bool_2;

	private int int_0;

	private int int_1;

	private int int_2;

	private int int_3;

	private int int_4;

	private int int_5;

	private Class764 class764_0;

	private Class764 class764_1;

	private Class764 class764_2;

	private Class753 class753_0;

	private bool bool_3;

	private bool bool_4;

	private bool bool_5;

	private bool bool_6;

	private string string_0;

	private Class744 class744_0;

	private bool bool_7;

	private int int_6;

	private Class761 class761_0;

	private int int_7;

	private int int_8;

	private Font font_0;

	private int int_9;

	private int int_10;

	private int int_11;

	private RectangleF rectangleF_0;

	private float float_0;

	internal bool bool_8;

	internal double double_0;

	internal double double_1;

	internal int int_12;

	internal int int_13;

	internal int int_14;

	internal int int_15;

	internal bool bool_9;

	public Chart SourceChart
	{
		get
		{
			return chart_0;
		}
		set
		{
			chart_0 = value;
		}
	}

	[Attribute7(true)]
	public int Width
	{
		get
		{
			if (class746_0.Width == 0)
			{
				return 1;
			}
			return class746_0.Width;
		}
		set
		{
			if (value < 1)
			{
				throw new Exception("The width of chart can not be less than 1");
			}
			class746_0.Width = value;
		}
	}

	[Attribute7(true)]
	public int Height
	{
		get
		{
			if (class746_0.Height == 0)
			{
				return 1;
			}
			return class746_0.Height;
		}
		set
		{
			if (value < 1)
			{
				throw new Exception("The height of chart can not be less than 1");
			}
			class746_0.Height = value;
		}
	}

	public int X
	{
		get
		{
			return int_7;
		}
		set
		{
			int_7 = value;
		}
	}

	public int Y
	{
		get
		{
			return int_8;
		}
		set
		{
			int_8 = value;
		}
	}

	internal Class746 ChartAreaInternal => class746_0;

	public Interface10 ChartArea => class746_0;

	public int DepthPercent
	{
		get
		{
			return int_0;
		}
		set
		{
			if (value >= 20 && value <= 2000)
			{
				int_0 = value;
			}
		}
	}

	public int GapDepth
	{
		get
		{
			return int_1;
		}
		set
		{
			if (value >= 0 && value <= 500)
			{
				int_1 = value;
			}
		}
	}

	public int GapWidth
	{
		get
		{
			return int_2;
		}
		set
		{
			if (value < 0 || value > 500)
			{
				return;
			}
			int_2 = value;
			foreach (Class759 item in class757_0)
			{
				item.GapWidth = value;
			}
		}
	}

	public int Elevation
	{
		get
		{
			return int_3;
		}
		set
		{
			int_3 = value;
		}
	}

	public int HeightPercent
	{
		get
		{
			return int_5;
		}
		set
		{
			int_5 = value;
		}
	}

	public bool AutoScaling
	{
		get
		{
			return bool_5;
		}
		set
		{
			bool_5 = value;
		}
	}

	public bool RightAngleAxes
	{
		get
		{
			return bool_4;
		}
		set
		{
			bool_4 = value;
		}
	}

	internal Class753 FloorInternal => class753_0;

	public Interface16 Floor => class753_0;

	public bool IsLegendShown
	{
		get
		{
			return bool_1;
		}
		set
		{
			bool_1 = value;
		}
	}

	internal Class746 PlotAreaInternal => class746_1;

	public Interface10 PlotArea => class746_1;

	public bool IsRectangularCornered
	{
		get
		{
			return bool_2;
		}
		set
		{
			bool_2 = value;
		}
	}

	internal Class757 NSeriesInternal => class757_0;

	public Interface20 NSeries => class757_0;

	public bool IsInnerMode
	{
		get
		{
			return bool_6;
		}
		set
		{
			bool_6 = value;
		}
	}

	public int Rotation
	{
		get
		{
			return int_4;
		}
		set
		{
			int_4 = value;
		}
	}

	public ChartType Type
	{
		get
		{
			return chartType_0;
		}
		set
		{
			chartType_0 = value;
		}
	}

	internal Class764 WallsInternal => class764_0;

	public Interface24 Walls => class764_0;

	internal Class764 SideWallsInternal => class764_1;

	public Interface24 SideWalls => class764_1;

	internal Class764 BackWallsInternal => class764_2;

	public Interface24 BackWalls => class764_2;

	public bool IsDate1904
	{
		get
		{
			return bool_3;
		}
		set
		{
			bool_3 = value;
		}
	}

	public string ProductName
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

	public bool IsDrawEvaluation
	{
		get
		{
			return bool_7;
		}
		set
		{
			bool_7 = value;
		}
	}

	public Interface9 SubCharts => class744_0;

	public int StyleIndex
	{
		get
		{
			return int_6;
		}
		set
		{
			int_6 = value;
		}
	}

	internal Class761 Themes => class761_0;

	internal Font Font
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

	internal int RadiusFirst
	{
		get
		{
			return int_9;
		}
		set
		{
			int_9 = value;
		}
	}

	internal int RadiusSecond
	{
		get
		{
			return int_10;
		}
		set
		{
			int_10 = value;
		}
	}

	internal int GapWidthBetween2Plots
	{
		get
		{
			return int_11;
		}
		set
		{
			int_11 = value;
		}
	}

	internal RectangleF OriginalPlotRect
	{
		get
		{
			return rectangleF_0;
		}
		set
		{
			rectangleF_0 = value;
		}
	}

	internal float SliceRelativeHeight
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

	internal Rectangle BoundingBox
	{
		get
		{
			_ = Width;
			return new Rectangle((int)((double)((float)int_12 * 4000f / (float)Width) + 0.5), (int)((double)((float)int_13 * 4000f / (float)Height) + 0.5), (int)((double)((float)int_14 * 4000f / (float)Width) + 0.5), (int)((double)((float)int_15 * 4000f / (float)Height) + 0.5));
		}
	}

	public Size ActualChartSize
	{
		get
		{
			ChartAreaInternal.BorderInternal.method_2();
			int width = ChartAreaInternal.BorderInternal.Width;
			if (width <= 1)
			{
				return new Size(Width, Height);
			}
			return new Size(Width + width, Height + width);
		}
	}

	internal Rectangle Position
	{
		get
		{
			ChartAreaInternal.BorderInternal.method_2();
			int width = ChartAreaInternal.BorderInternal.Width;
			int num = width / 2;
			int y = num;
			return new Rectangle(num, y, Width, Height);
		}
	}

	public Interface32 Graphics
	{
		get
		{
			return interface32_0;
		}
		set
		{
			interface32_0 = value;
		}
	}

	public Class740(Font font)
	{
		method_0(font);
	}

	public Class740()
	{
		method_0(null);
	}

	private void method_0(Font font)
	{
		if (font == null)
		{
			font_0 = new Font("Arial", 10f);
		}
		else
		{
			font_0 = font;
		}
		int_6 = 2;
		class761_0 = new Class761();
		class746_0 = new Class746(this, this, Enum140.const_0, Enum145.const_0);
		class746_0.Width = 480;
		class746_0.Height = 288;
		bool_0 = false;
		bool_1 = true;
		bool_2 = true;
		class757_0 = new Class757(this);
		class746_1 = new Class746(this, this, Enum140.const_1, Enum145.const_1);
		chartType_0 = ChartType.ClusteredColumn;
		int_0 = 100;
		int_1 = 150;
		int_2 = 150;
		int_5 = 100;
		int_3 = 15;
		int_4 = 20;
		class764_0 = new Class764(this);
		class764_1 = new Class764(this);
		class764_2 = new Class764(this);
		class753_0 = new Class753(this);
		bool_3 = false;
		bool_4 = true;
		bool_5 = true;
		bool_6 = false;
		string_0 = "Aspose.Cells for .NET";
		class744_0 = new Class744();
		bool_7 = true;
	}

	public void imethod_1(Color[] colors)
	{
		class761_0.ThemeColors.method_2(colors);
	}

	internal bool Is3DChart()
	{
		switch (Type)
		{
		default:
			return false;
		case ChartType.ClusteredColumn3D:
		case ChartType.StackedColumn3D:
		case ChartType.PercentsStackedColumn3D:
		case ChartType.Column3D:
		case ChartType.ClusteredCylinder:
		case ChartType.StackedCylinder:
		case ChartType.PercentsStackedCylinder:
		case ChartType.Cylinder3D:
		case ChartType.ClusteredCone:
		case ChartType.StackedCone:
		case ChartType.PercentsStackedCone:
		case ChartType.Cone3D:
		case ChartType.ClusteredPyramid:
		case ChartType.StackedPyramid:
		case ChartType.PercentsStackedPyramid:
		case ChartType.Pyramid3D:
		case ChartType.Line3D:
		case ChartType.Pie3D:
		case ChartType.ExplodedPie3D:
		case ChartType.ClusteredBar3D:
		case ChartType.StackedBar3D:
		case ChartType.PercentsStackedBar3D:
		case ChartType.ClusteredHorizontalCylinder:
		case ChartType.StackedHorizontalCylinder:
		case ChartType.PercentsStackedHorizontalCylinder:
		case ChartType.ClusteredHorizontalCone:
		case ChartType.StackedHorizontalCone:
		case ChartType.PercentsStackedHorizontalCone:
		case ChartType.ClusteredHorizontalPyramid:
		case ChartType.StackedHorizontalPyramid:
		case ChartType.PercentsStackedHorizontalPyramid:
		case ChartType.Area3D:
		case ChartType.StackedArea3D:
		case ChartType.PercentsStackedArea3D:
		case ChartType.Surface3D:
		case ChartType.WireframeSurface3D:
		case ChartType.Contour:
		case ChartType.WireframeContour:
			return true;
		}
	}

	internal void method_1(int x, int y, int width, int height)
	{
		int_12 = x;
		int_13 = y;
		int_14 = width;
		int_15 = height;
	}

	internal void method_2(ref RectangleF rect)
	{
		if (rect.X < 0f)
		{
			rect.X = 0f;
		}
		if (rect.Y < 0f)
		{
			rect.Y = 0f;
		}
		if (rect.Right > (float)Width)
		{
			rect.X = (float)Width - rect.Width;
		}
		if (rect.Bottom > (float)Height)
		{
			rect.Y = (float)Height - rect.Height;
		}
	}

	public void imethod_0()
	{
		if (Is3DChart())
		{
			Struct25.smethod_1(this);
		}
		else
		{
			Struct24.smethod_1(this);
		}
		method_3();
	}

	private void method_3()
	{
		for (int i = 0; i < SubCharts.Count; i++)
		{
			Class740 @class = class744_0.method_0(i);
			using MemoryStream memoryStream = new MemoryStream();
			int graphcisType = Class792.int_0;
			Interface32 @interface = Class792.smethod_1(graphcisType, @class.ActualChartSize.Width, @class.ActualChartSize.Height, ImageFormat.Emf, null, memoryStream, @class);
			@interface.imethod_0();
			if (memoryStream.Length != 0L)
			{
				memoryStream.Seek(0L, SeekOrigin.Begin);
				using Image image = Image.FromStream(memoryStream);
				Graphics.imethod_33(image, @class.X, @class.Y, @class.Width, @class.Height);
			}
		}
	}
}
