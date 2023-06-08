using System;
using System.ComponentModel;

namespace Aspose.Cells;

/// <summary>
///        The load data options.
///       </summary>
public class LoadDataOption
{
	/// <summary>
	///       Indicates which sheets to be imported.
	///       </summary>
	/// <remarks>If SheetNames is not null, this property will no effect.</remarks>
	public int[] SheetIndexes;

	/// <summary>
	///       Indicates which sheets to be imported.
	///       </summary>
	public string[] SheetNames;

	private bool bool_0 = true;

	private bool bool_1;

	/// <summary>
	///       Indicates whether to import the formulas.
	///       </summary>
	/// <remarks>NOTE: This member is now obsolete. Instead, 
	///       please use LoadDataOption.ImportFormula property. 
	///       This property will be removed 12 months later since June 2010. 
	///       Aspose apologizes for any inconvenience you may have experienced.</remarks>
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	[Obsolete("Use LoadDataOption.ImportFormula property instead.")]
	public bool Formula
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
	///       Indicates whether to import the formulas.
	///       The default value is true.
	///       </summary>
	public bool ImportFormula
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

	public bool OnlyCreateWorksheet
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
