using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[Guid("000D0C1B-0000-0000-C000-000000000046")]
[TypeLibType(16)]
public enum tagVisFieldCategories
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
