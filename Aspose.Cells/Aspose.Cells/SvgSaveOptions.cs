namespace Aspose.Cells;

public class SvgSaveOptions : ImageSaveOptions
{
	private int int_0 = -1;

	public int SheetIndex
	{
		get
		{
			return int_0;
		}
		set
		{
			int_0 = value;
		}
	}

	public SvgSaveOptions()
		: base(SaveFormat.SVG)
	{
	}

	public SvgSaveOptions(SaveFormat saveFormat)
		: base(SaveFormat.SVG)
	{
		m_SaveFormat = saveFormat;
	}

	internal static SvgSaveOptions smethod_1(SaveOptions saveOptions_0)
	{
		if (saveOptions_0 is SvgSaveOptions)
		{
			return (SvgSaveOptions)saveOptions_0;
		}
		SvgSaveOptions svgSaveOptions = new SvgSaveOptions();
		if (saveOptions_0 is ImageSaveOptions)
		{
			ImageSaveOptions imageSaveOptions_ = (ImageSaveOptions)saveOptions_0;
			svgSaveOptions.Copy(imageSaveOptions_);
			svgSaveOptions.ImageOrPrintOptions.SaveFormat = SaveFormat.SVG;
		}
		return svgSaveOptions;
	}
}
