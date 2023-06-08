using System.Runtime.InteropServices;

namespace Aspose.Slides;

[Guid("8e007050-0f50-42b8-b5d6-0dc8289d12e2")]
[ComVisible(true)]
public interface ICommentAuthor
{
	string Name { get; set; }

	string Initials { get; set; }

	ICommentCollection Comments { get; }
}
