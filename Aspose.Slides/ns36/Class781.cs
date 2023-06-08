using System.Drawing;
using System.Drawing.Drawing2D;
using ns40;

namespace ns36;

internal class Class781 : Interface31
{
	private Image image_0;

	private int int_0;

	private bool bool_0;

	private double double_0;

	private double double_1;

	private double double_2;

	private double double_3;

	private Enum158 enum158_0;

	private Enum159 enum159_0;

	private Enum151 enum151_0;

	private double double_4;

	private double double_5;

	private double double_6;

	private double double_7;

	private double double_8;

	public Image Image
	{
		get
		{
			return image_0;
		}
		set
		{
			image_0 = value;
		}
	}

	public int Transparency
	{
		get
		{
			return int_0;
		}
		set
		{
			int_0 = value;
		}
	}

	public bool IsTiling
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

	public double OffsetX
	{
		get
		{
			return double_0;
		}
		set
		{
			double_0 = method_0(value, -2112.0, 2112.0);
		}
	}

	public double OffsetY
	{
		get
		{
			return double_1;
		}
		set
		{
			double_1 = method_0(value, -2112.0, 2112.0);
		}
	}

	public double ScaleX
	{
		get
		{
			return double_2;
		}
		set
		{
			double_2 = method_0(value, 0.0, 100.0);
		}
	}

	public double ScaleY
	{
		get
		{
			return double_3;
		}
		set
		{
			double_3 = method_0(value, 0.0, 100.0);
		}
	}

	public Enum158 Alignment
	{
		get
		{
			return enum158_0;
		}
		set
		{
			enum158_0 = value;
		}
	}

	public Enum159 MirrorType
	{
		get
		{
			return enum159_0;
		}
		set
		{
			enum159_0 = value;
		}
	}

	public Enum151 FillPictrueType
	{
		get
		{
			return enum151_0;
		}
		set
		{
			enum151_0 = value;
		}
	}

	public double OffsetsLeft
	{
		get
		{
			return double_4;
		}
		set
		{
			double_4 = method_0(value, -100.0, 100.0);
		}
	}

	public double OffsetsRight
	{
		get
		{
			return double_5;
		}
		set
		{
			double_5 = method_0(value, -100.0, 100.0);
		}
	}

	public double OffsetsTop
	{
		get
		{
			return double_6;
		}
		set
		{
			double_6 = method_0(value, -100.0, 100.0);
		}
	}

	public double OffsetsBottom
	{
		get
		{
			return double_7;
		}
		set
		{
			double_7 = method_0(value, -100.0, 100.0);
		}
	}

	public double StackAndScaleWithValue
	{
		get
		{
			return double_8;
		}
		set
		{
			if (value < 0.0)
			{
				double_8 = 0.0;
			}
			if (value > 1000000000.0)
			{
				double_8 = 1000000000.0;
			}
			double_8 = value;
		}
	}

	public Class781()
	{
		int_0 = 0;
		bool_0 = false;
		enum158_0 = Enum158.const_7;
		enum159_0 = Enum159.const_0;
		enum151_0 = Enum151.const_0;
		double_8 = 1.0;
	}

	private double method_0(double val, double minCritical, double maxCritical)
	{
		if (val < minCritical)
		{
			return minCritical;
		}
		if (val > maxCritical)
		{
			return maxCritical;
		}
		return val;
	}

	public bool method_1(Class781 other)
	{
		if (other == null)
		{
			return false;
		}
		if (image_0 != null && other.image_0 != null && image_0.Size != other.image_0.Size)
		{
			return false;
		}
		if (int_0 != other.Transparency)
		{
			return false;
		}
		if (bool_0 != other.IsTiling)
		{
			return false;
		}
		if (bool_0)
		{
			if (double_0 != other.OffsetX || double_2 != other.ScaleX)
			{
				return false;
			}
			if (double_1 != other.OffsetY || double_3 != other.ScaleY)
			{
				return false;
			}
			if (Alignment != other.Alignment || MirrorType != other.MirrorType)
			{
				return false;
			}
		}
		else
		{
			if (FillPictrueType != other.FillPictrueType)
			{
				return false;
			}
			if (FillPictrueType == Enum151.const_0)
			{
				if (OffsetsLeft != other.OffsetsLeft || double_5 != other.double_5 || OffsetsTop != other.OffsetsTop || OffsetsBottom != other.OffsetsBottom)
				{
					return false;
				}
			}
			else if (FillPictrueType == Enum151.const_2 && StackAndScaleWithValue != other.StackAndScaleWithValue)
			{
				return false;
			}
		}
		return true;
	}

	internal Brush method_2(GraphicsPath path, float colorGene)
	{
		if (int_0 != 0)
		{
		}
		if (bool_0)
		{
			RectangleF rectangleF = Class790.smethod_0(path);
			TextureBrush textureBrush = new TextureBrush(image_0, WrapMode.Tile);
			Matrix matrix = new Matrix();
			matrix.Translate(rectangleF.X, rectangleF.Y);
			textureBrush.Transform = matrix;
			return textureBrush;
		}
		if (enum151_0 == Enum151.const_0)
		{
			RectangleF rectangleF2 = Class790.smethod_0(path);
			Bitmap bitmap = new Bitmap((int)rectangleF2.Width, (int)rectangleF2.Height);
			Graphics graphics = Graphics.FromImage(bitmap);
			graphics.DrawImage(destRect: new RectangleF(0f, 0f, bitmap.Width, bitmap.Height), srcRect: new RectangleF(0f, 0f, image_0.Width, image_0.Height), image: image_0, srcUnit: GraphicsUnit.Pixel);
			TextureBrush textureBrush2 = new TextureBrush(bitmap);
			Matrix matrix2 = new Matrix();
			matrix2.Translate(rectangleF2.X, rectangleF2.Y);
			textureBrush2.Transform = matrix2;
			return textureBrush2;
		}
		if (enum151_0 == Enum151.const_1)
		{
			RectangleF rectangleF3 = Class790.smethod_0(path);
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
		RectangleF rectangleF4 = Class790.smethod_0(path);
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
}
