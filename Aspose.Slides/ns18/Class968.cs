using System;
using System.Collections.Generic;
using Aspose.Slides;
using ns56;

namespace ns18;

internal class Class968
{
	public static void smethod_0(ILineFormat lineFormat, Class1875 linePropertiesElementData)
	{
		if (linePropertiesElementData == null)
		{
			return;
		}
		Class967.smethod_0(lineFormat.FillFormat, linePropertiesElementData.LineFillProperties);
		Class2605 lineDashProperties = linePropertiesElementData.LineDashProperties;
		if (lineDashProperties != null)
		{
			switch (lineDashProperties.Name)
			{
			case "custDash":
			{
				Class1830 class2 = (Class1830)lineDashProperties.Object;
				lineFormat.DashStyle = LineDashStyle.Custom;
				List<float> list = new List<float>();
				Class1829[] dsList = class2.DsList;
				foreach (Class1829 class3 in dsList)
				{
					list.Add(class3.D / 100f);
					list.Add(class3.Sp / 100f);
				}
				lineFormat.CustomDashPattern = list.ToArray();
				break;
			}
			case "prstDash":
			{
				Class1909 @class = (Class1909)lineDashProperties.Object;
				lineFormat.DashStyle = @class.Val;
				break;
			}
			default:
				throw new Exception("Unknown element \"" + lineDashProperties.Name + "\"");
			}
		}
		else
		{
			lineFormat.DashStyle = LineDashStyle.NotDefined;
		}
		lineFormat.Width = linePropertiesElementData.W;
		lineFormat.CapStyle = linePropertiesElementData.Cap;
		lineFormat.Style = linePropertiesElementData.Cmpd;
		lineFormat.Alignment = linePropertiesElementData.Algn;
		Class2605 lineJoinProperties = linePropertiesElementData.LineJoinProperties;
		if (lineJoinProperties != null)
		{
			switch (lineJoinProperties.Name)
			{
			case "miter":
			{
				Class1873 class4 = (Class1873)lineJoinProperties.Object;
				lineFormat.JoinStyle = LineJoinStyle.Miter;
				lineFormat.MiterLimit = class4.Lim / 100f;
				break;
			}
			case "bevel":
				lineFormat.JoinStyle = LineJoinStyle.Bevel;
				break;
			case "round":
				lineFormat.JoinStyle = LineJoinStyle.Round;
				break;
			default:
				throw new Exception("Unknown element \"" + lineJoinProperties.Name + "\"");
			}
		}
		else
		{
			lineFormat.JoinStyle = LineJoinStyle.NotDefined;
		}
		if (linePropertiesElementData.HeadEnd != null)
		{
			lineFormat.BeginArrowheadStyle = linePropertiesElementData.HeadEnd.Type;
			lineFormat.BeginArrowheadWidth = linePropertiesElementData.HeadEnd.W;
			lineFormat.BeginArrowheadLength = linePropertiesElementData.HeadEnd.Len;
		}
		if (linePropertiesElementData.TailEnd != null)
		{
			lineFormat.EndArrowheadStyle = linePropertiesElementData.TailEnd.Type;
			lineFormat.EndArrowheadWidth = linePropertiesElementData.TailEnd.W;
			lineFormat.EndArrowheadLength = linePropertiesElementData.TailEnd.Len;
		}
	}

	public static void smethod_1(ILineFormat lineFormat, Class1875.Delegate1504 addLn)
	{
		if (lineFormat != null)
		{
			if (lineFormat.IsFormatNotDefined)
			{
				addLn().delegate2773_1("noFill");
			}
			else
			{
				smethod_2(lineFormat, addLn);
			}
		}
	}

	public static void smethod_2(ILineFormat lineFormat, Class1875.Delegate1504 addLn)
	{
		if (lineFormat != null && !lineFormat.IsFormatNotDefined)
		{
			smethod_3(lineFormat, addLn());
		}
	}

	public static void smethod_3(ILineFormat lineFormat, Class1875 linePropertiesElementData)
	{
		if (lineFormat == null || lineFormat.IsFormatNotDefined)
		{
			return;
		}
		Class967.smethod_1(lineFormat.FillFormat, linePropertiesElementData.delegate2773_1);
		if (lineFormat.DashStyle != LineDashStyle.NotDefined)
		{
			if (lineFormat.DashStyle != LineDashStyle.Custom)
			{
				Class1909 @class = (Class1909)linePropertiesElementData.delegate2773_0("prstDash").Object;
				@class.Val = lineFormat.DashStyle;
			}
			else
			{
				Class1830 class2 = (Class1830)linePropertiesElementData.delegate2773_0("custDash").Object;
				float[] customDashPattern = lineFormat.CustomDashPattern;
				if (customDashPattern != null)
				{
					if ((customDashPattern.Length & 1) == 1)
					{
						for (int i = 0; i < customDashPattern.Length * 2; i += 2)
						{
							Class1829 class3 = class2.delegate1366_0();
							class3.D = customDashPattern[i % customDashPattern.Length] * 100f;
							class3.Sp = customDashPattern[(i + 1) % customDashPattern.Length] * 100f;
						}
					}
					else
					{
						for (int j = 0; j < customDashPattern.Length; j += 2)
						{
							Class1829 class4 = class2.delegate1366_0();
							class4.D = customDashPattern[j] * 100f;
							class4.Sp = customDashPattern[j + 1] * 100f;
						}
					}
				}
			}
		}
		linePropertiesElementData.W = lineFormat.Width;
		linePropertiesElementData.Cap = lineFormat.CapStyle;
		linePropertiesElementData.Cmpd = lineFormat.Style;
		linePropertiesElementData.Algn = lineFormat.Alignment;
		switch (lineFormat.JoinStyle)
		{
		case LineJoinStyle.Round:
			linePropertiesElementData.delegate2773_2("round");
			break;
		case LineJoinStyle.Bevel:
			linePropertiesElementData.delegate2773_2("bevel");
			break;
		case LineJoinStyle.Miter:
		{
			Class1873 class5 = (Class1873)linePropertiesElementData.delegate2773_2("miter").Object;
			class5.Lim = lineFormat.MiterLimit * 100f;
			break;
		}
		}
		if (lineFormat.BeginArrowheadStyle != LineArrowheadStyle.NotDefined)
		{
			Class1871 class6 = linePropertiesElementData.delegate1492_0();
			class6.Type = lineFormat.BeginArrowheadStyle;
			class6.W = lineFormat.BeginArrowheadWidth;
			class6.Len = lineFormat.BeginArrowheadLength;
		}
		if (lineFormat.EndArrowheadStyle != LineArrowheadStyle.NotDefined)
		{
			Class1871 class7 = linePropertiesElementData.delegate1492_1();
			class7.Type = lineFormat.EndArrowheadStyle;
			class7.W = lineFormat.EndArrowheadWidth;
			class7.Len = lineFormat.EndArrowheadLength;
		}
	}
}
