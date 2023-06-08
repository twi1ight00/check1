using System;
using Aspose.Words.Drawing;
using x011d489fb9df7027;
using x1a62aaf14e3c5909;
using x556d8f9846e43329;
using x5794c252ba25e723;
using x6c95d9cf46ff5f25;
using xf989f31a236ff98c;

namespace x639ad3f66698fe1b;

internal class x5fbed40a77205d71
{
	private readonly x21f0d20d41203be1 x8cedcaa9a62c6e39;

	private bool x610d1a116fd8c9bd;

	private bool x625b9038331e382d;

	private bool x39356f2583b8c713;

	internal static bool x492f529cee830a40;

	private xbfd162a6d47f59a4 xe1410f585439c7d4 => x8cedcaa9a62c6e39.xe1410f585439c7d4;

	internal x5fbed40a77205d71(x21f0d20d41203be1 context)
	{
		x8cedcaa9a62c6e39 = context;
	}

	internal void x409f6d17d51b0ce0(ShapeBase x5770cdefd8931aa9)
	{
		x610d1a116fd8c9bd = true;
		x6210059f049f0d48(x5770cdefd8931aa9);
		x610d1a116fd8c9bd = false;
	}

	internal void x6210059f049f0d48(ShapeBase x5770cdefd8931aa9)
	{
		x6210059f049f0d48(x5770cdefd8931aa9, xa551490e89134536: false);
	}

	internal void x6210059f049f0d48(ShapeBase x5770cdefd8931aa9, bool xa551490e89134536)
	{
		x39356f2583b8c713 = true;
		x4ca9f3d85457b9b9(x5770cdefd8931aa9, xa551490e89134536);
		x625b9038331e382d = x5770cdefd8931aa9.xac9731dd322f2036;
		xf7125312c7ee115c xf7125312c7ee115c = x5770cdefd8931aa9.xf7125312c7ee115c;
		for (int i = 0; i < xf7125312c7ee115c.xd44988f225497f3a; i++)
		{
			int num = xf7125312c7ee115c.xf15263674eb297bb(i);
			object obj = xf7125312c7ee115c.x6d3720b962bd3112(i);
			switch (num)
			{
			case 924:
				xac1588bced6f81bf("borderLeftColor", (x26d9ecb4bdf0456d)obj);
				break;
			case 926:
				xac1588bced6f81bf("borderRightColor", (x26d9ecb4bdf0456d)obj);
				break;
			case 923:
				xac1588bced6f81bf("borderTopColor", (x26d9ecb4bdf0456d)obj);
				break;
			case 925:
				xac1588bced6f81bf("borderBottomColor", (x26d9ecb4bdf0456d)obj);
				break;
			case 912:
				if (x5770cdefd8931aa9.IsTopLevel)
				{
					xac1588bced6f81bf("posrelh", Convert.ToInt32(obj));
				}
				break;
			case 914:
				if (x5770cdefd8931aa9.IsTopLevel)
				{
					xac1588bced6f81bf("posrelv", Convert.ToInt32(obj));
				}
				break;
			case 911:
				if (x5770cdefd8931aa9.IsTopLevel)
				{
					xac1588bced6f81bf("posh", Convert.ToInt32(obj));
				}
				break;
			case 913:
				if (x5770cdefd8931aa9.IsTopLevel)
				{
					xac1588bced6f81bf("posv", Convert.ToInt32(obj));
				}
				break;
			case 950:
				if (x5770cdefd8931aa9.IsTopLevel)
				{
					xac1588bced6f81bf("fAllowOverlap", (bool)obj);
				}
				break;
			case 1984:
				xac1588bced6f81bf("pctHoriz", (int)obj);
				break;
			case 1985:
				xac1588bced6f81bf("pctVert", (int)obj);
				break;
			case 1986:
				xac1588bced6f81bf("pctHorizPos", (int)obj);
				break;
			case 1987:
				xac1588bced6f81bf("pctVertPos", (int)obj);
				break;
			case 1988:
				xac1588bced6f81bf("sizerelh", Convert.ToInt32(obj));
				break;
			case 1989:
				xac1588bced6f81bf("sizerelv", Convert.ToInt32(obj));
				break;
			case 945:
				xac1588bced6f81bf("fIsBullet", (bool)obj);
				break;
			case 4:
				xac1588bced6f81bf("rotation", (int)obj);
				break;
			case 4096:
				xb392b51383ce6e9f((FlipOrientation)obj, x5770cdefd8931aa9.IsTopLevel);
				break;
			case 896:
				xac1588bced6f81bf("wzName", (string)obj);
				break;
			case 897:
				xac1588bced6f81bf("wzDescription", (string)obj);
				break;
			case 900:
				if (x5770cdefd8931aa9.IsTopLevel)
				{
					xac1588bced6f81bf("dxWrapDistLeft", (int)obj);
				}
				break;
			case 902:
				if (x5770cdefd8931aa9.IsTopLevel)
				{
					xac1588bced6f81bf("dxWrapDistRight", (int)obj);
				}
				break;
			case 901:
				if (x5770cdefd8931aa9.IsTopLevel)
				{
					xac1588bced6f81bf("dyWrapDistTop", (int)obj);
				}
				break;
			case 903:
				if (x5770cdefd8931aa9.IsTopLevel)
				{
					xac1588bced6f81bf("dyWrapDistBottom", (int)obj);
				}
				break;
			case 954:
				if (x5770cdefd8931aa9.IsTopLevel)
				{
					xac1588bced6f81bf("fBehindDocument", (bool)obj);
				}
				break;
			case 956:
				xac1588bced6f81bf("fIsButton", (bool)obj);
				break;
			case 958:
				xac1588bced6f81bf("fHidden", (bool)obj);
				break;
			case 507:
				xac1588bced6f81bf("fArrowheadsOK", (bool)obj);
				break;
			case 830:
				xac1588bced6f81bf("fDeleteAttachedObject", (bool)obj);
				break;
			case 953:
				xac1588bced6f81bf("fEditedWrap", (bool)obj);
				break;
			case 444:
				xac1588bced6f81bf("fHitTestFill", (bool)obj);
				break;
			case 509:
				xac1588bced6f81bf("fHitTestLine", (bool)obj);
				break;
			case 447:
				xac1588bced6f81bf("fNoFillHitTest", (bool)obj);
				break;
			case 511:
				xac1588bced6f81bf("fNoLineDrawDash", (bool)obj);
				break;
			case 826:
				xac1588bced6f81bf("fOleIcon", (bool)obj);
				break;
			case 955:
				xac1588bced6f81bf("fOnDblClickNotify", (bool)obj);
				break;
			case 957:
				xac1588bced6f81bf("fOneD", (bool)obj);
				break;
			case 827:
				xac1588bced6f81bf("fPreferRelativeResize", (bool)obj);
				break;
			case 959:
				xac1588bced6f81bf("fPrint", (bool)obj);
				break;
			case 952:
				xac1588bced6f81bf("fScriptAnchor", (bool)obj);
				break;
			case 910:
				xac1588bced6f81bf("wzScript", (string)obj);
				break;
			case 919:
				xac1588bced6f81bf("wzScriptExtAttr", (string)obj);
				break;
			case 920:
				xac1588bced6f81bf("scriptLang", (int)obj);
				break;
			case 922:
				xac1588bced6f81bf("wzScriptLangAttr", (string)obj);
				break;
			case 138:
				xac1588bced6f81bf("hspNext", (int)obj);
				break;
			case 119:
				x8d0b1bbfa5da914b("fLockRotation", (bool)obj);
				break;
			case 121:
				x8d0b1bbfa5da914b("fLockPosition", (bool)obj);
				break;
			case 120:
				x8d0b1bbfa5da914b("fLockAspectRatio", (bool)obj);
				break;
			case 122:
				x8d0b1bbfa5da914b("fLockAgainstSelect", (bool)obj);
				break;
			case 123:
				x8d0b1bbfa5da914b("fLockCropping", (bool)obj);
				break;
			case 124:
				x8d0b1bbfa5da914b("fLockVerticies", (bool)obj);
				break;
			case 125:
				x8d0b1bbfa5da914b("fLockText", (bool)obj);
				break;
			case 126:
				x8d0b1bbfa5da914b("fLockAdjustHandles", (bool)obj);
				break;
			case 127:
				x8d0b1bbfa5da914b("fLockAgainstGrouping", (bool)obj);
				break;
			case 828:
				x8d0b1bbfa5da914b("fLockShapeType", (bool)obj);
				break;
			case 129:
				xac1588bced6f81bf("dxTextLeft", (int)obj);
				break;
			case 131:
				xac1588bced6f81bf("dxTextRight", (int)obj);
				break;
			case 130:
				xac1588bced6f81bf("dyTextTop", (int)obj);
				break;
			case 132:
				xac1588bced6f81bf("dyTextBottom", (int)obj);
				break;
			case 133:
				xac1588bced6f81bf("WrapText", Convert.ToInt32(obj));
				break;
			case 135:
				xac1588bced6f81bf("anchorText", Convert.ToInt32(obj));
				break;
			case 136:
				xac1588bced6f81bf("txflTextFlow", Convert.ToInt32(obj));
				break;
			case 137:
				xac1588bced6f81bf("cdirFont", Convert.ToInt32(obj));
				break;
			case 188:
				xac1588bced6f81bf("fAutoTextMargin", (bool)obj);
				break;
			case 134:
				xac1588bced6f81bf("scaleText", (int)obj);
				break;
			case 128:
				xac1588bced6f81bf("lTxid", (int)obj);
				break;
			case 189:
				xac1588bced6f81bf("fRotateText", (bool)obj);
				break;
			case 187:
				xac1588bced6f81bf("fSelectText", (bool)obj);
				break;
			case 190:
				xac1588bced6f81bf("fFitShapeToText", (bool)obj);
				break;
			case 191:
				xac1588bced6f81bf("fFitTextToShape", (bool)obj);
				break;
			case 192:
				xac1588bced6f81bf("gtextUNICODE", (string)obj);
				break;
			case 195:
				xac1588bced6f81bf("gtextSize", (int)obj);
				break;
			case 196:
				xac1588bced6f81bf("gtextSpacing", (int)obj);
				break;
			case 197:
				xac1588bced6f81bf("gtextFont", (string)obj);
				break;
			case 241:
				xac1588bced6f81bf("fGtext", (bool)obj);
				break;
			case 242:
				xac1588bced6f81bf("gtextFVertical", (bool)obj);
				break;
			case 243:
				xac1588bced6f81bf("gtextFKern", (bool)obj);
				break;
			case 244:
				xac1588bced6f81bf("gtextFTight", (bool)obj);
				break;
			case 245:
				xac1588bced6f81bf("gtextFStretch", (bool)obj);
				break;
			case 246:
				xac1588bced6f81bf("gtextFShrinkFit", (bool)obj);
				break;
			case 247:
				xac1588bced6f81bf("gtextFBestFit", (bool)obj);
				break;
			case 248:
				xac1588bced6f81bf("gtextFNormalize", (bool)obj);
				break;
			case 249:
				xac1588bced6f81bf("gtextFDxMeasure", (bool)obj);
				break;
			case 250:
				xac1588bced6f81bf("gtextFBold", (bool)obj);
				break;
			case 251:
				xac1588bced6f81bf("gtextFItalic", (bool)obj);
				break;
			case 252:
				xac1588bced6f81bf("gtextFUnderline", (bool)obj);
				break;
			case 253:
				xac1588bced6f81bf("gtextFShadow", (bool)obj);
				break;
			case 254:
				xac1588bced6f81bf("gtextFSmallcaps", (bool)obj);
				break;
			case 255:
				xac1588bced6f81bf("gtextFStrikethrough", (bool)obj);
				break;
			case 240:
				xac1588bced6f81bf("gtextFReverseRows", (bool)obj);
				break;
			case 193:
				xac1588bced6f81bf("gtextRTF", (bool)obj);
				break;
			case 325:
				xac1588bced6f81bf("shapePath", 4);
				xe5c97d2d0daa8b43("pVerticies", (x08d932077485c285[])obj);
				break;
			case 326:
				x431a88a390b2c434((x44f2b8bf33b16275[])obj);
				break;
			case 344:
				xac1588bced6f81bf("cxk", Convert.ToInt32(obj));
				break;
			case 337:
				xe5c97d2d0daa8b43("pConnectionSites", (x08d932077485c285[])obj);
				break;
			case 341:
				x7cac727ef7c00771((x7efbe0a2dc0d335f[])obj);
				break;
			case 342:
				xf7b167486e3ffbc1((x40937ad35b1cf5f7[])obj);
				break;
			case 343:
				xc059ae6d9116afde((xbc9979937c838d75[])obj);
				break;
			case 327:
				xac1588bced6f81bf("adjustValue", (int)obj);
				break;
			case 328:
				xac1588bced6f81bf("adjust2Value", (int)obj);
				break;
			case 329:
				xac1588bced6f81bf("adjust3Value", (int)obj);
				break;
			case 330:
				xac1588bced6f81bf("adjust4Value", (int)obj);
				break;
			case 331:
				xac1588bced6f81bf("adjust5Value", (int)obj);
				break;
			case 332:
				xac1588bced6f81bf("adjust6Value", (int)obj);
				break;
			case 333:
				xac1588bced6f81bf("adjust7Value", (int)obj);
				break;
			case 334:
				xac1588bced6f81bf("adjust8Value", (int)obj);
				break;
			case 335:
				xac1588bced6f81bf("adjust9Value", (int)obj);
				break;
			case 336:
				xac1588bced6f81bf("adjust10Value", (int)obj);
				break;
			case 381:
				xac1588bced6f81bf("fGtextOK", (bool)obj);
				break;
			case 383:
				xac1588bced6f81bf("fFillOK", (bool)obj);
				break;
			case 382:
				xac1588bced6f81bf("fFillShadeShapeOK", (bool)obj);
				break;
			case 380:
				xac1588bced6f81bf("fLineOK", (bool)obj);
				break;
			case 378:
				xac1588bced6f81bf("fShadowOK", (bool)obj);
				break;
			case 379:
				xac1588bced6f81bf("f3DOK", (bool)obj);
				break;
			case 339:
				xac1588bced6f81bf("xLimo", (int)obj);
				break;
			case 340:
				xac1588bced6f81bf("yLimo", (int)obj);
				break;
			case 904:
				xac1588bced6f81bf("lidRegroup", (int)obj);
				break;
			case 258:
				xac1588bced6f81bf("cropFromLeft", (int)obj);
				break;
			case 259:
				xac1588bced6f81bf("cropFromRight", (int)obj);
				break;
			case 256:
				xac1588bced6f81bf("cropFromTop", (int)obj);
				break;
			case 257:
				xac1588bced6f81bf("cropFromBottom", (int)obj);
				break;
			case 263:
				xac1588bced6f81bf("pictureTransparent", (x26d9ecb4bdf0456d)obj);
				break;
			case 264:
				xac1588bced6f81bf("pictureContrast", (int)obj);
				break;
			case 265:
				xac1588bced6f81bf("pictureBrightness", (int)obj);
				break;
			case 266:
				xac1588bced6f81bf("pictureGamma", (int)obj);
				break;
			case 317:
				xac1588bced6f81bf("pictureGray", (bool)obj);
				break;
			case 318:
				xac1588bced6f81bf("pictureBiLevel", (bool)obj);
				break;
			case 319:
				xac1588bced6f81bf("pictureActive", (bool)obj);
				break;
			case 268:
				xac1588bced6f81bf("pictureDblCrMod", (int)obj);
				break;
			case 269:
				xac1588bced6f81bf("pictureFillCrMod", (int)obj);
				break;
			case 267:
				xac1588bced6f81bf("pictureId", (int)obj);
				break;
			case 270:
				xac1588bced6f81bf("pictureLineCrMod", (int)obj);
				break;
			case 384:
				xac1588bced6f81bf("fillType", Convert.ToInt32(obj));
				break;
			case 385:
			{
				x26d9ecb4bdf0456d x26d9ecb4bdf0456d = (x26d9ecb4bdf0456d)obj;
				xac1588bced6f81bf("fillColor", x26d9ecb4bdf0456d);
				if (x26d9ecb4bdf0456d.xda71bf6f7c07c3bc == 0)
				{
					xac1588bced6f81bf("fFilled", xbcea506a33cf9111: false);
					x39356f2583b8c713 = false;
				}
				break;
			}
			case 386:
				xac1588bced6f81bf("fillOpacity", (int)obj);
				break;
			case 387:
				xac1588bced6f81bf("fillBackColor", (x26d9ecb4bdf0456d)obj);
				break;
			case 388:
				xac1588bced6f81bf("fillBackOpacity", (int)obj);
				break;
			case 391:
				xac1588bced6f81bf("fillBlipName", (string)obj);
				break;
			case 4111:
				x93386efb383a4e44("fillBlip", (byte[])obj, (x10884bb8036bcee0)xf7125312c7ee115c.xfe91eeeafcb3026a(4122));
				break;
			case 395:
				xac1588bced6f81bf("fillAngle", (int)obj);
				break;
			case 396:
				xac1588bced6f81bf("fillFocus", (int)obj);
				break;
			case 397:
				xac1588bced6f81bf("fillToLeft", (int)obj);
				break;
			case 399:
				xac1588bced6f81bf("fillToRight", (int)obj);
				break;
			case 398:
				xac1588bced6f81bf("fillToTop", (int)obj);
				break;
			case 400:
				xac1588bced6f81bf("fillToBottom", (int)obj);
				break;
			case 407:
				x9a865479aaebc1f0((x9fb6ff04f20b10d0[])obj);
				break;
			case 412:
				xac1588bced6f81bf("fillShadeType", Convert.ToInt32(obj));
				break;
			case 408:
				xac1588bced6f81bf("fillOriginX", (int)obj);
				break;
			case 409:
				xac1588bced6f81bf("fillOriginY", (int)obj);
				break;
			case 410:
				xac1588bced6f81bf("fillShapeOriginX", (int)obj);
				break;
			case 411:
				xac1588bced6f81bf("fillShapeOriginY", (int)obj);
				break;
			case 443:
				if (x39356f2583b8c713)
				{
					xac1588bced6f81bf("fFilled", (bool)obj);
				}
				break;
			case 389:
				xac1588bced6f81bf("fillCrMod", (int)obj);
				break;
			case 405:
				xac1588bced6f81bf("fillDztype", Convert.ToInt32(obj));
				break;
			case 445:
				xac1588bced6f81bf("fillShape", (bool)obj);
				break;
			case 446:
				xac1588bced6f81bf("fillUseRect", (bool)obj);
				break;
			case 441:
				xac1588bced6f81bf("fRecolorFillAsPicture", (bool)obj);
				break;
			case 442:
				xac1588bced6f81bf("fUseShapeAnchor", (bool)obj);
				break;
			case 448:
				xac1588bced6f81bf("lineColor", (x26d9ecb4bdf0456d)obj);
				break;
			case 449:
				xac1588bced6f81bf("lineOpacity", (int)obj);
				break;
			case 450:
				xac1588bced6f81bf("lineBackColor", (x26d9ecb4bdf0456d)obj);
				break;
			case 452:
				xac1588bced6f81bf("lineType", Convert.ToInt32(obj));
				break;
			case 458:
				xac1588bced6f81bf("lineFillDztype", Convert.ToInt32(obj));
				break;
			case 459:
				xac1588bced6f81bf("lineWidth", (int)obj);
				break;
			case 461:
				xac1588bced6f81bf("lineStyle", Convert.ToInt32(obj));
				break;
			case 462:
				xac1588bced6f81bf("lineDashing", Convert.ToInt32(obj));
				break;
			case 471:
				xac1588bced6f81bf("lineEndCapStyle", Convert.ToInt32(obj));
				break;
			case 470:
				xac1588bced6f81bf("lineJoinStyle", Convert.ToInt32(obj));
				break;
			case 460:
				xac1588bced6f81bf("lineMiterLimit", (int)obj);
				break;
			case 454:
				xac1588bced6f81bf("lineFillBlipName", (string)obj);
				break;
			case 4110:
				x93386efb383a4e44("lineFillBlip", (byte[])obj, (x10884bb8036bcee0)xf7125312c7ee115c.xfe91eeeafcb3026a(4121));
				break;
			case 456:
				xac1588bced6f81bf("lineFillWidth", (int)obj);
				break;
			case 457:
				xac1588bced6f81bf("lineFillHeight", (int)obj);
				break;
			case 508:
				xac1588bced6f81bf("fLine", (bool)obj);
				break;
			case 464:
				xac1588bced6f81bf("lineStartArrowhead", Convert.ToInt32(obj));
				break;
			case 465:
				xac1588bced6f81bf("lineEndArrowhead", Convert.ToInt32(obj));
				break;
			case 466:
				xac1588bced6f81bf("lineStartArrowWidth", Convert.ToInt32(obj));
				break;
			case 468:
				xac1588bced6f81bf("lineEndArrowWidth", Convert.ToInt32(obj));
				break;
			case 467:
				xac1588bced6f81bf("lineStartArrowLength", Convert.ToInt32(obj));
				break;
			case 469:
				xac1588bced6f81bf("lineEndArrowLength", Convert.ToInt32(obj));
				break;
			case 512:
				xac1588bced6f81bf("shadowType", Convert.ToInt32(obj));
				break;
			case 513:
				xac1588bced6f81bf("shadowColor", (x26d9ecb4bdf0456d)obj);
				break;
			case 514:
				xac1588bced6f81bf("shadowHighlight", (x26d9ecb4bdf0456d)obj);
				break;
			case 516:
				xac1588bced6f81bf("shadowOpacity", (int)obj);
				break;
			case 517:
				xac1588bced6f81bf("shadowOffsetX", (int)obj);
				break;
			case 518:
				xac1588bced6f81bf("shadowOffsetY", (int)obj);
				break;
			case 519:
				xac1588bced6f81bf("shadowSecondOffsetX", (int)obj);
				break;
			case 520:
				xac1588bced6f81bf("shadowSecondOffsetY", (int)obj);
				break;
			case 521:
				xac1588bced6f81bf("shadowScaleXToX", (int)obj);
				break;
			case 522:
				xac1588bced6f81bf("shadowScaleYToX", (int)obj);
				break;
			case 523:
				xac1588bced6f81bf("shadowScaleXToY", (int)obj);
				break;
			case 524:
				xac1588bced6f81bf("shadowScaleYToY", (int)obj);
				break;
			case 525:
				xac1588bced6f81bf("shadowPerspectiveX", (int)obj);
				break;
			case 526:
				xac1588bced6f81bf("shadowPerspectiveY", (int)obj);
				break;
			case 527:
				xac1588bced6f81bf("shadowWeight", (int)obj);
				break;
			case 528:
				xac1588bced6f81bf("shadowOriginX", (int)obj);
				break;
			case 529:
				xac1588bced6f81bf("shadowOriginY", (int)obj);
				break;
			case 574:
				xac1588bced6f81bf("fShadow", (bool)obj);
				break;
			case 515:
				xac1588bced6f81bf("shadowCrMod", (int)obj);
				break;
			case 575:
				xac1588bced6f81bf("fShadowObscured", (bool)obj);
				break;
			case 640:
				xac1588bced6f81bf("c3DSpecularAmt", (int)obj);
				break;
			case 641:
				xac1588bced6f81bf("c3DDiffuseAmt", (int)obj);
				break;
			case 642:
				xac1588bced6f81bf("c3DShininess", (int)obj);
				break;
			case 643:
				xac1588bced6f81bf("c3DEdgeThickness", (int)obj);
				break;
			case 644:
				xac1588bced6f81bf("c3DExtrudeForward", (int)obj);
				break;
			case 645:
				xac1588bced6f81bf("c3DExtrudeBackward", (int)obj);
				break;
			case 647:
				xac1588bced6f81bf("c3DExtrusionColor", (x26d9ecb4bdf0456d)obj);
				break;
			case 700:
				xac1588bced6f81bf("f3D", (bool)obj);
				break;
			case 701:
				xac1588bced6f81bf("fc3DMetallic", (bool)obj);
				break;
			case 646:
				xac1588bced6f81bf("c3DExtrudePlane", Convert.ToInt32(obj));
				break;
			case 702:
				xac1588bced6f81bf("fc3DUseExtrusionColor", (bool)obj);
				break;
			case 703:
				xac1588bced6f81bf("fc3DLightFace", (bool)obj);
				break;
			case 705:
				xac1588bced6f81bf("c3DXRotationAngle", (int)obj);
				break;
			case 704:
				xac1588bced6f81bf("c3DYRotationAngle", (int)obj);
				break;
			case 706:
				xac1588bced6f81bf("c3DRotationAxisX", (int)obj);
				break;
			case 707:
				xac1588bced6f81bf("c3DRotationAxisY", (int)obj);
				break;
			case 708:
				xac1588bced6f81bf("c3DRotationAxisZ", (int)obj);
				break;
			case 709:
				xac1588bced6f81bf("c3DRotationAngle", (int)obj);
				break;
			case 764:
				xac1588bced6f81bf("fC3DRotationCenterAuto", (bool)obj);
				break;
			case 710:
				xac1588bced6f81bf("c3DRotationCenterX", (int)obj);
				break;
			case 711:
				xac1588bced6f81bf("c3DRotationCenterY", (int)obj);
				break;
			case 712:
				xac1588bced6f81bf("c3DRotationCenterZ", (int)obj);
				break;
			case 713:
				xac1588bced6f81bf("c3DRenderMode", Convert.ToInt32(obj));
				break;
			case 715:
				xac1588bced6f81bf("c3DXViewpoint", (int)obj);
				break;
			case 716:
				xac1588bced6f81bf("c3DYViewpoint", (int)obj);
				break;
			case 717:
				xac1588bced6f81bf("c3DZViewpoint", (int)obj);
				break;
			case 718:
				xac1588bced6f81bf("c3DOriginX", (int)obj);
				break;
			case 719:
				xac1588bced6f81bf("c3DOriginY", (int)obj);
				break;
			case 720:
				xac1588bced6f81bf("c3DSkewAngle", (int)obj);
				break;
			case 721:
				xac1588bced6f81bf("c3DSkewAmount", (int)obj);
				break;
			case 722:
				xac1588bced6f81bf("c3DAmbientIntensity", (int)obj);
				break;
			case 723:
				xac1588bced6f81bf("c3DKeyX", (int)obj);
				break;
			case 724:
				xac1588bced6f81bf("c3DKeyY", (int)obj);
				break;
			case 725:
				xac1588bced6f81bf("c3DKeyZ", (int)obj);
				break;
			case 726:
				xac1588bced6f81bf("c3DKeyIntensity", (int)obj);
				break;
			case 727:
				xac1588bced6f81bf("c3DFillX", (int)obj);
				break;
			case 728:
				xac1588bced6f81bf("c3DFillY", (int)obj);
				break;
			case 729:
				xac1588bced6f81bf("c3DFillZ", (int)obj);
				break;
			case 730:
				xac1588bced6f81bf("c3DFillIntensity", (int)obj);
				break;
			case 765:
				xac1588bced6f81bf("fc3DParallel", (bool)obj);
				break;
			case 766:
				xac1588bced6f81bf("fc3DKeyHarsh", (bool)obj);
				break;
			case 767:
				xac1588bced6f81bf("fc3DFillHarsh", (bool)obj);
				break;
			case 648:
				xac1588bced6f81bf("c3DCrMod", (int)obj);
				break;
			case 714:
				xac1588bced6f81bf("c3DTolerance", (int)obj);
				break;
			case 763:
				xac1588bced6f81bf("fc3DConstrainRotation", (bool)obj);
				break;
			case 577:
				xac1588bced6f81bf("perspectiveOffsetX", (int)obj);
				break;
			case 578:
				xac1588bced6f81bf("perspectiveOffsetY", (int)obj);
				break;
			case 586:
				xac1588bced6f81bf("perspectiveOriginX", (int)obj);
				break;
			case 587:
				xac1588bced6f81bf("perspectiveOriginY", (int)obj);
				break;
			case 583:
				xac1588bced6f81bf("perspectivePerspectiveX", (int)obj);
				break;
			case 584:
				xac1588bced6f81bf("perspectivePerspectiveY", (int)obj);
				break;
			case 579:
				xac1588bced6f81bf("perspectiveScaleXToX", (int)obj);
				break;
			case 581:
				xac1588bced6f81bf("perspectiveScaleXToY", (int)obj);
				break;
			case 580:
				xac1588bced6f81bf("perspectiveScaleYToX", (int)obj);
				break;
			case 582:
				xac1588bced6f81bf("perspectiveScaleYToY", (int)obj);
				break;
			case 576:
				xac1588bced6f81bf("perspectiveType", Convert.ToInt32(obj));
				break;
			case 585:
				xac1588bced6f81bf("perspectiveWeight", (int)obj);
				break;
			case 639:
				xac1588bced6f81bf("fPerspective", (bool)obj);
				break;
			case 832:
				xac1588bced6f81bf("spcot", Convert.ToInt32(obj));
				break;
			case 833:
				xac1588bced6f81bf("dxyCalloutGap", (int)obj);
				break;
			case 834:
				xac1588bced6f81bf("spcoa", Convert.ToInt32(obj));
				break;
			case 835:
				xac1588bced6f81bf("spcod", Convert.ToInt32(obj));
				break;
			case 836:
				xac1588bced6f81bf("dxyCalloutDropSpecified", (int)obj);
				break;
			case 837:
				xac1588bced6f81bf("dxyCalloutLengthSpecified", (int)obj);
				break;
			case 889:
				xac1588bced6f81bf("fCallout", (bool)obj);
				break;
			case 890:
				xac1588bced6f81bf("fCalloutAccentBar", (bool)obj);
				break;
			case 891:
				xac1588bced6f81bf("fCalloutTextBorder", (bool)obj);
				break;
			case 894:
				xac1588bced6f81bf("fCalloutDropAuto", (bool)obj);
				break;
			case 895:
				xac1588bced6f81bf("fCalloutLengthSpecified", (bool)obj);
				break;
			case 892:
				xac1588bced6f81bf("fCalloutMinusX", (bool)obj);
				break;
			case 893:
				xac1588bced6f81bf("fCalloutMinusY", (bool)obj);
				break;
			case 771:
				xac1588bced6f81bf("cxstyle", Convert.ToInt32(obj));
				break;
			case 1280:
			{
				x5e63bd35f6835a06 x5e63bd35f6835a = (x5e63bd35f6835a06)obj;
				if (x5e63bd35f6835a >= x5e63bd35f6835a06.xa1eafe7821eb4aab)
				{
					xac1588bced6f81bf("dgmt", Convert.ToInt32(obj));
				}
				break;
			}
			case 1281:
				xac1588bced6f81bf("dgmtStyle", (int)obj);
				break;
			case 1284:
				x518ad5df1036fea0((x580ae020787e37f2[])obj);
				break;
			case 1285:
				xac1588bced6f81bf("dgmScaleX", (int)obj);
				break;
			case 1286:
				xac1588bced6f81bf("dgmScaleY", (int)obj);
				break;
			case 1287:
				xac1588bced6f81bf("dgmDefaultFontSize", (int)obj);
				break;
			case 1288:
				xac1588bced6f81bf("dgmConstrainBounds", (int[])obj);
				break;
			case 1342:
				xac1588bced6f81bf("fDoLayout", (bool)obj);
				break;
			case 1340:
				xac1588bced6f81bf("fDoFormat", (bool)obj);
				break;
			case 777:
				xac1588bced6f81bf("dgmLayout", Convert.ToInt32(obj));
				break;
			case 778:
				xac1588bced6f81bf("dgmNodeKind", Convert.ToInt32(obj));
				break;
			case 1341:
				xac1588bced6f81bf("fReverse", (bool)obj);
				break;
			case 772:
				xac1588bced6f81bf("bWMode", Convert.ToInt32(obj));
				break;
			case 774:
				xac1588bced6f81bf("bWModeBW", Convert.ToInt32(obj));
				break;
			case 773:
				xac1588bced6f81bf("bWModePureBW", Convert.ToInt32(obj));
				break;
			case 948:
			{
				bool flag = (bool)obj;
				xac1588bced6f81bf("fHorizRule", flag);
				if (flag)
				{
					xac1588bced6f81bf("dxHeightHR", x4574ea26106f0edb.x88bf16f2386d633e(x5770cdefd8931aa9.Height));
					xac1588bced6f81bf("dxWidthHR", x4574ea26106f0edb.x88bf16f2386d633e(x5770cdefd8931aa9.Width));
				}
				break;
			}
			case 916:
				xac1588bced6f81bf("alignHR", Convert.ToInt32(obj));
				break;
			case 947:
				xac1588bced6f81bf("fNoshadeHR", (bool)obj);
				break;
			case 946:
				xac1588bced6f81bf("fStandardHR", (bool)obj);
				break;
			case 915:
				xac1588bced6f81bf("pctHR", (int)obj);
				break;
			case 909:
				xac1588bced6f81bf("wzTooltip", (string)obj);
				break;
			case 4125:
				if (!x5770cdefd8931aa9.IsGroup)
				{
					xac1588bced6f81bf("geoLeft", (int)obj);
				}
				break;
			case 4126:
				if (!x5770cdefd8931aa9.IsGroup)
				{
					xac1588bced6f81bf("geoTop", (int)obj);
				}
				break;
			case 4127:
				if (!x5770cdefd8931aa9.IsGroup)
				{
					xac1588bced6f81bf("geoRight", x5770cdefd8931aa9.x06c65daad0c0656c + (int)obj);
				}
				break;
			case 4128:
				if (!x5770cdefd8931aa9.IsGroup)
				{
					xac1588bced6f81bf("geoBottom", x5770cdefd8931aa9.x399bb78ac51a4081 + (int)obj);
				}
				break;
			case 1792:
				xb4193fadfb06a739("pInkData");
				xe1410f585439c7d4.xee60bff2900a72f2("\\*\\svb");
				xe1410f585439c7d4.xf7f536bd531211e3((byte[])obj);
				xe1410f585439c7d4.xc8a13a52db0580ae();
				x3513d37d4b482998();
				xac1588bced6f81bf("fInkAnnotation", x5770cdefd8931aa9.x04253a50feaae58a);
				xac1588bced6f81bf("fRenderInk", xbcea506a33cf9111: true);
				break;
			case 1927:
				xac1588bced6f81bf("wzSigSetupAddlXml", (string)obj);
				break;
			case 1981:
				xac1588bced6f81bf("fSigSetupAllowComments", (bool)obj);
				break;
			case 1921:
				xac1588bced6f81bf("wzSigSetupId", (string)obj);
				break;
			case 1983:
				xac1588bced6f81bf("fIsSignatureLine", (bool)obj);
				break;
			case 1922:
				xac1588bced6f81bf("wzSigSetupProvId", (string)obj);
				break;
			case 1980:
				xac1588bced6f81bf("fSigSetupShowSignDate", (bool)obj);
				break;
			case 1926:
				xac1588bced6f81bf("wzSigSetupSignInst", (string)obj);
				break;
			case 1928:
				xac1588bced6f81bf("wzSigSetupProvUrl", (string)obj);
				break;
			case 1923:
				xac1588bced6f81bf("wzSigSetupSuggSigner", (string)obj);
				break;
			case 1924:
				xac1588bced6f81bf("wzSigSetupSuggSigner2", (string)obj);
				break;
			case 1925:
				xac1588bced6f81bf("wzSigSetupSuggSignerEmail", (string)obj);
				break;
			case 1982:
				xac1588bced6f81bf("fSigSetupSignInstSet", (bool)obj);
				break;
			default:
				_ = x492f529cee830a40;
				break;
			case 338:
			case 414:
			case 415:
			case 416:
			case 417:
			case 421:
			case 422:
			case 476:
			case 480:
			case 533:
			case 537:
			case 652:
			case 779:
			case 898:
			case 938:
			case 944:
			case 949:
			case 951:
			case 1087:
			case 1282:
			case 1283:
			case 1855:
			case 4097:
			case 4098:
			case 4099:
			case 4102:
			case 4103:
			case 4104:
			case 4106:
			case 4107:
			case 4108:
			case 4109:
			case 4112:
			case 4113:
			case 4121:
			case 4122:
				break;
			}
		}
		x0d5c5ac3156c4491(x5770cdefd8931aa9.ShapeType);
		xd5d1a790cf0c0482(x5770cdefd8931aa9);
		if (x610d1a116fd8c9bd)
		{
			xac1588bced6f81bf("fBackground", xbcea506a33cf9111: true);
		}
		if (x625b9038331e382d)
		{
			xac1588bced6f81bf("fPseudoInline", xbcea506a33cf9111: true);
		}
		x93386efb383a4e44(x5770cdefd8931aa9);
		if (x5770cdefd8931aa9.xbfc952aeef7fd0d5)
		{
			xc2550bde00ba6ebf(x5770cdefd8931aa9);
		}
	}

	internal void x3b286c2f991fe9df(ShapeBase x5770cdefd8931aa9)
	{
		xe1410f585439c7d4.x4d14ee33f46b5913("\\defshp");
		xe1410f585439c7d4.x4d14ee33f46b5913("\\shplid", x5770cdefd8931aa9.xea1e81378298fa81);
		x0d5c5ac3156c4491(ShapeType.Image);
		xac1588bced6f81bf("fFlipH", xbcea506a33cf9111: false);
		xac1588bced6f81bf("fFlipV", xbcea506a33cf9111: false);
		xac1588bced6f81bf("fLockRotation", xbcea506a33cf9111: true);
		xac1588bced6f81bf("fLockPosition", xbcea506a33cf9111: true);
		xac1588bced6f81bf("fLayoutInCell", xbcea506a33cf9111: true);
		xac1588bced6f81bf("fPseudoInline", xbcea506a33cf9111: true);
	}

	private void x8d0b1bbfa5da914b(string xc3513c7f2bbafa84, bool xde011137ec375c87)
	{
		xac1588bced6f81bf(xc3513c7f2bbafa84, !x625b9038331e382d && xde011137ec375c87);
	}

	private void x93386efb383a4e44(ShapeBase x8739b0dd3627f37e)
	{
		if (x8739b0dd3627f37e.CanHaveImage)
		{
			Shape shape = (Shape)x8739b0dd3627f37e;
			ImageData imageData = shape.ImageData;
			if (imageData.IsLink)
			{
				xac1588bced6f81bf("pibName", imageData.SourceFullName);
				xac1588bced6f81bf("pibFlags", imageData.IsLinkOnly ? 14 : 10);
			}
			else
			{
				xac1588bced6f81bf("pibName", imageData.Title);
			}
			if (imageData.x169baa05e57bf312 && !x8739b0dd3627f37e.IsInline)
			{
				xb4193fadfb06a739("pib");
				x4cefe4b20532460c x4cefe4b20532460c2 = new x4cefe4b20532460c(x8cedcaa9a62c6e39, shape);
				x4cefe4b20532460c2.x6210059f049f0d48(x0efda03510113407: false, x87e9ac2885e28700: false, x10884bb8036bcee0.x1a23317d325de634);
				x3513d37d4b482998();
			}
		}
	}

	private void x93386efb383a4e44(string xc3513c7f2bbafa84, byte[] xf1c258adc3c53c0e, x10884bb8036bcee0 x29d5ed4aec3de9b7)
	{
		xb4193fadfb06a739(xc3513c7f2bbafa84);
		x4cefe4b20532460c x4cefe4b20532460c2 = new x4cefe4b20532460c(x8cedcaa9a62c6e39, xf1c258adc3c53c0e);
		x4cefe4b20532460c2.x6210059f049f0d48(x0efda03510113407: true, x87e9ac2885e28700: false, x29d5ed4aec3de9b7);
		x3513d37d4b482998();
	}

	private void xc2550bde00ba6ebf(ShapeBase x5770cdefd8931aa9)
	{
		string hRef = x5770cdefd8931aa9.HRef;
		xb4193fadfb06a739("pihlShape");
		xe1410f585439c7d4.xee60bff2900a72f2("\\*\\hl");
		xe1410f585439c7d4.xf55384516c165731("\\hlsrc", x0d4d45882065c63e.xc8c8ca56669559a3(hRef));
		xe1410f585439c7d4.xf55384516c165731("\\hlloc", x0d4d45882065c63e.x358b45b4ddbfa57c(hRef));
		xe1410f585439c7d4.xf55384516c165731("\\hlfr", hRef);
		xe1410f585439c7d4.xc8a13a52db0580ae();
		x3513d37d4b482998();
	}

	private void xb392b51383ce6e9f(FlipOrientation xbcea506a33cf9111, bool x7a77671c06dfd253)
	{
		xac1588bced6f81bf(x7a77671c06dfd253 ? "fFlipH" : "fRelFlipH", xbcea506a33cf9111 == FlipOrientation.Horizontal || xbcea506a33cf9111 == FlipOrientation.Both);
		xac1588bced6f81bf(x7a77671c06dfd253 ? "fFlipV" : "fRelFlipV", xbcea506a33cf9111 == FlipOrientation.Vertical || xbcea506a33cf9111 == FlipOrientation.Both);
	}

	private void x0d5c5ac3156c4491(ShapeType x02f2ab213025de6d)
	{
		switch (x02f2ab213025de6d)
		{
		case ShapeType.Group:
			break;
		case ShapeType.OleObject:
		case ShapeType.OleControl:
			xac1588bced6f81bf("shapeType", 75);
			break;
		default:
			xac1588bced6f81bf("shapeType", (int)x02f2ab213025de6d);
			break;
		}
	}

	private void xd5d1a790cf0c0482(ShapeBase x5770cdefd8931aa9)
	{
		if (!x5770cdefd8931aa9.IsTopLevel || x5770cdefd8931aa9.IsGroup)
		{
			int xbcea506a33cf;
			int xbcea506a33cf2;
			int xbcea506a33cf3;
			int xbcea506a33cf4;
			if (x5770cdefd8931aa9.IsTopLevel)
			{
				xbcea506a33cf = x5770cdefd8931aa9.CoordOrigin.X;
				xbcea506a33cf2 = x5770cdefd8931aa9.CoordOrigin.X + x5770cdefd8931aa9.CoordSize.Width;
				xbcea506a33cf3 = x5770cdefd8931aa9.CoordOrigin.Y;
				xbcea506a33cf4 = x5770cdefd8931aa9.CoordOrigin.Y + x5770cdefd8931aa9.CoordSize.Height;
			}
			else
			{
				x5a479118db43fa5e x5a479118db43fa5e = x5a479118db43fa5e.xf648b77e8172fa16(x5770cdefd8931aa9);
				xbcea506a33cf = (int)x5a479118db43fa5e.x72d92bd1aff02e37;
				xbcea506a33cf2 = (int)(x5a479118db43fa5e.x72d92bd1aff02e37 + x5a479118db43fa5e.xdc1bf80853046136);
				xbcea506a33cf3 = (int)x5a479118db43fa5e.xe360b1885d8d4a41;
				xbcea506a33cf4 = (int)(x5a479118db43fa5e.xe360b1885d8d4a41 + x5a479118db43fa5e.xb0f146032f47c24e);
			}
			if (x5770cdefd8931aa9.IsGroup)
			{
				xac1588bced6f81bf("groupLeft", x5770cdefd8931aa9.CoordOrigin.X);
				xac1588bced6f81bf("groupRight", x5770cdefd8931aa9.CoordOrigin.X + x5770cdefd8931aa9.CoordSize.Width);
				xac1588bced6f81bf("groupTop", x5770cdefd8931aa9.CoordOrigin.Y);
				xac1588bced6f81bf("groupBottom", x5770cdefd8931aa9.CoordOrigin.Y + x5770cdefd8931aa9.CoordSize.Height);
			}
			if (!x5770cdefd8931aa9.IsTopLevel)
			{
				xac1588bced6f81bf("relLeft", xbcea506a33cf);
				xac1588bced6f81bf("relRight", xbcea506a33cf2);
				xac1588bced6f81bf("relTop", xbcea506a33cf3);
				xac1588bced6f81bf("relBottom", xbcea506a33cf4);
			}
		}
	}

	private void x4ca9f3d85457b9b9(ShapeBase x5770cdefd8931aa9, bool xa551490e89134536)
	{
		xe1410f585439c7d4.x4d14ee33f46b5913("\\shplid", x5770cdefd8931aa9.xea1e81378298fa81);
		bool flag = x5770cdefd8931aa9.IsInline && !x5770cdefd8931aa9.x3d318285d887cd3a;
		if (x610d1a116fd8c9bd || (x5770cdefd8931aa9.IsTopLevel && !flag))
		{
			x5a479118db43fa5e x5a479118db43fa5e = x5a479118db43fa5e.xf648b77e8172fa16(x5770cdefd8931aa9);
			xe1410f585439c7d4.x4d14ee33f46b5913("\\shpleft", x4574ea26106f0edb.x88bf16f2386d633e(x5a479118db43fa5e.x72d92bd1aff02e37));
			xe1410f585439c7d4.x4d14ee33f46b5913("\\shpright", x4574ea26106f0edb.x88bf16f2386d633e(x5a479118db43fa5e.x72d92bd1aff02e37 + x5a479118db43fa5e.xdc1bf80853046136));
			xe1410f585439c7d4.x4d14ee33f46b5913("\\shptop", x4574ea26106f0edb.x88bf16f2386d633e(x5a479118db43fa5e.xe360b1885d8d4a41));
			xe1410f585439c7d4.x4d14ee33f46b5913("\\shpbottom", x4574ea26106f0edb.x88bf16f2386d633e(x5a479118db43fa5e.xe360b1885d8d4a41 + x5a479118db43fa5e.xb0f146032f47c24e));
			xe1410f585439c7d4.x4d14ee33f46b5913("\\shpfhdr", xa551490e89134536 ? "1" : "0");
			xe1410f585439c7d4.x4d14ee33f46b5913("\\shpz", x5770cdefd8931aa9.x2dacf7fcd96fee63);
			xe1410f585439c7d4.x4d14ee33f46b5913("\\shpfblwtxt", x5770cdefd8931aa9.BehindText ? "1" : "0");
			xe1410f585439c7d4.x4d14ee33f46b5913(x94f5d65be6ba39b4.xd2b15bd56bbd56f2(x5770cdefd8931aa9.RelativeHorizontalPosition));
			xe1410f585439c7d4.x4d14ee33f46b5913("\\shpbxignore");
			xe1410f585439c7d4.x4d14ee33f46b5913(x94f5d65be6ba39b4.x81ebc6d588b0838e(x5770cdefd8931aa9.RelativeVerticalPosition));
			xe1410f585439c7d4.x4d14ee33f46b5913("\\shpbyignore");
			xe1410f585439c7d4.x4d14ee33f46b5913("\\shpwr", (x5770cdefd8931aa9.WrapType == WrapType.Inline) ? 3 : Convert.ToInt32(x5770cdefd8931aa9.WrapType));
			xe1410f585439c7d4.x4d14ee33f46b5913("\\shpwrk", Convert.ToInt32(x5770cdefd8931aa9.WrapSide));
			xe1410f585439c7d4.xb8aea59edd4060ce("\\shplockanchor", x5770cdefd8931aa9.AnchorLocked);
		}
		if (x5770cdefd8931aa9.IsTopLevel)
		{
			xac1588bced6f81bf("fLayoutInCell", x5770cdefd8931aa9.x87119342b85a2a43);
		}
	}

	private void x9a865479aaebc1f0(x9fb6ff04f20b10d0[] xa70c7ccd3278240f)
	{
		xb4193fadfb06a739("fillShadeColors");
		xc4043f5e0fc37114(xa70c7ccd3278240f.Length, 8);
		for (int i = 0; i < xa70c7ccd3278240f.Length; i++)
		{
			x9fb6ff04f20b10d0 x9fb6ff04f20b10d = xa70c7ccd3278240f[i];
			xc3a98ea651fcae41(x195cb055715b526e.x103636c839f725d7(x9fb6ff04f20b10d.x9b41425268471380), x9fb6ff04f20b10d.x12cb12b5d2cad53d, i == xa70c7ccd3278240f.Length - 1);
		}
		x3513d37d4b482998();
	}

	private void xe5c97d2d0daa8b43(string xc3513c7f2bbafa84, x08d932077485c285[] x6fa2570084b2ad39)
	{
		xb4193fadfb06a739(xc3513c7f2bbafa84);
		xc4043f5e0fc37114(x6fa2570084b2ad39.Length, 8);
		for (int i = 0; i < x6fa2570084b2ad39.Length; i++)
		{
			x08d932077485c285 x08d932077485c = x6fa2570084b2ad39[i];
			xc3a98ea651fcae41(xf7d2bc4cd6535591.x990d3e2e1a133b7d(x08d932077485c.x8df91a2f90079e88), xf7d2bc4cd6535591.x990d3e2e1a133b7d(x08d932077485c.xc821290d7ecc08bf), i == x6fa2570084b2ad39.Length - 1);
		}
		x3513d37d4b482998();
	}

	private void x7cac727ef7c00771(x7efbe0a2dc0d335f[] x24b33b6b7c8643ea)
	{
		xb4193fadfb06a739("pAdjustHandles");
		xf50f5428be94001d(x24b33b6b7c8643ea.Length, 36);
		foreach (x7efbe0a2dc0d335f x7efbe0a2dc0d335f in x24b33b6b7c8643ea)
		{
			xe1410f585439c7d4.xb6c076f287274764(x7efbe0a2dc0d335f.xabe60eaba2fa6780());
			xe1410f585439c7d4.xb6c076f287274764(x7efbe0a2dc0d335f.x3b1bddb38a858693.x98a6bc3f2b64620b);
			xe1410f585439c7d4.xb6c076f287274764(x7efbe0a2dc0d335f.x97a3447730c7ceb9.x98a6bc3f2b64620b);
			xe1410f585439c7d4.xb6c076f287274764(x7efbe0a2dc0d335f.xb6af3939c9fabf06.xd2f68ee6f47e9dfb);
			xe1410f585439c7d4.xb6c076f287274764(x7efbe0a2dc0d335f.x8d8e3bafebd1a122.xd2f68ee6f47e9dfb);
			xe1410f585439c7d4.xb6c076f287274764(x7efbe0a2dc0d335f.x9462c8df936efa39.xd2f68ee6f47e9dfb);
			xe1410f585439c7d4.xb6c076f287274764(x7efbe0a2dc0d335f.x11f73230b9b436a7.xd2f68ee6f47e9dfb);
			xe1410f585439c7d4.xb6c076f287274764(x7efbe0a2dc0d335f.x5b051452efe1bbe3.xd2f68ee6f47e9dfb);
			xe1410f585439c7d4.xb6c076f287274764(x7efbe0a2dc0d335f.xbed6b6abe5a7fcce.xd2f68ee6f47e9dfb);
		}
		x3513d37d4b482998();
	}

	private void xf7b167486e3ffbc1(x40937ad35b1cf5f7[] x25e1a744748a0dec)
	{
		xb4193fadfb06a739("pGuides");
		xc4043f5e0fc37114(x25e1a744748a0dec.Length, 8);
		for (int i = 0; i < x25e1a744748a0dec.Length; i++)
		{
			x40937ad35b1cf5f7 x40937ad35b1cf5f = x25e1a744748a0dec[i];
			int num = 0;
			num |= (byte)x40937ad35b1cf5f.xca0517fe66f52202;
			num |= x40937ad35b1cf5f.x586b7652ac7cefe0 << 8;
			num |= x40937ad35b1cf5f.xf63e76e85f8fbc50 << 16;
			int num2 = 0;
			num2 |= x40937ad35b1cf5f.xe7e30aeba78bbcd2;
			num2 |= x40937ad35b1cf5f.x7cc7f538a3b98861 << 16;
			xc3a98ea651fcae41(num, num2, i == x25e1a744748a0dec.Length - 1);
		}
		x3513d37d4b482998();
	}

	private void xc059ae6d9116afde(xbc9979937c838d75[] x09d9444f882ac964)
	{
		xb4193fadfb06a739("pInscribe");
		xf50f5428be94001d(x09d9444f882ac964.Length, 16);
		foreach (xbc9979937c838d75 xbc9979937c838d in x09d9444f882ac964)
		{
			xe1410f585439c7d4.xb6c076f287274764(xf7d2bc4cd6535591.x990d3e2e1a133b7d(xbc9979937c838d.x72d92bd1aff02e37));
			xe1410f585439c7d4.xb6c076f287274764(xf7d2bc4cd6535591.x990d3e2e1a133b7d(xbc9979937c838d.xe360b1885d8d4a41));
			xe1410f585439c7d4.xb6c076f287274764(xf7d2bc4cd6535591.x990d3e2e1a133b7d(xbc9979937c838d.x419ba17a5322627b));
			xe1410f585439c7d4.xb6c076f287274764(xf7d2bc4cd6535591.x990d3e2e1a133b7d(xbc9979937c838d.x9bcb07e204e30218));
		}
		x3513d37d4b482998();
	}

	private void x518ad5df1036fea0(x580ae020787e37f2[] x7d109799e45a956b)
	{
		xb4193fadfb06a739("pRelationTbl");
		xf50f5428be94001d(x7d109799e45a956b.Length, 12);
		foreach (x580ae020787e37f2 x580ae020787e37f in x7d109799e45a956b)
		{
			xe1410f585439c7d4.xb6c076f287274764(x580ae020787e37f.xda71bf6f7c07c3bc);
			xe1410f585439c7d4.xb6c076f287274764(x580ae020787e37f.x8e8f6cc6a0756b05);
			xe1410f585439c7d4.xb6c076f287274764(x580ae020787e37f.x857912840ffd015f);
		}
		x3513d37d4b482998();
	}

	private void xac1588bced6f81bf(string xc15bd84e01929885, bool xbcea506a33cf9111)
	{
		xac1588bced6f81bf(xc15bd84e01929885, xbcea506a33cf9111 ? "1" : "0");
	}

	private void xac1588bced6f81bf(string xc15bd84e01929885, int xbcea506a33cf9111)
	{
		xac1588bced6f81bf(xc15bd84e01929885, xbcea506a33cf9111.ToString());
	}

	private void x431a88a390b2c434(x44f2b8bf33b16275[] x4d2d2c7878ccec7b)
	{
		xb4193fadfb06a739("pSegmentInfo");
		xc4043f5e0fc37114(x4d2d2c7878ccec7b.Length, 2);
		for (int i = 0; i < x4d2d2c7878ccec7b.Length; i++)
		{
			int xbcea506a33cf = x30145fee5dd2eb06.xeda895769860002f(x4d2d2c7878ccec7b[i]);
			bool x490527f1272e27b = i == x4d2d2c7878ccec7b.Length - 1;
			x10b1d68300b61ff5(xbcea506a33cf, x490527f1272e27b);
		}
		x3513d37d4b482998();
	}

	private void xac1588bced6f81bf(string xc15bd84e01929885, int[] xbcea506a33cf9111)
	{
		xb4193fadfb06a739(xc15bd84e01929885);
		xc4043f5e0fc37114(xbcea506a33cf9111.Length, 4);
		for (int i = 0; i < xbcea506a33cf9111.Length; i++)
		{
			x10b1d68300b61ff5(xbcea506a33cf9111[i], i == xbcea506a33cf9111.Length - 1);
		}
		x3513d37d4b482998();
	}

	private void xac1588bced6f81bf(string xc15bd84e01929885, x26d9ecb4bdf0456d xbcea506a33cf9111)
	{
		xac1588bced6f81bf(xc15bd84e01929885, x195cb055715b526e.x103636c839f725d7(xbcea506a33cf9111));
	}

	private void xac1588bced6f81bf(string xc15bd84e01929885, string xbcea506a33cf9111)
	{
		if (x0d299f323d241756.x5959bccb67bbf051(xbcea506a33cf9111))
		{
			xe1410f585439c7d4.xee60bff2900a72f2("\\sp");
			xe1410f585439c7d4.xf55384516c165731("\\sn", xc15bd84e01929885);
			xe1410f585439c7d4.xf55384516c165731("\\sv", xbcea506a33cf9111);
			xe1410f585439c7d4.xc8a13a52db0580ae();
		}
	}

	private void xb4193fadfb06a739(string xc15bd84e01929885)
	{
		xe1410f585439c7d4.xee60bff2900a72f2("\\sp");
		xe1410f585439c7d4.xf55384516c165731("\\sn", xc15bd84e01929885);
		xe1410f585439c7d4.xee60bff2900a72f2("\\sv");
	}

	private void x3513d37d4b482998()
	{
		xe1410f585439c7d4.xc8a13a52db0580ae();
		xe1410f585439c7d4.xc8a13a52db0580ae();
	}

	private void xc4043f5e0fc37114(int x046c167834ef261f, int x4cb8d2c926f9fad1)
	{
		xe1410f585439c7d4.xe7b920de107da0c7();
		xe1410f585439c7d4.x6210059f049f0d48(x4cb8d2c926f9fad1);
		xe1410f585439c7d4.x80fb22e7844d1324();
		xe1410f585439c7d4.x6210059f049f0d48(x046c167834ef261f);
		xe1410f585439c7d4.x80fb22e7844d1324();
	}

	private void xf50f5428be94001d(int x046c167834ef261f, int x4cb8d2c926f9fad1)
	{
		xc4043f5e0fc37114(x046c167834ef261f, x4cb8d2c926f9fad1);
		xe1410f585439c7d4.xfb9a91e8308b9cbc((short)x046c167834ef261f);
		xe1410f585439c7d4.xfb9a91e8308b9cbc((short)x046c167834ef261f);
		xe1410f585439c7d4.xfb9a91e8308b9cbc((short)x4cb8d2c926f9fad1);
	}

	private void x10b1d68300b61ff5(int xbcea506a33cf9111, bool x490527f1272e27b8)
	{
		xe1410f585439c7d4.x6210059f049f0d48(xbcea506a33cf9111);
		if (!x490527f1272e27b8)
		{
			xe1410f585439c7d4.x80fb22e7844d1324();
		}
	}

	private void xc3a98ea651fcae41(int x77d17eeb695582c3, int x55ed5caacf5c2306, bool x490527f1272e27b8)
	{
		xe1410f585439c7d4.x6210059f049f0d48("(");
		xe1410f585439c7d4.x6210059f049f0d48(x77d17eeb695582c3);
		xe1410f585439c7d4.x6210059f049f0d48(",");
		xe1410f585439c7d4.x6210059f049f0d48(x55ed5caacf5c2306);
		xe1410f585439c7d4.x6210059f049f0d48(")");
		if (!x490527f1272e27b8)
		{
			xe1410f585439c7d4.x80fb22e7844d1324();
		}
	}
}
