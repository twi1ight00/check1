using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using stdole;

namespace Microsoft.Office.Interop.Visio;

[ComImport]
[Guid("000D0A0A-0000-0000-C000-000000000046")]
[ClassInterface(0)]
[ComSourceInterfaces("Microsoft.Office.Interop.Visio.EShape\0\0")]
[DefaultMember("Name")]
public class ShapeClass : IVShape, Shape, EShape_Event
{
	[DispId(44)]
	public virtual extern Document Document
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(44)]
		[return: MarshalAs(UnmanagedType.Interface)]
		get;
	}

	[DispId(56)]
	public virtual extern object Parent
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(56)]
		[return: MarshalAs(UnmanagedType.IDispatch)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(56)]
		[param: In]
		[param: MarshalAs(UnmanagedType.IDispatch)]
		set;
	}

	[DispId(1)]
	public virtual extern Application Application
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1)]
		[return: MarshalAs(UnmanagedType.Interface)]
		get;
	}

	[DispId(2)]
	public virtual extern short Stat
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(2)]
		get;
	}

	[DispId(21)]
	public virtual extern Master Master
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(21)]
		[return: MarshalAs(UnmanagedType.Interface)]
		get;
	}

	[DispId(20)]
	public virtual extern short Type
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(20)]
		get;
	}

	[DispId(3)]
	public virtual extern short ObjectType
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(3)]
		get;
	}

	[DispId(13)]
	public virtual extern Cell Cells
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(13)]
		[return: MarshalAs(UnmanagedType.Interface)]
		get;
	}

	[DispId(14)]
	public virtual extern Cell CellsSRC
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(14)]
		[return: MarshalAs(UnmanagedType.Interface)]
		get;
	}

	[DispId(5)]
	public virtual extern Shapes Shapes
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(5)]
		[return: MarshalAs(UnmanagedType.Interface)]
		get;
	}

	[DispId(15)]
	public virtual extern string Data1
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(15)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(15)]
		[param: In]
		[param: MarshalAs(UnmanagedType.BStr)]
		set;
	}

	[DispId(16)]
	public virtual extern string Data2
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(16)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(16)]
		[param: In]
		[param: MarshalAs(UnmanagedType.BStr)]
		set;
	}

	[DispId(17)]
	public virtual extern string Data3
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(17)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(17)]
		[param: In]
		[param: MarshalAs(UnmanagedType.BStr)]
		set;
	}

	[DispId(18)]
	public virtual extern string Help
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(18)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(18)]
		[param: In]
		[param: MarshalAs(UnmanagedType.BStr)]
		set;
	}

	[DispId(4)]
	public virtual extern string NameID
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(4)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
	}

	[DispId(0)]
	public virtual extern string Name
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(0)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(0)]
		[param: In]
		[param: MarshalAs(UnmanagedType.BStr)]
		set;
	}

	[DispId(6)]
	public virtual extern string Text
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(6)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(6)]
		[param: In]
		[param: MarshalAs(UnmanagedType.BStr)]
		set;
	}

	[DispId(7)]
	public virtual extern int CharCount
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(7)]
		get;
	}

	[DispId(8)]
	public virtual extern Characters Characters
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(8)]
		[return: MarshalAs(UnmanagedType.Interface)]
		get;
	}

	[DispId(22)]
	public virtual extern short OneD
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(22)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(22)]
		[param: In]
		set;
	}

	[DispId(23)]
	public virtual extern short GeometryCount
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(23)]
		get;
	}

	[DispId(24)]
	public virtual extern short RowCount
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(24)]
		get;
	}

	[DispId(29)]
	public virtual extern short RowsCellCount
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(29)]
		get;
	}

	[DispId(30)]
	public virtual extern short RowType
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(30)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(30)]
		[param: In]
		set;
	}

	[DispId(34)]
	public virtual extern Connects Connects
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(34)]
		[return: MarshalAs(UnmanagedType.Interface)]
		get;
	}

	[DispId(35)]
	public virtual extern short Index16
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[TypeLibFunc(64)]
		[DispId(35)]
		get;
	}

	[DispId(36)]
	public virtual extern string Style
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(36)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(36)]
		[param: In]
		[param: MarshalAs(UnmanagedType.BStr)]
		set;
	}

	[DispId(40)]
	public virtual extern string StyleKeepFmt
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(40)]
		[param: In]
		[param: MarshalAs(UnmanagedType.BStr)]
		set;
	}

	[DispId(37)]
	public virtual extern string LineStyle
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(37)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(37)]
		[param: In]
		[param: MarshalAs(UnmanagedType.BStr)]
		set;
	}

	[DispId(41)]
	public virtual extern string LineStyleKeepFmt
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(41)]
		[param: In]
		[param: MarshalAs(UnmanagedType.BStr)]
		set;
	}

	[DispId(38)]
	public virtual extern string FillStyle
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(38)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(38)]
		[param: In]
		[param: MarshalAs(UnmanagedType.BStr)]
		set;
	}

	[DispId(42)]
	public virtual extern string FillStyleKeepFmt
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(42)]
		[param: In]
		[param: MarshalAs(UnmanagedType.BStr)]
		set;
	}

	[DispId(39)]
	public virtual extern string TextStyle
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(39)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(39)]
		[param: In]
		[param: MarshalAs(UnmanagedType.BStr)]
		set;
	}

	[DispId(43)]
	public virtual extern string TextStyleKeepFmt
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(43)]
		[param: In]
		[param: MarshalAs(UnmanagedType.BStr)]
		set;
	}

	[DispId(58)]
	public virtual extern double old_AreaIU
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[TypeLibFunc(64)]
		[DispId(58)]
		get;
	}

	[DispId(59)]
	public virtual extern double old_LengthIU
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(59)]
		[TypeLibFunc(64)]
		get;
	}

	[DispId(60)]
	public virtual extern object GeomExIf
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(60)]
		[TypeLibFunc(64)]
		[return: MarshalAs(UnmanagedType.IUnknown)]
		get;
	}

	[DispId(61)]
	public virtual extern string UniqueID
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(61)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
	}

	[DispId(62)]
	public virtual extern Page ContainingPage
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(62)]
		[return: MarshalAs(UnmanagedType.Interface)]
		get;
	}

	[DispId(63)]
	public virtual extern Master ContainingMaster
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(63)]
		[return: MarshalAs(UnmanagedType.Interface)]
		get;
	}

	[DispId(64)]
	public virtual extern Shape ContainingShape
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(64)]
		[return: MarshalAs(UnmanagedType.Interface)]
		get;
	}

	[DispId(65)]
	public virtual extern short SectionExists
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(65)]
		get;
	}

	[DispId(66)]
	public virtual extern short RowExists
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(66)]
		get;
	}

	[DispId(67)]
	public virtual extern short CellExists
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(67)]
		get;
	}

	[DispId(68)]
	public virtual extern short CellsSRCExists
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(68)]
		get;
	}

	[DispId(69)]
	public virtual extern short LayerCount
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(69)]
		get;
	}

	[DispId(70)]
	public virtual extern Layer Layer
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(70)]
		[return: MarshalAs(UnmanagedType.Interface)]
		get;
	}

	[DispId(73)]
	public virtual extern EventList EventList
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(73)]
		[return: MarshalAs(UnmanagedType.Interface)]
		get;
	}

	[DispId(74)]
	public virtual extern short PersistsEvents
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(74)]
		get;
	}

	[DispId(86)]
	public virtual extern string ClassID
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(86)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
	}

	[DispId(87)]
	public virtual extern short ForeignType
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(87)]
		get;
	}

	[DispId(88)]
	public virtual extern object Object
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(88)]
		[return: MarshalAs(UnmanagedType.IDispatch)]
		get;
	}

	[DispId(91)]
	public virtual extern short ID16
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[TypeLibFunc(64)]
		[DispId(91)]
		get;
	}

	[DispId(97)]
	public virtual extern Connects FromConnects
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(97)]
		[return: MarshalAs(UnmanagedType.Interface)]
		get;
	}

	[DispId(101)]
	public virtual extern Hyperlink Hyperlink
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(101)]
		[TypeLibFunc(64)]
		[return: MarshalAs(UnmanagedType.Interface)]
		get;
	}

	[DispId(102)]
	public virtual extern string ProgID
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(102)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
	}

	[DispId(103)]
	public virtual extern short ObjectIsInherited
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(103)]
		get;
	}

	[DispId(104)]
	public virtual extern Paths Paths
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(104)]
		[return: MarshalAs(UnmanagedType.Interface)]
		get;
	}

	[DispId(105)]
	public virtual extern Paths PathsLocal
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(105)]
		[return: MarshalAs(UnmanagedType.Interface)]
		get;
	}

	[DispId(107)]
	public virtual extern int ID
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(107)]
		get;
	}

	[DispId(108)]
	public virtual extern int Index
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(108)]
		get;
	}

	[DispId(109)]
	public virtual extern Section Section
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(109)]
		[return: MarshalAs(UnmanagedType.Interface)]
		get;
	}

	[DispId(110)]
	public virtual extern Hyperlinks Hyperlinks
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(110)]
		[return: MarshalAs(UnmanagedType.Interface)]
		get;
	}

	[DispId(111)]
	public virtual extern short SpatialRelation
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(111)]
		get;
	}

	[DispId(112)]
	public virtual extern double DistanceFrom
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(112)]
		get;
	}

	[DispId(113)]
	public virtual extern double DistanceFromPoint
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(113)]
		get;
	}

	[DispId(114)]
	public virtual extern Selection SpatialNeighbors
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(114)]
		[return: MarshalAs(UnmanagedType.Interface)]
		get;
	}

	[DispId(115)]
	public virtual extern Selection SpatialSearch
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(115)]
		[return: MarshalAs(UnmanagedType.Interface)]
		get;
	}

	[DispId(121)]
	public virtual extern Cell CellsU
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(121)]
		[return: MarshalAs(UnmanagedType.Interface)]
		get;
	}

	[DispId(122)]
	public virtual extern string NameU
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(122)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(122)]
		[param: In]
		[param: MarshalAs(UnmanagedType.BStr)]
		set;
	}

	[DispId(123)]
	public virtual extern short CellExistsU
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(123)]
		get;
	}

	[DispId(127)]
	public virtual extern short CellsRowIndex
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(127)]
		get;
	}

	[DispId(128)]
	public virtual extern short CellsRowIndexU
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(128)]
		get;
	}

	[DispId(129)]
	public virtual extern bool IsOpenForTextEdit
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(129)]
		get;
	}

	[DispId(1610743951)]
	public virtual extern Shape RootShape
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1610743951)]
		[return: MarshalAs(UnmanagedType.Interface)]
		get;
	}

	[DispId(1610743952)]
	public virtual extern Shape MasterShape
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1610743952)]
		[return: MarshalAs(UnmanagedType.Interface)]
		get;
	}

	[ComAliasName("stdole.IPictureDisp")]
	[DispId(1610743953)]
	public virtual extern IPictureDisp Picture
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1610743953)]
		[return: MarshalAs(UnmanagedType.Interface)]
		[return: ComAliasName("stdole.IPictureDisp")]
		get;
	}

	[DispId(1610743958)]
	public virtual extern Array ForeignData
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1610743958)]
		[return: MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_UI1)]
		get;
	}

	[DispId(1610743964)]
	public virtual extern int Language
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1610743964)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1610743964)]
		[param: In]
		set;
	}

	[DispId(1610743968)]
	public virtual extern double AreaIU
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1610743968)]
		get;
	}

	[DispId(1610743969)]
	public virtual extern double LengthIU
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1610743969)]
		get;
	}

	[DispId(1610743973)]
	public virtual extern int ContainingPageID
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1610743973)]
		get;
	}

	[DispId(1610743974)]
	public virtual extern int ContainingMasterID
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1610743974)]
		get;
	}

	[DispId(1610743983)]
	public virtual extern Master DataGraphic
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1610743983)]
		[return: MarshalAs(UnmanagedType.Interface)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1610743983)]
		[param: In]
		[param: MarshalAs(UnmanagedType.Interface)]
		set;
	}

	[DispId(1610743985)]
	public virtual extern bool IsDataGraphicCallout
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1610743985)]
		get;
	}

	[DispId(1610743986)]
	public virtual extern ContainerProperties ContainerProperties
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1610743986)]
		[return: MarshalAs(UnmanagedType.Interface)]
		get;
	}

	[DispId(1610743988)]
	public virtual extern Array MemberOfContainers
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1610743988)]
		[return: MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_I4)]
		get;
	}

	[DispId(1610743992)]
	public virtual extern bool IsCallout
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1610743992)]
		get;
	}

	[DispId(1610743993)]
	public virtual extern Shape CalloutTarget
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1610743993)]
		[return: MarshalAs(UnmanagedType.Interface)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1610743993)]
		[param: In]
		[param: MarshalAs(UnmanagedType.Interface)]
		set;
	}

	[DispId(1610743995)]
	public virtual extern Array CalloutsAssociated
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1610743995)]
		[return: MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_I4)]
		get;
	}

	[DispId(1610744005)]
	public virtual extern Comments Comments
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1610744005)]
		[return: MarshalAs(UnmanagedType.Interface)]
		get;
	}

	public virtual extern event EShape_CellChangedEventHandler CellChanged;

	public virtual extern event EShape_ShapeAddedEventHandler ShapeAdded;

	public virtual extern event EShape_BeforeSelectionDeleteEventHandler BeforeSelectionDelete;

	public virtual extern event EShape_ShapeChangedEventHandler ShapeChanged;

	public virtual extern event EShape_SelectionAddedEventHandler SelectionAdded;

	public virtual extern event EShape_BeforeShapeDeleteEventHandler BeforeShapeDelete;

	public virtual extern event EShape_TextChangedEventHandler TextChanged;

	public virtual extern event EShape_FormulaChangedEventHandler FormulaChanged;

	public virtual extern event EShape_ShapeParentChangedEventHandler ShapeParentChanged;

	public virtual extern event EShape_BeforeShapeTextEditEventHandler BeforeShapeTextEdit;

	public virtual extern event EShape_ShapeExitedTextEditEventHandler ShapeExitedTextEdit;

	public virtual extern event EShape_QueryCancelSelectionDeleteEventHandler QueryCancelSelectionDelete;

	public virtual extern event EShape_SelectionDeleteCanceledEventHandler SelectionDeleteCanceled;

	public virtual extern event EShape_QueryCancelUngroupEventHandler QueryCancelUngroup;

	public virtual extern event EShape_UngroupCanceledEventHandler UngroupCanceled;

	public virtual extern event EShape_QueryCancelConvertToGroupEventHandler QueryCancelConvertToGroup;

	public virtual extern event EShape_ConvertToGroupCanceledEventHandler ConvertToGroupCanceled;

	public virtual extern event EShape_QueryCancelGroupEventHandler QueryCancelGroup;

	public virtual extern event EShape_GroupCanceledEventHandler GroupCanceled;

	public virtual extern event EShape_ShapeDataGraphicChangedEventHandler ShapeDataGraphicChanged;

	public virtual extern event EShape_ShapeLinkAddedEventHandler ShapeLinkAdded;

	public virtual extern event EShape_ShapeLinkDeletedEventHandler ShapeLinkDeleted;

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(45)]
	[TypeLibFunc(64)]
	public virtual extern void VoidGroup();

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(46)]
	public virtual extern void BringForward();

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(47)]
	public virtual extern void BringToFront();

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(48)]
	public virtual extern void ConvertToGroup();

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(49)]
	public virtual extern void FlipHorizontal();

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(50)]
	public virtual extern void FlipVertical();

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(51)]
	public virtual extern void ReverseEnds();

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(52)]
	public virtual extern void SendBackward();

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(53)]
	public virtual extern void SendToBack();

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(54)]
	public virtual extern void Rotate90();

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(55)]
	public virtual extern void Ungroup();

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[TypeLibFunc(64)]
	[DispId(9)]
	public virtual extern void old_Copy();

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[TypeLibFunc(64)]
	[DispId(10)]
	public virtual extern void old_Cut();

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(11)]
	public virtual extern void Delete();

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(12)]
	[TypeLibFunc(64)]
	public virtual extern void VoidDuplicate();

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(19)]
	[return: MarshalAs(UnmanagedType.Interface)]
	public virtual extern Shape Drop([In][MarshalAs(UnmanagedType.IUnknown)] object ObjectToDrop, [In] double xPos, [In] double yPos);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(25)]
	public virtual extern short AddSection([In] short Section);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(26)]
	public virtual extern void DeleteSection([In] short Section);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(27)]
	public virtual extern short AddRow([In] short Section, [In] short Row, [In] short RowTag);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(28)]
	public virtual extern void DeleteRow([In] short Section, [In] short Row);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(31)]
	public virtual extern void SetCenter([In] double xPos, [In] double yPos);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(32)]
	public virtual extern void SetBegin([In] double xPos, [In] double yPos);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(33)]
	public virtual extern void SetEnd([In] double xPos, [In] double yPos);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(57)]
	public virtual extern void Export([In][MarshalAs(UnmanagedType.BStr)] string FileName);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(71)]
	public virtual extern short AddNamedRow([In] short Section, [In][MarshalAs(UnmanagedType.BStr)] string RowName, [In] short RowTag);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(72)]
	public virtual extern short AddRows([In] short Section, [In] short Row, [In] short RowTag, [In] short RowCount);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(75)]
	[return: MarshalAs(UnmanagedType.Interface)]
	public virtual extern Shape DrawLine([In] double xBegin, [In] double yBegin, [In] double xEnd, [In] double yEnd);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(76)]
	[return: MarshalAs(UnmanagedType.Interface)]
	public virtual extern Shape DrawRectangle([In] double x1, [In] double y1, [In] double x2, [In] double y2);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(77)]
	[return: MarshalAs(UnmanagedType.Interface)]
	public virtual extern Shape DrawOval([In] double x1, [In] double y1, [In] double x2, [In] double y2);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(78)]
	[return: MarshalAs(UnmanagedType.Interface)]
	public virtual extern Shape DrawSpline([In][MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_R8)] ref Array xyArray, [In] double Tolerance, [In] short Flags);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(79)]
	[return: MarshalAs(UnmanagedType.Interface)]
	public virtual extern Shape DrawBezier([In][MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_R8)] ref Array xyArray, [In] short degree, [In] short Flags);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(80)]
	[return: MarshalAs(UnmanagedType.Interface)]
	public virtual extern Shape DrawPolyline([In][MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_R8)] ref Array xyArray, [In] short Flags);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(81)]
	public virtual extern void FitCurve([In] double Tolerance, [In] short Flags);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(82)]
	[return: MarshalAs(UnmanagedType.Interface)]
	public virtual extern Shape Import([In][MarshalAs(UnmanagedType.BStr)] string FileName);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(83)]
	public virtual extern void CenterDrawing();

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(84)]
	[return: MarshalAs(UnmanagedType.Interface)]
	public virtual extern Shape InsertFromFile([In][MarshalAs(UnmanagedType.BStr)] string FileName, [In] short Flags);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(85)]
	[return: MarshalAs(UnmanagedType.Interface)]
	public virtual extern Shape InsertObject([In][MarshalAs(UnmanagedType.BStr)] string ClassOrProgID, [In] short Flags);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(89)]
	[return: MarshalAs(UnmanagedType.Interface)]
	public virtual extern Window OpenDrawWindow();

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(90)]
	[return: MarshalAs(UnmanagedType.Interface)]
	public virtual extern Window OpenSheetWindow();

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(92)]
	public virtual extern short DropMany([In][MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_VARIANT)] ref Array ObjectsToInstance, [In][MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_R8)] ref Array xyArray, [MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_I2)] out Array IDArray);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(93)]
	public virtual extern void GetFormulas([In][MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_I2)] ref Array SRCStream, [MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_VARIANT)] out Array formulaArray);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(94)]
	public virtual extern void GetResults([In][MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_I2)] ref Array SRCStream, [In] short Flags, [In][MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_VARIANT)] ref Array UnitsNamesOrCodes, [MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_VARIANT)] out Array resultArray);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(95)]
	public virtual extern short SetFormulas([In][MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_I2)] ref Array SRCStream, [In][MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_VARIANT)] ref Array formulaArray, [In] short Flags);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(96)]
	public virtual extern short SetResults([In][MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_I2)] ref Array SRCStream, [In][MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_VARIANT)] ref Array UnitsNamesOrCodes, [In][MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_VARIANT)] ref Array resultArray, [In] short Flags);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(98)]
	public virtual extern void Layout();

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(99)]
	public virtual extern void BoundingBox([In] short Flags, out double lpr8Left, out double lpr8Bottom, out double lpr8Right, out double lpr8Top);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(100)]
	public virtual extern short HitTest([In] double xPos, [In] double yPos, [In] double Tolerance);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(106)]
	[return: MarshalAs(UnmanagedType.Interface)]
	public virtual extern Hyperlink AddHyperlink();

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(116)]
	public virtual extern void TransformXYTo([In][MarshalAs(UnmanagedType.Interface)] Shape OtherShape, [In] double x, [In] double y, out double xprime, out double yprime);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(117)]
	public virtual extern void TransformXYFrom([In][MarshalAs(UnmanagedType.Interface)] Shape OtherShape, [In] double x, [In] double y, out double xprime, out double yprime);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(118)]
	public virtual extern void XYToPage([In] double x, [In] double y, out double xprime, out double yprime);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(119)]
	public virtual extern void XYFromPage([In] double x, [In] double y, out double xprime, out double yprime);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(120)]
	public virtual extern void UpdateAlignmentBox();

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(124)]
	public virtual extern short DropManyU([In][MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_VARIANT)] ref Array ObjectsToInstance, [In][MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_R8)] ref Array xyArray, [MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_I2)] out Array IDArray);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(125)]
	public virtual extern void GetFormulasU([In][MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_I2)] ref Array SRCStream, [MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_VARIANT)] out Array formulaArray);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(126)]
	[return: MarshalAs(UnmanagedType.Interface)]
	public virtual extern Shape DrawNURBS([In] short degree, [In] short Flags, [In][MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_R8)] ref Array xyArray, [In][MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_R8)] ref Array knots, [Optional][In][MarshalAs(UnmanagedType.Struct)] object weights);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(1610743954)]
	[return: MarshalAs(UnmanagedType.Interface)]
	public virtual extern Shape Group();

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(1610743955)]
	[return: MarshalAs(UnmanagedType.Interface)]
	public virtual extern Shape Duplicate();

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(1610743956)]
	public virtual extern void SwapEnds();

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(1610743959)]
	public virtual extern void Copy([Optional][In][MarshalAs(UnmanagedType.Struct)] object Flags);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(1610743960)]
	public virtual extern void Cut([Optional][In][MarshalAs(UnmanagedType.Struct)] object Flags);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(1610743961)]
	public virtual extern void Paste([Optional][In][MarshalAs(UnmanagedType.Struct)] object Flags);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(1610743962)]
	public virtual extern void PasteSpecial([In] int Format, [Optional][In][MarshalAs(UnmanagedType.Struct)] object Link, [Optional][In][MarshalAs(UnmanagedType.Struct)] object DisplayAsIcon);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(1610743963)]
	[return: MarshalAs(UnmanagedType.Interface)]
	public virtual extern Selection CreateSelection([In] VisSelectionTypes SelType, [In] VisSelectMode IterationMode = VisSelectMode.visSelModeSkipSuper, [Optional][In][MarshalAs(UnmanagedType.Struct)] object Data);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(1610743966)]
	public virtual extern void Offset([In] double Distance);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(1610743967)]
	[return: MarshalAs(UnmanagedType.Interface)]
	public virtual extern Shape AddGuide([In] short Type, [In] double xPos, [In] double yPos);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(1610743970)]
	[return: MarshalAs(UnmanagedType.Interface)]
	public virtual extern Shape DrawArcByThreePoints([In] double xBegin, [In] double yBegin, [In] double xEnd, [In] double yEnd, [In] double xControl, [In] double yControl);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(1610743971)]
	[return: MarshalAs(UnmanagedType.Interface)]
	public virtual extern Shape DrawQuarterArc([In] double xBegin, [In] double yBegin, [In] double xEnd, [In] double yEnd, [In] VisArcSweepFlags SweepFlag);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(1610743972)]
	[return: MarshalAs(UnmanagedType.Interface)]
	public virtual extern Shape DrawCircularArc([In] double xCenter, [In] double yCenter, [In] double Radius, [In] double StartAngle = 0.0, [In] double EndAngle = 3.1415927410125732);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(1610743975)]
	public virtual extern void LinkToData([In] int DataRecordsetID, [In] int RowID, [In] bool ApplyDataGraphicAfterLink = true);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(1610743976)]
	public virtual extern void BreakLinkToData([In] int DataRecordsetID);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(1610743977)]
	public virtual extern int GetLinkedDataRow([In] int DataRecordsetID);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(1610743978)]
	public virtual extern void GetLinkedDataRecordsetIDs([MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_I4)] out Array DataRecordsetIDs);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(1610743979)]
	public virtual extern void GetCustomPropertiesLinkedToData([In] int DataRecordsetID, [MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_I4)] out Array CustomPropertyIndices);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(1610743980)]
	public virtual extern bool IsCustomPropertyLinked([In] int DataRecordsetID, [In] int CustomPropertyIndex);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(1610743981)]
	[return: MarshalAs(UnmanagedType.BStr)]
	public virtual extern string GetCustomPropertyLinkedColumn([In] int DataRecordsetID, [In] int CustomPropertyIndex);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(1610743982)]
	public virtual extern void AutoConnect([In][MarshalAs(UnmanagedType.Interface)] Shape ToShape, [In] VisAutoConnectDir PlacementDir, [Optional][In][IUnknownConstant][MarshalAs(UnmanagedType.IUnknown)] object Connector);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(1610743987)]
	public virtual extern bool HasCategory([In][MarshalAs(UnmanagedType.BStr)] string Category);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(1610743989)]
	[return: MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_I4)]
	public virtual extern Array ConnectedShapes([In] VisConnectedShapesFlags Flags, [In][MarshalAs(UnmanagedType.BStr)] string CategoryFilter);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(1610743990)]
	[return: MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_I4)]
	public virtual extern Array GluedShapes([In] VisGluedShapesFlags Flags, [In][MarshalAs(UnmanagedType.BStr)] string CategoryFilter, [Optional][In][MarshalAs(UnmanagedType.Interface)] Shape pOtherConnectedShape);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(1610743991)]
	public virtual extern void Disconnect([In] VisConnectorEnds ConnectorEnd, [In] double OffsetX, [In] double OffsetY, [In] VisUnitCodes Units);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(1610743996)]
	public virtual extern void Resize([In] VisResizeDirection Direction, [In] double Distance, [In] VisUnitCodes UnitCode);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(1610743997)]
	public virtual extern void AddToContainers();

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(1610743998)]
	public virtual extern void RemoveFromContainers();

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(1610743999)]
	[return: MarshalAs(UnmanagedType.Interface)]
	public virtual extern Page CreateSubProcess();

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(1610744000)]
	[return: MarshalAs(UnmanagedType.Interface)]
	public virtual extern Selection MoveToSubprocess([In][MarshalAs(UnmanagedType.Interface)] Page Page, [In][MarshalAs(UnmanagedType.IUnknown)] object ObjectToDrop, [Optional][DefaultParameterValue(null)][MarshalAs(UnmanagedType.Interface)] out Shape NewShape);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(1610744001)]
	public virtual extern void DeleteEx([In] int DelFlags);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(1610744002)]
	[return: MarshalAs(UnmanagedType.Interface)]
	public virtual extern Shape ReplaceShape([In][MarshalAs(UnmanagedType.IUnknown)] object MasterOrMasterShortcutToDrop, [In] int ReplaceFlags = 0);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(1610744003)]
	public virtual extern void SetQuickStyle([In] VisQuickStyleMatrixIndices lineMatrix, [In] VisQuickStyleMatrixIndices fillMatrix, [In] VisQuickStyleMatrixIndices effectsMatrix, [In] VisQuickStyleMatrixIndices fontMatrix, [In] VisQuickStyleColors lineColor, [In] VisQuickStyleColors fillColor, [In] VisQuickStyleColors shadowColor, [In] VisQuickStyleColors fontColor);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(1610744004)]
	public virtual extern double ChangePicture([In][MarshalAs(UnmanagedType.BStr)] string FileName, [In] int ChangePictureFlags = 0);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(1610744006)]
	public virtual extern void VisualBoundingBox([In] short Flags, out double lpr8Left, out double lpr8Bottom, out double lpr8Right, out double lpr8Top);
}
