using System;
using Aspose.Words;
using Aspose.Words.Lists;
using x6c95d9cf46ff5f25;

namespace x13cd31bb39e0b7ea;

internal class xb82ae5a29166d7a2
{
	internal void xc30b48dd08fbdff0(Paragraph x41baca1d6c0c2e8e)
	{
		if (x41baca1d6c0c2e8e.IsListItem)
		{
			ListLevel listLevel = x41baca1d6c0c2e8e.ListFormat.ListLevel;
			if (listLevel.xf9be1d0b8b44c7e8)
			{
				double num = x41baca1d6c0c2e8e.ParagraphFormat.LeftIndent + x41baca1d6c0c2e8e.ParagraphFormat.FirstLineIndent;
				double tabPosition = ((listLevel.x5cf63f659ff5ee9f == 0 && listLevel.x42bf8be828fc1b33 == 0) ? x41baca1d6c0c2e8e.ParagraphFormat.LeftIndent : (num + x4574ea26106f0edb.x0e1fdb362561ddb2(Math.Max(listLevel.x5cf63f659ff5ee9f, listLevel.x42bf8be828fc1b33))));
				listLevel.TabPosition = tabPosition;
				listLevel.TrailingCharacter = ListTrailingCharacter.Tab;
				listLevel.xf9be1d0b8b44c7e8 = false;
			}
		}
	}
}
