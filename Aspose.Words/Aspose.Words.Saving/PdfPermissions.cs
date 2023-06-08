using System;

namespace Aspose.Words.Saving;

[Flags]
public enum PdfPermissions
{
	DisallowAll = 0,
	AllowAll = 0xFFFF,
	ContentCopy = 0x10,
	ContentCopyForAccessibility = 0x200,
	ModifyContents = 8,
	ModifyAnnotations = 0x20,
	FillIn = 0x100,
	DocumentAssembly = 0x400,
	Printing = 4,
	HighResolutionPrinting = 0x804
}
