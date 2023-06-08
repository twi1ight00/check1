using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[TypeLibType(16)]
[ComVisible(false)]
[ComEventInterface(typeof(ECell_0000), typeof(ECell_EventProvider_0000))]
public interface ECell_Event
{
	event ECell_CellChangedEventHandler CellChanged;

	event ECell_FormulaChangedEventHandler FormulaChanged;
}
