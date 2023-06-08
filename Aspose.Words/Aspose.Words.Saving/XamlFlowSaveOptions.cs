using System;
using x6c95d9cf46ff5f25;

namespace Aspose.Words.Saving;

public class XamlFlowSaveOptions : SaveOptions
{
	private SaveFormat xdeadbdaa7eaefd95;

	private string x282240c41fd6d480 = string.Empty;

	private string xb21f9ec81fe60f6f = string.Empty;

	private IImageSavingCallback xc14caec69d8d0393;

	public override SaveFormat SaveFormat
	{
		get
		{
			return xdeadbdaa7eaefd95;
		}
		set
		{
			x144c0b7717868eb8(value);
		}
	}

	public string ImagesFolder
	{
		get
		{
			return x282240c41fd6d480;
		}
		set
		{
			x0d299f323d241756.x0aaaea7864a53f26(value, "ImagesFolder");
			x282240c41fd6d480 = value;
		}
	}

	public string ImagesFolderAlias
	{
		get
		{
			return xb21f9ec81fe60f6f;
		}
		set
		{
			x0d299f323d241756.x0aaaea7864a53f26(value, "ImagesFolderAlias");
			xb21f9ec81fe60f6f = value;
		}
	}

	public IImageSavingCallback ImageSavingCallback
	{
		get
		{
			return xc14caec69d8d0393;
		}
		set
		{
			xc14caec69d8d0393 = value;
		}
	}

	public XamlFlowSaveOptions()
		: this(SaveFormat.XamlFlow)
	{
	}

	public XamlFlowSaveOptions(SaveFormat saveFormat)
	{
		x144c0b7717868eb8(saveFormat);
	}

	private void x144c0b7717868eb8(SaveFormat xd003f66121eb36a0)
	{
		switch (xd003f66121eb36a0)
		{
		case SaveFormat.XamlFlow:
		case SaveFormat.XamlFlowPack:
			xdeadbdaa7eaefd95 = xd003f66121eb36a0;
			break;
		default:
			throw new ArgumentException("An invalid SaveFormat for this options type was chosen.");
		}
	}
}
