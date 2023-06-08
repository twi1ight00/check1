using System.Runtime.CompilerServices;
using Aspose.Cells;

namespace ns14;

internal class Class530
{
	private object object_0;

	private string string_0;

	private string string_1;

	private string string_2;

	private CellValueType cellValueType_0;

	public object Value => object_0;

	internal void Reset()
	{
		cellValueType_0 = CellValueType.IsNull;
		object_0 = null;
		string_0 = null;
		string_1 = null;
		string_2 = null;
	}

	internal void method_0(CellValueType cellValueType_1, object object_1)
	{
		cellValueType_0 = cellValueType_1;
		object_0 = object_1;
	}

	[SpecialName]
	public CellValueType method_1()
	{
		return cellValueType_0;
	}

	internal void method_2(string string_3)
	{
		string_0 = string_3;
	}

	[SpecialName]
	public string method_3()
	{
		return string_0;
	}

	internal void method_4(string string_3)
	{
		string_1 = string_3;
	}

	[SpecialName]
	public string method_5()
	{
		return string_1;
	}

	internal void method_6(string string_3)
	{
		string_2 = string_3;
	}

	[SpecialName]
	public string method_7()
	{
		return string_2;
	}
}
