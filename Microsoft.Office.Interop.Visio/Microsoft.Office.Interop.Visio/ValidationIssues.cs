using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[ComImport]
[CoClass(typeof(ValidationIssuesClass))]
[Guid("000D073F-0000-0000-C000-000000000046")]
public interface ValidationIssues : IVValidationIssues
{
}
