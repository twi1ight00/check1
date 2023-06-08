using Aspose.Words;
using x6c95d9cf46ff5f25;

namespace x2a6f63b6650e76c4;

internal class xb42dd4742eae5750 : xddb28bb303a8678b
{
	private readonly x12e7545fad3ccc9b x8cedcaa9a62c6e39;

	private readonly string x113ec0a83b1ef460;

	internal Bookmark x6624b07f4ed29060 => x8cedcaa9a62c6e39.x2c8c6741422a1298.Range.Bookmarks[x113ec0a83b1ef460];

	internal xb42dd4742eae5750(x12e7545fad3ccc9b context, string bookmarkName)
	{
		x8cedcaa9a62c6e39 = context;
		x113ec0a83b1ef460 = bookmarkName;
	}

	private x82e26649b09596bd x3494e22b9d135f56(xa7ef704c7557cbae x4be5a34ade30ae6b)
	{
		if (x6624b07f4ed29060 == null)
		{
			return new xf7d966ea5d1701b6($"!Undefined Bookmark, {x113ec0a83b1ef460.ToUpper()}");
		}
		string text = x6624b07f4ed29060.x633d57e35b6715a4(x39abdfb3e1bf0b2a: true);
		if (text != null && x0d299f323d241756.x90637a473b1ceaaa(text.Trim(), x6624b07f4ed29060.Name))
		{
			return new xdfbdf8708b1e8b71(text);
		}
		x82e26649b09596bd x82e26649b09596bd2 = x6d929209cd800011.x308cb2f3483de2a6(x8cedcaa9a62c6e39.xd1b40af56a8385d4, text);
		if (!x82e26649b09596bd2.x6b54bdfbc4586f55)
		{
			return x82e26649b09596bd2;
		}
		text = text.Replace('\a', ' ');
		string[] array = text.Split();
		xc50df386fc548c72 xc50df386fc548c73 = new xc50df386fc548c72();
		double num = 0.0;
		string[] array2 = array;
		foreach (string text2 in array2)
		{
			if (text2.Length != 0)
			{
				x918e475ee39e3253 x918e475ee39e3254 = x918e475ee39e3253.x19890931227f0f56(text2);
				if (x918e475ee39e3254 == null)
				{
					return new x918e475ee39e3253(0.0);
				}
				xc50df386fc548c73.xd6b6ed77479ef68c(x918e475ee39e3254);
				num += x918e475ee39e3254.x7ce859afc0c75642;
			}
		}
		return x918e475ee39e3253.xcf290d1e33e810d0(xc50df386fc548c73, num);
	}

	x82e26649b09596bd xddb28bb303a8678b.x308cb2f3483de2a6(xa7ef704c7557cbae x4be5a34ade30ae6b)
	{
		//ILSpy generated this explicit interface implementation from .override directive in x3494e22b9d135f56
		return this.x3494e22b9d135f56(x4be5a34ade30ae6b);
	}
}
