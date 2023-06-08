using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[Guid("000D0C41-0000-0000-C000-000000000046")]
public enum VisSelectionTypes
{
	visSelTypeEmpty,
	visSelTypeAll,
	visSelTypeSingle,
	visSelTypeByLayer,
	visSelTypeByType,
	visSelTypeByMaster,
	visSelTypeByDataGraphic,
	visSelTypeByRole
}
