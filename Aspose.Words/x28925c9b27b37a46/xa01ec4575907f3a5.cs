using System;
using System.Collections;
using Aspose;
using Aspose.Words;

namespace x28925c9b27b37a46;

[JavaManual("To fully implement java Iterator with generics for foreach")]
internal class xa01ec4575907f3a5 : IEnumerator
{
	private readonly NodeCollection xc7d5d28b3f8072cd;

	private Node xe34d6abf59682d24;

	private Node xd66b3bfe87086cc8;

	public object Current
	{
		get
		{
			if (xd66b3bfe87086cc8 == xc7d5d28b3f8072cd.xc255c495fd9232ca || xd66b3bfe87086cc8 == null)
			{
				throw new InvalidOperationException("Invalid position of the enumerator.");
			}
			return xd66b3bfe87086cc8;
		}
	}

	internal xa01ec4575907f3a5(NodeCollection nodes)
	{
		xc7d5d28b3f8072cd = nodes;
		Reset();
	}

	public bool MoveNext()
	{
		if (xd66b3bfe87086cc8 == null)
		{
			return false;
		}
		if (xd66b3bfe87086cc8 != xc7d5d28b3f8072cd.xc255c495fd9232ca && xd66b3bfe87086cc8.ParentNode == null)
		{
			xd66b3bfe87086cc8 = xe34d6abf59682d24;
		}
		if (xd66b3bfe87086cc8 != xc7d5d28b3f8072cd.xc255c495fd9232ca && xd66b3bfe87086cc8.ParentNode == null)
		{
			throw new InvalidOperationException("Document structure was changed.");
		}
		xe34d6abf59682d24 = xc7d5d28b3f8072cd.x546e10f8b0fe6693(ref xd66b3bfe87086cc8, xa17853d20c8c42bd: true);
		return xd66b3bfe87086cc8 != null;
	}

	public void Reset()
	{
		xd66b3bfe87086cc8 = xc7d5d28b3f8072cd.xc255c495fd9232ca;
	}
}
