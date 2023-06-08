using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[ComImport]
[ClassInterface(0)]
[ComSourceInterfaces("Microsoft.Office.Interop.Visio.EShape\0\0")]
[Guid("000D0D06-0000-0000-C000-000000000046")]
[TypeLibType(16)]
public class ExtenderClass : IVDispExtender, Extender, EShape_Event
{
	[DispId(-2147418112)]
	public virtual extern string Name
	{
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(-2147418112)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(-2147418112)]
		[param: In]
		[param: MarshalAs(UnmanagedType.BStr)]
		set;
	}

	[DispId(-802)]
	public virtual extern object Object
	{
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(-802)]
		[return: MarshalAs(UnmanagedType.IUnknown)]
		get;
	}

	[DispId(-2147418104)]
	public virtual extern object Parent
	{
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(-2147418104)]
		[return: MarshalAs(UnmanagedType.IUnknown)]
		get;
	}

	[DispId(-2147417856)]
	public virtual extern Shape Shape
	{
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(-2147417856)]
		[return: MarshalAs(UnmanagedType.Interface)]
		get;
	}

	[DispId(-2147417812)]
	public virtual extern Document Document
	{
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(-2147417812)]
		[return: MarshalAs(UnmanagedType.Interface)]
		get;
	}

	[DispId(-2147417800)]
	public virtual extern object ShapeParent
	{
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(-2147417800)]
		[return: MarshalAs(UnmanagedType.IDispatch)]
		get;
	}

	[DispId(-2147417855)]
	public virtual extern Application Application
	{
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(-2147417855)]
		[return: MarshalAs(UnmanagedType.Interface)]
		get;
	}

	[DispId(-2147417835)]
	public virtual extern Master Master
	{
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(-2147417835)]
		[return: MarshalAs(UnmanagedType.Interface)]
		get;
	}

	[DispId(-2147417843)]
	public virtual extern Cell Cells
	{
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(-2147417843)]
		[return: MarshalAs(UnmanagedType.Interface)]
		get;
	}

	[DispId(-2147417842)]
	public virtual extern Cell CellsSRC
	{
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(-2147417842)]
		[return: MarshalAs(UnmanagedType.Interface)]
		get;
	}

	[DispId(-2147417841)]
	public virtual extern string Data1
	{
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(-2147417841)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(-2147417841)]
		[param: In]
		[param: MarshalAs(UnmanagedType.BStr)]
		set;
	}

	[DispId(-2147417840)]
	public virtual extern string Data2
	{
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(-2147417840)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(-2147417840)]
		[param: In]
		[param: MarshalAs(UnmanagedType.BStr)]
		set;
	}

	[DispId(-2147417839)]
	public virtual extern string Data3
	{
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(-2147417839)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(-2147417839)]
		[param: In]
		[param: MarshalAs(UnmanagedType.BStr)]
		set;
	}

	[DispId(-2147417838)]
	public virtual extern string Help
	{
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(-2147417838)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(-2147417838)]
		[param: In]
		[param: MarshalAs(UnmanagedType.BStr)]
		set;
	}

	[DispId(-2147417852)]
	public virtual extern string NameID
	{
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(-2147417852)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
	}

	[DispId(-2147417832)]
	public virtual extern short RowCount
	{
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(-2147417832)]
		get;
	}

	[DispId(-2147417827)]
	public virtual extern short RowsCellCount
	{
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(-2147417827)]
		get;
	}

	[DispId(-2147417826)]
	public virtual extern short RowType
	{
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(-2147417826)]
		get;
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(-2147417826)]
		[param: In]
		set;
	}

	[DispId(-2147417822)]
	public virtual extern Connects Connects
	{
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(-2147417822)]
		[return: MarshalAs(UnmanagedType.Interface)]
		get;
	}

	[DispId(-2147417821)]
	public virtual extern short ShapeIndex16
	{
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[TypeLibFunc(64)]
		[DispId(-2147417821)]
		get;
	}

	[DispId(-2147417820)]
	public virtual extern string Style
	{
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(-2147417820)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(-2147417820)]
		[param: In]
		[param: MarshalAs(UnmanagedType.BStr)]
		set;
	}

	[DispId(-2147417816)]
	public virtual extern string StyleKeepFmt
	{
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(-2147417816)]
		[param: In]
		[param: MarshalAs(UnmanagedType.BStr)]
		set;
	}

	[DispId(-2147417819)]
	public virtual extern string LineStyle
	{
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(-2147417819)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(-2147417819)]
		[param: In]
		[param: MarshalAs(UnmanagedType.BStr)]
		set;
	}

	[DispId(-2147417815)]
	public virtual extern string LineStyleKeepFmt
	{
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(-2147417815)]
		[param: In]
		[param: MarshalAs(UnmanagedType.BStr)]
		set;
	}

	[DispId(-2147417818)]
	public virtual extern string FillStyle
	{
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(-2147417818)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(-2147417818)]
		[param: In]
		[param: MarshalAs(UnmanagedType.BStr)]
		set;
	}

	[DispId(-2147417814)]
	public virtual extern string FillStyleKeepFmt
	{
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(-2147417814)]
		[param: In]
		[param: MarshalAs(UnmanagedType.BStr)]
		set;
	}

	[DispId(-2147417795)]
	public virtual extern string UniqueID
	{
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(-2147417795)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
	}

	[DispId(-2147417794)]
	public virtual extern Page ContainingPage
	{
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(-2147417794)]
		[return: MarshalAs(UnmanagedType.Interface)]
		get;
	}

	[DispId(-2147417793)]
	public virtual extern Master ContainingMaster
	{
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(-2147417793)]
		[return: MarshalAs(UnmanagedType.Interface)]
		get;
	}

	[DispId(-2147417792)]
	public virtual extern Shape ContainingShape
	{
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(-2147417792)]
		[return: MarshalAs(UnmanagedType.Interface)]
		get;
	}

	[DispId(-2147417791)]
	public virtual extern short SectionExists
	{
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(-2147417791)]
		get;
	}

	[DispId(-2147417790)]
	public virtual extern short RowExists
	{
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(-2147417790)]
		get;
	}

	[DispId(-2147417789)]
	public virtual extern short CellExists
	{
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(-2147417789)]
		get;
	}

	[DispId(-2147417788)]
	public virtual extern short CellsSRCExists
	{
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(-2147417788)]
		get;
	}

	[DispId(-2147417787)]
	public virtual extern short LayerCount
	{
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(-2147417787)]
		get;
	}

	[DispId(-2147417786)]
	public virtual extern Layer Layer
	{
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(-2147417786)]
		[return: MarshalAs(UnmanagedType.Interface)]
		get;
	}

	[DispId(-2147417783)]
	public virtual extern EventList EventList
	{
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(-2147417783)]
		[return: MarshalAs(UnmanagedType.Interface)]
		get;
	}

	[DispId(-2147417782)]
	public virtual extern short PersistsEvents
	{
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(-2147417782)]
		get;
	}

	[DispId(-2147417770)]
	public virtual extern string ClassID
	{
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(-2147417770)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
	}

	[DispId(-2147417768)]
	public virtual extern object ShapeObject
	{
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(-2147417768)]
		[return: MarshalAs(UnmanagedType.IDispatch)]
		get;
	}

	[DispId(-2147417765)]
	public virtual extern short ShapeID16
	{
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(-2147417765)]
		[TypeLibFunc(64)]
		get;
	}

	[DispId(-2147417759)]
	public virtual extern Connects FromConnects
	{
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(-2147417759)]
		[return: MarshalAs(UnmanagedType.Interface)]
		get;
	}

	[DispId(-2147417755)]
	public virtual extern Hyperlink Hyperlink
	{
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(-2147417755)]
		[return: MarshalAs(UnmanagedType.Interface)]
		get;
	}

	[DispId(-2147417754)]
	public virtual extern string ProgID
	{
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(-2147417754)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
	}

	[DispId(-2147417753)]
	public virtual extern short ObjectIsInherited
	{
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(-2147417753)]
		get;
	}

	[DispId(-2147417749)]
	public virtual extern int ShapeID
	{
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(-2147417749)]
		get;
	}

	[DispId(-2147417748)]
	public virtual extern int ShapeIndex
	{
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(-2147417748)]
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

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(-801)]
	[TypeLibFunc(64)]
	public virtual extern void Delete();

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(-804)]
	[TypeLibFunc(64)]
	public virtual extern void Index();

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[TypeLibFunc(64)]
	[DispId(-2147417811)]
	public virtual extern void VoidGroup();

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(-2147417810)]
	public virtual extern void BringForward();

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(-2147417809)]
	public virtual extern void BringToFront();

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(-2147417808)]
	public virtual extern void ConvertToGroup();

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(-2147417804)]
	public virtual extern void SendBackward();

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(-2147417803)]
	public virtual extern void SendToBack();

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(-2147417847)]
	public virtual extern void ShapeCopy();

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(-2147417846)]
	public virtual extern void ShapeCut();

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(-2147417845)]
	public virtual extern void ShapeDelete();

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(-2147417844)]
	[TypeLibFunc(64)]
	public virtual extern void VoidShapeDuplicate();

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(-2147417831)]
	public virtual extern short AddSection([In] short Section);

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(-2147417830)]
	public virtual extern void DeleteSection([In] short Section);

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(-2147417829)]
	public virtual extern short AddRow([In] short Section, [In] short Row, [In] short RowTag);

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(-2147417828)]
	public virtual extern void DeleteRow([In] short Section, [In] short Row);

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(-2147417825)]
	public virtual extern void SetCenter([In] double xPos, [In] double yPos);

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(-2147417799)]
	public virtual extern void Export([In][MarshalAs(UnmanagedType.BStr)] string FileName);

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(-2147417785)]
	public virtual extern short AddNamedRow([In] short Section, [In][MarshalAs(UnmanagedType.BStr)] string RowName, [In] short RowTag);

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(-2147417784)]
	public virtual extern short AddRows([In] short Section, [In] short Row, [In] short RowTag, [In] short RowCount);

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(-2147417766)]
	[return: MarshalAs(UnmanagedType.Interface)]
	public virtual extern Window OpenSheetWindow();

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(-2147417763)]
	public virtual extern void GetFormulas([In][MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_I2)] ref Array SRCStream, [MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_VARIANT)] out Array formulaArray);

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(-2147417762)]
	public virtual extern void GetResults([In][MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_I2)] ref Array SRCStream, [In] short Flags, [In][MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_VARIANT)] ref Array UnitsNamesOrCodes, [MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_VARIANT)] out Array resultArray);

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(-2147417761)]
	public virtual extern short SetFormulas([In][MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_I2)] ref Array SRCStream, [In][MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_VARIANT)] ref Array formulaArray, [In] short Flags);

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(-2147417760)]
	public virtual extern short SetResults([In][MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_I2)] ref Array SRCStream, [In][MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_VARIANT)] ref Array UnitsNamesOrCodes, [In][MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_VARIANT)] ref Array resultArray, [In] short Flags);

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(-2147417757)]
	public virtual extern void BoundingBox([In] short Flags, out double lpr8Left, out double lpr8Bottom, out double lpr8Right, out double lpr8Top);

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(-2147417756)]
	public virtual extern short HitTest([In] double xPos, [In] double yPos, [In] double Tolerance);

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(-2147417726)]
	[return: MarshalAs(UnmanagedType.Interface)]
	public virtual extern Shape Group();

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(-2147417725)]
	[return: MarshalAs(UnmanagedType.Interface)]
	public virtual extern Shape ShapeDuplicate();

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(-2147417724)]
	public virtual extern void VisualBoundingBox([In] short Flags, out double lpr8Left, out double lpr8Bottom, out double lpr8Right, out double lpr8Top);
}
