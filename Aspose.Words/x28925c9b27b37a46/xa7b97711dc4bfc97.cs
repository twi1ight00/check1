using System.Collections;
using Aspose.Words;

namespace x28925c9b27b37a46;

internal class xa7b97711dc4bfc97 : xe83a6b069ec8efc2
{
	private readonly ArrayList x3b6c59e973380af9 = new ArrayList();

	internal void xf054c9e7ce73c305(xe83a6b069ec8efc2 xcbf24c118ac8aa0b)
	{
		x3b6c59e973380af9.Add(xcbf24c118ac8aa0b);
	}

	private Node x65611a033680c59d(Node x98cacf1c34b53cca, Node xc926b680b06084a7, bool xdc5889e5d1efc748)
	{
		foreach (xe83a6b069ec8efc2 item in x3b6c59e973380af9)
		{
			if (xc926b680b06084a7 != null)
			{
				xc926b680b06084a7 = item.x57f70b425b43a885(x98cacf1c34b53cca, xc926b680b06084a7, xdc5889e5d1efc748);
			}
		}
		return xc926b680b06084a7;
	}

	Node xe83a6b069ec8efc2.x57f70b425b43a885(Node x98cacf1c34b53cca, Node xc926b680b06084a7, bool xdc5889e5d1efc748)
	{
		//ILSpy generated this explicit interface implementation from .override directive in x65611a033680c59d
		return this.x65611a033680c59d(x98cacf1c34b53cca, xc926b680b06084a7, xdc5889e5d1efc748);
	}
}
