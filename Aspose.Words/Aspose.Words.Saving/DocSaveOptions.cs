using System;

namespace Aspose.Words.Saving;

public class DocSaveOptions : SaveOptions
{
	private string x43bfbd3c83649bc6;

	private SaveFormat xdeadbdaa7eaefd95;

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

	public string Password
	{
		get
		{
			return x43bfbd3c83649bc6;
		}
		set
		{
			x43bfbd3c83649bc6 = value;
		}
	}

	public DocSaveOptions()
		: this(SaveFormat.Doc)
	{
	}

	public DocSaveOptions(SaveFormat saveFormat)
	{
		x144c0b7717868eb8(saveFormat);
	}

	private void x144c0b7717868eb8(SaveFormat xd003f66121eb36a0)
	{
		switch (xd003f66121eb36a0)
		{
		case SaveFormat.Doc:
		case SaveFormat.Dot:
			xdeadbdaa7eaefd95 = xd003f66121eb36a0;
			break;
		default:
			throw new ArgumentException("An invalid SaveFormat for this options type was chosen.");
		}
	}
}
