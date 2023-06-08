using System.Collections;
using System.Runtime.CompilerServices;
using ns2;

namespace Aspose.Cells;

/// <summary>
///       Represents the copy options.
///       </summary>
public class CopyOptions
{
	internal bool bool_0;

	internal Hashtable hashtable_0;

	internal Enum173 enum173_0;

	internal Hashtable hashtable_1;

	internal bool bool_1;

	private bool bool_2;

	internal Hashtable hashtable_2;

	internal Hashtable hashtable_3;

	private bool bool_3;

	internal Hashtable hashtable_4;

	internal Hashtable hashtable_5;

	private bool bool_4;

	private bool bool_5 = true;

	public bool CopyNames
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

	/// <summary>
	///       If the formula is not valid for the dest destination, only copy values.
	///       </summary>
	public bool CopyInvalidFormulasAsValues
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

	/// <summary>
	///       Indicates whether copying column width in unit of characters.
	///       </summary>
	public bool ColumnCharacterWidth
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

	/// <summary>
	///       CopyOptions constructor.
	///       </summary>
	public CopyOptions()
	{
		bool_0 = false;
		if (!bool_0)
		{
			hashtable_0 = new Hashtable();
			enum173_0 = Enum173.const_0;
		}
		else
		{
			enum173_0 = Enum173.const_0;
		}
	}

	internal CopyOptions(bool bool_6)
	{
		bool_0 = bool_6;
		if (!bool_6)
		{
			hashtable_0 = new Hashtable();
			enum173_0 = Enum173.const_0;
		}
		else
		{
			enum173_0 = Enum173.const_0;
		}
	}

	internal CopyOptions(bool bool_6, Enum173 enum173_1)
	{
		bool_0 = bool_6;
		enum173_0 = enum173_1;
		if (!bool_6)
		{
			hashtable_0 = new Hashtable();
		}
	}

	[SpecialName]
	internal bool method_0()
	{
		return bool_5;
	}
}
