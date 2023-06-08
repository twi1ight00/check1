using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[ComImport]
[Guid("000D073A-0000-0000-C000-000000000046")]
[CoClass(typeof(ValidationClass))]
public interface Validation : IVValidation
{
}
