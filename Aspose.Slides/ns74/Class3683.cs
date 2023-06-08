using System.Text;
using ns305;
using ns73;

namespace ns74;

internal class Class3683 : Class3681
{
	private Class3680 class3680_0;

	private Class3680 class3680_1;

	public override string CSSText
	{
		get
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("counter(");
			stringBuilder.Append(class3680_0.vmethod_3());
			if (class3680_1 != null)
			{
				stringBuilder.Append(", ");
				stringBuilder.Append(class3680_1.vmethod_3());
			}
			stringBuilder.Append(")");
			return stringBuilder.ToString();
		}
		set
		{
			throw new Exception73(Enum968.const_14);
		}
	}

	public Class3683(Class3680 identifier, Class3680 listStyle)
		: base(23)
	{
		class3680_0 = identifier;
		class3680_1 = listStyle;
	}

	public override Class3698 vmethod_4()
	{
		return new Class3698(class3680_0.vmethod_3(), (class3680_1 != null) ? class3680_1.vmethod_3() : null, null);
	}
}
