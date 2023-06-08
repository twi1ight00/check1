using System.Collections;
using Aspose;
using Aspose.Words;

namespace x28925c9b27b37a46;

[JavaManual("This is passed to Jaxen Xpath engine and it calls hasNext() twice so we have to manually implement correctly.")]
internal class x75a996f7f9d00390 : IEnumerator
{
	private readonly CompositeNode x437fa02210b98bec;

	private bool x3aa29a83a6c57b2a;

	private Node xd4bd25740614b729;

	public object Current => xd4bd25740614b729;

	internal x75a996f7f9d00390(CompositeNode container)
	{
		x437fa02210b98bec = container;
		Reset();
	}

	public bool MoveNext()
	{
		if (x3aa29a83a6c57b2a)
		{
			xd4bd25740614b729 = x437fa02210b98bec.FirstChild;
			x3aa29a83a6c57b2a = false;
		}
		else if (xd4bd25740614b729 != null)
		{
			xd4bd25740614b729 = xd4bd25740614b729.NextSibling;
		}
		return xd4bd25740614b729 != null;
	}

	public void Reset()
	{
		x3aa29a83a6c57b2a = true;
		xd4bd25740614b729 = null;
	}
}
