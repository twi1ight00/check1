using System.Xml;
using Aspose.Slides.Charts;
using ns21;
using ns34;
using ns53;
using ns56;

namespace ns20;

internal class Class1221 : Class1216
{
	internal void method_5(ChartDataWorkbook workbook)
	{
		method_0();
		while (base.XmlPartReader.Read())
		{
			if (base.XmlPartReader.NodeType == XmlNodeType.Element && base.XmlPartReader.LocalName == "styleSheet")
			{
				Class1709 @class = new Class1709(base.XmlPartReader);
				workbook.class805_0 = new Class805(workbook);
				Class254.smethod_0(workbook.class805_0, @class.NumFmts);
				workbook.class737_0 = new Class737(workbook);
				Class252.smethod_0(workbook.class737_0, @class.CellXfs);
				Class802 stylesPartXLSXUnsupportedProps = workbook.StylesPartXLSXUnsupportedProps;
				stylesPartXLSXUnsupportedProps.Borders = @class.Borders;
				stylesPartXLSXUnsupportedProps.CellStyleXfs = @class.CellStyleXfs;
				stylesPartXLSXUnsupportedProps.CellStyles = @class.CellStyles;
				stylesPartXLSXUnsupportedProps.Colors = @class.Colors;
				stylesPartXLSXUnsupportedProps.Dxfs = @class.Dxfs;
				stylesPartXLSXUnsupportedProps.Fills = @class.Fills;
				stylesPartXLSXUnsupportedProps.Fonts = @class.Fonts;
				stylesPartXLSXUnsupportedProps.TableStyles = @class.TableStyles;
				stylesPartXLSXUnsupportedProps.ExtLst = @class.ExtLst;
			}
		}
		method_2();
	}

	internal void method_6(ChartDataWorkbook workbook)
	{
		method_3();
		Class1709 @class = new Class1709();
		if (workbook.class805_0.Count > 0)
		{
			Class254.smethod_1(workbook.class805_0, @class.delegate661_0());
		}
		if (workbook.class737_0.Count > 0)
		{
			if (workbook.StylesPartXLSXUnsupportedProps.CellStyleXfs == null)
			{
				workbook.StylesPartXLSXUnsupportedProps.CellStyleXfs = new Class1402();
			}
			Class1405 cellXfsElementData = @class.delegate177_0();
			Class252.smethod_1(workbook.class737_0, cellXfsElementData);
		}
		Class802 stylesPartXLSXUnsupportedProps = workbook.StylesPartXLSXUnsupportedProps;
		@class.delegate101_0(stylesPartXLSXUnsupportedProps.Borders);
		@class.delegate170_0(stylesPartXLSXUnsupportedProps.CellStyleXfs);
		@class.delegate167_0(stylesPartXLSXUnsupportedProps.CellStyles);
		@class.delegate230_0(stylesPartXLSXUnsupportedProps.Colors);
		@class.delegate376_0(stylesPartXLSXUnsupportedProps.Dxfs);
		@class.delegate450_0(stylesPartXLSXUnsupportedProps.Fills);
		@class.delegate471_0(stylesPartXLSXUnsupportedProps.Fonts);
		@class.delegate1044_0(stylesPartXLSXUnsupportedProps.TableStyles);
		@class.delegate387_0(stylesPartXLSXUnsupportedProps.ExtLst);
		@class.vmethod_4(null, base.XmlPartWriter, "styleSheet");
		method_4();
	}

	public Class1221(Class1342 part, Class1340 deserializationContext)
		: base(part, deserializationContext)
	{
	}

	public Class1221(Class1342 part, Class1345 serializationContext)
		: base(part, serializationContext)
	{
	}
}
