using ns305;
using ns73;
using ns88;

namespace ns74;

internal class Class3693 : Class3679
{
	private short short_5;

	private string string_0;

	public override string CSSText
	{
		get
		{
			return string_0;
		}
		set
		{
			throw new Exception73(Enum968.const_8);
		}
	}

	public Class3693(Interface99 lexicalUnit)
		: base(3)
	{
		short_5 = lexicalUnit.LexicalUnitType;
		string_0 = lexicalUnit.imethod_5();
	}

	protected override bool Equals(Class3679 obj)
	{
		Class3693 objB = obj as Class3693;
		if (object.ReferenceEquals(null, objB))
		{
			return false;
		}
		if (object.ReferenceEquals(this, objB))
		{
			return true;
		}
		return short_5.Equals(short_5);
	}
}
