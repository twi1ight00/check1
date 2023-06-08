using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[ComImport]
[Guid("000D0B02-0000-0000-C000-000000000046")]
[InterfaceType(2)]
[TypeLibType(4112)]
public interface EWindow
{
	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(701)]
	void SelectionChanged([In][MarshalAs(UnmanagedType.Interface)] Window Window);

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(16385)]
	void BeforeWindowClosed([In][MarshalAs(UnmanagedType.Interface)] Window Window);

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(4224)]
	void WindowActivated([In][MarshalAs(UnmanagedType.Interface)] Window Window);

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(702)]
	void BeforeWindowSelDelete([In][MarshalAs(UnmanagedType.Interface)] Window Window);

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(703)]
	void BeforeWindowPageTurn([In][MarshalAs(UnmanagedType.Interface)] Window Window);

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(704)]
	void WindowTurnedToPage([In][MarshalAs(UnmanagedType.Interface)] Window Window);

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(8193)]
	void WindowChanged([In][MarshalAs(UnmanagedType.Interface)] Window Window);

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(705)]
	void ViewChanged([In][MarshalAs(UnmanagedType.Interface)] Window Window);

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(706)]
	bool QueryCancelWindowClose([In][MarshalAs(UnmanagedType.Interface)] Window Window);

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(707)]
	void WindowCloseCanceled([In][MarshalAs(UnmanagedType.Interface)] Window Window);

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(708)]
	bool OnKeystrokeMessageForAddon([In][MarshalAs(UnmanagedType.Interface)] MSGWrap MSG);

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(709)]
	void MouseDown([In] int Button, [In] int KeyButtonState, [In] double x, [In] double y, [In][Out] ref bool CancelDefault);

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(710)]
	void MouseMove([In] int Button, [In] int KeyButtonState, [In] double x, [In] double y, [In][Out] ref bool CancelDefault);

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(711)]
	void MouseUp([In] int Button, [In] int KeyButtonState, [In] double x, [In] double y, [In][Out] ref bool CancelDefault);

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(712)]
	void KeyDown([In] int KeyCode, [In] int KeyButtonState, [In][Out] ref bool CancelDefault);

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(713)]
	void KeyPress([In] int KeyAscii, [In][Out] ref bool CancelDefault);

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(714)]
	void KeyUp([In] int KeyCode, [In] int KeyButtonState, [In][Out] ref bool CancelDefault);
}
