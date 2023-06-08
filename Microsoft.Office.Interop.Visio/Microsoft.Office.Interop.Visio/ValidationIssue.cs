using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[ComImport]
[CoClass(typeof(ValidationIssueClass))]
[Guid("000D0740-0000-0000-C000-000000000046")]
public interface ValidationIssue : IVValidationIssue
{
}
