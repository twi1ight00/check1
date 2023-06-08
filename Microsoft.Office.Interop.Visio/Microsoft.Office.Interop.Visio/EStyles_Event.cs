using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[TypeLibType(16)]
[ComVisible(false)]
[ComEventInterface(typeof(EStyles_0000), typeof(EStyles_EventProvider_0000))]
public interface EStyles_Event
{
	event EStyles_StyleAddedEventHandler StyleAdded;

	event EStyles_StyleChangedEventHandler StyleChanged;

	event EStyles_BeforeStyleDeleteEventHandler BeforeStyleDelete;

	event EStyles_QueryCancelStyleDeleteEventHandler QueryCancelStyleDelete;

	event EStyles_StyleDeleteCanceledEventHandler StyleDeleteCanceled;
}
