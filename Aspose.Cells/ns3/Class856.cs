using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.CompilerServices;

namespace ns3;

internal class Class856 : IDisposable, Interface34
{
	private Interface8 interface8_0;

	private HatchBrush hatchBrush_0;

	private Class867 class867_0;

	private Class857 class857_0;

	private bool bool_0;

	public Interface35 GradientFill => class857_0;

	public Interface40 TextureFill => class867_0;

	public Class856(Interface8 interface8_1)
	{
		interface8_0 = interface8_1;
		class857_0 = new Class857();
		class867_0 = new Class867();
	}

	[SpecialName]
	internal Class857 method_0()
	{
		return class857_0;
	}

	public void imethod_0(Color color_0, Color color_1, HatchStyle hatchStyle_0)
	{
		interface8_0.Formatting = Enum71.const_5;
		hatchBrush_0 = new HatchBrush(hatchStyle_0, color_0, color_1);
	}

	[SpecialName]
	internal Enum71 method_1()
	{
		return interface8_0.Formatting;
	}

	internal Brush method_2(RectangleF rectangleF_0)
	{
		GraphicsPath graphicsPath = new GraphicsPath();
		graphicsPath.AddRectangle(rectangleF_0);
		return method_3(graphicsPath, bool_1: false, 1f);
	}

	public Brush method_3(GraphicsPath graphicsPath_0, bool bool_1, float float_0)
	{
		switch (method_1())
		{
		default:
			return new SolidBrush(Color.White);
		case Enum71.const_3:
			return method_0().method_1(graphicsPath_0, null, bool_1, float_0);
		case Enum71.const_4:
			return class867_0.method_1(graphicsPath_0, float_0);
		case Enum71.const_5:
		{
			Color foreColor = Color.FromArgb(hatchBrush_0.ForegroundColor.A, (int)((float)(int)hatchBrush_0.ForegroundColor.R * float_0), (int)((float)(int)hatchBrush_0.ForegroundColor.G * float_0), (int)((float)(int)hatchBrush_0.ForegroundColor.B * float_0));
			Color backColor = Color.FromArgb(hatchBrush_0.BackgroundColor.A, (int)((float)(int)hatchBrush_0.BackgroundColor.R * float_0), (int)((float)(int)hatchBrush_0.BackgroundColor.G * float_0), (int)((float)(int)hatchBrush_0.BackgroundColor.B * float_0));
			return new HatchBrush(hatchBrush_0.HatchStyle, foreColor, backColor);
		}
		}
	}

	public void method_4(Brush brush_0)
	{
		switch (method_1())
		{
		case Enum71.const_4:
			brush_0.Dispose();
			break;
		case Enum71.const_3:
		case Enum71.const_5:
			brush_0.Dispose();
			break;
		}
	}

	~Class856()
	{
		Dispose(bool_1: false);
	}

	public void Dispose()
	{
		Dispose(bool_1: true);
		GC.SuppressFinalize(this);
	}

	protected virtual void Dispose(bool bool_1)
	{
		if (!bool_0)
		{
			if (bool_1 && class867_0 != null)
			{
				class867_0.Dispose();
			}
			bool_0 = true;
		}
	}
}
