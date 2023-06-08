using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[ComImport]
[CoClass(typeof(CommentsClass))]
[Guid("000D0743-0000-0000-C000-000000000046")]
public interface Comments : IVComments
{
}
