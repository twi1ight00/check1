using System.Runtime.CompilerServices;
using Aspose.Cells.Render;

namespace ns3;

internal interface Interface27
{
	Interface28 this[int int_0] { get; }

	int Count { get; }

	[SpecialName]
	Interface10 imethod_0();

	[SpecialName]
	Interface10 imethod_1();

	Interface28 Add(ChartType_Chart chartType_Chart_0);

	void RemoveAt(int index);
}
