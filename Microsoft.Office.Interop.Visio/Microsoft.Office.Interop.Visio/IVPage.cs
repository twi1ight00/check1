using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using stdole;

namespace Microsoft.Office.Interop.Visio;

[ComImport]
[DefaultMember("Name")]
[Guid("000D0709-0000-0000-C000-000000000046")]
[TypeLibType(4176)]
public interface IVPage
{
	[DispId(13)]
	Document Document
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(13)]
		[return: MarshalAs(UnmanagedType.Interface)]
		get;
	}

	[DispId(1)]
	Application Application
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1)]
		[return: MarshalAs(UnmanagedType.Interface)]
		get;
	}

	[DispId(2)]
	short Stat
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(2)]
		get;
	}

	[DispId(11)]
	short Background
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(11)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(11)]
		[param: In]
		set;
	}

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[TypeLibFunc(64)]
	[DispId(10)]
	void old_Paste();

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[TypeLibFunc(64)]
	[DispId(16)]
	void old_PasteSpecial([In] short Format);

	[DispId(3)]
	short ObjectType
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(3)]
		get;
	}

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(6)]
	[return: MarshalAs(UnmanagedType.Interface)]
	Shape DrawLine([In] double xBegin, [In] double yBegin, [In] double xEnd, [In] double yEnd);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(7)]
	[return: MarshalAs(UnmanagedType.Interface)]
	Shape DrawRectangle([In] double x1, [In] double y1, [In] double x2, [In] double y2);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(8)]
	[return: MarshalAs(UnmanagedType.Interface)]
	Shape DrawOval([In] double x1, [In] double y1, [In] double x2, [In] double y2);

	[DispId(4)]
	short Index
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
	string Name
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
	Shapes Shapes
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(5)]
		[return: MarshalAs(UnmanagedType.Interface)]
		get;
	}

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(9)]
	[return: MarshalAs(UnmanagedType.Interface)]
	Shape Drop([In][MarshalAs(UnmanagedType.IUnknown)] object ObjectToDrop, [In] double xPos, [In] double yPos);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(12)]
	[return: MarshalAs(UnmanagedType.Interface)]
	Shape AddGuide([In] short Type, [In] double xPos, [In] double yPos);

	[DispId(14)]
	Page BackPageAsObj
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(14)]
		[TypeLibFunc(64)]
		[return: MarshalAs(UnmanagedType.Interface)]
		get;
	}

	[DispId(1499)]
	string BackPageFromName
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[TypeLibFunc(64)]
		[DispId(1499)]
		[param: In]
		[param: MarshalAs(UnmanagedType.BStr)]
		set;
	}

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(15)]
	void Print();

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(17)]
	[return: MarshalAs(UnmanagedType.Interface)]
	Shape Import([In][MarshalAs(UnmanagedType.BStr)] string FileName);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(18)]
	void Export([In][MarshalAs(UnmanagedType.BStr)] string FileName);

	[DispId(19)]
	Layers Layers
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(19)]
		[return: MarshalAs(UnmanagedType.Interface)]
		get;
	}

	[DispId(20)]
	Shape PageSheet
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(20)]
		[return: MarshalAs(UnmanagedType.Interface)]
		get;
	}

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(21)]
	void Delete([In] short fRenumberPages);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(22)]
	void CenterDrawing();

	[DispId(23)]
	EventList EventList
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(23)]
		[return: MarshalAs(UnmanagedType.Interface)]
		get;
	}

	[DispId(24)]
	short PersistsEvents
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(24)]
		get;
	}

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(25)]
	[return: MarshalAs(UnmanagedType.Interface)]
	Shape DrawSpline([In][MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_R8)] ref Array xyArray, [In] double Tolerance, [In] short Flags);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(26)]
	[return: MarshalAs(UnmanagedType.Interface)]
	Shape DrawBezier([In][MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_R8)] ref Array xyArray, [In] short degree, [In] short Flags);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(27)]
	[return: MarshalAs(UnmanagedType.Interface)]
	Shape DrawPolyline([In][MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_R8)] ref Array xyArray, [In] short Flags);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(28)]
	[return: MarshalAs(UnmanagedType.Interface)]
	Shape InsertFromFile([In][MarshalAs(UnmanagedType.BStr)] string FileName, [In] short Flags);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(29)]
	[return: MarshalAs(UnmanagedType.Interface)]
	Shape InsertObject([In][MarshalAs(UnmanagedType.BStr)] string ClassOrProgID, [In] short Flags);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(30)]
	[return: MarshalAs(UnmanagedType.Interface)]
	Window OpenDrawWindow();

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(31)]
	short DropMany([In][MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_VARIANT)] ref Array ObjectsToInstance, [In][MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_R8)] ref Array xyArray, [MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_I2)] out Array IDArray);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(32)]
	void GetFormulas([In][MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_I2)] ref Array SID_SRCStream, [MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_VARIANT)] out Array formulaArray);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(33)]
	void GetResults([In][MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_I2)] ref Array SID_SRCStream, [In] short Flags, [In][MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_VARIANT)] ref Array UnitsNamesOrCodes, [MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_VARIANT)] out Array resultArray);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(34)]
	short SetFormulas([In][MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_I2)] ref Array SID_SRCStream, [In][MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_VARIANT)] ref Array formulaArray, [In] short Flags);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(35)]
	short SetResults([In][MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_I2)] ref Array SID_SRCStream, [In][MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_VARIANT)] ref Array UnitsNamesOrCodes, [In][MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_VARIANT)] ref Array resultArray, [In] short Flags);

	[DispId(36)]
	Connects Connects
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(36)]
		[return: MarshalAs(UnmanagedType.Interface)]
		get;
	}

	[DispId(37)]
	object BackPage
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

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(38)]
	void Layout();

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(39)]
	void BoundingBox([In] short Flags, out double lpr8Left, out double lpr8Bottom, out double lpr8Right, out double lpr8Top);

	[DispId(40)]
	short ID16
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[TypeLibFunc(64)]
		[DispId(40)]
		get;
	}

	[DispId(41)]
	OLEObjects OLEObjects
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(41)]
		[return: MarshalAs(UnmanagedType.Interface)]
		get;
	}

	[DispId(42)]
	int ID
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(42)]
		get;
	}

	[DispId(43)]
	Selection SpatialSearch
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(43)]
		[return: MarshalAs(UnmanagedType.Interface)]
		get;
	}

	[DispId(44)]
	string NameU
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

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(45)]
	short DropManyU([In][MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_VARIANT)] ref Array ObjectsToInstance, [In][MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_R8)] ref Array xyArray, [MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_I2)] out Array IDArray);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(46)]
	void GetFormulasU([In][MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_I2)] ref Array SID_SRCStream, [MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_VARIANT)] out Array formulaArray);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(47)]
	[return: MarshalAs(UnmanagedType.Interface)]
	Shape DrawNURBS([In] short degree, [In] short Flags, [In][MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_R8)] ref Array xyArray, [In][MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_R8)] ref Array knots, [Optional][In][MarshalAs(UnmanagedType.Struct)] object weights);

	[ComAliasName("stdole.IPictureDisp")]
	[DispId(1610743861)]
	IPictureDisp Picture
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1610743861)]
		[return: MarshalAs(UnmanagedType.Interface)]
		[return: ComAliasName("stdole.IPictureDisp")]
		get;
	}

	[DispId(1610743863)]
	int PrintTileCount
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1610743863)]
		get;
	}

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(1610743864)]
	void PrintTile([In] int nTile);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(1610743865)]
	void ResizeToFitContents();

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(1610743866)]
	void Paste([Optional][In][MarshalAs(UnmanagedType.Struct)] object Flags);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(1610743867)]
	void PasteSpecial([In] int Format, [Optional][In][MarshalAs(UnmanagedType.Struct)] object Link, [Optional][In][MarshalAs(UnmanagedType.Struct)] object DisplayAsIcon);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(1610743868)]
	[return: MarshalAs(UnmanagedType.Interface)]
	Selection CreateSelection([In] VisSelectionTypes SelType, [In] VisSelectMode IterationMode = VisSelectMode.visSelModeSkipSuper, [Optional][In][MarshalAs(UnmanagedType.Struct)] object Data);

	[DispId(1610743869)]
	VisPageTypes Type
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1610743869)]
		get;
	}

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(1610743870)]
	[return: MarshalAs(UnmanagedType.Interface)]
	Shape DrawArcByThreePoints([In] double xBegin, [In] double yBegin, [In] double xEnd, [In] double yEnd, [In] double xControl, [In] double yControl);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(1610743871)]
	[return: MarshalAs(UnmanagedType.Interface)]
	Shape DrawQuarterArc([In] double xBegin, [In] double yBegin, [In] double xEnd, [In] double yEnd, [In] VisArcSweepFlags SweepFlag);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(1610743872)]
	[return: MarshalAs(UnmanagedType.Interface)]
	Shape DrawCircularArc([In] double xCenter, [In] double yCenter, [In] double Radius, [In] double StartAngle = 0.0, [In] double EndAngle = 3.1415927410125732);

	[DispId(1610743873)]
	int ReviewerID
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1610743873)]
		get;
	}

	[DispId(1610743874)]
	Page OriginalPage
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1610743874)]
		[return: MarshalAs(UnmanagedType.Interface)]
		get;
	}

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(1610743875)]
	void GetShapesLinkedToData([In] int DataRecordsetID, [MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_I4)] out Array ShapeIDs);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(1610743876)]
	void GetShapesLinkedToDataRow([In] int DataRecordsetID, [In] int DataRowID, [MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_I4)] out Array ShapeIDs);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(1610743877)]
	void LinkShapesToDataRows([In] int DataRecordsetID, [In][MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_I4)] ref Array DataRowIDs, [In][MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_I4)] ref Array ShapeIDs, [In] bool ApplyDataGraphicAfterLink = true);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(1610743878)]
	void ShapeIDsToUniqueIDs([In][MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_I4)] ref Array ShapeIDs, [In] VisUniqueIDArgs UniqueIDArgs, [MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_BSTR)] out Array GUIDs);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(1610743879)]
	void UniqueIDsToShapeIDs([In][MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_BSTR)] ref Array GUIDs, [MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_I4)] out Array ShapeIDs);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(1610743880)]
	[return: MarshalAs(UnmanagedType.Interface)]
	Shape DropLinked([In][MarshalAs(UnmanagedType.IUnknown)] object ObjectToDrop, [In] double x, [In] double y, [In] int DataRecordsetID, [In] int DataRowID, [In] bool ApplyDataGraphicAfterLink);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(1610743881)]
	int DropManyLinkedU([In][MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_VARIANT)] ref Array ObjectsToInstance, [In][MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_R8)] ref Array XYs, [In] int DataRecordsetID, [In][MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_I4)] ref Array DataRowIDs, [In] bool ApplyDataGraphicAfterLink, [MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_I4)] out Array ShapeIDs);

	[DispId(1610743882)]
	object ThemeColors
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
	object ThemeEffects
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

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(1610743886)]
	[return: MarshalAs(UnmanagedType.Interface)]
	Shape DropConnected([In][MarshalAs(UnmanagedType.IUnknown)] object ObjectToDrop, [In][MarshalAs(UnmanagedType.Interface)] Shape TargetShape, [In] VisAutoConnectDir PlacementDir, [Optional][In][IUnknownConstant][MarshalAs(UnmanagedType.IUnknown)] object Connector);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(1610743887)]
	int AutoConnectMany([In][MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_I4)] ref Array FromShapeIDs, [In][MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_I4)] ref Array ToShapeIDs, [In][MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_I4)] ref Array PlacementDirs, [Optional][In][IUnknownConstant][MarshalAs(UnmanagedType.IUnknown)] object Connector);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(1610743888)]
	[return: MarshalAs(UnmanagedType.Interface)]
	Shape DropContainer([In][MarshalAs(UnmanagedType.IUnknown)] object ObjectToDrop, [In][MarshalAs(UnmanagedType.IUnknown)] object TargetShapes);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(1610743889)]
	void LayoutIncremental([In] VisLayoutIncrementalType AlignOrSpace, [In] VisLayoutHorzAlignType AlignHorizontal, [In] VisLayoutVertAlignType AlignVertical, [In] double SpaceHorizontal, [In] double SpaceVertical, [In] VisUnitCodes UnitsNameOrCode);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(1610743890)]
	void LayoutChangeDirection([In] VisLayoutDirection Direction);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(1610743891)]
	void AvoidPageBreaks();

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(1610743892)]
	[return: MarshalAs(UnmanagedType.Interface)]
	Shape SplitConnector([In][MarshalAs(UnmanagedType.Interface)] Shape ConnectorToSplit, [In][MarshalAs(UnmanagedType.Interface)] Shape Shape);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(1610743893)]
	[return: MarshalAs(UnmanagedType.Interface)]
	Shape DropCallout([In][MarshalAs(UnmanagedType.IUnknown)] object ObjectToDrop, [In][MarshalAs(UnmanagedType.Interface)] Shape TargetShape);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(1610743894)]
	void PasteToLocation([In] double xPos, [In] double yPos, [In] int Flags);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(1610743895)]
	[return: MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_I4)]
	Array GetContainers([In] VisContainerNested NestedOptions);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(1610743896)]
	[return: MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_I4)]
	Array GetCallouts([In] VisContainerNested NestedOptions);

	[DispId(1610743897)]
	bool LayoutRoutePassive
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1610743897)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1610743897)]
		[param: In]
		set;
	}

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(1610743899)]
	[return: MarshalAs(UnmanagedType.Interface)]
	Shape DropLegend([In][MarshalAs(UnmanagedType.IUnknown)] object OuterList, [In][MarshalAs(UnmanagedType.IUnknown)] object InnerContainer, [In] VisLegendFlags populateFlags);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(1610743900)]
	[return: MarshalAs(UnmanagedType.Interface)]
	Shape DropIntoList([In][MarshalAs(UnmanagedType.IUnknown)] object ObjectToDrop, [In][MarshalAs(UnmanagedType.Interface)] Shape TargetList, [In] int lPosition);

	[DispId(1610743901)]
	bool AutoSize
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1610743901)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1610743901)]
		[param: In]
		set;
	}

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(1610743903)]
	void AutoSizeDrawing();

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(1610743904)]
	[return: MarshalAs(UnmanagedType.Interface)]
	Page Duplicate();

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(1610743905)]
	[return: MarshalAs(UnmanagedType.Struct)]
	object GetTheme([In] VisThemeTypes eThemeType);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(1610743906)]
	void SetTheme([In][MarshalAs(UnmanagedType.Struct)] object varThemeIndex, [Optional][In][MarshalAs(UnmanagedType.Struct)] object varColorScheme, [Optional][In][MarshalAs(UnmanagedType.Struct)] object varEffectScheme, [Optional][In][MarshalAs(UnmanagedType.Struct)] object varConnectorScheme, [Optional][In][MarshalAs(UnmanagedType.Struct)] object varFontScheme);

	[DispId(1610743907)]
	Comments Comments
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1610743907)]
		[return: MarshalAs(UnmanagedType.Interface)]
		get;
	}

	[DispId(1610743908)]
	Comments ShapeComments
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1610743908)]
		[return: MarshalAs(UnmanagedType.Interface)]
		get;
	}

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(1610743909)]
	void GetThemeVariant(out short pVariantColor, out short pVariantStyle, [Optional][DefaultParameterValue(0)] out short pEmbellishment);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(1610743910)]
	void SetThemeVariant([In] short variantColor, [In] short variantStyle, [In] short embellishment = -1);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(1610743911)]
	void VisualBoundingBox([In] short Flags, out double lpr8Left, out double lpr8Bottom, out double lpr8Right, out double lpr8Top);
}
