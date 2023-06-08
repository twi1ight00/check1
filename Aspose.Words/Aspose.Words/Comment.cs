using System;
using x28925c9b27b37a46;
using x6c95d9cf46ff5f25;

namespace Aspose.Words;

public class Comment : InlineStory, x8ad0c0863d1cd403
{
	private int x60adf410a9cceab0;

	private string xcd4f10ffc60ffeac = "";

	private string x7653bfba0eb25e11 = "";

	private DateTime x2f96d2f190b633ce = DateTime.MinValue;

	private bool xd51b889046e2195c;

	public override NodeType NodeType => NodeType.Comment;

	public override StoryType StoryType => StoryType.Comments;

	public int Id => x60adf410a9cceab0;

	int x8ad0c0863d1cd403.xb514a0ed67981a02
	{
		get
		{
			return x60adf410a9cceab0;
		}
		set
		{
			x60adf410a9cceab0 = value;
		}
	}

	public string Initial
	{
		get
		{
			return xcd4f10ffc60ffeac;
		}
		set
		{
			x0d299f323d241756.x0aaaea7864a53f26(value, "Initial");
			xcd4f10ffc60ffeac = value;
		}
	}

	public DateTime DateTime
	{
		get
		{
			return x2f96d2f190b633ce;
		}
		set
		{
			x2f96d2f190b633ce = value;
		}
	}

	public string Author
	{
		get
		{
			return x7653bfba0eb25e11;
		}
		set
		{
			x0d299f323d241756.x0aaaea7864a53f26(value, "Author");
			x7653bfba0eb25e11 = value;
		}
	}

	internal bool xad2b66edfff52038
	{
		get
		{
			return xd51b889046e2195c;
		}
		set
		{
			xd51b889046e2195c = value;
		}
	}

	internal Comment(DocumentBase doc, xeedad81aaed42a76 runPr)
		: base(doc, runPr)
	{
		x60adf410a9cceab0 = doc.x8ef8795c4475a0e3();
	}

	public Comment(DocumentBase doc)
		: this(doc, "", "", DateTime.MinValue)
	{
	}

	public Comment(DocumentBase doc, string author, string initial, DateTime dateTime)
		: this(doc, new xeedad81aaed42a76())
	{
		Author = author;
		Initial = initial;
		DateTime = dateTime;
		base.Font.StyleIdentifier = StyleIdentifier.CommentReference;
	}

	public override bool Accept(DocumentVisitor visitor)
	{
		return xf7ae36cd24e0b11c(visitor);
	}

	internal override VisitorAction x2449520719b1e37e(DocumentVisitor x672ff13faf031f3d)
	{
		return x672ff13faf031f3d.VisitCommentStart(this);
	}

	internal override VisitorAction x3bbb475596fa1de1(DocumentVisitor x672ff13faf031f3d)
	{
		return x672ff13faf031f3d.VisitCommentEnd(this);
	}

	public void SetText(string text)
	{
		RemoveAllChildren();
		Paragraph paragraph = new Paragraph(base.Document);
		paragraph.ParagraphFormat.StyleIdentifier = StyleIdentifier.CommentText;
		AppendChild(paragraph);
		DocumentBuilder documentBuilder = new DocumentBuilder(x357c90b33d6bb8e6());
		documentBuilder.MoveTo(paragraph);
		SpecialChar specialChar = new SpecialChar(x357c90b33d6bb8e6(), '\u0005', new xeedad81aaed42a76());
		specialChar.Font.StyleIdentifier = StyleIdentifier.CommentReference;
		documentBuilder.InsertNode(specialChar);
		documentBuilder.Write(text);
	}
}
