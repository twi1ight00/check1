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
using ns32;
using ns5;

namespace ns31;

internal class Class787 : IDisposable, Interface6, Interface7
{
	private Interface42 interface42_0;

	internal bool bool_0;

	private Class789 class789_0;

	private Class789 class789_1;

	private Class789 class789_2;

	private Class789 class789_3;

	private Class812 class812_0;

	private ChartType_Chart chartType_Chart_0;

	private Class808 class808_0;

	private Class794 class794_0;

	private Class794 class794_1;

	private Class793 class793_0;

	private bool bool_1;

	private bool bool_2;

	private bool bool_3;

	private Class804 class804_0;

	private Class797 class797_0;

	private Class797 class797_1;

	private bool bool_4;

	private string string_0;

	private Class792 class792_0;

	private Class789 class789_4;

	private int int_0;

	private int int_1;

	private int int_2;

	private int int_3;

	private int int_4;

	private int int_5;

	private Class816 class816_0;

	private Class801 class801_0;

	private bool bool_5;

	private bool bool_6;

	private int int_6;

	private int int_7;

	private Class516 class516_0;

	private Class895 class895_0;

	private int int_8;

	private int int_9;

	private int int_10;

	private RectangleF rectangleF_0;

	private float float_0;

	private Rectangle rectangle_0 = Rectangle.Empty;

	internal Rectangle rectangle_1 = Rectangle.Empty;

	internal bool bool_7;

	internal Class789 class789_5;

	internal double double_0;

	internal double double_1;

	internal bool bool_8;

	private bool bool_9;

	private bool bool_10;

	public int Width
	{
		get
		{
			if (class794_0.Width == 0)
			{
				return 1;
			}
			return class794_0.Width;
		}
	}

	public int Height
	{
		get
		{
			if (class794_0.Height == 0)
			{
				return 1;
			}
			return class794_0.Height;
		}
	}

	public virtual int X
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

	public virtual int Y
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

	public Interface9 CategoryAxis => class789_0;

	public Interface9 ValueAxis => class789_2;

	public Interface9 SeriesAxis => class789_4;

	public Interface30 Title => class812_0;

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

	public Interface33 Walls => class816_0;

	public Interface14 ChartArea => class794_0;

	public Interface13 ChartDataTable => class793_0;

	public Interface23 Legend => class804_0;

	public Interface27 NSeries => class808_0;

	public Interface14 PlotArea => class794_1;

	public Interface20 Floor => class801_0;

	public bool IsInnerMode
	{
		set
		{
		}
	}

	public int Rotation
	{
		get
		{
			return int_4 % 360;
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
			foreach (Class810 item in class808_0)
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
			bool_6 = value;
		}
	}

	public bool IsDataTableShown
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

	public bool IsLegendShown
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

	public bool IsRectangularCornered
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

	public Class895 Shapes => class895_0;

	internal Font Font => class794_0.Font;

	internal Color FontColor => class794_0.FontColor;

	public Class787(Font font_0, Color color_0)
	{
		method_0(font_0, color_0);
	}

	public Class787()
	{
		method_0(null, Color.Empty);
		class794_1.method_2().Color = method_14(bool_11: false).GetColor(55);
	}

	private void method_0(Font font_0, Color color_0)
	{
		class797_0 = new Class797(null, bool_0: false);
		class797_1 = new Class797(null, bool_0: true);
		class794_0 = new Class794(this, this, Enum52.const_0);
		class794_0.Width = 533;
		class794_0.Height = 400;
		class794_0.method_3(font_0);
		if (!color_0.IsEmpty)
		{
			class794_0.FontColor = color_0;
		}
		class789_0 = new Class789(this, Enum61.const_0);
		class789_1 = new Class789(this, Enum61.const_2);
		class789_1.IsVisible = false;
		class789_2 = new Class789(this, Enum61.const_1);
		class789_3 = new Class789(this, Enum61.const_3);
		class789_3.IsVisible = false;
		class789_4 = new Class789(this, Enum61.const_4);
		class789_4.IsVisible = (method_29() ? true : false);
		class793_0 = new Class793(this);
		bool_1 = false;
		bool_2 = true;
		bool_3 = true;
		class804_0 = new Class804(this, this, Enum52.const_10);
		class808_0 = new Class808(this);
		class794_1 = new Class794(this, this, Enum52.const_1);
		class812_0 = new Class812(this, this, Enum52.const_8);
		chartType_Chart_0 = ChartType_Chart.Column;
		bool_0 = false;
		string_0 = "Aspose.Cells for .NET";
		bool_6 = true;
		bool_5 = true;
		class792_0 = new Class792();
		bool_4 = true;
		int_0 = 100;
		int_1 = 150;
		int_2 = 150;
		int_5 = 100;
		int_3 = 15;
		int_4 = 20;
		class816_0 = new Class816(this);
		class801_0 = new Class801(this);
		class895_0 = new Class895(this);
		class516_0 = new Class516();
	}

	[SpecialName]
	internal Class789 method_1()
	{
		return class789_0;
	}

	[SpecialName]
	internal Class789 method_2()
	{
		return class789_1;
	}

	[SpecialName]
	public Interface9 imethod_3()
	{
		return class789_1;
	}

	[SpecialName]
	internal Class794 method_3()
	{
		return class794_0;
	}

	[SpecialName]
	internal Class793 method_4()
	{
		return class793_0;
	}

	[SpecialName]
	internal Class801 method_5()
	{
		return class801_0;
	}

	[SpecialName]
	internal Class804 method_6()
	{
		return class804_0;
	}

	[SpecialName]
	internal Class808 method_7()
	{
		return class808_0;
	}

	[SpecialName]
	internal Class794 method_8()
	{
		return class794_1;
	}

	[SpecialName]
	internal Class789 method_9()
	{
		return class789_2;
	}

	[SpecialName]
	internal Class789 method_10()
	{
		return class789_3;
	}

	[SpecialName]
	public Interface9 imethod_4()
	{
		return class789_3;
	}

	[SpecialName]
	internal Class789 method_11()
	{
		return class789_4;
	}

	[SpecialName]
	internal Class812 method_12()
	{
		return class812_0;
	}

	[SpecialName]
	internal Class816 method_13()
	{
		return class816_0;
	}

	[SpecialName]
	public Interface33 imethod_6()
	{
		return class816_0;
	}

	[SpecialName]
	public Interface33 imethod_5()
	{
		return class816_0;
	}

	[SpecialName]
	public int imethod_7()
	{
		return 0;
	}

	[SpecialName]
	public void imethod_8(int int_11)
	{
	}

	internal Class797 method_14(bool bool_11)
	{
		if (bool_11)
		{
			return class797_1;
		}
		return class797_0;
	}

	public void ChangePalette(Color[] color_0)
	{
		class797_0.ChangePalette(color_0, bool_0: false);
		class797_1.ChangePalette(color_0, bool_0: true);
	}

	[SpecialName]
	public bool vmethod_0()
	{
		return bool_0;
	}

	[SpecialName]
	public void imethod_11(bool bool_11)
	{
		bool_0 = bool_11;
	}

	[SpecialName]
	public void imethod_12(string string_1)
	{
		string_0 = string_1;
	}

	[SpecialName]
	public Size imethod_13()
	{
		int num = (int)method_3().method_2().LineStyle.Width;
		if (num <= 1)
		{
			return new Size(Width, Height);
		}
		return new Size(Width + num, Height + num);
	}

	internal bool method_15()
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
	public Interface12 imethod_10()
	{
		return class792_0;
	}

	[SpecialName]
	public bool vmethod_1()
	{
		return bool_4;
	}

	[SpecialName]
	public void imethod_9(bool bool_11)
	{
		bool_4 = bool_11;
	}

	internal void method_16()
	{
		for (int i = 0; i < imethod_10().Count; i++)
		{
			Class787 @class = class792_0.method_0(i);
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

	[SpecialName]
	internal int method_17()
	{
		return int_8;
	}

	[SpecialName]
	internal void method_18(int int_11)
	{
		int_8 = int_11;
	}

	[SpecialName]
	internal int method_19()
	{
		return int_9;
	}

	[SpecialName]
	internal void method_20(int int_11)
	{
		int_9 = int_11;
	}

	[SpecialName]
	internal int method_21()
	{
		return int_10;
	}

	[SpecialName]
	internal void method_22(int int_11)
	{
		int_10 = int_11;
	}

	[SpecialName]
	internal RectangleF method_23()
	{
		return rectangleF_0;
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
		if (!PlotArea.imethod_3())
		{
			return rectangle_0;
		}
		int num = class794_0.Width - 2 * Class817.int_2;
		int num2 = class794_0.Height - 2 * Class817.int_2;
		return new Rectangle((int)((double)((float)rectangle_0.X * 4000f / (float)num) + 0.5), (int)((double)((float)rectangle_0.Y * 4000f / (float)num2) + 0.5), (int)((double)((float)rectangle_0.Width * 4000f / (float)num) + 0.5), (int)((double)((float)rectangle_0.Height * 4000f / (float)num2) + 0.5));
	}

	[SpecialName]
	internal void method_28(Rectangle rectangle_2)
	{
		rectangle_0 = rectangle_2;
	}

	[SpecialName]
	internal bool method_29()
	{
		switch (chartType_Chart_0)
		{
		default:
			return false;
		case ChartType_Chart.Area3D:
		case ChartType_Chart.Column3D:
		case ChartType_Chart.ConicalColumn3D:
		case ChartType_Chart.CylindricalColumn3D:
		case ChartType_Chart.Line3D:
		case ChartType_Chart.PyramidColumn3D:
			return true;
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
		bool_9 = true;
		if (method_15())
		{
			Struct22.smethod_0(this);
		}
		else
		{
			Class817.smethod_0(this);
		}
		bool_9 = false;
	}

	[SpecialName]
	internal bool method_30()
	{
		return bool_9;
	}

	internal void method_31(int int_11)
	{
		if (!vmethod_1())
		{
			return;
		}
		string text = "                Evaluation Only\r\nCreated with " + string_0 + "\r\n     (C) 2003-" + DateTime.Now.Year + " Aspose Pty Ltd";
		RectangleF rectangleF = new RectangleF(0f, 0f, Width, Height);
		int num = 10;
		string text2 = "Microsoft Sans Serif";
		Font font = null;
		using SolidBrush brush_ = new SolidBrush(Color.FromArgb(int_11, 120, 120, 191));
		SizeF sizeF;
		do
		{
			font?.Dispose();
			font = Struct40.smethod_23(text2, num, FontStyle.Regular);
			sizeF = interface42_0.imethod_39(text, font);
			if ((double)sizeF.Width < (double)rectangleF.Width * 0.55)
			{
				num++;
				continue;
			}
			if (!((double)sizeF.Width > (double)rectangleF.Width * 0.8))
			{
				break;
			}
			num--;
		}
		while (num > 1);
		float x = rectangleF.Left + (rectangleF.Width - sizeF.Width) / 2f;
		float y = rectangleF.Top + (rectangleF.Height - sizeF.Height) / 2f;
		RectangleF rectangleF2 = new RectangleF(x, y, sizeF.Width, sizeF.Height);
		if (method_3().method_1().method_3())
		{
			interface42_0.imethod_57(TextRenderingHint.AntiAlias);
		}
		TextRenderingHint textRenderingHint_ = interface42_0.imethod_56();
		CompositingQuality compositingQuality_ = interface42_0.imethod_59();
		int num2 = interface42_0.imethod_61();
		interface42_0.imethod_60(CompositingQuality.GammaCorrected);
		interface42_0.imethod_62(0);
		interface42_0.imethod_25(text, font, brush_, rectangleF2);
		interface42_0.imethod_62(num2);
		interface42_0.imethod_60(compositingQuality_);
		interface42_0.imethod_57(textRenderingHint_);
		font?.Dispose();
	}

	public void imethod_2()
	{
		Struct24.smethod_1(imethod_0(), this);
		if (method_15())
		{
			Struct22.smethod_0(this);
		}
		else
		{
			Class817.smethod_0(this);
		}
		Shapes.method_0(imethod_0());
		method_16();
		method_31(100);
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

	~Class787()
	{
		Dispose(bool_11: false);
	}

	public void Dispose()
	{
		Dispose(bool_11: true);
		GC.SuppressFinalize(this);
	}

	protected virtual void Dispose(bool bool_11)
	{
		if (bool_10)
		{
			return;
		}
		if (bool_11)
		{
			if (class812_0 != null)
			{
				class812_0.Dispose();
			}
			if (class794_1 != null)
			{
				class794_1.Dispose();
			}
			if (class794_0 != null)
			{
				class794_0.Dispose();
			}
			if (class804_0 != null)
			{
				class804_0.Dispose();
			}
			if (class801_0 != null)
			{
				class801_0.Dispose();
			}
			if (class816_0 != null)
			{
				class816_0.Dispose();
			}
			if (class793_0 != null)
			{
				class793_0.Dispose();
			}
			if (class789_0 != null)
			{
				class789_0.Dispose();
			}
			if (class789_1 != null)
			{
				class789_1.Dispose();
			}
			if (class789_2 != null)
			{
				class789_2.Dispose();
			}
			if (class789_3 != null)
			{
				class789_3.Dispose();
			}
			if (class789_4 != null)
			{
				class789_4.Dispose();
			}
			if (class808_0 != null)
			{
				for (int i = 0; i < class808_0.Count; i++)
				{
					class808_0.method_9(i)?.Dispose();
				}
			}
			if (class792_0 != null)
			{
				for (int j = 0; j < class792_0.Count; j++)
				{
					class792_0.method_0(j)?.Dispose();
				}
			}
		}
		bool_10 = true;
	}
}
