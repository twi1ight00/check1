using System;
using System.Collections;

namespace ns238;

internal class Class6588
{
	private bool bool_0 = true;

	private bool bool_1 = true;

	private int int_0;

	private int int_1;

	private int int_2;

	private bool bool_2 = true;

	private int int_3;

	private int int_4;

	private bool bool_3 = true;

	private bool bool_4 = true;

	private bool bool_5 = true;

	private bool bool_6 = true;

	private bool bool_7 = true;

	private bool bool_8 = true;

	private bool bool_9;

	private bool bool_10 = true;

	private bool bool_11 = true;

	private byte[] byte_0;

	private string string_0;

	private string string_1 = "Arial";

	private Hashtable hashtable_0 = new Hashtable();

	private Hashtable hashtable_1 = new Hashtable();

	private Hashtable hashtable_2 = new Hashtable();

	private Hashtable hashtable_3 = new Hashtable();

	private Hashtable hashtable_4 = new Hashtable();

	private int int_5 = 95;

	public bool Compressed
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

	public bool ViewerIncluded
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

	public bool ShowPageBorder
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

	public bool ShowFullScreen
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

	public bool ShowPageStepper
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

	public bool ShowSearch
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

	public bool ShowTopPane
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

	public bool ShowBottomPane
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

	public bool ShowLeftPane
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

	public bool StartOpenLeftPane
	{
		get
		{
			return bool_9;
		}
		set
		{
			bool_9 = value;
		}
	}

	public bool AllowReadMode
	{
		get
		{
			return bool_10;
		}
		set
		{
			bool_10 = value;
		}
	}

	public bool EnableContextMenu
	{
		get
		{
			return bool_11;
		}
		set
		{
			bool_11 = value;
		}
	}

	public int TopPaneControlFlags
	{
		get
		{
			return int_3;
		}
		set
		{
			int_3 = value;
		}
	}

	public int LeftPaneControlFlags
	{
		get
		{
			return int_4;
		}
		set
		{
			int_4 = value;
		}
	}

	public byte[] LogoImageBytes
	{
		get
		{
			return byte_0;
		}
		set
		{
			byte_0 = value;
		}
	}

	public string LogoLink
	{
		get
		{
			return string_0;
		}
		set
		{
			string_0 = value;
		}
	}

	public string ToolTipsFontName
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

	public Hashtable TopPaneToolTips => hashtable_0;

	public Hashtable LeftPaneToolTips => hashtable_1;

	public Hashtable BottomPaneToolTips => hashtable_2;

	public Hashtable ReadModePaneToolTips => hashtable_3;

	public Hashtable DialogsToolTips => hashtable_4;

	public int JpegQuality
	{
		get
		{
			return int_5;
		}
		set
		{
			if (value < 0 || value > 100)
			{
				throw new ArgumentException("value");
			}
			int_5 = value;
		}
	}
}
