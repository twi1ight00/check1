using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using ns311;

namespace ns309;

internal class Class7117 : Interface376
{
	private bool[] bool_0;

	private PointF pointF_0;

	private Class7118 class7118_0;

	private Interface375 interface375_0;

	private Class7106[] class7106_0;

	private Class7102 class7102_0;

	private GraphicsPath graphicsPath_0;

	private RectangleF rectangleF_0;

	private RectangleF rectangleF_1;

	private GraphicsPath[] graphicsPath_1;

	public Interface375 Font => interface375_0;

	public Class7102 RenderContext => class7102_0;

	public RectangleF ActualBounds
	{
		get
		{
			if (rectangleF_0.IsEmpty)
			{
				GraphicsPath graphicsPath = new GraphicsPath();
				for (int i = 0; i < GlyphsLength; i++)
				{
					imethod_0(i);
				}
				rectangleF_0 = graphicsPath.GetBounds();
			}
			return rectangleF_0;
		}
	}

	public int GlyphsLength
	{
		get
		{
			if (class7106_0 != null)
			{
				return class7106_0.Length;
			}
			return 0;
		}
	}

	public GraphicsPath Outline
	{
		get
		{
			if (graphicsPath_0 == null)
			{
				graphicsPath_0 = new GraphicsPath();
				for (int i = 0; i < class7106_0.Length; i++)
				{
					if (bool_0[i])
					{
						GraphicsPath graphicsPath = class7106_0[i].graphicsPath_0;
						if (graphicsPath != null)
						{
							graphicsPath_0.AddPath(graphicsPath, connect: false);
						}
					}
				}
			}
			return graphicsPath_0;
		}
	}

	public RectangleF GeometricBounds => Outline.GetBounds();

	public Class7117(Interface375 font, Class7106[] glyphs, Class7102 context)
	{
		interface375_0 = font;
		class7106_0 = glyphs;
		class7102_0 = context;
		graphicsPath_0 = new GraphicsPath();
		rectangleF_1 = default(RectangleF);
		rectangleF_0 = default(RectangleF);
		graphicsPath_1 = new GraphicsPath[glyphs.Length];
		bool_0 = new bool[glyphs.Length];
		for (int i = 0; i < glyphs.Length; i++)
		{
			bool_0[i] = true;
		}
		if (glyphs.Length > 0)
		{
			pointF_0 = glyphs[glyphs.Length - 1].Position;
			pointF_0 = new PointF(pointF_0.X + glyphs[glyphs.Length - 1].HorizontalLevel.X, pointF_0.Y);
		}
	}

	public int imethod_3(int glyphIndex)
	{
		if (glyphIndex >= 0 && glyphIndex <= class7106_0.Length - 1)
		{
			return class7106_0[glyphIndex].GlyphCode;
		}
		return -1;
	}

	public int[] imethod_4(int start, int length, int[] result)
	{
		if (length < 0)
		{
			return new int[0];
		}
		if (start < 0)
		{
			return new int[0];
		}
		if (start + length > class7106_0.Length)
		{
			return new int[0];
		}
		if (result == null)
		{
			result = new int[length];
		}
		for (int i = start; i < start + length; i++)
		{
			result[i - start] = class7106_0[i].GlyphCode;
		}
		return result;
	}

	public GraphicsPath imethod_0(int index)
	{
		if (graphicsPath_1[index] == null && bool_0[index])
		{
			method_0();
		}
		if (graphicsPath_1[index] != null)
		{
			return graphicsPath_1[index];
		}
		return new GraphicsPath();
	}

	public Matrix imethod_7(int index)
	{
		if (index >= 0 && index <= class7106_0.Length - 1)
		{
			return class7106_0[index].matrix_0;
		}
		return new Matrix();
	}

	public GraphicsPath imethod_8(int index)
	{
		if (index >= 0 && index <= class7106_0.Length - 1)
		{
			return class7106_0[index].graphicsPath_0;
		}
		return new GraphicsPath();
	}

	public RectangleF imethod_14(Class7127 iterator)
	{
		iterator.imethod_8();
		Class7118 @class = (Class7118)iterator.vmethod_1("PAINT_INFO");
		if (Class7118.smethod_0(@class, class7118_0))
		{
			return rectangleF_1;
		}
		if (@class.bool_0)
		{
			for (int i = 0; i < GlyphsLength; i++)
			{
				if (bool_0[i])
				{
					RectangleF rectangleF = class7106_0[i].rectangleF_0;
					_ = rectangleF.IsEmpty;
				}
			}
		}
		if (rectangleF_1.IsEmpty)
		{
			rectangleF_1 = default(RectangleF);
		}
		class7118_0 = new Class7118(@class);
		return rectangleF_1;
	}

	private void method_0()
	{
		float num = 0f;
		float num2 = 0f;
		if (interface375_0 != null)
		{
			Class7103 @class = new Class7103();
			num = @class.Top;
			num2 = @class.Bottom;
			if (num2 < 0f)
			{
				num2 = 0f - num2;
			}
		}
		if (num == 0f)
		{
			float num3 = 0f;
			float num4 = 0f;
			for (int i = 0; i < GlyphsLength; i++)
			{
				if (!bool_0[i])
				{
					continue;
				}
				Class7114 class2 = method_1(i);
				if (class2 != null)
				{
					RectangleF bounds = class2.Bounds;
					num = 0f - bounds.Y;
					num2 = bounds.Height - num;
					if (num > num3)
					{
						num3 = num;
					}
					if (num2 > num4)
					{
						num4 = num2;
					}
				}
			}
			num = num3;
			num2 = num4;
		}
		GraphicsPath[] array = new GraphicsPath[GlyphsLength];
		bool[] array2 = new bool[GlyphsLength];
		float num5 = -1f;
		float num6 = -1f;
		for (int j = 0; j < GlyphsLength; j++)
		{
			if (!bool_0[j])
			{
				array[j] = null;
				continue;
			}
			imethod_7(j);
			Class7114 class3 = method_1(j);
			RectangleF rectangleF = new RectangleF(0f, 0f - num, class3.HorizontalLevel, num + num2);
			if (rectangleF.Y <= 0f && rectangleF.X <= 0f)
			{
				if (j > 0)
				{
					array2[j] = array2[j - 1];
				}
				else
				{
					array2[j] = true;
				}
			}
		}
		GraphicsPath graphicsPath = new GraphicsPath();
		for (int k = 0; k < GlyphsLength; k++)
		{
			if (array[k] != null)
			{
				graphicsPath.AddRectangle(array[k].GetBounds());
			}
		}
		RectangleF bounds2 = graphicsPath.GetBounds();
		if ((double)bounds2.Height < (double)num6 * 1.5)
		{
			for (int l = 0; l < GlyphsLength; l++)
			{
				if (array2[l] || array[l] == null)
				{
					continue;
				}
				RectangleF bounds3 = array[l].GetBounds();
				float x = bounds3.X;
				float num7 = bounds3.Width;
				if (l < GlyphsLength - 1 && array[l + 1] != null)
				{
					RectangleF bounds4 = array[l + 1].GetBounds();
					if (bounds4.X > x)
					{
						float num8 = bounds4.X - x;
						if ((double)num8 < (double)num7 * 1.15 && (double)num8 > (double)num7 * 0.85)
						{
							float num9 = (num8 - num7) * 0.5f;
							num7 += num9;
							bounds4.X -= num9;
							bounds4.Y = bounds4.Y;
							bounds4.Width += num9;
							bounds4.Height = bounds4.Height;
						}
					}
				}
				array[l].AddRectangle(new RectangleF(x, bounds2.Y, num7, bounds2.Height));
			}
		}
		else if ((double)bounds2.Width < (double)num5 * 1.5)
		{
			for (int m = 0; m < GlyphsLength; m++)
			{
				if (array2[m] || array[m] == null)
				{
					continue;
				}
				RectangleF bounds5 = array[m].GetBounds();
				float y = bounds5.Y;
				float num10 = bounds5.Height;
				if (m < GlyphsLength - 1 && array[m + 1] != null)
				{
					RectangleF bounds6 = array[m + 1].GetBounds();
					if (bounds6.Y > y)
					{
						float num11 = bounds6.Y - y;
						if ((double)num11 < (double)num10 * 1.15 && (double)num11 > (double)num10 * 0.85)
						{
							float num12 = (num11 - num10) * 0.5f;
							num10 += num12;
							bounds6.X = bounds6.X;
							bounds6.Y -= num12;
							bounds6.Width = bounds6.Width;
							bounds6.Height += num12;
						}
					}
				}
				array[m].AddRectangle(new RectangleF(bounds2.X, y, bounds2.Width, num10));
			}
		}
		Array.Copy(array, 0, graphicsPath_1, 0, GlyphsLength);
	}

	public Class7114 method_1(int glyphIndex)
	{
		if (glyphIndex >= 0 && glyphIndex <= class7106_0.Length - 1)
		{
			if (glyphIndex < class7106_0.Length - 1 && interface375_0 != null)
			{
				float hkern = interface375_0.imethod_2(class7106_0[glyphIndex].GlyphCode, class7106_0[glyphIndex + 1].GlyphCode);
				float vkern = interface375_0.imethod_1(class7106_0[glyphIndex].GlyphCode, class7106_0[glyphIndex + 1].GlyphCode);
				return class7106_0[glyphIndex].method_0(hkern, vkern);
			}
			return class7106_0[glyphIndex].class7114_0;
		}
		return new Class7114();
	}

	public GraphicsPath imethod_1(int index)
	{
		if (index >= 0 && index <= class7106_0.Length - 1)
		{
			return class7106_0[index].graphicsPath_0;
		}
		return new GraphicsPath();
	}

	public RectangleF imethod_2(int index)
	{
		return imethod_0(index).GetBounds();
	}

	public PointF imethod_5(int index)
	{
		if (index == class7106_0.Length)
		{
			return pointF_0;
		}
		if (index >= 0 && index <= class7106_0.Length - 1)
		{
			return class7106_0[index].Position;
		}
		return default(PointF);
	}

	public float[] imethod_6(int start, int length, float[] result)
	{
		if (length >= 0 && start >= 0 && start + length <= class7106_0.Length + 1)
		{
			if (result == null)
			{
				result = new float[length * 2];
			}
			if (start + length == class7106_0.Length + 1)
			{
				length--;
				result[length * 2] = pointF_0.X;
				result[length * 2 + 1] = pointF_0.Y;
			}
			for (int i = start; i < start + length; i++)
			{
				PointF position = class7106_0[i].Position;
				result[(i - start) * 2] = position.X;
				result[(i - start) * 2 + 1] = position.Y;
			}
			return result;
		}
		return new float[0];
	}

	public GraphicsPath imethod_13(float x, float y)
	{
		Matrix matrix = new Matrix();
		matrix.Translate(x, y);
		GraphicsPath graphicsPath = graphicsPath_0;
		graphicsPath.Transform(matrix);
		return graphicsPath;
	}

	public void imethod_11(int index, bool visible)
	{
		if (visible != bool_0[index])
		{
			graphicsPath_0 = new GraphicsPath();
			rectangleF_1 = default(RectangleF);
			rectangleF_0 = default(RectangleF);
			bool_0[index] = visible;
			graphicsPath_1[index] = null;
		}
	}

	public bool imethod_12(int index)
	{
		return bool_0[index];
	}

	public int method_2(int start, int end)
	{
		int num = 0;
		if (start < 0)
		{
			start = 0;
		}
		if (end > class7106_0.Length - 1)
		{
			end = class7106_0.Length - 1;
		}
		for (int i = start; i <= end; i++)
		{
			Class7106 @class = class7106_0[i];
			if (@class.GlyphCode == -1)
			{
				num++;
				continue;
			}
			string unicode = @class.Unicode;
			num += unicode.Length;
		}
		return num;
	}

	public void imethod_9(int index, PointF position)
	{
		if (index == class7106_0.Length)
		{
			pointF_0 = position;
		}
		else if (index >= 0 && index <= class7106_0.Length - 1)
		{
			graphicsPath_0 = new GraphicsPath();
			rectangleF_1 = default(RectangleF);
			class7106_0[index].Position = position;
			graphicsPath_1[index] = null;
			rectangleF_0 = default(RectangleF);
		}
	}

	public void imethod_10(int index, Matrix transfromMatrix)
	{
		if (index >= 0 && index <= class7106_0.Length - 1)
		{
			graphicsPath_0 = new GraphicsPath();
			rectangleF_1 = default(RectangleF);
			rectangleF_0 = default(RectangleF);
			class7106_0[index].matrix_0 = transfromMatrix;
			graphicsPath_1[index] = null;
		}
	}
}
