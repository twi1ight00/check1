namespace Aspose.Cells;

/// <summary>
///       Represents Data provider for saving large spreadsheet files in light weight mode. 	
///       </summary>
/// <remarks>
///       When saving a workbook by this mode, <see cref="M:Aspose.Cells.LightCellsDataProvider.StartSheet(System.Int32)" /> will be checked when saving every worksheet in the workbook.
///       For one sheet, if <see cref="M:Aspose.Cells.LightCellsDataProvider.StartSheet(System.Int32)" /> gives true, then all data and properties of rows/cells of this sheet to be saved
///       will be provided by this implementation. In the first place, <see cref="M:Aspose.Cells.LightCellsDataProvider.NextRow" /> will be called to get the next row index to be saved.
///       If a valid row index is returned(the row index must be in ascending order for the rows to be saved),
///       then a Row object representing this row will be provided for implementation to set its properties by <see cref="M:Aspose.Cells.LightCellsDataProvider.StartRow(Aspose.Cells.Row)" />.
///       For one row, <see cref="M:Aspose.Cells.LightCellsDataProvider.NextCell" /> will be checked firstly. If a valid column index be returned(the column index must be in ascending order for all cells of one row to be saved),
///       then a Cell object representing this cell will be provided for implementation to set its data and properties by <see cref="M:Aspose.Cells.LightCellsDataProvider.StartCell(Aspose.Cells.Cell)" />.
///       After data of this cell is set, this cell will be saved directy to the generated spreadsheet file and the next cell will be checked and processed.
///       </remarks>
public interface LightCellsDataProvider
{
	/// <summary>
	///       Starts to save a worksheet.
	///       </summary>
	/// <remarks>
	///       It will be called at the beginning of saving a worksheet during saving a workbook.
	///       If the provider needs to refer to <i><code>sheetIndex</code></i> later
	///       in startRow(Row) or startCell(Cell) method,
	///       that is, if the process needs to know which worksheet is being processed, 
	///       the implementation should retain the <i><code>sheetIndex</code></i> value here.
	///       </remarks>
	/// <param name="sheetIndex">index of current sheet to be saved.</param>
	/// <returns>
	///       true if this provider will provide data for the given sheet; false if given sheet should use its normal data model(Cells).
	///       </returns>
	bool StartSheet(int sheetIndex);

	/// <summary>
	///       Gets the next row to be saved.
	///       </summary>
	/// <remarks>
	///       It will be called at the beginning of saving a row and its cells data(before <see cref="M:Aspose.Cells.LightCellsDataProvider.StartRow(Aspose.Cells.Row)" />).
	///       </remarks>
	/// <returns>
	///       the next row index to be saved. -1 means the end of current sheet data has been reached and no further row of current sheet to be saved.
	///       </returns>
	int NextRow();

	/// <summary>
	///       Starts to save data of one row.
	///       </summary>
	/// <remarks>
	///       It will be called at the beginning of saving a row and its cells data.
	///       If current row has some custom properties such as height, style, ...etc.,
	///       implementation should set those properties to given Row object here.
	///       </remarks>
	/// <param name="row">
	///       Row object for implementation to fill data. Its row index is the returned value of latest call of <see cref="M:Aspose.Cells.LightCellsDataProvider.NextRow" />.
	///       If the row has been initialized in the inner cells model, the existing row object will be used.
	///       Otherwise a temporary Row object will be used for implementation to fill data.
	///       </param>
	void StartRow(Row row);

	/// <summary>
	///       Gets next cell to be saved.
	///       </summary>
	/// <remarks>
	///       It will be called at the beginning of saving one cell.
	///       </remarks>
	/// <returns>
	///       column index of the next cell to be saved. -1 means the end of current row data has been reached and no further cell of current row to be saved.
	///       </returns>
	int NextCell();

	/// <summary>
	///       Starts to save data of one cell.
	///       </summary>
	/// <remarks>
	/// </remarks>
	/// <param name="cell">
	///       Cell object for implementation to fill data. Its column index is the returned value of latest call of <see cref="M:Aspose.Cells.LightCellsDataProvider.NextCell" />.
	///       If the cell has been initialized in the inner cells model, the existed cell object will be used.
	///       Otherwise a temporary Cell object will be used for implementation to fill data.
	///       </param>
	void StartCell(Cell cell);

	/// <summary>
	///       Checks whether the current string value of cell needs to be gathered into a global pool.
	///       </summary>
	/// <remarks>
	///       Gathering string values will take advantage only when there are many duplicated string values for the cells provided by this implementation.
	///       In this situation gathering string will save much memory and generate smaller resultant file.
	///       If there are many string values for the cells provided by LightCellsDataProvider but few of them are same,
	///       gathering string will cost more memory and time and has no advantage for the resultant file.
	///       </remarks>
	/// <returns>
	///       true if string value need to be gathered into a global pool for the resultant file.
	///       </returns>
	bool IsGatherString();
}
