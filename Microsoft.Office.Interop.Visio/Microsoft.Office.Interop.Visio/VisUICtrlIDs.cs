using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[Guid("000D0C85-0000-0000-C000-000000000046")]
[TypeLibType(16)]
public enum VisUICtrlIDs
{
	[TypeLibVar(64)]
	visCtrlIDNEW = 8383,
	[TypeLibVar(64)]
	visCtrlIDOPEN = 1,
	[TypeLibVar(64)]
	visCtrlIDOPENSTEN = 2,
	[TypeLibVar(64)]
	visCtrlIDSAVE = 3,
	[TypeLibVar(64)]
	visCtrlIDPRINT = 4,
	[TypeLibVar(64)]
	visCtrlIDPREVIEW = 5,
	[TypeLibVar(64)]
	visCtrlIDCUT = 6,
	[TypeLibVar(64)]
	visCtrlIDCOPY = 7,
	[TypeLibVar(64)]
	visCtrlIDPASTE = 8,
	[TypeLibVar(64)]
	visCtrlIDCLEAR = 9,
	[TypeLibVar(64)]
	visCtrlIDUNDO = 10,
	[TypeLibVar(64)]
	visCtrlIDREDO = 11,
	[TypeLibVar(64)]
	visCtrlIDREPEAT = 12,
	[TypeLibVar(64)]
	visCtrlIDPREVIOUSPAGE = 13,
	[TypeLibVar(64)]
	visCtrlIDNEXTPAGE = 14,
	[TypeLibVar(64)]
	visCtrlIDZOOMOUT = 15,
	[TypeLibVar(64)]
	visCtrlIDZOOMIN = 16,
	[TypeLibVar(64)]
	visCtrlIDZOOM100 = 17,
	[TypeLibVar(64)]
	visCtrlIDFLIPHORZ = 18,
	[TypeLibVar(64)]
	visCtrlIDFLIPVERT = 19,
	[TypeLibVar(64)]
	visCtrlIDPOINTERTOOL = 20,
	[TypeLibVar(64)]
	visCtrlIDPENCILTOOL = 21,
	[TypeLibVar(64)]
	visCtrlIDLINETOOL = 22,
	[TypeLibVar(64)]
	visCtrlIDQTRARCTOOL = 23,
	[TypeLibVar(64)]
	visCtrlIDRECTTOOL = 24,
	[TypeLibVar(64)]
	visCtrlIDOVALTOOL = 25,
	[TypeLibVar(64)]
	visCtrlIDSTAMPTOOL = 26,
	[TypeLibVar(64)]
	visCtrlIDTEXTTOOL = 27,
	[TypeLibVar(64)]
	visCtrlIDROTATETOOL = 28,
	[TypeLibVar(64)]
	visCtrlIDCROPTOOL = 29,
	[TypeLibVar(64)]
	visCtrlIDCONNECTIONPTTOOL = 30,
	[TypeLibVar(64)]
	visCtrlIDSNAP = 31,
	[TypeLibVar(64)]
	visCtrlIDGLUE = 32,
	[TypeLibVar(64)]
	visCtrlIDRULER = 33,
	[TypeLibVar(64)]
	visCtrlIDGRID = 34,
	[TypeLibVar(64)]
	visCtrlIDGUIDE = 35,
	[TypeLibVar(64)]
	visCtrlIDCONNECT = 36,
	[TypeLibVar(64)]
	visCtrlIDROTATECLOCKWISE = 37,
	[TypeLibVar(64)]
	visCtrlIDROTATECOUNTER = 38,
	[TypeLibVar(64)]
	visCtrlIDNEWWINDOW = 39,
	[TypeLibVar(64)]
	visCtrlIDCORNERSTYLE = 40,
	[TypeLibVar(64)]
	visCtrlIDLINEEND = 41,
	[TypeLibVar(64)]
	visCtrlIDSHADOWSTYLE = 42,
	[TypeLibVar(64)]
	visCtrlIDFILLCOLOR = 43,
	[TypeLibVar(64)]
	visCtrlIDLINECOLOR = 44,
	[TypeLibVar(64)]
	visCtrlIDLINEWEIGHT = 45,
	[TypeLibVar(64)]
	visCtrlIDLINEPATTERN = 46,
	[TypeLibVar(64)]
	visCtrlIDFILLPATTERN = 47,
	[TypeLibVar(64)]
	visCtrlIDPOINTSIZEDOWN = 48,
	[TypeLibVar(64)]
	visCtrlIDPOINTSIZEUP = 49,
	[TypeLibVar(64)]
	visCtrlIDBOLD = 50,
	[TypeLibVar(64)]
	visCtrlIDITALIC = 51,
	[TypeLibVar(64)]
	visCtrlIDULINE = 52,
	[TypeLibVar(64)]
	visCtrlIDSUPERSCRIPT = 53,
	[TypeLibVar(64)]
	visCtrlIDSUBSCRIPT = 54,
	[TypeLibVar(64)]
	visCtrlIDTEXTCOLOR = 55,
	[TypeLibVar(64)]
	visCtrlIDTEXTLEFT = 56,
	[TypeLibVar(64)]
	visCtrlIDTEXTCENTER = 57,
	[TypeLibVar(64)]
	visCtrlIDTEXTRIGHT = 58,
	[TypeLibVar(64)]
	visCtrlIDTEXTJUSTIFY = 59,
	[TypeLibVar(64)]
	visCtrlIDTEXTTOP = 60,
	[TypeLibVar(64)]
	visCtrlIDTEXTMIDDLE = 61,
	[TypeLibVar(64)]
	visCtrlIDTEXTBOTTOM = 62,
	[TypeLibVar(64)]
	visCtrlIDALIGN = 63,
	[TypeLibVar(64)]
	visCtrlIDALIGNLEFT = 64,
	[TypeLibVar(64)]
	visCtrlIDALIGNCENTER = 65,
	[TypeLibVar(64)]
	visCtrlIDALIGNRIGHT = 66,
	[TypeLibVar(64)]
	visCtrlIDALIGNTOP = 67,
	[TypeLibVar(64)]
	visCtrlIDALIGNMIDDLE = 68,
	[TypeLibVar(64)]
	visCtrlIDALIGNBOTTOM = 69,
	[TypeLibVar(64)]
	visCtrlIDDISTRIBUTE = 70,
	[TypeLibVar(64)]
	visCtrlIDDHORZ_EQSPACE = 71,
	[TypeLibVar(64)]
	visCtrlIDDHORZ_CENTER = 72,
	[TypeLibVar(64)]
	visCtrlIDDVERT_EQSPACE = 73,
	[TypeLibVar(64)]
	visCtrlIDDVERT_MIDDLE = 74,
	[TypeLibVar(64)]
	visCtrlIDCONNECTSHAPES = 75,
	[TypeLibVar(64)]
	visCtrlIDFIRSTPAGE = 76,
	[TypeLibVar(64)]
	visCtrlIDLASTPAGE = 77,
	[TypeLibVar(64)]
	visCtrlIDPAGEBREAKS = 78,
	[TypeLibVar(64)]
	visCtrlIDICONNAME = 80,
	[TypeLibVar(64)]
	visCtrlIDICONONLY = 81,
	[TypeLibVar(64)]
	visCtrlIDNAMEONLY = 82,
	[TypeLibVar(64)]
	visCtrlIDARRANGEICONS = 83,
	[TypeLibVar(64)]
	visCtrlIDCANCELFORMULA = 84,
	[TypeLibVar(64)]
	visCtrlIDACCEPTFORMULA = 85,
	[TypeLibVar(64)]
	visCtrlIDICONPENCIL = 86,
	[TypeLibVar(64)]
	visCtrlIDICONBUCKET = 87,
	[TypeLibVar(64)]
	visCtrlIDICONLASSO = 88,
	[TypeLibVar(64)]
	visCtrlIDICONSELNET = 89,
	[TypeLibVar(64)]
	visCtrlIDBRINGFRONT = 90,
	[TypeLibVar(64)]
	visCtrlIDSENDBACK = 91,
	[TypeLibVar(64)]
	visCtrlIDGROUP = 92,
	[TypeLibVar(64)]
	visCtrlIDUNGROUP = 93,
	[TypeLibVar(64)]
	visCtrlIDCASCADE = 94,
	[TypeLibVar(64)]
	visCtrlIDTILE = 95,
	[TypeLibVar(64)]
	visCtrlIDCONNECTORTOOL = 96,
	[TypeLibVar(64)]
	visCtrlIDTEXTBLOCKTOOL = 97,
	[TypeLibVar(64)]
	visCtrlIDWHOLEPAGE = 98,
	[TypeLibVar(64)]
	visCtrlIDSINGLETILE = 99,
	[TypeLibVar(64)]
	visCtrlIDFORMULA = 190,
	[TypeLibVar(64)]
	visCtrlIDSPACER = 191,
	[TypeLibVar(64)]
	visCtrlIDALLSTYLESCOMBO = 200,
	[TypeLibVar(64)]
	visCtrlIDTEXTSTYLECOMBO = 201,
	[TypeLibVar(64)]
	visCtrlIDLINESTYLECOMBO = 202,
	[TypeLibVar(64)]
	visCtrlIDFILLSTYLECOMBO = 203,
	[TypeLibVar(64)]
	visCtrlIDZOOMCOMBO = 204,
	[TypeLibVar(64)]
	visCtrlIDFONTCOMBO = 205,
	[TypeLibVar(64)]
	visCtrlIDPOINTSIZECOMBO = 206,
	[TypeLibVar(64)]
	visCtrlIDALLSTYLESLIST = 220,
	[TypeLibVar(64)]
	visCtrlIDTEXTSTYLELIST = 221,
	[TypeLibVar(64)]
	visCtrlIDLINESTYLELIST = 222,
	[TypeLibVar(64)]
	visCtrlIDFILLSTYLELIST = 223,
	[TypeLibVar(64)]
	visCtrlIDZOOMLIST = 224,
	[TypeLibVar(64)]
	visCtrlIDFONTLIST = 225,
	[TypeLibVar(64)]
	visCtrlIDPOINTSIZELIST = 226,
	[TypeLibVar(64)]
	visCtrlIDGOTOPAGELIST = 227,
	[TypeLibVar(64)]
	visCtrlIDCLOSE = 240,
	[TypeLibVar(64)]
	visCtrlIDLEFTCOLORBOX = 300,
	[TypeLibVar(64)]
	visCtrlIDRIGHTCOLORBOX = 301,
	[TypeLibVar(64)]
	visCtrlIDCOLOR1 = 302,
	[TypeLibVar(64)]
	visCtrlIDCOLOR2 = 303,
	[TypeLibVar(64)]
	visCtrlIDCOLOR3 = 304,
	[TypeLibVar(64)]
	visCtrlIDCOLOR4 = 305,
	[TypeLibVar(64)]
	visCtrlIDCOLOR5 = 306,
	[TypeLibVar(64)]
	visCtrlIDCOLOR6 = 307,
	[TypeLibVar(64)]
	visCtrlIDCOLOR7 = 308,
	[TypeLibVar(64)]
	visCtrlIDCOLOR8 = 309,
	[TypeLibVar(64)]
	visCtrlIDCOLOR9 = 310,
	[TypeLibVar(64)]
	visCtrlIDCOLOR10 = 311,
	[TypeLibVar(64)]
	visCtrlIDCOLOR11 = 312,
	[TypeLibVar(64)]
	visCtrlIDCOLOR12 = 313,
	[TypeLibVar(64)]
	visCtrlIDCOLOR13 = 314,
	[TypeLibVar(64)]
	visCtrlIDCOLOR14 = 315,
	[TypeLibVar(64)]
	visCtrlIDCOLOR15 = 316,
	[TypeLibVar(64)]
	visCtrlIDCOLOR16 = 317,
	[TypeLibVar(64)]
	visCtrlIDTRANSPARENT = 318,
	[TypeLibVar(64)]
	visCtrlIDALLSTYLESLABEL = 400,
	[TypeLibVar(64)]
	visCtrlIDTEXTSTYLELABEL = 401,
	[TypeLibVar(64)]
	visCtrlIDLINESTYLELABEL = 402,
	[TypeLibVar(64)]
	visCtrlIDFILLSTYLELABEL = 403,
	[TypeLibVar(64)]
	visCtrlIDZOOMLABEL = 404,
	[TypeLibVar(64)]
	visCtrlIDFONTLABEL = 405,
	[TypeLibVar(64)]
	visCtrlIDPOINTSIZELABEL = 406,
	[TypeLibVar(64)]
	visCtrlIDLEFTCOLORLABEL = 407,
	[TypeLibVar(64)]
	visCtrlIDRIGHTCOLORLABEL = 408,
	[TypeLibVar(64)]
	visCtrlIDSTATUSLABEL = 409,
	[TypeLibVar(64)]
	visCtrlIDPREVIEWLABEL = 410,
	[TypeLibVar(64)]
	visCtrlIDSTATUSREADOUT = 500,
	[TypeLibVar(64)]
	visCtrlIDSTATUSMSG_1 = 501,
	[TypeLibVar(64)]
	visCtrlIDSTATUSMSG_2 = 502,
	[TypeLibVar(64)]
	visCtrlIDSTATUSMSG_3 = 503,
	[TypeLibVar(64)]
	visCtrlIDSTATUSMSG_4 = 504,
	[TypeLibVar(64)]
	visCtrlIDSTATUSMSG_5 = 505,
	[TypeLibVar(64)]
	visCtrlIDSTATUSMSG_6 = 506,
	[TypeLibVar(64)]
	visCtrlIDSTATUSMSG_7 = 507,
	[TypeLibVar(64)]
	visCtrlIDSTATUSMSG_8 = 508,
	[TypeLibVar(64)]
	visCtrlIDSTATUSMSG_9 = 509,
	[TypeLibVar(64)]
	visCtrlIDSPLINETOOL = 79,
	[TypeLibVar(64)]
	visCtrlIDSPELLING = 100,
	[TypeLibVar(64)]
	visCtrlIDFORMATPAINTER = 101,
	[TypeLibVar(64)]
	visCtrlIDHELPMODE = 102,
	[TypeLibVar(64)]
	visCtrlIDLAYERPROPERTIES = 103,
	[TypeLibVar(64)]
	visCtrlIDLAYOUTSHAPES = 104,
	[TypeLibVar(64)]
	visCtrlIDINSERTHYPERLINK = 105,
	[TypeLibVar(64)]
	visCtrlIDSEARCHTHEWEB = 106,
	[TypeLibVar(64)]
	visCtrlIDGOBACK = 107,
	[TypeLibVar(64)]
	visCtrlIDGOFORWARD = 108,
	[TypeLibVar(64)]
	visCtrlIDWEBTOOLBAR = 109,
	[TypeLibVar(64)]
	visCtrlIDSHAPEEXPL = 110,
	[TypeLibVar(64)]
	visCtrlIDCUSTPROP = 111,
	[TypeLibVar(64)]
	visCtrlIDROTATETEXT = 112,
	[TypeLibVar(64)]
	visCtrlIDBULLETS = 113,
	[TypeLibVar(64)]
	visCtrlIDDECRINDENT = 114,
	[TypeLibVar(64)]
	visCtrlIDINCRINDENT = 115,
	[TypeLibVar(64)]
	visCtrlIDDECRPARA = 116,
	[TypeLibVar(64)]
	visCtrlIDINCRPARA = 117,
	[TypeLibVar(64)]
	visCtrlIDINSERTCONTROL = 118,
	[TypeLibVar(64)]
	visCtrlIDDESIGNMODE = 119,
	[TypeLibVar(64)]
	visCtrlIDSHAPESHEET = 120,
	[TypeLibVar(64)]
	visCtrlIDSHAPELAYER = 247,
	[TypeLibVar(64)]
	visCtrlIDGOTOPAGE = 207,
	[TypeLibVar(64)]
	visCtrlIDLINECOLORS = 241,
	[TypeLibVar(64)]
	visCtrlIDLINEWEIGHTS = 242,
	[TypeLibVar(64)]
	visCtrlIDLINEPATTERNS = 243,
	[TypeLibVar(64)]
	visCtrlIDFILLCOLORS = 244,
	[TypeLibVar(64)]
	visCtrlIDFILLPATTERNS = 245,
	[TypeLibVar(64)]
	visCtrlIDTEXTCOLORS = 246,
	[TypeLibVar(64)]
	visCtrlIDMACROS = 121,
	[TypeLibVar(64)]
	visCtrlIDVBEDITOR = 122,
	[TypeLibVar(64)]
	visCtrlIDSHAPELAYERCOMBO = 208,
	[TypeLibVar(64)]
	visCtrlIDSHAPELAYERLIST = 228,
	[TypeLibVar(64)]
	visCtrlIDALIGNSHAPES = 260,
	[TypeLibVar(64)]
	visCtrlIDDISTRIBUTESHAPES = 261,
	[TypeLibVar(64)]
	visCtrlIDMSG_PAGES = 510
}
