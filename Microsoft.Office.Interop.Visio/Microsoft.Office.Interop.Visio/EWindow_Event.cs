using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[TypeLibType(16)]
[ComEventInterface(typeof(EWindow_0000), typeof(EWindow_EventProvider_0000))]
[ComVisible(false)]
public interface EWindow_Event
{
	event EWindow_SelectionChangedEventHandler SelectionChanged;

	event EWindow_BeforeWindowClosedEventHandler BeforeWindowClosed;

	event EWindow_WindowActivatedEventHandler WindowActivated;

	event EWindow_BeforeWindowSelDeleteEventHandler BeforeWindowSelDelete;

	event EWindow_BeforeWindowPageTurnEventHandler BeforeWindowPageTurn;

	event EWindow_WindowTurnedToPageEventHandler WindowTurnedToPage;

	event EWindow_WindowChangedEventHandler WindowChanged;

	event EWindow_ViewChangedEventHandler ViewChanged;

	event EWindow_QueryCancelWindowCloseEventHandler QueryCancelWindowClose;

	event EWindow_WindowCloseCanceledEventHandler WindowCloseCanceled;

	event EWindow_OnKeystrokeMessageForAddonEventHandler OnKeystrokeMessageForAddon;

	event EWindow_MouseDownEventHandler MouseDown;

	event EWindow_MouseMoveEventHandler MouseMove;

	event EWindow_MouseUpEventHandler MouseUp;

	event EWindow_KeyDownEventHandler KeyDown;

	event EWindow_KeyPressEventHandler KeyPress;

	event EWindow_KeyUpEventHandler KeyUp;
}
