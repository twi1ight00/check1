using System;
using System.Collections.Generic;
using System.Drawing;
using ns19;
using ns4;
using ns44;
using ns56;

namespace ns24;

internal class Class350 : Class278
{
	private Class513 class513_0 = new Class513();

	private Enum165 enum165_0;

	private SizeF sizeF_0;

	private Class1472 class1472_0;

	private Class1464 class1464_0;

	private Class1469 class1469_0;

	private Class1465 class1465_0;

	private Class1885 class1885_0;

	private float float_0 = 0.5f;

	private int int_0 = 1;

	private bool bool_0 = true;

	private bool bool_1;

	private bool bool_2;

	private bool bool_3;

	private bool bool_4 = true;

	private bool bool_5;

	private bool bool_6;

	private bool bool_7 = true;

	private int int_1 = 1;

	private byte[] byte_0;

	private Class367 class367_0;

	private Class249 class249_0 = new Class249();

	private List<object[]> list_0 = new List<object[]>();

	private Class146 class146_0;

	private uint uint_0 = 256u;

	private uint uint_1 = 2147483648u;

	public Class513 ModifyVerifier => class513_0;

	public Enum165 PresentationType
	{
		get
		{
			return enum165_0;
		}
		set
		{
			enum165_0 = value;
		}
	}

	public SizeF NotesSize
	{
		get
		{
			return sizeF_0;
		}
		set
		{
			sizeF_0 = value;
		}
	}

	public Class1472 SmartTags
	{
		get
		{
			return class1472_0;
		}
		set
		{
			class1472_0 = value;
		}
	}

	public Class1464 CustomShowList
	{
		get
		{
			return class1464_0;
		}
		set
		{
			class1464_0 = value;
		}
	}

	public Class1469 PhotoAlbumInformation
	{
		get
		{
			return class1469_0;
		}
		set
		{
			class1469_0 = value;
		}
	}

	public Class1465 KinsokuSettings
	{
		get
		{
			return class1465_0;
		}
		set
		{
			class1465_0 = value;
		}
	}

	public Class1885 ExtensionList
	{
		get
		{
			return class1885_0;
		}
		set
		{
			class1885_0 = value;
		}
	}

	public float ServerZoom
	{
		get
		{
			return float_0;
		}
		set
		{
			if (value < 0f || value > 100f)
			{
				throw new ArgumentOutOfRangeException("ServerZoom must be in range [0;100]");
			}
			float_0 = value;
		}
	}

	public int FirstSlideNumber
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

	public bool ShowHeaderFooterOnTitles
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

	public bool RightToLeft
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

	public bool RemovePersonalInfoOnSave
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

	public bool CompatiblityMode
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

	public bool StrictFirstAndLastChars
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

	public bool EmbedTrueTypeFonts
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

	public bool SaveSubsetFonts
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

	public bool AutoCompressPictures
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

	public int BookmarkIdSeed
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

	public byte[] PresPropsPart
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

	public Class367 ViewProps
	{
		get
		{
			return class367_0;
		}
		set
		{
			class367_0 = value;
		}
	}

	public Class249 UnknownParts => class249_0;

	public List<object[]> RelsToUnknownParts => list_0;

	public Class146 TableStyles
	{
		get
		{
			return class146_0;
		}
		set
		{
			class146_0 = value;
		}
	}

	public uint method_0()
	{
		return uint_0++;
	}

	public void method_1(uint lastSlideId)
	{
		if (uint_0 <= lastSlideId)
		{
			uint_0 = lastSlideId + 1;
		}
	}

	public uint method_2()
	{
		return uint_1++;
	}

	public void method_3(uint lastMasterLayoutId)
	{
		if (uint_1 <= lastMasterLayoutId)
		{
			uint_1 = lastMasterLayoutId + 1;
		}
	}
}
