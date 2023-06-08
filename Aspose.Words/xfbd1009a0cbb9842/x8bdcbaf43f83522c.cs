using System;
using System.Text;
using Aspose;
using Aspose.Words;
using Aspose.Words.Fields;
using x28925c9b27b37a46;

namespace xfbd1009a0cbb9842;

internal class x8bdcbaf43f83522c : x5c928e5f0a98a22c
{
	private readonly Field x54c413cc80cb99d5;

	private readonly xb56968f92e308c8a x7945f37de10c46e0;

	private x1b9dfa914d94b6e0 xc0f30b33b4e98ad1;

	private int xafc4b914f07c2d11;

	private int xb1b386f3683ab810;

	private bool x3e61945adbb4ad79;

	private x98739d759efb5fe7 xde172855d8887651 => x7945f37de10c46e0.x180f9c8380162d4e;

	private Node x3387295f12854dfd => x7945f37de10c46e0.x3387295f12854dfd;

	private bool x991897f13cf6aadc => xafc4b914f07c2d11 > 0;

	public x1b9dfa914d94b6e0 xd420ac3415caa02b => xc0f30b33b4e98ad1;

	public bool xdb33379fd4e83768 => xde172855d8887651.x375e8189a5358be0;

	public char x1efcac262b819134 => ((Run)x3387295f12854dfd).Text[xde172855d8887651.xf1d9b91c9700c401];

	public bool x0e410626c9576523 => x3e61945adbb4ad79;

	public int x5eddc5de8738680a
	{
		get
		{
			if (!(x3387295f12854dfd is Inline inline))
			{
				return 1024;
			}
			return inline.Font.LocaleId;
		}
	}

	public int x885d577f7c56563e
	{
		get
		{
			if (!(x3387295f12854dfd is Inline inline))
			{
				return 1024;
			}
			return inline.Font.LocaleIdFarEast;
		}
	}

	internal x8bdcbaf43f83522c(Field field)
		: this(field, moveToFirstToken: false)
	{
	}

	internal x8bdcbaf43f83522c(Field field, bool moveToFirstToken)
	{
		x54c413cc80cb99d5 = field;
		x7945f37de10c46e0 = new xb56968f92e308c8a(field.xabae4fa6681a6afd(x7d5e2f34b6651bf4.xb0b4ff1622a01d12));
		if (moveToFirstToken)
		{
			x2408a6db33935c93();
		}
	}

	internal static string xe6235ea181d3b309(Field xe01ae93d9fe5a880)
	{
		x8bdcbaf43f83522c x8bdcbaf43f83522c2 = new x8bdcbaf43f83522c(xe01ae93d9fe5a880);
		StringBuilder stringBuilder = new StringBuilder();
		while (x8bdcbaf43f83522c2.x2408a6db33935c93())
		{
			switch (x8bdcbaf43f83522c2.xd420ac3415caa02b)
			{
			case x1b9dfa914d94b6e0.x6fe652a9a79f74c7:
				if (!x8bdcbaf43f83522c2.xdb33379fd4e83768)
				{
					stringBuilder.Append(x8bdcbaf43f83522c2.x1efcac262b819134);
				}
				break;
			default:
				throw new ArgumentOutOfRangeException();
			case x1b9dfa914d94b6e0.x4465bafc6dc0d5e5:
			case x1b9dfa914d94b6e0.xfdc1a17f479acc42:
			case x1b9dfa914d94b6e0.x10d7a1cae426b158:
			case x1b9dfa914d94b6e0.x50e8abecd48a6d6a:
			case x1b9dfa914d94b6e0.xc6c75be6e65e2ee9:
				break;
			}
		}
		return stringBuilder.ToString();
	}

	[JavaConvertCheckedExceptions]
	public bool x2408a6db33935c93()
	{
		if (xc0f30b33b4e98ad1 == x1b9dfa914d94b6e0.x50e8abecd48a6d6a && x3387295f12854dfd.NodeType == NodeType.FieldEnd && x5c29822913be33c1.xb2cdffc8e47588c8(((FieldEnd)x3387295f12854dfd).FieldType))
		{
			xc0f30b33b4e98ad1 = x1b9dfa914d94b6e0.xc6c75be6e65e2ee9;
			return true;
		}
		do
		{
			bool flag = x3387295f12854dfd != null && x3387295f12854dfd.NodeType == NodeType.Table;
			bool flag2 = !x54c413cc80cb99d5.x21f09c4bcee72280 || x54c413cc80cb99d5.x6edce55dcd2d335b.x06768d79f7751c4d;
			bool x0d900d42b3598fde = !flag || flag2;
			if (!x7945f37de10c46e0.x1ef2c3be187f37a2(x0d900d42b3598fde, xbdbaf46b72254a00()))
			{
				x3e61945adbb4ad79 = true;
				return false;
			}
		}
		while (!x6a74f368397a67e2());
		return true;
	}

	private bool x6a74f368397a67e2()
	{
		if (x3387295f12854dfd is FieldChar)
		{
			return xa0ecc56397a1ba5c();
		}
		if (x991897f13cf6aadc)
		{
			return false;
		}
		return x2e0fe11ef677c63e();
	}

	private bool xa0ecc56397a1ba5c()
	{
		switch (x3387295f12854dfd.NodeType)
		{
		case NodeType.FieldStart:
			if (!x991897f13cf6aadc && x54c413cc80cb99d5.x21f09c4bcee72280)
			{
				x54c413cc80cb99d5.x6edce55dcd2d335b.xdc608dfe6805120e((FieldStart)x3387295f12854dfd);
			}
			xafc4b914f07c2d11++;
			xb1b386f3683ab810++;
			break;
		case NodeType.FieldSeparator:
			if (xc0f30b33b4e98ad1 == x1b9dfa914d94b6e0.x50e8abecd48a6d6a)
			{
				return false;
			}
			if (x5c29822913be33c1.xb2cdffc8e47588c8(((FieldSeparator)x3387295f12854dfd).FieldType))
			{
				return false;
			}
			xafc4b914f07c2d11--;
			if (!x991897f13cf6aadc)
			{
				xc0f30b33b4e98ad1 = x1b9dfa914d94b6e0.x50e8abecd48a6d6a;
				return true;
			}
			break;
		case NodeType.FieldEnd:
		{
			FieldEnd fieldEnd = (FieldEnd)x3387295f12854dfd;
			if (!fieldEnd.HasSeparator)
			{
				xafc4b914f07c2d11--;
				return false;
			}
			bool flag = x5c29822913be33c1.xb2cdffc8e47588c8(fieldEnd.FieldType);
			if (flag)
			{
				xafc4b914f07c2d11--;
			}
			bool flag2 = xc0f30b33b4e98ad1 == x1b9dfa914d94b6e0.x50e8abecd48a6d6a && xb1b386f3683ab810 > 1;
			xb1b386f3683ab810--;
			if (!x991897f13cf6aadc && !flag2)
			{
				xc0f30b33b4e98ad1 = (flag ? x1b9dfa914d94b6e0.x50e8abecd48a6d6a : x1b9dfa914d94b6e0.xc6c75be6e65e2ee9);
				return true;
			}
			break;
		}
		}
		return false;
	}

	private bool x2e0fe11ef677c63e()
	{
		switch (x3387295f12854dfd.NodeType)
		{
		case NodeType.Run:
		{
			Run run = (Run)x3387295f12854dfd;
			if (run.Text.Length == 0)
			{
				return false;
			}
			xc0f30b33b4e98ad1 = x1b9dfa914d94b6e0.x6fe652a9a79f74c7;
			break;
		}
		case NodeType.Paragraph:
			xc0f30b33b4e98ad1 = x1b9dfa914d94b6e0.xfdc1a17f479acc42;
			break;
		case NodeType.Section:
			xc0f30b33b4e98ad1 = x1b9dfa914d94b6e0.x10d7a1cae426b158;
			break;
		case NodeType.BookmarkStart:
		case NodeType.BookmarkEnd:
		case NodeType.SmartTag:
		case NodeType.CustomXmlMarkup:
		case NodeType.StructuredDocumentTag:
		case NodeType.CommentRangeStart:
		case NodeType.CommentRangeEnd:
			return false;
		default:
			xc0f30b33b4e98ad1 = x1b9dfa914d94b6e0.x4465bafc6dc0d5e5;
			break;
		}
		return true;
	}

	private bool xbdbaf46b72254a00()
	{
		if (x3387295f12854dfd == null)
		{
			return false;
		}
		switch (x3387295f12854dfd.NodeType)
		{
		case NodeType.BookmarkStart:
		case NodeType.BookmarkEnd:
		case NodeType.FieldStart:
		case NodeType.FieldSeparator:
		case NodeType.FieldEnd:
		case NodeType.SmartTag:
		case NodeType.CustomXmlMarkup:
		case NodeType.StructuredDocumentTag:
		case NodeType.CommentRangeStart:
		case NodeType.CommentRangeEnd:
			return true;
		default:
			return false;
		}
	}

	public x98739d759efb5fe7 x80766db8f9759629()
	{
		switch (xc0f30b33b4e98ad1)
		{
		case x1b9dfa914d94b6e0.x50e8abecd48a6d6a:
			return x98739d759efb5fe7.xeea9b43f0c912fdb(x3387295f12854dfd);
		case x1b9dfa914d94b6e0.xc6c75be6e65e2ee9:
			return x98739d759efb5fe7.xf86191ae51e45118(x3387295f12854dfd);
		default:
			if (!x3387295f12854dfd.IsComposite)
			{
				return xde172855d8887651.x8b61531c8ea35b85();
			}
			if (!xde172855d8887651.x83f9d074410e5abf)
			{
				return x3387295f12854dfd.x94cfa410ea3bb516();
			}
			return x3387295f12854dfd.x3df2fc2e9da31f50();
		}
	}
}
