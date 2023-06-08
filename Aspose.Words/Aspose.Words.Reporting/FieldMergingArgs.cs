using Aspose.Words.Fields;

namespace Aspose.Words.Reporting;

public class FieldMergingArgs : FieldMergingArgsBase
{
	private string xed4a7b1500064e12;

	public string Text
	{
		get
		{
			return xed4a7b1500064e12;
		}
		set
		{
			xed4a7b1500064e12 = value;
		}
	}

	internal FieldMergingArgs(Document document, string tableName, int recordIndex, Field field, string fieldName, string documentFieldName, object fieldValue)
		: base(document, tableName, recordIndex, field, fieldName, documentFieldName, fieldValue)
	{
	}
}
