using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[Guid("000D0C07-0000-0000-C000-000000000046")]
public enum VisCellIndices
{
	visCellInval = 255,
	visCellFirst = 0,
	visCellNone = 255,
	visXFormPinX = 0,
	visXFormPinY = 1,
	visXFormWidth = 2,
	visXFormHeight = 3,
	visXFormLocPinX = 4,
	visXFormLocPinY = 5,
	visXFormAngle = 6,
	visXFormFlipX = 7,
	visXFormFlipY = 8,
	visXFormResizeMode = 9,
	visLineWeight = 0,
	visLineColor = 1,
	visLinePattern = 2,
	visLineRounding = 3,
	[TypeLibVar(64)]
	visLineArrowSize = 4,
	visLineEndArrowSize = 4,
	visLineBeginArrow = 5,
	visLineEndArrow = 6,
	visLineEndCap = 7,
	visLineBeginArrowSize = 8,
	visLineColorTrans = 9,
	visCompoundType = 10,
	visFillForegnd = 0,
	visFillBkgnd = 1,
	visFillPattern = 2,
	visFillShdwForegnd = 3,
	visFillShdwBkgnd = 4,
	visFillShdwPattern = 5,
	visFillForegndTrans = 6,
	visFillBkgndTrans = 7,
	visFillShdwForegndTrans = 8,
	visFillShdwBkgndTrans = 9,
	visFillShdwType = 10,
	visFillShdwOffsetX = 11,
	visFillShdwOffsetY = 12,
	visFillShdwObliqueAngle = 13,
	visFillShdwScaleFactor = 14,
	visFillShdwBlur = 15,
	visFillShdwShow = 16,
	vis1DBeginX = 0,
	vis1DBeginY = 1,
	vis1DEndX = 2,
	vis1DEndY = 3,
	[TypeLibVar(64)]
	visEvtCellTheData = 0,
	visEvtCellTheText = 1,
	visEvtCellDblClick = 2,
	visEvtCellXFMod = 3,
	visEvtCellDrop = 4,
	visLayerMember = 0,
	[TypeLibVar(64)]
	visGuideFlags = 2,
	visStyleIncludesLine = 0,
	visStyleIncludesFill = 1,
	visStyleIncludesText = 2,
	visStyleHidden = 3,
	visFrgnImgOffsetX = 0,
	visFrgnImgOffsetY = 1,
	visFrgnImgWidth = 2,
	visFrgnImgHeight = 3,
	visFrgnImgClippingPath = 4,
	visPageWidth = 0,
	visPageHeight = 1,
	visPageShdwOffsetX = 2,
	visPageShdwOffsetY = 3,
	visPageScale = 4,
	visPageDrawingScale = 5,
	visPageDrawSizeType = 6,
	visPageDrawScaleType = 7,
	visPageInhibitSnap = 26,
	visPageLockReplace = 27,
	visPageLockDuplicate = 28,
	visPageUIVisibility = 34,
	visPageShdwType = 35,
	visPageShdwObliqueAngle = 36,
	visPageShdwScaleFactor = 37,
	visPageDrawResizeType = 38,
	visPageZOrderChanged = 39,
	visTxtBlkLeftMargin = 0,
	visTxtBlkRightMargin = 1,
	visTxtBlkTopMargin = 2,
	visTxtBlkBottomMargin = 3,
	visTxtBlkVerticalAlign = 4,
	visTxtBlkBkgnd = 5,
	visTxtBlkDefaultTabStop = 6,
	visTxtBlkDirection = 10,
	visTxtBlkBkgndTrans = 11,
	visAlignLeft = 0,
	visAlignCenter = 1,
	visAlignRight = 2,
	visAlignTop = 3,
	visAlignMiddle = 4,
	visAlignBottom = 5,
	visLockWidth = 0,
	visLockHeight = 1,
	visLockMoveX = 2,
	visLockMoveY = 3,
	visLockAspect = 4,
	visLockDelete = 5,
	visLockBegin = 6,
	visLockEnd = 7,
	visLockRotate = 8,
	visLockCrop = 9,
	visLockVtxEdit = 10,
	visLockTextEdit = 11,
	visLockFormat = 12,
	visLockGroup = 13,
	visLockCalcWH = 14,
	visLockSelect = 15,
	visLockCustProp = 16,
	visObjHelp = 0,
	visCopyright = 1,
	visNoObjHandles = 0,
	visNonPrinting = 1,
	visNoCtlHandles = 2,
	visNoAlignBox = 3,
	visUpdateAlignBox = 4,
	visHideText = 5,
	[TypeLibVar(64)]
	visVerticalText = 6,
	visDynFeedback = 8,
	visGlueType = 9,
	visWalkPref = 10,
	visBegTrigger = 11,
	visEndTrigger = 12,
	visLOFlags = 13,
	[TypeLibVar(64)]
	visLOInteraction = 14,
	[TypeLibVar(64)]
	visLOBehavior = 15,
	visComment = 16,
	visDropSource = 17,
	visNoLiveDynamics = 18,
	visObjLocalizeMerge = 19,
	visObjNoProofing = 20,
	visObjCalendar = 25,
	visObjLangID = 26,
	visObjKeywords = 27,
	visObjDropOnPageScale = 28,
	visObjTheme = 29,
	visObjThemeModern = 30,
	visXRulerDensity = 0,
	visYRulerDensity = 1,
	visXRulerOrigin = 4,
	visYRulerOrigin = 5,
	visXGridDensity = 6,
	visYGridDensity = 7,
	visXGridSpacing = 8,
	visYGridSpacing = 9,
	visXGridOrigin = 10,
	visYGridOrigin = 11,
	visDocOutputFormat = 0,
	visDocLockPreview = 1,
	[TypeLibVar(64)]
	visDocMetric = 2,
	visDocAddMarkup = 3,
	visDocViewMarkup = 4,
	visDocLockReplace = 5,
	visDocNoCoauth = 6,
	visDocLockDuplicatePage = 7,
	visDocPreviewQuality = 9,
	visDocPreviewScope = 10,
	visDocLangID = 19,
	visImageGamma = 0,
	visImageContrast = 1,
	visImageBrightness = 2,
	visImageSharpen = 3,
	visImageBlur = 4,
	visImageDenoise = 5,
	visImageTransparency = 6,
	visGroupSelectMode = 0,
	visGroupDisplayMode = 1,
	visGroupIsDropTarget = 2,
	visGroupIsSnapTarget = 3,
	visGroupIsTextEditTarget = 4,
	visGroupDontMoveChildren = 5,
	visSLOPermX = 0,
	visSLOPermY = 1,
	visSLOPermeablePlace = 2,
	visSLORelationships = 3,
	visSLOFixedCode = 8,
	visSLOPlowCode = 9,
	visSLORouteStyle = 10,
	visSLOPlaceStyle = 11,
	visSLOConFixedCode = 12,
	visSLOJumpCode = 13,
	visSLOJumpStyle = 14,
	visSLOJumpDirX = 16,
	visSLOJumpDirY = 17,
	visSLOPlaceFlip = 18,
	visSLOLineRouteExt = 19,
	visSLOSplit = 20,
	visSLOSplittable = 21,
	visSLODisplayLevel = 22,
	visSLORelChanged = 23,
	visSLOCategoryChanged = 24,
	visPLOResizePage = 0,
	visPLOEnableGrid = 1,
	visPLODynamicsOff = 2,
	visPLOCtrlAsInput = 3,
	visPLOAvoidPageBreaks = 4,
	visPLOPlaceStyle = 8,
	visPLORouteStyle = 9,
	visPLOPlaceDepth = 10,
	visPLOPlowCode = 11,
	visPLOJumpCode = 12,
	visPLOJumpStyle = 13,
	visPLOJumpDirX = 14,
	visPLOJumpDirY = 15,
	visPLOLineToNodeX = 16,
	visPLOLineToNodeY = 17,
	visPLOBlockSizeX = 18,
	visPLOBlockSizeY = 19,
	visPLOAvenueSizeX = 20,
	visPLOAvenueSizeY = 21,
	visPLOLineToLineX = 22,
	visPLOLineToLineY = 23,
	visPLOJumpFactorX = 24,
	visPLOJumpFactorY = 25,
	visPLOLineAdjustFrom = 26,
	visPLOLineAdjustTo = 27,
	visPLOPlaceFlip = 28,
	visPLOLineRouteExt = 29,
	visPLOSplit = 30,
	visCharacterFont = 0,
	visCharacterColor = 1,
	visCharacterStyle = 2,
	visCharacterCase = 3,
	visCharacterPos = 4,
	visCharacterFontScale = 5,
	[TypeLibVar(64)]
	visCharacterLocale = 6,
	visCharacterSize = 7,
	visCharacterDblUnderline = 8,
	visCharacterOverline = 9,
	visCharacterStrikethru = 10,
	[TypeLibVar(64)]
	visCharacterPerpendicular = 12,
	visCharacterDoubleStrikethrough = 13,
	[TypeLibVar(64)]
	visCharacterRTLText = 14,
	[TypeLibVar(64)]
	visCharacterUseVertical = 15,
	visCharacterLetterspace = 16,
	visCharacterColorTrans = 17,
	visCharacterAsianFont = 51,
	visCharacterComplexScriptFont = 52,
	[TypeLibVar(64)]
	visCharacterLocalizeFont = 53,
	visCharacterComplexScriptSize = 54,
	visCharacterLangID = 57,
	visIndentFirst = 0,
	visIndentLeft = 1,
	visIndentRight = 2,
	visSpaceLine = 3,
	visSpaceBefore = 4,
	visSpaceAfter = 5,
	visHorzAlign = 6,
	visBulletIndex = 7,
	visBulletString = 8,
	visBulletFont = 9,
	[TypeLibVar(64)]
	visLocalizeBulletFont = 10,
	visBulletFontSize = 11,
	visTextPosAfterBullet = 12,
	visFlags = 13,
	visTabStopCount = 0,
	visTabPos = 1,
	visTabAlign = 2,
	visScratchX = 0,
	visScratchY = 1,
	visScratchA = 2,
	visScratchB = 3,
	visScratchC = 4,
	visScratchD = 5,
	visCnnctX = 0,
	visCnnctY = 1,
	visCnnctDirX = 2,
	visCnnctDirY = 3,
	visCnnctType = 4,
	visCnnctAutoGen = 5,
	visCnnctA = 2,
	visCnnctB = 3,
	visCnnctC = 4,
	visCnnctD = 5,
	visFieldCell = 0,
	[TypeLibVar(64)]
	visFieldEditMode = 1,
	visFieldFormat = 2,
	visFieldType = 3,
	visFieldUICategory = 4,
	visFieldUICode = 5,
	visFieldUIFormat = 6,
	visFieldCalendar = 7,
	visFieldObjectKind = 10,
	visCtlX = 0,
	visCtlY = 1,
	visCtlXDyn = 2,
	visCtlYDyn = 3,
	visCtlXCon = 4,
	visCtlYCon = 5,
	visCtlGlue = 6,
	[TypeLibVar(64)]
	visCtlType = 7,
	visCtlTip = 8,
	visCompNoFill = 0,
	visCompNoLine = 1,
	visCompNoShow = 2,
	visCompNoSnap = 3,
	visCompPath = 4,
	visCompNoQuickDrag = 5,
	visX = 0,
	visY = 1,
	visBow = 2,
	visInfiniteLineX1 = 0,
	visInfiniteLineY1 = 1,
	visInfiniteLineX2 = 2,
	visInfiniteLineY2 = 3,
	visEllipseCenterX = 0,
	visEllipseCenterY = 1,
	visEllipseMajorX = 2,
	visEllipseMajorY = 3,
	visEllipseMinorX = 4,
	visEllipseMinorY = 5,
	visControlX = 2,
	visControlY = 3,
	visEccentricityAngle = 4,
	visAspectRatio = 5,
	visSplineKnot = 2,
	visSplineKnot2 = 3,
	visSplineKnot3 = 4,
	visSplineDegree = 5,
	visPolylineData = 2,
	visControl1X = 2,
	visControl1Y = 3,
	visControl2X = 4,
	visControl2Y = 5,
	visNURBSKnot = 2,
	visNURBSWeight = 3,
	visNURBSKnotPrev = 4,
	visNURBSWeightPrev = 5,
	visNURBSData = 6,
	visActionMenu = 0,
	[TypeLibVar(64)]
	visActionPrompt = 1,
	[TypeLibVar(64)]
	visActionHelp = 2,
	visActionAction = 3,
	visActionChecked = 4,
	visActionDisabled = 5,
	visActionReadOnly = 6,
	visActionInvisible = 7,
	visActionBeginGroup = 8,
	visActionFlyoutChild = 9,
	visActionTagName = 14,
	visActionButtonFace = 15,
	visActionSortKey = 16,
	visLayerName = 0,
	visLayerColor = 2,
	visLayerStatus = 3,
	visLayerVisible = 4,
	visLayerPrint = 5,
	visLayerActive = 6,
	visLayerLock = 7,
	visLayerSnap = 8,
	visLayerGlue = 9,
	visLayerNameUniv = 10,
	visLayerColorTrans = 11,
	visUserValue = 0,
	visUserPrompt = 1,
	visCustPropsValue = 0,
	visCustPropsPrompt = 1,
	visCustPropsLabel = 2,
	visCustPropsFormat = 3,
	visCustPropsSortKey = 4,
	visCustPropsType = 5,
	visCustPropsInvis = 6,
	visCustPropsAsk = 7,
	visCustPropsDataLinked = 8,
	visCustPropsLangID = 14,
	visCustPropsCalendar = 15,
	visHLinkDescription = 0,
	visHLinkAddress = 1,
	visHLinkSubAddress = 2,
	visHLinkExtraInfo = 3,
	visHLinkFrame = 4,
	visHLinkNewWin = 5,
	visHLinkDefault = 7,
	visHLinkInvisible = 8,
	visHLinkSortKey = 15,
	visReviewerName = 0,
	visReviewerInitials = 1,
	visReviewerColor = 2,
	visReviewerReviewerID = 3,
	visReviewerCurrentIndex = 4,
	visAnnotationX = 0,
	visAnnotationY = 1,
	visAnnotationReviewerID = 2,
	visAnnotationMarkerIndex = 3,
	visAnnotationDate = 4,
	visAnnotationComment = 5,
	visAnnotationLangID = 6,
	visSmartTagX = 0,
	visSmartTagY = 1,
	visSmartTagName = 2,
	visSmartTagXJustify = 3,
	visSmartTagYJustify = 4,
	visSmartTagDisplayMode = 5,
	visSmartTagButtonFace = 6,
	visSmartTagDisabled = 7,
	visSmartTagDescription = 15,
	visPrintPropertiesLeftMargin = 0,
	visPrintPropertiesRightMargin = 1,
	visPrintPropertiesTopMargin = 2,
	visPrintPropertiesBottomMargin = 3,
	visPrintPropertiesScaleX = 4,
	visPrintPropertiesScaleY = 5,
	visPrintPropertiesPagesX = 6,
	visPrintPropertiesPagesY = 7,
	visPrintPropertiesCenterX = 8,
	visPrintPropertiesCenterY = 9,
	visPrintPropertiesOnPage = 10,
	visPrintPropertiesPrintGrid = 11,
	visPrintPropertiesPageOrientation = 16,
	visPrintPropertiesPaperKind = 17,
	visPrintPropertiesPaperSource = 18,
	visLockFromGroupFormat = 17,
	visLockThemeColors = 18,
	visLockThemeEffects = 19,
	visLockThemeConnectors = 20,
	visLockThemeFonts = 21,
	visLockThemeIndex = 22,
	visLockReplace = 23,
	visLockVariation = 24,
	visEvtCellMultiDrop = 22,
	visLineGradientDir = 0,
	visLineGradientAngle = 1,
	visFillGradientDir = 2,
	visFillGradientAngle = 3,
	visLineGradientEnabled = 4,
	visFillGradientEnabled = 5,
	visRotateGradientWithShape = 6,
	visUseGroupGradient = 7,
	visQuickStyleLineColor = 0,
	visQuickStyleFillColor = 1,
	visQuickStyleShadowColor = 2,
	visQuickStyleFontColor = 3,
	visQuickStyleLineMatrix = 4,
	visQuickStyleFillMatrix = 5,
	visQuickStyleEffectsMatrix = 6,
	visQuickStyleFontMatrix = 7,
	visQuickStyleType = 8,
	visQuickStyleVariation = 9,
	visReflectionTrans = 0,
	visReflectionSize = 1,
	visReflectionDist = 2,
	visReflectionBlur = 3,
	visGlowColor = 4,
	visGlowColorTrans = 5,
	visGlowSize = 6,
	visSoftEdgesSize = 7,
	visSketchSeed = 8,
	visSketchEnabled = 9,
	visSketchAmount = 10,
	visSketchLineWeight = 11,
	visSketchLineChange = 12,
	visSketchFillChange = 13,
	visBevelTopType = 0,
	visBevelTopWidth = 1,
	visBevelTopHeight = 2,
	visBevelBottomType = 3,
	visBevelBottomWidth = 4,
	visBevelBottomHeight = 5,
	visBevelDepthColor = 6,
	visBevelDepthSize = 7,
	visBevelContourColor = 8,
	visBevelContourSize = 9,
	visBevelMaterialType = 10,
	visBevelLightingType = 11,
	visBevelLightingAngle = 12,
	visRotationXAngle = 0,
	visRotationYAngle = 1,
	visRotationZAngle = 2,
	visRotationType = 3,
	visPerspective = 4,
	visDistanceFromGround = 5,
	visKeepTextFlat = 6,
	visGradientStopColor = 0,
	visGradientStopColorTrans = 1,
	visGradientStopPosition = 2,
	visColorSchemeIndex = 0,
	visEffectSchemeIndex = 1,
	visConnectorSchemeIndex = 2,
	visFontSchemeIndex = 3,
	visThemeIndex = 4,
	visVariationColorIndex = 5,
	visVariationStyleIndex = 6,
	visEmbellishmentIndex = 7,
	visReplaceLockShapeData = 0,
	visReplaceLockText = 1,
	visReplaceLockFormat = 2,
	visReplaceCopyCells = 3
}
