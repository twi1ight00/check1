using Aspose.Words;
using Aspose.Words.Fields;
using x28925c9b27b37a46;
using x6c95d9cf46ff5f25;
using xfbd1009a0cbb9842;

namespace x2182451cabb5c30d;

internal abstract class x92b42501109671de : x3b57052406b93b82
{
	private FieldStart xba47e1f61097ef1c;

	protected abstract string FieldTypeName { get; }

	protected x92b42501109671de(xe5e546ef5f0503b2 context)
		: base(context)
	{
	}

	protected void x0769cdcc579bd707(x03f56b37a0050a82 x153c99a852375422)
	{
		xba47e1f61097ef1c = base.xe1410f585439c7d4.xcf72734b7092bebe();
		base.xe1410f585439c7d4.x93a8c149d218a60f(FieldTypeName);
	}

	protected void xbbbbc5ea4258e1a4()
	{
		x7e263f21a73a027a x7e263f21a73a027a = new x7e263f21a73a027a(xba47e1f61097ef1c.NextSibling.NextSibling, base.xe1410f585439c7d4.xc255c495fd9232ca.LastChild);
		base.xe1410f585439c7d4.x93a8c149d218a60f(" ");
		WriteSwitches();
		FieldEnd end = base.xe1410f585439c7d4.x3bb349c77392b35c();
		if (xba47e1f61097ef1c.xeedad81aaed42a76.x96e55b5d052d1279.x4e98cd0cf854343f())
		{
			x7e263f21a73a027a x7e263f21a73a027a2 = new x7e263f21a73a027a(xba47e1f61097ef1c, end);
			foreach (Node item in x7e263f21a73a027a2)
			{
				if (item is xcf3b0f04424de818 xcf3b0f04424de)
				{
					xcf3b0f04424de.xc87649c48f7756d2.x52b190e626f65140(130);
				}
			}
		}
		else
		{
			x0a28863c804404d7.x775521112ede5e6f(x7e263f21a73a027a, xba47e1f61097ef1c, new x78f7ad9d7fd68e82(isTrimDoubleQuotes: true));
		}
		string text = x9f265cdf86e37e15.x633d57e35b6715a4(x7e263f21a73a027a);
		bool flag = text.StartsWith("\"");
		bool flag2 = text.EndsWith("\"");
		if ((flag && flag2) || !x0d299f323d241756.x6df149467337111e(text))
		{
			return;
		}
		if (!flag)
		{
			Node node2 = x7e263f21a73a027a.x12cb12b5d2cad53d.x40212106aad8a8b0;
			while (!(node2 is xcf3b0f04424de818))
			{
				node2 = node2.NextSibling;
			}
			Run newChild = new Run(base.x2c8c6741422a1298, "\"", (xeedad81aaed42a76)((xcf3b0f04424de818)node2).xc87649c48f7756d2.x8b61531c8ea35b85());
			node2.ParentNode.InsertBefore(newChild, node2);
		}
		if (!flag2)
		{
			Node node3 = x7e263f21a73a027a.x9fd888e65466818c.x40212106aad8a8b0;
			while (!(node3 is xcf3b0f04424de818))
			{
				node3 = node3.PreviousSibling;
			}
			Run newChild2 = new Run(base.x2c8c6741422a1298, "\"", (xeedad81aaed42a76)((xcf3b0f04424de818)node3).xc87649c48f7756d2.x8b61531c8ea35b85());
			node3.ParentNode.InsertAfter(newChild2, node3);
		}
	}

	protected abstract void WriteSwitches();
}
