using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[TypeLibType(16)]
[ComEventInterface(typeof(EShape_0000), typeof(EShape_EventProvider_0000))]
[ComVisible(false)]
public interface EShape_Event
{
	event EShape_CellChangedEventHandler CellChanged;

	event EShape_ShapeAddedEventHandler ShapeAdded;

	event EShape_BeforeSelectionDeleteEventHandler BeforeSelectionDelete;

	event EShape_ShapeChangedEventHandler ShapeChanged;

	event EShape_SelectionAddedEventHandler SelectionAdded;

	event EShape_BeforeShapeDeleteEventHandler BeforeShapeDelete;

	event EShape_TextChangedEventHandler TextChanged;

	event EShape_FormulaChangedEventHandler FormulaChanged;

	event EShape_ShapeParentChangedEventHandler ShapeParentChanged;

	event EShape_BeforeShapeTextEditEventHandler BeforeShapeTextEdit;

	event EShape_ShapeExitedTextEditEventHandler ShapeExitedTextEdit;

	event EShape_QueryCancelSelectionDeleteEventHandler QueryCancelSelectionDelete;

	event EShape_SelectionDeleteCanceledEventHandler SelectionDeleteCanceled;

	event EShape_QueryCancelUngroupEventHandler QueryCancelUngroup;

	event EShape_UngroupCanceledEventHandler UngroupCanceled;

	event EShape_QueryCancelConvertToGroupEventHandler QueryCancelConvertToGroup;

	event EShape_ConvertToGroupCanceledEventHandler ConvertToGroupCanceled;

	event EShape_QueryCancelGroupEventHandler QueryCancelGroup;

	event EShape_GroupCanceledEventHandler GroupCanceled;

	event EShape_ShapeDataGraphicChangedEventHandler ShapeDataGraphicChanged;

	event EShape_ShapeLinkAddedEventHandler ShapeLinkAdded;

	event EShape_ShapeLinkDeletedEventHandler ShapeLinkDeleted;
}
