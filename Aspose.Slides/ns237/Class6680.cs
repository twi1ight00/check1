using System;
using ns218;
using ns224;
using ns235;

namespace ns237;

internal class Class6680
{
	private Class6559 class6559_0;

	private Class6510 class6510_0;

	private int int_0;

	private int int_1;

	private int int_2;

	private Enum890 enum890_0 = Enum890.const_3;

	private Enum891 enum891_0;

	private int int_3 = 95;

	private bool bool_0;

	private Enum883 enum883_0;

	private bool bool_1;

	private bool bool_2;

	private bool bool_3 = true;

	private Class6558 class6558_0 = new Class6558();

	private Class6551 class6551_0 = new Class6551();

	private Enum872 enum872_0 = Enum872.flag_1;

	private Class5998 class5998_0 = Class5998.class5998_140;

	private bool bool_4;

	private Interface317 interface317_0;

	private uint uint_0 = 8u;

	public int HeadingsOutlineLevels
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

	public int ExpandedOutlineLevels
	{
		get
		{
			return int_1;
		}
		set
		{
			int_1 = value;
		}
	}

	public int BookmarksOutlineLevel
	{
		get
		{
			return int_2;
		}
		set
		{
			int_2 = value;
		}
	}

	public Enum890 TextCompression
	{
		get
		{
			return enum890_0;
		}
		set
		{
			enum890_0 = value;
		}
	}

	public Enum891 ImageCompression
	{
		get
		{
			return enum891_0;
		}
		set
		{
			enum891_0 = value;
		}
	}

	public int JpegQuality
	{
		get
		{
			return int_3;
		}
		set
		{
			if (value < 0 || value > 100)
			{
				throw new ArgumentException("value");
			}
			int_3 = value;
		}
	}

	public bool IsShowHyperlinkRects
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

	public Enum883 Compliance
	{
		get
		{
			return enum883_0;
		}
		set
		{
			enum883_0 = value;
		}
	}

	public Class6558 ComplianceOptions
	{
		get
		{
			return class6558_0;
		}
		set
		{
			class6558_0 = value;
		}
	}

	public bool PdfaCompliant
	{
		get
		{
			switch (enum883_0)
			{
			default:
				return false;
			case Enum883.const_1:
			case Enum883.const_2:
				return true;
			}
		}
	}

	public Class6510 EncryptionDetails
	{
		get
		{
			return class6510_0;
		}
		set
		{
			class6510_0 = value;
		}
	}

	internal bool IsEncrypted => class6510_0 != null;

	public Class5998 ImageTransparentColor
	{
		get
		{
			return class5998_0;
		}
		set
		{
			class5998_0 = value;
		}
	}

	public bool ApplyImageTransparent
	{
		get
		{
			return bool_4;
		}
		set
		{
			bool_4 = value;
		}
	}

	public Class6559 DigitalSignatureDetails
	{
		get
		{
			return class6559_0;
		}
		set
		{
			class6559_0 = value;
		}
	}

	public bool RenderMetafileAsBitmap
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

	public Class6551 FontException => class6551_0;

	public Enum872 FontEmbeddingRule
	{
		get
		{
			return enum872_0;
		}
		set
		{
			enum872_0 = value;
		}
	}

	public Interface317 ErrorHandler
	{
		get
		{
			return interface317_0;
		}
		set
		{
			interface317_0 = value;
		}
	}

	public uint TabSize
	{
		get
		{
			return uint_0;
		}
		set
		{
			uint_0 = value;
		}
	}

	public void method_0()
	{
		if (PdfaCompliant)
		{
			if (IsEncrypted)
			{
				throw new ArgumentException("You have requested both PDF/A compliance and PDF encryption but these options cannot be used together.");
			}
			if (TextCompression == Enum890.const_2)
			{
				throw new ArgumentException("LZW text compression algorithm does not conforms with PDF/A standard.");
			}
			if (ImageCompression == Enum891.const_4 || ImageCompression == Enum891.const_5)
			{
				throw new ArgumentException("LZW image compression algorithms does not conforms with PDF/A standard.");
			}
		}
		if (class6510_0 != null)
		{
			if (!Class5964.smethod_20(class6510_0.UserPassword) && !Class5964.smethod_20(class6510_0.OwnerPassword))
			{
				throw new ArgumentException("You have requested PDF encryption, but not specified either a user password or an owner password.");
			}
			if (class6510_0.UserPassword == class6510_0.OwnerPassword)
			{
				throw new ArgumentException("The PDF user password and owner password cannot be the same. Please enter different passwords.");
			}
		}
	}
}
