using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[Guid("000D0C37-0000-0000-C000-000000000046")]
public enum VisSavePreviewMode
{
	visSavePreviewNone = 0,
	visSavePreviewDraft1st = 1,
	visSavePreviewDetailed1st = 2,
	[TypeLibVar(64)]
	visSavePreviewDraftAll = 4,
	[TypeLibVar(64)]
	visSavePreviewDetailedAll = 8
}
