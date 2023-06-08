using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[ComImport]
[Guid("000D0702-0000-0000-C000-000000000046")]
[CoClass(typeof(CharactersClass))]
public interface Characters : IVCharacters, ECharacters_Event
{
}
