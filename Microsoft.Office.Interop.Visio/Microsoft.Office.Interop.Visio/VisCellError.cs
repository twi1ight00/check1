using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[Guid("000D0C10-0000-0000-C000-000000000046")]
public enum VisCellError
{
	visErrorSuccess = 0,
	visErrorDivideByZero = 39,
	visErrorValue = 47,
	visErrorReference = 55,
	visErrorName = 61,
	visErrorNumber = 68,
	visErrorNotAvailable = 74
}
