using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[Guid("000D0C80-0000-0000-C000-000000000046")]
public enum VisUIObjSets
{
	[TypeLibVar(64)]
	visUIObjSetNoDocument = 1,
	visUIObjSetDrawing = 2,
	visUIObjSetStencil = 3,
	visUIObjSetShapeSheet = 4,
	visUIObjSetIcon = 5,
	visUIObjSetInPlace = 6,
	visUIObjSetPrintPreview = 7,
	[TypeLibVar(64)]
	visUIObjSetText = 8,
	visUIObjSetCntx_DrawObjSel = 9,
	visUIObjSetCntx_DrawOleObjSel = 10,
	[TypeLibVar(64)]
	visUIObjSetCntx_DrawNoObjSel = 11,
	[TypeLibVar(64)]
	visUIObjSetCntx_InPlaceNoObj = 12,
	visUIObjSetCntx_TextEdit = 13,
	[TypeLibVar(64)]
	visUIObjSetCntx_StencilRO = 14,
	visUIObjSetCntx_ShapeSheet = 15,
	[TypeLibVar(64)]
	visUIObjSetCntx_Toolbar = 16,
	visUIObjSetCntx_FullScreen = 17,
	[TypeLibVar(64)]
	visUIObjSetBinderInPlace = 18,
	visUIObjSetActiveXDoc = 18,
	[TypeLibVar(64)]
	visUIObjSetCntx_Debug = 19,
	[TypeLibVar(64)]
	visUIObjSetCntx_StencilRW = 20,
	[TypeLibVar(64)]
	visUIObjSetCntx_StencilDocked = 21,
	visUIObjSetHostingInPlace = 22,
	[TypeLibVar(64)]
	visUIObjSetCntx_Hyperlink = 23,
	visUIObjSetPal_LineColors = 24,
	visUIObjSetPal_LineWeights = 25,
	visUIObjSetPal_LinePatterns = 26,
	visUIObjSetPal_FillColors = 27,
	visUIObjSetPal_FillPatterns = 28,
	visUIObjSetPal_TextColors = 29,
	visUIObjSetPal_AlignShapes = 30,
	visUIObjSetPal_DistributeShapes = 31,
	visUIObjSetPal_Shadow = 32,
	visUIObjSetPal_LineEnds = 33,
	visUIObjSetPal_CornerRounding = 34,
	[TypeLibVar(64)]
	visUIObjSetCntx_ToolbarInPlace = 35,
	[TypeLibVar(64)]
	visUIObjSetCntx_ToolbarHostingInPlace = 36,
	visUIObjSetPal_Rectangle_Tool = 37,
	visUIObjSetPopup_LineJumpCode = 38,
	visUIObjSetPopup_LineJumpStyle = 39,
	visUIObjSetPal_ConnectorTool = 40,
	visUIObjSetPal_TextTool = 41,
	visUIObjSetPal_LineTool = 42,
	visUIObjSetPal_RotationTool = 43,
	visUIObjSetCntx_ConnectPtType = 44,
	[TypeLibVar(64)]
	visUIObjSetPal_Undo = 45,
	[TypeLibVar(64)]
	visUIObjSetPal_Redo = 46,
	visUIObjSetCntx_PageTabs = 47,
	[TypeLibVar(64)]
	visUIObjSetPal_ShapeExt = 48,
	visUIObjSetCntx_DEDocument = 49,
	visUIObjSetCntx_DEPages = 50,
	visUIObjSetCntx_DEPage = 51,
	visUIObjSetCntx_DEShapes = 52,
	visUIObjSetCntx_DEShape = 53,
	visUIObjSetCntx_DELayers = 54,
	visUIObjSetCntx_DELayer = 55,
	visUIObjSetCntx_DEStyles = 56,
	visUIObjSetCntx_DEStyle = 57,
	visUIObjSetCntx_DEMasters = 58,
	visUIObjSetCntx_DEMaster = 59,
	visUIObjSetCntx_DEPatterns = 60,
	visUIObjSetCntx_AnchorBar_Base = 61,
	visUIObjSetCntx_AnchorBar_CustProp = 62,
	visUIObjSetCntx_AnchorBar_SizePos = 63,
	visUIObjSetCntx_Master = 14,
	visUIObjSetCntx_Stencil = 21,
	visUIObjSetCntx_AddCommands = 1000,
	visUIObjSetCntx_BuiltinMenus = 1010,
	[TypeLibVar(64)]
	visUIObjSetCntx_ShortcutMenus = 1011,
	visUIObjSetCntx_MEDocument = 66,
	visUIObjSetCntx_MEMasters = 67,
	visUIObjSetCntx_CommentMarker = 68,
	visUIObjSetCntx_AnchorBar_Shapes = 69,
	visUIObjSetCntx_DataExplorerTabs = 70,
	visUIObjSetCntx_DataExplorerList = 71,
	visUIObjSetCntx_PageTabNavigation = 74,
	visUIObjSetCntx_Page = 75,
	visUIObjSetCntx_Issues = 76
}
