using System;
using Aspose.Slides;
using ns62;

namespace ns15;

internal class Class858
{
	public static void smethod_0(IBaseShapeLock shapeLock, Class2834 odrawFopt)
	{
		if (odrawFopt == null || !odrawFopt.Properties.Contains(Enum426.const_404))
		{
			return;
		}
		Class2924 @class = (Class2924)odrawFopt.Properties[Enum426.const_404];
		if (shapeLock is IGroupShapeLock)
		{
			IGroupShapeLock groupShapeLock = (IGroupShapeLock)shapeLock;
			groupShapeLock.AspectRatioLocked = @class.CfUsefLockAspectRatio && @class.MfLockAspectRatio;
			groupShapeLock.GroupingLocked = @class.JfUsefLockAgainstGrouping && @class.TfLockAgainstGrouping;
			groupShapeLock.PositionLocked = @class.DfUsefLockPosition && @class.NfLockPosition;
			groupShapeLock.RotationLocked = @class.BfUsefLockRotation && @class.LfLockRotation;
			groupShapeLock.SelectLocked = @class.EfUsefLockAgainstSelect && @class.OfLockAgainstSelect;
			groupShapeLock.SizeLocked = false;
			groupShapeLock.UngroupingLocked = @class.AfUsefLockAgainstUngrouping && @class.KfLockAgainstUngrouping;
		}
		else if (shapeLock is IAutoShapeLock)
		{
			IAutoShapeLock autoShapeLock = (IAutoShapeLock)shapeLock;
			autoShapeLock.AdjustHandlesLocked = @class.IfUsefLockAdjustHandles && @class.SfLockAdjustHandles;
			autoShapeLock.ArrowheadsLocked = false;
			autoShapeLock.AspectRatioLocked = @class.CfUsefLockAspectRatio && @class.MfLockAspectRatio;
			autoShapeLock.ShapeTypeLocked = false;
			autoShapeLock.EditPointsLocked = @class.GfUsefLockVertices && @class.QfLockVertices;
			autoShapeLock.GroupingLocked = @class.JfUsefLockAgainstGrouping && @class.TfLockAgainstGrouping;
			autoShapeLock.PositionLocked = @class.DfUsefLockPosition && @class.NfLockPosition;
			autoShapeLock.SizeLocked = false;
			autoShapeLock.RotateLocked = @class.BfUsefLockRotation && @class.LfLockRotation;
			autoShapeLock.SelectLocked = @class.EfUsefLockAgainstSelect && @class.OfLockAgainstSelect;
			autoShapeLock.TextLocked = @class.HfUsefLockText && @class.RfLockText;
		}
		else if (shapeLock is IPictureFrameLock)
		{
			IPictureFrameLock pictureFrameLock = (IPictureFrameLock)shapeLock;
			pictureFrameLock.AdjustHandlesLocked = @class.IfUsefLockAdjustHandles && @class.SfLockAdjustHandles;
			pictureFrameLock.ArrowheadsLocked = false;
			pictureFrameLock.AspectRatioLocked = @class.CfUsefLockAspectRatio && @class.MfLockAspectRatio;
			pictureFrameLock.CropLocked = @class.FfUsefLockCropping && @class.PfLockCropping;
			pictureFrameLock.EditPointsLocked = @class.GfUsefLockVertices && @class.QfLockVertices;
			pictureFrameLock.GroupingLocked = @class.JfUsefLockAgainstGrouping && @class.TfLockAgainstGrouping;
			pictureFrameLock.PositionLocked = @class.DfUsefLockPosition && @class.NfLockPosition;
			pictureFrameLock.RotationLocked = @class.BfUsefLockRotation && @class.LfLockRotation;
			pictureFrameLock.SelectLocked = @class.EfUsefLockAgainstSelect && @class.OfLockAgainstSelect;
			pictureFrameLock.ShapeTypeLocked = false;
			pictureFrameLock.SizeLocked = false;
		}
		else if (shapeLock is IGraphicalObjectLock)
		{
			IGraphicalObjectLock graphicalObjectLock = (IGraphicalObjectLock)shapeLock;
			graphicalObjectLock.AspectRatioLocked = @class.CfUsefLockAspectRatio && @class.MfLockAspectRatio;
			graphicalObjectLock.DrilldownLocked = false;
			graphicalObjectLock.GroupingLocked = @class.JfUsefLockAgainstGrouping && @class.TfLockAgainstGrouping;
			graphicalObjectLock.PositionLocked = @class.DfUsefLockPosition && @class.NfLockPosition;
			graphicalObjectLock.SelectLocked = @class.EfUsefLockAgainstSelect && @class.OfLockAgainstSelect;
			graphicalObjectLock.SizeLocked = false;
		}
		else
		{
			if (!(shapeLock is IConnectorLock))
			{
				throw new Exception();
			}
			IConnectorLock connectorLock = (IConnectorLock)shapeLock;
			connectorLock.AdjustHandlesLocked = @class.IfUsefLockAdjustHandles && @class.SfLockAdjustHandles;
			connectorLock.ArrowheadsLocked = false;
			connectorLock.AspectRatioLocked = @class.CfUsefLockAspectRatio && @class.MfLockAspectRatio;
			connectorLock.EditPointsLocked = @class.GfUsefLockVertices && @class.QfLockVertices;
			connectorLock.GroupingLocked = @class.JfUsefLockAgainstGrouping && @class.TfLockAgainstGrouping;
			connectorLock.PositionMove = @class.DfUsefLockPosition && @class.NfLockPosition;
			connectorLock.RotateLocked = @class.BfUsefLockRotation && @class.LfLockRotation;
			connectorLock.SelectLocked = @class.EfUsefLockAgainstSelect && @class.OfLockAgainstSelect;
			connectorLock.ShapeTypeLocked = false;
			connectorLock.SizeLocked = false;
		}
		((BaseShapeLock)shapeLock).PPTUnsupportedProps.EsProtectionFlagsProperty = @class;
	}

	public static void smethod_1(IShape shape, Class2834 odrawFopt)
	{
		if (shape is IGroupShape)
		{
			smethod_2(((IGroupShape)shape).ShapeLock, odrawFopt);
		}
		else if (shape is IAutoShape)
		{
			smethod_2(((IAutoShape)shape).ShapeLock, odrawFopt);
		}
		else if (shape is IPictureFrame)
		{
			smethod_2(((IPictureFrame)shape).ShapeLock, odrawFopt);
		}
		else if (shape is IGraphicalObject)
		{
			smethod_2(((IGraphicalObject)shape).ShapeLock, odrawFopt);
		}
		else if (shape is IConnector)
		{
			smethod_2(((IConnector)shape).ShapeLock, odrawFopt);
		}
	}

	public static void smethod_2(IBaseShapeLock shapeLock, Class2834 odrawFopt)
	{
		if (shapeLock == null)
		{
			return;
		}
		Class2924 @class = ((BaseShapeLock)shapeLock).PPTUnsupportedProps.EsProtectionFlagsProperty;
		if (@class == null)
		{
			@class = new Class2924();
		}
		if (shapeLock.NoLocks && @class.Value == 0)
		{
			return;
		}
		odrawFopt.Properties.method_0(@class);
		if (shapeLock is IGroupShapeLock)
		{
			IGroupShapeLock groupShapeLock = (IGroupShapeLock)shapeLock;
			Class2924 class2 = @class;
			int mfLockAspectRatio;
			if (!groupShapeLock.AspectRatioLocked)
			{
				mfLockAspectRatio = 0;
			}
			else
			{
				@class.CfUsefLockAspectRatio = true;
				mfLockAspectRatio = 1;
			}
			class2.MfLockAspectRatio = (byte)mfLockAspectRatio != 0;
			Class2924 class3 = @class;
			int tfLockAgainstGrouping;
			if (!groupShapeLock.GroupingLocked)
			{
				tfLockAgainstGrouping = 0;
			}
			else
			{
				@class.JfUsefLockAgainstGrouping = true;
				tfLockAgainstGrouping = 1;
			}
			class3.TfLockAgainstGrouping = (byte)tfLockAgainstGrouping != 0;
			Class2924 class4 = @class;
			int nfLockPosition;
			if (!groupShapeLock.PositionLocked)
			{
				nfLockPosition = 0;
			}
			else
			{
				@class.DfUsefLockPosition = true;
				nfLockPosition = 1;
			}
			class4.NfLockPosition = (byte)nfLockPosition != 0;
			Class2924 class5 = @class;
			int lfLockRotation;
			if (!groupShapeLock.RotationLocked)
			{
				lfLockRotation = 0;
			}
			else
			{
				@class.BfUsefLockRotation = true;
				lfLockRotation = 1;
			}
			class5.LfLockRotation = (byte)lfLockRotation != 0;
			Class2924 class6 = @class;
			int ofLockAgainstSelect;
			if (!groupShapeLock.SelectLocked)
			{
				ofLockAgainstSelect = 0;
			}
			else
			{
				@class.EfUsefLockAgainstSelect = true;
				ofLockAgainstSelect = 1;
			}
			class6.OfLockAgainstSelect = (byte)ofLockAgainstSelect != 0;
			Class2924 class7 = @class;
			int kfLockAgainstUngrouping;
			if (!groupShapeLock.UngroupingLocked)
			{
				kfLockAgainstUngrouping = 0;
			}
			else
			{
				@class.AfUsefLockAgainstUngrouping = true;
				kfLockAgainstUngrouping = 1;
			}
			class7.KfLockAgainstUngrouping = (byte)kfLockAgainstUngrouping != 0;
		}
		else if (shapeLock is IAutoShapeLock)
		{
			IAutoShapeLock autoShapeLock = (IAutoShapeLock)shapeLock;
			Class2924 class8 = @class;
			int sfLockAdjustHandles;
			if (!autoShapeLock.AdjustHandlesLocked)
			{
				sfLockAdjustHandles = 0;
			}
			else
			{
				@class.IfUsefLockAdjustHandles = true;
				sfLockAdjustHandles = 1;
			}
			class8.SfLockAdjustHandles = (byte)sfLockAdjustHandles != 0;
			Class2924 class9 = @class;
			int mfLockAspectRatio2;
			if (!autoShapeLock.AspectRatioLocked)
			{
				mfLockAspectRatio2 = 0;
			}
			else
			{
				@class.CfUsefLockAspectRatio = true;
				mfLockAspectRatio2 = 1;
			}
			class9.MfLockAspectRatio = (byte)mfLockAspectRatio2 != 0;
			Class2924 class10 = @class;
			int qfLockVertices;
			if (!autoShapeLock.EditPointsLocked)
			{
				qfLockVertices = 0;
			}
			else
			{
				@class.GfUsefLockVertices = true;
				qfLockVertices = 1;
			}
			class10.QfLockVertices = (byte)qfLockVertices != 0;
			Class2924 class11 = @class;
			int tfLockAgainstGrouping2;
			if (!autoShapeLock.GroupingLocked)
			{
				tfLockAgainstGrouping2 = 0;
			}
			else
			{
				@class.JfUsefLockAgainstGrouping = true;
				tfLockAgainstGrouping2 = 1;
			}
			class11.TfLockAgainstGrouping = (byte)tfLockAgainstGrouping2 != 0;
			Class2924 class12 = @class;
			int nfLockPosition2;
			if (!autoShapeLock.PositionLocked)
			{
				nfLockPosition2 = 0;
			}
			else
			{
				@class.DfUsefLockPosition = true;
				nfLockPosition2 = 1;
			}
			class12.NfLockPosition = (byte)nfLockPosition2 != 0;
			Class2924 class13 = @class;
			int lfLockRotation2;
			if (!autoShapeLock.RotateLocked)
			{
				lfLockRotation2 = 0;
			}
			else
			{
				@class.BfUsefLockRotation = true;
				lfLockRotation2 = 1;
			}
			class13.LfLockRotation = (byte)lfLockRotation2 != 0;
			Class2924 class14 = @class;
			int ofLockAgainstSelect2;
			if (!autoShapeLock.SelectLocked)
			{
				ofLockAgainstSelect2 = 0;
			}
			else
			{
				@class.EfUsefLockAgainstSelect = true;
				ofLockAgainstSelect2 = 1;
			}
			class14.OfLockAgainstSelect = (byte)ofLockAgainstSelect2 != 0;
			Class2924 class15 = @class;
			int rfLockText;
			if (!autoShapeLock.TextLocked)
			{
				rfLockText = 0;
			}
			else
			{
				@class.HfUsefLockText = true;
				rfLockText = 1;
			}
			class15.RfLockText = (byte)rfLockText != 0;
		}
		else if (shapeLock is IPictureFrameLock)
		{
			IPictureFrameLock pictureFrameLock = (IPictureFrameLock)shapeLock;
			Class2924 class16 = @class;
			int sfLockAdjustHandles2;
			if (!pictureFrameLock.AdjustHandlesLocked)
			{
				sfLockAdjustHandles2 = 0;
			}
			else
			{
				@class.IfUsefLockAdjustHandles = true;
				sfLockAdjustHandles2 = 1;
			}
			class16.SfLockAdjustHandles = (byte)sfLockAdjustHandles2 != 0;
			Class2924 class17 = @class;
			int mfLockAspectRatio3;
			if (!pictureFrameLock.AspectRatioLocked)
			{
				mfLockAspectRatio3 = 0;
			}
			else
			{
				@class.CfUsefLockAspectRatio = true;
				mfLockAspectRatio3 = 1;
			}
			class17.MfLockAspectRatio = (byte)mfLockAspectRatio3 != 0;
			Class2924 class18 = @class;
			int pfLockCropping;
			if (!pictureFrameLock.CropLocked)
			{
				pfLockCropping = 0;
			}
			else
			{
				@class.FfUsefLockCropping = true;
				pfLockCropping = 1;
			}
			class18.PfLockCropping = (byte)pfLockCropping != 0;
			Class2924 class19 = @class;
			int qfLockVertices2;
			if (!pictureFrameLock.EditPointsLocked)
			{
				qfLockVertices2 = 0;
			}
			else
			{
				@class.GfUsefLockVertices = true;
				qfLockVertices2 = 1;
			}
			class19.QfLockVertices = (byte)qfLockVertices2 != 0;
			Class2924 class20 = @class;
			int tfLockAgainstGrouping3;
			if (!pictureFrameLock.GroupingLocked)
			{
				tfLockAgainstGrouping3 = 0;
			}
			else
			{
				@class.JfUsefLockAgainstGrouping = true;
				tfLockAgainstGrouping3 = 1;
			}
			class20.TfLockAgainstGrouping = (byte)tfLockAgainstGrouping3 != 0;
			Class2924 class21 = @class;
			int nfLockPosition3;
			if (!pictureFrameLock.PositionLocked)
			{
				nfLockPosition3 = 0;
			}
			else
			{
				@class.DfUsefLockPosition = true;
				nfLockPosition3 = 1;
			}
			class21.NfLockPosition = (byte)nfLockPosition3 != 0;
			Class2924 class22 = @class;
			int lfLockRotation3;
			if (!pictureFrameLock.RotationLocked)
			{
				lfLockRotation3 = 0;
			}
			else
			{
				@class.BfUsefLockRotation = true;
				lfLockRotation3 = 1;
			}
			class22.LfLockRotation = (byte)lfLockRotation3 != 0;
			Class2924 class23 = @class;
			int ofLockAgainstSelect3;
			if (!pictureFrameLock.SelectLocked)
			{
				ofLockAgainstSelect3 = 0;
			}
			else
			{
				@class.EfUsefLockAgainstSelect = true;
				ofLockAgainstSelect3 = 1;
			}
			class23.OfLockAgainstSelect = (byte)ofLockAgainstSelect3 != 0;
		}
		else if (shapeLock is IGraphicalObjectLock)
		{
			IGraphicalObjectLock graphicalObjectLock = (IGraphicalObjectLock)shapeLock;
			Class2924 class24 = @class;
			int mfLockAspectRatio4;
			if (!graphicalObjectLock.AspectRatioLocked)
			{
				mfLockAspectRatio4 = 0;
			}
			else
			{
				@class.CfUsefLockAspectRatio = true;
				mfLockAspectRatio4 = 1;
			}
			class24.MfLockAspectRatio = (byte)mfLockAspectRatio4 != 0;
			Class2924 class25 = @class;
			int tfLockAgainstGrouping4;
			if (!graphicalObjectLock.GroupingLocked)
			{
				tfLockAgainstGrouping4 = 0;
			}
			else
			{
				@class.JfUsefLockAgainstGrouping = true;
				tfLockAgainstGrouping4 = 1;
			}
			class25.TfLockAgainstGrouping = (byte)tfLockAgainstGrouping4 != 0;
			Class2924 class26 = @class;
			int nfLockPosition4;
			if (!graphicalObjectLock.PositionLocked)
			{
				nfLockPosition4 = 0;
			}
			else
			{
				@class.DfUsefLockPosition = true;
				nfLockPosition4 = 1;
			}
			class26.NfLockPosition = (byte)nfLockPosition4 != 0;
			Class2924 class27 = @class;
			int ofLockAgainstSelect4;
			if (!graphicalObjectLock.SelectLocked)
			{
				ofLockAgainstSelect4 = 0;
			}
			else
			{
				@class.EfUsefLockAgainstSelect = true;
				ofLockAgainstSelect4 = 1;
			}
			class27.OfLockAgainstSelect = (byte)ofLockAgainstSelect4 != 0;
		}
		else
		{
			if (!(shapeLock is IConnectorLock))
			{
				throw new Exception();
			}
			IConnectorLock connectorLock = (IConnectorLock)shapeLock;
			Class2924 class28 = @class;
			int sfLockAdjustHandles3;
			if (!connectorLock.AdjustHandlesLocked)
			{
				sfLockAdjustHandles3 = 0;
			}
			else
			{
				@class.IfUsefLockAdjustHandles = true;
				sfLockAdjustHandles3 = 1;
			}
			class28.SfLockAdjustHandles = (byte)sfLockAdjustHandles3 != 0;
			Class2924 class29 = @class;
			int mfLockAspectRatio5;
			if (!connectorLock.AspectRatioLocked)
			{
				mfLockAspectRatio5 = 0;
			}
			else
			{
				@class.CfUsefLockAspectRatio = true;
				mfLockAspectRatio5 = 1;
			}
			class29.MfLockAspectRatio = (byte)mfLockAspectRatio5 != 0;
			Class2924 class30 = @class;
			int qfLockVertices3;
			if (!connectorLock.EditPointsLocked)
			{
				qfLockVertices3 = 0;
			}
			else
			{
				@class.GfUsefLockVertices = true;
				qfLockVertices3 = 1;
			}
			class30.QfLockVertices = (byte)qfLockVertices3 != 0;
			Class2924 class31 = @class;
			int tfLockAgainstGrouping5;
			if (!connectorLock.GroupingLocked)
			{
				tfLockAgainstGrouping5 = 0;
			}
			else
			{
				@class.JfUsefLockAgainstGrouping = true;
				tfLockAgainstGrouping5 = 1;
			}
			class31.TfLockAgainstGrouping = (byte)tfLockAgainstGrouping5 != 0;
			Class2924 class32 = @class;
			int nfLockPosition5;
			if (!connectorLock.PositionMove)
			{
				nfLockPosition5 = 0;
			}
			else
			{
				@class.DfUsefLockPosition = true;
				nfLockPosition5 = 1;
			}
			class32.NfLockPosition = (byte)nfLockPosition5 != 0;
			Class2924 class33 = @class;
			int lfLockRotation4;
			if (!connectorLock.RotateLocked)
			{
				lfLockRotation4 = 0;
			}
			else
			{
				@class.BfUsefLockRotation = true;
				lfLockRotation4 = 1;
			}
			class33.LfLockRotation = (byte)lfLockRotation4 != 0;
			Class2924 class34 = @class;
			int ofLockAgainstSelect5;
			if (!connectorLock.SelectLocked)
			{
				ofLockAgainstSelect5 = 0;
			}
			else
			{
				@class.EfUsefLockAgainstSelect = true;
				ofLockAgainstSelect5 = 1;
			}
			class34.OfLockAgainstSelect = (byte)ofLockAgainstSelect5 != 0;
		}
	}
}
