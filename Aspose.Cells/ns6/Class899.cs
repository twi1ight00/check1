using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.CompilerServices;

namespace ns6;

internal class Class899
{
	private Class905 class905_0;

	private Enum122 enum122_0;

	private Class313 class313_0;

	private HatchBrush hatchBrush_0;

	private TextureBrush textureBrush_0;

	private TextureBrush textureBrush_1;

	private Class309 class309_0;

	private Class900 class900_0;

	internal Class313 TextureFill
	{
		get
		{
			if (class313_0 == null)
			{
				class313_0 = new Class313();
			}
			return class313_0;
		}
	}

	public Class899(Class900 class900_1)
	{
		class900_0 = class900_1;
		class313_0 = new Class313();
	}

	[SpecialName]
	internal Class309 method_0()
	{
		if (class309_0 == null)
		{
			class309_0 = new Class309();
		}
		return class309_0;
	}

	internal void method_1(Image image_0, GraphicsPath graphicsPath_0)
	{
		enum122_0 = Enum122.const_1;
		textureBrush_0 = (TextureBrush)class313_0.method_9(image_0, graphicsPath_0);
	}

	public Brush method_2(RectangleF rectangleF_0)
	{
		return enum122_0 switch
		{
			Enum122.const_0 => class905_0.method_0(rectangleF_0, bool_1: false), 
			Enum122.const_1 => textureBrush_0, 
			Enum122.const_2 => hatchBrush_0, 
			Enum122.const_3 => textureBrush_1, 
			_ => new SolidBrush(Color.White), 
		};
	}

	public Brush method_3(GraphicsPath graphicsPath_0, Pen pen_0, bool bool_0, float float_0)
	{
		return enum122_0 switch
		{
			Enum122.const_0 => class309_0.method_2(graphicsPath_0, pen_0, bool_0, float_0), 
			Enum122.const_1 => textureBrush_0, 
			Enum122.const_2 => hatchBrush_0, 
			Enum122.const_3 => textureBrush_1, 
			_ => new SolidBrush(Color.White), 
		};
	}
}
