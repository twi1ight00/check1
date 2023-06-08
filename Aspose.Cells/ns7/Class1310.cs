using Aspose.Cells;

namespace ns7;

internal class Class1310
{
	public object object_0;

	public CellValueType cellValueType_0;

	public override string ToString()
	{
		string result = "";
		switch (cellValueType_0)
		{
		case CellValueType.IsBool:
			result = "IsBool";
			break;
		case CellValueType.IsDateTime:
			result = "IsDateTime";
			break;
		case CellValueType.IsError:
			result = "IsError";
			break;
		case CellValueType.IsNull:
			result = "IsNull";
			break;
		case CellValueType.IsNumeric:
			result = "IsNumeric";
			break;
		case CellValueType.IsString:
			result = "IsString";
			break;
		case CellValueType.IsUnknown:
			result = "IsUnknown";
			break;
		}
		return result;
	}
}
