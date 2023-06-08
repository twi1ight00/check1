using ns221;
using ns235;
using ns237;

namespace ns265;

internal abstract class Class6504
{
	[Attribute7(true)]
	public abstract void vmethod_0(Class6678 writer);

	public static Class6504 smethod_0(Class6270 hyperlink)
	{
		if (hyperlink.HyperlinkType == Enum802.const_0)
		{
			if (!hyperlink.IsLocal)
			{
				return new Class6509(hyperlink.Target);
			}
			return new Class6506(hyperlink.Target);
		}
		switch (hyperlink.JumpType)
		{
		default:
			return null;
		case Enum803.const_0:
			return new Class6506(hyperlink.Target);
		case Enum803.const_1:
			return Class6508.NextPage;
		case Enum803.const_2:
			return Class6508.PreviousPage;
		case Enum803.const_3:
			return Class6508.FirstPage;
		case Enum803.const_5:
			return Class6508.GoBack;
		case Enum803.const_4:
		case Enum803.const_6:
			return Class6508.LastPage;
		case Enum803.const_7:
			return new Class6507(hyperlink.Page + 1);
		}
	}

	public static Class6504 smethod_1(string uri)
	{
		return new Class6509(uri);
	}
}
