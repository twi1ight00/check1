using System;

namespace Aspose.Words.Reporting;

[Flags]
public enum MailMergeCleanupOptions
{
	None = 0,
	RemoveEmptyParagraphs = 1,
	RemoveUnusedRegions = 2,
	RemoveUnusedFields = 4,
	RemoveContainingFields = 8
}
