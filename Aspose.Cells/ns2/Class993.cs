using System.Collections;
using System.Runtime.CompilerServices;
using Aspose.Cells;

namespace ns2;

internal class Class993 : CollectionBase
{
	private Worksheet worksheet_0;

	public Class991 this[int int_0] => (Class991)base.InnerList[int_0];

	internal Class993(Worksheet worksheet_1)
	{
		worksheet_0 = worksheet_1;
	}

	[SpecialName]
	internal Worksheet method_0()
	{
		return worksheet_0;
	}

	internal void Insert(int int_0, Class991 class991_0)
	{
		base.InnerList.Insert(int_0, class991_0);
	}
}
