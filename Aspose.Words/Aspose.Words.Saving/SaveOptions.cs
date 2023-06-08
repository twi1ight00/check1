using System;
using System.IO;
using x6c95d9cf46ff5f25;

namespace Aspose.Words.Saving;

public abstract class SaveOptions
{
	private bool x8023b58a0a7e4812;

	private bool xead5686b9edac889 = true;

	private bool x1ac26385458f9175;

	private string xf5e0ee752f83f28a;

	private bool x3601dffc481e0ac5;

	private bool xcd4fe3c73ca3fbc2;

	private IWarningCallback xa056586c1f99e199;

	internal bool x3d42c161dd5cf126
	{
		get
		{
			return x8023b58a0a7e4812;
		}
		set
		{
			x8023b58a0a7e4812 = value;
		}
	}

	public abstract SaveFormat SaveFormat { get; set; }

	internal virtual bool x49451109f9415aa0 => false;

	internal virtual bool xda76bf558c43e688 => true;

	internal bool xbfa4c2c3efbf56fd
	{
		get
		{
			return xead5686b9edac889;
		}
		set
		{
			xead5686b9edac889 = value;
		}
	}

	public string TempFolder
	{
		get
		{
			return xf5e0ee752f83f28a;
		}
		set
		{
			xf5e0ee752f83f28a = value;
		}
	}

	public bool PrettyFormat
	{
		get
		{
			return x1ac26385458f9175;
		}
		set
		{
			x1ac26385458f9175 = value;
		}
	}

	public bool UseAntiAliasing
	{
		get
		{
			return x3601dffc481e0ac5;
		}
		set
		{
			x3601dffc481e0ac5 = value;
		}
	}

	public bool UseHighQualityRendering
	{
		get
		{
			return xcd4fe3c73ca3fbc2;
		}
		set
		{
			xcd4fe3c73ca3fbc2 = value;
		}
	}

	public IWarningCallback WarningCallback
	{
		get
		{
			return xa056586c1f99e199;
		}
		set
		{
			xa056586c1f99e199 = value;
		}
	}

	internal virtual void x392c33ba8e976198()
	{
		x3d42c161dd5cf126 = true;
		PrettyFormat = true;
		xbfa4c2c3efbf56fd = false;
	}

	public static SaveOptions CreateSaveOptions(SaveFormat saveFormat)
	{
		switch (saveFormat)
		{
		case SaveFormat.Doc:
		case SaveFormat.Dot:
			return new DocSaveOptions(saveFormat);
		case SaveFormat.Docx:
		case SaveFormat.Docm:
		case SaveFormat.Dotx:
		case SaveFormat.Dotm:
		case SaveFormat.FlatOpc:
		case SaveFormat.FlatOpcMacroEnabled:
		case SaveFormat.FlatOpcTemplate:
		case SaveFormat.FlatOpcTemplateMacroEnabled:
			return new OoxmlSaveOptions(saveFormat);
		case SaveFormat.Rtf:
			return new RtfSaveOptions();
		case SaveFormat.WordML:
			return new WordML2003SaveOptions();
		case SaveFormat.Pdf:
			return new PdfSaveOptions();
		case SaveFormat.Xps:
			return new XpsSaveOptions();
		case SaveFormat.XamlFixed:
			return new XamlFixedSaveOptions();
		case SaveFormat.Swf:
			return new SwfSaveOptions();
		case SaveFormat.Svg:
			return new SvgSaveOptions();
		case SaveFormat.Html:
		case SaveFormat.Mhtml:
		case SaveFormat.Epub:
			return new HtmlSaveOptions(saveFormat);
		case SaveFormat.Odt:
		case SaveFormat.Ott:
			return new OdtSaveOptions(saveFormat);
		case SaveFormat.Text:
			return new TxtSaveOptions();
		case SaveFormat.XamlFlow:
			return new XamlFlowSaveOptions();
		case SaveFormat.XamlFlowPack:
			return new XamlFlowSaveOptions(saveFormat);
		case SaveFormat.Tiff:
		case SaveFormat.Png:
		case SaveFormat.Bmp:
		case SaveFormat.Emf:
		case SaveFormat.Jpeg:
			return new ImageSaveOptions(saveFormat);
		default:
			throw new ArgumentException("Invalid save format requested.");
		}
	}

	public static SaveOptions CreateSaveOptions(string fileName)
	{
		return CreateSaveOptions(FileFormatUtil.x9ac6b4aed1d86203(xb9015fe823e7e228.x0f2906e6dae0813a(Path.GetExtension(fileName))));
	}
}
