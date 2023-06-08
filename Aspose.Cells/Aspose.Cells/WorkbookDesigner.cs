using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Web;
using Aspose.Cells.Charts;
using Aspose.Cells.Drawing;
using Aspose.Cells.Pivot;
using Aspose.Cells.Tables;
using ns1;
using ns2;
using ns22;

namespace Aspose.Cells;

/// <summary>
///       Encapsulates the object that represents a designer spreadsheet.
///       </summary>
/// <example>
///   <code>
///
///       [C#]
///
///       //Create a connection object, specify the provider info and set the data source.
///       OleDbConnection con = new OleDbConnection("provider=microsoft.jet.oledb.4.0;data source=d:\\test\\Northwind.mdb");
///       //Open the connection object.
///       con.Open();
///       //Create a command object and specify the SQL query.
///       OleDbCommand cmd = new OleDbCommand("Select * from [Order Details]", con);
///       //Create a data adapter object.
///       OleDbDataAdapter da = new OleDbDataAdapter();
///       //Specify the command.
///       da.SelectCommand = cmd;
///       //Create a dataset object.
///       DataSet ds = new DataSet();
///       //Fill the dataset with the table records.
///       da.Fill(ds, "Order Details");
///       //Create a datatable with respect to dataset table.
///       DataTable dt = ds.Tables["Order Details"];
///       //Create WorkbookDesigner object.
///       WorkbookDesigner wd = new WorkbookDesigner();
///       //Open the template file (which contains smart markers).
///       wd.Open("D:\\test\\SmartMarker_Designer.xls");
///       //Set the datatable as the data source.
///       wd.SetDataSource(dt);
///       //Process the smart markers to fill the data into the worksheets.
///       wd.Process(true);
///       //Save the excel file.
///       wd.Workbook.Save("D:\\test\\outSmartMarker_Designer.xls");
///
///       [Visual Basic]
///
///       'Create a connection object, specify the provider info and set the data source.
///       Dim con As OleDbConnection = New OleDbConnection("provider=microsoft.jet.oledb.4.0;data source=d:\test\Northwind.mdb")
///       'Open the connection object.
///       con.Open()
///       'Create a command object and specify the SQL query.
///       Dim cmd As OleDbCommand = New OleDbCommand("Select * from [Order Details]", con)
///       'Create a data adapter object.
///       Dim da As OleDbDataAdapter = New OleDbDataAdapter()
///       'Specify the command.
///       da.SelectCommand = cmd
///       'Create a dataset object.
///       Dim ds As DataSet = New DataSet()
///       'Fill the dataset with the table records.
///       da.Fill(ds, "Order Details")
///       'Create a datatable with respect to dataset table.
///       Dim dt As DataTable = ds.Tables("Order Details")
///       'Create WorkbookDesigner object.
///       Dim wd As WorkbookDesigner = New WorkbookDesigner()
///       'Open the template file (which contains smart markers).
///       wd.Open("D:\test\SmartMarker_Designer.xls")
///       'Set the datatable as the data source.
///       wd.SetDataSource(dt)
///       'Process the smart markers to fill the data into the worksheets.
///       wd.Process(True)
///       'Save the excel file.
///       wd.Workbook.Save("D:\test\outSmartMarker_Designer.xls")
///       </code>
/// </example>
public class WorkbookDesigner
{
	private Workbook workbook_0;

	private Hashtable hashtable_0;

	private object object_0;

	private readonly Regex regex_0 = new Regex("\\((.+)\\)", RegexOptions.IgnoreCase);

	private readonly Regex regex_1 = new Regex("^\\((.+)\\)$", RegexOptions.IgnoreCase);

	private bool bool_0;

	private bool bool_1;

	private ArrayList arrayList_0;

	/// <summary>
	///       Gets and sets the <see cref="P:Aspose.Cells.WorkbookDesigner.Workbook" /> object.
	///       </summary>
	public Workbook Workbook
	{
		get
		{
			return workbook_0;
		}
		set
		{
			workbook_0 = value;
		}
	}

	/// <summary>
	///       Indicates if references in other worksheets will be updated.
	///       </summary>
	public bool UpdateReference
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

	public bool CalculateFormula
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
	///       Initializes a new instance of the <see cref="T:Aspose.Cells.WorkbookDesigner" /> class.
	///       </summary>
	public WorkbookDesigner()
	{
		workbook_0 = new Workbook();
		hashtable_0 = new Hashtable();
	}

	/// <summary>
	///       Opens a preset designer spreadsheet.
	///       </summary>
	/// <param name="designerSpreadsheet">The preset designer spreadsheet.</param>
	/// <remarks>NOTE: This member is now obsolete. Instead, 
	///       please use WorkbookDesigner.Workbook(string) construtor.
	///       This property will be removed 12 months later since December 2009. 
	///       Aspose apologizes for any inconvenience you may have experienced.</remarks>
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Obsolete("Use WorkbookDesigner.Workbook(string) construtor instead.")]
	public void Open(string designerSpreadsheet)
	{
		workbook_0 = new Workbook(designerSpreadsheet);
	}

	/// <summary>
	///       Opens a preset designer spreadsheet from memory stream.
	///       </summary>
	/// <param name="stream">Memory stream which contains the preset designer spreadsheet.</param>
	/// <remarks>NOTE: This member is now obsolete. Instead, 
	///       please use WorkbookDesigner.Workbook construtor.
	///       This property will be removed 12 months later since December 2009. 
	///       Aspose apologizes for any inconvenience you may have experienced.</remarks>
	[Browsable(false)]
	[Obsolete("Use WorkbookDesigner.Workbook(Stream) construtor instead.")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public void Open(MemoryStream stream)
	{
		workbook_0 = new Workbook(stream);
	}

	/// <summary>
	///       Creates and saves the result spreadsheet to the disk.
	///       </summary>
	/// <param name="resultSpreadsheet">Result spreadsheet.</param>
	/// <remarks>NOTE: This member is now obsolete. Instead, 
	///       please use WorkbookDesigner.Workbook.Save method.
	///       This property will be removed 12 months later since December 2009. 
	///       Aspose apologizes for any inconvenience you may have experienced.</remarks>
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Obsolete("Use WorkbookDesigner.Workbook.Save method instead.")]
	public void Save(string resultSpreadsheet)
	{
		workbook_0.Save(resultSpreadsheet);
	}

	/// <summary>
	///       Creates and saves the result spreadsheet to the disk.
	///       </summary>
	/// <param name="resultSpreadsheet">Result spreadsheet</param>
	/// <param name="fileFormatType">Excel file format type</param>
	/// <remarks>NOTE: This member is now obsolete. Instead, 
	///       please use WorkbookDesigner.Workbook.Save method.
	///       This property will be removed 12 months later since December 2009. 
	///       Aspose apologizes for any inconvenience you may have experienced.</remarks>
	[Browsable(false)]
	[Obsolete("Use WorkbookDesigner.Workbook.Save method instead.")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public void Save(string resultSpreadsheet, FileFormatType fileFormatType)
	{
		workbook_0.Save(resultSpreadsheet);
	}

	/// <summary>
	///       Creates the result spreadsheet and transfer it to the client then open it in the browser.
	///       </summary>
	/// <param name="resultSpreadsheet">Result file</param>
	/// <param name="saveType">Save type</param>
	/// <param name="fileFormatType">Excel file format type</param>
	/// <param name="response">Response object to return the spreadsheet to client.</param>
	/// <remarks>NOTE: This member is now obsolete. Instead, 
	///       please use WorkbookDesigner.Workbook.Save method.
	///       This property will be removed 12 months later since December 2009. 
	///       Aspose apologizes for any inconvenience you may have experienced.</remarks>
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Obsolete("Use WorkbookDesigner.Workbook.Save method instead.")]
	public void Save(string resultSpreadsheet, SaveType saveType, FileFormatType fileFormatType, HttpResponse response)
	{
		workbook_0.Save(resultSpreadsheet, saveType, fileFormatType, response);
	}

	/// <summary>
	///       Clears all data sources.
	///       </summary>
	public void ClearDataSource()
	{
		object_0 = null;
		hashtable_0.Clear();
	}

	/// <summary>
	///       Sets data source of a DataSet object.
	///       </summary>
	/// <param name="dataSet">DataSet object</param>
	public void SetDataSource(DataSet dataSet)
	{
		if (dataSet == null)
		{
			return;
		}
		foreach (DataTable table in dataSet.Tables)
		{
			method_20(table.TableName, new Class783(table));
		}
	}

	/// <summary>
	///       Sets data source of a DataTable object.
	///       </summary>
	/// <param name="dataTable">DataTable object</param>
	public void SetDataSource(DataTable dataTable)
	{
		if (dataTable != null)
		{
			method_20(dataTable.TableName, new Class783(dataTable));
		}
	}

	/// <summary>
	///       Sets data source of a DataView object and binds it to a data source name.
	///       </summary>
	/// <param name="dataSourceName">Data source name.</param>
	/// <param name="dataView">DataView object.</param>
	public void SetDataSource(string dataSourceName, DataView dataView)
	{
		if (dataView != null)
		{
			method_20(dataSourceName, new Class784(dataView));
		}
	}

	/// <summary>
	///       Sets data source of a DataView object.
	///       </summary>
	/// <param name="dataView">DataView object</param>
	public void SetDataSource(DataView dataView)
	{
		if (dataView != null)
		{
			method_20(dataView.Table.TableName, new Class784(dataView));
		}
	}

	/// <summary>
	///        Sets data source of a IDataReader object.
	///       </summary>
	/// <param name="name">The data source map name.</param>
	/// <param name="dataReader">IDataReader object</param>
	/// <param name="rowCount">The number of the data rows.
	///       If the smart marker does not contains "noadd",
	///       we have to insert rows by the row count for performance issue and dynamic repeated formulas.
	///       -1 means the param is useless.
	///       </param>
	public void SetDataSource(string name, IDataReader dataReader, int rowCount)
	{
		method_20(name, new Class782(dataReader, rowCount));
	}

	/// <summary>
	///       Sets data binding to a variable.
	///       </summary>
	/// <param name="variable">Variable name created using smark marker.</param>
	/// <param name="data">Source data.</param>
	public void SetDataSource(string variable, object data)
	{
		if (variable == null || !(variable != ""))
		{
			return;
		}
		if (data is int[])
		{
			int[] array = (int[])data;
			object[] array2 = new object[array.Length];
			for (int i = 0; i < array.Length; i++)
			{
				array2[i] = array.GetValue(i);
			}
			method_20(variable, new Class785(variable, array2));
		}
		else if (data is double[])
		{
			double[] array3 = (double[])data;
			object[] array4 = new object[array3.Length];
			for (int j = 0; j < array3.Length; j++)
			{
				array4[j] = array3.GetValue(j);
			}
			method_20(variable, new Class785(variable, array4));
		}
		else if (data is string[])
		{
			method_20(variable, new Class785(variable, (object[])data));
		}
		else if (data is ICollection)
		{
			ICollection icollection_ = (ICollection)data;
			method_20(variable, Class992.smethod_5(icollection_));
		}
		else
		{
			method_20(variable, new Class785(variable, new object[1] { data }));
		}
	}

	/// <summary>
	///       Sets data array binding to a variable.
	///       </summary>
	/// <param name="variable">Variable name created using smark marker.</param>
	/// <param name="dataArray">Source data array.</param>
	public void SetDataSource(string variable, object[] dataArray)
	{
		if (variable != null && variable != "")
		{
			method_20(variable, new Class785(variable, dataArray));
		}
	}

	private void method_0(Class993 class993_0)
	{
		Worksheet worksheet = class993_0.method_0();
		method_16(worksheet.Cells, class993_0);
		int num = -1;
		bool bool_ = false;
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < class993_0.Count; i++)
		{
			Class991 @class = class993_0[i];
			if (!@class.bool_0)
			{
				continue;
			}
			if (num == -1)
			{
				num = @class.cell_0.Row;
			}
			else if (num != @class.cell_0.Row)
			{
				if (arrayList.Count != 0)
				{
					method_2(worksheet.Cells, num, arrayList, bool_);
				}
				num = @class.cell_0.Row;
				arrayList.Clear();
				bool_ = false;
			}
			if (@class.bool_5)
			{
				bool_ = true;
			}
			arrayList.Add(@class);
		}
		if (arrayList.Count != 0)
		{
			method_2(worksheet.Cells, num, arrayList, bool_);
		}
	}

	private void method_1(Cells cells_0, int int_0, ArrayList arrayList_1)
	{
		CellArea area = default(CellArea);
		area.StartRow = int_0;
		DataSorter dataSorter = new DataSorter(Workbook);
		bool flag = false;
		for (int i = 0; i < arrayList_1.Count; i++)
		{
			Class991 @class = (Class991)arrayList_1[i];
			if (i == 0)
			{
				area.StartColumn = @class.cell_0.Column;
				area.EndRow = @class.method_2() + int_0;
			}
			area.EndColumn = @class.cell_0.Column;
			if (@class.bool_0 && @class.int_12 != -1)
			{
				if (@class.enum138_0 == Enum138.const_1 || @class.enum138_0 == Enum138.const_2)
				{
					flag = true;
				}
				Class1108 class2 = new Class1108(dataSorter);
				int num = @class.int_12 - 1;
				class2.Index = @class.cell_0.Column;
				class2.Order = ((!@class.bool_8) ? SortOrder.Descending : SortOrder.Ascending);
				if (num >= dataSorter.method_0().Count)
				{
					dataSorter.method_0().Add(class2);
				}
				else
				{
					dataSorter.method_0().Insert(num, class2);
				}
			}
		}
		if (flag)
		{
			workbook_0.CalculateFormula();
		}
		dataSorter.Sort(cells_0, area);
	}

	private void method_2(Cells cells_0, int int_0, ArrayList arrayList_1, bool bool_2)
	{
		Class991 @class = null;
		ArrayList arrayList = new ArrayList();
		arrayList.AddRange(arrayList_1);
		for (int i = 0; i < arrayList_1.Count; i++)
		{
			@class = (Class991)arrayList_1[i];
			@class.method_0();
			if (@class.enum138_0 == Enum138.const_1)
			{
				string formula = Class992.smethod_6(@class.string_0, @class.cell_0.Row, @class.cell_0.Column);
				@class.cell_0.Formula = formula;
				arrayList_1.RemoveAt(i--);
			}
		}
		object obj = null;
		while (arrayList_1.Count > 0)
		{
			@class = null;
			for (int j = 0; j < arrayList_1.Count; j++)
			{
				@class = (Class991)arrayList_1[j];
				if (@class.enum138_0 == Enum138.const_0)
				{
					break;
				}
				@class = null;
			}
			if (@class == null)
			{
				break;
			}
			if (@class.enum138_0 != 0)
			{
				continue;
			}
			bool isGroup;
			ArrayList arrayList2 = method_18(arrayList_1, @class.string_0, includeRepeatFormula: true, out isGroup);
			ICellsDataTable cellsDataTable = method_21(@class.string_0);
			if (cellsDataTable.Count == 0)
			{
				for (int k = 0; k < arrayList2.Count; k++)
				{
					@class = (Class991)arrayList2[k];
					Enum138 enum138_ = @class.enum138_0;
					if (enum138_ == Enum138.const_2)
					{
						method_15(@class, cells_0, @class.int_0, @class.int_1);
					}
				}
				continue;
			}
			if (isGroup)
			{
				method_3(cells_0, arrayList2, cellsDataTable);
				continue;
			}
			cellsDataTable.BeforeFirst();
			while (cellsDataTable.Next())
			{
				for (int l = 0; l < arrayList2.Count; l++)
				{
					@class = (Class991)arrayList2[l];
					switch (@class.enum138_0)
					{
					case Enum138.const_0:
						obj = cellsDataTable[@class.int_5];
						method_14(@class, cells_0, @class.int_0, @class.int_1, obj);
						@class.int_0 += @class.int_4 + 1;
						break;
					case Enum138.const_2:
						method_15(@class, cells_0, @class.int_0, @class.int_1);
						@class.int_0 += 1 + @class.int_4;
						break;
					}
				}
			}
		}
		if (arrayList_1.Count != 0)
		{
			for (int m = 0; m < arrayList_1.Count; m++)
			{
				@class = (Class991)arrayList_1[m];
				if (@class.enum138_0 == Enum138.const_2)
				{
					method_15(@class, cells_0, @class.int_0, @class.int_1);
				}
			}
		}
		method_1(cells_0, int_0, arrayList);
	}

	private void method_3(Cells cells_0, ArrayList arrayList_1, ICellsDataTable icellsDataTable_0)
	{
		bool bool_ = false;
		Class991 @class = (Class991)arrayList_1[0];
		int num = 0;
		ArrayList arrayList = new ArrayList();
		int int_ = @class.cell_0.Row;
		Hashtable hashtable = new Hashtable();
		int num2 = 0;
		for (int i = 0; i < arrayList_1.Count; i++)
		{
			@class = (Class991)arrayList_1[i];
			if (@class.bool_5)
			{
				@class.int_8 = -1;
				if (@class.int_7 == -1)
				{
					@class.int_7 = num2;
				}
				num2++;
			}
			else
			{
				if (@class.string_3 == null || !@class.bool_6)
				{
					continue;
				}
				for (int j = 0; j < @class.string_3.Length; j++)
				{
					if (!hashtable.ContainsKey(@class.string_3[j]))
					{
						ArrayList arrayList2 = new ArrayList();
						arrayList2.Add(@class);
						hashtable.Add(@class.string_3[j], arrayList2);
					}
					else
					{
						ArrayList arrayList3 = (ArrayList)hashtable[@class.string_3[j]];
						arrayList3.Add(@class);
					}
				}
			}
		}
		Class991[] array = new Class991[num2];
		for (int k = 0; k < arrayList_1.Count; k++)
		{
			@class = (Class991)arrayList_1[k];
			if (@class.bool_5)
			{
				array[@class.int_7] = @class;
			}
		}
		Hashtable hashtable2 = null;
		icellsDataTable_0.BeforeFirst();
		while (icellsDataTable_0.Next())
		{
			if (hashtable2 != null)
			{
				ArrayList arrayList4 = new ArrayList();
				for (int l = 0; l < array.Length; l++)
				{
					arrayList4.Clear();
					@class = array[l];
					object obj = hashtable2[@class.int_5];
					object obj2 = icellsDataTable_0[@class.int_5];
					bool flag = Class992.smethod_0(obj);
					bool flag2 = Class992.smethod_0(obj2);
					if (flag)
					{
						if (flag2)
						{
							continue;
						}
						if (@class.int_8 == -1)
						{
							@class.int_8 = int_;
							hashtable2[@class.int_5] = obj2;
							arrayList4.Add(@class);
							continue;
						}
					}
					else if (!flag2 && obj.Equals(obj2))
					{
						continue;
					}
					for (; l < array.Length; l++)
					{
						@class = array[l];
						if (@class.int_8 != -1)
						{
							if (num < @class.int_4)
							{
								num = @class.int_4;
							}
							arrayList.Add(@class);
							if (hashtable.ContainsKey(@class.string_1))
							{
								bool_ = true;
							}
						}
					}
				}
				if (arrayList.Count != 0)
				{
					method_4(cells_0, ref int_, arrayList, hashtable, bool_, arrayList_1, hashtable2);
					for (int m = 0; m < arrayList.Count; m++)
					{
						@class = (Class991)arrayList[m];
						@class.int_8 = -1;
					}
					for (int n = 0; n < arrayList4.Count; n++)
					{
						@class = (Class991)arrayList4[n];
						@class.int_8 = int_;
					}
					hashtable2 = method_22(hashtable2, icellsDataTable_0, arrayList_1, int_);
					num = 0;
					arrayList.Clear();
					bool_ = false;
				}
			}
			else
			{
				hashtable2 = method_22(hashtable2, icellsDataTable_0, arrayList_1, int_);
			}
			for (int num3 = 0; num3 < arrayList_1.Count; num3++)
			{
				@class = (Class991)arrayList_1[num3];
				if (@class.enum138_0 == Enum138.const_2)
				{
					cells_0.GetCell(int_, @class.cell_0.Column, bool_2: false).Formula = Class992.smethod_6(@class.string_0, int_, @class.cell_0.Column);
					continue;
				}
				object obj3 = icellsDataTable_0[@class.int_5];
				if (@class.bool_5 && @class.int_8 != int_)
				{
					Enum137 enum137_ = @class.enum137_0;
					if (enum137_ == Enum137.const_1)
					{
						if (obj3 != null && Type.GetTypeCode(obj3.GetType()) == TypeCode.String)
						{
							cells_0.GetCell(int_, @class.cell_0.Column, bool_2: false).PutValue((string)obj3, @class.bool_4);
						}
						else
						{
							cells_0.GetCell(int_, @class.cell_0.Column, bool_2: false).PutValue(obj3);
						}
					}
				}
				else if (@class.enum138_0 == Enum138.const_0)
				{
					if (obj3 != null && Type.GetTypeCode(obj3.GetType()) == TypeCode.String)
					{
						cells_0.GetCell(int_, @class.cell_0.Column, bool_2: false).PutValue((string)obj3, @class.bool_4);
					}
					else
					{
						cells_0.GetCell(int_, @class.cell_0.Column, bool_2: false).PutValue(obj3);
					}
				}
			}
			int_++;
		}
		for (int num4 = 0; num4 < arrayList_1.Count; num4++)
		{
			@class = (Class991)arrayList_1[num4];
			if (@class.bool_5 && @class.int_8 != -1)
			{
				arrayList.Add(@class);
			}
			if (@class.enum138_0 != Enum138.const_2 && hashtable.ContainsKey(@class.string_1))
			{
				bool_ = true;
			}
		}
		method_4(cells_0, ref int_, arrayList, hashtable, bool_, arrayList_1, hashtable2);
	}

	private void method_4(Cells cells_0, ref int int_0, ArrayList arrayList_1, Hashtable hashtable_1, bool bool_2, ArrayList arrayList_2, Hashtable hashtable_2)
	{
		Class991 @class = null;
		Row row = null;
		bool flag = false;
		for (int num = arrayList_2.Count - 1; num >= 0; num--)
		{
			@class = (Class991)arrayList_2[num];
			if (@class.row_0 != null)
			{
				row = @class.row_0;
			}
			if (@class.bool_1)
			{
				flag = @class.bool_1;
			}
		}
		if (bool_2 && flag && row != null && int_0 != row.Index)
		{
			Row row2 = cells_0.Rows.GetRow(int_0, bool_0: false, bool_1: true);
			row2.CopyData(row);
			for (int i = 0; i < row.method_0(); i++)
			{
				Cell cellByIndex = row.GetCellByIndex(i);
				row2.GetCell(cellByIndex.Column).method_37(cellByIndex.method_36());
			}
		}
		for (int num2 = arrayList_1.Count - 1; num2 >= 0; num2--)
		{
			@class = (Class991)arrayList_1[num2];
			int num3 = 0;
			int int_ = @class.int_8;
			if (bool_2)
			{
				if (hashtable_1.ContainsKey(@class.string_1))
				{
					ArrayList arrayList = (ArrayList)hashtable_1[@class.string_1];
					for (int j = 0; j < arrayList.Count; j++)
					{
						Class991 class2 = (Class991)arrayList[j];
						Cell cell = cells_0.GetCell(int_0, class2.cell_0.Column, bool_2: false);
						if (class2.string_2 != null)
						{
							cell.Formula = Class992.smethod_7(class2.string_2, bool_0: true, int_, class2.cell_0.Column, int_0 - 1, class2.cell_0.Column);
						}
						else
						{
							string text = CellsHelper.CellIndexToName(int_, class2.cell_0.Column) + ":" + CellsHelper.CellIndexToName(int_0 - 1, class2.cell_0.Column);
							cell.Formula = "=SUBTOTAL(" + class2.int_10 + "," + text + ")";
						}
						if (class2.int_11 != -1)
						{
							cell.method_37(class2.int_11);
						}
						if (class2.hashtable_0 != null && class2.hashtable_0[@class.string_1] != null)
						{
							Class994 class3 = (Class994)class2.hashtable_0[@class.string_1];
							cell = cells_0.GetCell(int_0, class2.cell_0.Column + class3.int_0, bool_2: false);
							cell.PutValue(string.Format(class3.string_0, hashtable_2[@class.int_5]));
						}
					}
					num3++;
				}
				for (int k = 0; k < arrayList_2.Count; k++)
				{
					Class991 class4 = (Class991)arrayList_2[k];
					if (class4.string_4 != null)
					{
						Cell cell2 = cells_0.GetCell(int_0, class4.cell_0.Column, bool_2: false);
						cell2.method_37(class4.int_11);
						if (class4.bool_7)
						{
							cell2.Formula = Class992.smethod_6(class4.string_4, cell2.Row, cell2.Column);
						}
						else
						{
							cell2.PutValue(class4.string_4);
						}
					}
					else if (class4.int_11 != -1)
					{
						Cell cell3 = cells_0.GetCell(int_0, class4.cell_0.Column, bool_2: false);
						cell3.method_37(class4.int_11);
					}
				}
			}
			switch (@class.enum137_0)
			{
			case Enum137.const_2:
				cells_0.Merge(int_, @class.cell_0.Column, int_0 - int_ + num3, 1);
				break;
			}
			if (num3 != 0 && @class.int_4 > 0)
			{
				num3 += @class.int_4;
			}
			int_0 += num3;
		}
	}

	private void method_5(Cells cells_0, Class991 class991_0, int int_0, int int_1, byte[] byte_0)
	{
		MemoryStream stream = new MemoryStream(byte_0);
		if (class991_0.bool_12)
		{
			Image image = Image.FromStream(stream);
			int columnWidthPixel = cells_0.GetColumnWidthPixel(int_1);
			int rowHeightPixel = cells_0.GetRowHeightPixel(int_0);
			int heightScale = (int)((double)((float)rowHeightPixel * 100f / (float)image.Height) + 0.5);
			int widthScale = (int)((double)((float)columnWidthPixel * 100f / (float)image.Width) + 0.5);
			cells_0.method_3().Pictures.Add(int_0, int_1, stream, widthScale, heightScale);
		}
		else if (class991_0.bool_13)
		{
			cells_0.method_3().Pictures.Add(int_0, int_1, stream, class991_0.int_18, class991_0.int_17);
		}
		else
		{
			int index = cells_0.method_3().Pictures.Add(int_0, int_1, stream);
			Picture picture = cells_0.method_3().Pictures[index];
			if (class991_0.bool_14)
			{
				picture.Left = class991_0.int_13;
			}
			if (class991_0.bool_15)
			{
				picture.Top = class991_0.int_14;
			}
			if (class991_0.bool_16)
			{
				picture.Width = class991_0.int_15;
			}
			if (class991_0.bool_17)
			{
				picture.Height = class991_0.int_16;
			}
		}
		cells_0.CheckCell(int_0, int_1)?.PutValue(null);
	}

	private void method_6(string string_0, Class991 class991_0)
	{
		try
		{
			string text = string_0.Substring("subtotal".Length);
			int num = text.IndexOf(':');
			if (num == -1)
			{
				class991_0.int_10 = int.Parse(text.Substring(0));
				return;
			}
			class991_0.int_10 = int.Parse(text.Substring(0, 1));
			string[] array = text.Substring(num + 1).Split('&');
			if (array[array.Length - 1] != null && array[array.Length - 1].StartsWith("formula"))
			{
				string text2 = array[array.Length - 1];
				for (int i = "formula".Length; i < text2.Length; i++)
				{
					if (text2[i] == '=')
					{
						class991_0.string_2 = text2.Substring(i);
						break;
					}
				}
				if (class991_0.string_2 != null)
				{
					string[] array2 = new string[array.Length - 1];
					Array.Copy(array, 0, array2, 0, array2.Length);
					array = array2;
				}
			}
			class991_0.string_3 = new string[array.Length];
			for (int j = 0; j < array.Length; j++)
			{
				string string_ = array[j];
				string[] array3 = Class992.smethod_1(string_);
				string[] array4 = array3[0].Split('.');
				array4[1] = Class992.smethod_3(array4[1]);
				class991_0.string_3[j] = array4[1];
				if (array3.Length <= 1)
				{
					continue;
				}
				if (class991_0.hashtable_0 == null)
				{
					class991_0.hashtable_0 = new Hashtable();
				}
				Class994 @class = new Class994();
				class991_0.hashtable_0.Add(class991_0.string_3[j], @class);
				for (int k = 1; k < array3.Length; k++)
				{
					num = array3[k].IndexOf(':');
					string text3 = array3[k].Substring(0, num);
					string text4 = array3[k].Substring(num + 1);
					switch (text3.ToLower())
					{
					case "labelposition":
						@class.int_0 = int.Parse(text4.Trim());
						break;
					case "label":
					{
						string text5 = text4;
						if (text5[0] == '"')
						{
							text5 = text5.Substring(1, text5.Length - 2);
						}
						@class.string_0 = text5;
						break;
					}
					}
				}
			}
		}
		catch
		{
		}
	}

	internal void method_7(Cell cell_0, Class991 class991_0, ArrayList arrayList_1, bool bool_2)
	{
		class991_0.cell_0 = cell_0;
		string text = cell_0.StringValue.Substring(2);
		string text2 = null;
		if (text[0] != '=' && text[0] != '&')
		{
			if (text[0] == '[')
			{
				int num = text.IndexOf("].[");
				if (num != -1)
				{
					num = text.IndexOf(']', num + 2) + 1;
					if (num >= text.Length)
					{
						text2 = "";
					}
					else
					{
						text2 = text.Substring(num);
						if (text2 != null && text2 != "" && text2[0] == '(' && text2[text2.Length - 1] == ')')
						{
							text2 = text2.Substring(1, text2.Length - 2);
						}
					}
					text = text.Substring(0, num);
				}
				else
				{
					Match match = regex_0.Match(text);
					if (match.Success)
					{
						text2 = match.Groups[1].Value;
						text = text.Substring(0, text.IndexOf("("));
					}
				}
			}
			else
			{
				Match match2 = regex_0.Match(text);
				if (match2.Success)
				{
					text2 = match2.Groups[1].Value;
					text = text.Substring(0, text.IndexOf("("));
				}
			}
		}
		else
		{
			int num2 = text.LastIndexOf('~');
			if (num2 != -1)
			{
				text2 = text.Substring(num2 + 1);
				Match match3 = regex_1.Match(text2);
				if (match3.Success)
				{
					text = text.Substring(0, num2);
					text2 = match3.Groups[1].Value;
				}
				else
				{
					text2 = null;
				}
			}
		}
		string[] array;
		if (text2 != null)
		{
			array = text2.Split(',');
			if (array.Length > 0)
			{
				string[] array2 = array;
				foreach (string text3 in array2)
				{
					string text4 = text3.Trim().ToLower();
					string key;
					if ((key = text4) != null)
					{
						if (Class1742.dictionary_32 == null)
						{
							Class1742.dictionary_32 = new Dictionary<string, int>(9)
							{
								{ "copystyle", 0 },
								{ "horizontal", 1 },
								{ "noadd", 2 },
								{ "numeric", 3 },
								{ "shift", 4 },
								{ "group", 5 },
								{ "picture", 6 },
								{ "html", 7 },
								{ "bean", 8 }
							};
						}
						if (Class1742.dictionary_32.TryGetValue(key, out var value))
						{
							switch (value)
							{
							case 0:
								class991_0.bool_2 = true;
								class991_0.int_2 = cell_0.method_36();
								continue;
							case 1:
								class991_0.bool_0 = false;
								continue;
							case 2:
								class991_0.bool_1 = false;
								continue;
							case 3:
								class991_0.bool_4 = true;
								continue;
							case 4:
								class991_0.bool_1 = false;
								class991_0.bool_3 = true;
								continue;
							case 5:
								class991_0.bool_5 = true;
								continue;
							case 6:
								class991_0.bool_11 = true;
								class991_0.bool_13 = true;
								continue;
							case 7:
								class991_0.bool_10 = true;
								continue;
							case 8:
								class991_0.bool_9 = true;
								continue;
							}
						}
					}
					if (text4.IndexOf("skip:") != -1)
					{
						try
						{
							class991_0.int_4 = int.Parse(text4.Substring(5));
						}
						catch
						{
						}
					}
					else if (text4.IndexOf("shift:") != -1)
					{
						try
						{
							class991_0.bool_1 = false;
							class991_0.bool_3 = true;
							class991_0.int_3 = int.Parse(text4.Substring(5));
						}
						catch
						{
						}
					}
					else if (text4.IndexOf("subtotal") != -1)
					{
						method_6(text4, class991_0);
					}
					else if (text4.IndexOf("group:") != -1)
					{
						class991_0.bool_5 = true;
						switch (text4.Substring("group:".Length))
						{
						case "merge":
							class991_0.enum137_0 = Enum137.const_2;
							break;
						case "repeat":
							class991_0.enum137_0 = Enum137.const_1;
							break;
						case "normal":
							class991_0.enum137_0 = Enum137.const_0;
							break;
						}
					}
					else if (text4.IndexOf("grouporder:") != -1)
					{
						class991_0.bool_5 = true;
						text4 = text4.Substring("grouporder:".Length);
						class991_0.int_7 = int.Parse(text4);
					}
					else if (text4.IndexOf("ascending:") != -1)
					{
						class991_0.bool_8 = true;
						text4 = text4.Substring("ascending:".Length).Trim();
						class991_0.int_12 = int.Parse(text4);
					}
					else if (text4.IndexOf("descending:") != -1)
					{
						class991_0.bool_8 = false;
						text4 = text4.Substring("descending:".Length).Trim();
						class991_0.int_12 = int.Parse(text4);
					}
					else
					{
						if (text4.IndexOf("picture:") == -1)
						{
							continue;
						}
						class991_0.bool_11 = true;
						text4 = text4.Substring("picture:".Length).Trim().ToLower();
						if (text4 == "fittocell")
						{
							class991_0.bool_12 = true;
							continue;
						}
						if (text4.StartsWith("scale"))
						{
							try
							{
								class991_0.bool_13 = true;
								text4 = text4.Substring("scale".Length);
								int num3 = text4.IndexOf('&');
								if (num3 != -1)
								{
									class991_0.int_18 = int.Parse(text4.Substring(0, num3));
									class991_0.int_17 = int.Parse(text4.Substring(num3 + 1));
								}
								else
								{
									class991_0.int_18 = (class991_0.int_17 = int.Parse(text4));
								}
							}
							catch
							{
							}
							continue;
						}
						class991_0.bool_13 = false;
						string[] array3 = text4.Split('&');
						for (int j = 0; j < array3.Length; j++)
						{
							if (array3[j].StartsWith("left:"))
							{
								class991_0.bool_14 = true;
								class991_0.int_13 = Class992.smethod_4(array3[j].Substring("left:".Length).Trim(), workbook_0.Worksheets.method_76());
							}
							else if (array3[j].StartsWith("top:"))
							{
								class991_0.bool_15 = true;
								class991_0.int_14 = Class992.smethod_4(array3[j].Substring("top:".Length).Trim(), workbook_0.Worksheets.method_76());
							}
							else if (array3[j].StartsWith("width:"))
							{
								class991_0.bool_16 = true;
								class991_0.int_15 = Class992.smethod_4(array3[j].Substring("width:".Length).Trim(), workbook_0.Worksheets.method_76());
							}
							else if (array3[j].StartsWith("height:"))
							{
								class991_0.bool_17 = true;
								class991_0.int_16 = Class992.smethod_4(array3[j].Substring("Height:".Length).Trim(), workbook_0.Worksheets.method_76());
							}
						}
					}
				}
			}
		}
		switch (text[0])
		{
		case '=':
			class991_0.enum138_0 = Enum138.const_1;
			class991_0.string_0 = text;
			return;
		case '$':
		{
			class991_0.string_0 = (class991_0.string_1 = text.Substring(1));
			class991_0.int_5 = 0;
			ICellsDataTable cellsDataTable = method_21(class991_0.string_0);
			if (!bool_2)
			{
				cell_0.PutValue(null);
			}
			if (cellsDataTable != null)
			{
				class991_0.int_9 = cellsDataTable.Count;
				class991_0.enum138_0 = Enum138.const_0;
			}
			return;
		}
		case '&':
			class991_0.string_0 = text.Substring(1, text.Length - 1);
			if (class991_0.string_0 != null && class991_0.string_0 != "")
			{
				class991_0.enum138_0 = Enum138.const_2;
			}
			return;
		}
		if (!bool_2)
		{
			cell_0.PutValue(null);
		}
		array = text.Split('.');
		string text5 = Class992.smethod_3(array[0]);
		if (text5 == null || text5 == "")
		{
			return;
		}
		ICellsDataTable cellsDataTable2 = method_21(text5);
		if (cellsDataTable2 == null)
		{
			return;
		}
		if (array.Length == 2)
		{
			if (class991_0.bool_9 && cellsDataTable2 != null && cellsDataTable2 is Class785)
			{
				method_19(text5);
				cellsDataTable2.BeforeFirst();
				cellsDataTable2.Next();
				object value2 = cellsDataTable2[0];
				ArrayList arrayList = new ArrayList();
				arrayList.Add(value2);
				cellsDataTable2 = Class992.smethod_5(arrayList);
				method_20(text5, cellsDataTable2);
			}
			string string_ = Class992.smethod_3(array[1]);
			int num4 = -1;
			if (cellsDataTable2 != null)
			{
				num4 = Class992.smethod_2(cellsDataTable2.Columns, string_);
			}
			if (cellsDataTable2 != null && num4 != -1)
			{
				class991_0.string_0 = text5;
				class991_0.string_1 = string_;
				class991_0.int_5 = num4;
				class991_0.enum138_0 = Enum138.const_0;
				class991_0.int_9 = cellsDataTable2.Count;
			}
			return;
		}
		if (array.Length <= 2 || cellsDataTable2 == null)
		{
			return;
		}
		string string_2 = Class992.smethod_3(array[1]);
		int num5 = Class992.smethod_2(cellsDataTable2.Columns, string_2);
		if (num5 != -1)
		{
			class991_0.string_0 = text5;
			class991_0.string_1 = string_2;
			class991_0.int_5 = num5;
			class991_0.string_5 = new string[array.Length - 2];
			for (int k = 2; k < array.Length; k++)
			{
				class991_0.string_5[k - 2] = Class992.smethod_3(array[k]);
			}
			class991_0.enum138_0 = Enum138.const_0;
			class991_0.int_9 = cellsDataTable2.Count;
		}
	}

	private int method_8(Cells cells_0, int int_0, ArrayList arrayList_1, string string_0)
	{
		Class991 @class = null;
		bool flag = false;
		bool flag2 = false;
		for (int num = arrayList_1.Count - 1; num >= 0; num--)
		{
			@class = (Class991)arrayList_1[num];
			if (@class.bool_1)
			{
				flag2 = true;
			}
			if (@class.int_10 <= 0)
			{
				Cell cell = cells_0.CheckCell(int_0 + 1, @class.cell_0.Column);
				if (cell != null)
				{
					if (cell.Type == CellValueType.IsString)
					{
						string stringValue = cell.StringValue;
						if (stringValue.ToLower().StartsWith("&=subtotal"))
						{
							stringValue = stringValue.Substring(2);
							method_6(stringValue, @class);
							@class.bool_6 = true;
							@class.int_11 = cell.method_36();
							flag = true;
							cell.method_6();
							cell.method_37(15);
							@class.row_0 = cells_0.CheckRow(int_0 + 1);
						}
						else if (stringValue.ToLower().StartsWith("&=&="))
						{
							@class.string_4 = stringValue;
							@class.int_11 = cell.method_36();
							@class.bool_7 = true;
							@class.string_4 = stringValue.Substring(3);
							cell.method_6();
							cell.method_37(15);
						}
					}
					else
					{
						@class.int_11 = cell.method_36();
					}
				}
			}
			if (@class.enum138_0 != Enum138.const_2 && @class.enum138_0 != Enum138.const_1)
			{
				if (@class.int_10 > 0 && @class.string_3 == null)
				{
					int num2 = num - 1;
					while (num2 >= 0)
					{
						Class991 class2 = (Class991)arrayList_1[num2];
						if (!class2.bool_5)
						{
							num2--;
							continue;
						}
						@class.string_3 = new string[1] { class2.string_1 };
						break;
					}
				}
			}
			else
			{
				arrayList_1.RemoveAt(num);
			}
		}
		if (flag2)
		{
			Hashtable hashtable = null;
			int num3 = 0;
			for (int i = 0; i < arrayList_1.Count; i++)
			{
				@class = (Class991)arrayList_1[i];
				if (@class.bool_5)
				{
					@class.int_8 = -1;
					if (@class.int_7 == -1)
					{
						@class.int_7 = num3;
					}
					num3++;
				}
			}
			Class991[] array = new Class991[num3];
			for (int j = 0; j < arrayList_1.Count; j++)
			{
				@class = (Class991)arrayList_1[j];
				if (@class.bool_5)
				{
					array[@class.int_7] = @class;
				}
			}
			Hashtable hashtable2 = new Hashtable();
			for (int k = 0; k < arrayList_1.Count; k++)
			{
				@class = (Class991)arrayList_1[k];
				if (@class.bool_5 || @class.string_3 == null)
				{
					continue;
				}
				for (int l = 0; l < @class.string_3.Length; l++)
				{
					if (!hashtable2.ContainsKey(@class.string_3[l]))
					{
						hashtable2.Add(@class.string_3[l], false);
					}
				}
			}
			int num4 = 0;
			int num5 = 0;
			ICellsDataTable cellsDataTable = method_21(string_0);
			int num6 = cellsDataTable.Count;
			ArrayList arrayList = new ArrayList();
			cellsDataTable.BeforeFirst();
			while (cellsDataTable.Next())
			{
				if (hashtable == null)
				{
					hashtable = method_22(hashtable, cellsDataTable, arrayList_1, 1);
					continue;
				}
				num5 = 0;
				num4 = 0;
				bool flag3 = true;
				for (int m = 0; m < array.Length; m++)
				{
					@class = array[m];
					if (@class.enum138_0 != 0 || !@class.bool_5)
					{
						continue;
					}
					object obj = hashtable[@class.int_5];
					object obj2 = cellsDataTable[@class.int_5];
					bool flag4 = Class992.smethod_0(obj);
					bool flag5 = Class992.smethod_0(obj2);
					if (flag4)
					{
						if (flag5)
						{
							continue;
						}
						if (@class.int_8 == -1)
						{
							@class.int_8 = int_0;
							hashtable[@class.int_5] = obj2;
							continue;
						}
					}
					else if (!flag5 && obj.Equals(obj2))
					{
						continue;
					}
					flag3 = false;
					for (; m < array.Length; m++)
					{
						@class = array[m];
						if (@class.enum138_0 == Enum138.const_0 && @class.int_8 != -1)
						{
							arrayList.Add(@class);
							if (hashtable2.ContainsKey(@class.string_1))
							{
								num4++;
								num5 += @class.int_4;
							}
						}
					}
				}
				num6 += num4 + num5;
				if (!flag3)
				{
					for (int n = 0; n < arrayList.Count; n++)
					{
						((Class991)arrayList[n]).int_8 = -1;
					}
					arrayList.Clear();
					hashtable = method_22(hashtable, cellsDataTable, arrayList_1, 1);
				}
			}
			for (int num7 = 0; num7 < arrayList_1.Count; num7++)
			{
				@class = (Class991)arrayList_1[num7];
				if (@class.bool_5 && @class.int_8 != -1 && hashtable2.Contains(@class.string_1))
				{
					num6++;
					num6 += @class.int_4;
				}
			}
			if (flag)
			{
				num6--;
			}
			return num6 - 1;
		}
		return 0;
	}

	private void method_9(Cells cells_0, int int_0, ArrayList arrayList_1)
	{
		bool flag = false;
		bool flag2 = false;
		Class991 @class = null;
		int num = 0;
		for (int i = 0; i < arrayList_1.Count; i++)
		{
			@class = (Class991)arrayList_1[i];
			if (@class.bool_5)
			{
				string string_ = @class.string_0;
				bool isGroup;
				ArrayList arrayList_2 = method_18(arrayList_1, string_, includeRepeatFormula: true, out isGroup);
				int num2 = method_8(cells_0, int_0, arrayList_2, string_);
				if (num2 > num)
				{
					num = num2;
				}
				if (num2 > 0)
				{
					flag = true;
				}
				i = -1;
			}
		}
		for (int j = 0; j < arrayList_1.Count; j++)
		{
			@class = (Class991)arrayList_1[j];
			switch (@class.enum138_0)
			{
			case Enum138.const_0:
				if (@class.bool_1)
				{
					flag = true;
				}
				break;
			case Enum138.const_2:
				flag2 = true;
				break;
			}
		}
		int num3 = 0;
		int num4 = 0;
		int num5 = 0;
		for (int k = 0; k < arrayList_1.Count; k++)
		{
			@class = (Class991)arrayList_1[k];
			num5 = @class.method_2();
			if (num5 > num)
			{
				num = num5;
			}
			if (@class.bool_1)
			{
				if (num5 > num3)
				{
					num3 = @class.method_2();
				}
			}
			else if (@class.bool_3)
			{
				num5 = @class.method_3();
				if (num5 > num4)
				{
					num4 = @class.method_3();
				}
			}
		}
		if (flag)
		{
			if (num > num3)
			{
				num3 = num;
			}
			InsertRows(cells_0, int_0, num3);
			num4 -= num3;
		}
		if (num4 > 0)
		{
			for (int l = 0; l < arrayList_1.Count; l++)
			{
				@class = (Class991)arrayList_1[l];
				if (@class.bool_3)
				{
					int num6 = @class.method_3();
					if (num6 > num3)
					{
						Cell cell_ = @class.cell_0;
						CellArea area = default(CellArea);
						area.StartRow = cell_.Row + 1;
						area.StartColumn = cell_.Column;
						area.EndRow = cell_.Row + 1;
						area.EndColumn = cell_.Column;
						cells_0.InsertRange(area, num6 - num3, ShiftType.Down);
					}
				}
			}
		}
		if (!flag2)
		{
			return;
		}
		for (int m = 0; m < arrayList_1.Count; m++)
		{
			@class = (Class991)arrayList_1[m];
			if (@class.enum138_0 == Enum138.const_2)
			{
				@class.int_6 = num + 1;
			}
		}
	}

	/// <summary>
	///       Processes the smart markers and populates the data source values.
	///       </summary>
	public void Process()
	{
		Process(isPreserved: false);
	}

	/// <summary>
	///       Processes the smart markers and populates the data source values.
	///       </summary>
	/// <param name="isPreserved">True if the unrecognized smart marker is preserved.</param>
	public void Process(bool isPreserved)
	{
		DataSet dataSet = Class786.smethod_0(this, object_0);
		if (dataSet != null && dataSet.Tables.Count > 0)
		{
			SetDataSource(dataSet);
		}
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < workbook_0.Worksheets.Count; i++)
		{
			Class993 @class = method_11(i, isPreserved);
			if (@class != null && @class.Count > 0)
			{
				arrayList.Add(@class);
			}
		}
		for (int j = 0; j < arrayList.Count; j++)
		{
			Class993 class2 = (Class993)arrayList[j];
			if (class2 != null && class2.Count != 0)
			{
				method_0(class2);
			}
		}
		if (dataSet != null && dataSet.Tables.Count > 0)
		{
			for (int k = 0; k < dataSet.Tables.Count; k++)
			{
				method_19(dataSet.Tables[k].TableName);
			}
		}
		bool flag = false;
		if (bool_1)
		{
			flag = true;
			workbook_0.Settings.CreateCalcChain = false;
			workbook_0.CalculateFormula();
		}
		for (int l = 0; l < workbook_0.Worksheets.Count; l++)
		{
			PivotTableCollection pivotTables = workbook_0.Worksheets[l].PivotTables;
			if (pivotTables.Count == 0)
			{
				continue;
			}
			for (int m = 0; m < pivotTables.Count; m++)
			{
				if (!pivotTables[m].RefreshDataOnOpeningFile)
				{
					pivotTables[m].RefreshDataOnOpeningFile = true;
				}
				if (!flag)
				{
					flag = true;
					workbook_0.Settings.CreateCalcChain = false;
					workbook_0.CalculateFormula();
				}
				pivotTables[m].RefreshDataFlag = true;
				pivotTables[m].RefreshData();
			}
		}
	}

	/// <summary>
	///       Processes the smart markers and populates the data source values.
	///       </summary>
	/// <param name="sheetIndex">Worksheet index.</param>
	/// <param name="isPreserved">True if the unrecognized smart marker is preserved.</param>
	/// <remarks>This method works on worksheet level.</remarks>
	public void Process(int sheetIndex, bool isPreserved)
	{
		Class993 @class = method_11(sheetIndex, isPreserved);
		if (@class != null)
		{
			method_0(@class);
		}
	}

	private bool method_10(Cell cell_0, ArrayList arrayList_1)
	{
		int num = 0;
		while (true)
		{
			if (num < arrayList_1.Count)
			{
				CellArea cellArea = (CellArea)arrayList_1[num];
				if (cell_0.Row >= cellArea.StartRow && cell_0.Row <= cellArea.EndRow && cell_0.Column >= cellArea.StartColumn && cell_0.Column <= cellArea.EndColumn)
				{
					break;
				}
				num++;
				continue;
			}
			return false;
		}
		return true;
	}

	private Class993 method_11(int int_0, bool bool_2)
	{
		Worksheet worksheet = workbook_0.Worksheets[int_0];
		Class993 @class = new Class993(worksheet);
		Class991 class2 = null;
		ArrayList arrayList = new ArrayList();
		Cells cells = worksheet.Cells;
		ArrayList arrayList2 = cells.method_42();
		for (int num = cells.Rows.Count - 1; num >= 0; num--)
		{
			Row rowByIndex = cells.Rows.GetRowByIndex(num);
			bool flag = false;
			for (int num2 = rowByIndex.method_0() - 1; num2 >= 0; num2--)
			{
				Cell cellByIndex = rowByIndex.GetCellByIndex(num2);
				if (cellByIndex.method_20() == Enum199.const_6 && (arrayList2 == null || !method_10(cellByIndex, arrayList2)))
				{
					string stringValue = cellByIndex.StringValue;
					if (stringValue.ToLower().StartsWith("&=subtotal"))
					{
						flag = true;
						break;
					}
				}
			}
			for (int num3 = rowByIndex.method_0() - 1; num3 >= 0; num3--)
			{
				Cell cellByIndex2 = rowByIndex.GetCellByIndex(num3);
				if (cellByIndex2.method_20() == Enum199.const_6 && (arrayList2 == null || !method_10(cellByIndex2, arrayList2)))
				{
					string stringValue2 = cellByIndex2.StringValue;
					if (stringValue2.StartsWith("&=") && !stringValue2.ToLower().StartsWith("&=subtotal") && (!flag || !stringValue2.StartsWith("&=&=")))
					{
						class2 = new Class991();
						method_7(cellByIndex2, class2, arrayList, bool_2);
						if (class2.enum138_0 != Enum138.const_3)
						{
							@class.Insert(0, class2);
							if (class2.bool_0)
							{
								arrayList.Insert(0, class2);
							}
						}
					}
				}
			}
			if (arrayList.Count > 0)
			{
				method_9(cells, rowByIndex.Index, arrayList);
				arrayList.Clear();
			}
		}
		if (@class.Count == 0)
		{
			return null;
		}
		if (arrayList_0 != null && cells.method_18().Count > 0)
		{
			ArrayList arrayList3 = new ArrayList(cells.method_18().Count);
			for (int i = 0; i < cells.method_18().Count; i++)
			{
				arrayList3.Add(cells.method_18()[i]);
			}
			for (int j = 0; j < arrayList_0.Count; j++)
			{
				Class990 class3 = (Class990)arrayList_0[j];
				for (int k = 0; k < arrayList3.Count; k++)
				{
					CellArea cellArea = (CellArea)arrayList3[k];
					if (cellArea.StartRow == class3.int_1 && cellArea.EndRow == class3.int_1)
					{
						int int_ = class3.int_0;
						int startColumn = cellArea.StartColumn;
						int totalColumns = cellArea.EndColumn - startColumn + 1;
						for (int l = 1; l <= int_; l++)
						{
							cells.Merge(class3.int_1 + l, startColumn, 1, totalColumns);
						}
					}
				}
			}
			arrayList_0.Clear();
		}
		method_13(cells, @class);
		return @class;
	}

	private ArrayList method_12(Class993 class993_0, int int_0, bool bool_2)
	{
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < class993_0.Count; i++)
		{
			if (class993_0[i].cell_0.Column == int_0 && !class993_0[i].bool_0)
			{
				arrayList.Add(class993_0[i]);
				if (bool_2)
				{
					class993_0.RemoveAt(i--);
				}
			}
		}
		return arrayList;
	}

	private void method_13(Cells cells_0, Class993 class993_0)
	{
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		ArrayList arrayList = null;
		int num4 = cells_0.method_22(0);
		for (int num5 = num4; num5 >= 0; num5--)
		{
			arrayList = method_12(class993_0, num5, bool_2: false);
			if (arrayList.Count != 0)
			{
				num = 0;
				num2 = 0;
				num3 = 0;
				Class991 @class = null;
				for (int i = 0; i < arrayList.Count; i++)
				{
					@class = (Class991)arrayList[i];
					if (@class.method_1() > num3)
					{
						num3 = @class.method_1();
					}
					int num6 = 0;
					if (@class.bool_1)
					{
						num6 = @class.method_2();
						if (num6 > num)
						{
							num = @class.method_2();
						}
					}
					else if (@class.bool_3)
					{
						num6 = @class.method_3();
						if (num6 > num2)
						{
							num2 = @class.method_3();
						}
					}
				}
				if (num != 0)
				{
					InsertColumns(cells_0, @class, @class.cell_0, num);
				}
				if (num2 > num)
				{
					for (int j = 0; j < arrayList.Count; j++)
					{
						@class = (Class991)arrayList[j];
						if (@class.bool_3)
						{
							int num7 = @class.method_3();
							if (num7 > num)
							{
								Cell cell_ = @class.cell_0;
								CellArea area = default(CellArea);
								area.StartRow = cell_.Row;
								area.StartColumn = cell_.Column + 1;
								area.EndRow = cell_.Row;
								area.EndColumn = cell_.Column + 1;
								cells_0.InsertRange(area, num2 - num, ShiftType.Right);
							}
						}
					}
				}
				for (int k = 0; k < arrayList.Count; k++)
				{
					@class = (Class991)arrayList[k];
					if (@class.enum138_0 == Enum138.const_2 && !@class.bool_0)
					{
						@class.int_6 = num3;
					}
				}
			}
		}
	}

	private void method_14(Class991 class991_0, Cells cells_0, int int_0, int int_1, object object_1)
	{
		if (class991_0.bool_11)
		{
			if (object_1 != null && object_1 is byte[])
			{
				method_5(cells_0, class991_0, int_0, int_1, (byte[])object_1);
			}
			return;
		}
		if (class991_0.bool_10)
		{
			cells_0.GetCell(int_0, int_1, bool_2: false).HtmlString = object_1.ToString();
			return;
		}
		Cell cell = cells_0.GetCell(int_0, int_1, bool_2: false);
		if (object_1 != null && class991_0.string_5 != null)
		{
			object_1 = Class507.smethod_0(class991_0.string_5, object_1);
		}
		if (class991_0.bool_4 && object_1 != null && object_1 is string)
		{
			cell.PutValue((string)object_1, isConverted: true);
		}
		else
		{
			cell.PutValue(object_1);
		}
		if (class991_0.bool_2)
		{
			cell.int_1 = class991_0.int_2;
		}
	}

	private void method_15(Class991 class991_0, Cells cells_0, int int_0, int int_1)
	{
		string string_ = class991_0.string_0;
		Cell cell = cells_0.GetCell(class991_0.int_0, class991_0.int_1, bool_2: false);
		cell.Formula = Class992.smethod_6(string_, class991_0.int_0, class991_0.int_1);
		if (class991_0.bool_2)
		{
			cell.int_1 = class991_0.int_2;
		}
	}

	private void method_16(Cells cells_0, Class993 class993_0)
	{
		ArrayList arrayList = null;
		object obj = null;
		int num = cells_0.method_22(0);
		for (int num2 = num; num2 >= 0; num2--)
		{
			arrayList = method_12(class993_0, num2, bool_2: true);
			if (arrayList.Count != 0)
			{
				for (int i = 0; i < arrayList.Count; i++)
				{
					Class991 @class = (Class991)arrayList[i];
					@class.method_0();
					if (@class.enum138_0 == Enum138.const_1)
					{
						string formula = Class992.smethod_6(@class.string_0, @class.cell_0.Row, @class.cell_0.Column);
						@class.cell_0.Formula = formula;
						arrayList.RemoveAt(i--);
					}
				}
				while (arrayList.Count > 0)
				{
					Class991 class2 = null;
					for (int j = 0; j < arrayList.Count; j++)
					{
						class2 = (Class991)arrayList[j];
						if (class2.enum138_0 == Enum138.const_0)
						{
							break;
						}
						class2 = null;
					}
					if (class2 == null)
					{
						break;
					}
					bool isGroup;
					ArrayList arrayList2 = method_18(arrayList, class2.string_0, includeRepeatFormula: true, out isGroup);
					ICellsDataTable cellsDataTable = method_21(class2.string_0);
					cellsDataTable.BeforeFirst();
					while (cellsDataTable.Next())
					{
						for (int k = 0; k < arrayList2.Count; k++)
						{
							class2 = (Class991)arrayList2[k];
							switch (class2.enum138_0)
							{
							case Enum138.const_0:
								obj = cellsDataTable[class2.int_5];
								method_14(class2, cells_0, class2.int_0, class2.int_1, obj);
								class2.int_1 += class2.int_4 + 1;
								break;
							case Enum138.const_2:
								method_15(class2, cells_0, class2.int_0, class2.int_1);
								class2.int_1 += 1 + class2.int_4;
								break;
							}
						}
					}
				}
			}
		}
	}

	private void InsertColumns(Cells cells_0, Class991 class991_0, Cell cell_0, int int_0)
	{
		int num = cell_0.Column + 1;
		for (int i = 0; i < cells_0.method_18().Count; i++)
		{
			CellArea cellArea = cells_0.method_18()[i];
			if (cellArea.StartRow <= cell_0.Row && cellArea.EndRow >= cell_0.Row && cellArea.StartColumn <= cell_0.Column && cellArea.EndColumn >= cell_0.Column)
			{
				num = cellArea.EndColumn + 1;
				break;
			}
		}
		if (class991_0.bool_2)
		{
			cells_0.Rows.InsertColumns(num, int_0);
			if (num <= cells_0.MaxColumn)
			{
				cells_0.method_21((short)(cells_0.MaxColumn + int_0));
			}
			cells_0.Columns.InsertColumns(num, int_0);
		}
		else
		{
			cells_0.InsertColumns(num, int_0);
		}
		method_17(cells_0, -1, num - 1, bool_2: false, int_0);
	}

	private void method_17(Cells cells_0, int int_0, int int_1, bool bool_2, int int_2)
	{
		for (int i = 0; i < cells_0.Rows.Count; i++)
		{
			Row rowByIndex = cells_0.Rows.GetRowByIndex(i);
			for (int j = 0; j < rowByIndex.method_0(); j++)
			{
				Cell cellByIndex = rowByIndex.GetCellByIndex(j);
				if (cellByIndex.method_41() != null)
				{
					Class1674.smethod_25(cells_0.method_3(), bool_0: true, int_0, int_1, bool_2, int_2, -1, -1, cellByIndex.method_41());
				}
			}
		}
		for (int k = 0; k < cells_0.method_19().Count; k++)
		{
			Worksheet worksheet = cells_0.method_19()[k];
			ChartCollection charts = worksheet.Charts;
			for (int l = 0; l < charts.Count; l++)
			{
				Chart chart = charts[l];
				for (int m = 0; m < chart.NSeries.Count; m++)
				{
					Series series = chart.NSeries[m];
					if (series.method_18() != null && series.method_18().imethod_4() != null)
					{
						Class1674.smethod_25(cells_0.method_3(), worksheet == cells_0.method_3(), 0, 0, bool_2, int_2, -1, -1, series.method_18().imethod_4());
					}
					if (series.method_16() != null && series.method_16().imethod_4() != null)
					{
						Class1674.smethod_25(cells_0.method_3(), worksheet == cells_0.method_3(), 0, 0, bool_2, int_2, -1, -1, series.method_16().imethod_4());
					}
				}
			}
		}
		NameCollection names = cells_0.method_19().Names;
		for (int n = 0; n < names.Count; n++)
		{
			Name name = names[n];
			if (name.method_2() != null)
			{
				Class1674.smethod_25(cells_0.method_3(), bool_0: false, int_0, int_1, bool_2, int_2, -1, -1, name.method_2());
			}
		}
	}

	private void InsertRows(Cells cells_0, int int_0, int int_1)
	{
		cells_0.InsertRows(int_0 + 1, int_1, bool_0);
		method_17(cells_0, int_0, -1, bool_2: true, int_1);
		if (cells_0.method_18().Count != 0)
		{
			if (arrayList_0 == null)
			{
				arrayList_0 = new ArrayList();
			}
			else
			{
				for (int i = 0; i < arrayList_0.Count; i++)
				{
					Class990 @class = (Class990)arrayList_0[i];
					if (@class.int_1 > int_0)
					{
						@class.int_1 += int_1;
					}
				}
			}
			arrayList_0.Add(new Class990(int_1, int_0));
		}
		if (cells_0.method_3().ListObjects.Count != 0)
		{
			ListObjectCollection listObjects = cells_0.method_3().ListObjects;
			for (int j = 0; j < listObjects.Count; j++)
			{
				ListObject listObject = listObjects[j];
				if (listObject.EndRow == int_0)
				{
					listObject.method_4(listObject.EndRow + int_1);
				}
			}
		}
		if (cells_0.method_19().method_89().Count != 0)
		{
			for (int k = 0; k < cells_0.method_19().method_89().Count; k++)
			{
				cells_0.method_19().method_89()[k].method_3(int_0, int_1, cells_0.method_3());
			}
		}
	}

	/// <summary>
	///       Returns a collection of smart markers in a spreadsheet.
	///       </summary>
	/// <returns>A collection of smart markers</returns>
	/// <remarks>A string array is created on every call. The array is sorted and duplicated values are removed.</remarks>
	public string[] GetSmartMarkers()
	{
		return workbook_0.Worksheets.class1301_0.GetSmartMarkers();
	}

	/// <summary>
	///       Sets data source of a OleDbConnection object.
	///       </summary>
	/// <param name="connection">OleDbConnection object</param>
	public void SetDataSource(OleDbConnection connection)
	{
		object_0 = connection;
	}

	/// <summary>
	///       Sets data source of a SqlConnection object.
	///       </summary>
	/// <param name="connection">SqlConnection object</param>
	public void SetDataSource(SqlConnection connection)
	{
		object_0 = connection;
	}

	private ArrayList method_18(ArrayList smartsInRow, string tableName, bool includeRepeatFormula, out bool isGroup)
	{
		ArrayList arrayList = new ArrayList();
		isGroup = false;
		bool flag = false;
		for (int i = 0; i < smartsInRow.Count; i++)
		{
			Class991 @class = (Class991)smartsInRow[i];
			Enum138 enum138_ = @class.enum138_0;
			if (enum138_ == Enum138.const_2)
			{
				if (includeRepeatFormula)
				{
					if (flag)
					{
						arrayList.Add(@class);
						smartsInRow.RemoveAt(i--);
					}
					else
					{
						arrayList.Add(@class);
						smartsInRow.RemoveAt(i--);
					}
				}
				continue;
			}
			if (string.Compare(tableName, @class.string_0, ignoreCase: true) == 0)
			{
				arrayList.Add(@class);
				smartsInRow.RemoveAt(i--);
				flag = true;
			}
			if (@class.bool_5)
			{
				isGroup = true;
			}
		}
		return arrayList;
	}

	private void method_19(string string_0)
	{
		hashtable_0.Remove(string_0.ToUpper());
	}

	private void method_20(string string_0, ICellsDataTable icellsDataTable_0)
	{
		hashtable_0.Add(string_0.ToUpper(), icellsDataTable_0);
	}

	private ICellsDataTable method_21(string string_0)
	{
		return (ICellsDataTable)hashtable_0[string_0.ToUpper()];
	}

	private Hashtable method_22(Hashtable hashtable_1, ICellsDataTable icellsDataTable_0, ArrayList arrayList_1, int int_0)
	{
		if (hashtable_1 == null)
		{
			hashtable_1 = new Hashtable();
			for (int i = 0; i < arrayList_1.Count; i++)
			{
				Class991 @class = (Class991)arrayList_1[i];
				if (@class.bool_5)
				{
					object value = icellsDataTable_0[@class.int_5];
					hashtable_1.Add(@class.int_5, value);
					if (@class.int_8 == -1 && !Class992.smethod_0(value))
					{
						@class.int_8 = int_0;
					}
				}
			}
		}
		else
		{
			for (int j = 0; j < arrayList_1.Count; j++)
			{
				Class991 class2 = (Class991)arrayList_1[j];
				if (class2.bool_5)
				{
					object value2 = icellsDataTable_0[class2.int_5];
					hashtable_1[class2.int_5] = value2;
					if (class2.int_8 == -1 && !Class992.smethod_0(value2))
					{
						class2.int_8 = int_0;
					}
				}
			}
		}
		return hashtable_1;
	}
}
