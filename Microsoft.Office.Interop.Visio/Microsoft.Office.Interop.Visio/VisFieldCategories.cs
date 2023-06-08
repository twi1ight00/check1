using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[Guid("000D0C1B-0000-0000-C000-000000000046")]
public enum VisFieldCategories
{
	visFCatCustom,
	visFCatDateTime,
	visFCatDocument,
	visFCatGeometry,
	visFCatObject,
	visFCatPage,
	[TypeLibVar(64)]
	visFCatNotes
}
