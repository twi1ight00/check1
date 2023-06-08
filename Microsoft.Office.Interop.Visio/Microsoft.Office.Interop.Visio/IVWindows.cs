using System.Collections;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[ComImport]
[Guid("000D0711-0000-0000-C000-000000000046")]
[TypeLibType(4176)]
public interface IVWindows : IEnumerable
{
	[DispId(3)]
	Application Application
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(3)]
		[return: MarshalAs(UnmanagedType.Interface)]
		get;
	}

	[DispId(2)]
	short ObjectType
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(2)]
		get;
	}

	[DispId(0)]
	Window this[[In] short Index]
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(0)]
		[return: MarshalAs(UnmanagedType.Interface)]
		get;
	}

	[DispId(1)]
	short Count
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1)]
		get;
	}

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(4)]
	[TypeLibFunc(64)]
	void VoidArrange();

	[DispId(5)]
	EventList EventList
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(5)]
		[return: MarshalAs(UnmanagedType.Interface)]
		get;
	}

	[DispId(6)]
	short PersistsEvents
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(6)]
		get;
	}

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[TypeLibFunc(64)]
	[DispId(7)]
	[return: MarshalAs(UnmanagedType.Interface)]
	Window Add_WithoutMergeArgs([Optional][In][MarshalAs(UnmanagedType.Struct)] object bstrCaption, [Optional][In][MarshalAs(UnmanagedType.Struct)] object nFlags, [Optional][In][MarshalAs(UnmanagedType.Struct)] object nType, [Optional][In][MarshalAs(UnmanagedType.Struct)] object nLeft, [Optional][In][MarshalAs(UnmanagedType.Struct)] object nTop, [Optional][In][MarshalAs(UnmanagedType.Struct)] object nWidth, [Optional][In][MarshalAs(UnmanagedType.Struct)] object nHeight);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(8)]
	void Arrange([Optional][In][MarshalAs(UnmanagedType.Struct)] object nArrangeFlags);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[TypeLibFunc(1)]
	[DispId(-4)]
	[return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalType = "System.Runtime.InteropServices.CustomMarshalers.EnumeratorToEnumVariantMarshaler, CustomMarshalers, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
	new IEnumerator GetEnumerator();

	[DispId(9)]
	Window ItemFromID
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(9)]
		[return: MarshalAs(UnmanagedType.Interface)]
		get;
	}

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(1610743819)]
	[return: MarshalAs(UnmanagedType.Interface)]
	Window Add([Optional][In][MarshalAs(UnmanagedType.Struct)] object bstrCaption, [Optional][In][MarshalAs(UnmanagedType.Struct)] object nFlags, [Optional][In][MarshalAs(UnmanagedType.Struct)] object nType, [Optional][In][MarshalAs(UnmanagedType.Struct)] object nLeft, [Optional][In][MarshalAs(UnmanagedType.Struct)] object nTop, [Optional][In][MarshalAs(UnmanagedType.Struct)] object nWidth, [Optional][In][MarshalAs(UnmanagedType.Struct)] object nHeight, [Optional][In][MarshalAs(UnmanagedType.Struct)] object bstrMergeID, [Optional][In][MarshalAs(UnmanagedType.Struct)] object bstrMergeClass, [Optional][In][MarshalAs(UnmanagedType.Struct)] object nMergePosition);

	[DispId(10)]
	Window ItemEx
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(10)]
		[return: MarshalAs(UnmanagedType.Interface)]
		get;
	}
}
