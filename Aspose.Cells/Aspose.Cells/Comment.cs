using System.Collections;
using System.Runtime.CompilerServices;
using Aspose.Cells.Drawing;
using ns2;

namespace Aspose.Cells;

/// <summary>
///       Encapsulates the object that represents a cell comment.
///       </summary>
/// <example>
///   <code>
///       [C#]
///
///       Workbook workbook = new Workbook();
///       CommentCollection comments = workbook.Worksheets[0].Comments;
///
///       //Add comment to cell A1
///       int commentIndex = comments.Add(0, 0);
///       Comment comment = comments[commentIndex];
///       comment.Note = "First note.";
///       comment.Font.Name = "Times New Roman";
///
///       //Add comment to cell B2
///       comments.Add("B2");
///       comment = comments["B2"];
///       comment.Note = "Second note.";
///
///       [Visual Basic]
///
///       Dim workbook as Workbook = new Workbook()
///       Dim comments as CommentCollection = workbook.Worksheets(0).Comments
///
///       'Add comment to cell A1
///       Dim commentIndex as Integer = comments.Add(0, 0)
///       Dim comment as Comment = comments(commentIndex)
///       comment.Note = "First note."
///       comment.Font.Name = "Times New Roman"
///
///       'Add comment to cell B2
///       comments.Add("B2")
///       comment = comments("B2")
///       comment.Note = "Second note."
///
///       </code>
/// </example>
public class Comment
{
	private CommentShape commentShape_0;

	private CommentCollection commentCollection_0;

	private bool bool_0;

	private string string_0;

	private int int_0;

	private short short_0;

	/// <summary>
	///       Gets and sets Name of the original comment author
	///       </summary>
	public string Author
	{
		get
		{
			return string_0;
		}
		set
		{
			string_0 = value;
		}
	}

	/// <summary>
	///       Get a Shape object that represents the shape attached to the specified comment.
	///       </summary>
	public CommentShape CommentShape => commentShape_0;

	/// <summary>
	///       Gets the row index of the comment.
	///       </summary>
	public int Row => int_0;

	/// <summary>
	///       Gets the column index of the comment.
	///       </summary>
	public int Column => short_0;

	/// <summary>
	///       Represents the content of comment.
	///       </summary>
	public string Note
	{
		get
		{
			return method_2().Text;
		}
		set
		{
			method_2().Text = value;
		}
	}

	/// <summary>
	///       Gets and sets the html string which contains data and some formattings in this comment.
	///       </summary>
	public string HtmlNote
	{
		get
		{
			return method_2().HtmlString;
		}
		set
		{
			method_2().HtmlString = value;
		}
	}

	/// <summary>
	///       Gets the font of comment.
	///       </summary>
	public Font Font => method_2().Font;

	/// <summary>
	///       Represents if the comment is visible or not.
	///       </summary>
	public bool IsVisible
	{
		get
		{
			return !commentShape_0.IsHidden;
		}
		set
		{
			commentShape_0.IsHidden = !value;
		}
	}

	/// <summary>
	///        Gets and sets the text orientation type of the comment.
	///       </summary>
	public TextOrientationType TextOrientationType
	{
		get
		{
			return method_2().TextOrientationType;
		}
		set
		{
			method_2().TextOrientationType = value;
		}
	}

	/// <summary>
	///        Gets and sets the text horizontal alignment type of the comment.
	///       </summary>
	public TextAlignmentType TextHorizontalAlignment
	{
		get
		{
			return method_2().TextHorizontalAlignment;
		}
		set
		{
			method_2().TextHorizontalAlignment = value;
		}
	}

	/// <summary>
	///        Gets and sets the text vertical alignment type of the comment.
	///       </summary>
	public TextAlignmentType TextVerticalAlignment
	{
		get
		{
			return method_2().TextVerticalAlignment;
		}
		set
		{
			method_2().TextVerticalAlignment = value;
		}
	}

	/// <summary>
	///       Indicates if size of comment is adjusted automatically according to its content.
	///       </summary>
	public bool AutoSize
	{
		get
		{
			return commentShape_0.TextFrame.AutoSize;
		}
		set
		{
			commentShape_0.TextFrame.AutoSize = value;
		}
	}

	/// <summary>
	///       Represents the height of the comment, in unit of centimeters.
	///       </summary>
	public double HeightCM
	{
		get
		{
			return CommentShape.HeightCM;
		}
		set
		{
			CommentShape.HeightCM = value;
		}
	}

	/// <summary>
	///       Represents the width of the comment, in unit of centimeters.
	///       </summary>
	public double WidthCM
	{
		get
		{
			return CommentShape.WidthCM;
		}
		set
		{
			CommentShape.WidthCM = value;
		}
	}

	/// <summary>
	///       Represents the width of the comment, in unit of inches.
	///       </summary>
	public double WidthInch
	{
		get
		{
			return CommentShape.WidthInch;
		}
		set
		{
			CommentShape.WidthInch = value;
		}
	}

	/// <summary>
	///       Represents the height of the comment, in unit of inches.
	///       </summary>
	public double HeightInch
	{
		get
		{
			return CommentShape.HeightInch;
		}
		set
		{
			CommentShape.HeightInch = value;
		}
	}

	internal Comment(CommentCollection commentCollection_1)
	{
		commentCollection_0 = commentCollection_1;
		Worksheet worksheet = commentCollection_0.method_0();
		commentShape_0 = new CommentShape(worksheet.Shapes, this);
		bool_0 = false;
		string_0 = commentCollection_0.method_0().method_2().Author;
	}

	internal Comment(CommentCollection commentCollection_1, int int_1, int int_2)
	{
		bool_0 = true;
		int_0 = int_1;
		short_0 = (short)int_2;
		commentCollection_0 = commentCollection_1;
		Worksheet worksheet = commentCollection_0.method_0();
		commentShape_0 = new CommentShape(worksheet.Shapes, this);
		string_0 = commentCollection_0.method_0().method_2().Author;
	}

	[SpecialName]
	internal bool method_0()
	{
		return bool_0;
	}

	[SpecialName]
	internal void method_1(bool bool_1)
	{
		bool_0 = bool_1;
	}

	[SpecialName]
	internal Class1737 method_2()
	{
		return CommentShape.method_63();
	}

	internal void method_3()
	{
		int num = short_0 + 1;
		commentShape_0.method_27().method_7().method_4(PlacementType.FreeFloating);
		if (int_0 == 0)
		{
			commentShape_0.method_27().method_7().Top = 1;
		}
		else if (int_0 > 1048570)
		{
			commentShape_0.method_27().method_7().Top = commentShape_0.method_41(0, 0, int_0 - 5, 105);
		}
		else
		{
			commentShape_0.method_27().method_7().Top = commentShape_0.method_41(0, 0, int_0 - 1, 105);
		}
		num = ((short_0 <= 16380) ? (short_0 + 1) : (short_0 - 3));
		commentShape_0.method_27().method_7().Left = commentShape_0.method_44(0, 0, num, 240);
		commentShape_0.method_27().method_7().Right = 128;
		commentShape_0.method_27().method_7().Bottom = 74;
	}

	internal void method_4(int int_1)
	{
		int_0 = int_1;
	}

	internal void method_5(int int_1)
	{
		short_0 = (short)int_1;
	}

	/// <summary>
	///       Returns a Characters object that represents a range of characters within the comment text.
	///       </summary>
	/// <param name="startIndex">The index of the start of the character.</param>
	/// <param name="length">The number of characters.</param>
	/// <returns>Characters object.</returns>
	public FontSetting Characters(int startIndex, int length)
	{
		return method_2().Characters(startIndex, length);
	}

	/// <summary>
	///       Returns all Characters objects 
	///       that represents a range of characters within the comment text.
	///       </summary>
	/// <returns>All Characters objects </returns>
	public ArrayList GetCharacters()
	{
		return method_2().method_12();
	}

	internal Font method_6()
	{
		return method_2().method_5();
	}

	[SpecialName]
	internal void method_7(int int_1)
	{
		method_2().method_9(int_1);
	}

	internal void Copy(Comment comment_0)
	{
		method_2().Copy(comment_0.method_2());
		bool_0 = comment_0.bool_0;
		string_0 = comment_0.string_0;
	}
}
