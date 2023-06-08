using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[Guid("000D0C08-0000-0000-C000-000000000046")]
public enum VisCellVals
{
	visXFormResizeDontCare = 0,
	visXFormResizeSpread = 1,
	visXFormResizeScale = 2,
	visArrowSizeVerySmall = 0,
	visArrowSizeSmall = 1,
	visArrowSizeMedium = 2,
	visArrowSizeLarge = 3,
	visArrowSizeVeryLarge = 4,
	visArrowSizeJumbo = 5,
	visArrowSizeColossal = 6,
	visNoFill = 0,
	visSolid = 1,
	visWideUpDiagonal = 2,
	visWideCross = 3,
	visWideDiagonalCross = 4,
	visWideDownDiagonal = 5,
	visWideHorz = 6,
	visWideVert = 7,
	visBackDotsMini = 8,
	visHalfAndHalf = 9,
	visForeDotsMini = 10,
	visForeDotsNarrow = 11,
	visForeDotsWide = 12,
	visThickHorz = 13,
	visThickVertical = 14,
	visThickDownDiagonal = 15,
	visThickUpDiagonal = 16,
	visThickDiagonalCross = 17,
	visBackDotsWide = 18,
	visThinHorz = 19,
	visThinVert = 20,
	visThinDownDiagonal = 21,
	visThinUpDiagonal = 22,
	visThinCross = 23,
	visThinDiagonalCross = 24,
	[TypeLibVar(64)]
	visGuideXActive = 1024,
	[TypeLibVar(64)]
	visGuideYActive = 2048,
	visPrintSetup = 0,
	visTight = 1,
	visStandard = 2,
	visCustom = 3,
	visLogical = 4,
	visDSMetric = 5,
	visDSEngr = 6,
	visDSArch = 7,
	visNoScale = 0,
	visArchitectural = 1,
	visEngineering = 2,
	visScaleCustom = 3,
	visScaleMetric = 4,
	visScaleMechanical = 5,
	visVertTop = 0,
	visVertMiddle = 1,
	visVertBottom = 2,
	visTxtBlkOpaque = 255,
	visTxtBlkLeftToRight = 0,
	visTxtBlkTopToBottom = 1,
	visDynFBDefault = 0,
	visDynFBUCon3Leg = 1,
	visDynFBUCon5Leg = 2,
	visGlueTypeDefault = 0,
	[TypeLibVar(64)]
	visGlueTypeTrigger = 1,
	visGlueTypeWalking = 2,
	visGlueTypeNoWalking = 4,
	visGlueTypeNoWalkingTo = 8,
	visWalkPrefBegNS = 1,
	visWalkPrefEndNS = 2,
	visLOFlagsVisDecides = 0,
	visLOFlagsPlacable = 1,
	visLOFlagsRoutable = 2,
	visLOFlagsDont = 4,
	visLOFlagsPNRGroup = 8,
	[TypeLibVar(64)]
	visLOIPlaceNormal = 0,
	[TypeLibVar(64)]
	visLOIPlaceXPermeable = 2,
	[TypeLibVar(64)]
	visLOIPlaceYPermeable = 4,
	[TypeLibVar(64)]
	visLOIRouteNormal = 0,
	[TypeLibVar(64)]
	visLOBPlaceNormal = 0,
	[TypeLibVar(64)]
	visLOBRouteNormal = 0,
	[TypeLibVar(64)]
	visLOBRouteRightAng = 1,
	[TypeLibVar(64)]
	visLOBRouteStraight = 2,
	[TypeLibVar(64)]
	visLOBRouteFlowNS = 5,
	[TypeLibVar(64)]
	visLOBRouteFlowWE = 6,
	[TypeLibVar(64)]
	visLOBRouteTreeNS = 7,
	[TypeLibVar(64)]
	visLOBRouteTreeWE = 8,
	[TypeLibVar(64)]
	visLOBRouteManual = 1024,
	visRulerFine = 32,
	visRulerNormal = 16,
	visRulerCoarse = 8,
	visRulerFixed = 0,
	visGridFine = 8,
	visGridNormal = 4,
	visGridCoarse = 2,
	visGridFixed = 0,
	visDocPreviewQualityDraft = 0,
	visDocPreviewQualityDetailed = 1,
	visDocPreviewScope1stPage = 0,
	visDocPreviewScopeNone = 1,
	[TypeLibVar(64)]
	visDocPreviewScopeAllPages = 2,
	visPPOSameAsPrinter = 0,
	visPPOPortrait = 1,
	visPPOLandscape = 2,
	visGrpSelModeGroupOnly = 0,
	visGrpSelModeGroup1st = 1,
	visGrpSelModeMembers1st = 2,
	visGrpDispModeNone = 0,
	visGrpDispModeBack = 1,
	visGrpDispModeFront = 2,
	visLORouteDefault = 0,
	visLORouteRightAngle = 1,
	visLORouteStraight = 2,
	visLORouteOrgChartNS = 3,
	visLORouteOrgChartWE = 4,
	visLORouteFlowchartNS = 5,
	visLORouteFlowchartWE = 6,
	visLORouteTreeNS = 7,
	visLORouteTreeWE = 8,
	visLORouteNetwork = 9,
	visLORouteOrgChartSN = 10,
	visLORouteOrgChartEW = 11,
	visLORouteFlowchartSN = 12,
	visLORouteFlowchartEW = 13,
	visLORouteTreeSN = 14,
	visLORouteTreeEW = 15,
	visLORouteCenterToCenter = 16,
	visLORouteSimpleNS = 17,
	visLORouteSimpleWE = 18,
	visLORouteSimpleSN = 19,
	visLORouteSimpleEW = 20,
	visLORouteSimpleHV = 21,
	visLORouteSimpleVH = 22,
	visLOJumpStyleDefault = 0,
	visLOJumpStyleArc = 1,
	visLOJumpStyleGap = 2,
	visLOJumpStyleSquare = 3,
	visLOJumpStyleTriangle = 4,
	visLOJumpStyle2Point = 5,
	visLOJumpStyle3Point = 6,
	visLOJumpStyle4Point = 7,
	visLOJumpStyle5Point = 8,
	visLOJumpStyle6Point = 9,
	visLOJumpDirXDefault = 0,
	visLOJumpDirXUp = 1,
	visLOJumpDirXDown = 2,
	visLOJumpDirYDefault = 0,
	visLOJumpDirYLeft = 1,
	visLOJumpDirYRight = 2,
	visLOFlipDefault = 0,
	visLOFlipX = 1,
	visLOFlipY = 2,
	visLOFlipRotate = 4,
	visLOFlipNone = 8,
	visLORouteExtDefault = 0,
	visLORouteExtStraight = 1,
	visLORouteExtNURBS = 2,
	visSLOFixedPlacement = 1,
	visSLOFixedPlow = 2,
	visSLOFixedPermeablePlow = 4,
	visSLOFixedConnPtsIgnore = 32,
	visSLOFixedConnPtsOnly = 64,
	visSLOFixedNoFoldToShape = 128,
	visSLOPlowDefault = 0,
	visSLOPlowNever = 1,
	visSLOPlowAlways = 2,
	visSLOConFixedRerouteFreely = 0,
	visSLOConFixedRerouteAsNeeded = 1,
	visSLOConFixedRerouteNever = 2,
	visSLOConFixedRerouteOnCrossover = 3,
	[TypeLibVar(64)]
	visSLOConFixedByAlgFrom = 4,
	[TypeLibVar(64)]
	visSLOConFixedByAlgTo = 5,
	[TypeLibVar(64)]
	visSLOConFixedByAlgFromTo = 6,
	visSLOJumpDefault = 0,
	visSLOJumpNever = 1,
	visSLOJumpAlways = 2,
	visSLOJumpOther = 3,
	visSLOJumpNeither = 4,
	visPLOPlaceDefault = 0,
	visPLOPlaceTopToBottom = 1,
	visPLOPlaceLeftToRight = 2,
	visPLOPlaceRadial = 3,
	visPLOPlaceBottomToTop = 4,
	visPLOPlaceRightToLeft = 5,
	visPLOPlaceCircular = 6,
	visPLOPlaceCompactDownRight = 7,
	visPLOPlaceCompactRightDown = 8,
	visPLOPlaceCompactRightUp = 9,
	visPLOPlaceCompactUpRight = 10,
	visPLOPlaceCompactUpLeft = 11,
	visPLOPlaceCompactLeftUp = 12,
	visPLOPlaceCompactLeftDown = 13,
	visPLOPlaceCompactDownLeft = 14,
	visPLOPlaceParentDefault = 15,
	visPLOPlaceHierarchyTopToBottomLeft = 16,
	visPLOPlaceHierarchyTopToBottomCenter = 17,
	visPLOPlaceHierarchyTopToBottomRight = 18,
	visPLOPlaceHierarchyBottomToTopLeft = 19,
	visPLOPlaceHierarchyBottomToTopCenter = 20,
	visPLOPlaceHierarchyBottomToTopRight = 21,
	visPLOPlaceHierarchyLeftToRightTop = 22,
	visPLOPlaceHierarchyLeftToRightMiddle = 23,
	visPLOPlaceHierarchyLeftToRightBottom = 24,
	visPLOPlaceHierarchyRightToLeftTop = 25,
	visPLOPlaceHierarchyRightToLeftMiddle = 26,
	visPLOPlaceHierarchyRightToLeftBottom = 27,
	visLOPlaceDefault = 0,
	visLOPlaceTopToBottom = 1,
	visLOPlaceLeftToRight = 2,
	visLOPlaceRadial = 3,
	visLOPlaceBottomToTop = 4,
	visLOPlaceRightToLeft = 5,
	visLOPlaceCircular = 6,
	visLOPlaceCompactDownRight = 7,
	visLOPlaceCompactRightDown = 8,
	visLOPlaceCompactRightUp = 9,
	visLOPlaceCompactUpRight = 10,
	visLOPlaceCompactUpLeft = 11,
	visLOPlaceCompactLeftUp = 12,
	visLOPlaceCompactLeftDown = 13,
	visLOPlaceCompactDownLeft = 14,
	visLOPlaceParentDefault = 15,
	visLOPlaceHierarchyTopToBottomLeft = 16,
	visLOPlaceHierarchyTopToBottomCenter = 17,
	visLOPlaceHierarchyTopToBottomRight = 18,
	visLOPlaceHierarchyBottomToTopLeft = 19,
	visLOPlaceHierarchyBottomToTopCenter = 20,
	visLOPlaceHierarchyBottomToTopRight = 21,
	visLOPlaceHierarchyLeftToRightTop = 22,
	visLOPlaceHierarchyLeftToRightMiddle = 23,
	visLOPlaceHierarchyLeftToRightBottom = 24,
	visLOPlaceHierarchyRightToLeftTop = 25,
	visLOPlaceHierarchyRightToLeftMiddle = 26,
	visLOPlaceHierarchyRightToLeftBottom = 27,
	visPLOPlaceDepthDefault = 0,
	visPLOPlaceDepthMedium = 1,
	visPLOPlaceDepthDeep = 2,
	visPLOPlaceDepthShallow = 3,
	visPLOPlowNone = 0,
	visPLOPlowAll = 1,
	visPLOJumpNone = 0,
	visPLOJumpHorizontal = 1,
	visPLOJumpVertical = 2,
	visPLOJumpLastRouted = 3,
	visPLOJumpDisplayOrder = 4,
	visPLOJumpReverseDisplayOrder = 5,
	visPLOJumpProhibitAll = 6,
	visPLOLineAdjustFromNotRelated = 0,
	visPLOLineAdjustFromAll = 1,
	visPLOLineAdjustFromNone = 2,
	visPLOLineAdjustFromRoutingDefault = 3,
	visPLOLineAdjustToDefault = 0,
	visPLOLineAdjustToAll = 1,
	visPLOLineAdjustToNone = 2,
	visPLOLineAdjustToRelated = 3,
	visBold = 1,
	visItalic = 2,
	visUnderLine = 4,
	visSmallCaps = 8,
	visComplexBold = 16,
	visComplexItalic = 32,
	visCaseNormal = 0,
	visCaseAllCaps = 1,
	visCaseInitialCaps = 2,
	visPosNormal = 0,
	visPosSuper = 1,
	visPosSub = 2,
	visHorzLeft = 0,
	visHorzCenter = 1,
	visHorzRight = 2,
	visHorzJustify = 3,
	[TypeLibVar(64)]
	visHorzForce = 4,
	visHorzDistribute = 4,
	visHorzJustifyLow = 5,
	visHorzJustifyMedium = 6,
	visHorzJustifyHigh = 7,
	visTabStopLeft = 0,
	visTabStopCenter = 1,
	visTabStopRight = 2,
	visTabStopDecimal = 3,
	visTabStopComma = 4,
	visCnnctTypeInward = 0,
	visCnnctTypeOutward = 1,
	visCnnctTypeInwardOutward = 2,
	visCtlProportional = 0,
	visCtlLocked = 1,
	visCtlOffsetMin = 2,
	visCtlOffsetMid = 3,
	visCtlOffsetMax = 4,
	visCtlProportionalHidden = 5,
	visCtlLockedHidden = 6,
	visCtlOffsetMinHidden = 7,
	visCtlOffsetMidHidden = 8,
	visCtlOffsetMaxHidden = 9,
	visNoLayerColor = 255,
	visLayerValid = 0,
	visLayerDeleted = 1,
	visLayerAvailable = 2,
	visPropTypeString = 0,
	visPropTypeListFix = 1,
	visPropTypeNumber = 2,
	visPropTypeBool = 3,
	visPropTypeListVar = 4,
	visPropTypeDate = 5,
	visPropTypeDuration = 6,
	visPropTypeCurrency = 7,
	visCalWestern = 0,
	visCalArabicHijri = 1,
	visCalHebrewLunar = 2,
	visCalChineseTaiwan = 3,
	visCalJapaneseEmperor = 4,
	[TypeLibVar(64)]
	visCalThaiBuddhism = 5,
	visCalThaiBuddhist = 5,
	visCalKoreanDanki = 6,
	visCalSakaEra = 7,
	visCalTranslitEnglish = 8,
	visCalTranslitFrench = 9,
	visPLOSplitNone = 0,
	visPLOSplitAllow = 1,
	visSLOSplitNone = 0,
	visSLOSplitAllow = 1,
	visSLOSplittableNone = 0,
	visSLOSplittableAllow = 1,
	visFSTPageDefault = 0,
	visFSTSimple = 1,
	visFSTOblique = 2,
	visUIVNormal = 0,
	visUIVHidden = 1,
	visLocFontIfArialOrSym = 0,
	visLocFontAlways = 1,
	visLocFontNever = 2,
	visSmartTagXJustifyLeft = 0,
	visSmartTagXJustifyCenter = 1,
	visSmartTagXJustifyRight = 2,
	visSmartTagYJustifyTop = 0,
	visSmartTagYJustifyMiddle = 1,
	visSmartTagYJustifyBottom = 2,
	visSmartTagDispModeMouseOver = 0,
	visSmartTagDispModeShapeSelected = 1,
	visSmartTagDispModeAlways = 2,
	visTFOKStandard = 0,
	visTFOKHorizontalInVertical = 1,
	visPPFlagsRTLText = 1
}
