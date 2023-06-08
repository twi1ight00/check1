namespace Aspose.Cells;

public interface ICellsDataTable
{
	string[] Columns { get; }

	int Count { get; }

	object this[int columnIndex] { get; }

	object this[string columnName] { get; }

	void BeforeFirst();

	bool Next();
}
