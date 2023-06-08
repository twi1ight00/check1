using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace Aspose.Slides;

[Guid("b0a925df-72ce-4603-90bd-58b5ab6bb967")]
[ComVisible(true)]
public interface IComment
{
	string Text { get; set; }

	DateTime CreatedTime { get; set; }

	ISlide Slide { get; }

	ICommentAuthor Author { get; }

	PointF Position { get; set; }
}
