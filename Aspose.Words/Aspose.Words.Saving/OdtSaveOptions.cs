using System;

namespace Aspose.Words.Saving;

public class OdtSaveOptions : SaveOptions
{
	private SaveFormat xdeadbdaa7eaefd95;

	private bool xedb98e95c6eb432c;

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

	public bool IsStrictSchema11
	{
		get
		{
			return xedb98e95c6eb432c;
		}
		set
		{
			xedb98e95c6eb432c = value;
		}
	}

	public OdtSaveOptions()
		: this(SaveFormat.Odt)
	{
	}

	public OdtSaveOptions(SaveFormat saveFormat)
	{
		x144c0b7717868eb8(saveFormat);
	}

	private void x144c0b7717868eb8(SaveFormat xd003f66121eb36a0)
	{
		switch (xd003f66121eb36a0)
		{
		case SaveFormat.Odt:
		case SaveFormat.Ott:
			xdeadbdaa7eaefd95 = xd003f66121eb36a0;
			break;
		default:
			throw new ArgumentException("An invalid SaveFormat for this options type was chosen.");
		}
	}
}
