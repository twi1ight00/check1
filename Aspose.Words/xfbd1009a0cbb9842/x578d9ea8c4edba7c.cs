using Aspose.Words;
using Aspose.Words.Fields;
using x28925c9b27b37a46;

namespace xfbd1009a0cbb9842;

internal class x578d9ea8c4edba7c
{
	private x578d9ea8c4edba7c()
	{
	}

	internal static x7e263f21a73a027a x2df35d3afd4c6380(x7e263f21a73a027a xdb7cb868f37462c7)
	{
		x98739d759efb5fe7 x98739d759efb5fe = xdb7cb868f37462c7.x12cb12b5d2cad53d.x8b61531c8ea35b85();
		if (x98739d759efb5fe.x40212106aad8a8b0.NodeType == NodeType.FieldSeparator)
		{
			x98739d759efb5fe = xb82177674abffa74(x98739d759efb5fe);
		}
		x98739d759efb5fe7 x98739d759efb5fe2 = xdb7cb868f37462c7.x9fd888e65466818c.x8b61531c8ea35b85();
		if (x98739d759efb5fe2.x40212106aad8a8b0.NodeType == NodeType.FieldEnd)
		{
			FieldEnd fieldEnd = (FieldEnd)x98739d759efb5fe2.x40212106aad8a8b0;
			if (fieldEnd.FieldType == FieldType.FieldMacroButton || fieldEnd.FieldType == FieldType.FieldGoToButton)
			{
				x98739d759efb5fe2.x9e19f5bd0a6dd5b7(null, xa17853d20c8c42bd: false, x0d900d42b3598fde: false, x2709983bf2ac093e: false, xa5486b84e3604cca: false, xad9f70dbf5281236: false);
				x98739d759efb5fe2.x8a92b04b9d325900();
			}
		}
		return new x7e263f21a73a027a(x98739d759efb5fe, x98739d759efb5fe2);
	}

	private static x98739d759efb5fe7 xb82177674abffa74(x98739d759efb5fe7 xed9a565596a6ae3f)
	{
		int num = 0;
		while (true)
		{
			xed9a565596a6ae3f.x9e19f5bd0a6dd5b7(null, xa17853d20c8c42bd: false, x0d900d42b3598fde: false, x2709983bf2ac093e: false, xa5486b84e3604cca: false, xad9f70dbf5281236: false);
			switch (xed9a565596a6ae3f.x40212106aad8a8b0.NodeType)
			{
			case NodeType.FieldStart:
				if (num == 0)
				{
					xed9a565596a6ae3f.xac0bfd155c704ff8();
					return xed9a565596a6ae3f;
				}
				num--;
				break;
			case NodeType.FieldEnd:
				num++;
				break;
			}
		}
	}
}
