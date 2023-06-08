namespace PageOffice.ExcelReader;

public interface IDataFieldCollection
{
	int Count { get; }

	string KeyValue { get; }

	bool IsEmpty { get; }

	DataField this[int index] { get; }
}
