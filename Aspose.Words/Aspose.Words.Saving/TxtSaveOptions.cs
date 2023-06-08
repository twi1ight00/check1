using System;
using System.Text;
using x6c95d9cf46ff5f25;

namespace Aspose.Words.Saving;

public class TxtSaveOptions : SaveOptions
{
	private bool xf2216c4f5f526782 = true;

	private Encoding xcce637b6f486a407 = Encoding.UTF8;

	private string xb6c4489b7aadd758 = ControlChar.CrLf;

	private bool x7725a61955bc9e68;

	private bool x2d3fc14e83d9a3e4;

	public override SaveFormat SaveFormat
	{
		get
		{
			return SaveFormat.Text;
		}
		set
		{
			if (value != SaveFormat.Text)
			{
				throw new ArgumentException("An invalid SaveFormat for this options type was chosen.");
			}
		}
	}

	public bool ExportHeadersFooters
	{
		get
		{
			return xf2216c4f5f526782;
		}
		set
		{
			xf2216c4f5f526782 = value;
		}
	}

	public Encoding Encoding
	{
		get
		{
			return xcce637b6f486a407;
		}
		set
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			xcce637b6f486a407 = value;
		}
	}

	public string ParagraphBreak
	{
		get
		{
			return xb6c4489b7aadd758;
		}
		set
		{
			x0d299f323d241756.x0aaaea7864a53f26(value, "ParagraphBreak");
			xb6c4489b7aadd758 = value;
		}
	}

	public bool PreserveTableLayout
	{
		get
		{
			return x7725a61955bc9e68;
		}
		set
		{
			x7725a61955bc9e68 = value;
		}
	}

	public bool SimplifyListLabels
	{
		get
		{
			return x2d3fc14e83d9a3e4;
		}
		set
		{
			x2d3fc14e83d9a3e4 = value;
		}
	}
}
