using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[TypeLibType(16)]
[ComVisible(false)]
[ComEventInterface(typeof(EStyle_0000), typeof(EStyle_EventProvider_0000))]
public interface EStyle_Event
{
	event EStyle_StyleChangedEventHandler StyleChanged;

	event EStyle_BeforeStyleDeleteEventHandler BeforeStyleDelete;

	event EStyle_QueryCancelStyleDeleteEventHandler QueryCancelStyleDelete;

	event EStyle_StyleDeleteCanceledEventHandler StyleDeleteCanceled;
}
