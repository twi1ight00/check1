using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[Guid("000D0C49-0000-0000-C000-000000000046")]
public enum VisDefaultSaveFormats
{
	visDefaultSaveCurrent = 0,
	[TypeLibVar(64)]
	visDefaultSaveCurrentBinary = 0,
	visDefaultSavePreviousBinary = 1,
	[TypeLibVar(64)]
	visDefaultSaveCurrentXML = 2,
	visDefaultSaveCurrentMacroEnabled = 3
}
