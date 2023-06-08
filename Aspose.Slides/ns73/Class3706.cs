using ns76;

namespace ns73;

internal abstract class Class3706 : Interface59
{
	public const short short_0 = 0;

	public const short short_1 = 1;

	public const short short_2 = 2;

	public const short short_3 = 3;

	public const short short_4 = 4;

	public const short short_5 = 5;

	public const short short_6 = 6;

	public const short short_7 = 11;

	private Class3735 class3735_0;

	private Interface59 interface59_0;

	private short short_8;

	public short Type => short_8;

	public abstract string CSSText { get; set; }

	internal Class3735 ParentStyleSheet => class3735_0;

	Interface76 Interface59.ParentStyleSheet => class3735_0;

	public Interface59 ParentRule => interface59_0;

	internal Class3706(Class3735 styleSheet, Interface59 parentRule, short type)
	{
		class3735_0 = styleSheet;
		interface59_0 = parentRule;
		short_8 = type;
	}

	protected bool Equals(Class3706 other)
	{
		if (object.Equals(CSSText, other.CSSText))
		{
			return short_8 == other.short_8;
		}
		return false;
	}

	public override int GetHashCode()
	{
		return ((CSSText?.GetHashCode() ?? 0) * 397) ^ short_8.GetHashCode();
	}

	public static bool operator ==(Class3706 left, Class3706 right)
	{
		return object.Equals(left, right);
	}

	public static bool operator !=(Class3706 left, Class3706 right)
	{
		return !object.Equals(left, right);
	}

	public override bool Equals(object obj)
	{
		if (object.ReferenceEquals(null, obj))
		{
			return false;
		}
		if (object.ReferenceEquals(this, obj))
		{
			return true;
		}
		if (obj.GetType() != GetType())
		{
			return false;
		}
		return Equals((Class3706)obj);
	}
}
