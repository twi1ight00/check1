using System.Collections;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[ComImport]
[ComSourceInterfaces("Microsoft.Office.Interop.Visio.EDataRecordsets\0\0")]
[Guid("000D0A2B-0000-0000-C000-000000000046")]
[ClassInterface(0)]
public class DataRecordsetsClass : IVDataRecordsets, DataRecordsets, EDataRecordsets_Event, IEnumerable
{
	[DispId(1610743808)]
	public virtual extern Application Application
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1610743808)]
		[return: MarshalAs(UnmanagedType.Interface)]
		get;
	}

	[DispId(1610743809)]
	public virtual extern short Stat
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1610743809)]
		get;
	}

	[DispId(1610743810)]
	public virtual extern Document Document
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1610743810)]
		[return: MarshalAs(UnmanagedType.Interface)]
		get;
	}

	[DispId(1610743811)]
	public virtual extern short ObjectType
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1610743811)]
		get;
	}

	[DispId(1610743812)]
	public virtual extern int Count
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1610743812)]
		get;
	}

	[DispId(0)]
	public virtual extern DataRecordset this[[In] int Index]
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(0)]
		[return: MarshalAs(UnmanagedType.Interface)]
		get;
	}

	[DispId(1610743814)]
	public virtual extern DataRecordset ItemFromID
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1610743814)]
		[return: MarshalAs(UnmanagedType.Interface)]
		get;
	}

	[DispId(1610743816)]
	public virtual extern EventList EventList
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1610743816)]
		[return: MarshalAs(UnmanagedType.Interface)]
		get;
	}

	public virtual extern event EDataRecordsets_DataRecordsetAddedEventHandler DataRecordsetAdded;

	public virtual extern event EDataRecordsets_BeforeDataRecordsetDeleteEventHandler BeforeDataRecordsetDelete;

	public virtual extern event EDataRecordsets_DataRecordsetChangedEventHandler DataRecordsetChanged;

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(-4)]
	[TypeLibFunc(1)]
	[return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalType = "System.Runtime.InteropServices.CustomMarshalers.EnumeratorToEnumVariantMarshaler, CustomMarshalers, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
	public virtual extern IEnumerator GetEnumerator();

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(1610743817)]
	[return: MarshalAs(UnmanagedType.Interface)]
	public virtual extern DataRecordset Add([In][MarshalAs(UnmanagedType.Struct)] object ConnectionIDOrString, [In][MarshalAs(UnmanagedType.BStr)] string CommandString, [In] int AddOptions, [In][MarshalAs(UnmanagedType.BStr)] string Name = "");

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(1610743818)]
	[return: MarshalAs(UnmanagedType.Interface)]
	public virtual extern DataRecordset AddFromXML([In][MarshalAs(UnmanagedType.BStr)] string XMLString, [In] int AddOptions, [In][MarshalAs(UnmanagedType.BStr)] string Name = "");

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(1610743819)]
	[return: MarshalAs(UnmanagedType.Interface)]
	public virtual extern DataRecordset AddFromConnectionFile([In][MarshalAs(UnmanagedType.BStr)] string FileName, [In] int AddOptions, [In][MarshalAs(UnmanagedType.BStr)] string Name = "");

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(1610743820)]
	public virtual extern void GetLastDataError(out int DataErrorCode, [MarshalAs(UnmanagedType.BStr)] out string DataErrorDescription, out int RecordsetID);
}
