using System;
using System.Collections.Generic;
using System.Drawing;
using Aspose.Slides;
using ns24;

namespace ns4;

internal sealed class Class58 : IGradientFormatEffectiveData, IEffectiveData
{
	private const float float_0 = 2.2f;

	private const float float_1 = 0.45454544f;

	private static readonly float[] float_2 = new float[5] { 0.05f, 0.1f, 0.2f, 0.3f, 0.4f };

	private static readonly float[] float_3 = new float[5] { 0.014f, 0.033f, 0.096f, 0.2f, 0.333f };

	private GradientFormat gradientFormat_0;

	private bool bool_0;

	private Class21.Delegate3 delegate3_0;

	private IBaseSlide ibaseSlide_0;

	private TileFlip tileFlip_0;

	private GradientDirection gradientDirection_0;

	private float float_4;

	private bool bool_1;

	internal GradientShape gradientShape_0;

	private Class1148 class1148_0 = new Class1148();

	private Class1148 class1148_1 = new Class1148();

	private Class56 class56_0;

	public TileFlip TileFlip => tileFlip_0;

	public GradientDirection GradientDirection => gradientDirection_0;

	public float LinearGradientAngle => float_4;

	public bool LinearGradientScaled => bool_1;

	public GradientShape GradientShape => gradientShape_0;

	public IGradientStopCollectionEffectiveData GradientStops => class56_0;

	internal Class1148 TileRectangleInternal => class1148_0;

	internal Class1148 FillToRectangleInternal => class1148_1;

	internal Class58()
	{
		class56_0 = new Class56();
		tileFlip_0 = TileFlip.NotDefined;
		gradientDirection_0 = GradientDirection.NotDefined;
		float_4 = float.NaN;
		bool_1 = false;
		gradientShape_0 = GradientShape.NotDefined;
		class56_0.Clear();
	}

	internal void method_0(GradientFormat source)
	{
		if (source == null)
		{
			return;
		}
		if (source.tileFlip_0 != TileFlip.NotDefined)
		{
			tileFlip_0 = source.tileFlip_0;
		}
		if (source.GradientDirection != GradientDirection.NotDefined)
		{
			gradientDirection_0 = source.GradientDirection;
		}
		if (!float.IsNaN(source.float_2))
		{
			float_4 = source.float_2;
		}
		if (source.nullableBool_0 != NullableBool.NotDefined)
		{
			bool_1 = source.nullableBool_0 == NullableBool.True;
		}
		if (source.gradientShape_0 != GradientShape.NotDefined)
		{
			gradientShape_0 = source.gradientShape_0;
		}
		if (source.TileRectangle != null)
		{
			class1148_0.method_0(source.TileRectangle);
		}
		class1148_1.method_0(new Class1148(source.FillToRectangleX, source.FillToRectangleY, source.FillToRectangleWidth, source.FillToRectangleHeight));
		if (source.gradientStopCollection_0 == null || source.gradientStopCollection_0.Count <= 0)
		{
			return;
		}
		class56_0.Clear();
		foreach (GradientStop item in source.gradientStopCollection_0)
		{
			class56_0.Add(item.Position, ((ColorFormat)item.Color).method_5);
		}
	}

	internal void method_1(IBaseSlide slide, FloatColor styleColor)
	{
		foreach (Class57 item in class56_0)
		{
			item.method_0(slide, styleColor);
		}
	}

	internal void method_2(Class58 source)
	{
		if (source == null)
		{
			return;
		}
		tileFlip_0 = source.tileFlip_0;
		gradientDirection_0 = source.GradientDirection;
		float_4 = source.float_4;
		bool_1 = source.bool_1;
		gradientShape_0 = source.gradientShape_0;
		class1148_0.method_0(source.class1148_0);
		class1148_1.method_0(source.class1148_1);
		class56_0.Clear();
		foreach (Class57 item in source.class56_0)
		{
			class56_0.method_0(item);
		}
	}

	public override bool Equals(object obj)
	{
		if (!(obj is Class58 obj2))
		{
			return false;
		}
		return method_3(obj2);
	}

	internal bool method_3(Class58 obj)
	{
		if (obj == null)
		{
			return false;
		}
		if (gradientDirection_0 != obj.GradientDirection)
		{
			return false;
		}
		if (gradientShape_0 != obj.GradientShape)
		{
			return false;
		}
		switch (gradientShape_0)
		{
		default:
			return true;
		case GradientShape.Linear:
			if (float_4 == obj.LinearGradientAngle && bool_1 == obj.LinearGradientScaled)
			{
				if (tileFlip_0 == obj.TileFlip && class56_0.Count == obj.GradientStops.Count)
				{
					int num = 0;
					while (true)
					{
						if (num < class56_0.Count)
						{
							if (class56_0[num].Position != obj.GradientStops[num].Position || class56_0[num].Color != obj.GradientStops[num].Color)
							{
								break;
							}
							num++;
							continue;
						}
						return true;
					}
					return false;
				}
				return false;
			}
			return false;
		case GradientShape.Rectangle:
		case GradientShape.Radial:
			return gradientDirection_0 == obj.GradientDirection;
		}
	}

	internal bool method_4(GradientFormatEffectiveData obj)
	{
		if (obj == null)
		{
			return false;
		}
		if (gradientDirection_0 != obj.GradientDirection)
		{
			return false;
		}
		if (gradientShape_0 != obj.GradientShape)
		{
			return false;
		}
		switch (gradientShape_0)
		{
		default:
			return true;
		case GradientShape.Linear:
			if (float_4 == obj.LinearGradientAngle && bool_1 == obj.LinearGradientScaled)
			{
				if (tileFlip_0 == obj.TileFlip && class56_0.Count == obj.GradientStops.Count)
				{
					int num = 0;
					while (true)
					{
						if (num < class56_0.Count)
						{
							if (class56_0[num].Position != obj.GradientStops[num].Position || class56_0[num].Color != obj.GradientStops[num].Color)
							{
								break;
							}
							num++;
							continue;
						}
						return true;
					}
					return false;
				}
				return false;
			}
			return false;
		case GradientShape.Rectangle:
		case GradientShape.Radial:
			return gradientDirection_0 == obj.GradientDirection;
		}
	}

	public override int GetHashCode()
	{
		return 23456;
	}

	private static float smethod_0(float component)
	{
		return (float)Math.Pow(component, 0.4545454446934474);
	}

	private static float smethod_1(float component)
	{
		return (float)Math.Pow(component, 2.200000047683716);
	}

	internal SortedList<float, Color> method_5()
	{
		if (class56_0.Count < 2)
		{
			return null;
		}
		SortedList<float, Color> sortedList = new SortedList<float, Color>();
		float num = -1f;
		Color value = Color.Empty;
		foreach (Class57 item in class56_0)
		{
			if (!sortedList.ContainsKey(item.Position))
			{
				sortedList.Add(item.Position, item.Color);
			}
			if (item.Position >= num)
			{
				num = item.Position;
				value = item.Color;
			}
		}
		if (sortedList.Keys[sortedList.Count - 1] < 1f)
		{
			sortedList.Add(1f, value);
		}
		if (class56_0.Count == 2 && sortedList.Count == 2 && sortedList.Keys[0] == 0f && sortedList.Keys[1] == 1f)
		{
			Color color = sortedList.Values[0];
			Color color2 = sortedList.Values[1];
			if (!color2.Equals(color))
			{
				float num2 = smethod_1((float)(int)color.A / 255f);
				float num3 = smethod_1((float)(int)color.R / 255f);
				float num4 = smethod_1((float)(int)color.G / 255f);
				float num5 = smethod_1((float)(int)color.B / 255f);
				float num6 = smethod_1((float)(int)color2.A / 255f);
				float num7 = smethod_1((float)(int)color2.R / 255f);
				float num8 = smethod_1((float)(int)color2.G / 255f);
				float num9 = smethod_1((float)(int)color2.B / 255f);
				sortedList.Capacity = 2 + float_3.Length * 2;
				for (int i = 0; i < float_3.Length; i++)
				{
					sortedList.Add(float_2[i], new FloatColor(smethod_0(num2 + (num6 - num2) * float_3[i]), smethod_0(num3 + (num7 - num3) * float_3[i]), smethod_0(num4 + (num8 - num4) * float_3[i]), smethod_0(num5 + (num9 - num5) * float_3[i])).Color);
					sortedList.Add(1f - float_2[i], new FloatColor(smethod_0(num2 + (num6 - num2) * (1f - float_3[i])), smethod_0(num3 + (num7 - num3) * (1f - float_3[i])), smethod_0(num4 + (num8 - num4) * (1f - float_3[i])), smethod_0(num5 + (num9 - num5) * (1f - float_3[i]))).Color);
				}
			}
		}
		else if (class56_0.Count == 3 && sortedList.Count == 3 && sortedList.Values[0].Equals(sortedList.Values[2]) && sortedList.Keys[0] == 0f && sortedList.Keys[2] == 1f)
		{
			Color color3 = sortedList.Values[0];
			Color color4 = sortedList.Values[1];
			if (!color4.Equals(color3))
			{
				float num10 = smethod_1((float)(int)color3.A / 255f);
				float num11 = smethod_1((float)(int)color3.R / 255f);
				float num12 = smethod_1((float)(int)color3.G / 255f);
				float num13 = smethod_1((float)(int)color3.B / 255f);
				float num14 = smethod_1((float)(int)color4.A / 255f);
				float num15 = smethod_1((float)(int)color4.R / 255f);
				float num16 = smethod_1((float)(int)color4.G / 255f);
				float num17 = smethod_1((float)(int)color4.B / 255f);
				sortedList.Capacity = 2 + float_3.Length * 2;
				float num18 = sortedList.Keys[1];
				for (int j = 0; j < float_3.Length; j++)
				{
					sortedList.Add(num18 * float_2[j], new FloatColor(smethod_0(num10 + (num14 - num10) * float_3[j]), smethod_0(num11 + (num15 - num11) * float_3[j]), smethod_0(num12 + (num16 - num12) * float_3[j]), smethod_0(num13 + (num17 - num13) * float_3[j])).Color);
					sortedList.Add(num18 * (1f - float_2[j]), new FloatColor(smethod_0(num10 + (num14 - num10) * (1f - float_3[j])), smethod_0(num11 + (num15 - num11) * (1f - float_3[j])), smethod_0(num12 + (num16 - num12) * (1f - float_3[j])), smethod_0(num13 + (num17 - num13) * (1f - float_3[j]))).Color);
					sortedList.Add(1f - (1f - num18) * float_2[j], new FloatColor(smethod_0(num10 + (num14 - num10) * float_3[j]), smethod_0(num11 + (num15 - num11) * float_3[j]), smethod_0(num12 + (num16 - num12) * float_3[j]), smethod_0(num13 + (num17 - num13) * float_3[j])).Color);
					sortedList.Add(num18 + (1f - num18) * float_2[j], new FloatColor(smethod_0(num10 + (num14 - num10) * (1f - float_3[j])), smethod_0(num11 + (num15 - num11) * (1f - float_3[j])), smethod_0(num12 + (num16 - num12) * (1f - float_3[j])), smethod_0(num13 + (num17 - num13) * (1f - float_3[j]))).Color);
				}
			}
		}
		return sortedList;
	}
}
