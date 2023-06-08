using Aspose.Words;
using Aspose.Words.Fields;
using x2a6f63b6650e76c4;
using x4adf554d20d941a6;
using x6c95d9cf46ff5f25;

namespace xfbd1009a0cbb9842;

internal class x454fffaf703e5e86 : Field, x6ed66b5cf8da2955
{
	private Bookmark x6624b07f4ed29060 => base.x2c8c6741422a1298.Range.Bookmarks[x0e99a2a20bc3c647];

	internal string x0e99a2a20bc3c647 => base.xb452e2ee706d7a67.x642e37025c67edab(0);

	internal bool xd1f083ffc72ae389 => base.xb452e2ee706d7a67.xcc2d426b867d703d("\\h");

	internal bool x5bc3f473bf19ef90 => base.xb452e2ee706d7a67.xcc2d426b867d703d("\\p");

	internal override x5dc2b4bc740c9563 x83bcdf1790545fdb()
	{
		if (!x0d299f323d241756.x5959bccb67bbf051(x0e99a2a20bc3c647))
		{
			return new xd5801a931e010963(this, "Error! No bookmark name given.");
		}
		if (x6624b07f4ed29060 == null)
		{
			return new xd5801a931e010963(this, "Error! Bookmark not defined.");
		}
		x82e26649b09596bd x82e26649b09596bd = base.x6edce55dcd2d335b.x803fdc6662fa3f31();
		if (x82e26649b09596bd == null)
		{
			return null;
		}
		x25abb95a730411e4 x25abb95a730411e5 = new x25abb95a730411e4(this);
		bool flag = x25abb95a730411e5.xcb95a4eb398e8796.xd113acd60d1dd3f6() != null || base.xb452e2ee706d7a67.xcc2d426b867d703d("\\#");
		if (x5bc3f473bf19ef90 && !flag)
		{
			return new xca592a476766b11a(this, xfa9bb5f52f15f5c5((x35d8d79b119cae44)x82e26649b09596bd));
		}
		return new xca592a476766b11a(this, x82e26649b09596bd);
	}

	private string xfa9bb5f52f15f5c5(x35d8d79b119cae44 x5791adbbb1cb4dea)
	{
		int num = (int)x5791adbbb1cb4dea.x7ce859afc0c75642;
		if (base.IsInHeaderFooter)
		{
			return xb02e0f110ce239aa(num);
		}
		x5c28fdcd27dee7d9 x5c28fdcd27dee7d = x357c90b33d6bb8e6().xcde671c53995c411.x2f356dc98cc87b99(base.Start);
		if (x5c28fdcd27dee7d.x6af07e13bc41d733() != num)
		{
			return xb02e0f110ce239aa(num);
		}
		if (!x6624b07f4ed29060.BookmarkStart.x026dc2547516c59d(base.Start))
		{
			return "below";
		}
		return "above";
	}

	private static string xb02e0f110ce239aa(int x39b5532b4ddc40a3)
	{
		return $"on page {x39b5532b4ddc40a3}";
	}

	internal override Section xe8d4351bdfdbf28a()
	{
		return (Section)((x6624b07f4ed29060 != null) ? x6624b07f4ed29060.BookmarkStart.GetAncestor(NodeType.Section) : null);
	}

	private x9f6b815e19fa8f62 x6b9dc5b8ca4335e3(string x724fbd227bfb6eda)
	{
		switch (x724fbd227bfb6eda)
		{
		case "\\h":
		case "\\p":
			return x9f6b815e19fa8f62.x8416ed4b8ffb3e34;
		default:
			return x9f6b815e19fa8f62.xf6c17f648b65c793;
		}
	}

	x9f6b815e19fa8f62 x6ed66b5cf8da2955.x3ecf81e56889c4af(string x724fbd227bfb6eda)
	{
		//ILSpy generated this explicit interface implementation from .override directive in x6b9dc5b8ca4335e3
		return this.x6b9dc5b8ca4335e3(x724fbd227bfb6eda);
	}
}
