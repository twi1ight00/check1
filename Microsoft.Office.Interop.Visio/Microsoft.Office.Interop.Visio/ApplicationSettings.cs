using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[ComImport]
[CoClass(typeof(ApplicationSettingsClass))]
[Guid("000D072D-0000-0000-C000-000000000046")]
public interface ApplicationSettings : IVApplicationSettings
{
}
