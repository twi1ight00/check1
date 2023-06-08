using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[TypeLibType(16)]
[ComVisible(false)]
[ComEventInterface(typeof(EWindows_0000), typeof(EWindows_EventProvider_0000))]
public interface EWindows_Event
{
	event EWindows_WindowOpenedEventHandler WindowOpened;

	event EWindows_SelectionChangedEventHandler SelectionChanged;

	event EWindows_BeforeWindowClosedEventHandler BeforeWindowClosed;

	event EWindows_WindowActivatedEventHandler WindowActivated;

	event EWindows_BeforeWindowSelDeleteEventHandler BeforeWindowSelDelete;

	event EWindows_BeforeWindowPageTurnEventHandler BeforeWindowPageTurn;

	event EWindows_WindowTurnedToPageEventHandler WindowTurnedToPage;

	event EWindows_WindowChangedEventHandler WindowChanged;

	event EWindows_ViewChangedEventHandler ViewChanged;

	event EWindows_QueryCancelWindowCloseEventHandler QueryCancelWindowClose;

	event EWindows_WindowCloseCanceledEventHandler WindowCloseCanceled;

	event EWindows_OnKeystrokeMessageForAddonEventHandler OnKeystrokeMessageForAddon;

	event EWindows_MouseDownEventHandler MouseDown;

	event EWindows_MouseMoveEventHandler MouseMove;

	event EWindows_MouseUpEventHandler MouseUp;

	event EWindows_KeyDownEventHandler KeyDown;

	event EWindows_KeyPressEventHandler KeyPress;

	event EWindows_KeyUpEventHandler KeyUp;
}
