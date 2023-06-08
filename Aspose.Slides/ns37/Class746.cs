using System.Drawing;
using Aspose.Slides.Charts;
using ns36;
using ns38;

namespace ns37;

internal class Class746 : Interface10
{
	private Class740 class740_0;

	private Class741 class741_0;

	private Class755 class755_0;

	private Font font_0;

	private bool bool_0;

	private Color color_0;

	private int int_0;

	private int int_1;

	private int int_2;

	private int int_3;

	internal Rectangle rectangle_0;

	internal Rectangle rectangle_1;

	private bool bool_1 = true;

	private bool bool_2 = true;

	private bool bool_3 = true;

	private bool bool_4 = true;

	private object object_0;

	private Enum140 enum140_0;

	private int int_4;

	private int int_5;

	private int int_6;

	private bool bool_5 = true;

	internal Class740 Chart => class740_0;

	internal object Parent => object_0;

	internal Class741 AreaInternal => class741_0;

	public Interface6 Area => class741_0;

	internal Class755 BorderInternal => class755_0;

	public Interface18 Border => class755_0;

	public Font TextFont
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

	public Color FontColor
	{
		get
		{
			if (bool_0)
			{
				if (Chart.StyleIndex > 40)
				{
					return Chart.Themes.ThemeColors.method_3("lt1");
				}
				return Chart.Themes.ThemeColors.method_3("dk1");
			}
			return color_0;
		}
		set
		{
			bool_0 = false;
			color_0 = value;
		}
	}

	public virtual int Width
	{
		get
		{
			Enum140 @enum = enum140_0;
			if (@enum != Enum140.const_1 && @enum != Enum140.const_10)
			{
				return int_0;
			}
			if (!IsSizeAuto && int_0 + X > 4000)
			{
				return 4000 - X;
			}
			return int_0;
		}
		set
		{
			int_0 = value;
			bool_3 = false;
		}
	}

	public virtual int Height
	{
		get
		{
			Enum140 @enum = enum140_0;
			if (@enum != Enum140.const_1 && @enum != Enum140.const_10)
			{
				return int_1;
			}
			if (!IsSizeAuto && int_1 + Y > 4000)
			{
				return 4000 - Y;
			}
			return int_1;
		}
		set
		{
			int_1 = value;
			bool_3 = false;
		}
	}

	public virtual int X
	{
		get
		{
			Enum140 @enum = enum140_0;
			if (@enum != Enum140.const_1 && @enum != Enum140.const_10)
			{
				return int_2;
			}
			if (int_2 >= 0)
			{
				return int_2;
			}
			return 0;
		}
		set
		{
			int_2 = value;
			bool_1 = false;
		}
	}

	public virtual int Y
	{
		get
		{
			Enum140 @enum = enum140_0;
			if (@enum != Enum140.const_1 && @enum != Enum140.const_10)
			{
				return int_3;
			}
			if (int_3 >= 0)
			{
				return int_3;
			}
			return 0;
		}
		set
		{
			int_3 = value;
			bool_2 = false;
		}
	}

	public virtual Rectangle Rectangle
	{
		get
		{
			return new Rectangle(int_2, int_3, int_0, int_1);
		}
		set
		{
			int_2 = value.X;
			int_3 = value.Y;
			int_0 = value.Width;
			int_1 = value.Height;
			bool_1 = false;
			bool_2 = false;
			bool_3 = false;
		}
	}

	public bool IsXAuto
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

	public bool IsYAuto
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

	public bool IsSizeAuto
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

	public bool IsEdge
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

	public bool IsBoundAuto
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

	internal Class746(Class740 chart, object parent, Enum140 areaParentType, Enum145 lineParentType)
	{
		class740_0 = chart;
		int_2 = 0;
		int_3 = 0;
		int_0 = 0;
		int_1 = 0;
		class741_0 = new Class741(chart, parent, areaParentType);
		class755_0 = new Class755(chart, lineParentType);
		method_0(lineParentType, chart.Font);
		bool_0 = true;
		color_0 = chart.Themes.ThemeColors.method_3("dk1");
		rectangle_0 = Rectangle.Empty;
		rectangle_1 = Rectangle.Empty;
		object_0 = parent;
		enum140_0 = areaParentType;
	}

	private void method_0(Enum145 lineParentType, Font sourceFont)
	{
		switch (lineParentType)
		{
		default:
			font_0 = sourceFont;
			break;
		case Enum145.const_10:
		case Enum145.const_11:
			font_0 = new Font(sourceFont.Name, sourceFont.Size, FontStyle.Bold);
			break;
		}
	}

	internal Size method_1()
	{
		int width = Width * method_10() / method_12();
		int height = Height * method_11() / method_12();
		return new Size(width, height);
	}

	internal int method_2()
	{
		return Width * method_10() / method_12();
	}

	internal int method_3()
	{
		return Height * method_11() / method_12();
	}

	internal int method_4()
	{
		return X * method_10() / method_12();
	}

	internal int method_5()
	{
		return Y * method_11() / method_12();
	}

	internal void method_6()
	{
		rectangle_0.X = rectangle_1.X;
		rectangle_0.Y = rectangle_1.Y;
		rectangle_0.Width = rectangle_1.Width;
		rectangle_0.Height = rectangle_1.Height;
		ChartType chartType = ChartType.ClusteredColumn;
		if (!bool_1)
		{
			if ((enum140_0 != Enum140.const_12 || bool_4) && enum140_0 != Enum140.const_16 && (enum140_0 != Enum140.const_8 || bool_4))
			{
				if (enum140_0 != Enum140.const_1)
				{
					int num = method_4();
					rectangle_0.X = ((num >= 0) ? num : 0);
					if (rectangle_0.Right > class740_0.Width)
					{
						rectangle_0.X = class740_0.Width - rectangle_0.Width;
					}
				}
			}
			else
			{
				int num2 = ((rectangle_0.X >= 0) ? rectangle_0.X : 0);
				if (rectangle_0.Right > class740_0.Width)
				{
					num2 = class740_0.Width - rectangle_0.Width;
				}
				if (chartType == ChartType.ClusteredBar)
				{
					int num3 = int_2;
					int_2 = int_3;
					num2 -= method_4();
					int_2 = num3;
				}
				else
				{
					num2 += method_4();
				}
				rectangle_0.X = ((num2 >= 0) ? num2 : 0);
				if (rectangle_0.Right > class740_0.Width)
				{
					rectangle_0.X = class740_0.Width - rectangle_0.Width;
				}
				bool_3 = true;
			}
		}
		if (!bool_2)
		{
			if ((enum140_0 != Enum140.const_12 || bool_4) && enum140_0 != Enum140.const_16 && (enum140_0 != Enum140.const_8 || bool_4))
			{
				if (enum140_0 != Enum140.const_1)
				{
					int num4 = method_5();
					rectangle_0.Y = ((num4 >= 0) ? num4 : 0);
					if (rectangle_0.Bottom > class740_0.Height)
					{
						rectangle_0.Y = class740_0.Height - rectangle_0.Height;
					}
				}
			}
			else
			{
				int num5 = ((rectangle_0.Y >= 0) ? rectangle_0.Y : 0);
				if (rectangle_0.Bottom > class740_0.Height)
				{
					num5 = class740_0.Height - rectangle_0.Height;
				}
				if (chartType == ChartType.ClusteredBar)
				{
					int num6 = int_3;
					int_3 = int_2;
					num5 -= method_5();
					int_3 = num6;
				}
				else
				{
					num5 += method_5();
				}
				rectangle_0.Y = ((num5 >= 0) ? num5 : 0);
				if (rectangle_0.Bottom > class740_0.Height)
				{
					rectangle_0.Y = class740_0.Height - rectangle_0.Height;
				}
			}
		}
		if (!bool_3 && enum140_0 == Enum140.const_10)
		{
			Size size = method_1();
			rectangle_0.Width = size.Width;
			rectangle_0.Height = size.Height;
		}
	}

	internal void method_7(int val)
	{
		int_4 = val;
	}

	internal void method_8(int val)
	{
		int_5 = val;
	}

	internal void method_9(int val)
	{
		int_6 = val;
	}

	private int method_10()
	{
		switch (enum140_0)
		{
		default:
			return int_4;
		case Enum140.const_1:
		case Enum140.const_8:
		case Enum140.const_9:
		case Enum140.const_10:
		case Enum140.const_12:
		case Enum140.const_13:
			return class740_0.Position.Width;
		}
	}

	private int method_11()
	{
		switch (enum140_0)
		{
		default:
			return int_5;
		case Enum140.const_1:
		case Enum140.const_8:
		case Enum140.const_9:
		case Enum140.const_10:
		case Enum140.const_12:
		case Enum140.const_13:
			return class740_0.Position.Height;
		}
	}

	private int method_12()
	{
		switch (enum140_0)
		{
		default:
			return int_6;
		case Enum140.const_1:
		case Enum140.const_8:
		case Enum140.const_9:
		case Enum140.const_10:
		case Enum140.const_12:
		case Enum140.const_13:
		case Enum140.const_16:
			return 4000;
		}
	}

	internal void method_13()
	{
		method_6();
		class741_0.method_2();
		class755_0.method_2();
	}

	internal Rectangle method_14()
	{
		if (!IsBoundAuto && enum140_0 != Enum140.const_1)
		{
			return Rectangle;
		}
		method_6();
		Rectangle result = new Rectangle(rectangle_0.X, rectangle_0.Y, rectangle_0.Width, rectangle_0.Height);
		ChartType chartType = ChartType.ClusteredColumn;
		if (enum140_0 == Enum140.const_12)
		{
			chartType = ((!(object_0 is Class759)) ? ((Class748)object_0).ChartPoints.ASeries.ResembleType : ((Class759)object_0).ResembleType);
		}
		if (enum140_0 == Enum140.const_12)
		{
			if (chartType == ChartType.ClusteredBar)
			{
				result.X = Struct41.smethod_5((double)method_12() * (double)result.Y / (double)method_11());
			}
			else
			{
				result.X = Struct41.smethod_5((double)method_12() * (double)result.X / (double)method_10());
			}
		}
		else
		{
			result.X = Struct41.smethod_5((double)method_12() * (double)result.X / (double)method_10());
		}
		if (enum140_0 == Enum140.const_12)
		{
			if (chartType == ChartType.ClusteredBar)
			{
				result.Y = Struct41.smethod_5((double)method_12() * (double)result.X / (double)method_10());
			}
			else
			{
				result.Y = Struct41.smethod_5((double)method_12() * (double)result.Y / (double)method_11());
			}
		}
		else
		{
			result.Y = Struct41.smethod_5((double)method_12() * (double)result.Y / (double)method_11());
		}
		result.Width = Struct41.smethod_5((double)method_12() * (double)result.Width / (double)method_10());
		result.Height = Struct41.smethod_5((double)method_12() * (double)result.Height / (double)method_11());
		return result;
	}

	internal float method_15()
	{
		return Struct41.smethod_3(Chart.Graphics.GraphicsTools.imethod_2(TextFont));
	}

	internal bool method_16()
	{
		method_6();
		if (rectangle_0.Width > 0 && rectangle_0.Height > 0)
		{
			return false;
		}
		return true;
	}

	internal void method_17()
	{
		if (!method_16())
		{
			AreaInternal.method_4(rectangle_0);
			BorderInternal.method_6(rectangle_0);
		}
	}
}
