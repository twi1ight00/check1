namespace Aspose.Cells;

/// <summary>
///       Represents paper size constants.
///       </summary>
public enum PaperSizeType
{
	/// <summary>
	///       Letter (8-1/2 in. x 11 in.)
	///       </summary>
	PaperLetter = 1,
	/// <summary>
	///       Letter Small (8-1/2 in. x 11 in.)
	///       </summary>
	PaperLetterSmall = 2,
	/// <summary>
	///       Tabloid (11 in. x 17 in.) 
	///       </summary>
	PaperTabloid = 3,
	/// <summary>
	///       Ledger (17 in. x 11 in.)
	///       </summary>
	PaperLedger = 4,
	/// <summary>
	///       Legal (8-1/2 in. x 14 in.)
	///       </summary>
	PaperLegal = 5,
	/// <summary>
	///       Statement (5-1/2 in. x 8-1/2 in.)
	///       </summary>
	PaperStatement = 6,
	/// <summary>
	///       Executive (7-1/2 in. x 10-1/2 in.)
	///       </summary>
	PaperExecutive = 7,
	/// <summary>
	///       A3 (297 mm x 420 mm)
	///       </summary>
	PaperA3 = 8,
	/// <summary>
	///       A4 (210 mm x 297 mm)
	///       </summary>
	PaperA4 = 9,
	/// <summary>
	///       A4 Small (210 mm x 297 mm)
	///       </summary>
	PaperA4Small = 10,
	/// <summary>
	///       A5 (148 mm x 210 mm)
	///       </summary>
	PaperA5 = 11,
	/// <summary>
	///       B4 (250 mm x 354 mm)
	///       </summary>
	PaperB4 = 12,
	/// <summary>
	///       B5 (182 mm x 257 mm)
	///       </summary>
	PaperB5 = 13,
	/// <summary>
	///       Folio (8-1/2 in. x 13 in.)
	///       </summary>
	PaperFolio = 14,
	/// <summary>
	///       Quarto (215 mm x 275 mm)
	///       </summary>
	PaperQuarto = 15,
	/// <summary>
	///       10 in. x 14 in.
	///       </summary>
	Paper10x14 = 16,
	/// <summary>
	///       11 in. x 17 in.
	///       </summary>
	Paper11x17 = 17,
	/// <summary>
	///       Note (8-1/2 in. x 11 in.)
	///       </summary>
	PaperNote = 18,
	/// <summary>
	///       Envelope #9 (3-7/8 in. x 8-7/8 in.)
	///       </summary>
	PaperEnvelope9 = 19,
	/// <summary>
	///       Envelope #10 (4-1/8 in. x 9-1/2 in.)
	///       </summary>
	PaperEnvelope10 = 20,
	/// <summary>
	///       Envelope #11 (4-1/2 in. x 10-3/8 in.)
	///       </summary>
	PaperEnvelope11 = 21,
	/// <summary>
	///       Envelope #12 (4-1/2 in. x 11 in.)
	///       </summary>
	PaperEnvelope12 = 22,
	/// <summary>
	///       Envelope #14 (5 in. x 11-1/2 in.)
	///       </summary>
	PaperEnvelope14 = 23,
	/// <summary>
	///       C size sheet
	///       </summary>
	PaperCSheet = 24,
	/// <summary>
	///       D size sheet
	///       </summary>
	PaperDSheet = 25,
	/// <summary>
	///       E size sheet
	///       </summary>
	PaperESheet = 26,
	/// <summary>
	///       Envelope DL (110 mm x 220 mm)
	///       </summary>
	PaperEnvelopeDL = 27,
	/// <summary>
	///       Envelope C5 (162 mm x 229 mm)
	///       </summary>
	PaperEnvelopeC5 = 28,
	/// <summary>
	///       Envelope C3 (324 mm x 458 mm)
	///       </summary>
	PaperEnvelopeC3 = 29,
	/// <summary>
	///       Envelope C4 (229 mm x 324 mm)
	///       </summary>
	PaperEnvelopeC4 = 30,
	/// <summary>
	///       Envelope C6 (114 mm x 162 mm)
	///       </summary>
	PaperEnvelopeC6 = 31,
	/// <summary>
	///       Envelope C65 (114 mm x 229 mm)
	///       </summary>
	PaperEnvelopeC65 = 32,
	/// <summary>
	///       Envelope B4 (250 mm x 353 mm)
	///       </summary>
	PaperEnvelopeB4 = 33,
	/// <summary>
	///       Envelope B5 (176 mm x 250 mm)
	///       </summary>
	PaperEnvelopeB5 = 34,
	/// <summary>
	///       Envelope B6 (176 mm x 125 mm)
	///       </summary>
	PaperEnvelopeB6 = 35,
	/// <summary>
	///       Envelope Italy (110 mm x 230 mm)
	///       </summary>
	PaperEnvelopeItaly = 36,
	/// <summary>
	///       Envelope Monarch (3-7/8 in. x 7-1/2 in.)
	///       </summary>
	PaperEnvelopeMonarch = 37,
	/// <summary>
	///       Envelope (3-5/8 in. x 6-1/2 in.)
	///       </summary>
	PaperEnvelopePersonal = 38,
	/// <summary>
	///       U.S. Standard Fanfold (14-7/8 in. x 11 in.)
	///       </summary>
	PaperFanfoldUS = 39,
	/// <summary>
	///       German Standard Fanfold (8-1/2 in. x 12 in.)
	///       </summary>
	PaperFanfoldStdGerman = 40,
	/// <summary>
	///       German Legal Fanfold (8-1/2 in. x 13 in.)
	///       </summary>
	PaperFanfoldLegalGerman = 41,
	PaperISOB4 = 42,
	/// <summary>
	///       Japanese Postcard (100mm × 148mm)
	///       </summary>
	PaperJapanesePostcard = 43,
	/// <summary>
	///       9? × 11?
	///       </summary>
	Paper9x11 = 44,
	/// <summary>
	///       10? × 11?
	///       </summary>
	Paper10x11 = 45,
	/// <summary>
	///       15? × 11?
	///       </summary>
	Paper15x11 = 46,
	/// <summary>
	///       Envelope Invite(220mm × 220mm)
	///       </summary>
	PaperEnvelopeInvite = 47,
	PaperLetterExtra = 50,
	PaperLegalExtra = 51,
	PaperTabloidExtra = 52,
	PaperA4Extra = 53,
	PaperLetterTransverse = 54,
	PaperA4Transverse = 55,
	PaperLetterExtraTransverse = 56,
	PaperSuperA = 57,
	PaperSuperB = 58,
	PaperLetterPlus = 59,
	PaperA4Plus = 60,
	PaperA5Transverse = 61,
	PaperJISB5Transverse = 62,
	PaperA3Extra = 63,
	PaperA5Extra = 64,
	PaperISOB5Extra = 65,
	PaperA2 = 66,
	PaperA3Transverse = 67,
	PaperA3ExtraTransverse = 68,
	PaperJapaneseDoublePostcard = 69,
	PaperA6 = 70,
	PaperJapaneseEnvelopeKaku2 = 71,
	PaperJapaneseEnvelopeKaku3 = 72,
	PaperJapaneseEnvelopeChou3 = 73,
	PaperJapaneseEnvelopeChou4 = 74,
	/// <summary>
	///       11in × 8.5in
	///       </summary>
	PaperLetterRotated = 75,
	/// <summary>
	///       420mm × 297mm
	///       </summary>
	PaperA3Rotated = 76,
	/// <summary>
	///       297mm × 210mm
	///       </summary>
	PaperA4Rotated = 77,
	/// <summary>
	///       210mm × 148mm
	///       </summary>
	PaperA5Rotated = 78,
	PaperJISB4Rotated = 79,
	PaperJISB5Rotated = 80,
	PaperJapanesePostcardRotated = 81,
	PaperJapaneseDoublePostcardRotated = 82,
	PaperA6Rotated = 83,
	PaperJapaneseEnvelopeKaku2Rotated = 84,
	PaperJapaneseEnvelopeKaku3Rotated = 85,
	PaperJapaneseEnvelopeChou3Rotated = 86,
	PaperJapaneseEnvelopeChou4Rotated = 87,
	PaperJISB6 = 88,
	PaperJISB6Rotated = 89,
	Paper12x11 = 90,
	PaperJapaneseEnvelopeYou4 = 91,
	PaperJapaneseEnvelopeYou4Rotated = 92,
	PaperPRC16K = 93,
	PaperPRC32K = 94,
	PaperPRCBig32K = 95,
	PaperPRCEnvelope1 = 96,
	PaperPRCEnvelope2 = 97,
	PaperPRCEnvelope3 = 98,
	PaperPRCEnvelope4 = 99,
	PaperPRCEnvelope5 = 100,
	PaperPRCEnvelope6 = 101,
	PaperPRCEnvelope7 = 102,
	PaperPRCEnvelope8 = 103,
	PaperPRCEnvelope9 = 104,
	PaperPRCEnvelope10 = 105,
	PaperPRC16KRotated = 106,
	PaperPRC32KRotated = 107,
	PaperPRCBig32KRotated = 108,
	PaperPRCEnvelope1Rotated = 109,
	PaperPRCEnvelope2Rotated = 110,
	PaperPRCEnvelope3Rotated = 111,
	PaperPRCEnvelope4Rotated = 112,
	PaperPRCEnvelope5Rotated = 113,
	PaperPRCEnvelope6Rotated = 114,
	PaperPRCEnvelope7Rotated = 115,
	PaperPRCEnvelope8Rotated = 116,
	PaperPRCEnvelope9Rotated = 117,
	PaperPRCEnvelope10Rotated = 118
}
