using ns305;
using ns73;

namespace ns74;

internal class Class3690 : Class3681
{
	private string string_0;

	public override string CSSText
	{
		get
		{
			return "url(" + string_0 + ')';
		}
		set
		{
			throw new Exception73(Enum968.const_14);
		}
	}

	public Class3690(string value)
		: base(20)
	{
		string_0 = value;
	}

	public override string vmethod_3()
	{
		return string_0;
	}

	protected override bool Equals(Class3679 obj)
	{
		Class3690 @class = obj as Class3690;
		if (object.ReferenceEquals(null, @class))
		{
			return false;
		}
		if (object.ReferenceEquals(this, @class))
		{
			return true;
		}
		if (base.CSSValueType.Equals(@class.CSSValueType))
		{
			return string_0.Equals(@class.string_0);
		}
		return false;
	}
}
