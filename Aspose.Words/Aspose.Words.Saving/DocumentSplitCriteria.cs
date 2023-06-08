using System;

namespace Aspose.Words.Saving;

[Flags]
public enum DocumentSplitCriteria
{
	None = 0,
	PageBreak = 1,
	ColumnBreak = 2,
	SectionBreak = 4,
	HeadingParagraph = 8
}
