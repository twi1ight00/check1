using Aspose.Words;
using Aspose.Words.Fields;

namespace xfbd1009a0cbb9842;

internal class x6faec3efd633f535 : x04c0e061352aeb47
{
	private readonly Field x54c413cc80cb99d5;

	internal x6faec3efd633f535(Field field)
	{
		x54c413cc80cb99d5 = field;
	}

	public Inline xf39c106b43956987()
	{
		foreach (Node item in x54c413cc80cb99d5.xabae4fa6681a6afd(x7d5e2f34b6651bf4.xf8d31d196ccd74c4))
		{
			if (item.NodeType == NodeType.Run)
			{
				return (Inline)item;
			}
		}
		if (x54c413cc80cb99d5.Start.PreviousSibling is Inline result)
		{
			return result;
		}
		return x54c413cc80cb99d5.End;
	}

	public x9710cfdf3f61d319 xc5dc1bbbb8923eaa()
	{
		if (x5c29822913be33c1.xd668adf9377c05ee(x54c413cc80cb99d5.Type) != 0)
		{
			x54c413cc80cb99d5.x5f4c2139149eaf99(x5113d1e6ef8a0405: true);
			return new x93d0f6869ccdc479(x54c413cc80cb99d5.x1a58ab8aeb0cc722, x54c413cc80cb99d5.Separator.ParentParagraph, x54c413cc80cb99d5.End.ParentParagraph);
		}
		return null;
	}
}
