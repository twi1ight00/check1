using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[TypeLibType(16)]
[Guid("000D0C10-0000-0000-C000-000000000046")]
public enum tagVisCellError
{
	visErrorSuccess = 0,
	visErrorDivideByZero = 39,
	visErrorValue = 47,
	visErrorReference = 55,
	visErrorName = 61,
	visErrorNumber = 68,
	visErrorNotAvailable = 74
}
