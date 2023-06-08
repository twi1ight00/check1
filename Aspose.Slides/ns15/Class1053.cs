using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Warnings;
using ns24;
using ns4;
using ns62;

namespace ns15;

internal class Class1053
{
	internal static void smethod_0(GradientFormat targetFormat, Class2670 frame, Class2670 masterFrame, Class854 slideDeserializationContext)
	{
		Class2930 @class = Class2945.smethod_6(frame, masterFrame, Enum426.const_104);
		Class2911 class2 = Class2945.smethod_4(frame, masterFrame, Enum426.const_109);
		if (@class != null && @class.Size > 6)
		{
			float num = (float)Class2945.smethod_10(frame, masterFrame, Enum426.const_83, 65536u) / 65536f;
			float num2 = (float)Class2945.smethod_10(frame, masterFrame, Enum426.const_85, 65536u) / 65536f;
			float num3 = num2 - num;
			byte[] value = @class.Value;
			int num4 = Class1162.smethod_0(value, 0);
			int num5 = Class1162.smethod_0(value, 4);
			if (@class.Size < 6 + num5 * num4 || num5 != 8)
			{
				throw new PptReadException("Error reading gradient stops.");
			}
			for (int i = 0; i < num4; i++)
			{
				int num6 = 6 + num5 * i;
				float num7 = (float)Class1162.smethod_6(value, num6 + 4) / 65536f;
				if (num7 >= 0f && num7 <= 1f)
				{
					int num8 = (int)Math.Round(255f * (num + num7 * num3));
					if (num8 > 255)
					{
						num8 = 255;
					}
					if (num8 < 0)
					{
						num8 = 0;
					}
					targetFormat.GradientStops.Add(num7, Color.FromArgb(num8, value[num6], value[num6 + 1], value[num6 + 2]));
				}
			}
			if (targetFormat.gradientStopCollection_0.method_0(0f) == null)
			{
				ColorFormat colorFormat = new ColorFormat(targetFormat.Parent as ISlideComponent);
				Class1049.smethod_3(colorFormat, frame, masterFrame, Enum426.const_82, Enum426.const_83, 16777215u);
				targetFormat.gradientStopCollection_0.Insert(0, 0f, colorFormat);
			}
			if (targetFormat.gradientStopCollection_0.method_0(1f) == null)
			{
				ColorFormat colorFormat2 = new ColorFormat(targetFormat.Parent as ISlideComponent);
				Class1049.smethod_3(colorFormat2, frame, masterFrame, Enum426.const_84, Enum426.const_85, 16777215u);
				targetFormat.gradientStopCollection_0.Add(1f, colorFormat2);
			}
		}
		else if (class2 != null && class2.Value != 1073741827)
		{
			if (class2.Value == 1073741835)
			{
				targetFormat.GradientStops.Add(0f, Color.Black);
				targetFormat.GradientStops.Add(1f, Color.White);
				Class1049.smethod_3((ColorFormat)targetFormat.GradientStops[0].Color, frame, masterFrame, Enum426.const_82, Enum426.const_83, 16777215u);
				Class2911 class3 = Class2945.smethod_4(frame, masterFrame, Enum426.const_84);
				ColorFormat colorFormat3 = (ColorFormat)targetFormat.GradientStops[1].Color;
				colorFormat3.method_0(targetFormat.GradientStops[0].Color);
				int num9 = 0;
				while (num9 < colorFormat3.ColorTransform.Count)
				{
					if (((ColorOperation)colorFormat3.ColorTransform[num9]).IsAlphaOperation)
					{
						colorFormat3.ColorTransform.RemoveAt(num9);
					}
					else
					{
						num9++;
					}
				}
				uint num10 = Class2945.smethod_10(frame, masterFrame, Enum426.const_85, 65536u);
				if (num10 < 65536)
				{
					colorFormat3.ColorTransform.Add(ColorTransformOperation.SetAlpha, (float)num10 / 65536f);
				}
				int num11 = 0;
				if (class3 != null)
				{
					colorFormat3.ColorTransform.Add(ColorTransformOperation.Gamma, 0f);
					num11 = (int)((class3.Value >> 16) & 0xFF);
					if ((class3.Value & 0xFFFF) == 496)
					{
						colorFormat3.ColorTransform.Add(ColorTransformOperation.Shade, (float)num11 / 255f);
					}
					else if ((class3.Value & 0xFFFF) == 752)
					{
						colorFormat3.ColorTransform.Add(ColorTransformOperation.Tint, (float)num11 / 255f);
					}
					colorFormat3.ColorTransform.Add(ColorTransformOperation.InverseGamma, 0f);
				}
			}
		}
		else
		{
			targetFormat.GradientStops.Add(0f, Color.Black);
			targetFormat.GradientStops.Add(1f, Color.White);
			Class1049.smethod_3((ColorFormat)targetFormat.GradientStops[0].Color, frame, masterFrame, Enum426.const_82, Enum426.const_83, 16777215u);
			Class1049.smethod_3((ColorFormat)targetFormat.GradientStops[1].Color, frame, masterFrame, Enum426.const_84, Enum426.const_85, 16777215u);
		}
		class2 = Class2945.smethod_2(frame, Enum426.const_81) as Class2911;
		Class2944 class4 = Class2945.smethod_0(frame);
		float num12 = (float)(int)Class2945.smethod_10(frame, masterFrame, Enum426.const_93, 0u) / 100f;
		switch (class2.Value)
		{
		case 5u:
		{
			targetFormat.GradientShape = GradientShape.Rectangle;
			Class2911 class5 = class4[Enum426.const_94] as Class2911;
			Class2911 class6 = class4[Enum426.const_95] as Class2911;
			Class2911 class7 = class4[Enum426.const_96] as Class2911;
			Class2911 class8 = class4[Enum426.const_97] as Class2911;
			float num13 = (float)(class5?.Value ?? 0) / 65536f;
			float num14 = (float)(class6?.Value ?? 0) / 65536f;
			float num15 = (float)(class7?.Value ?? 0) / 65536f;
			float num16 = (float)(class8?.Value ?? 0) / 65536f;
			targetFormat.method_6(num13, num14, num15 - num13, num16 - num14);
			break;
		}
		case 6u:
			targetFormat.GradientShape = GradientShape.Path;
			targetFormat.method_6(0.5f, 0.5f, 0f, 0f);
			targetFormat.GradientDirection = GradientDirection.FromCenter;
			break;
		case 4u:
		case 7u:
			targetFormat.GradientShape = GradientShape.Linear;
			targetFormat.float_2 = (float)(((int?)(class4[Enum426.const_92] as Class2911)?.Value) ?? (-5898240)) / 65536f;
			targetFormat.float_2 = 90f - (float)Class2945.smethod_9(frame, masterFrame, Enum426.const_92, 0) / 65536f;
			if (targetFormat.float_2 < 0f)
			{
				targetFormat.float_2 += 360f;
			}
			targetFormat.nullableBool_0 = NullableBool.True;
			break;
		}
		if (num12 == 1f)
		{
			return;
		}
		if (num12 >= 0f)
		{
			GradientStopCollection gradientStopCollection = new GradientStopCollection(targetFormat.Parent);
			if (num12 > 0f)
			{
				for (int j = 0; j < targetFormat.GradientStops.Count - 1; j++)
				{
					ColorFormat color = new ColorFormat(targetFormat.Parent as ISlideComponent, (ColorFormat)targetFormat.GradientStops[j].Color);
					gradientStopCollection.Add(targetFormat.GradientStops[j].Position * num12, color);
				}
			}
			for (int num17 = targetFormat.GradientStops.Count - 1; num17 >= 0; num17--)
			{
				ColorFormat color2 = new ColorFormat(targetFormat.Parent as ISlideComponent, (ColorFormat)targetFormat.GradientStops[num17].Color);
				gradientStopCollection.Add(1f - targetFormat.GradientStops[num17].Position * (1f - num12), color2);
			}
			targetFormat.gradientStopCollection_0 = gradientStopCollection;
		}
		else
		{
			if (!(num12 < 0f))
			{
				return;
			}
			GradientStopCollection gradientStopCollection2 = new GradientStopCollection(targetFormat.Parent);
			if (num12 > -1f)
			{
				for (int num18 = targetFormat.GradientStops.Count - 1; num18 > 0; num18--)
				{
					ColorFormat color3 = new ColorFormat(targetFormat.Parent as ISlideComponent, (ColorFormat)targetFormat.GradientStops[num18].Color);
					gradientStopCollection2.Add((1f - targetFormat.GradientStops[num18].Position) * (1f + num12), color3);
				}
			}
			for (int k = 0; k < targetFormat.GradientStops.Count; k++)
			{
				ColorFormat color4 = new ColorFormat(targetFormat.Parent as ISlideComponent, (ColorFormat)targetFormat.GradientStops[k].Color);
				gradientStopCollection2.Add(1f - (1f - targetFormat.GradientStops[k].Position) * (0f - num12), color4);
			}
			targetFormat.gradientStopCollection_0 = gradientStopCollection2;
		}
	}

	internal static void smethod_1(GradientFormat gradientFormat, Class2834 fopt, Class856 serializationContext)
	{
		Class2944 properties = fopt.Properties;
		properties.Remove(Enum426.const_81);
		properties.Remove(Enum426.const_92);
		switch (gradientFormat.GradientShape)
		{
		default:
			throw new Exception();
		case GradientShape.Linear:
			properties.Add(new Class2911(Enum426.const_81, 4u));
			if (gradientFormat.LinearGradientAngle != 90f)
			{
				float num = 90f - gradientFormat.LinearGradientAngle;
				if (num < 0f)
				{
					num += 360f;
				}
				if (num != 0f)
				{
					properties.Add(new Class2911(Enum426.const_92, (uint)(num * 65536f)));
				}
			}
			break;
		case GradientShape.Rectangle:
			properties.Add(new Class2911(Enum426.const_81, 5u));
			break;
		case GradientShape.Radial:
			serializationContext.method_15("Radial gradient is not implemented for saving to PPT yet.", WarningType.MajorFormattingLoss);
			break;
		case GradientShape.Path:
			properties.Add(new Class2911(Enum426.const_81, 6u));
			break;
		case GradientShape.NotDefined:
			break;
		}
		properties.Remove(Enum426.const_82);
		properties.Remove(Enum426.const_83);
		properties.Remove(Enum426.const_84);
		properties.Remove(Enum426.const_85);
		properties.Remove(Enum426.const_104);
		int count = gradientFormat.GradientStops.Count;
		bool flag = false;
		bool flag2 = false;
		if (count > 0)
		{
			Class1049.smethod_8(gradientFormat.GradientStops[0].Color, properties, Enum426.const_82, Enum426.const_83, serializationContext);
			Class1049.smethod_8(gradientFormat.GradientStops[count - 1].Color, properties, Enum426.const_84, Enum426.const_85, serializationContext);
			flag = gradientFormat.GradientStops[0].Position == 0f;
			flag2 = gradientFormat.GradientStops[count - 1].Position == 1f;
		}
		if (!flag || !flag2 || count != 2)
		{
			int num2 = (flag2 ? 1 : 0);
			int num3 = 0;
			Class2934 @class = new Class2934(Enum426.const_104, (ushort)(count - num2 - 0), 8);
			for (int i = 0; i < count - num2; i++)
			{
				@class[i - num3] = Class1049.smethod_7(gradientFormat.GradientStops[i - num3].Color, serializationContext) | ((ulong)(gradientFormat.GradientStops[i - num3].Position * 65536f) << 32);
			}
			properties.Add(@class);
		}
		properties.method_0(new Class2911(Enum426.const_93, 100u));
		properties.Remove(Enum426.const_94);
		properties.Remove(Enum426.const_95);
		properties.Remove(Enum426.const_96);
		properties.Remove(Enum426.const_97);
		if (gradientFormat.GradientShape == GradientShape.Rectangle)
		{
			Class1148 fillToRectangle = gradientFormat.FillToRectangle;
			properties.Add(new Class2911(Enum426.const_94, (uint)(fillToRectangle.X * 65536f)));
			properties.Add(new Class2911(Enum426.const_95, (uint)(fillToRectangle.Y * 65536f)));
			properties.Add(new Class2911(Enum426.const_96, (uint)((fillToRectangle.X + fillToRectangle.Width) * 65536f)));
			properties.Add(new Class2911(Enum426.const_97, (uint)((fillToRectangle.Y + fillToRectangle.Height) * 65536f)));
		}
		if (gradientFormat.TileFlip != 0 && gradientFormat.TileFlip != TileFlip.NotDefined)
		{
			serializationContext.method_15("Non default GradientFormat.TileFlip is not implemented for saving to PPT yet.", WarningType.MajorFormattingLoss);
		}
	}
}
