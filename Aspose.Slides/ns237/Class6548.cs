using System;

namespace ns237;

internal class Class6548 : Class6511
{
	private const bool bool_0 = false;

	private static readonly Enum884 enum884_0 = Enum884.const_1;

	private Enum884 enum884_1 = enum884_0;

	private Enum884 enum884_2 = enum884_0;

	private Enum884 enum884_3 = enum884_0;

	private Enum884 enum884_4 = enum884_0;

	private Enum889 enum889_0 = enum889_1;

	private static readonly Enum889 enum889_1 = Enum889.const_0;

	private bool bool_1;

	private bool bool_2;

	private bool bool_3;

	private bool bool_4;

	private bool bool_5;

	private bool bool_6;

	private bool bool_7;

	public bool HideToolbar
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

	public bool HideMenubar
	{
		get
		{
			return bool_6;
		}
		set
		{
			bool_6 = value;
		}
	}

	public bool HideWindowUI
	{
		get
		{
			return bool_5;
		}
		set
		{
			bool_5 = value;
		}
	}

	public bool FitWindow
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

	public bool CenterWindow
	{
		get
		{
			return bool_3;
		}
		set
		{
			bool_3 = value;
		}
	}

	public bool DisplayDocTitle
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

	public Enum889 NonFullScreenPageMode
	{
		get
		{
			return enum889_0;
		}
		set
		{
			switch (value)
			{
			default:
				throw new ArgumentOutOfRangeException("Please report exception. Invalid PdfPageModeType value.");
			case Enum889.const_0:
			case Enum889.const_1:
			case Enum889.const_2:
			case Enum889.const_4:
				enum889_0 = value;
				break;
			}
		}
	}

	internal bool NeedToWriteFullScreenPdfPageMode
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

	public Enum884 ViewArea
	{
		get
		{
			return enum884_4;
		}
		set
		{
			enum884_4 = value;
		}
	}

	public Enum884 ViewClip
	{
		get
		{
			return enum884_3;
		}
		set
		{
			enum884_3 = value;
		}
	}

	public Enum884 PrintArea
	{
		get
		{
			return enum884_2;
		}
		set
		{
			enum884_2 = value;
		}
	}

	public Enum884 PrintClip
	{
		get
		{
			return enum884_1;
		}
		set
		{
			enum884_1 = value;
		}
	}

	internal Class6548(Class6672 context)
		: base(context)
	{
	}

	public override void vmethod_0(Class6679 writer)
	{
		writer.method_29(this);
		writer.method_6();
		if (enum884_1 != enum884_0)
		{
			writer.method_8("/PrintClip", Class6661.smethod_0(enum884_1));
		}
		if (enum884_2 != enum884_0)
		{
			writer.method_8("/PrintArea", Class6661.smethod_0(enum884_2));
		}
		if (enum884_3 != enum884_0)
		{
			writer.method_8("/ViewClip", Class6661.smethod_0(enum884_3));
		}
		if (enum884_4 != enum884_0)
		{
			writer.method_8("/ViewArea", Class6661.smethod_0(enum884_4));
		}
		if (bool_1 && enum889_0 != enum889_1)
		{
			writer.method_8("/NonFullScreenPageMode", Class6661.smethod_1(enum889_0));
		}
		if (bool_2)
		{
			writer.method_9("/DisplayDocTitle", bool_2);
		}
		if (bool_3)
		{
			writer.method_9("/CenterWindow", bool_3);
		}
		if (bool_4)
		{
			writer.method_9("/FitWindow", bool_4);
		}
		if (bool_5)
		{
			writer.method_9("/HideWindowUI", bool_5);
		}
		if (bool_6)
		{
			writer.method_9("/HideMenubar", bool_6);
		}
		if (bool_7)
		{
			writer.method_9("/HideToolbar", bool_7);
		}
		writer.method_7();
		writer.method_30();
	}
}
