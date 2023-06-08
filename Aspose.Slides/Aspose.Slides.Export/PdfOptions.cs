using System;
using System.Runtime.InteropServices;
using ns12;
using ns224;
using ns237;

namespace Aspose.Slides.Export;

[ClassInterface(ClassInterfaceType.None)]
[Guid("9ba5ca66-8a94-4dcd-ae43-f9d3085f02fc")]
[ComVisible(true)]
public class PdfOptions : SaveOptions, ISaveOptions, IPdfOptions
{
	private PdfTextCompression pdfTextCompression_0;

	private bool bool_0;

	private bool bool_1;

	private int int_0;

	private PdfCompliance pdfCompliance_0;

	private bool bool_2;

	private string[] string_0;

	private string string_1;

	private float float_0;

	internal static string[] string_2 = new string[8] { "Arial", "Helvetica", "Times", "Times New Roman", "Courier", "Courier New", "Symbol", "Zapf Dingbats" };

	public PdfTextCompression TextCompression
	{
		get
		{
			return pdfTextCompression_0;
		}
		set
		{
			pdfTextCompression_0 = value;
		}
	}

	public bool EmbedTrueTypeFontsForASCII
	{
		get
		{
			return bool_0;
		}
		set
		{
			bool_0 = value;
		}
	}

	public string[] AdditionalCommonFontFamilies
	{
		get
		{
			if (string_0 == null)
			{
				return null;
			}
			return (string[])string_0.Clone();
		}
		set
		{
			if (value == null)
			{
				string_0 = null;
			}
			else
			{
				string_0 = (string[])value.Clone();
			}
		}
	}

	public bool EmbedFullFonts
	{
		get
		{
			return bool_1;
		}
		set
		{
			bool_1 = value;
		}
	}

	public byte JpegQuality
	{
		get
		{
			return (byte)int_0;
		}
		set
		{
			if (value < 0 || value > 100)
			{
				throw new ArgumentOutOfRangeException("value", "JpegQuality value must be between 0 and 100.");
			}
			int_0 = value;
		}
	}

	public PdfCompliance Compliance
	{
		get
		{
			return pdfCompliance_0;
		}
		set
		{
			pdfCompliance_0 = value;
		}
	}

	public string Password
	{
		get
		{
			return string_1;
		}
		set
		{
			string_1 = value;
		}
	}

	public bool SaveMetafilesAsPng
	{
		get
		{
			return bool_2;
		}
		set
		{
			bool_2 = value;
		}
	}

	public float SufficientResolution
	{
		get
		{
			return float_0;
		}
		set
		{
			float_0 = value;
		}
	}

	ISaveOptions IPdfOptions.AsISaveOptions => this;

	public PdfOptions()
	{
		pdfTextCompression_0 = PdfTextCompression.Flate;
		bool_0 = true;
		bool_1 = false;
		int_0 = 100;
		pdfCompliance_0 = PdfCompliance.Pdf15;
		bool_2 = true;
		float_0 = 96f;
	}

	internal Class6680 method_0()
	{
		return method_1(null);
	}

	internal Class6680 method_1(ISaveOptions saveOptions)
	{
		Class6680 @class = new Class6680();
		@class.ErrorHandler = new Class183(saveOptions);
		@class.ImageTransparentColor = Class5998.class5998_140;
		@class.ApplyImageTransparent = true;
		@class.TextCompression = ((TextCompression == PdfTextCompression.Flate) ? Enum890.const_3 : Enum890.const_0);
		@class.ImageCompression = Enum891.const_0;
		@class.JpegQuality = JpegQuality;
		@class.Compliance = ((Compliance != 0) ? Enum883.const_2 : Enum883.const_0);
		if (string_1 != null && string_1.Trim() != "")
		{
			@class.EncryptionDetails = new Class6510(string_1, null, 0, Enum871.const_1);
		}
		if (Compliance != PdfCompliance.PdfA1b)
		{
			@class.FontEmbeddingRule = (EmbedFullFonts ? Enum872.flag_2 : Enum872.flag_1);
			if (!EmbedTrueTypeFontsForASCII)
			{
				Enum872 @enum = Enum872.flag_0;
				if (EmbedFullFonts)
				{
					@enum |= Enum872.flag_2;
				}
				for (int i = 0; i < string_2.Length; i++)
				{
					@class.FontException.Add(string_2[i], @enum);
				}
				if (string_0 != null)
				{
					for (int j = 0; j < string_0.Length; j++)
					{
						if (string_0[j] != null && string_0[j] != "")
						{
							@class.FontException.Add(string_0[j], @enum);
						}
					}
				}
			}
		}
		@class.FontException["Batang"] = Enum872.flag_2;
		@class.FontException["BatangChe"] = Enum872.flag_2;
		@class.FontException["GulimChe"] = Enum872.flag_2;
		return @class;
	}
}
