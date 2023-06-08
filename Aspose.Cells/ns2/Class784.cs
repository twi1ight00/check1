using System.Collections;
using System.Data;
using Aspose.Cells;

namespace ns2;

internal class Class784 : ICellsDataTable
{
	internal string[] string_0;

	internal DataView dataView_0;

	private DataRowView dataRowView_0;

	private IEnumerator ienumerator_0;

	public object this[int columnIndex] => dataRowView_0[columnIndex];

	public object this[string columnName] => dataRowView_0[columnName];

	public string[] Columns => string_0;

	public int Count => dataView_0.Count;

	internal Class784(DataView dataView_1)
	{
		dataView_0 = dataView_1;
		string_0 = new string[dataView_1.Table.Columns.Count];
		for (int i = 0; i < dataView_1.Table.Columns.Count; i++)
		{
			string_0[i] = dataView_1.Table.Columns[i].ColumnName;
		}
		ienumerator_0 = dataView_0.GetEnumerator();
	}

	public void BeforeFirst()
	{
		ienumerator_0 = dataView_0.GetEnumerator();
		dataRowView_0 = null;
	}

	public bool Next()
	{
		if (ienumerator_0 == null)
		{
			return false;
		}
		if (ienumerator_0.MoveNext())
		{
			dataRowView_0 = (DataRowView)ienumerator_0.Current;
			return true;
		}
		return false;
	}
}
