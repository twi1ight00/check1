using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[TypeLibType(16)]
[ComEventInterface(typeof(ESection_0000), typeof(ESection_EventProvider_0000))]
[ComVisible(false)]
public interface ESection_Event
{
	event ESection_CellChangedEventHandler CellChanged;

	event ESection_FormulaChangedEventHandler FormulaChanged;
}
