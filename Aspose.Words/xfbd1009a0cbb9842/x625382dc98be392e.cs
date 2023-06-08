using System.Text;
using Aspose.Words;
using x28925c9b27b37a46;

namespace xfbd1009a0cbb9842;

internal class x625382dc98be392e : xe83a6b069ec8efc2
{
	private readonly bool x6c1c90120947c83c;

	private readonly bool xe8e73ade9b8e9bb2;

	internal x625382dc98be392e(bool preserveTabs, bool preserveLineBreaks)
	{
		x6c1c90120947c83c = preserveTabs;
		xe8e73ade9b8e9bb2 = preserveLineBreaks;
	}

	private Node x65611a033680c59d(Node x98cacf1c34b53cca, Node xc926b680b06084a7, bool xdc5889e5d1efc748)
	{
		if (xc926b680b06084a7 is Inline)
		{
			Inline inline = (Inline)xc926b680b06084a7;
			if (inline.x1a2af56d5e4e537b)
			{
				return null;
			}
		}
		switch (xc926b680b06084a7.NodeType)
		{
		case NodeType.Run:
		{
			Run run = (Run)xc926b680b06084a7;
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < run.Text.Length; i++)
			{
				char c = run.Text[i];
				if (c != '\f' && c != '\u000e')
				{
					bool flag = c == '\t' && !x6c1c90120947c83c;
					bool flag2 = c == '\v' && !xe8e73ade9b8e9bb2;
					if (flag || flag2)
					{
						stringBuilder.Append(' ');
					}
					else
					{
						stringBuilder.Append(c);
					}
				}
			}
			run.Text = stringBuilder.ToString();
			break;
		}
		case NodeType.Comment:
		case NodeType.CommentRangeStart:
		case NodeType.CommentRangeEnd:
			return null;
		}
		return xc926b680b06084a7;
	}

	Node xe83a6b069ec8efc2.x57f70b425b43a885(Node x98cacf1c34b53cca, Node xc926b680b06084a7, bool xdc5889e5d1efc748)
	{
		//ILSpy generated this explicit interface implementation from .override directive in x65611a033680c59d
		return this.x65611a033680c59d(x98cacf1c34b53cca, xc926b680b06084a7, xdc5889e5d1efc748);
	}
}
