using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[ComImport]
[Guid("000D0D10-0000-0000-C000-000000000046")]
[TypeLibType(4176)]
public interface IVAmbients
{
	[DispId(-701)]
	int BackColor
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(-701)]
		[TypeLibFunc(64)]
		get;
	}

	[DispId(-702)]
	string DisplayName
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[TypeLibFunc(64)]
		[DispId(-702)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
	}

	[DispId(-703)]
	object Font
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(-703)]
		[TypeLibFunc(64)]
		[return: MarshalAs(UnmanagedType.IDispatch)]
		get;
	}

	[DispId(-704)]
	int ForeColor
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[TypeLibFunc(64)]
		[DispId(-704)]
		get;
	}

	[DispId(-705)]
	int LocaleID
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[TypeLibFunc(64)]
		[DispId(-705)]
		get;
	}

	[DispId(-706)]
	bool MessageReflect
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(-706)]
		[TypeLibFunc(64)]
		get;
	}

	[DispId(-707)]
	string ScaleUnits
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[TypeLibFunc(64)]
		[DispId(-707)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
	}

	[DispId(-708)]
	short TextAlign
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(-708)]
		[TypeLibFunc(64)]
		get;
	}

	[DispId(-709)]
	bool UserMode
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[TypeLibFunc(64)]
		[DispId(-709)]
		get;
	}

	[DispId(-710)]
	bool UIDead
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[TypeLibFunc(64)]
		[DispId(-710)]
		get;
	}

	[DispId(-711)]
	bool ShowGrabHandles
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[TypeLibFunc(64)]
		[DispId(-711)]
		get;
	}

	[DispId(-712)]
	bool ShowHatching
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(-712)]
		[TypeLibFunc(64)]
		get;
	}

	[DispId(-713)]
	bool DisplayAsDefault
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(-713)]
		[TypeLibFunc(64)]
		get;
	}

	[DispId(-714)]
	bool SupportsMnemonics
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(-714)]
		[TypeLibFunc(64)]
		get;
	}

	[DispId(-715)]
	bool AutoClip
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(-715)]
		[TypeLibFunc(64)]
		get;
	}

	[DispId(-716)]
	int Appearance
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(-716)]
		[TypeLibFunc(64)]
		get;
	}

	[DispId(1610743824)]
	Shape Shape
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1610743824)]
		[return: MarshalAs(UnmanagedType.Interface)]
		get;
	}

	[DispId(1610743825)]
	bool CancelOperation
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1610743825)]
		get;
	}
}
