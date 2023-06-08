using System.Collections;
using Aspose.Words;
using Aspose.Words.Fields;
using x28925c9b27b37a46;

namespace xfbd1009a0cbb9842;

internal class x109ecce6e2a0da51
{
	private readonly Field x54c413cc80cb99d5;

	private xb56968f92e308c8a x7945f37de10c46e0;

	private Field x30cd88ed60c0ba65;

	private readonly Stack x215f4deb55f3496c = new Stack();

	internal Field x38a7520391277515 => x30cd88ed60c0ba65;

	internal x109ecce6e2a0da51(Field field, x7d5e2f34b6651bf4 area)
	{
		x54c413cc80cb99d5 = field;
		x74f5a1ef3906e23c(area);
	}

	internal bool x47f176deff0d42e2()
	{
		if (x7945f37de10c46e0 == null)
		{
			return false;
		}
		while (x7945f37de10c46e0.x1ef2c3be187f37a2())
		{
			Node x3387295f12854dfd = x7945f37de10c46e0.x3387295f12854dfd;
			switch (x3387295f12854dfd.NodeType)
			{
			case NodeType.FieldStart:
			case NodeType.FieldSeparator:
				x215f4deb55f3496c.Push(x3387295f12854dfd);
				break;
			case NodeType.FieldEnd:
			{
				FieldEnd fieldEnd = (FieldEnd)x3387295f12854dfd;
				FieldSeparator x3de314ab70bbd9bf = (fieldEnd.HasSeparator ? ((FieldSeparator)x215f4deb55f3496c.Pop()) : null);
				FieldStart x10aaa7cdfa38f = (FieldStart)x215f4deb55f3496c.Pop();
				if (x215f4deb55f3496c.Count == 0)
				{
					x30cd88ed60c0ba65 = x3759c06a3a4cf5d1.x43fef3435fba7a66(x10aaa7cdfa38f, x3de314ab70bbd9bf, fieldEnd);
					return true;
				}
				break;
			}
			}
		}
		return false;
	}

	internal void x74f5a1ef3906e23c(x7d5e2f34b6651bf4 xdd2e02377d7065ba)
	{
		x7e263f21a73a027a x7e263f21a73a027a = x54c413cc80cb99d5.xc29c85f333b133e4(xdd2e02377d7065ba);
		x7945f37de10c46e0 = (x7e263f21a73a027a.x30d6662e83251ab4 ? null : new xb56968f92e308c8a(x7e263f21a73a027a));
		x215f4deb55f3496c.Clear();
		x30cd88ed60c0ba65 = null;
	}
}
