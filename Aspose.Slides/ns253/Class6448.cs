using ns252;
using ns260;

namespace ns253;

internal class Class6448
{
	private Enum826 enum826_0;

	private bool bool_0;

	private bool bool_1;

	private Class6422 class6422_0;

	private int int_0 = 1;

	private Enum827 enum827_0;

	private Class6433 class6433_0;

	private bool bool_2;

	private bool bool_3;

	private Class6449 class6449_0;

	private bool bool_4;

	private Class6444 class6444_0;

	private Class6323 class6323_0 = new Class6323();

	private Class6413 class6413_0;

	private Class6414 class6414_0;

	private int int_1;

	private Enum828 enum828_0;

	private Enum832 enum832_0;

	private Enum833 enum833_0;

	private Enum834 enum834_0 = Enum834.const_1;

	private bool bool_5;

	public Class6433 FlatText
	{
		get
		{
			return class6433_0;
		}
		set
		{
			class6433_0 = value;
		}
	}

	public Class6444 PresetTextWrap
	{
		get
		{
			if (class6444_0 == null)
			{
				class6444_0 = new Class6444();
			}
			return class6444_0;
		}
		set
		{
			class6444_0 = value;
		}
	}

	public Class6422 AutoFitMode
	{
		get
		{
			if (class6422_0 == null)
			{
				class6422_0 = new Class6423();
			}
			return class6422_0;
		}
		set
		{
			class6422_0 = value;
		}
	}

	public Class6413 Scene3DProperties
	{
		get
		{
			return class6413_0;
		}
		set
		{
			class6413_0 = value;
		}
	}

	public Class6414 Shape3DProperties
	{
		get
		{
			return class6414_0;
		}
		set
		{
			class6414_0 = value;
		}
	}

	public Enum826 Anchor
	{
		get
		{
			return enum826_0;
		}
		set
		{
			enum826_0 = value;
		}
	}

	public bool AnchorCenter
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

	public Class6449 Insets
	{
		get
		{
			if (class6449_0 == null)
			{
				class6449_0 = new Class6449();
			}
			return class6449_0;
		}
		set
		{
			class6449_0 = value;
		}
	}

	public bool UseCompatibleLineSpacing
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

	public bool ForceAntiAlias
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

	public bool FromWordArt
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

	public Enum828 TextHorizontalOverflow
	{
		get
		{
			return enum828_0;
		}
		set
		{
			enum828_0 = value;
		}
	}

	public int ColumnNumber
	{
		get
		{
			return int_0;
		}
		set
		{
			if (value < 1)
			{
				int_0 = 1;
			}
			else
			{
				int_0 = value;
			}
		}
	}

	public Class6323 Rotation
	{
		get
		{
			return class6323_0;
		}
		set
		{
			class6323_0 = value;
		}
	}

	public Enum827 ColumnOrder
	{
		get
		{
			return enum827_0;
		}
		set
		{
			enum827_0 = value;
		}
	}

	public int SpaceBetweenColumns
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

	public bool AreFirstAndLastParagraphsUseSpacing
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

	public bool IsTextUpright
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

	public Enum833 TextVerticalType
	{
		get
		{
			return enum833_0;
		}
		set
		{
			enum833_0 = value;
		}
	}

	public Enum832 TextVerticalOverflow
	{
		get
		{
			return enum832_0;
		}
		set
		{
			enum832_0 = value;
		}
	}

	public Enum834 TextWrappingType
	{
		get
		{
			return enum834_0;
		}
		set
		{
			enum834_0 = value;
		}
	}
}
