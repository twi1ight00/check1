using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[Guid("000D0C0C-0000-0000-C000-000000000046")]
public enum VisGetSetArgs
{
	visGetFloats = 0,
	visGetTruncatedInts = 1,
	visGetRoundedInts = 2,
	visGetStrings = 3,
	visGetFormulas = 4,
	visGetFormulasU = 5,
	visSetFormulas = 1,
	visSetBlastGuards = 2,
	visSetTestCircular = 4,
	visSetUniversalSyntax = 8
}
