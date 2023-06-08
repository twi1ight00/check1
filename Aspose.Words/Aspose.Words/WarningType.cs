using System;

namespace Aspose.Words;

[Flags]
public enum WarningType
{
	DataLossCategory = 0xFF,
	DataLoss = 1,
	MajorFormattingLossCategory = 0xFF00,
	MajorFormattingLoss = 0x100,
	MinorFormattingLossCategory = 0xFF0000,
	MinorFormattingLoss = 0x10000,
	FontSubstitution = 0x20000,
	UnexpectedContentCategory = 0xF000000,
	UnexpectedContent = 0x1000000
}
