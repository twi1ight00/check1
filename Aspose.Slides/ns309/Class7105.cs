using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using ns311;

namespace ns309;

internal class Class7105 : Interface376
{
	private Class7117 class7117_0;

	private Class7104 class7104_0;

	private GraphicsPath[] graphicsPath_0;

	private GraphicsPath[] graphicsPath_1;

	private bool[] bool_0;

	private Class7112[] class7112_0;

	private GraphicsPath graphicsPath_2;

	private RectangleF rectangleF_0;

	private RectangleF rectangleF_1;

	private RectangleF rectangleF_2;

	private float float_0;

	private float float_1;

	private float float_2;

	private Class7118 class7118_0;

	private static readonly bool bool_1;

	private Class7127 class7127_0;

	private PointF[] pointF_0;

	private PointF[] pointF_1;

	private Matrix[] matrix_0;

	private GraphicsPath[] graphicsPath_3;

	public virtual Interface375 Font => class7104_0;

	public virtual Class7102 RenderContext => class7117_0.RenderContext;

	public virtual int GlyphsLength => class7117_0.GlyphsLength;

	public virtual GraphicsPath Outline
	{
		get
		{
			if (graphicsPath_2 != null)
			{
				return graphicsPath_2;
			}
			graphicsPath_2 = new GraphicsPath();
			for (int i = 0; i < GlyphsLength; i++)
			{
				if (bool_0[i])
				{
					GraphicsPath addingPath = imethod_1(i);
					graphicsPath_2.AddPath(addingPath, connect: false);
				}
			}
			return graphicsPath_2;
		}
	}

	public virtual RectangleF GeometricBounds
	{
		get
		{
			if (rectangleF_0.IsEmpty)
			{
				GraphicsPath graphicsPath = new GraphicsPath();
				rectangleF_0 = graphicsPath.GetBounds();
			}
			return rectangleF_0;
		}
	}

	public virtual RectangleF ActualBounds
	{
		get
		{
			if (rectangleF_1.IsEmpty)
			{
				method_0();
			}
			return rectangleF_1;
		}
	}

	public Class7105(Class7117 vector, Class7104 font, float scale, Class7127 iterator)
	{
		class7117_0 = vector;
		class7104_0 = font;
		float_0 = scale;
		class7127_0 = iterator;
		Class7103 @class = new Class7103();
		float_1 = @class.Top;
		float_2 = @class.Bottom;
		graphicsPath_2 = null;
		int glyphsLength = vector.GlyphsLength;
		pointF_1 = new PointF[glyphsLength + 1];
		matrix_0 = new Matrix[glyphsLength];
		graphicsPath_0 = new GraphicsPath[glyphsLength];
		graphicsPath_1 = new GraphicsPath[glyphsLength];
		graphicsPath_3 = new GraphicsPath[glyphsLength];
		bool_0 = new bool[glyphsLength];
		class7112_0 = new Class7112[glyphsLength];
		rectangleF_0 = default(RectangleF);
		rectangleF_1 = default(RectangleF);
		rectangleF_2 = default(RectangleF);
		for (int i = 0; i < glyphsLength; i++)
		{
			bool_0[i] = true;
		}
		pointF_0 = new PointF[0];
	}

	public virtual int imethod_3(int index)
	{
		return class7117_0.imethod_3(index);
	}

	public virtual int[] imethod_4(int index, int length, int[] result)
	{
		return class7117_0.imethod_4(index, length, result);
	}

	public virtual Class7112 vmethod_0(int index)
	{
		if (class7112_0[index] != null)
		{
			return class7112_0[index];
		}
		PointF position = default(PointF);
		if (pointF_0.Length - 1 >= index)
		{
			position = pointF_0[index];
		}
		char charCode = class7127_0.imethod_9(class7127_0.BeginIndex + index);
		class7127_0.Index = class7127_0.BeginIndex;
		Class7104.smethod_0(class7104_0, charCode, class7117_0, index, position);
		RectangleF rectangleF = default(RectangleF);
		RectangleF bounds = new RectangleF(rectangleF.X * float_0, rectangleF.Y * float_0, rectangleF.Width * float_0, rectangleF.Height * float_0);
		float num = 0f;
		if (pointF_0.Length - 1 >= index)
		{
			num = pointF_0[index + 1].X - pointF_0[index].X;
		}
		class7112_0[index] = new Class7112(horizontal: true, num * float_0, float_1 + float_2, bounds, Class7112.byte_1);
		return class7112_0[index];
	}

	public virtual GraphicsPath imethod_1(int index)
	{
		if (graphicsPath_0[index] == null)
		{
			PointF position = default(PointF);
			if (pointF_0.Length - 1 >= index)
			{
				position = pointF_0[index];
			}
			char charCode = class7127_0.imethod_9(class7127_0.BeginIndex + index);
			class7127_0.Index = class7127_0.BeginIndex;
			Class7104.smethod_0(class7104_0, charCode, class7117_0, index, position);
			GraphicsPath graphicsPath = new GraphicsPath();
			Matrix matrix = new Matrix();
			Matrix matrix2 = imethod_7(index);
			if (matrix2 != null)
			{
				matrix = matrix2;
			}
			matrix.Scale(float_0, float_0);
			graphicsPath.Transform(matrix);
			graphicsPath_0[index] = graphicsPath;
		}
		return graphicsPath_0[index];
	}

	static Class7105()
	{
		bool_1 = false;
	}

	internal static bool smethod_0()
	{
		return bool_1;
	}

	public virtual RectangleF imethod_2(int index)
	{
		return imethod_0(index).GetBounds();
	}

	public virtual PointF imethod_5(int index)
	{
		return pointF_1[index];
	}

	public virtual float[] imethod_6(int start, int length, float[] result)
	{
		if (result == null)
		{
			result = new float[length * 2];
		}
		for (int i = start; i < start + length; i++)
		{
			PointF pointF = imethod_5(i);
			result[(i - start) * 2] = pointF.X;
			result[(i - start) * 2 + 1] = pointF.Y;
		}
		return result;
	}

	public virtual Matrix imethod_7(int index)
	{
		return matrix_0[index];
	}

	public virtual GraphicsPath imethod_8(int index)
	{
		if (graphicsPath_1[index] == null)
		{
			PointF position = default(PointF);
			if (pointF_0.Length - 1 >= index)
			{
				position = pointF_0[index];
			}
			char charCode = class7127_0.imethod_9(class7127_0.BeginIndex + index);
			class7127_0.Index = class7127_0.BeginIndex;
			Class7104.smethod_0(class7104_0, charCode, class7117_0, index, position);
			Matrix matrix = new Matrix();
			Matrix matrix2 = imethod_7(index);
			if (matrix2 != null)
			{
				matrix = matrix2;
			}
			matrix.Scale(float_0, float_0);
			if (graphicsPath_1[index] != null)
			{
				graphicsPath_1[index].Transform(matrix);
			}
		}
		return graphicsPath_1[index];
	}

	public virtual GraphicsPath imethod_13(float x, float y)
	{
		GraphicsPath outline = Outline;
		Matrix matrix = new Matrix();
		matrix.Translate(x, y);
		outline.Transform(matrix);
		return outline;
	}

	public virtual void imethod_9(int index, PointF positon)
	{
		pointF_1[index].X = positon.X;
		pointF_1[index].Y = positon.Y;
		graphicsPath_2 = new GraphicsPath();
		rectangleF_0 = default(RectangleF);
		rectangleF_1 = default(RectangleF);
		rectangleF_2 = default(RectangleF);
		if (index != GlyphsLength)
		{
			graphicsPath_1[index] = null;
			graphicsPath_3[index] = null;
			graphicsPath_0[index] = null;
			class7112_0[index] = null;
		}
	}

	public virtual void imethod_10(int index, Matrix transformation)
	{
		matrix_0[index] = transformation;
		graphicsPath_2 = new GraphicsPath();
		rectangleF_0 = default(RectangleF);
		graphicsPath_1[index] = null;
		graphicsPath_3[index] = null;
		graphicsPath_0[index] = null;
		class7112_0[index] = null;
		rectangleF_1 = default(RectangleF);
		rectangleF_2 = default(RectangleF);
	}

	public virtual void imethod_11(int index, bool visible)
	{
		if (visible != bool_0[index])
		{
			bool_0[index] = visible;
			graphicsPath_2 = new GraphicsPath();
			rectangleF_0 = default(RectangleF);
			graphicsPath_1[index] = null;
			graphicsPath_3[index] = null;
			graphicsPath_0[index] = null;
			class7112_0[index] = null;
			rectangleF_1 = default(RectangleF);
			rectangleF_2 = default(RectangleF);
		}
	}

	private void method_0()
	{
		GraphicsPath[] array = new GraphicsPath[GlyphsLength];
		bool[] array2 = new bool[GlyphsLength];
		float num = -1f;
		float num2 = -1f;
		for (int i = 0; i < GlyphsLength; i++)
		{
			if (!bool_0[i])
			{
				array[i] = null;
				continue;
			}
			Matrix matrix = imethod_7(i);
			Class7112 @class = vmethod_0(i);
			float x = 0f;
			float y = (0f - float_1) / float_0;
			float width = @class.float_0 / float_0;
			float height = @class.float_1 / float_0;
			RectangleF rectangleF = new RectangleF(x, y, width, height);
			if (rectangleF.Width <= 0f && rectangleF.Height <= 0f)
			{
				if (i > 0)
				{
					array2[i] = array2[i - 1];
				}
				else
				{
					array2[i] = true;
				}
				continue;
			}
			PointF pointF = new PointF(rectangleF.X, rectangleF.Y);
			PointF pointF2 = new PointF(rectangleF.Width, rectangleF.Y);
			PointF pointF3 = new PointF(rectangleF.X, rectangleF.Height);
			imethod_5(i);
			Matrix matrix2 = new Matrix();
			if (matrix != null)
			{
				matrix2 = matrix;
			}
			matrix2.Scale(float_0, float_0);
			array[i].Transform(matrix2);
			PointF pointF4 = default(PointF);
			PointF pointF5 = default(PointF);
			PointF pointF6 = default(PointF);
			matrix2.TransformPoints(new PointF[2] { pointF, pointF4 });
			matrix2.TransformPoints(new PointF[2] { pointF2, pointF5 });
			matrix2.TransformPoints(new PointF[2] { pointF3, pointF6 });
			float value = pointF4.X - pointF5.X;
			float value2 = pointF4.X - pointF6.X;
			float value3 = pointF4.Y - pointF5.Y;
			float value4 = pointF4.Y - pointF6.Y;
			if (((double)Math.Abs(value) < 0.001 && (double)Math.Abs(value4) < 0.001) || ((double)Math.Abs(value2) < 0.001 && (double)Math.Abs(value3) < 0.001))
			{
				array2[i] = false;
			}
			else
			{
				array2[i] = true;
			}
			RectangleF bounds = array[i].GetBounds();
			if (bounds.Width > num)
			{
				num = bounds.Width;
			}
			if (bounds.Height > num2)
			{
				num2 = bounds.Height;
			}
		}
		GraphicsPath graphicsPath = new GraphicsPath();
		for (int j = 0; j < GlyphsLength; j++)
		{
			if (array[j] != null)
			{
				graphicsPath.AddPath(array[j], connect: false);
			}
		}
		rectangleF_1 = graphicsPath.GetBounds();
		if ((double)rectangleF_1.Height < (double)num2 * 1.5)
		{
			for (int k = 0; k < GlyphsLength; k++)
			{
				if (array2[k] || array[k] == null)
				{
					continue;
				}
				RectangleF bounds2 = array[k].GetBounds();
				float x2 = bounds2.X;
				float num3 = bounds2.Width;
				if (k < GlyphsLength - 1 && array[k + 1] != null)
				{
					RectangleF bounds3 = array[k + 1].GetBounds();
					if (bounds3.X > x2)
					{
						float num4 = bounds3.X - x2;
						if ((double)num4 < (double)num3 * 1.15 && (double)num4 > (double)num3 * 0.85)
						{
							float num5 = (num4 - num3) * 0.5f;
							num3 += num5;
							bounds3.X -= num5;
							bounds3.Width += num5;
						}
					}
				}
				array[k].AddRectangle(new RectangleF(x2, rectangleF_1.Y, num3, rectangleF_1.Height));
			}
		}
		else if ((double)rectangleF_1.Width < (double)num * 1.5)
		{
			for (int l = 0; l < GlyphsLength; l++)
			{
				if (array2[l] || array[l] == null)
				{
					continue;
				}
				RectangleF bounds4 = array[l].GetBounds();
				float y2 = bounds4.Y;
				float num6 = bounds4.Height;
				if (l < GlyphsLength - 1 && array[l + 1] != null)
				{
					RectangleF bounds5 = array[l + 1].GetBounds();
					if (bounds5.Y > y2)
					{
						float num7 = bounds5.Y - y2;
						if ((double)num7 < (double)num6 * 1.15 && (double)num7 > (double)num6 * 0.85)
						{
							float num8 = (num7 - num6) * 0.5f;
							num6 += num8;
							bounds5.Y -= num8;
							bounds5.Height += num8;
						}
					}
				}
				array[l].AddRectangle(new RectangleF(rectangleF_1.X, y2, rectangleF_1.Width, num6));
			}
		}
		Array.Copy(array, 0, graphicsPath_3, 0, GlyphsLength);
	}

	public virtual bool imethod_12(int index)
	{
		return bool_0[index];
	}

	public virtual RectangleF imethod_14(Class7127 iterator)
	{
		iterator.imethod_8();
		Class7118 @class = (Class7118)iterator.vmethod_1("PAINT_INFO");
		if (Class7118.smethod_0(@class, class7118_0))
		{
			return rectangleF_2;
		}
		if (@class == null)
		{
			return default(RectangleF);
		}
		if (!@class.bool_0)
		{
			return default(RectangleF);
		}
		class7118_0 = new Class7118(@class);
		GraphicsPath graphicsPath = null;
		if (@class.string_3 != null)
		{
			graphicsPath = graphicsPath_2;
			rectangleF_2 = graphicsPath.GetBounds();
		}
		string string_ = @class.string_5;
		string string_2 = @class.string_4;
		if (string_ != null && string_2 != null && graphicsPath == null)
		{
			graphicsPath = graphicsPath_2;
		}
		if (rectangleF_2.IsEmpty)
		{
			return default(RectangleF);
		}
		if (rectangleF_2.Width == 0f || rectangleF_2.Height == 0f)
		{
			rectangleF_2 = default(RectangleF);
		}
		return rectangleF_2;
	}

	public virtual GraphicsPath imethod_0(int index)
	{
		if (graphicsPath_3[index] == null && bool_0[index])
		{
			method_0();
		}
		if (graphicsPath_3[index] != null)
		{
			return graphicsPath_3[index];
		}
		return new GraphicsPath();
	}
}
