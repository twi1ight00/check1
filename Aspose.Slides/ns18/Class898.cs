using Aspose.Slides;
using ns24;
using ns56;

namespace ns18;

internal class Class898
{
	public static void smethod_0(IGroupShapeLock groupShapeLock, Class1860 groupLockingElementData)
	{
		if (groupLockingElementData != null)
		{
			smethod_5(groupShapeLock, groupLockingElementData.ExtLst);
			groupShapeLock.AspectRatioLocked = groupLockingElementData.NoChangeAspect;
			groupShapeLock.GroupingLocked = groupLockingElementData.NoGrp;
			groupShapeLock.PositionLocked = groupLockingElementData.NoMove;
			groupShapeLock.RotationLocked = groupLockingElementData.NoRot;
			groupShapeLock.SelectLocked = groupLockingElementData.NoSelect;
			groupShapeLock.SizeLocked = groupLockingElementData.NoResize;
			groupShapeLock.UngroupingLocked = groupLockingElementData.NoUngrp;
		}
	}

	public static void smethod_1(IAutoShapeLock shapeLock, Class1920 shapeLockingElementData)
	{
		if (shapeLockingElementData != null)
		{
			smethod_5(shapeLock, shapeLockingElementData.ExtLst);
			shapeLock.AdjustHandlesLocked = shapeLockingElementData.NoAdjustHandles;
			shapeLock.ArrowheadsLocked = shapeLockingElementData.NoChangeArrowheads;
			shapeLock.AspectRatioLocked = shapeLockingElementData.NoChangeAspect;
			shapeLock.ShapeTypeLocked = shapeLockingElementData.NoChangeShapeType;
			shapeLock.EditPointsLocked = shapeLockingElementData.NoEditPoints;
			shapeLock.GroupingLocked = shapeLockingElementData.NoGrp;
			shapeLock.PositionLocked = shapeLockingElementData.NoMove;
			shapeLock.SizeLocked = shapeLockingElementData.NoResize;
			shapeLock.RotateLocked = shapeLockingElementData.NoRot;
			shapeLock.SelectLocked = shapeLockingElementData.NoSelect;
			shapeLock.TextLocked = shapeLockingElementData.NoTextEdit;
		}
	}

	public static void smethod_2(IPictureFrameLock pictureFrameLock, Class1902 picLocksElementData)
	{
		if (picLocksElementData != null)
		{
			smethod_5(pictureFrameLock, picLocksElementData.ExtLst);
			pictureFrameLock.AdjustHandlesLocked = picLocksElementData.NoAdjustHandles;
			pictureFrameLock.ArrowheadsLocked = picLocksElementData.NoChangeArrowheads;
			pictureFrameLock.AspectRatioLocked = picLocksElementData.NoChangeAspect;
			pictureFrameLock.CropLocked = picLocksElementData.NoCrop;
			pictureFrameLock.EditPointsLocked = picLocksElementData.NoEditPoints;
			pictureFrameLock.GroupingLocked = picLocksElementData.NoGrp;
			pictureFrameLock.PositionLocked = picLocksElementData.NoMove;
			pictureFrameLock.RotationLocked = picLocksElementData.NoRot;
			pictureFrameLock.SelectLocked = picLocksElementData.NoSelect;
			pictureFrameLock.ShapeTypeLocked = picLocksElementData.NoChangeShapeType;
			pictureFrameLock.SizeLocked = picLocksElementData.NoResize;
		}
	}

	public static void smethod_3(IGraphicalObjectLock graphicShapeLock, Class1856 graphicLockingElementData)
	{
		if (graphicLockingElementData != null)
		{
			smethod_5(graphicShapeLock, graphicLockingElementData.ExtLst);
			graphicShapeLock.AspectRatioLocked = graphicLockingElementData.NoChangeAspect;
			graphicShapeLock.DrilldownLocked = graphicLockingElementData.NoDrilldown;
			graphicShapeLock.GroupingLocked = graphicLockingElementData.NoGrp;
			graphicShapeLock.PositionLocked = graphicLockingElementData.NoMove;
			graphicShapeLock.SelectLocked = graphicLockingElementData.NoSelect;
			graphicShapeLock.SizeLocked = graphicLockingElementData.NoResize;
		}
	}

	public static void smethod_4(IConnectorLock connectorLock, Class1825 cxnSpLocksElementData)
	{
		if (cxnSpLocksElementData != null)
		{
			smethod_5(connectorLock, cxnSpLocksElementData.ExtLst);
			connectorLock.AdjustHandlesLocked = cxnSpLocksElementData.NoAdjustHandles;
			connectorLock.ArrowheadsLocked = cxnSpLocksElementData.NoChangeArrowheads;
			connectorLock.AspectRatioLocked = cxnSpLocksElementData.NoChangeAspect;
			connectorLock.EditPointsLocked = cxnSpLocksElementData.NoEditPoints;
			connectorLock.GroupingLocked = cxnSpLocksElementData.NoGrp;
			connectorLock.PositionMove = cxnSpLocksElementData.NoMove;
			connectorLock.RotateLocked = cxnSpLocksElementData.NoRot;
			connectorLock.SelectLocked = cxnSpLocksElementData.NoSelect;
			connectorLock.ShapeTypeLocked = cxnSpLocksElementData.NoChangeShapeType;
			connectorLock.SizeLocked = cxnSpLocksElementData.NoResize;
		}
	}

	private static void smethod_5(IBaseShapeLock shapeLock, Class1885 extLst)
	{
		Class295 pPTXUnsupportedProps = ((BaseShapeLock)shapeLock).PPTXUnsupportedProps;
		pPTXUnsupportedProps.ExtensionList = extLst;
	}

	public static void smethod_6(GroupShapeLock groupShapeLock, Class1860.Delegate1459 addGrpSpLocks)
	{
		if (groupShapeLock == null)
		{
			return;
		}
		Class1885 extensionList = groupShapeLock.PPTXUnsupportedProps.ExtensionList;
		if (!groupShapeLock.NoLocks || extensionList != null)
		{
			Class1860 @class = addGrpSpLocks();
			if (!groupShapeLock.NoLocks)
			{
				@class.NoChangeAspect = groupShapeLock.AspectRatioLocked;
				@class.NoGrp = groupShapeLock.GroupingLocked;
				@class.NoMove = groupShapeLock.PositionLocked;
				@class.NoRot = groupShapeLock.RotationLocked;
				@class.NoSelect = groupShapeLock.SelectLocked;
				@class.NoResize = groupShapeLock.SizeLocked;
				@class.NoUngrp = groupShapeLock.UngroupingLocked;
			}
			@class.delegate1535_0(extensionList);
		}
	}

	public static void smethod_7(AutoShapeLock shapeLock, Class1920.Delegate1627 addSpLocks)
	{
		if (shapeLock == null)
		{
			return;
		}
		Class1885 extensionList = shapeLock.PPTXUnsupportedProps.ExtensionList;
		if (!shapeLock.NoLocks || extensionList != null)
		{
			Class1920 @class = addSpLocks();
			if (!shapeLock.NoLocks)
			{
				@class.NoAdjustHandles = shapeLock.AdjustHandlesLocked;
				@class.NoChangeArrowheads = shapeLock.ArrowheadsLocked;
				@class.NoChangeAspect = shapeLock.AspectRatioLocked;
				@class.NoChangeShapeType = shapeLock.ShapeTypeLocked;
				@class.NoEditPoints = shapeLock.EditPointsLocked;
				@class.NoGrp = shapeLock.GroupingLocked;
				@class.NoMove = shapeLock.PositionLocked;
				@class.NoResize = shapeLock.SizeLocked;
				@class.NoRot = shapeLock.RotateLocked;
				@class.NoSelect = shapeLock.SelectLocked;
				@class.NoTextEdit = shapeLock.TextLocked;
			}
			@class.delegate1535_0(extensionList);
		}
	}

	public static void smethod_8(GraphicalObjectLock graphicShapeLock, Class1856.Delegate1447 addGraphicFrameLocks)
	{
		if (graphicShapeLock == null)
		{
			return;
		}
		Class1885 extensionList = graphicShapeLock.PPTXUnsupportedProps.ExtensionList;
		if (!graphicShapeLock.NoLocks || extensionList != null)
		{
			Class1856 @class = addGraphicFrameLocks();
			if (!graphicShapeLock.NoLocks)
			{
				@class.NoChangeAspect = graphicShapeLock.AspectRatioLocked;
				@class.NoDrilldown = graphicShapeLock.DrilldownLocked;
				@class.NoGrp = graphicShapeLock.GroupingLocked;
				@class.NoMove = graphicShapeLock.PositionLocked;
				@class.NoSelect = graphicShapeLock.SelectLocked;
				@class.NoResize = graphicShapeLock.SizeLocked;
			}
			@class.delegate1535_0(extensionList);
		}
	}

	public static void smethod_9(ConnectorLock connectorLock, Class1825.Delegate1354 addConnectorLock)
	{
		if (connectorLock == null)
		{
			return;
		}
		Class1885 extensionList = connectorLock.PPTXUnsupportedProps.ExtensionList;
		if (!connectorLock.NoLocks || extensionList != null)
		{
			Class1825 @class = addConnectorLock();
			if (!connectorLock.NoLocks)
			{
				@class.NoAdjustHandles = connectorLock.AdjustHandlesLocked;
				@class.NoChangeArrowheads = connectorLock.ArrowheadsLocked;
				@class.NoChangeAspect = connectorLock.AspectRatioLocked;
				@class.NoEditPoints = connectorLock.EditPointsLocked;
				@class.NoGrp = connectorLock.GroupingLocked;
				@class.NoMove = connectorLock.PositionMove;
				@class.NoRot = connectorLock.RotateLocked;
				@class.NoSelect = connectorLock.SelectLocked;
				@class.NoChangeShapeType = connectorLock.ShapeTypeLocked;
				@class.NoResize = connectorLock.SizeLocked;
			}
			@class.delegate1535_0(extensionList);
		}
	}

	public static void smethod_10(PictureFrameLock pictureFrameLock, Class1902.Delegate1573 addPicLocks)
	{
		if (pictureFrameLock == null)
		{
			return;
		}
		Class1885 extensionList = pictureFrameLock.PPTXUnsupportedProps.ExtensionList;
		if (!pictureFrameLock.NoLocks || extensionList != null)
		{
			Class1902 @class = addPicLocks();
			if (!pictureFrameLock.NoLocks)
			{
				@class.NoAdjustHandles = pictureFrameLock.AdjustHandlesLocked;
				@class.NoChangeArrowheads = pictureFrameLock.ArrowheadsLocked;
				@class.NoChangeAspect = pictureFrameLock.AspectRatioLocked;
				@class.NoCrop = pictureFrameLock.CropLocked;
				@class.NoEditPoints = pictureFrameLock.EditPointsLocked;
				@class.NoGrp = pictureFrameLock.GroupingLocked;
				@class.NoMove = pictureFrameLock.PositionLocked;
				@class.NoRot = pictureFrameLock.RotationLocked;
				@class.NoSelect = pictureFrameLock.SelectLocked;
				@class.NoChangeShapeType = pictureFrameLock.ShapeTypeLocked;
				@class.NoResize = pictureFrameLock.SizeLocked;
			}
			@class.delegate1535_0(extensionList);
		}
	}
}
