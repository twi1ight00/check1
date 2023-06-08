using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using stdole;

namespace Microsoft.Office.Interop.Visio;

[ComImport]
[ClassInterface(0)]
[DefaultMember("Name")]
[ComSourceInterfaces("Microsoft.Office.Interop.Visio.EPage\0\0")]
[Guid("000D0A06-0000-0000-C000-000000000046")]
public class PageClass : IVPage, Page, EPage_Event
{
	[DispId(13)]
	public virtual extern Document Document
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(13)]
		[return: MarshalAs(UnmanagedType.Interface)]
		get;
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

	[DispId(11)]
	public virtual extern short Background
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(11)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(11)]
		[param: In]
		set;
	}

	[DispId(3)]
	public virtual extern short ObjectType
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(3)]
		get;
	}

	[DispId(4)]
	public virtual extern short Index
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(4)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(4)]
		[param: In]
		set;
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

	[DispId(5)]
	public virtual extern Shapes Shapes
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(5)]
		[return: MarshalAs(UnmanagedType.Interface)]
		get;
	}

	[DispId(14)]
	public virtual extern Page BackPageAsObj
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[TypeLibFunc(64)]
		[DispId(14)]
		[return: MarshalAs(UnmanagedType.Interface)]
		get;
	}

	[DispId(1499)]
	public virtual extern string BackPageFromName
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1499)]
		[TypeLibFunc(64)]
		[param: In]
		[param: MarshalAs(UnmanagedType.BStr)]
		set;
	}

	[DispId(19)]
	public virtual extern Layers Layers
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(19)]
		[return: MarshalAs(UnmanagedType.Interface)]
		get;
	}

	[DispId(20)]
	public virtual extern Shape PageSheet
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(20)]
		[return: MarshalAs(UnmanagedType.Interface)]
		get;
	}

	[DispId(23)]
	public virtual extern EventList EventList
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(23)]
		[return: MarshalAs(UnmanagedType.Interface)]
		get;
	}

	[DispId(24)]
	public virtual extern short PersistsEvents
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(24)]
		get;
	}

	[DispId(36)]
	public virtual extern Connects Connects
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(36)]
		[return: MarshalAs(UnmanagedType.Interface)]
		get;
	}

	[DispId(37)]
	public virtual extern object BackPage
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(37)]
		[return: MarshalAs(UnmanagedType.Struct)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(37)]
		[param: In]
		[param: MarshalAs(UnmanagedType.Struct)]
		set;
	}

	[DispId(40)]
	public virtual extern short ID16
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(40)]
		[TypeLibFunc(64)]
		get;
	}

	[DispId(41)]
	public virtual extern OLEObjects OLEObjects
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(41)]
		[return: MarshalAs(UnmanagedType.Interface)]
		get;
	}

	[DispId(42)]
	public virtual extern int ID
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(42)]
		get;
	}

	[DispId(43)]
	public virtual extern Selection SpatialSearch
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(43)]
		[return: MarshalAs(UnmanagedType.Interface)]
		get;
	}

	[DispId(44)]
	public virtual extern string NameU
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(44)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(44)]
		[param: In]
		[param: MarshalAs(UnmanagedType.BStr)]
		set;
	}

	[ComAliasName("stdole.IPictureDisp")]
	[DispId(1610743861)]
	public virtual extern IPictureDisp Picture
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1610743861)]
		[return: MarshalAs(UnmanagedType.Interface)]
		[return: ComAliasName("stdole.IPictureDisp")]
		get;
	}

	[DispId(1610743863)]
	public virtual extern int PrintTileCount
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1610743863)]
		get;
	}

	[DispId(1610743869)]
	public virtual extern VisPageTypes Type
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1610743869)]
		get;
	}

	[DispId(1610743873)]
	public virtual extern int ReviewerID
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1610743873)]
		get;
	}

	[DispId(1610743874)]
	public virtual extern Page OriginalPage
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1610743874)]
		[return: MarshalAs(UnmanagedType.Interface)]
		get;
	}

	[DispId(1610743882)]
	public virtual extern object ThemeColors
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1610743882)]
		[return: MarshalAs(UnmanagedType.Struct)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1610743882)]
		[param: In]
		[param: MarshalAs(UnmanagedType.Struct)]
		set;
	}

	[DispId(1610743884)]
	public virtual extern object ThemeEffects
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1610743884)]
		[return: MarshalAs(UnmanagedType.Struct)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1610743884)]
		[param: In]
		[param: MarshalAs(UnmanagedType.Struct)]
		set;
	}

	[DispId(1610743897)]
	public virtual extern bool LayoutRoutePassive
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1610743897)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1610743897)]
		[param: In]
		set;
	}

	[DispId(1610743901)]
	public virtual extern bool AutoSize
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1610743901)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1610743901)]
		[param: In]
		set;
	}

	[DispId(1610743907)]
	public virtual extern Comments Comments
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1610743907)]
		[return: MarshalAs(UnmanagedType.Interface)]
		get;
	}

	[DispId(1610743908)]
	public virtual extern Comments ShapeComments
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1610743908)]
		[return: MarshalAs(UnmanagedType.Interface)]
		get;
	}

	public virtual extern event EPage_PageChangedEventHandler PageChanged;

	public virtual extern event EPage_BeforePageDeleteEventHandler BeforePageDelete;

	public virtual extern event EPage_ShapeAddedEventHandler ShapeAdded;

	public virtual extern event EPage_BeforeSelectionDeleteEventHandler BeforeSelectionDelete;

	public virtual extern event EPage_ShapeChangedEventHandler ShapeChanged;

	public virtual extern event EPage_SelectionAddedEventHandler SelectionAdded;

	public virtual extern event EPage_BeforeShapeDeleteEventHandler BeforeShapeDelete;

	public virtual extern event EPage_TextChangedEventHandler TextChanged;

	public virtual extern event EPage_CellChangedEventHandler CellChanged;

	public virtual extern event EPage_FormulaChangedEventHandler FormulaChanged;

	public virtual extern event EPage_ConnectionsAddedEventHandler ConnectionsAdded;

	public virtual extern event EPage_ConnectionsDeletedEventHandler ConnectionsDeleted;

	public virtual extern event EPage_QueryCancelPageDeleteEventHandler QueryCancelPageDelete;

	public virtual extern event EPage_PageDeleteCanceledEventHandler PageDeleteCanceled;

	public virtual extern event EPage_ShapeParentChangedEventHandler ShapeParentChanged;

	public virtual extern event EPage_BeforeShapeTextEditEventHandler BeforeShapeTextEdit;

	public virtual extern event EPage_ShapeExitedTextEditEventHandler ShapeExitedTextEdit;

	public virtual extern event EPage_QueryCancelSelectionDeleteEventHandler QueryCancelSelectionDelete;

	public virtual extern event EPage_SelectionDeleteCanceledEventHandler SelectionDeleteCanceled;

	public virtual extern event EPage_QueryCancelUngroupEventHandler QueryCancelUngroup;

	public virtual extern event EPage_UngroupCanceledEventHandler UngroupCanceled;

	public virtual extern event EPage_QueryCancelConvertToGroupEventHandler QueryCancelConvertToGroup;

	public virtual extern event EPage_ConvertToGroupCanceledEventHandler ConvertToGroupCanceled;

	public virtual extern event EPage_QueryCancelGroupEventHandler QueryCancelGroup;

	public virtual extern event EPage_GroupCanceledEventHandler GroupCanceled;

	public virtual extern event EPage_ShapeDataGraphicChangedEventHandler ShapeDataGraphicChanged;

	public virtual extern event EPage_ShapeLinkAddedEventHandler ShapeLinkAdded;

	public virtual extern event EPage_ShapeLinkDeletedEventHandler ShapeLinkDeleted;

	public virtual extern event EPage_ContainerRelationshipAddedEventHandler ContainerRelationshipAdded;

	public virtual extern event EPage_ContainerRelationshipDeletedEventHandler ContainerRelationshipDeleted;

	public virtual extern event EPage_CalloutRelationshipAddedEventHandler CalloutRelationshipAdded;

	public virtual extern event EPage_CalloutRelationshipDeletedEventHandler CalloutRelationshipDeleted;

	public virtual extern event EPage_QueryCancelReplaceShapesEventHandler QueryCancelReplaceShapes;

	public virtual extern event EPage_ReplaceShapesCanceledEventHandler ReplaceShapesCanceled;

	public virtual extern event EPage_BeforeReplaceShapesEventHandler BeforeReplaceShapes;

	public virtual extern event EPage_AfterReplaceShapesEventHandler AfterReplaceShapes;

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(10)]
	[TypeLibFunc(64)]
	public virtual extern void old_Paste();

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(16)]
	[TypeLibFunc(64)]
	public virtual extern void old_PasteSpecial([In] short Format);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(6)]
	[return: MarshalAs(UnmanagedType.Interface)]
	public virtual extern Shape DrawLine([In] double xBegin, [In] double yBegin, [In] double xEnd, [In] double yEnd);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(7)]
	[return: MarshalAs(UnmanagedType.Interface)]
	public virtual extern Shape DrawRectangle([In] double x1, [In] double y1, [In] double x2, [In] double y2);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(8)]
	[return: MarshalAs(UnmanagedType.Interface)]
	public virtual extern Shape DrawOval([In] double x1, [In] double y1, [In] double x2, [In] double y2);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(9)]
	[return: MarshalAs(UnmanagedType.Interface)]
	public virtual extern Shape Drop([In][MarshalAs(UnmanagedType.IUnknown)] object ObjectToDrop, [In] double xPos, [In] double yPos);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(12)]
	[return: MarshalAs(UnmanagedType.Interface)]
	public virtual extern Shape AddGuide([In] short Type, [In] double xPos, [In] double yPos);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(15)]
	public virtual extern void Print();

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(17)]
	[return: MarshalAs(UnmanagedType.Interface)]
	public virtual extern Shape Import([In][MarshalAs(UnmanagedType.BStr)] string FileName);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(18)]
	public virtual extern void Export([In][MarshalAs(UnmanagedType.BStr)] string FileName);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(21)]
	public virtual extern void Delete([In] short fRenumberPages);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(22)]
	public virtual extern void CenterDrawing();

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(25)]
	[return: MarshalAs(UnmanagedType.Interface)]
	public virtual extern Shape DrawSpline([In][MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_R8)] ref Array xyArray, [In] double Tolerance, [In] short Flags);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(26)]
	[return: MarshalAs(UnmanagedType.Interface)]
	public virtual extern Shape DrawBezier([In][MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_R8)] ref Array xyArray, [In] short degree, [In] short Flags);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(27)]
	[return: MarshalAs(UnmanagedType.Interface)]
	public virtual extern Shape DrawPolyline([In][MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_R8)] ref Array xyArray, [In] short Flags);

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
	public virtual extern short DropMany([In][MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_VARIANT)] ref Array ObjectsToInstance, [In][MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_R8)] ref Array xyArray, [MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_I2)] out Array IDArray);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(32)]
	public virtual extern void GetFormulas([In][MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_I2)] ref Array SID_SRCStream, [MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_VARIANT)] out Array formulaArray);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(33)]
	public virtual extern void GetResults([In][MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_I2)] ref Array SID_SRCStream, [In] short Flags, [In][MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_VARIANT)] ref Array UnitsNamesOrCodes, [MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_VARIANT)] out Array resultArray);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(34)]
	public virtual extern short SetFormulas([In][MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_I2)] ref Array SID_SRCStream, [In][MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_VARIANT)] ref Array formulaArray, [In] short Flags);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(35)]
	public virtual extern short SetResults([In][MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_I2)] ref Array SID_SRCStream, [In][MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_VARIANT)] ref Array UnitsNamesOrCodes, [In][MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_VARIANT)] ref Array resultArray, [In] short Flags);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(38)]
	public virtual extern void Layout();

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(39)]
	public virtual extern void BoundingBox([In] short Flags, out double lpr8Left, out double lpr8Bottom, out double lpr8Right, out double lpr8Top);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(45)]
	public virtual extern short DropManyU([In][MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_VARIANT)] ref Array ObjectsToInstance, [In][MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_R8)] ref Array xyArray, [MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_I2)] out Array IDArray);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(46)]
	public virtual extern void GetFormulasU([In][MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_I2)] ref Array SID_SRCStream, [MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_VARIANT)] out Array formulaArray);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(47)]
	[return: MarshalAs(UnmanagedType.Interface)]
	public virtual extern Shape DrawNURBS([In] short degree, [In] short Flags, [In][MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_R8)] ref Array xyArray, [In][MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_R8)] ref Array knots, [Optional][In][MarshalAs(UnmanagedType.Struct)] object weights);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(1610743864)]
	public virtual extern void PrintTile([In] int nTile);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(1610743865)]
	public virtual extern void ResizeToFitContents();

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(1610743866)]
	public virtual extern void Paste([Optional][In][MarshalAs(UnmanagedType.Struct)] object Flags);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(1610743867)]
	public virtual extern void PasteSpecial([In] int Format, [Optional][In][MarshalAs(UnmanagedType.Struct)] object Link, [Optional][In][MarshalAs(UnmanagedType.Struct)] object DisplayAsIcon);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(1610743868)]
	[return: MarshalAs(UnmanagedType.Interface)]
	public virtual extern Selection CreateSelection([In] VisSelectionTypes SelType, [In] VisSelectMode IterationMode = VisSelectMode.visSelModeSkipSuper, [Optional][In][MarshalAs(UnmanagedType.Struct)] object Data);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(1610743870)]
	[return: MarshalAs(UnmanagedType.Interface)]
	public virtual extern Shape DrawArcByThreePoints([In] double xBegin, [In] double yBegin, [In] double xEnd, [In] double yEnd, [In] double xControl, [In] double yControl);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(1610743871)]
	[return: MarshalAs(UnmanagedType.Interface)]
	public virtual extern Shape DrawQuarterArc([In] double xBegin, [In] double yBegin, [In] double xEnd, [In] double yEnd, [In] VisArcSweepFlags SweepFlag);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(1610743872)]
	[return: MarshalAs(UnmanagedType.Interface)]
	public virtual extern Shape DrawCircularArc([In] double xCenter, [In] double yCenter, [In] double Radius, [In] double StartAngle = 0.0, [In] double EndAngle = 3.1415927410125732);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(1610743875)]
	public virtual extern void GetShapesLinkedToData([In] int DataRecordsetID, [MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_I4)] out Array ShapeIDs);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(1610743876)]
	public virtual extern void GetShapesLinkedToDataRow([In] int DataRecordsetID, [In] int DataRowID, [MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_I4)] out Array ShapeIDs);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(1610743877)]
	public virtual extern void LinkShapesToDataRows([In] int DataRecordsetID, [In][MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_I4)] ref Array DataRowIDs, [In][MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_I4)] ref Array ShapeIDs, [In] bool ApplyDataGraphicAfterLink = true);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(1610743878)]
	public virtual extern void ShapeIDsToUniqueIDs([In][MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_I4)] ref Array ShapeIDs, [In] VisUniqueIDArgs UniqueIDArgs, [MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_BSTR)] out Array GUIDs);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(1610743879)]
	public virtual extern void UniqueIDsToShapeIDs([In][MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_BSTR)] ref Array GUIDs, [MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_I4)] out Array ShapeIDs);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(1610743880)]
	[return: MarshalAs(UnmanagedType.Interface)]
	public virtual extern Shape DropLinked([In][MarshalAs(UnmanagedType.IUnknown)] object ObjectToDrop, [In] double x, [In] double y, [In] int DataRecordsetID, [In] int DataRowID, [In] bool ApplyDataGraphicAfterLink);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(1610743881)]
	public virtual extern int DropManyLinkedU([In][MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_VARIANT)] ref Array ObjectsToInstance, [In][MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_R8)] ref Array XYs, [In] int DataRecordsetID, [In][MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_I4)] ref Array DataRowIDs, [In] bool ApplyDataGraphicAfterLink, [MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_I4)] out Array ShapeIDs);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(1610743886)]
	[return: MarshalAs(UnmanagedType.Interface)]
	public virtual extern Shape DropConnected([In][MarshalAs(UnmanagedType.IUnknown)] object ObjectToDrop, [In][MarshalAs(UnmanagedType.Interface)] Shape TargetShape, [In] VisAutoConnectDir PlacementDir, [Optional][In][IUnknownConstant][MarshalAs(UnmanagedType.IUnknown)] object Connector);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(1610743887)]
	public virtual extern int AutoConnectMany([In][MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_I4)] ref Array FromShapeIDs, [In][MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_I4)] ref Array ToShapeIDs, [In][MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_I4)] ref Array PlacementDirs, [Optional][In][IUnknownConstant][MarshalAs(UnmanagedType.IUnknown)] object Connector);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(1610743888)]
	[return: MarshalAs(UnmanagedType.Interface)]
	public virtual extern Shape DropContainer([In][MarshalAs(UnmanagedType.IUnknown)] object ObjectToDrop, [In][MarshalAs(UnmanagedType.IUnknown)] object TargetShapes);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(1610743889)]
	public virtual extern void LayoutIncremental([In] VisLayoutIncrementalType AlignOrSpace, [In] VisLayoutHorzAlignType AlignHorizontal, [In] VisLayoutVertAlignType AlignVertical, [In] double SpaceHorizontal, [In] double SpaceVertical, [In] VisUnitCodes UnitsNameOrCode);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(1610743890)]
	public virtual extern void LayoutChangeDirection([In] VisLayoutDirection Direction);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(1610743891)]
	public virtual extern void AvoidPageBreaks();

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(1610743892)]
	[return: MarshalAs(UnmanagedType.Interface)]
	public virtual extern Shape SplitConnector([In][MarshalAs(UnmanagedType.Interface)] Shape ConnectorToSplit, [In][MarshalAs(UnmanagedType.Interface)] Shape Shape);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(1610743893)]
	[return: MarshalAs(UnmanagedType.Interface)]
	public virtual extern Shape DropCallout([In][MarshalAs(UnmanagedType.IUnknown)] object ObjectToDrop, [In][MarshalAs(UnmanagedType.Interface)] Shape TargetShape);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(1610743894)]
	public virtual extern void PasteToLocation([In] double xPos, [In] double yPos, [In] int Flags);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(1610743895)]
	[return: MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_I4)]
	public virtual extern Array GetContainers([In] VisContainerNested NestedOptions);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(1610743896)]
	[return: MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_I4)]
	public virtual extern Array GetCallouts([In] VisContainerNested NestedOptions);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(1610743899)]
	[return: MarshalAs(UnmanagedType.Interface)]
	public virtual extern Shape DropLegend([In][MarshalAs(UnmanagedType.IUnknown)] object OuterList, [In][MarshalAs(UnmanagedType.IUnknown)] object InnerContainer, [In] VisLegendFlags populateFlags);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(1610743900)]
	[return: MarshalAs(UnmanagedType.Interface)]
	public virtual extern Shape DropIntoList([In][MarshalAs(UnmanagedType.IUnknown)] object ObjectToDrop, [In][MarshalAs(UnmanagedType.Interface)] Shape TargetList, [In] int lPosition);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(1610743903)]
	public virtual extern void AutoSizeDrawing();

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(1610743904)]
	[return: MarshalAs(UnmanagedType.Interface)]
	public virtual extern Page Duplicate();

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(1610743905)]
	[return: MarshalAs(UnmanagedType.Struct)]
	public virtual extern object GetTheme([In] VisThemeTypes eThemeType);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(1610743906)]
	public virtual extern void SetTheme([In][MarshalAs(UnmanagedType.Struct)] object varThemeIndex, [Optional][In][MarshalAs(UnmanagedType.Struct)] object varColorScheme, [Optional][In][MarshalAs(UnmanagedType.Struct)] object varEffectScheme, [Optional][In][MarshalAs(UnmanagedType.Struct)] object varConnectorScheme, [Optional][In][MarshalAs(UnmanagedType.Struct)] object varFontScheme);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(1610743909)]
	public virtual extern void GetThemeVariant(out short pVariantColor, out short pVariantStyle, [Optional][DefaultParameterValue(0)] out short pEmbellishment);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(1610743910)]
	public virtual extern void SetThemeVariant([In] short variantColor, [In] short variantStyle, [In] short embellishment = -1);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(1610743911)]
	public virtual extern void VisualBoundingBox([In] short Flags, out double lpr8Left, out double lpr8Bottom, out double lpr8Right, out double lpr8Top);
}
