using System.Data;
using Aspose.Cells;

namespace ns2;

internal class Class782 : ICellsDataTable
{
	internal int int_0;

	internal string[] string_0;

	internal IDataReader idataReader_0;

	public object this[int columnIndex] => idataReader_0[columnIndex];

	public object this[string columnName] => idataReader_0[columnName];

	public string[] Columns => string_0;

	public int Count => int_0;

	internal Class782(IDataReader idataReader_1, int int_1)
	{
		idataReader_0 = idataReader_1;
		int_0 = int_1;
		if (int_1 < 0)
		{
			int_0 = 0;
		}
		DataTable schemaTable = idataReader_1.GetSchemaTable();
		string_0 = new string[idataReader_1.FieldCount];
		for (int i = 0; i < string_0.Length; i++)
		{
			DataRow dataRow = schemaTable.Rows[i];
			string_0[i] = (string)dataRow["ColumnName"];
		}
	}

	public void BeforeFirst()
	{
	}

	public bool Next()
	{
		return idataReader_0.Read();
	}
}
