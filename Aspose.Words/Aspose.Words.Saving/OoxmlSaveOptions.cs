using System;

namespace Aspose.Words.Saving;

public class OoxmlSaveOptions : SaveOptions
{
	private SaveFormat xdeadbdaa7eaefd95;

	private OoxmlCompliance x38f73f642a5eb695;

	private bool x8b73f0d37b611222;

	private bool x163e2a9241b3a230 = true;

	private string x43bfbd3c83649bc6;

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

	public OoxmlCompliance Compliance
	{
		get
		{
			return x38f73f642a5eb695;
		}
		set
		{
			x38f73f642a5eb695 = value;
		}
	}

	internal bool x351d5c790f4a6545
	{
		get
		{
			return x8b73f0d37b611222;
		}
		set
		{
			x8b73f0d37b611222 = value;
		}
	}

	internal bool x5dd57fb93ce7c3d8
	{
		get
		{
			return x163e2a9241b3a230;
		}
		set
		{
			x163e2a9241b3a230 = value;
		}
	}

	public OoxmlSaveOptions()
		: this(SaveFormat.Docx)
	{
	}

	public OoxmlSaveOptions(SaveFormat saveFormat)
	{
		x144c0b7717868eb8(saveFormat);
	}

	internal override void x392c33ba8e976198()
	{
		base.x392c33ba8e976198();
		x5dd57fb93ce7c3d8 = false;
	}

	private void x144c0b7717868eb8(SaveFormat xd003f66121eb36a0)
	{
		switch (xd003f66121eb36a0)
		{
		case SaveFormat.Docx:
		case SaveFormat.Docm:
		case SaveFormat.Dotx:
		case SaveFormat.Dotm:
		case SaveFormat.FlatOpc:
		case SaveFormat.FlatOpcMacroEnabled:
		case SaveFormat.FlatOpcTemplate:
		case SaveFormat.FlatOpcTemplateMacroEnabled:
			xdeadbdaa7eaefd95 = xd003f66121eb36a0;
			break;
		default:
			throw new ArgumentException("An invalid SaveFormat for this options type was chosen.");
		}
	}
}
