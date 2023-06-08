using System.Runtime.CompilerServices;
using ns2;

namespace Aspose.Cells.Drawing;

/// <summary>
///       Represents the shape of the comment.
///       </summary>
public class CommentShape : Shape
{
	private Comment comment_0;

	/// <summary>
	///       Gets the Commnet object.
	///       </summary>
	public Comment Comment => comment_0;

	internal CommentShape(ShapeCollection shapeCollection_1, Comment comment_1)
		: base(shapeCollection_1, MsoDrawingType.Comment, shapeCollection_1)
	{
		comment_0 = comment_1;
		class1737_0 = new Class1737(this);
	}

	[SpecialName]
	internal Comment method_69()
	{
		return comment_0;
	}

	internal void Copy(CommentShape commentShape_0, CopyOptions copyOptions_0)
	{
		Copy((Shape)commentShape_0, copyOptions_0);
		comment_0.Copy(commentShape_0.comment_0);
	}
}
