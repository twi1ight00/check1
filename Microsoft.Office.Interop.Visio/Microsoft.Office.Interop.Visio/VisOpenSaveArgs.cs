using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[Guid("000D0C0A-0000-0000-C000-000000000046")]
public enum VisOpenSaveArgs
{
	visOpenCopy = 1,
	visOpenRO = 2,
	visOpenDocked = 4,
	visOpenDontList = 8,
	visOpenMinimized = 16,
	visOpenRW = 32,
	visOpenHidden = 64,
	visOpenMacrosDisabled = 128,
	visOpenNoWorkspace = 256,
	visOpenDeclineAutoRefresh = 1024,
	visOpenCopyOfNaming = 2048,
	visAddDocked = 4,
	visAddMinimized = 16,
	visAddHidden = 64,
	visAddMacrosDisabled = 128,
	visAddNoWorkspace = 256,
	visAddStencil = 512,
	visAddDeclineAutoRefresh = 1024,
	visSaveAsRO = 1,
	visSaveAsWS = 2,
	visSaveAsListInMRU = 4,
	visSaveAsCheckCompatibility = 8,
	[TypeLibVar(64)]
	visSavePrevNone = 0,
	[TypeLibVar(64)]
	visSavePrevDraft1st = 1,
	[TypeLibVar(64)]
	visSavePrevDetailed1st = 2,
	[TypeLibVar(64)]
	visSavePrevDraftAll = 4,
	[TypeLibVar(64)]
	visSavePrevDetailedAll = 8
}
