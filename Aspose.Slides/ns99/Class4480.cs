using ns121;
using ns137;
using ns138;
using ns146;

namespace ns99;

internal class Class4480
{
	internal class Class4482
	{
		private byte[] byte_0;

		private Class4651 class4651_0;

		private Class4506 class4506_0;

		public static Class4482 class4482_0 = new Class4482(null, Class4508.class4508_0, null);

		public Class4651 TTFParserContext => class4651_0;

		public Class4506 GlyphID => class4506_0;

		public byte[] RawGlyphBytes => byte_0;

		public Class4482(Class4651 context, Class4506 glyphId, byte[] rawGlyphBytes)
		{
			byte_0 = rawGlyphBytes;
			class4651_0 = context;
			class4506_0 = glyphId;
		}
	}

	internal Class4618 class4618_0;

	private double double_0 = double.MinValue;

	private double double_1 = double.MinValue;

	private double double_2;

	private double double_3;

	private int int_0;

	private Class4518 class4518_0;

	private object object_0 = new object();

	private object object_1 = new object();

	private object object_2 = new object();

	private Class4610 class4610_0;

	private Class4482 class4482_0 = Class4482.class4482_0;

	internal Class4615 class4615_0;

	private bool bool_0;

	private object object_3 = new object();

	private Enum642 enum642_0;

	internal virtual Class4615 PathDefinition
	{
		get
		{
			return class4615_0;
		}
		set
		{
			class4615_0 = value;
			bool_0 = false;
		}
	}

	internal Class4482 InitialData
	{
		get
		{
			return class4482_0;
		}
		set
		{
			class4482_0 = value;
		}
	}

	public Enum642 State
	{
		get
		{
			return enum642_0;
		}
		set
		{
			enum642_0 = value;
		}
	}

	public bool IsEmpty => Path.Segments.Count == 0;

	public virtual Class4618 Path
	{
		get
		{
			if (PathDefinition != null && !bool_0)
			{
				lock (object_3)
				{
					if (!bool_0)
					{
						class4618_0 = class4615_0.vmethod_0();
						bool_0 = true;
					}
				}
			}
			return class4618_0;
		}
	}

	public double LeftSidebearingX
	{
		get
		{
			if (double_0 == double.MinValue)
			{
				lock (object_1)
				{
					if (double_0 == double.MinValue)
					{
						double_0 = GlyphBBox.double_0;
					}
				}
			}
			return double_0;
		}
		set
		{
			double_0 = value;
		}
	}

	public double LeftSidebearingY
	{
		get
		{
			if (double_1 == double.MinValue)
			{
				lock (object_2)
				{
					if (double_1 == double.MinValue)
					{
						double_1 = GlyphBBox.double_3;
					}
				}
			}
			return double_1;
		}
		set
		{
			double_1 = value;
		}
	}

	public double WidthVectorX
	{
		get
		{
			return double_2;
		}
		set
		{
			double_2 = value;
		}
	}

	public double WidthVectorY
	{
		get
		{
			return double_3;
		}
		set
		{
			double_3 = value;
		}
	}

	public int SourceResolution
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

	public Class4518 GlyphBBox
	{
		get
		{
			if (class4518_0 == null)
			{
				lock (object_0)
				{
					if (class4518_0 == null)
					{
						class4518_0 = new Class4518();
						method_0(class4518_0);
					}
				}
			}
			return class4518_0;
		}
		set
		{
			class4518_0 = value;
		}
	}

	internal Class4610 HintCollections => class4610_0;

	public Class4480()
	{
		State = Enum642.const_0;
		class4610_0 = new Class4610();
		class4618_0 = new Class4618();
	}

	internal void method_0(Class4518 bbox)
	{
		if (bbox == null)
		{
			return;
		}
		double num;
		double num2;
		double num3;
		double num4;
		if (Path.Segments.Count == 0)
		{
			num = 0.0;
			num2 = 0.0;
			num3 = 0.0;
			num4 = 0.0;
		}
		else
		{
			num3 = double.MinValue;
			num4 = double.MinValue;
			num = double.MaxValue;
			num2 = double.MaxValue;
			foreach (Interface143 segment in Path.Segments)
			{
				double num5 = -2147483648.0;
				double num6 = -2147483648.0;
				if (segment is Class4614 @class)
				{
					num5 = @class.X;
					num6 = @class.Y;
				}
				else if (segment is Class4613 class2)
				{
					num5 = class2.X;
					num6 = class2.Y;
				}
				else if (segment is Class4612 class3)
				{
					num5 = class3.X3;
					num6 = class3.Y3;
				}
				if (num5 != -2147483648.0 && num6 != -2147483648.0)
				{
					if (num5 < num)
					{
						num = num5;
					}
					if (num5 > num3)
					{
						num3 = num5;
					}
					if (num6 < num2)
					{
						num2 = num6;
					}
					if (num6 > num4)
					{
						num4 = num6;
					}
				}
			}
		}
		bbox.double_0 = num;
		bbox.double_2 = num3;
		bbox.double_1 = num2;
		bbox.double_3 = num4;
	}

	public void method_1(double dx, double dy)
	{
		foreach (Interface143 segment in Path.Segments)
		{
			if (segment is Class4614 @class)
			{
				@class.X += dx;
				@class.Y += dy;
			}
			else if (segment is Class4613 class2)
			{
				class2.X += dx;
				class2.Y += dy;
			}
			else if (segment is Class4612 class3)
			{
				class3.X1 += dx;
				class3.Y1 += dy;
				class3.X2 += dx;
				class3.Y2 += dy;
				class3.X3 += dx;
				class3.Y3 += dy;
			}
			else if (segment is Class4611 class4)
			{
				class4.X += dx;
				class4.Y += dy;
			}
		}
	}

	public void method_2(Class4509 matrix)
	{
		foreach (Interface143 segment in Path.Segments)
		{
			double outX;
			double outY;
			if (segment is Class4614 @class)
			{
				smethod_0(@class.X, @class.Y, matrix, out outX, out outY);
				@class.X = outX;
				@class.Y = outY;
			}
			else if (segment is Class4613 class2)
			{
				smethod_0(class2.X, class2.Y, matrix, out outX, out outY);
				class2.X = outX;
				class2.Y = outY;
			}
			else if (segment is Class4612 class3)
			{
				smethod_0(class3.X1, class3.Y1, matrix, out outX, out outY);
				class3.X1 = outX;
				class3.Y1 = outY;
				smethod_0(class3.X2, class3.Y2, matrix, out outX, out outY);
				class3.X2 = outX;
				class3.Y2 = outY;
				smethod_0(class3.X3, class3.Y3, matrix, out outX, out outY);
				class3.X3 = outX;
				class3.Y3 = outY;
			}
			else if (segment is Class4611 class4)
			{
				smethod_0(class4.X, class4.Y, matrix, out outX, out outY);
				class4.X = outX;
				class4.Y = outY;
			}
		}
	}

	private static void smethod_0(double x, double y, Class4509 finalMatrix, out double outX, out double outY)
	{
		outX = x * finalMatrix.A + y * finalMatrix.B;
		outY = x * finalMatrix.C + y * finalMatrix.D;
	}
}
