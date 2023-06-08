using System;

namespace Aspose.Words.Saving;

public class RtfSaveOptions : SaveOptions
{
	private bool x1b402ceae249fea8;

	private bool xe7e65414cfdebcab = true;

	public override SaveFormat SaveFormat
	{
		get
		{
			return SaveFormat.Rtf;
		}
		set
		{
			if (value != SaveFormat.Rtf)
			{
				throw new ArgumentException("An invalid SaveFormat for this options type was chosen.");
			}
		}
	}

	public bool ExportCompactSize
	{
		get
		{
			return x1b402ceae249fea8;
		}
		set
		{
			x1b402ceae249fea8 = value;
		}
	}

	public bool ExportImagesForOldReaders
	{
		get
		{
			return xe7e65414cfdebcab;
		}
		set
		{
			xe7e65414cfdebcab = value;
		}
	}

	internal override void x392c33ba8e976198()
	{
		base.x392c33ba8e976198();
		ExportImagesForOldReaders = false;
	}
}
