using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[ComImport]
[CoClass(typeof(CommentClass))]
[Guid("000D0744-0000-0000-C000-000000000046")]
public interface Comment : IVComment
{
}
