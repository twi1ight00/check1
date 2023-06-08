using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Aspose.Cells;

/// <summary>
///       Represents find options.
///       </summary>
/// <example>
///   <code>
///
///       [C#]
///
///       //Instantiate the workbook object
///       Workbook workbook = new Workbook("C:\\book1.xls");
///
///       //Get Cells collection 
///       Cells cells = workbook.Worksheets[0].Cells;
///
///       //Instantiate FindOptions Object
///       FindOptions findOptions = new FindOptions();
///
///       //Create a Cells Area
///       CellArea ca = new CellArea();
///       ca.StartRow = 8;
///       ca.StartColumn = 2;
///       ca.EndRow = 17;
///       ca.EndColumn = 13;
///
///       //Set cells area for find options
///       findOptions.SetRange(ca);
///
///       //Set searching properties
///       findOptions.SearchNext = true;
///
///       findOptions.SeachOrderByRows = true;
///
///       findOptions.LookInType = LookInType.Values;
///
///       //Find the cell with 0 value
///       Cell cell = cells.Find(0, null, findOptions);
///
///       [VB.NET]
///
///       'Instantiate the workbook object
///       Dim workbook As New Workbook("C:\book1.xls")
///
///       'Get Cells collection 
///       Dim cells As Cells = workbook.Worksheets(0).Cells
///
///       'Instantiate FindOptions Object
///       Dim findOptions As New FindOptions()
///
///       'Create a Cells Area
///       Dim ca As New CellArea()
///       ca.StartRow = 8
///       ca.StartColumn = 2
///       ca.EndRow = 17
///       ca.EndColumn = 13
///
///       'Set cells area for find options
///       findOptions.SetRange(ca)
///
///       'Set searching properties
///       findOptions.SearchNext = True
///
///       findOptions.SeachOrderByRows = True
///
///       findOptions.LookInType = LookInType.Values
///
///       'Find the cell with 0 value
///       Dim cell As Cell = cells.Find(0, Nothing, findOptions)
///
///       </code>
/// </example>
public class FindOptions
{
	private bool bool_0;

	private LookAtType lookAtType_0;

	private CellArea cellArea_0;

	private bool bool_1;

	private bool bool_2 = true;

	private bool bool_3 = true;

	private LookInType lookInType_0;

	private bool bool_4;

	/// <summary>
	///       Indicates if the searched string is case sensitive.
	///       </summary>
	/// <remarks>NOTE: This member is now obsolete. Instead, 
	///       please use FindOptions.CaseSensitive property. 
	///       This property will be removed 12 months later since June 2010. 
	///       Aspose apologizes for any inconvenience you may have experienced.</remarks>
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	[Obsolete("Use FindOptions.CaseSensitive property instead.")]
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
	///       Look at type.
	///       </summary>
	public LookAtType LookAtType
	{
		get
		{
			return lookAtType_0;
		}
		set
		{
			lookAtType_0 = value;
		}
	}

	/// <summary>
	///       Indicates whether the searched range is set.
	///       </summary>
	public bool IsRangeSet => bool_1;

	/// <summary>
	///       Search order. True: search next. False: search previous.
	///       </summary>
	public bool SearchNext
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
	///       Indicates whether search order by rows or columns.
	///       </summary>
	public bool SeachOrderByRows
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
	///       Look in type.
	///       </summary>
	public LookInType LookInType
	{
		get
		{
			return lookInType_0;
		}
		set
		{
			lookInType_0 = value;
		}
	}

	public bool RegexKey
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
	///       Gets and sets the searched range.
	///       </summary>
	/// <returns>
	///       Returns the seached range.
	///       </returns>
	public CellArea GetRange()
	{
		return cellArea_0;
	}

	/// <summary>
	///       Sets the searched range.
	///       </summary>
	/// <param name="ca">the searched range.</param>
	public void SetRange(CellArea ca)
	{
		cellArea_0 = ca;
		bool_1 = true;
	}

	[SpecialName]
	internal bool method_0()
	{
		return bool_1;
	}
}
