using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using ns11;
using ns2;

namespace Aspose.Cells;

/// <summary>
///       Represents the various types of protection options available for a worksheet. 
///       Only used in ExcelXP and above version.
///       </summary>
/// <example>
///   <code>
///
///       [C#]
///
///       //Allowing users to select locked cells of the worksheet
///       worksheet.Protection.AllowSelectingLockedCell = true;
///       //Allowing users to select unlocked cells of the worksheet
///       worksheet.Protection.AllowSelectingUnlockedCell = true;  
///
///       [Visual Basic]
///
///       'Allowing users to select locked cells of the worksheet
///       worksheet.Protection.AllowSelectingLockedCell = True
///       'Allowing users to select unlocked cells of the worksheet
///       worksheet.Protection.AllowSelectingUnlockedCell = True
///       </code>
/// </example>
public class Protection
{
	private bool bool_0;

	private bool bool_1;

	private bool bool_2;

	private bool bool_3;

	private bool bool_4;

	private bool bool_5;

	private bool bool_6;

	private bool bool_7;

	private bool bool_8;

	private bool bool_9;

	private bool bool_10;

	private bool bool_11 = true;

	private bool bool_12 = true;

	private bool bool_13 = true;

	private bool bool_14 = true;

	private bool bool_15 = true;

	private string string_0;

	internal Class414 class414_0;

	/// <summary>
	///       Represents if the deletion of columns is allowed on a protected worksheet.
	///       </summary>
	/// <remarks>The columns containing the cells to be deleted must be unlocked when the sheet is protected,
	///       and "Select unlocked cells" option must be enabled. </remarks>
	public bool AllowDeletingColumn
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
	///       Represents if the deletion of columns is allowed on a protected worksheet.
	///       </summary>
	/// <remarks>The columns containing the cells to be deleted must be unlocked when the sheet is protected,
	///       and "Select unlocked cells" option must be enabled. </remarks>
	/// <remarks>NOTE: This member is now obsolete. Instead, 
	///       please use Protection.AllowDeletingColumn property. 
	///       This property will be removed 12 months later since June 2010. 
	///       Aspose apologizes for any inconvenience you may have experienced.</remarks>
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Obsolete("Use Protection.AllowDeletingColumn property instead.")]
	public bool IsDeletingColumnsAllowed
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
	///       Represents if the deletion of rows is allowed on a protected worksheet.
	///       </summary>
	/// <remarks>The rows containing the cells to be deleted must be unlocked when the sheet is protected,
	///       and "Select unlocked cells" option must be enabled. </remarks>
	public bool AllowDeletingRow
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

	/// <summary>
	///       Represents if the deletion of rows is allowed on a protected worksheet.
	///       </summary>
	/// <remarks>The rows containing the cells to be deleted must be unlocked when the sheet is protected,
	///       and "Select unlocked cells" option must be enabled. </remarks>
	/// <remarks>NOTE: This member is now obsolete. Instead, 
	///       please use Protection.AllowDeletingRow property. 
	///       This property will be removed 12 months later since June 2010. 
	///       Aspose apologizes for any inconvenience you may have experienced.</remarks>
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Obsolete("Use Protection.AllowDeletingRow property instead.")]
	public bool IsDeletingRowsAllowed
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

	/// <summary>
	///       Represents if the user is allowed to make use of an AutoFilter that was created before the sheet was protected. 
	///       </summary>
	public bool AllowFiltering
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
	///       Represents if the user is allowed to make use of an AutoFilter that was created before the sheet was protected. 
	///       </summary>
	/// <remarks>NOTE: This member is now obsolete. Instead, 
	///       please use Protection.AllowFiltering property. 
	///       This property will be removed 12 months later since June 2010. 
	///       Aspose apologizes for any inconvenience you may have experienced.</remarks>
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	[Obsolete("Use Protection.AllowFiltering property instead.")]
	public bool IsFilteringAllowed
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
	///       Represents if the formatting of cells is allowed on a protected worksheet.
	///       </summary>
	public bool AllowFormattingCell
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
	///       Represents if the formatting of cells is allowed on a protected worksheet.
	///       </summary>
	/// <remarks>NOTE: This member is now obsolete. Instead, 
	///       please use Protection.AllowFormattingCell property. 
	///       This property will be removed 12 months later since June 2010. 
	///       Aspose apologizes for any inconvenience you may have experienced.</remarks>
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	[Obsolete("Use Protection.AllowFormattingCell property instead.")]
	public bool IsFormattingCellsAllowed
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
	///       Represents if the formatting of columns is allowed on a protected worksheet
	///       </summary>
	public bool AllowFormattingColumn
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
	///       Represents if the formatting of columns is allowed on a protected worksheet
	///       </summary>
	/// <remarks>NOTE: This member is now obsolete. Instead, 
	///       please use Protection.AllowFormattingColumn property. 
	///       This property will be removed 12 months later since June 2010. 
	///       Aspose apologizes for any inconvenience you may have experienced.</remarks>
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	[Obsolete("Use Protection.AllowFormattingColumn property instead.")]
	public bool IsFormattingColumnsAllowed
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
	///       Represents if the formatting of rows is allowed on a protected worksheet
	///       </summary>
	public bool AllowFormattingRow
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

	/// <summary>
	///       Represents if the formatting of rows is allowed on a protected worksheet
	///       </summary>
	/// <remarks>NOTE: This member is now obsolete. Instead, 
	///       please use Protection.AllowFormattingRow property. 
	///       This property will be removed 12 months later since June 2010. 
	///       Aspose apologizes for any inconvenience you may have experienced.</remarks>
	[Obsolete("Use Protection.AllowFormattingRow property instead.")]
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public bool IsFormattingRowsAllowed
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

	/// <summary>
	///       Represents if the insertion of columns is allowed on a protected worksheet
	///       </summary>
	public bool AllowInsertingColumn
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

	/// <summary>
	///       Represents if the insertion of columns is allowed on a protected worksheet
	///       </summary>
	/// <remarks>NOTE: This member is now obsolete. Instead, 
	///       please use Protection.AllowInsertingColumn property. 
	///       This property will be removed 12 months later since June 2010. 
	///       Aspose apologizes for any inconvenience you may have experienced.</remarks>
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Obsolete("Use Protection.AllowInsertingColumn property instead.")]
	public bool IsInsertingColumnsAllowed
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

	/// <summary>
	///       Represents if the insertion of hyperlinks is allowed on a protected worksheet
	///       </summary>
	public bool AllowInsertingHyperlink
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

	/// <summary>
	///       Represents if the insertion of hyperlinks is allowed on a protected worksheet
	///       </summary>
	/// <remarks>NOTE: This member is now obsolete. Instead, 
	///       please use Protection.AllowInsertingHyperlink property. 
	///       This property will be removed 12 months later since June 2010. 
	///       Aspose apologizes for any inconvenience you may have experienced.</remarks>
	[Obsolete("Use Protection.AllowInsertingHyperlink property instead.")]
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public bool IsInsertingHyperlinksAllowed
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

	/// <summary>
	///       Represents if the insertion of rows is allowed on a protected worksheet
	///       </summary>
	public bool AllowInsertingRow
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

	/// <summary>
	///       Represents if the insertion of rows is allowed on a protected worksheet
	///       </summary>
	/// <remarks>NOTE: This member is now obsolete. Instead, 
	///       please use Protection.AllowInsertingRow property. 
	///       This property will be removed 12 months later since June 2010. 
	///       Aspose apologizes for any inconvenience you may have experienced.</remarks>
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Obsolete("Use Protection.AllowInsertingRow property instead.")]
	[Browsable(false)]
	public bool IsInsertingRowsAllowed
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

	/// <summary>
	///       Represents if the sorting option is allowed on a protected worksheet.
	///       </summary>
	public bool AllowSorting
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

	/// <summary>
	///       Represents if the sorting option is allowed on a protected worksheet.
	///       </summary>
	/// <remarks>NOTE: This member is now obsolete. Instead, 
	///       please use Protection.AllowSorting property. 
	///       This property will be removed 12 months later since June 2010. 
	///       Aspose apologizes for any inconvenience you may have experienced.</remarks>
	[Obsolete("Use Protection.AllowSorting property instead.")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	public bool IsSortingAllowed
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

	/// <summary>
	///       Represents if the user is allowed to manipulate pivot tables on a protected worksheet.
	///       </summary>
	public bool AllowUsingPivotTable
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

	/// <summary>
	///       Represents if the user is allowed to manipulate pivot tables on a protected worksheet.
	///       </summary>
	/// <remarks>NOTE: This member is now obsolete. Instead, 
	///       please use Protection.AllowUsingPivotTable property. 
	///       This property will be removed 12 months later since June 2010. 
	///       Aspose apologizes for any inconvenience you may have experienced.</remarks>
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Obsolete("Use Protection.AllowUsingPivotTable property instead.")]
	[Browsable(false)]
	public bool IsUsingPivotTablesAllowed
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

	/// <summary>
	///       Represents if the user is allowed to edit contents of locked cells on a protected worksheet.
	///       </summary>
	public bool AllowEditingContent
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

	/// <summary>
	///       Represents if the user is allowed to edit contents of locked cells on a protected worksheet.
	///       </summary>
	/// <remarks>NOTE: This member is now obsolete. Instead, 
	///       please use Protection.AllowEditingContent property. 
	///       This property will be removed 12 months later since June 2010. 
	///       Aspose apologizes for any inconvenience you may have experienced.</remarks>
	[Obsolete("Use Protection.AllowEditingContent property instead.")]
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public bool IsEditingContentsAllowed
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

	/// <summary>
	///       Represents if the user is allowed to manipulate drawing objects on a protected worksheet.
	///       </summary>
	public bool AllowEditingObject
	{
		get
		{
			return bool_12;
		}
		set
		{
			bool_12 = value;
		}
	}

	/// <summary>
	///       Represents if the user is allowed to manipulate drawing objects on a protected worksheet.
	///       </summary>
	/// <remarks>NOTE: This member is now obsolete. Instead, 
	///       please use Protection.AllowEditingObject property. 
	///       This property will be removed 12 months later since June 2010. 
	///       Aspose apologizes for any inconvenience you may have experienced.</remarks>
	[Obsolete("Use Protection.AllowEditingObject property instead.")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	public bool IsEditingObjectsAllowed
	{
		get
		{
			return bool_12;
		}
		set
		{
			bool_12 = value;
		}
	}

	/// <summary>
	///       Represents if the user is allowed to edit scenarios on a protected worksheet.
	///       </summary>
	public bool AllowEditingScenario
	{
		get
		{
			return bool_13;
		}
		set
		{
			bool_13 = value;
		}
	}

	/// <summary>
	///       Represents if the user is allowed to edit scenarios on a protected worksheet.
	///       </summary>
	/// <remarks>NOTE: This member is now obsolete. Instead, 
	///       please use Protection.AllowEditingScenario property. 
	///       This property will be removed 12 months later since June 2010. 
	///       Aspose apologizes for any inconvenience you may have experienced.</remarks>
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Obsolete("Use Protection.AllowEditingScenario property instead.")]
	public bool IsEditingScenariosAllowed
	{
		get
		{
			return bool_13;
		}
		set
		{
			bool_13 = value;
		}
	}

	/// <summary>
	///       Represents the password to protect the worksheet.
	///       </summary>
	/// <remarks>
	///       If password is set to null or blank string, you can unprotect the worksheet or workbook without using a password. Otherwise, you must specify the password to unprotect the worksheet or workbook.
	///       </remarks>
	public string Password
	{
		get
		{
			return string_0;
		}
		set
		{
			string_0 = value;
			method_3((ushort)Class1652.smethod_0(value));
		}
	}

	/// <summary>
	///       Represents if the user is allowed to select locked cells on a protected worksheet.
	///       </summary>
	public bool AllowSelectingLockedCell
	{
		get
		{
			return bool_15;
		}
		set
		{
			bool_15 = value;
		}
	}

	/// <summary>
	///       Represents if the user is allowed to select locked cells on a protected worksheet.
	///       </summary>
	/// <remarks>NOTE: This member is now obsolete. Instead, 
	///       please use Protection.AllowSelectingLockedCell property. 
	///       This property will be removed 12 months later since June 2010. 
	///       Aspose apologizes for any inconvenience you may have experienced.</remarks>
	[Browsable(false)]
	[Obsolete("Use Protection.AllowSelectingLockedCell property instead.")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public bool IsSelectingLockedCellsAllowed
	{
		get
		{
			return bool_15;
		}
		set
		{
			bool_15 = value;
		}
	}

	/// <summary>
	///       Represents if the user is allowed to select unlocked cells on a protected worksheet.
	///       </summary>
	public bool AllowSelectingUnlockedCell
	{
		get
		{
			return bool_14;
		}
		set
		{
			bool_14 = value;
		}
	}

	/// <summary>
	///       Represents if the user is allowed to select unlocked cells on a protected worksheet.
	///       </summary>
	/// <remarks>NOTE: This member is now obsolete. Instead, 
	///       please use Protection.AllowSelectingUnlockedCell property. 
	///       This property will be removed 12 months later since June 2010. 
	///       Aspose apologizes for any inconvenience you may have experienced.</remarks>
	[Obsolete("Use Protection.AllowSelectingUnlockedCell property instead.")]
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public bool IsSelectingUnlockedCellsAllowed
	{
		get
		{
			return bool_14;
		}
		set
		{
			bool_14 = value;
		}
	}

	[SpecialName]
	internal Class414 method_0()
	{
		if (class414_0 == null)
		{
			class414_0 = new Class414();
		}
		return class414_0;
	}

	internal Protection()
	{
	}

	/// <summary>
	///       Copy protection info.
	///       </summary>
	/// <param name="source">
	/// </param>
	public void Copy(Protection source)
	{
		bool_0 = source.bool_0;
		bool_1 = source.bool_1;
		bool_11 = source.bool_11;
		bool_12 = source.bool_12;
		bool_13 = source.bool_13;
		bool_2 = source.bool_2;
		bool_3 = source.bool_3;
		bool_4 = source.bool_4;
		bool_5 = source.bool_5;
		bool_6 = source.bool_6;
		bool_7 = source.bool_7;
		bool_8 = source.bool_8;
		bool_9 = source.bool_9;
		bool_10 = source.bool_10;
		string_0 = source.string_0;
		if (source.class414_0 != null)
		{
			class414_0 = new Class414();
			class414_0.Copy(source.class414_0);
		}
		else
		{
			class414_0 = null;
		}
		bool_15 = source.bool_15;
		bool_14 = source.bool_14;
	}

	internal void method_1(byte[] byte_0)
	{
		if (byte_0.Length >= 23)
		{
			if ((byte_0[20] & 0x40) == 0)
			{
				bool_14 = false;
			}
			else
			{
				bool_14 = true;
			}
			if ((byte_0[20] & 4) == 0)
			{
				bool_15 = false;
			}
			else
			{
				bool_15 = true;
				bool_14 = true;
			}
			if ((byte_0[19] & 4) == 0)
			{
				bool_3 = false;
			}
			else
			{
				bool_3 = true;
			}
			if ((byte_0[19] & 8) == 0)
			{
				bool_4 = false;
			}
			else
			{
				bool_4 = true;
			}
			if ((byte_0[19] & 0x10) == 0)
			{
				bool_5 = false;
			}
			else
			{
				bool_5 = true;
			}
			if ((byte_0[19] & 0x20) == 0)
			{
				bool_6 = false;
			}
			else
			{
				bool_6 = true;
			}
			if ((byte_0[19] & 0x40) == 0)
			{
				bool_8 = false;
			}
			else
			{
				bool_8 = true;
			}
			if ((byte_0[19] & 0x80) == 0)
			{
				bool_7 = false;
			}
			else
			{
				bool_7 = true;
			}
			if ((byte_0[20] & 1) == 0)
			{
				bool_0 = false;
			}
			else
			{
				bool_0 = true;
			}
			if ((byte_0[20] & 2) == 0)
			{
				bool_1 = false;
			}
			else
			{
				bool_1 = true;
			}
			if ((byte_0[20] & 8) == 0)
			{
				bool_9 = false;
			}
			else
			{
				bool_9 = true;
			}
			if ((byte_0[20] & 0x10) == 0)
			{
				bool_2 = false;
			}
			else
			{
				bool_2 = true;
			}
			bool_10 = (byte_0[20] & 0x20) != 0;
		}
	}

	[SpecialName]
	internal ushort method_2()
	{
		if (class414_0 == null)
		{
			return 0;
		}
		return (ushort)class414_0.method_0();
	}

	[SpecialName]
	internal void method_3(ushort ushort_0)
	{
		if (class414_0 == null)
		{
			class414_0 = new Class414();
		}
		class414_0.method_1(ushort_0);
	}

	/// <summary>
	///       Gets the hash of current password.
	///       </summary>
	public int GetPasswordHash()
	{
		if (class414_0 != null)
		{
			return class414_0.method_0();
		}
		return 0;
	}

	internal bool method_4(string string_1)
	{
		if (class414_0 != null)
		{
			return class414_0.method_2(string_1);
		}
		return string_1 == null;
	}
}
