using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Drawing2D;
using ns309;

namespace ns311;

internal class Class7130 : Interface380
{
	public const float float_0 = 1E-05f;

	internal float float_1 = 1f;

	internal float float_2 = 1f;

	internal Class7117 class7117_0 = new Class7117(null, new Class7106[0], new Class7102());

	internal float[] float_3;

	internal Class7131 class7131_0;

	internal static Hashtable hashtable_0;

	internal static Hashtable hashtable_1;

	internal int[] int_0;

	internal bool bool_0 = true;

	internal bool bool_1 = true;

	internal PointF pointF_0;

	internal PointF pointF_1;

	internal PointF pointF_2 = default(PointF);

	private bool bool_2;

	private bool bool_3;

	private bool bool_4;

	internal Class7127 class7127_0;

	private static readonly Class7127 class7127_1;

	private static readonly Class7127 class7127_2;

	private static readonly Class7127 class7127_3;

	private static readonly Class7127 class7127_4;

	public static readonly Class7127 class7127_5;

	public static readonly Class7127 class7127_6;

	public static readonly Class7127 class7127_7;

	public static readonly Class7127 class7127_8;

	private static readonly Class7127 class7127_9;

	private static readonly Class7127 class7127_10;

	private static readonly Class7127 class7127_11;

	public static readonly Class7127 class7127_12;

	public static readonly Class7127 class7127_13;

	public static readonly Class7127 class7127_14;

	public static readonly Class7127 class7127_15;

	private static readonly Class7127 class7127_16;

	private static readonly Class7127 class7127_17;

	public virtual Class7117 GlyphPath => class7117_0;

	public virtual PointF Offset
	{
		get
		{
			return pointF_1;
		}
		set
		{
			if (value.X == pointF_1.X && value.Y == pointF_1.Y)
			{
				return;
			}
			if (bool_2 || bool_3)
			{
				float num = value.X - pointF_1.X;
				float num2 = value.Y - pointF_1.Y;
				int glyphsLength = class7117_0.GlyphsLength;
				float[] array = class7117_0.imethod_6(0, glyphsLength + 1, null);
				PointF position = default(PointF);
				for (int i = 0; i <= glyphsLength; i++)
				{
					position.X = array[2 * i] + num;
					position.Y = array[2 * i + 1] + num2;
					class7117_0.imethod_9(i, position);
				}
			}
			pointF_1 = value;
			bool_4 = false;
		}
	}

	public virtual Class7103 GlyphLineMetrics => new Class7103();

	public virtual int GlyphCount
	{
		get
		{
			if (class7117_0 != null)
			{
				return class7117_0.GlyphsLength;
			}
			return 0;
		}
	}

	internal bool IsLeftToRight
	{
		get
		{
			class7127_0.imethod_8();
			int num = 0;
			if (class7127_0.vmethod_1("BIDI_LEVEL") != null)
			{
				num = (int)class7127_0.vmethod_1("BIDI_LEVEL");
			}
			return (num & 1) == 0;
		}
	}

	public virtual PointF Top
	{
		get
		{
			vmethod_0();
			return pointF_0;
		}
	}

	public virtual GraphicsPath Outline
	{
		get
		{
			if (class7117_0 != null)
			{
				return class7117_0.Outline;
			}
			return new GraphicsPath();
		}
	}

	public virtual float[] GlyphLevels
	{
		get
		{
			if (float_3 != null)
			{
				return float_3;
			}
			if (!bool_3)
			{
				vmethod_0();
			}
			int num = 0;
			float_3 = new float[0];
			if (class7117_0 != null)
			{
				num = class7117_0.GlyphsLength;
				float[] array = class7117_0.imethod_6(0, num + 1, null);
				float_3 = new float[num + 1];
				int num2 = 0;
				if (bool_0)
				{
					num2 = 1;
				}
				float num3 = array[num2];
				for (int i = 0; i < num + 1; i++)
				{
					float_3[i] = array[2 * i + num2] - num3;
				}
			}
			return float_3;
		}
	}

	public virtual RectangleF Bounds
	{
		get
		{
			if (class7117_0 != null)
			{
				return class7117_0.imethod_14(class7127_0);
			}
			return default(RectangleF);
		}
	}

	internal virtual int GlyphAngle
	{
		get
		{
			int i = 0;
			class7127_0.imethod_8();
			float num = 0f;
			if (class7127_0.vmethod_1("VERTICAL_ORIENTATION_ANGLE") != null && bool_0)
			{
				num = (int)class7127_0.vmethod_1("VERTICAL_ORIENTATION_ANGLE");
			}
			else if (class7127_0.vmethod_1("HORIZONTAL_ORIENTATION_ANGLE") != null)
			{
				num = (int)class7127_0.vmethod_1("HORIZONTAL_ORIENTATION_ANGLE");
			}
			if (num != 0f)
			{
				i = (int)num;
			}
			if (i != 0 || i != 90 || i != 180 || i != 270)
			{
				for (; i < 0; i += 360)
				{
				}
				while (i >= 360)
				{
					i -= 360;
				}
				i = ((i > 45 && i <= 315) ? ((i > 45 && i <= 135) ? 90 : ((i <= 135 || i > 225) ? 270 : 180)) : 0);
			}
			return i;
		}
	}

	public virtual RectangleF GeometricBounds
	{
		get
		{
			if (class7117_0 != null)
			{
				RectangleF geometricBounds = class7117_0.GeometricBounds;
				RectangleF bounds = imethod_1(1).GetBounds();
				geometricBounds.Inflate(bounds.Width, bounds.Height);
				return geometricBounds;
			}
			return default(RectangleF);
		}
	}

	public virtual PointF TextPathLevel
	{
		get
		{
			if (class7131_0 != null)
			{
				return pointF_2;
			}
			return Top;
		}
	}

	static Class7130()
	{
		hashtable_0 = new Hashtable();
		hashtable_1 = new Hashtable();
		class7127_1 = new Class7127("X");
		class7127_2 = new Class7127("Y");
		class7127_3 = new Class7127("DX");
		class7127_4 = new Class7127("DY");
		class7127_5 = new Class7127("FLOW_LINE_BREAK");
		class7127_6 = new Class7127("VERTICAL_ORIENTATION");
		class7127_7 = new Class7127("VERTICAL_ORIENTATION_ANGLE");
		class7127_8 = new Class7127("HORIZONTAL_ORIENTATION_ANGLE");
		class7127_9 = new Class7127("ROTATION");
		class7127_10 = new Class7127("BASELINE_SHIFT");
		class7127_11 = new Class7127("ORIENTATION_AUTO");
		class7127_12 = new Class7127("GVT_FONT");
		class7127_13 = new Class7127("FLOW_PARAGRAPH");
		class7127_14 = new Class7127("FLOW_EMPTY_PARAGRAPH");
		class7127_15 = new Class7127("LINE_HEIGHT");
		class7127_16 = new Class7127("WRITING_MODE");
		class7127_17 = new Class7127("WRITING_MODE_TTB");
		hashtable_0.Add(hashtable_0.Count, class7127_4);
		hashtable_0.Add(hashtable_0.Count, class7127_9);
		hashtable_0.Add(hashtable_0.Count, class7127_10);
		hashtable_1.Add(hashtable_1.Count, class7127_12);
		hashtable_1.Add(hashtable_1.Count, class7127_15);
		hashtable_0.Add(hashtable_0.Count, class7127_1);
		hashtable_0.Add(hashtable_0.Count, class7127_2);
		hashtable_0.Add(hashtable_0.Count, class7127_3);
	}

	public Class7130(Class7127 iterator, int[] map, PointF space, Class7102 context)
	{
		class7127_0 = iterator;
		pointF_1 = space;
		int_0 = map;
		class7117_0 = null;
		if (class7127_0 != null)
		{
			class7127_0.imethod_8();
		}
		bool_0 = iterator.vmethod_1("WRITING_MODE") == class7127_17;
		if (iterator.vmethod_1("TEXTPATH") != null)
		{
			class7131_0 = (Class7131)iterator.vmethod_1("TEXTPATH");
		}
		else
		{
			class7131_0 = new Class7131(new GraphicsPath());
		}
	}

	public virtual void imethod_2(float xScale, float yScale, bool spacing)
	{
		if (bool_0)
		{
			xScale = 1f;
		}
		else
		{
			yScale = 1f;
		}
		if (xScale != float_1 || yScale != float_2 || spacing != bool_1)
		{
			bool_3 = false;
			float_3 = null;
			bool_4 = false;
			float_1 = xScale;
			float_2 = yScale;
			bool_1 = spacing;
		}
	}

	public virtual Class7114 imethod_0(int index)
	{
		if (class7117_0 != null)
		{
			return class7117_0.method_1(index);
		}
		return new Class7114();
	}

	public virtual int imethod_7(int start, int end)
	{
		if (class7117_0 != null)
		{
			return class7117_0.method_2(start, end);
		}
		return 0;
	}

	public virtual GraphicsPath imethod_1(int decoration)
	{
		return new GraphicsPath();
	}

	public virtual float imethod_4(int index)
	{
		return GlyphAngle;
	}

	public virtual GraphicsPath imethod_5(int start, int end)
	{
		if (start > end)
		{
			int num = start;
			start = end;
			end = num;
		}
		GraphicsPath graphicsPath = null;
		int glyphCount = GlyphCount;
		int num2 = 0;
		for (int i = 0; i < glyphCount; i++)
		{
			int num3 = int_0[num2];
			if (num3 >= start && num3 <= end && class7117_0.imethod_12(i))
			{
				GraphicsPath graphicsPath2 = class7117_0.imethod_0(i);
				if (graphicsPath2 != null && graphicsPath == null)
				{
					graphicsPath = new GraphicsPath();
				}
			}
			num2 += imethod_7(i, i);
			if (num2 >= int_0.Length)
			{
				num2 = int_0.Length - 1;
			}
		}
		return graphicsPath;
	}

	public static bool smethod_0(float pointFirst, float pointSecond)
	{
		if (pointFirst + 1E-05f > pointSecond)
		{
			return pointFirst - 1E-05f < pointSecond;
		}
		return false;
	}

	public virtual bool imethod_3(int index)
	{
		int num = 0;
		while (true)
		{
			if (num < int_0.Length)
			{
				if (index == int_0[num])
				{
					break;
				}
				num++;
				continue;
			}
			return false;
		}
		return true;
	}

	public static void smethod_1(GraphicsPath shape, GraphicsPath[] shapes, int length)
	{
		while (length > 1)
		{
			int num = 0;
			for (int i = 1; i < length; i += 2)
			{
				shapes[i - 1].AddPath(shapes[i], connect: false);
				shapes[num++] = shapes[i - 1];
				shapes[i] = null;
			}
			if ((length & 1) == 1)
			{
				shapes[num - 1].AddPath(shapes[length - 1], connect: false);
			}
			length /= 2;
		}
		if (length == 1)
		{
			shape.AddPath(shapes[0], connect: false);
		}
	}

	internal virtual void vmethod_0()
	{
		if (!bool_3)
		{
			class7127_0.imethod_8();
			bool flag = false;
			if (class7127_0.vmethod_1("CUSTOM_SPACING") != null)
			{
				flag = (bool)class7127_0.vmethod_1("CUSTOM_SPACING");
			}
			if (flag && flag)
			{
				pointF_0 = vmethod_1((float)class7127_0.vmethod_1("KERNING"), (float)class7127_0.vmethod_1("LETTER_SPACING"), (float)class7127_0.vmethod_1("WORD_SPACING"));
				bool_2 = false;
			}
			vmethod_2(!bool_1);
			bool_3 = true;
			bool_4 = false;
		}
	}

	internal virtual PointF vmethod_1(float kerning, float spacing, float wordSpace)
	{
		bool flag = true;
		bool flag2 = false;
		bool flag3 = false;
		float num = 0f;
		float num2 = 0f;
		if (kerning != 0f)
		{
			num = kerning;
			flag = false;
		}
		if (spacing != 0f)
		{
			num2 = spacing;
			flag3 = true;
		}
		if (wordSpace != 0f)
		{
			flag2 = true;
		}
		int num3 = 0;
		if (class7117_0 == null)
		{
			return default(PointF);
		}
		num3 = class7117_0.GlyphsLength;
		float num4 = 0f;
		float num5 = 0f;
		PointF[] array = new PointF[num3 + 1];
		PointF pointF = class7117_0.imethod_5(0);
		class7117_0.imethod_3(0);
		float num6 = pointF.X;
		float num7 = pointF.Y;
		PointF pointF2 = new PointF(pointF_0.X - (class7117_0.imethod_5(num3 - 1).X - num6), pointF_0.Y - (class7117_0.imethod_5(num3 - 1).Y - num7));
		try
		{
			if (num3 > 1 && (flag3 || !flag))
			{
				for (int i = 1; i <= num3; i++)
				{
					PointF pointF3 = class7117_0.imethod_5(i);
					if (i == num3)
					{
						_ = -1;
					}
					else
						class7117_0.imethod_3(i);
					num4 = pointF3.X - pointF.X;
					num5 = pointF3.Y - pointF.Y;
					if (flag)
					{
						if (bool_0)
						{
							num5 += num2;
						}
						else
						{
							num4 += num2;
						}
					}
					else if (bool_0)
					{
						float num8 = 0f;
						num5 += num - num8 + num2;
					}
					else
					{
						float num9 = 0f;
						num4 += num - num9 + num2;
					}
					num6 += num4;
					num7 += num5;
					ref PointF reference = ref array[i];
					reference = new PointF(num6, num7);
					pointF = pointF3;
				}
				for (int j = 1; j <= num3; j++)
				{
					class7117_0.imethod_9(j, array[j]);
				}
			}
			if (bool_0)
			{
				pointF2.Y = pointF2.Y + num + num2;
			}
			else
			{
				pointF2.X = pointF2.X + num + num2;
			}
			num4 = 0f;
			num5 = 0f;
			pointF = class7117_0.imethod_5(0);
			num6 = pointF.X;
			num7 = pointF.Y;
			if (num3 > 1 && flag2)
			{
				for (int k = 1; k < num3; k++)
				{
					PointF pointF4 = class7117_0.imethod_5(k);
					num4 = pointF4.X - pointF.X;
					num5 = pointF4.Y - pointF.Y;
					bool flag4 = false;
					int num10 = k;
					int num11 = k;
					Class7114 @class = class7117_0.method_1(k);
					while ((double)@class.Bounds.Width < 0.01 || @class.vmethod_2())
					{
						if (!flag4)
						{
							flag4 = true;
						}
						if (k == num3 - 1)
						{
							break;
						}
						k++;
						num11++;
						pointF4 = class7117_0.imethod_5(k);
						@class = class7117_0.method_1(k);
					}
					if (flag4)
					{
						int num12 = num11 - num10;
						float num13 = pointF.X;
						float num14 = pointF.Y;
						num4 = (pointF4.X - num13) / (float)(num12 + 1);
						num5 = (pointF4.Y - num14) / (float)(num12 + 1);
						if (bool_0)
						{
							num5 += wordSpace / (float)(num12 + 1);
						}
						else
						{
							num4 += wordSpace / (float)(num12 + 1);
						}
						for (int l = num10; l <= num11; l++)
						{
							num6 += num4;
							num7 += num5;
							ref PointF reference2 = ref array[l];
							reference2 = new PointF(num6, num7);
						}
					}
					else
					{
						num4 = pointF4.X - pointF.X;
						num5 = pointF4.Y - pointF.Y;
						num6 += num4;
						num7 += num5;
						ref PointF reference3 = ref array[k];
						reference3 = new PointF(num6, num7);
					}
					pointF = pointF4;
				}
				PointF pointF5 = class7117_0.imethod_5(num3);
				num6 += pointF5.X - pointF.X;
				num7 += pointF5.Y - pointF.Y;
				ref PointF reference4 = ref array[num3];
				reference4 = new PointF(num6, num7);
				for (int m = 1; m <= num3; m++)
				{
					class7117_0.imethod_9(m, array[m]);
				}
			}
		}
		catch (Exception ex)
		{
			_ = ex.Message;
		}
		float num15 = class7117_0.imethod_5(num3 - 1).X - class7117_0.imethod_5(0).X;
		float num16 = class7117_0.imethod_5(num3 - 1).Y - class7117_0.imethod_5(0).Y;
		return new PointF(num15 + pointF2.X, num16 + pointF2.Y);
	}

	internal virtual void vmethod_2(bool stretchGlyphs)
	{
		if (float_1 == 1f && float_2 == 1f)
		{
			return;
		}
		Matrix matrix = new Matrix();
		matrix.Scale(float_1, float_2);
		if (class7117_0 == null)
		{
			return;
		}
		int glyphsLength = class7117_0.GlyphsLength;
		float[] array = class7117_0.imethod_6(0, glyphsLength + 1, null);
		float num = array[0];
		float num2 = array[1];
		PointF position = default(PointF);
		for (int i = 0; i <= glyphsLength; i++)
		{
			float num3 = array[2 * i] - num;
			float num4 = array[2 * i + 1] - num2;
			position.X = num + num3 * float_1;
			position.Y = num2 + num4 * float_2;
			class7117_0.imethod_9(i, position);
			if (stretchGlyphs && i != glyphsLength)
			{
				Matrix matrix2 = class7117_0.imethod_7(i);
				if (matrix2 != null)
				{
					matrix2.Scale(float_1, float_2);
					class7117_0.imethod_10(i, matrix2);
				}
				else
				{
					class7117_0.imethod_10(i, matrix);
				}
			}
		}
		bool_2 = false;
		pointF_0 = new PointF(pointF_0.X * float_1, pointF_0.Y * float_2);
	}

	public virtual int imethod_6(int index)
	{
		int glyphCount = GlyphCount;
		int num = 0;
		for (int i = 0; i < glyphCount; i++)
		{
			int num2 = imethod_7(i, i);
			for (int j = 0; j < num2; j++)
			{
				int num3 = int_0[num++];
				if (index != num3)
				{
					if (num >= int_0.Length)
					{
						return -1;
					}
					continue;
				}
				return i;
			}
		}
		return -1;
	}

	public virtual int vmethod_3(int index)
	{
		int glyphCount = GlyphCount;
		int num = int_0.Length - 1;
		for (int num2 = glyphCount - 1; num2 >= 0; num2--)
		{
			int num3 = imethod_7(num2, num2);
			for (int i = 0; i < num3; i++)
			{
				int num4 = int_0[num--];
				if (index != num4)
				{
					if (num < 0)
					{
						return -1;
					}
					continue;
				}
				return num2;
			}
		}
		return -1;
	}
}
