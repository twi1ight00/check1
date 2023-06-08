using System.IO;
using Aspose.Words.Fields;
using x2a6f63b6650e76c4;
using x6c95d9cf46ff5f25;

namespace xfbd1009a0cbb9842;

internal class x155232e8c0503479 : Field, x6ed66b5cf8da2955
{
	internal bool x2310765fd43349c6 => base.xb452e2ee706d7a67.xcc2d426b867d703d("\\k");

	internal bool xe7a2a34b3b7156e9 => base.xb452e2ee706d7a67.xcc2d426b867d703d("\\m");

	internal override x5dc2b4bc740c9563 x83bcdf1790545fdb()
	{
		int num = 0;
		string originalFileName = x357c90b33d6bb8e6().OriginalFileName;
		if (originalFileName != null)
		{
			try
			{
				FileInfo fileInfo = new FileInfo(x357c90b33d6bb8e6().OriginalFileName);
				num = (int)fileInfo.Length;
				if (xe7a2a34b3b7156e9)
				{
					num = x15e971129fd80714.x43fcc3f62534530b((double)num / 1000000.0);
				}
				else if (x2310765fd43349c6)
				{
					num = x15e971129fd80714.x43fcc3f62534530b((double)num / 1000.0);
				}
			}
			catch
			{
			}
		}
		return new xca592a476766b11a(this, new x35d8d79b119cae44(num));
	}

	private x9f6b815e19fa8f62 x6b9dc5b8ca4335e3(string x724fbd227bfb6eda)
	{
		switch (x724fbd227bfb6eda)
		{
		case "\\k":
		case "\\m":
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
