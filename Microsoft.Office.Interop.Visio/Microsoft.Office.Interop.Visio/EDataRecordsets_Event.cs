using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[ComEventInterface(typeof(EDataRecordsets_0000), typeof(EDataRecordsets_EventProvider_0000))]
[TypeLibType(16)]
[ComVisible(false)]
public interface EDataRecordsets_Event
{
	event EDataRecordsets_DataRecordsetAddedEventHandler DataRecordsetAdded;

	event EDataRecordsets_BeforeDataRecordsetDeleteEventHandler BeforeDataRecordsetDelete;

	event EDataRecordsets_DataRecordsetChangedEventHandler DataRecordsetChanged;
}
