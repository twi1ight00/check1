namespace Aspose.Words.Reporting;

public interface IMailMergeDataSource
{
	[JavaThrows(true)]
	string TableName { get; }

	[JavaThrows(true)]
	bool MoveNext();

	[JavaThrows(true)]
	bool GetValue(string fieldName, out object fieldValue);

	[JavaThrows(true)]
	IMailMergeDataSource GetChildDataSource(string tableName);
}
