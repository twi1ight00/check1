using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.CompilerServices;

namespace ns5;

internal class Class883
{
	private Class888 class888_0;

	private Enum108 enum108_0;

	private HatchBrush hatchBrush_0;

	private TextureBrush textureBrush_0;

	private TextureBrush textureBrush_1;

	private Class154 class154_0;

	private Class159 class159_0;

	internal Class159 TextureFill
	{
		get
		{
			if (class159_0 == null)
			{
				class159_0 = new Class159();
			}
			return class159_0;
		}
	}

	[SpecialName]
	internal Class154 method_0()
	{
		if (class154_0 == null)
		{
			class154_0 = new Class154();
		}
		return class154_0;
	}

	[SpecialName]
	internal Enum108 method_1()
	{
		return enum108_0;
	}

	internal void method_2(Color color_0, Color color_1, HatchStyle hatchStyle_0)
	{
		enum108_0 = Enum108.const_2;
		hatchBrush_0 = new HatchBrush(hatchStyle_0, color_0, color_1);
	}

	public Brush method_3(GraphicsPath graphicsPath_0, Pen pen_0, bool bool_0, float float_0)
	{
		return enum108_0 switch
		{
			Enum108.const_0 => class154_0.method_3(graphicsPath_0, pen_0, bool_0, float_0), 
			Enum108.const_1 => textureBrush_0, 
			Enum108.const_2 => hatchBrush_0, 
			Enum108.const_3 => textureBrush_1, 
			_ => new SolidBrush(Color.White), 
		};
	}

	public Brush method_4(Class884 class884_0, GraphicsPath graphicsPath_0, float float_0, float float_1)
	{
		return enum108_0 switch
		{
			Enum108.const_0 => class154_0.method_2(class884_0, graphicsPath_0, float_0, float_1), 
			Enum108.const_1 => textureBrush_0, 
			Enum108.const_2 => hatchBrush_0, 
			Enum108.const_3 => textureBrush_1, 
			_ => new SolidBrush(Color.White), 
		};
	}

	public Brush method_5(RectangleF rectangleF_0)
	{
		return enum108_0 switch
		{
			Enum108.const_0 => class888_0.method_0(rectangleF_0, bool_1: false), 
			Enum108.const_1 => new TextureBrush(new Bitmap(textureBrush_0.Image, new Size((int)rectangleF_0.Width, (int)rectangleF_0.Height))), 
			Enum108.const_2 => hatchBrush_0, 
			Enum108.const_3 => new TextureBrush(new Bitmap(textureBrush_1.Image, new Size((int)rectangleF_0.Width, (int)rectangleF_0.Height))), 
			_ => new SolidBrush(Color.White), 
		};
	}

	internal void method_6(Image image_0, RectangleF rectangleF_0)
	{
		enum108_0 = Enum108.const_1;
		textureBrush_0 = (TextureBrush)class159_0.method_9(image_0, rectangleF_0);
	}
}
