using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[TypeLibType(16)]
[ComVisible(false)]
[ComEventInterface(typeof(EMaster_0000), typeof(EMaster_EventProvider_0000))]
public interface EMaster_Event
{
	event EMaster_MasterChangedEventHandler MasterChanged;

	event EMaster_BeforeMasterDeleteEventHandler BeforeMasterDelete;

	event EMaster_ShapeAddedEventHandler ShapeAdded;

	event EMaster_BeforeSelectionDeleteEventHandler BeforeSelectionDelete;

	event EMaster_ShapeChangedEventHandler ShapeChanged;

	event EMaster_SelectionAddedEventHandler SelectionAdded;

	event EMaster_BeforeShapeDeleteEventHandler BeforeShapeDelete;

	event EMaster_TextChangedEventHandler TextChanged;

	event EMaster_CellChangedEventHandler CellChanged;

	event EMaster_FormulaChangedEventHandler FormulaChanged;

	event EMaster_ConnectionsAddedEventHandler ConnectionsAdded;

	event EMaster_ConnectionsDeletedEventHandler ConnectionsDeleted;

	event EMaster_QueryCancelMasterDeleteEventHandler QueryCancelMasterDelete;

	event EMaster_MasterDeleteCanceledEventHandler MasterDeleteCanceled;

	event EMaster_ShapeParentChangedEventHandler ShapeParentChanged;

	event EMaster_BeforeShapeTextEditEventHandler BeforeShapeTextEdit;

	event EMaster_ShapeExitedTextEditEventHandler ShapeExitedTextEdit;

	event EMaster_QueryCancelSelectionDeleteEventHandler QueryCancelSelectionDelete;

	event EMaster_SelectionDeleteCanceledEventHandler SelectionDeleteCanceled;

	event EMaster_QueryCancelUngroupEventHandler QueryCancelUngroup;

	event EMaster_UngroupCanceledEventHandler UngroupCanceled;

	event EMaster_QueryCancelConvertToGroupEventHandler QueryCancelConvertToGroup;

	event EMaster_ConvertToGroupCanceledEventHandler ConvertToGroupCanceled;

	event EMaster_QueryCancelGroupEventHandler QueryCancelGroup;

	event EMaster_GroupCanceledEventHandler GroupCanceled;

	event EMaster_ShapeDataGraphicChangedEventHandler ShapeDataGraphicChanged;
}
