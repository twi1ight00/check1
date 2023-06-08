using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[ComVisible(false)]
[ComEventInterface(typeof(EDataRecordset_0000), typeof(EDataRecordset_EventProvider_0000))]
[TypeLibType(16)]
public interface EDataRecordset_Event
{
	event EDataRecordset_DataRecordsetChangedEventHandler DataRecordsetChanged;

	event EDataRecordset_BeforeDataRecordsetDeleteEventHandler BeforeDataRecordsetDelete;
}
