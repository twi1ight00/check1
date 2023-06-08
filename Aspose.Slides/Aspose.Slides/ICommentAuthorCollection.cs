using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Aspose.Slides;

[ComVisible(true)]
[Guid("930c9bcb-4267-4af1-a71b-8e4003fdd1b9")]
public interface ICommentAuthorCollection : ICollection, IEnumerable, IEnumerable<ICommentAuthor>
{
	ICommentAuthor this[int index] { get; }

	ICollection AsICollection { get; }

	IEnumerable AsIEnumerable { get; }

	ICommentAuthor AddAuthor(string name, string initials);

	ICommentAuthor[] ToArray();

	ICommentAuthor[] FindByName(string name);

	ICommentAuthor[] FindByNameAndInitials(string name, string initials);
}
