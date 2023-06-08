using System;
using System.ComponentModel;

namespace Aspose.Cells;

/// <summary>
///       Represent the replace options.
///       </summary>
public class ReplaceOptions
{
	private bool bool_0 = true;

	private bool bool_1 = true;

	/// <summary>
	///       Indicates if the searched string is case sensitive.
	///       </summary>
	/// <remarks>NOTE: This member is now obsolete. Instead, 
	///       please use ReplaceOptions.CaseSensitive property. 
	///       This property will be removed 12 months later since June 2010. 
	///       Aspose apologizes for any inconvenience you may have experienced.</remarks>
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Obsolete("Use ReplaceOptions.CaseSensitive property instead.")]
	public bool IsCaseSensitive
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

	/// <summary>
	///       Indicates if the searched string is case sensitive.
	///       </summary>
	public bool CaseSensitive
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

	/// <summary>
	///       Indicates whether to match entire cells contents
	///       </summary>
	public bool MatchEntireCellContents
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
}
