using ns305;
using ns73;

namespace ns74;

internal class Class3692 : Class3679
{
	private Class3679 class3679_0;

	public override string CSSText
	{
		get
		{
			return class3679_0.CSSText;
		}
		set
		{
			throw new Exception73(Enum968.const_8);
		}
	}

	public Class3692(Class3679 value)
		: base(3)
	{
		class3679_0 = value;
	}

	protected override bool Equals(Class3679 obj)
	{
		Class3692 @class = obj as Class3692;
		if (object.ReferenceEquals(null, @class))
		{
			return false;
		}
		if (object.ReferenceEquals(this, @class))
		{
			return true;
		}
		return class3679_0.Equals(@class.class3679_0);
	}
}
