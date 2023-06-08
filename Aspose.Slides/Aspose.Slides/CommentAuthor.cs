using ns24;

namespace Aspose.Slides;

public sealed class CommentAuthor : ICommentAuthor
{
	private string string_0;

	private string string_1;

	internal Presentation presentation_0;

	private Class331 class331_0 = new Class331();

	private CommentCollection commentCollection_0;

	internal Class331 PPTXUnsupportedProps => class331_0;

	internal uint Id
	{
		get
		{
			return PPTXUnsupportedProps.Id;
		}
		set
		{
			PPTXUnsupportedProps.Id = value;
		}
	}

	public string Name
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

	public string Initials
	{
		get
		{
			return string_1;
		}
		set
		{
			string_1 = value;
		}
	}

	public ICommentCollection Comments => commentCollection_0;

	internal CommentAuthor(Presentation presentation, uint id, string name, string initials)
	{
		presentation_0 = presentation;
		Id = id;
		string_0 = name;
		string_1 = initials;
		commentCollection_0 = new CommentCollection(this);
	}
}
