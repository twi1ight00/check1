using System;

namespace Aspose.Words.Saving;

[Flags]
public enum SwfTopPaneControlFlags
{
	HideAll = 0,
	ShowAll = 0xFFF,
	ShowActualSize = 1,
	ShowFitToHeight = 2,
	ShowFitToWidth = 4,
	ShowZoomOut = 8,
	ShowZoomIn = 0x10,
	ShowTextSelectionMode = 0x20,
	ShowPageDragMode = 0x40,
	ShowSinglePageScroll = 0x80,
	ShowSinglePage = 0x100,
	ShowTwoPagesScroll = 0x200,
	ShowTwoPages = 0x400,
	ShowReadModeButton = 0x800
}
