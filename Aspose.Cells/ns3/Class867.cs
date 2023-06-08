using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.CompilerServices;
using ns22;

namespace ns3;

internal class Class867 : IDisposable, Interface40
{
	private Image image_0;

	private int int_0;

	private bool bool_0;

	private double double_0;

	private double double_1;

	private double double_2;

	private double double_3;

	private Enum85 enum85_0;

	private Enum86 enum86_0;

	private Enum70 enum70_0;

	private double double_4;

	private double double_5;

	private double double_6;

	private double double_7;

	private double double_8;

	private bool bool_1;

	public int Transparency
	{
		set
		{
			int_0 = value;
		}
	}

	public double OffsetX
	{
		set
		{
			double_0 = method_0(value, -2112.0, 2112.0);
		}
	}

	public double OffsetY
	{
		set
		{
			double_1 = method_0(value, -2112.0, 2112.0);
		}
	}

	public double ScaleX
	{
		set
		{
			double_2 = method_0(value, 0.0, 100.0);
		}
	}

	public double ScaleY
	{
		set
		{
			double_3 = method_0(value, 0.0, 100.0);
		}
	}

	public Enum86 MirrorType
	{
		set
		{
			enum86_0 = value;
		}
	}

	public Class867()
	{
		int_0 = 0;
		bool_0 = false;
		enum85_0 = Enum85.const_7;
		enum86_0 = Enum86.const_0;
		enum70_0 = Enum70.const_0;
		double_8 = 1.0;
	}

	[SpecialName]
	public void imethod_0(Image image_1)
	{
		image_0 = image_1;
	}

	[SpecialName]
	public void imethod_1(bool bool_2)
	{
		bool_0 = bool_2;
	}

	[SpecialName]
	public void imethod_2(Enum85 enum85_1)
	{
		enum85_0 = enum85_1;
	}

	[SpecialName]
	public void imethod_3(Enum70 enum70_1)
	{
		enum70_0 = enum70_1;
	}

	[SpecialName]
	public void imethod_4(double double_9)
	{
		double_4 = method_0(double_9, -100.0, 100.0);
	}

	[SpecialName]
	public void imethod_5(double double_9)
	{
		double_5 = method_0(double_9, -100.0, 100.0);
	}

	[SpecialName]
	public void imethod_6(double double_9)
	{
		double_6 = method_0(double_9, -100.0, 100.0);
	}

	[SpecialName]
	public void imethod_7(double double_9)
	{
		double_7 = method_0(double_9, -100.0, 100.0);
	}

	private double method_0(double double_9, double double_10, double double_11)
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
	public void imethod_8(double double_9)
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

	internal Brush method_1(GraphicsPath graphicsPath_0, float float_0)
	{
		if (int_0 != 0)
		{
		}
		if (bool_0)
		{
			RectangleF rectangleF = Class1181.smethod_1(graphicsPath_0);
			TextureBrush textureBrush = new TextureBrush(image_0, WrapMode.Tile);
			Matrix matrix = new Matrix();
			matrix.Translate(rectangleF.X, rectangleF.Y);
			textureBrush.Transform = matrix;
			return textureBrush;
		}
		if (enum70_0 == Enum70.const_0)
		{
			RectangleF rectangleF2 = Class1181.smethod_1(graphicsPath_0);
			Bitmap bitmap = new Bitmap((int)rectangleF2.Width, (int)rectangleF2.Height);
			Graphics graphics = Graphics.FromImage(bitmap);
			graphics.DrawImage(destRect: new RectangleF(0f, 0f, bitmap.Width, bitmap.Height), srcRect: new RectangleF(0f, 0f, image_0.Width, image_0.Height), image: image_0, srcUnit: GraphicsUnit.Pixel);
			TextureBrush textureBrush2 = new TextureBrush(bitmap);
			Matrix matrix2 = new Matrix();
			matrix2.Translate(rectangleF2.X, rectangleF2.Y);
			textureBrush2.Transform = matrix2;
			return textureBrush2;
		}
		if (enum70_0 == Enum70.const_1)
		{
			RectangleF rectangleF3 = Class1181.smethod_1(graphicsPath_0);
			Bitmap bitmap2 = new Bitmap((int)rectangleF3.Width, (int)((float)image_0.Height * rectangleF3.Width / (float)image_0.Width));
			Graphics graphics2 = Graphics.FromImage(bitmap2);
			graphics2.DrawImage(destRect: new RectangleF(0f, 0f, bitmap2.Width, bitmap2.Height), srcRect: new RectangleF(0f, 0f, image_0.Width, image_0.Height), image: image_0, srcUnit: GraphicsUnit.Pixel);
			int num = (int)rectangleF3.Height % bitmap2.Height;
			TextureBrush textureBrush3 = new TextureBrush(bitmap2);
			Matrix matrix3 = new Matrix();
			matrix3.Translate(rectangleF3.X, rectangleF3.Y - (float)(bitmap2.Height - num));
			textureBrush3.Transform = matrix3;
			return textureBrush3;
		}
		RectangleF rectangleF4 = Class1181.smethod_1(graphicsPath_0);
		Bitmap bitmap3 = new Bitmap((int)rectangleF4.Width, (int)((double)((float)image_0.Height * rectangleF4.Width / (float)image_0.Width) / double_8));
		Graphics graphics3 = Graphics.FromImage(bitmap3);
		graphics3.DrawImage(destRect: new RectangleF(0f, 0f, bitmap3.Width, bitmap3.Height), srcRect: new RectangleF(0f, 0f, image_0.Width, image_0.Height), image: image_0, srcUnit: GraphicsUnit.Pixel);
		int num2 = (int)rectangleF4.Height % bitmap3.Height;
		TextureBrush textureBrush4 = new TextureBrush(bitmap3);
		Matrix matrix4 = new Matrix();
		matrix4.Translate(rectangleF4.X, rectangleF4.Y - (float)(bitmap3.Height - num2));
		textureBrush4.Transform = matrix4;
		return textureBrush4;
	}

	~Class867()
	{
		Dispose(bool_2: false);
	}

	public void Dispose()
	{
		Dispose(bool_2: true);
		GC.SuppressFinalize(this);
	}

	protected virtual void Dispose(bool bool_2)
	{
		if (!bool_1)
		{
			if (bool_2 && image_0 != null)
			{
				image_0.Dispose();
			}
			bool_1 = true;
		}
	}
}
