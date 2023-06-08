using Aspose.Words.Tables;
using x28925c9b27b37a46;
using x6c95d9cf46ff5f25;

namespace Aspose.Words;

public abstract class Story : CompositeNode
{
	private readonly StoryType x476547a1677d89f7;

	private ParagraphCollection x27eb3ed41aea96de;

	private TableCollection x14a2f87d74dbdad1;

	public StoryType StoryType => x476547a1677d89f7;

	public Paragraph FirstParagraph => (Paragraph)GetChild(NodeType.Paragraph, 0, isDeep: false);

	public Paragraph LastParagraph => (Paragraph)GetChild(NodeType.Paragraph, -1, isDeep: false);

	public ParagraphCollection Paragraphs
	{
		get
		{
			if (x27eb3ed41aea96de == null)
			{
				x27eb3ed41aea96de = new ParagraphCollection(this);
			}
			return x27eb3ed41aea96de;
		}
	}

	public TableCollection Tables
	{
		get
		{
			if (x14a2f87d74dbdad1 == null)
			{
				x14a2f87d74dbdad1 = new TableCollection(this);
			}
			return x14a2f87d74dbdad1;
		}
	}

	internal bool x74f5d3c8c1c169b6
	{
		get
		{
			if (base.xefd689c2d1a39911)
			{
				return base.LastChild.GetText() == ControlChar.SectionBreak;
			}
			return false;
		}
	}

	internal Story(DocumentBase doc, StoryType storyType)
		: base(doc)
	{
		x476547a1677d89f7 = storyType;
	}

	internal override Node x8b61531c8ea35b85(bool x7a5f12b98e34a590, x15a33f6d96885286 xe870d6f33992ceb4)
	{
		Story story = (Story)base.x8b61531c8ea35b85(x7a5f12b98e34a590, xe870d6f33992ceb4);
		story.x27eb3ed41aea96de = null;
		story.x14a2f87d74dbdad1 = null;
		return story;
	}

	public void DeleteShapes()
	{
		NodeCollection childNodes = GetChildNodes(NodeType.GroupShape, isDeep: true);
		childNodes.Clear();
		NodeCollection childNodes2 = GetChildNodes(NodeType.Shape, isDeep: true);
		childNodes2.Clear();
	}

	internal override bool x8a4414b7d9d4073f(Node x40e458b3a58f5782)
	{
		return x2b1ee3a87b36a988.xb6578aa94903986e(x40e458b3a58f5782);
	}

	public Paragraph AppendParagraph(string text)
	{
		Paragraph paragraph = new Paragraph(base.Document);
		AppendChild(paragraph);
		if (x0d299f323d241756.x5959bccb67bbf051(text))
		{
			paragraph.AppendChild(new Run(base.Document, text));
		}
		return paragraph;
	}
}
