using System;
using Aspose.Slides;
using Aspose.Slides.Theme;
using ns25;
using ns56;
using ns9;

namespace ns18;

internal class Class931
{
	public static void smethod_0(Class288 chartUnsupported, Class1815 colorMappingElementData)
	{
		smethod_4(chartUnsupported.ColorMappingOverride, colorMappingElementData);
	}

	public static void smethod_1(IThemeManager themeManager, Class1815 colorMappingElementData)
	{
		smethod_4(((BaseThemeManager)themeManager).ColorMappingOverride, colorMappingElementData);
	}

	public static void smethod_2(IThemeManager themeManager, Class1816 colorMappingOverrideElementData)
	{
		smethod_3(((BaseThemeManager)themeManager).ColorMappingOverride, colorMappingOverrideElementData);
	}

	private static void smethod_3(Class153 colorMappingOverride, Class1816 colorMappingOverrideElementData)
	{
		colorMappingOverride.On = false;
		if (colorMappingOverrideElementData != null && colorMappingOverrideElementData.ColorMappingOverride != null)
		{
			switch (colorMappingOverrideElementData.ColorMappingOverride.Name)
			{
			case "overrideClrMapping":
			{
				Class1815 colorMappingElementData = (Class1815)colorMappingOverrideElementData.ColorMappingOverride.Object;
				smethod_4(colorMappingOverride, colorMappingElementData);
				break;
			}
			default:
				throw new Exception("Unknown element \"" + colorMappingOverrideElementData.ColorMappingOverride.Name + "\"");
			case "masterClrMapping":
				break;
			}
		}
	}

	internal static void smethod_4(Class153 colorMapping, Class1815 colorMappingElementData)
	{
		colorMapping.On = false;
		if (colorMappingElementData != null)
		{
			colorMapping.On = true;
			colorMapping.ExtensionList = colorMappingElementData.ExtLst;
			colorMapping.method_2(SchemeColor.Background1, colorMappingElementData.Bg1);
			colorMapping.method_2(SchemeColor.Text1, colorMappingElementData.Tx1);
			colorMapping.method_2(SchemeColor.Background2, colorMappingElementData.Bg2);
			colorMapping.method_2(SchemeColor.Text2, colorMappingElementData.Tx2);
			colorMapping.method_2(SchemeColor.Accent1, colorMappingElementData.Accent1);
			colorMapping.method_2(SchemeColor.Accent2, colorMappingElementData.Accent2);
			colorMapping.method_2(SchemeColor.Accent3, colorMappingElementData.Accent3);
			colorMapping.method_2(SchemeColor.Accent4, colorMappingElementData.Accent4);
			colorMapping.method_2(SchemeColor.Accent5, colorMappingElementData.Accent5);
			colorMapping.method_2(SchemeColor.Accent6, colorMappingElementData.Accent6);
			colorMapping.method_2(SchemeColor.Hyperlink, colorMappingElementData.Hlink);
			colorMapping.method_2(SchemeColor.FollowedHyperlink, colorMappingElementData.FolHlink);
		}
	}

	public static void smethod_5(IThemeManager themeManager, Class1815 colorMappingElementData)
	{
		smethod_10(((BaseThemeManager)themeManager).ColorMappingOverride, colorMappingElementData);
	}

	public static void smethod_6(IThemeManager themeManager, Class1816.Delegate1327 addClrMapOvr)
	{
		if (((BaseThemeManager)themeManager).ColorMappingOverride.On)
		{
			Class1816 colorMappingOverrideElementData = addClrMapOvr();
			smethod_7(((BaseThemeManager)themeManager).ColorMappingOverride, colorMappingOverrideElementData);
		}
	}

	internal static void smethod_7(Class153 colorMappingOverride, Class1816 colorMappingOverrideElementData)
	{
		if (colorMappingOverride != null && colorMappingOverride.On)
		{
			Class1815 colorMappingElementData = (Class1815)colorMappingOverrideElementData.delegate2773_0("overrideClrMapping").Object;
			smethod_10(colorMappingOverride, colorMappingElementData);
		}
		else
		{
			colorMappingOverrideElementData.delegate2773_0("masterClrMapping");
		}
	}

	public static void smethod_8(Class288 chartUnsupported, Class1815.Delegate1324 addClrMap)
	{
		if (chartUnsupported.ColorMappingOverride.On)
		{
			Class1815 colorMappingElementData = addClrMap();
			smethod_10(chartUnsupported.ColorMappingOverride, colorMappingElementData);
		}
	}

	internal static void smethod_9(Class153 colorMapping, Class1815.Delegate1324 addClrMap)
	{
		if (colorMapping.On)
		{
			Class1815 colorMappingElementData = addClrMap();
			smethod_10(colorMapping, colorMappingElementData);
		}
	}

	internal static void smethod_10(Class153 colorMapping, Class1815 colorMappingElementData)
	{
		colorMappingElementData.delegate1535_0(colorMapping.ExtensionList);
		colorMappingElementData.Bg1 = colorMapping.method_1(SchemeColor.Background1);
		colorMappingElementData.Tx1 = colorMapping.method_1(SchemeColor.Text1);
		colorMappingElementData.Bg2 = colorMapping.method_1(SchemeColor.Background2);
		colorMappingElementData.Tx2 = colorMapping.method_1(SchemeColor.Text2);
		colorMappingElementData.Accent1 = colorMapping.method_1(SchemeColor.Accent1);
		colorMappingElementData.Accent2 = colorMapping.method_1(SchemeColor.Accent2);
		colorMappingElementData.Accent3 = colorMapping.method_1(SchemeColor.Accent3);
		colorMappingElementData.Accent4 = colorMapping.method_1(SchemeColor.Accent4);
		colorMappingElementData.Accent5 = colorMapping.method_1(SchemeColor.Accent5);
		colorMappingElementData.Accent6 = colorMapping.method_1(SchemeColor.Accent6);
		colorMappingElementData.Hlink = colorMapping.method_1(SchemeColor.Hyperlink);
		colorMappingElementData.FolHlink = colorMapping.method_1(SchemeColor.FollowedHyperlink);
	}
}
