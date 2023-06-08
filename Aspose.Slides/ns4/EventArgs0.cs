using System;
using Aspose.Slides;

namespace ns4;

internal class EventArgs0 : EventArgs
{
	private readonly Paragraph paragraph_0;

	internal Paragraph Paragraph => paragraph_0;

	internal EventArgs0(Paragraph paragraph)
	{
		paragraph_0 = paragraph;
	}
}
