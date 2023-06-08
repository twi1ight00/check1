using Aspose.Words.Fields;

namespace Aspose.Words.Reporting;

public abstract class FieldMergingArgsBase
{
	private readonly Document xd1424e1a0bb4a72b;

	private readonly string x36e76b649e6f4ede;

	private readonly int xaff733c5c16ee620;

	private readonly string xcd243a5d7178f0b0;

	private readonly string xe499ad98c876ec8e;

	private readonly object xc84319e31b1d033e;

	private readonly Field x54c413cc80cb99d5;

	public Document Document => xd1424e1a0bb4a72b;

	public string TableName => x36e76b649e6f4ede;

	public int RecordIndex => xaff733c5c16ee620;

	public string FieldName => xcd243a5d7178f0b0;

	public string DocumentFieldName => xe499ad98c876ec8e;

	public object FieldValue => xc84319e31b1d033e;

	public Field Field => x54c413cc80cb99d5;

	internal FieldMergingArgsBase(Document document, string tableName, int recordIndex, Field field, string fieldName, string documentFieldName, object fieldValue)
	{
		xd1424e1a0bb4a72b = document;
		x36e76b649e6f4ede = tableName;
		xaff733c5c16ee620 = recordIndex;
		x54c413cc80cb99d5 = field;
		xcd243a5d7178f0b0 = fieldName;
		xe499ad98c876ec8e = documentFieldName;
		xc84319e31b1d033e = fieldValue;
	}
}
