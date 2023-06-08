using Aspose.Words.Markup;

namespace x53eb9320ebbb8395;

internal class x4687977089abc632 : xce81d6edccc8b285
{
	private bool xab258248e0fd6545;

	private readonly bool xf523bbf0be0ee426;

	internal bool xe3ccff5629a1e888
	{
		get
		{
			return xab258248e0fd6545;
		}
		set
		{
			xab258248e0fd6545 = value;
		}
	}

	internal override SdtType x3146d638ec378671
	{
		get
		{
			if (!xf523bbf0be0ee426)
			{
				return SdtType.PlainText;
			}
			return SdtType.RichText;
		}
	}

	internal x4687977089abc632(bool isRichText)
	{
		xf523bbf0be0ee426 = isRichText;
	}
}
