using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[ComImport]
[Guid("000D0705-0000-0000-C000-000000000046")]
[CoClass(typeof(DocumentClass))]
public interface Document : IVDocument, EDocument_Event
{
}
