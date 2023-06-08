using System;

namespace Aspose.Words.Tables;

[Flags]
public enum TableStyleOptions
{
	None = 0,
	FirstRow = 0x20,
	LastRow = 0x40,
	FirstColumn = 0x80,
	LastColumn = 0x100,
	RowBands = 0x200,
	ColumnBands = 0x400,
	Default2003 = 0x600,
	Default = 0x2A0
}
