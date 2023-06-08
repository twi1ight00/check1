using System;
using System.Collections.Generic;
using System.Drawing;
using ns224;
using ns24;
using ns28;
using ns4;

namespace Aspose.Slides;

public sealed class GradientFormat : IFillParamSource, IGradientFormat
{
	private const float float_0 = 2.2f;

	private const float float_1 = 0.45454544f;

	private IPresentationComponent ipresentationComponent_0;

	private uint uint_0;

	internal TileFlip tileFlip_0;

	internal float float_2;

	internal NullableBool nullableBool_0;

	internal GradientShape gradientShape_0;

	internal GradientStopCollection gradientStopCollection_0;

	private GradientDirection gradientDirection_0 = GradientDirection.NotDefined;

	private Class1148 class1148_0 = new Class1148();

	private Class1148 class1148_1 = new Class1148();

	private static readonly float[] float_3 = new float[5] { 0.05f, 0.1f, 0.2f, 0.3f, 0.4f };

	private static readonly float[] float_4 = new float[5] { 0.014f, 0.033f, 0.096f, 0.2f, 0.333f };

	private static readonly float[,] float_5 = new float[5, 6]
	{
		{ 0f, 0f, -1f, -1f, 2f, 2f },
		{ 1f, 0f, 0f, -1f, 2f, 2f },
		{ 0f, 1f, -1f, 0f, 2f, 2f },
		{ 1f, 1f, 0f, 0f, 2f, 2f },
		{ 0.5f, 0.5f, 0f, 0f, 1f, 1f }
	};

	public TileFlip TileFlip
	{
		get
		{
			return tileFlip_0;
		}
		set
		{
			tileFlip_0 = value;
			method_7();
		}
	}

	public GradientDirection GradientDirection
	{
		get
		{
			return gradientDirection_0;
		}
		set
		{
			if (gradientDirection_0 != value)
			{
				gradientDirection_0 = value;
				if (gradientDirection_0 != GradientDirection.NotDefined)
				{
					int num = (int)gradientDirection_0;
					class1148_1.X = float_5[num, 0];
					class1148_1.Y = float_5[num, 1];
					class1148_1.Width = 0f;
					class1148_1.Height = 0f;
					class1148_0.X = float_5[num, 2];
					class1148_0.Y = float_5[num, 3];
					class1148_0.Width = float_5[num, 4];
					class1148_0.Height = float_5[num, 5];
				}
				method_7();
			}
		}
	}

	public float LinearGradientAngle
	{
		get
		{
			return float_2;
		}
		set
		{
			value %= 360f;
			if (value < 0f)
			{
				value += 360f;
			}
			float_2 = value;
			method_7();
		}
	}

	public NullableBool LinearGradientScaled
	{
		get
		{
			return nullableBool_0;
		}
		set
		{
			nullableBool_0 = value;
			method_7();
		}
	}

	public GradientShape GradientShape
	{
		get
		{
			return gradientShape_0;
		}
		set
		{
			gradientShape_0 = value;
			method_7();
		}
	}

	public IGradientStopCollection GradientStops => gradientStopCollection_0;

	IFillParamSource IGradientFormat.AsIFillParamSource => this;

	internal Class1148 TileRectangle => class1148_0;

	internal float FillToRectangleX => class1148_1.X;

	internal float FillToRectangleY => class1148_1.Y;

	internal float FillToRectangleWidth => class1148_1.Width;

	internal float FillToRectangleHeight => class1148_1.Height;

	internal Class1148 FillToRectangle => class1148_1;

	internal IPresentationComponent Parent => ipresentationComponent_0;

	internal uint Version => uint_0 + gradientStopCollection_0.Version + class1148_0.Version + class1148_1.Version;

	internal GradientFormat(IPresentationComponent parent)
	{
		ipresentationComponent_0 = parent;
		gradientStopCollection_0 = new GradientStopCollection(parent);
		tileFlip_0 = TileFlip.NotDefined;
		float_2 = float.NaN;
		nullableBool_0 = NullableBool.NotDefined;
		gradientShape_0 = GradientShape.NotDefined;
	}

	public override bool Equals(object obj)
	{
		if (!(obj is GradientFormat gradientFormat))
		{
			return base.Equals(obj);
		}
		if (GradientDirection != gradientFormat.GradientDirection)
		{
			return false;
		}
		if (gradientShape_0 != gradientFormat.gradientShape_0)
		{
			return false;
		}
		switch (gradientShape_0)
		{
		default:
			return true;
		case GradientShape.Linear:
			if (float_2 == gradientFormat.float_2 && nullableBool_0 == gradientFormat.nullableBool_0)
			{
				if (tileFlip_0 == gradientFormat.tileFlip_0 && gradientStopCollection_0.Count == gradientStopCollection_0.Count)
				{
					int num = 0;
					while (true)
					{
						if (num < gradientStopCollection_0.Count)
						{
							if (!gradientStopCollection_0[num].Equals(gradientFormat.gradientStopCollection_0[num]))
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
			return GradientDirection == gradientFormat.GradientDirection;
		}
	}

	public override int GetHashCode()
	{
		return 23456;
	}

	internal void method_0(GradientFormat source)
	{
		tileFlip_0 = source.tileFlip_0;
		float_2 = source.float_2;
		nullableBool_0 = source.nullableBool_0;
		gradientShape_0 = source.gradientShape_0;
		gradientDirection_0 = source.gradientDirection_0;
		class1148_0.method_0(source.class1148_0);
		class1148_1.method_0(source.class1148_1);
		gradientStopCollection_0.Clear();
		foreach (GradientStop item in source.gradientStopCollection_0)
		{
			gradientStopCollection_0.Add(item.Position, new ColorFormat(ipresentationComponent_0 as ISlideComponent, (ColorFormat)item.Color));
		}
		method_7();
	}

	internal void method_1(IGradientFormatEffectiveData source)
	{
		tileFlip_0 = source.TileFlip;
		float_2 = source.LinearGradientAngle;
		nullableBool_0 = (source.LinearGradientScaled ? NullableBool.True : NullableBool.False);
		gradientShape_0 = source.GradientShape;
		gradientStopCollection_0.Clear();
		foreach (IGradientStopEffectiveData gradientStop in source.GradientStops)
		{
			gradientStopCollection_0.Add(gradientStop.Position, new ColorFormat(ipresentationComponent_0 as ISlideComponent, gradientStop.Color));
		}
		method_7();
	}

	private static float smethod_0(float component)
	{
		return (float)Math.Pow(component, 0.4545454446934474);
	}

	private static float smethod_1(float component)
	{
		return (float)Math.Pow(component, 2.200000047683716);
	}

	internal SortedList<float, Color> method_2(IBaseSlide slide, FloatColor styleColor)
	{
		if (gradientStopCollection_0.Count < 2)
		{
			return null;
		}
		SortedList<float, FloatColor> sortedList = new SortedList<float, FloatColor>();
		float num = -1f;
		ColorFormat colorFormat = null;
		foreach (GradientStop item in gradientStopCollection_0)
		{
			if (!sortedList.ContainsKey(item.Position))
			{
				sortedList.Add(item.Position, ((ColorFormat)item.Color).method_4(slide, styleColor));
			}
			if (item.Position >= num)
			{
				num = item.Position;
				colorFormat = (ColorFormat)item.Color;
			}
		}
		if (sortedList.Keys[sortedList.Count - 1] < 1f)
		{
			sortedList.Add(1f, colorFormat.method_4(slide, styleColor));
		}
		if (gradientStopCollection_0.Count == 2 && sortedList.Count == 2 && sortedList.Keys[0] == 0f && sortedList.Keys[1] == 1f)
		{
			FloatColor floatColor = sortedList.Values[0];
			FloatColor floatColor2 = sortedList.Values[1];
			if (!floatColor2.Equals(floatColor))
			{
				float num2 = smethod_1(floatColor.float_0);
				float num3 = smethod_1(floatColor.float_1);
				float num4 = smethod_1(floatColor.float_2);
				float num5 = smethod_1(floatColor.float_3);
				float num6 = smethod_1(floatColor2.float_0);
				float num7 = smethod_1(floatColor2.float_1);
				float num8 = smethod_1(floatColor2.float_2);
				float num9 = smethod_1(floatColor2.float_3);
				sortedList.Capacity = 2 + float_4.Length * 2;
				for (int i = 0; i < float_4.Length; i++)
				{
					sortedList.Add(float_3[i], new FloatColor(smethod_0(num2 + (num6 - num2) * float_4[i]), smethod_0(num3 + (num7 - num3) * float_4[i]), smethod_0(num4 + (num8 - num4) * float_4[i]), smethod_0(num5 + (num9 - num5) * float_4[i])));
					sortedList.Add(1f - float_3[i], new FloatColor(smethod_0(num2 + (num6 - num2) * (1f - float_4[i])), smethod_0(num3 + (num7 - num3) * (1f - float_4[i])), smethod_0(num4 + (num8 - num4) * (1f - float_4[i])), smethod_0(num5 + (num9 - num5) * (1f - float_4[i]))));
				}
			}
		}
		else if (gradientStopCollection_0.Count == 3 && sortedList.Count == 3 && sortedList.Values[0].Equals(sortedList.Values[2]) && sortedList.Keys[0] == 0f && sortedList.Keys[2] == 1f)
		{
			FloatColor floatColor3 = sortedList.Values[0];
			FloatColor floatColor4 = sortedList.Values[1];
			if (!floatColor4.Equals(floatColor3))
			{
				float num10 = smethod_1(floatColor3.float_0);
				float num11 = smethod_1(floatColor3.float_1);
				float num12 = smethod_1(floatColor3.float_2);
				float num13 = smethod_1(floatColor3.float_3);
				float num14 = smethod_1(floatColor4.float_0);
				float num15 = smethod_1(floatColor4.float_1);
				float num16 = smethod_1(floatColor4.float_2);
				float num17 = smethod_1(floatColor4.float_3);
				sortedList.Capacity = 2 + float_4.Length * 2;
				float num18 = sortedList.Keys[1];
				for (int j = 0; j < float_4.Length; j++)
				{
					sortedList.Add(num18 * float_3[j], new FloatColor(smethod_0(num10 + (num14 - num10) * float_4[j]), smethod_0(num11 + (num15 - num11) * float_4[j]), smethod_0(num12 + (num16 - num12) * float_4[j]), smethod_0(num13 + (num17 - num13) * float_4[j])));
					sortedList.Add(num18 * (1f - float_3[j]), new FloatColor(smethod_0(num10 + (num14 - num10) * (1f - float_4[j])), smethod_0(num11 + (num15 - num11) * (1f - float_4[j])), smethod_0(num12 + (num16 - num12) * (1f - float_4[j])), smethod_0(num13 + (num17 - num13) * (1f - float_4[j]))));
					sortedList.Add(1f - (1f - num18) * float_3[j], new FloatColor(smethod_0(num10 + (num14 - num10) * float_4[j]), smethod_0(num11 + (num15 - num11) * float_4[j]), smethod_0(num12 + (num16 - num12) * float_4[j]), smethod_0(num13 + (num17 - num13) * float_4[j])));
					sortedList.Add(num18 + (1f - num18) * float_3[j], new FloatColor(smethod_0(num10 + (num14 - num10) * (1f - float_4[j])), smethod_0(num11 + (num15 - num11) * (1f - float_4[j])), smethod_0(num12 + (num16 - num12) * (1f - float_4[j])), smethod_0(num13 + (num17 - num13) * (1f - float_4[j]))));
				}
			}
		}
		SortedList<float, Color> sortedList2 = new SortedList<float, Color>();
		for (int k = 0; k < sortedList.Count; k++)
		{
			sortedList2.Add(sortedList.Keys[k], sortedList.Values[k].Color);
		}
		return sortedList2;
	}

	internal void method_3(Class396 grad)
	{
		switch (grad.Style)
		{
		default:
			GradientShape = GradientShape.NotDefined;
			break;
		case Enum48.const_0:
			GradientShape = GradientShape.Linear;
			break;
		case Enum48.const_1:
			GradientShape = GradientShape.Linear;
			break;
		case Enum48.const_2:
			GradientShape = GradientShape.Radial;
			break;
		case Enum48.const_3:
			GradientShape = GradientShape.Radial;
			break;
		case Enum48.const_4:
			GradientShape = GradientShape.Rectangle;
			break;
		case Enum48.const_5:
			GradientShape = GradientShape.Path;
			break;
		}
		if (grad.Style == Enum48.const_1)
		{
			float num = (float)grad.Border / 100f;
			gradientStopCollection_0.Add(num / 2f, grad.EndColor);
			gradientStopCollection_0.Add(0.5f, grad.StartColor);
			gradientStopCollection_0.Add(1f - num / 2f, grad.EndColor);
		}
		else
		{
			float position = 1f - (float)grad.Border / 100f;
			gradientStopCollection_0.Add(position, grad.StartColor);
			gradientStopCollection_0.Add(0f, grad.EndColor);
		}
		LinearGradientAngle = Math.Abs(360f - (float)grad.Angle);
		int gradientCenterX = grad.GradientCenterX;
		int gradientCenterY = grad.GradientCenterY;
		if (gradientCenterX >= 40 && gradientCenterY <= 60)
		{
			GradientDirection = GradientDirection.FromCenter;
		}
		if (gradientCenterX < 40 && gradientCenterY < 50)
		{
			GradientDirection = GradientDirection.FromCorner1;
		}
		if (gradientCenterX < 40 && gradientCenterY > 50)
		{
			GradientDirection = GradientDirection.FromCorner3;
		}
		if (gradientCenterX > 60 && gradientCenterY <= 50)
		{
			GradientDirection = GradientDirection.FromCorner2;
		}
		if (gradientCenterX > 60 && gradientCenterY >= 50)
		{
			GradientDirection = GradientDirection.FromCorner4;
		}
		method_7();
	}

	internal void method_4(Class470 fillProp, BaseSlide slide, Class476 odpPackage)
	{
		if (GradientStops.Count > 2 || GradientStops[0].Position != 0f || GradientStops[GradientStops.Count - 1].Position != 1f)
		{
			fillProp.FillStyle = Enum36.const_2;
			if (GradientShape == GradientShape.Linear)
			{
				Bitmap bitmap = new Bitmap(256, (LinearGradientAngle % 180f == 0f) ? 1 : 256);
				bitmap.SetResolution(96f, 96f);
				Graphics graphics = Graphics.FromImage(bitmap);
				Class63 @class = new Class63(new Class67(new ShapeFrame(0f, 0f, bitmap.Width, bitmap.Height, NullableBool.False, NullableBool.False, 0f), new Class6002(), null, slide, null), this);
				@class.FillRotation = 0f;
				Brush brush = @class.method_9();
				graphics.FillRectangle(brush, 0, 0, bitmap.Width, bitmap.Height);
				brush.Dispose();
				graphics.Dispose();
				fillProp.FillImageRenderingStyle = Enum38.const_2;
				string imgName = (fillProp.FillImageName = "Img" + odpPackage.int_0++);
				odpPackage.class465_0.method_3(imgName, odpPackage.method_9(slide.ParentPresentation.Images.AddImage(bitmap)));
			}
			else
			{
				Bitmap bitmap2 = new Bitmap(256, 256);
				bitmap2.SetResolution(96f, 96f);
				Graphics graphics2 = Graphics.FromImage(bitmap2);
				Class63 class2 = new Class63(new Class67(new ShapeFrame(0f, 0f, 256f, 256f, NullableBool.False, NullableBool.False, 0f), new Class6002(), null, slide, null), this);
				Brush brush2 = class2.method_9();
				graphics2.FillRectangle(brush2, 0, 0, bitmap2.Width, bitmap2.Height);
				brush2.Dispose();
				graphics2.Dispose();
				fillProp.FillImageRenderingStyle = Enum38.const_2;
				string imgName2 = (fillProp.FillImageName = "Img" + odpPackage.int_0++);
				odpPackage.class465_0.method_3(imgName2, odpPackage.method_9(slide.ParentPresentation.Images.AddImage(bitmap2)));
			}
			return;
		}
		fillProp.FillStyle = Enum36.const_3;
		string text4 = (fillProp.GradientName = "Gradient" + odpPackage.int_0++);
		Class396 class3 = odpPackage.class465_0.method_4(text4);
		class3.DisplayName = text4;
		switch (GradientShape)
		{
		case GradientShape.Linear:
			class3.Style = Enum48.const_0;
			break;
		case GradientShape.Rectangle:
			class3.Style = Enum48.const_4;
			break;
		case GradientShape.Radial:
			class3.Style = Enum48.const_2;
			break;
		case GradientShape.Path:
			class3.Style = Enum48.const_5;
			break;
		}
		if (gradientStopCollection_0.Count > 2)
		{
			class3.Style = Enum48.const_1;
			class3.StartColor = gradientStopCollection_0[1].Color.Color;
			class3.EndColor = gradientStopCollection_0[0].Color.Color;
			class3.Border = 50;
		}
		else
		{
			class3.StartColor = gradientStopCollection_0[0].Color.Color;
			class3.EndColor = gradientStopCollection_0[1].Color.Color;
			class3.Border = (int)(100f - gradientStopCollection_0[0].Position * 100f);
		}
		switch (GradientDirection)
		{
		default:
			class3.GradientCenterX = 50;
			class3.GradientCenterY = 50;
			break;
		case GradientDirection.FromCorner1:
			class3.GradientCenterX = 20;
			class3.GradientCenterY = 20;
			break;
		case GradientDirection.FromCorner2:
			class3.GradientCenterX = 80;
			class3.GradientCenterY = 20;
			break;
		case GradientDirection.FromCorner3:
			class3.GradientCenterX = 20;
			class3.GradientCenterY = 80;
			break;
		case GradientDirection.FromCorner4:
			class3.GradientCenterX = 80;
			class3.GradientCenterY = 80;
			break;
		case GradientDirection.FromCenter:
			class3.GradientCenterX = 50;
			class3.GradientCenterY = 50;
			break;
		}
		if (LinearGradientAngle > 0f)
		{
			class3.Angle = (int)LinearGradientAngle + 360;
		}
	}

	private void method_5()
	{
		if (class1148_1.Width == 0f && class1148_1.Height == 0f)
		{
			if (class1148_1.X == 0f)
			{
				if (class1148_1.Y == 0f)
				{
					gradientDirection_0 = GradientDirection.FromCorner1;
				}
				else if (class1148_1.Y == 1f)
				{
					gradientDirection_0 = GradientDirection.FromCorner2;
				}
				else
				{
					gradientDirection_0 = GradientDirection.NotDefined;
				}
			}
			else if (class1148_1.X == 1f)
			{
				if (class1148_1.Y == 0f)
				{
					gradientDirection_0 = GradientDirection.FromCorner3;
				}
				else if (class1148_1.Y == 1f)
				{
					gradientDirection_0 = GradientDirection.FromCorner4;
				}
				else
				{
					gradientDirection_0 = GradientDirection.NotDefined;
				}
			}
			else if (class1148_1.X == 0.5f && class1148_1.Y == 0.5f)
			{
				gradientDirection_0 = GradientDirection.FromCenter;
			}
			else
			{
				gradientDirection_0 = GradientDirection.NotDefined;
			}
		}
		else
		{
			gradientDirection_0 = GradientDirection.NotDefined;
		}
		method_7();
	}

	internal void method_6(float x, float y, float width, float height)
	{
		class1148_1.X = x;
		class1148_1.Y = y;
		class1148_1.Width = width;
		class1148_1.Height = height;
		method_5();
		method_7();
	}

	private void method_7()
	{
		uint_0++;
	}
}
