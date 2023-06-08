using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using stdole;

namespace Microsoft.Office.Interop.Visio;

[ComImport]
[ClassInterface(0)]
[ComSourceInterfaces("Microsoft.Office.Interop.Visio.EMaster\0\0")]
[DefaultMember("Name")]
[Guid("000D0A04-0000-0000-C000-000000000046")]
public class MasterClass : IVMaster, Master, EMaster_Event
{
	[DispId(2)]
	public virtual extern Document Document
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(2)]
		[return: MarshalAs(UnmanagedType.Interface)]
		get;
	}

	[DispId(6)]
	public virtual extern string Prompt
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
	public virtual extern short AlignName
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(7)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(7)]
		[param: In]
		set;
	}

	[DispId(8)]
	public virtual extern short IconSize
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(8)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(8)]
		[param: In]
		set;
	}

	[DispId(9)]
	public virtual extern short IconUpdate
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(9)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(9)]
		[param: In]
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

	[DispId(4)]
	public virtual extern short Stat
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(4)]
		get;
	}

	[DispId(5)]
	public virtual extern short ObjectType
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(5)]
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

	[DispId(3)]
	public virtual extern Shapes Shapes
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(3)]
		[return: MarshalAs(UnmanagedType.Interface)]
		get;
	}

	[DispId(10)]
	public virtual extern short Index
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(10)]
		get;
	}

	[DispId(11)]
	public virtual extern short OneD
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(11)]
		get;
	}

	[DispId(13)]
	public virtual extern string UniqueID
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(13)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
	}

	[DispId(14)]
	public virtual extern Layers Layers
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(14)]
		[return: MarshalAs(UnmanagedType.Interface)]
		get;
	}

	[DispId(15)]
	public virtual extern Shape PageSheet
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(15)]
		[return: MarshalAs(UnmanagedType.Interface)]
		get;
	}

	[DispId(18)]
	public virtual extern EventList EventList
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(18)]
		[return: MarshalAs(UnmanagedType.Interface)]
		get;
	}

	[DispId(19)]
	public virtual extern short PersistsEvents
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(19)]
		get;
	}

	[DispId(39)]
	public virtual extern Connects Connects
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(39)]
		[return: MarshalAs(UnmanagedType.Interface)]
		get;
	}

	[DispId(44)]
	public virtual extern short ID16
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[TypeLibFunc(64)]
		[DispId(44)]
		get;
	}

	[DispId(45)]
	public virtual extern OLEObjects OLEObjects
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(45)]
		[return: MarshalAs(UnmanagedType.Interface)]
		get;
	}

	[DispId(46)]
	public virtual extern short PatternFlags
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(46)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(46)]
		[param: In]
		set;
	}

	[DispId(47)]
	public virtual extern short MatchByName
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(47)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(47)]
		[param: In]
		set;
	}

	[DispId(48)]
	public virtual extern int ID
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(48)]
		get;
	}

	[DispId(49)]
	public virtual extern short Hidden
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(49)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(49)]
		[param: In]
		set;
	}

	[DispId(50)]
	public virtual extern string BaseID
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(50)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
	}

	[DispId(51)]
	public virtual extern string NewBaseID
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(51)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
	}

	[DispId(52)]
	public virtual extern Selection SpatialSearch
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(52)]
		[return: MarshalAs(UnmanagedType.Interface)]
		get;
	}

	[DispId(54)]
	public virtual extern string NameU
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(54)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(54)]
		[param: In]
		[param: MarshalAs(UnmanagedType.BStr)]
		set;
	}

	[DispId(59)]
	public virtual extern short IndexInStencil
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(59)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(59)]
		[param: In]
		set;
	}

	[DispId(1610743877)]
	[ComAliasName("stdole.IPictureDisp")]
	public virtual extern IPictureDisp Picture
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1610743877)]
		[return: MarshalAs(UnmanagedType.Interface)]
		[return: ComAliasName("stdole.IPictureDisp")]
		get;
	}

	[ComAliasName("stdole.IPictureDisp")]
	[DispId(1610743878)]
	public virtual extern IPictureDisp Icon
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1610743878)]
		[return: MarshalAs(UnmanagedType.Interface)]
		[return: ComAliasName("stdole.IPictureDisp")]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1610743878)]
		[param: In]
		[param: ComAliasName("stdole.IPictureDisp")]
		[param: MarshalAs(UnmanagedType.Interface)]
		set;
	}

	[DispId(1610743880)]
	public virtual extern Master EditCopy
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1610743880)]
		[return: MarshalAs(UnmanagedType.Interface)]
		get;
	}

	[DispId(1610743881)]
	public virtual extern Master Original
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1610743881)]
		[return: MarshalAs(UnmanagedType.Interface)]
		get;
	}

	[DispId(1610743882)]
	public virtual extern bool IsChanged
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1610743882)]
		get;
	}

	[DispId(1610743892)]
	public virtual extern VisMasterTypes Type
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1610743892)]
		get;
	}

	[DispId(1610743893)]
	public virtual extern bool DataGraphicHidden
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1610743893)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1610743893)]
		[param: In]
		set;
	}

	[DispId(1610743895)]
	public virtual extern bool DataGraphicHidesText
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1610743895)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1610743895)]
		[param: In]
		set;
	}

	[DispId(1610743897)]
	public virtual extern bool DataGraphicShowBorder
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1610743897)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1610743897)]
		[param: In]
		set;
	}

	[DispId(1610743899)]
	public virtual extern VisGraphicPositionHorizontal DataGraphicHorizontalPosition
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1610743899)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1610743899)]
		[param: In]
		set;
	}

	[DispId(1610743901)]
	public virtual extern VisGraphicPositionVertical DataGraphicVerticalPosition
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1610743901)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1610743901)]
		[param: In]
		set;
	}

	[DispId(1610743903)]
	public virtual extern GraphicItems GraphicItems
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1610743903)]
		[return: MarshalAs(UnmanagedType.Interface)]
		get;
	}

	public virtual extern event EMaster_MasterChangedEventHandler MasterChanged;

	public virtual extern event EMaster_BeforeMasterDeleteEventHandler BeforeMasterDelete;

	public virtual extern event EMaster_ShapeAddedEventHandler ShapeAdded;

	public virtual extern event EMaster_BeforeSelectionDeleteEventHandler BeforeSelectionDelete;

	public virtual extern event EMaster_ShapeChangedEventHandler ShapeChanged;

	public virtual extern event EMaster_SelectionAddedEventHandler SelectionAdded;

	public virtual extern event EMaster_BeforeShapeDeleteEventHandler BeforeShapeDelete;

	public virtual extern event EMaster_TextChangedEventHandler TextChanged;

	public virtual extern event EMaster_CellChangedEventHandler CellChanged;

	public virtual extern event EMaster_FormulaChangedEventHandler FormulaChanged;

	public virtual extern event EMaster_ConnectionsAddedEventHandler ConnectionsAdded;

	public virtual extern event EMaster_ConnectionsDeletedEventHandler ConnectionsDeleted;

	public virtual extern event EMaster_QueryCancelMasterDeleteEventHandler QueryCancelMasterDelete;

	public virtual extern event EMaster_MasterDeleteCanceledEventHandler MasterDeleteCanceled;

	public virtual extern event EMaster_ShapeParentChangedEventHandler ShapeParentChanged;

	public virtual extern event EMaster_BeforeShapeTextEditEventHandler BeforeShapeTextEdit;

	public virtual extern event EMaster_ShapeExitedTextEditEventHandler ShapeExitedTextEdit;

	public virtual extern event EMaster_QueryCancelSelectionDeleteEventHandler QueryCancelSelectionDelete;

	public virtual extern event EMaster_SelectionDeleteCanceledEventHandler SelectionDeleteCanceled;

	public virtual extern event EMaster_QueryCancelUngroupEventHandler QueryCancelUngroup;

	public virtual extern event EMaster_UngroupCanceledEventHandler UngroupCanceled;

	public virtual extern event EMaster_QueryCancelConvertToGroupEventHandler QueryCancelConvertToGroup;

	public virtual extern event EMaster_ConvertToGroupCanceledEventHandler ConvertToGroupCanceled;

	public virtual extern event EMaster_QueryCancelGroupEventHandler QueryCancelGroup;

	public virtual extern event EMaster_GroupCanceledEventHandler GroupCanceled;

	public virtual extern event EMaster_ShapeDataGraphicChangedEventHandler ShapeDataGraphicChanged;

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(12)]
	public virtual extern void Delete();

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(16)]
	[return: MarshalAs(UnmanagedType.Interface)]
	public virtual extern Shape Drop([In][MarshalAs(UnmanagedType.IUnknown)] object ObjectToDrop, [In] double xPos, [In] double yPos);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(17)]
	public virtual extern void CenterDrawing();

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(20)]
	[return: MarshalAs(UnmanagedType.Interface)]
	public virtual extern Shape DrawLine([In] double xBegin, [In] double yBegin, [In] double xEnd, [In] double yEnd);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(21)]
	[return: MarshalAs(UnmanagedType.Interface)]
	public virtual extern Shape DrawRectangle([In] double x1, [In] double y1, [In] double x2, [In] double y2);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(22)]
	[return: MarshalAs(UnmanagedType.Interface)]
	public virtual extern Shape DrawOval([In] double x1, [In] double y1, [In] double x2, [In] double y2);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(23)]
	[return: MarshalAs(UnmanagedType.Interface)]
	public virtual extern Shape DrawSpline([In][MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_R8)] ref Array xyArray, [In] double Tolerance, [In] short Flags);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(24)]
	[return: MarshalAs(UnmanagedType.Interface)]
	public virtual extern Shape DrawBezier([In][MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_R8)] ref Array xyArray, [In] short degree, [In] short Flags);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(25)]
	[return: MarshalAs(UnmanagedType.Interface)]
	public virtual extern Shape DrawPolyline([In][MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_R8)] ref Array xyArray, [In] short Flags);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(26)]
	[return: MarshalAs(UnmanagedType.Interface)]
	public virtual extern Shape Import([In][MarshalAs(UnmanagedType.BStr)] string FileName);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(27)]
	public virtual extern void Export([In][MarshalAs(UnmanagedType.BStr)] string FileName);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(28)]
	[return: MarshalAs(UnmanagedType.Interface)]
	public virtual extern Shape InsertFromFile([In][MarshalAs(UnmanagedType.BStr)] string FileName, [In] short Flags);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(29)]
	[return: MarshalAs(UnmanagedType.Interface)]
	public virtual extern Shape InsertObject([In][MarshalAs(UnmanagedType.BStr)] string ClassOrProgID, [In] short Flags);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(30)]
	[return: MarshalAs(UnmanagedType.Interface)]
	public virtual extern Window OpenDrawWindow();

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(31)]
	[return: MarshalAs(UnmanagedType.Interface)]
	public virtual extern Window OpenIconWindow();

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(32)]
	[return: MarshalAs(UnmanagedType.Interface)]
	public virtual extern Master Open();

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(33)]
	public virtual extern void Close();

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(34)]
	public virtual extern short DropMany([In][MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_VARIANT)] ref Array ObjectsToInstance, [In][MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_R8)] ref Array xyArray, [MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_I2)] out Array IDArray);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(35)]
	public virtual extern void GetFormulas([In][MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_I2)] ref Array SID_SRCStream, [MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_VARIANT)] out Array formulaArray);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(36)]
	public virtual extern void GetResults([In][MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_I2)] ref Array SID_SRCStream, [In] short Flags, [In][MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_VARIANT)] ref Array UnitsNamesOrCodes, [MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_VARIANT)] out Array resultArray);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(37)]
	public virtual extern short SetFormulas([In][MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_I2)] ref Array SID_SRCStream, [In][MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_VARIANT)] ref Array formulaArray, [In] short Flags);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(38)]
	public virtual extern short SetResults([In][MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_I2)] ref Array SID_SRCStream, [In][MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_VARIANT)] ref Array UnitsNamesOrCodes, [In][MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_VARIANT)] ref Array resultArray, [In] short Flags);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(40)]
	public virtual extern void ImportIcon([In][MarshalAs(UnmanagedType.BStr)] string FileName);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[TypeLibFunc(64)]
	[DispId(41)]
	public virtual extern void ExportIconTransparentAsBlack([In][MarshalAs(UnmanagedType.BStr)] string FileName, [In] short Flags);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(42)]
	public virtual extern void Layout();

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(43)]
	public virtual extern void BoundingBox([In] short Flags, out double lpr8Left, out double lpr8Bottom, out double lpr8Right, out double lpr8Top);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(53)]
	[return: MarshalAs(UnmanagedType.Interface)]
	public virtual extern MasterShortcut CreateShortcut();

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(55)]
	public virtual extern short DropManyU([In][MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_VARIANT)] ref Array ObjectsToInstance, [In][MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_R8)] ref Array xyArray, [MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_I2)] out Array IDArray);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(56)]
	public virtual extern void GetFormulasU([In][MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_I2)] ref Array SID_SRCStream, [MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_VARIANT)] out Array formulaArray);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(57)]
	[return: MarshalAs(UnmanagedType.Interface)]
	public virtual extern Shape DrawNURBS([In] short degree, [In] short Flags, [In][MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_R8)] ref Array xyArray, [In][MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_R8)] ref Array knots, [Optional][In][MarshalAs(UnmanagedType.Struct)] object weights);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(58)]
	public virtual extern void ExportIcon([In][MarshalAs(UnmanagedType.BStr)] string FileName, [In] short Flags, [Optional][In][MarshalAs(UnmanagedType.Struct)] object TransparentRGB);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(1610743884)]
	public virtual extern void ResizeToFitContents();

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(1610743885)]
	public virtual extern void Paste([Optional][In][MarshalAs(UnmanagedType.Struct)] object Flags);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(1610743886)]
	public virtual extern void PasteSpecial([In] int Format, [Optional][In][MarshalAs(UnmanagedType.Struct)] object Link, [Optional][In][MarshalAs(UnmanagedType.Struct)] object DisplayAsIcon);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(1610743887)]
	[return: MarshalAs(UnmanagedType.Interface)]
	public virtual extern Selection CreateSelection([In] VisSelectionTypes SelType, [In] VisSelectMode IterationMode = VisSelectMode.visSelModeSkipSuper, [Optional][In][MarshalAs(UnmanagedType.Struct)] object Data);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(1610743888)]
	[return: MarshalAs(UnmanagedType.Interface)]
	public virtual extern Shape AddGuide([In] short Type, [In] double xPos, [In] double yPos);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(1610743889)]
	[return: MarshalAs(UnmanagedType.Interface)]
	public virtual extern Shape DrawArcByThreePoints([In] double xBegin, [In] double yBegin, [In] double xEnd, [In] double yEnd, [In] double xControl, [In] double yControl);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(1610743890)]
	[return: MarshalAs(UnmanagedType.Interface)]
	public virtual extern Shape DrawQuarterArc([In] double xBegin, [In] double yBegin, [In] double xEnd, [In] double yEnd, [In] VisArcSweepFlags SweepFlag);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(1610743891)]
	[return: MarshalAs(UnmanagedType.Interface)]
	public virtual extern Shape DrawCircularArc([In] double xCenter, [In] double yCenter, [In] double Radius, [In] double StartAngle = 0.0, [In] double EndAngle = 3.1415927410125732);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(1610743904)]
	public virtual extern void DataGraphicDelete();

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(1610743905)]
	public virtual extern void PasteToLocation([In] double xPos, [In] double yPos, [In] int Flags);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(1610743906)]
	public virtual extern void VisualBoundingBox([In] short Flags, out double lpr8Left, out double lpr8Bottom, out double lpr8Right, out double lpr8Top);
}
