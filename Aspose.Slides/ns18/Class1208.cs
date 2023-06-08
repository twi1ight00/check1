using System.Xml;
using Aspose.Slides.Theme;
using ns16;
using ns53;
using ns56;

namespace ns18;

internal class Class1208 : Class1188
{
	internal void method_5(IOverrideThemeManager themeOverrideManager)
	{
		if (!base.DeserializationContext.ThemePartToTheme.ContainsKey(base.Part))
		{
			method_0();
			while (base.XmlPartReader.Read())
			{
				if (base.XmlPartReader.NodeType == XmlNodeType.Element && base.XmlPartReader.LocalName == "themeOverride")
				{
					Class2319 @class = new Class2319(base.XmlPartReader);
					IOverrideTheme overrideTheme = themeOverrideManager.OverrideTheme;
					base.DeserializationContext.ThemePartToTheme.Add(base.Part, overrideTheme);
					if (@class.ClrScheme != null)
					{
						((OverrideTheme)overrideTheme).InitColorScheme();
						Class932.smethod_0(overrideTheme.ColorScheme, @class.ClrScheme);
					}
					if (@class.FontScheme != null)
					{
						((OverrideTheme)overrideTheme).InitFontScheme();
						Class951.smethod_0(overrideTheme.FontScheme, @class.FontScheme);
					}
					if (@class.FmtScheme != null)
					{
						((OverrideTheme)overrideTheme).InitFormatScheme();
						Class953.smethod_0(overrideTheme.FormatScheme, @class.FmtScheme, base.DeserializationContext);
					}
				}
			}
			method_2();
		}
		else
		{
			themeOverrideManager.OverrideTheme = (IOverrideTheme)base.DeserializationContext.ThemePartToTheme[base.Part];
			base.Part.Processed = true;
		}
	}

	internal void method_6(IOverrideTheme overrideTheme)
	{
		method_3();
		Class2319 @class = new Class2319();
		Class932.smethod_2(overrideTheme.ColorScheme, @class.delegate1336_0);
		Class951.smethod_2(overrideTheme.FontScheme, @class.delegate1420_0);
		Class953.smethod_2(overrideTheme.FormatScheme, @class.delegate1651_0, base.SerializationContext);
		@class.vmethod_4(null, base.XmlPartWriter, "themeOverride");
		method_4();
	}

	public Class1208(Class1342 part, Class1341 deserializationContext)
		: base(part, deserializationContext)
	{
	}

	public Class1208(Class1342 part, Class1346 serializationContext)
		: base(part, serializationContext)
	{
	}
}
