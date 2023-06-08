using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[Guid("000D0C82-0000-0000-C000-000000000046")]
public enum VisUICtrlTypes
{
	visCtrlTypeBUTTON = 2,
	visCtrlTypeBUTTON_OWNERDRAW = 33,
	[TypeLibVar(64)]
	visCtrlTypeOWNERDRAW_BUTTON = 33,
	visCtrlTypeSPLITBUTTON = 17,
	[TypeLibVar(64)]
	visCtrlTypePALETTEBUTTONNOMRU = 17,
	visCtrlTypeSPLITBUTTON_MRU_COLOR = 16,
	[TypeLibVar(64)]
	visCtrlTypePALETTEBUTTON = 16,
	[TypeLibVar(64)]
	visCtrlTypeSPINBUTTON = 16,
	visCtrlTypeSPLITBUTTON_MRU_COMMAND = 18,
	[TypeLibVar(64)]
	visCtrlTypePALETTEBUTTONICON = 18,
	visCtrlTypeEDITBOX = 64,
	visCtrlTypeCOMBOBOX = 128,
	[TypeLibVar(64)]
	visCtrlTypeCOMBOBOX_SORTED = 129,
	visCtrlTypeDROPDOWN = 272,
	[TypeLibVar(64)]
	visCtrlTypeDROPDOWN_SORTED = 273,
	[TypeLibVar(64)]
	visCtrlTypeDROPDOWN_OWNERDRAW = 256,
	[TypeLibVar(64)]
	visCtrlTypeCOMBODRAW = 256,
	[TypeLibVar(64)]
	visCtrlTypeDROPDOWN_SORTED_OWNERDRAW = 257,
	visCtrlTypeLABEL = 2048,
	[TypeLibVar(64)]
	visCtrlTypeSWATCH = 32768,
	[TypeLibVar(64)]
	visCtrlTypeSWATCH_COLORS = 32769,
	[TypeLibVar(64)]
	visCtrlTypeEND = 0,
	[TypeLibVar(64)]
	visCtrlTypeSTATE = 1,
	[TypeLibVar(64)]
	visCtrlTypeSTATE_BUTTON = 3,
	[TypeLibVar(64)]
	visCtrlTypeHIERBUTTON = 4,
	[TypeLibVar(64)]
	visCtrlTypeSTATE_HIERBUTTON = 5,
	[TypeLibVar(64)]
	visCtrlTypeDROPBUTTON = 8,
	[TypeLibVar(64)]
	visCtrlTypeSTATE_DROPBUTTON = 9,
	[TypeLibVar(64)]
	visCtrlTypePUSHBUTTON = 32,
	[TypeLibVar(64)]
	visCtrlTypeLISTBOX = 512,
	[TypeLibVar(64)]
	visCtrlTypeLISTBOXDRAW = 513,
	[TypeLibVar(64)]
	visCtrlTypeCOLORBOX = 1024,
	[TypeLibVar(64)]
	visCtrlTypeMESSAGE = 4096,
	[TypeLibVar(64)]
	visCtrlTypeSPACER = 16384
}
