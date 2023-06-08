using System;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using ns41;

namespace ns35;

internal class Class806
{
	private int int_0 = 96;

	private int int_1 = 96;

	private Enum163 enum163_0 = Enum163.const_2;

	private Enum161 enum161_0;

	private int int_2 = 100;

	private ImageFormat imageFormat_0 = ImageFormat.Bmp;

	private bool bool_0;

	private bool bool_1 = true;

	internal bool bool_2;

	internal bool bool_3;

	internal bool bool_4;

	internal bool bool_5;

	internal bool bool_6;

	private Enum162 enum162_0 = Enum162.const_14;

	private PrintPageEventHandler printPageEventHandler_0;

	internal bool bool_7 = true;

	private bool bool_8;

	internal Enum162 SaveFormat
	{
		get
		{
			return enum162_0;
		}
		set
		{
			enum162_0 = value;
			ImageFormat = ImageFormat.Icon;
		}
	}

	public PrintPageEventHandler CustomPrintPageEventHandler
	{
		get
		{
			return printPageEventHandler_0;
		}
		set
		{
			printPageEventHandler_0 = value;
		}
	}

	public bool PrintWithStatusDialog
	{
		get
		{
			return bool_7;
		}
		set
		{
			bool_7 = value;
		}
	}

	public int HorizontalResolution
	{
		get
		{
			return int_0;
		}
		set
		{
			bool_2 = true;
			int_0 = value;
		}
	}

	public int VerticalResolution
	{
		get
		{
			return int_1;
		}
		set
		{
			bool_2 = true;
			int_1 = value;
		}
	}

	public Enum163 TiffCompression
	{
		get
		{
			return enum163_0;
		}
		set
		{
			bool_4 = true;
			enum163_0 = value;
		}
	}

	internal Enum161 PrintingPage
	{
		get
		{
			return enum161_0;
		}
		set
		{
			bool_3 = true;
			enum161_0 = value;
		}
	}

	public int Quality
	{
		get
		{
			return int_2;
		}
		set
		{
			if (value < 0 || value > 100)
			{
				throw new ArgumentOutOfRangeException("Quality must be between 0 and 100");
			}
			int_2 = value;
		}
	}

	public ImageFormat ImageFormat
	{
		get
		{
			return imageFormat_0;
		}
		set
		{
			imageFormat_0 = value;
			bool_5 = true;
		}
	}

	public bool IsCellAutoFit
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

	internal bool IsPaginated
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

	public bool IsImageFitToPage
	{
		get
		{
			return bool_8;
		}
		set
		{
			bool_8 = value;
		}
	}
}
