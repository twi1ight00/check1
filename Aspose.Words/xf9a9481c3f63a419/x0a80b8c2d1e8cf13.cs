using System.Collections;
using Aspose;

namespace xf9a9481c3f63a419;

[JavaManual("Manual porting by design.")]
internal class x0a80b8c2d1e8cf13
{
	private readonly IEnumerator x9414df10628fec80;

	public object x35cfcea4890f4e7d => x9414df10628fec80.Current;

	protected IEnumerator x1661c4be9c5f4fb8 => x9414df10628fec80;

	public x0a80b8c2d1e8cf13(IEnumerator wrappedEnumerator)
	{
		x9414df10628fec80 = wrappedEnumerator;
	}

	public bool x47f176deff0d42e2()
	{
		return x9414df10628fec80.MoveNext();
	}

	public void x74f5a1ef3906e23c()
	{
		x9414df10628fec80.Reset();
	}
}
