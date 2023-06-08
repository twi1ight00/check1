using System.Text;
using Aspose.Words;
using x28925c9b27b37a46;

namespace xfbd1009a0cbb9842;

internal class x78f7ad9d7fd68e82 : xe83a6b069ec8efc2
{
	private readonly bool xe05e245d4db2df30;

	private bool x7c6034731a439955;

	internal x78f7ad9d7fd68e82(bool isTrimDoubleQuotes)
	{
		xe05e245d4db2df30 = isTrimDoubleQuotes;
	}

	internal static string xef44648eae7d9918(string x153c99a852375422, bool x82dae5f27bd7d807)
	{
		x78f7ad9d7fd68e82 x78f7ad9d7fd68e83 = new x78f7ad9d7fd68e82(x82dae5f27bd7d807);
		return x78f7ad9d7fd68e83.xe4c8b33e9a2cfc89(x153c99a852375422);
	}

	internal string xe4c8b33e9a2cfc89(string xeca554e14c60cd4e)
	{
		StringBuilder stringBuilder = new StringBuilder();
		foreach (char c in xeca554e14c60cd4e)
		{
			switch (c)
			{
			case '\\':
				if (x7c6034731a439955)
				{
					stringBuilder.Append(c);
				}
				x7c6034731a439955 = !x7c6034731a439955;
				break;
			case '"':
			case '“':
			case '”':
				if (!xe05e245d4db2df30 || x7c6034731a439955)
				{
					stringBuilder.Append(c);
					x7c6034731a439955 = false;
				}
				break;
			default:
				stringBuilder.Append(c);
				x7c6034731a439955 = false;
				break;
			}
		}
		return stringBuilder.ToString();
	}

	private Node x65611a033680c59d(Node x98cacf1c34b53cca, Node xc926b680b06084a7, bool xdc5889e5d1efc748)
	{
		if (xc926b680b06084a7.NodeType == NodeType.Run)
		{
			Run run = (Run)xc926b680b06084a7;
			string text = xe4c8b33e9a2cfc89(run.Text);
			if (run.Text != text)
			{
				if (xdc5889e5d1efc748)
				{
					run = (Run)run.Clone(isCloneChildren: false);
				}
				run.Text = text;
				return run;
			}
		}
		else
		{
			x7c6034731a439955 = false;
		}
		return xc926b680b06084a7;
	}

	Node xe83a6b069ec8efc2.x57f70b425b43a885(Node x98cacf1c34b53cca, Node xc926b680b06084a7, bool xdc5889e5d1efc748)
	{
		//ILSpy generated this explicit interface implementation from .override directive in x65611a033680c59d
		return this.x65611a033680c59d(x98cacf1c34b53cca, xc926b680b06084a7, xdc5889e5d1efc748);
	}
}
