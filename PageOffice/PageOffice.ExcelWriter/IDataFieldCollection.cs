namespace PageOffice.ExcelWriter;

public interface IDataFieldCollection
{
	int Count { get; }

	string KeyValue { set; }

	DataField this[int index] { get; }
}
