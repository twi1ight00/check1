using Aspose.Words;
using Aspose.Words.Fields;
using x6c95d9cf46ff5f25;

namespace xfbd1009a0cbb9842;

internal class x2a70bc2d90576783 : x04c0e061352aeb47
{
	private readonly Field x54c413cc80cb99d5;

	internal x2a70bc2d90576783(Field field)
	{
		x54c413cc80cb99d5 = field;
	}

	public Inline xf39c106b43956987()
	{
		foreach (Node item in x54c413cc80cb99d5.xabae4fa6681a6afd(x7d5e2f34b6651bf4.xb0b4ff1622a01d12))
		{
			if (item.NodeType == NodeType.Run)
			{
				Run run = (Run)item;
				if (!x0d299f323d241756.x0fb62ca630231ea1(run.Text))
				{
					return run;
				}
			}
		}
		return x54c413cc80cb99d5.Separator;
	}

	public x9710cfdf3f61d319 xc5dc1bbbb8923eaa()
	{
		return new x5ce12f936f3c0407(xf39c106b43956987());
	}
}
