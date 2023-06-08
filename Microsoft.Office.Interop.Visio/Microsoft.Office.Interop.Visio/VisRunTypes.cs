using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[Guid("000D0C12-0000-0000-C000-000000000046")]
public enum VisRunTypes
{
	visCharPropRow = 1,
	visParaPropRow = 2,
	visTabPropRow = 3,
	visWordRun = 10,
	visParaRun = 11,
	visFieldRun = 20
}
