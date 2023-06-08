using System.Collections;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[ComImport]
[ClassInterface(0)]
[Guid("000D0A0B-0000-0000-C000-000000000046")]
[ComSourceInterfaces("Microsoft.Office.Interop.Visio.EWindows\0\0")]
public class WindowsClass : IVWindows, Windows, EWindows_Event, IEnumerable
{
	[DispId(3)]
	public virtual extern Application Application
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(3)]
		[return: MarshalAs(UnmanagedType.Interface)]
		get;
	}

	[DispId(2)]
	public virtual extern short ObjectType
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(2)]
		get;
	}

	[DispId(0)]
	public virtual extern Window this[[In] short Index]
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(0)]
		[return: MarshalAs(UnmanagedType.Interface)]
		get;
	}

	[DispId(1)]
	public virtual extern short Count
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1)]
		get;
	}

	[DispId(5)]
	public virtual extern EventList EventList
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(5)]
		[return: MarshalAs(UnmanagedType.Interface)]
		get;
	}

	[DispId(6)]
	public virtual extern short PersistsEvents
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(6)]
		get;
	}

	[DispId(9)]
	public virtual extern Window ItemFromID
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(9)]
		[return: MarshalAs(UnmanagedType.Interface)]
		get;
	}

	[DispId(10)]
	public virtual extern Window ItemEx
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(10)]
		[return: MarshalAs(UnmanagedType.Interface)]
		get;
	}

	public virtual extern event EWindows_WindowOpenedEventHandler WindowOpened;

	public virtual extern event EWindows_SelectionChangedEventHandler SelectionChanged;

	public virtual extern event EWindows_BeforeWindowClosedEventHandler BeforeWindowClosed;

	public virtual extern event EWindows_WindowActivatedEventHandler WindowActivated;

	public virtual extern event EWindows_BeforeWindowSelDeleteEventHandler BeforeWindowSelDelete;

	public virtual extern event EWindows_BeforeWindowPageTurnEventHandler BeforeWindowPageTurn;

	public virtual extern event EWindows_WindowTurnedToPageEventHandler WindowTurnedToPage;

	public virtual extern event EWindows_WindowChangedEventHandler WindowChanged;

	public virtual extern event EWindows_ViewChangedEventHandler ViewChanged;

	public virtual extern event EWindows_QueryCancelWindowCloseEventHandler QueryCancelWindowClose;

	public virtual extern event EWindows_WindowCloseCanceledEventHandler WindowCloseCanceled;

	public virtual extern event EWindows_OnKeystrokeMessageForAddonEventHandler OnKeystrokeMessageForAddon;

	public virtual extern event EWindows_MouseDownEventHandler MouseDown;

	public virtual extern event EWindows_MouseMoveEventHandler MouseMove;

	public virtual extern event EWindows_MouseUpEventHandler MouseUp;

	public virtual extern event EWindows_KeyDownEventHandler KeyDown;

	public virtual extern event EWindows_KeyPressEventHandler KeyPress;

	public virtual extern event EWindows_KeyUpEventHandler KeyUp;

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[TypeLibFunc(64)]
	[DispId(4)]
	public virtual extern void VoidArrange();

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(7)]
	[TypeLibFunc(64)]
	[return: MarshalAs(UnmanagedType.Interface)]
	public virtual extern Window Add_WithoutMergeArgs([Optional][In][MarshalAs(UnmanagedType.Struct)] object bstrCaption, [Optional][In][MarshalAs(UnmanagedType.Struct)] object nFlags, [Optional][In][MarshalAs(UnmanagedType.Struct)] object nType, [Optional][In][MarshalAs(UnmanagedType.Struct)] object nLeft, [Optional][In][MarshalAs(UnmanagedType.Struct)] object nTop, [Optional][In][MarshalAs(UnmanagedType.Struct)] object nWidth, [Optional][In][MarshalAs(UnmanagedType.Struct)] object nHeight);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(8)]
	public virtual extern void Arrange([Optional][In][MarshalAs(UnmanagedType.Struct)] object nArrangeFlags);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(-4)]
	[TypeLibFunc(1)]
	[return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalType = "System.Runtime.InteropServices.CustomMarshalers.EnumeratorToEnumVariantMarshaler, CustomMarshalers, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
	public virtual extern IEnumerator GetEnumerator();

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(1610743819)]
	[return: MarshalAs(UnmanagedType.Interface)]
	public virtual extern Window Add([Optional][In][MarshalAs(UnmanagedType.Struct)] object bstrCaption, [Optional][In][MarshalAs(UnmanagedType.Struct)] object nFlags, [Optional][In][MarshalAs(UnmanagedType.Struct)] object nType, [Optional][In][MarshalAs(UnmanagedType.Struct)] object nLeft, [Optional][In][MarshalAs(UnmanagedType.Struct)] object nTop, [Optional][In][MarshalAs(UnmanagedType.Struct)] object nWidth, [Optional][In][MarshalAs(UnmanagedType.Struct)] object nHeight, [Optional][In][MarshalAs(UnmanagedType.Struct)] object bstrMergeID, [Optional][In][MarshalAs(UnmanagedType.Struct)] object bstrMergeClass, [Optional][In][MarshalAs(UnmanagedType.Struct)] object nMergePosition);
}
