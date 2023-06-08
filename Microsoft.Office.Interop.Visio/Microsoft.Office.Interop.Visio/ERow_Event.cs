using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[ComEventInterface(typeof(ERow_0000), typeof(ERow_EventProvider_0000))]
[ComVisible(false)]
[TypeLibType(16)]
public interface ERow_Event
{
	event ERow_CellChangedEventHandler CellChanged;

	event ERow_FormulaChangedEventHandler FormulaChanged;
}
