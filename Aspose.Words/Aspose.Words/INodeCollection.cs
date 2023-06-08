using System.Collections;

namespace Aspose.Words;

public interface INodeCollection
{
	int Count { get; }

	Node this[int index] { get; }

	IEnumerator GetEnumerator();
}
