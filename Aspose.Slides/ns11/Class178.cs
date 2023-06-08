using System.Drawing;
using System.Drawing.Drawing2D;
using System.Xml;

namespace ns11;

internal sealed class Class178
{
	internal enum Enum13
	{
		const_0,
		const_1,
		const_2,
		const_3,
		const_4
	}

	private Enum13 enum13_0;

	private Matrix matrix_0;

	private readonly float float_0;

	private readonly float float_1;

	private readonly float float_2;

	public string Code
	{
		get
		{
			if (IsIdentity)
			{
				return string.Empty;
			}
			return enum13_0 switch
			{
				Enum13.const_1 => $"tt{XmlConvert.ToString(matrix_0.Elements[4])}_{XmlConvert.ToString(matrix_0.Elements[5])}e", 
				Enum13.const_2 => $"ts{XmlConvert.ToString(matrix_0.Elements[0])}_{XmlConvert.ToString(matrix_0.Elements[3])}e", 
				Enum13.const_3 => $"tr{XmlConvert.ToString(float_0)}_{XmlConvert.ToString(float_1)}_{XmlConvert.ToString(float_2)}e", 
				Enum13.const_4 => $"tm{XmlConvert.ToString(matrix_0.Elements[0])}_{XmlConvert.ToString(matrix_0.Elements[1])}_{XmlConvert.ToString(matrix_0.Elements[2])}_{XmlConvert.ToString(matrix_0.Elements[3])}_{XmlConvert.ToString(matrix_0.Elements[4])}_{XmlConvert.ToString(matrix_0.Elements[5])})", 
				_ => string.Empty, 
			};
		}
	}

	public string SvgTransformText
	{
		get
		{
			if (IsIdentity)
			{
				return null;
			}
			switch (enum13_0)
			{
			default:
				return null;
			case Enum13.const_1:
				if (matrix_0.Elements[5] == 0f)
				{
					return $"translate({XmlConvert.ToString(matrix_0.Elements[4])})";
				}
				return $"translate({XmlConvert.ToString(matrix_0.Elements[4])}, {XmlConvert.ToString(matrix_0.Elements[5])})";
			case Enum13.const_2:
				if (matrix_0.Elements[3] == matrix_0.Elements[0])
				{
					return $"scale({XmlConvert.ToString(matrix_0.Elements[0])})";
				}
				return $"scale({XmlConvert.ToString(matrix_0.Elements[0])}, {XmlConvert.ToString(matrix_0.Elements[3])})";
			case Enum13.const_3:
				if (float_2 == 0f)
				{
					if (float_1 == 0f)
					{
						return $"rotate({XmlConvert.ToString(float_0)})";
					}
					return $"rotate({XmlConvert.ToString(float_0)}, {XmlConvert.ToString(float_1)})";
				}
				return $"rotate({XmlConvert.ToString(float_0)}, {XmlConvert.ToString(float_1)}, {XmlConvert.ToString(float_2)})";
			case Enum13.const_4:
				return $"matrix({XmlConvert.ToString(matrix_0.Elements[0])}, {XmlConvert.ToString(matrix_0.Elements[1])}, {XmlConvert.ToString(matrix_0.Elements[2])}, {XmlConvert.ToString(matrix_0.Elements[3])}, {XmlConvert.ToString(matrix_0.Elements[4])}, {XmlConvert.ToString(matrix_0.Elements[5])})";
			}
		}
	}

	public bool IsIdentity
	{
		get
		{
			if (enum13_0 != 0)
			{
				return matrix_0.IsIdentity;
			}
			return true;
		}
	}

	private void method_0(Matrix matr)
	{
		matrix_0 = matr;
		enum13_0 = ((matr != null && !matr.IsIdentity) ? Enum13.const_4 : Enum13.const_0);
	}

	public Class178(Matrix matr, Enum13 transformType)
	{
		method_0(matr);
		enum13_0 = transformType;
	}

	public static Class178 smethod_0()
	{
		return new Class178(Enum13.const_0, null, 0f, 0f, 0f);
	}

	public static Class178 smethod_1(float angle, float x, float y)
	{
		angle %= 360f;
		if (angle < 0f)
		{
			angle += 360f;
		}
		if (angle == 0f)
		{
			return smethod_0();
		}
		Matrix matrix = new Matrix();
		matrix.RotateAt(angle, new PointF(x, y));
		return new Class178(Enum13.const_3, matrix, angle, x, y);
	}

	public static Class178 smethod_2(float x, float y)
	{
		if (x == 0f && y == 0f)
		{
			return smethod_0();
		}
		return new Class178(Enum13.const_1, new Matrix(1f, 0f, 0f, 1f, x, y), 0f, 0f, 0f);
	}

	private Class178(Enum13 transformType, Matrix matr, float angle, float x, float y)
	{
		enum13_0 = transformType;
		matrix_0 = matr;
		float_0 = angle;
		float_1 = x;
		float_2 = y;
	}

	public static string smethod_3(Class178 transform)
	{
		if (transform != null)
		{
			return transform.Code;
		}
		return string.Empty;
	}

	public static string smethod_4(Class178 transform, string format)
	{
		if (transform != null)
		{
			return string.Format(format, transform.Code);
		}
		return string.Empty;
	}

	public static string smethod_5(Class178 transform)
	{
		return transform?.SvgTransformText;
	}
}
