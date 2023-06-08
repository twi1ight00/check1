using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.IO;
using System.Runtime.CompilerServices;
using Aspose.Cells.Render;
using ns14;
using ns19;
using ns3;
using ns34;
using ns6;

namespace ns33;

internal class Class821 : IDisposable, Interface6, Interface7
{
	private Interface42 interface42_0;

	private Class823 class823_0;

	private Class823 class823_1;

	private Class823 class823_2;

	private Class823 class823_3;

	private Class848 class848_0;

	private ChartType_Chart chartType_Chart_0;

	private Class842 class842_0;

	private Class829 class829_0;

	private Class829 class829_1;

	private Class828 class828_0;

	private bool bool_0;

	private bool bool_1;

	private bool bool_2;

	private Class838 class838_0;

	private Class823 class823_4;

	private int int_0;

	private int int_1;

	private int int_2;

	private int int_3;

	private int int_4;

	private int int_5;

	private Class851 class851_0;

	private Class851 class851_1;

	private Class851 class851_2;

	private Class835 class835_0;

	private bool bool_3;

	private bool bool_4;

	private bool bool_5;

	private bool bool_6;

	private string string_0;

	private Class826 class826_0;

	private bool bool_7;

	private int int_6;

	private Class846 class846_0;

	private int int_7;

	private int int_8;

	private Class516 class516_0;

	private Class911 class911_0;

	private int int_9;

	private int int_10;

	private int int_11;

	private RectangleF rectangleF_0;

	private float float_0;

	internal bool bool_8;

	internal Class823 class823_5;

	internal double double_0;

	internal double double_1;

	internal int int_12;

	internal int int_13;

	internal int int_14;

	internal int int_15;

	internal bool bool_9;

	private bool bool_10;

	private bool bool_11;

	public int Width
	{
		get
		{
			if (class829_0.Width == 0)
			{
				return 1;
			}
			return class829_0.Width;
		}
	}

	public int Height
	{
		get
		{
			if (class829_0.Height == 0)
			{
				return 1;
			}
			return class829_0.Height;
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

	public Interface9 CategoryAxis => class823_0;

	public Interface9 ValueAxis => class823_2;

	public Interface9 SeriesAxis => class823_4;

	public Interface30 Title => class848_0;

	public ChartType_Chart Type
	{
		get
		{
			return chartType_Chart_0;
		}
		set
		{
			chartType_Chart_0 = value;
		}
	}

	public Interface33 Walls => class851_0;

	public Interface14 ChartArea => class829_0;

	public Interface13 ChartDataTable => class828_0;

	public Interface23 Legend => class838_0;

	public Interface27 NSeries => class842_0;

	public Interface14 PlotArea => class829_1;

	public Interface20 Floor => class835_0;

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
			foreach (Class844 item in class842_0)
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
		set
		{
			bool_4 = value;
		}
	}

	public bool IsDataTableShown
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

	internal Class911 Shapes => class911_0;

	internal Font Font => class829_0.Font;

	internal Color FontColor => class829_0.FontColor;

	internal Rectangle Position
	{
		get
		{
			method_3().method_2().method_6();
			int width = method_3().method_2().Width;
			int num = width / 2;
			int y = num;
			return new Rectangle(num, y, Width, Height);
		}
	}

	public Class821(Font font_0, Color color_0)
	{
		method_0(font_0, color_0);
	}

	public Class821()
	{
		method_0(null, Color.Empty);
	}

	private void method_0(Font font_0, Color color_0)
	{
		int_6 = 2;
		class846_0 = new Class846();
		class829_0 = new Class829(this, this, Enum52.const_0, Enum57.const_0);
		class829_0.Width = 480;
		class829_0.Height = 288;
		_ = class829_0.FontColor;
		class829_0.method_3(font_0);
		if (!color_0.IsEmpty)
		{
			class829_0.FontColor = color_0;
		}
		class823_0 = new Class823(this, Enum61.const_0);
		class823_1 = new Class823(this, Enum61.const_2);
		class823_1.IsVisible = false;
		class823_2 = new Class823(this, Enum61.const_1);
		class823_3 = new Class823(this, Enum61.const_3);
		class823_3.IsVisible = false;
		class823_4 = new Class823(this, Enum61.const_4);
		class823_4.IsVisible = false;
		class828_0 = new Class828(this);
		bool_0 = false;
		bool_1 = true;
		bool_2 = true;
		class838_0 = new Class838(this, this, Enum52.const_10);
		class842_0 = new Class842(this);
		class829_1 = new Class829(this, this, Enum52.const_1, Enum57.const_1);
		class848_0 = new Class848(this, this, Enum52.const_8, Enum57.const_10);
		chartType_Chart_0 = ChartType_Chart.Column;
		int_0 = 100;
		int_1 = 150;
		int_2 = 150;
		int_5 = 100;
		int_3 = 15;
		int_4 = 20;
		class851_0 = new Class851(this);
		class851_1 = new Class851(this);
		class851_2 = new Class851(this);
		class835_0 = new Class835(this);
		class911_0 = new Class911(this);
		bool_3 = false;
		bool_4 = true;
		bool_5 = true;
		bool_6 = false;
		string_0 = "Aspose.Cells for .NET";
		class826_0 = new Class826();
		bool_7 = true;
		class516_0 = new Class516();
	}

	[SpecialName]
	internal Class823 method_1()
	{
		return class823_0;
	}

	[SpecialName]
	internal Class823 method_2()
	{
		return class823_1;
	}

	[SpecialName]
	public Interface9 imethod_3()
	{
		return class823_1;
	}

	[SpecialName]
	internal Class829 method_3()
	{
		return class829_0;
	}

	[SpecialName]
	internal Class828 method_4()
	{
		return class828_0;
	}

	[SpecialName]
	internal Class835 method_5()
	{
		return class835_0;
	}

	[SpecialName]
	internal Class838 method_6()
	{
		return class838_0;
	}

	[SpecialName]
	internal Class842 method_7()
	{
		return class842_0;
	}

	[SpecialName]
	internal Class829 method_8()
	{
		return class829_1;
	}

	[SpecialName]
	internal Class823 method_9()
	{
		return class823_2;
	}

	[SpecialName]
	internal Class823 method_10()
	{
		return class823_3;
	}

	[SpecialName]
	public Interface9 imethod_4()
	{
		return class823_3;
	}

	[SpecialName]
	internal Class823 method_11()
	{
		return class823_4;
	}

	[SpecialName]
	internal Class848 method_12()
	{
		return class848_0;
	}

	[SpecialName]
	internal Class851 method_13()
	{
		return class851_0;
	}

	[SpecialName]
	internal Class851 method_14()
	{
		return class851_1;
	}

	[SpecialName]
	public Interface33 imethod_5()
	{
		return class851_1;
	}

	[SpecialName]
	internal Class851 method_15()
	{
		return class851_2;
	}

	[SpecialName]
	public Interface33 imethod_6()
	{
		return class851_2;
	}

	[SpecialName]
	public bool vmethod_0()
	{
		return bool_3;
	}

	[SpecialName]
	public void imethod_11(bool bool_12)
	{
		bool_3 = bool_12;
	}

	[SpecialName]
	public void imethod_12(string string_1)
	{
		string_0 = string_1;
	}

	[SpecialName]
	public bool vmethod_1()
	{
		return bool_7;
	}

	[SpecialName]
	public void imethod_9(bool bool_12)
	{
		bool_7 = bool_12;
	}

	[SpecialName]
	public Interface12 imethod_10()
	{
		return class826_0;
	}

	[SpecialName]
	public int imethod_7()
	{
		return int_6;
	}

	[SpecialName]
	public void imethod_8(int int_16)
	{
		int_6 = int_16;
	}

	[SpecialName]
	internal Class846 method_16()
	{
		return class846_0;
	}

	public void ChangePalette(Color[] color_0)
	{
		class846_0.method_0().ChangePalette(color_0);
	}

	internal bool method_17()
	{
		switch (Type)
		{
		default:
			return false;
		case ChartType_Chart.Area3D:
		case ChartType_Chart.Area3DStacked:
		case ChartType_Chart.Area3D100PercentStacked:
		case ChartType_Chart.Bar3DClustered:
		case ChartType_Chart.Bar3DStacked:
		case ChartType_Chart.Bar3D100PercentStacked:
		case ChartType_Chart.Column3D:
		case ChartType_Chart.Column3DClustered:
		case ChartType_Chart.Column3DStacked:
		case ChartType_Chart.Column3D100PercentStacked:
		case ChartType_Chart.Cone:
		case ChartType_Chart.ConeStacked:
		case ChartType_Chart.Cone100PercentStacked:
		case ChartType_Chart.ConicalBar:
		case ChartType_Chart.ConicalBarStacked:
		case ChartType_Chart.ConicalBar100PercentStacked:
		case ChartType_Chart.ConicalColumn3D:
		case ChartType_Chart.Cylinder:
		case ChartType_Chart.CylinderStacked:
		case ChartType_Chart.Cylinder100PercentStacked:
		case ChartType_Chart.CylindricalBar:
		case ChartType_Chart.CylindricalBarStacked:
		case ChartType_Chart.CylindricalBar100PercentStacked:
		case ChartType_Chart.CylindricalColumn3D:
		case ChartType_Chart.Line3D:
		case ChartType_Chart.Pie3D:
		case ChartType_Chart.Pie3DExploded:
		case ChartType_Chart.Pyramid:
		case ChartType_Chart.PyramidStacked:
		case ChartType_Chart.Pyramid100PercentStacked:
		case ChartType_Chart.PyramidBar:
		case ChartType_Chart.PyramidBarStacked:
		case ChartType_Chart.PyramidBar100PercentStacked:
		case ChartType_Chart.PyramidColumn3D:
		case ChartType_Chart.Surface3D:
		case ChartType_Chart.SurfaceWireframe3D:
		case ChartType_Chart.SurfaceContour:
		case ChartType_Chart.SurfaceContourWireframe:
			return true;
		}
	}

	[SpecialName]
	internal int method_18()
	{
		return int_9;
	}

	[SpecialName]
	internal void method_19(int int_16)
	{
		int_9 = int_16;
	}

	[SpecialName]
	internal int method_20()
	{
		return int_10;
	}

	[SpecialName]
	internal void method_21(int int_16)
	{
		int_10 = int_16;
	}

	[SpecialName]
	internal int method_22()
	{
		return int_11;
	}

	[SpecialName]
	internal void method_23(int int_16)
	{
		int_11 = int_16;
	}

	[SpecialName]
	internal void method_24(RectangleF rectangleF_1)
	{
		rectangleF_0 = rectangleF_1;
	}

	[SpecialName]
	internal float method_25()
	{
		return float_0;
	}

	[SpecialName]
	internal void method_26(float float_1)
	{
		float_0 = float_1;
	}

	[SpecialName]
	internal Rectangle method_27()
	{
		_ = Width;
		return new Rectangle((int)((double)((float)int_12 * 4000f / (float)Width) + 0.5), (int)((double)((float)int_13 * 4000f / (float)Height) + 0.5), (int)((double)((float)int_14 * 4000f / (float)Width) + 0.5), (int)((double)((float)int_15 * 4000f / (float)Height) + 0.5));
	}

	internal void method_28(int int_16, int int_17, int int_18, int int_19)
	{
		int_12 = int_16;
		int_13 = int_17;
		int_14 = int_18;
		int_15 = int_19;
	}

	[SpecialName]
	public Size imethod_13()
	{
		method_3().method_2().method_6();
		int width = method_3().method_2().Width;
		if (width <= 1)
		{
			return new Size(Width, Height);
		}
		return new Size(Width + width, Height + width);
	}

	internal void method_29(ref RectangleF rectangleF_1)
	{
		if (rectangleF_1.X < 0f)
		{
			rectangleF_1.X = 0f;
		}
		if (rectangleF_1.Y < 0f)
		{
			rectangleF_1.Y = 0f;
		}
		if (rectangleF_1.Right > (float)Width)
		{
			rectangleF_1.X = (float)Width - rectangleF_1.Width;
		}
		if (rectangleF_1.Bottom > (float)Height)
		{
			rectangleF_1.Y = (float)Height - rectangleF_1.Height;
		}
	}

	[SpecialName]
	public Class516 vmethod_2()
	{
		return class516_0;
	}

	[SpecialName]
	public void imethod_14(Class516 class516_1)
	{
		class516_0 = class516_1;
	}

	public void Calculate()
	{
		method_3().method_2().method_6();
		method_3().method_1().method_5();
		bool_10 = true;
		if (method_17())
		{
			Struct48.smethod_0(this);
		}
		else
		{
			Struct47.smethod_0(this);
		}
		bool_10 = false;
	}

	[SpecialName]
	internal bool method_30()
	{
		return bool_10;
	}

	[SpecialName]
	public Interface42 imethod_0()
	{
		return interface42_0;
	}

	[SpecialName]
	public void imethod_1(Interface42 interface42_1)
	{
		interface42_0 = interface42_1;
	}

	public void imethod_2()
	{
		method_31();
		if (method_17())
		{
			Struct48.smethod_0(this);
		}
		else
		{
			Struct47.smethod_0(this);
		}
		Shapes.method_0(imethod_0());
		method_34();
		method_33(100);
	}

	private void method_31()
	{
		int width = method_3().method_2().Width;
		method_3().method_2().method_6();
		method_3().method_1().method_5();
		Size size = imethod_13();
		Rectangle rectangle_ = new Rectangle(0, 0, size.Width, size.Height);
		RectangleF rectangleF;
		if (width <= 1)
		{
			float width2 = Width - 1;
			float height = Height - 1;
			rectangleF = new RectangleF(0f, 0f, width2, height);
		}
		else
		{
			float width2 = Width;
			float height = Height;
			rectangleF = new RectangleF((float)width / 2f, (float)width / 2f, width2, height);
		}
		if (IsRectangularCornered)
		{
			method_3().method_1().method_7(rectangle_);
			method_3().method_2().method_10(rectangleF);
		}
		else
		{
			method_32(rectangleF.X, rectangleF.Y, rectangleF.Width, rectangleF.Height, 13f);
		}
	}

	private void method_32(float float_1, float float_2, float float_3, float float_4, float float_5)
	{
		GraphicsPath graphicsPath = new GraphicsPath();
		graphicsPath.AddLine(float_1 + float_5, float_2, float_1 + float_3 - float_5 * 2f, float_2);
		graphicsPath.AddArc(float_1 + float_3 - float_5 * 2f, float_2, float_5 * 2f, float_5 * 2f, 270f, 90f);
		graphicsPath.AddLine(float_1 + float_3, float_2 + float_5, float_1 + float_3, float_2 + float_4 - float_5 * 2f);
		graphicsPath.AddArc(float_1 + float_3 - float_5 * 2f, float_2 + float_4 - float_5 * 2f, float_5 * 2f, float_5 * 2f, 0f, 90f);
		graphicsPath.AddLine(float_1 + float_3 - float_5 * 2f, float_2 + float_4, float_1 + float_5, float_2 + float_4);
		graphicsPath.AddArc(float_1, float_2 + float_4 - float_5 * 2f, float_5 * 2f, float_5 * 2f, 90f, 90f);
		graphicsPath.AddLine(float_1, float_2 + float_4 - float_5 * 2f, float_1, float_2 + float_5);
		graphicsPath.AddArc(float_1, float_2, float_5 * 2f, float_5 * 2f, 180f, 90f);
		graphicsPath.CloseFigure();
		method_3().method_1().method_9(graphicsPath);
		method_3().method_2().method_11(graphicsPath);
	}

	private void method_33(int int_16)
	{
		if (!vmethod_1())
		{
			return;
		}
		string text = "                Evaluation Only\r\nCreated with " + string_0 + "\r\n     (C) 2003-" + DateTime.Now.Year + " Aspose Pty Ltd";
		Rectangle position = Position;
		int num = 10;
		string text2 = "Microsoft Sans Serif";
		Font font = null;
		using SolidBrush brush_ = new SolidBrush(Color.FromArgb(int_16, 120, 120, 191));
		SizeF sizeF;
		do
		{
			font?.Dispose();
			font = Struct63.smethod_23(text2, num, FontStyle.Regular);
			sizeF = interface42_0.imethod_39(text, font);
			if ((double)sizeF.Width < (double)position.Width * 0.55)
			{
				num++;
				continue;
			}
			if (!((double)sizeF.Width > (double)position.Width * 0.8))
			{
				break;
			}
			num--;
		}
		while (num > 1);
		float x = (float)position.Left + ((float)position.Width - sizeF.Width) / 2f;
		float y = (float)position.Top + ((float)position.Height - sizeF.Height) / 2f;
		RectangleF rectangleF = new RectangleF(x, y, sizeF.Width, sizeF.Height);
		if (method_3().method_1().method_2())
		{
			interface42_0.imethod_57(TextRenderingHint.AntiAlias);
		}
		TextRenderingHint textRenderingHint_ = interface42_0.imethod_56();
		CompositingQuality compositingQuality_ = interface42_0.imethod_59();
		int num2 = interface42_0.imethod_61();
		interface42_0.imethod_60(CompositingQuality.GammaCorrected);
		interface42_0.imethod_62(0);
		interface42_0.imethod_25(text, font, brush_, rectangleF);
		interface42_0.imethod_62(num2);
		interface42_0.imethod_60(compositingQuality_);
		interface42_0.imethod_57(textRenderingHint_);
		font?.Dispose();
	}

	private void method_34()
	{
		for (int i = 0; i < imethod_10().Count; i++)
		{
			Class821 @class = class826_0.method_0(i);
			using MemoryStream memoryStream = new MemoryStream();
			int num = Class1036.int_0;
			Interface42 @interface = Class1036.smethod_0(num, @class.imethod_13().Width, @class.imethod_13().Height, ImageFormat.Emf, null, memoryStream, @class);
			@interface.imethod_2();
			if (memoryStream.Length != 0)
			{
				memoryStream.Seek(0L, SeekOrigin.Begin);
				using Image image_ = Image.FromStream(memoryStream);
				imethod_0().imethod_11(image_, @class.X, @class.Y, @class.Width, @class.Height);
			}
		}
	}

	~Class821()
	{
		Dispose(bool_12: false);
	}

	public void Dispose()
	{
		Dispose(bool_12: true);
		GC.SuppressFinalize(this);
	}

	protected virtual void Dispose(bool bool_12)
	{
		if (bool_11)
		{
			return;
		}
		if (bool_12)
		{
			if (class848_0 != null)
			{
				class848_0.Dispose();
			}
			if (class829_1 != null)
			{
				class829_1.Dispose();
			}
			if (class829_0 != null)
			{
				class829_0.Dispose();
			}
			if (class838_0 != null)
			{
				class838_0.Dispose();
			}
			if (class828_0 != null)
			{
				class828_0.Dispose();
			}
			if (class851_0 != null)
			{
				class851_0.Dispose();
			}
			if (class851_1 != null)
			{
				class851_1.Dispose();
			}
			if (class851_2 != null)
			{
				class851_2.Dispose();
			}
			if (class835_0 != null)
			{
				class835_0.Dispose();
			}
			if (class823_0 != null)
			{
				class823_0.Dispose();
			}
			if (class823_1 != null)
			{
				class823_1.Dispose();
			}
			if (class823_2 != null)
			{
				class823_2.Dispose();
			}
			if (class823_3 != null)
			{
				class823_3.Dispose();
			}
			if (class823_4 != null)
			{
				class823_4.Dispose();
			}
			if (class842_0 != null)
			{
				for (int i = 0; i < class842_0.Count; i++)
				{
					class842_0.method_9(i)?.Dispose();
				}
			}
			if (class826_0 != null)
			{
				for (int j = 0; j < class826_0.Count; j++)
				{
					class826_0.method_0(j)?.Dispose();
				}
			}
		}
		bool_11 = true;
	}
}
