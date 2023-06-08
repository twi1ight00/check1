using System.Drawing;
using System.Runtime.CompilerServices;
using ns5;

namespace ns6;

internal class Class908
{
	private StringAlignment stringAlignment_0;

	private StringAlignment stringAlignment_1;

	private Enum105 enum105_0;

	private Enum107 enum107_0 = Enum107.const_2;

	public StringAlignment TextHorizontalAlignment
	{
		get
		{
			return stringAlignment_0;
		}
		set
		{
			stringAlignment_0 = value;
		}
	}

	public StringAlignment TextVerticalAlignment
	{
		get
		{
			return stringAlignment_1;
		}
		set
		{
			stringAlignment_1 = value;
		}
	}

	public Enum105 TextDirection
	{
		set
		{
			enum105_0 = value;
		}
	}

	[SpecialName]
	public void method_0(Enum107 enum107_1)
	{
		enum107_0 = enum107_1;
	}
}
