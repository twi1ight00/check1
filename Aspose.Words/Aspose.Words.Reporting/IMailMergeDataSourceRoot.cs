namespace Aspose.Words.Reporting;

public interface IMailMergeDataSourceRoot
{
	[JavaThrows(true)]
	IMailMergeDataSource GetDataSource(string tableName);
}
