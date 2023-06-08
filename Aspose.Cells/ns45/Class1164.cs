using System.Collections;
using Aspose.Cells.Pivot;

namespace ns45;

internal class Class1164 : CollectionBase
{
	internal PivotTable pivotTable_0;

	public Class1163 this[int int_0] => (Class1163)base.InnerList[int_0];

	internal Class1164(PivotTable pivotTable_1)
	{
		pivotTable_0 = pivotTable_1;
	}

	internal void Add(Class1163 class1163_0)
	{
		base.InnerList.Add(class1163_0);
	}

	internal void Remove(Class1163 class1163_0)
	{
		base.InnerList.Remove(class1163_0);
	}
}
