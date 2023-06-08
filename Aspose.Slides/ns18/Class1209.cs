using System.Xml;
using Aspose.Slides;
using Aspose.Slides.Theme;
using ns16;
using ns24;
using ns53;
using ns56;

namespace ns18;

internal class Class1209 : Class1188
{
	internal void method_5(IPresentation presentation)
	{
		method_0();
		while (base.XmlPartReader.Read())
		{
			if (base.XmlPartReader.NodeType == XmlNodeType.Element && base.XmlPartReader.LocalName == "theme")
			{
				method_7(presentation.MasterTheme);
				base.DeserializationContext.ThemePartToTheme.Add(base.Part, presentation.MasterTheme);
			}
		}
		method_2();
	}

	internal void method_6(IMasterThemeManager themeManager)
	{
		if (!base.DeserializationContext.ThemePartToTheme.ContainsKey(base.Part))
		{
			method_0();
			while (base.XmlPartReader.Read())
			{
				if (base.XmlPartReader.NodeType == XmlNodeType.Element && base.XmlPartReader.LocalName == "theme")
				{
					method_7(themeManager.OverrideTheme);
					base.DeserializationContext.ThemePartToTheme.Add(base.Part, themeManager.OverrideTheme);
					themeManager.IsOverrideThemeEnabled = true;
				}
			}
			method_2();
		}
		else
		{
			themeManager.OverrideTheme = (IMasterTheme)base.DeserializationContext.ThemePartToTheme[base.Part];
		}
	}

	private void method_7(IMasterTheme theme)
	{
		Class2318 @class = new Class2318(base.XmlPartReader);
		smethod_0(theme, @class);
		theme.Name = @class.Name;
		Class932.smethod_0(theme.ColorScheme, @class.ThemeElements.ClrScheme);
		Class951.smethod_0(theme.FontScheme, @class.ThemeElements.FontScheme);
		Class953.smethod_0(theme.FormatScheme, @class.ThemeElements.FmtScheme, base.DeserializationContext);
		if (@class.ExtraClrSchemeLst != null)
		{
			Class1818[] extraClrSchemeList = @class.ExtraClrSchemeLst.ExtraClrSchemeList;
			foreach (Class1818 extraColorSchemeElementData in extraClrSchemeList)
			{
				IExtraColorScheme extraColorScheme = ((ExtraColorSchemeCollection)theme.ExtraColorSchemes).Add(theme);
				Class948.smethod_0(extraColorScheme, extraColorSchemeElementData);
			}
		}
	}

	private static void smethod_0(IMasterTheme theme, Class2318 themeElementData)
	{
		Class358 pPTXUnsupportedProps = ((MasterTheme)theme).PPTXUnsupportedProps;
		pPTXUnsupportedProps.ObjectDefaults = themeElementData.ObjectDefaults;
		pPTXUnsupportedProps.CustomColors = themeElementData.CustClrLst;
		pPTXUnsupportedProps.ExtensionList = themeElementData.ExtLst;
		pPTXUnsupportedProps.ExtensionListOfThemeElements = themeElementData.ThemeElements.ExtLst;
	}

	internal void method_8(IPresentation presentation)
	{
		method_3();
		Class2318 @class = method_10(presentation.MasterTheme);
		@class.vmethod_4(null, base.XmlPartWriter, "theme");
		method_4();
	}

	internal void method_9(IMasterTheme masterTheme)
	{
		method_3();
		Class2318 @class = method_10(masterTheme);
		@class.vmethod_4(null, base.XmlPartWriter, "theme");
		method_4();
	}

	private Class2318 method_10(IMasterTheme theme)
	{
		Class2318 @class = new Class2318();
		@class.Name = theme.Name;
		Class932.smethod_1(theme.ColorScheme, @class.ThemeElements.ClrScheme);
		Class951.smethod_1(theme.FontScheme, @class.ThemeElements.FontScheme);
		Class953.smethod_1(theme.FormatScheme, @class.ThemeElements.FmtScheme, base.SerializationContext);
		if (theme.ExtraColorSchemes.Count > 0)
		{
			Class1820 class2 = @class.delegate1339_0();
			foreach (IExtraColorScheme extraColorScheme in theme.ExtraColorSchemes)
			{
				Class948.smethod_1(extraColorScheme, class2.delegate1333_0);
			}
		}
		smethod_1(theme, @class);
		return @class;
	}

	private static void smethod_1(IMasterTheme theme, Class2318 themeElementData)
	{
		Class358 pPTXUnsupportedProps = ((MasterTheme)theme).PPTXUnsupportedProps;
		themeElementData.delegate304_0(pPTXUnsupportedProps.ObjectDefaults);
		themeElementData.delegate1362_0(pPTXUnsupportedProps.CustomColors);
		themeElementData.delegate1535_0(pPTXUnsupportedProps.ExtensionList);
		themeElementData.ThemeElements.delegate1535_0(pPTXUnsupportedProps.ExtensionListOfThemeElements);
	}

	public Class1209(Class1342 part, Class1341 deserializationContext)
		: base(part, deserializationContext)
	{
	}

	public Class1209(Class1342 part, Class1346 serializationContext)
		: base(part, serializationContext)
	{
	}
}
