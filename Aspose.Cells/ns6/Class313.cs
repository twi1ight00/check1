using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.CompilerServices;
using ns22;

namespace ns6;

internal class Class313
{
	private int int_0;

	private bool bool_0;

	private double double_0;

	private double double_1;

	private double double_2;

	private double double_3;

	private Enum13 enum13_0;

	private Enum14 enum14_0;

	private Enum12 enum12_0;

	private double double_4;

	private double double_5;

	private double double_6;

	private double double_7;

	private double double_8;

	public double OffsetX
	{
		set
		{
			double_0 = method_7(value, -2112.0, 2112.0);
		}
	}

	public double OffsetY
	{
		set
		{
			double_1 = method_7(value, -2112.0, 2112.0);
		}
	}

	public double ScaleX
	{
		set
		{
			double_2 = method_7(value, 0.0, 100.0);
		}
	}

	public double ScaleY
	{
		set
		{
			double_3 = method_7(value, 0.0, 100.0);
		}
	}

	public Enum14 MirrorType
	{
		set
		{
			enum14_0 = value;
		}
	}

	public Class313()
	{
		int_0 = 0;
		bool_0 = false;
		enum13_0 = Enum13.const_7;
		enum14_0 = Enum14.const_0;
		enum12_0 = Enum12.const_0;
		double_8 = 1.0;
	}

	[SpecialName]
	public void method_0(bool bool_1)
	{
		bool_0 = bool_1;
	}

	[SpecialName]
	public void method_1(Enum13 enum13_1)
	{
		enum13_0 = enum13_1;
	}

	[SpecialName]
	public void method_2(Enum12 enum12_1)
	{
		enum12_0 = enum12_1;
	}

	[SpecialName]
	public void method_3(double double_9)
	{
		double_4 = method_7(double_9, -100.0, 100.0);
	}

	[SpecialName]
	public void method_4(double double_9)
	{
		double_5 = method_7(double_9, -100.0, 100.0);
	}

	[SpecialName]
	public void method_5(double double_9)
	{
		double_6 = method_7(double_9, -100.0, 100.0);
	}

	[SpecialName]
	public void method_6(double double_9)
	{
		double_7 = method_7(double_9, -100.0, 100.0);
	}

	private double method_7(double double_9, double double_10, double double_11)
	{
		if (double_9 < double_10)
		{
			return double_10;
		}
		if (double_9 > double_11)
		{
			return double_11;
		}
		return double_9;
	}

	[SpecialName]
	public void method_8(double double_9)
	{
		if (double_9 < 0.0)
		{
			double_8 = 0.0;
		}
		if (double_9 > 1000000000.0)
		{
			double_8 = 1000000000.0;
		}
		double_8 = double_9;
	}

	internal Brush method_9(Image image_0, GraphicsPath graphicsPath_0)
	{
		if (bool_0)
		{
			RectangleF rectangleF = Class1181.smethod_1(graphicsPath_0);
			TextureBrush textureBrush = new TextureBrush(image_0, WrapMode.Tile);
			Matrix matrix = new Matrix();
			matrix.Translate(rectangleF.X, rectangleF.Y);
			textureBrush.Transform = matrix;
			return textureBrush;
		}
		if (enum12_0 == Enum12.const_0)
		{
			RectangleF rectangleF2 = Class1181.smethod_1(graphicsPath_0);
			Bitmap bitmap = new Bitmap((int)rectangleF2.Width, (int)rectangleF2.Height);
			Graphics graphics = Graphics.FromImage(bitmap);
			RectangleF destRect = new RectangleF(0f, 0f, bitmap.Width, bitmap.Height);
			RectangleF srcRect = new RectangleF(0f, 0f, image_0.Width, image_0.Height);
			graphics.DrawImage(image_0, destRect, srcRect, GraphicsUnit.Pixel);
			return new TextureBrush(bitmap);
		}
		if (enum12_0 == Enum12.const_1)
		{
			RectangleF rectangleF3 = Class1181.smethod_1(graphicsPath_0);
			Bitmap bitmap2 = new Bitmap((int)rectangleF3.Width, (int)((float)image_0.Height * rectangleF3.Width / (float)image_0.Width));
			Graphics graphics2 = Graphics.FromImage(bitmap2);
			RectangleF destRect2 = new RectangleF(0f, 0f, bitmap2.Width, bitmap2.Height);
			RectangleF srcRect2 = new RectangleF(0f, 0f, image_0.Width, image_0.Height);
			graphics2.DrawImage(image_0, destRect2, srcRect2, GraphicsUnit.Pixel);
			int num = (int)rectangleF3.Height % bitmap2.Height;
			TextureBrush textureBrush2 = new TextureBrush(bitmap2);
			Matrix matrix2 = new Matrix();
			matrix2.Translate(rectangleF3.X, rectangleF3.Y - (float)(bitmap2.Height - num));
			textureBrush2.Transform = matrix2;
			return textureBrush2;
		}
		RectangleF rectangleF4 = Class1181.smethod_1(graphicsPath_0);
		Bitmap bitmap3 = new Bitmap((int)rectangleF4.Width, (int)((double)((float)image_0.Height * rectangleF4.Width / (float)image_0.Width) / double_8));
		Graphics graphics3 = Graphics.FromImage(bitmap3);
		RectangleF destRect3 = new RectangleF(0f, 0f, bitmap3.Width, bitmap3.Height);
		RectangleF srcRect3 = new RectangleF(0f, 0f, image_0.Width, image_0.Height);
		graphics3.DrawImage(image_0, destRect3, srcRect3, GraphicsUnit.Pixel);
		int num2 = (int)rectangleF4.Height % bitmap3.Height;
		TextureBrush textureBrush3 = new TextureBrush(bitmap3);
		Matrix matrix3 = new Matrix();
		matrix3.Translate(rectangleF4.X, rectangleF4.Y - (float)(bitmap3.Height - num2));
		textureBrush3.Transform = matrix3;
		return textureBrush3;
	}
}
