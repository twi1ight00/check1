using System.Diagnostics;

namespace ns73;

[DebuggerDisplay("{CSSText}")]
internal abstract class Class3679
{
	public const short short_0 = 0;

	public const short short_1 = 1;

	public const short short_2 = 2;

	public const short short_3 = 3;

	private short short_4;

	public abstract string CSSText { get; set; }

	public short CSSValueType => short_4;

	protected internal Class3679(short valueType)
	{
		short_4 = valueType;
	}

	public override string ToString()
	{
		return CSSText;
	}

	protected virtual bool Equals(Class3679 obj)
	{
		if (object.ReferenceEquals(null, obj))
		{
			return false;
		}
		if (object.ReferenceEquals(this, obj))
		{
			return true;
		}
		return short_4 == obj.short_4;
	}

	public override bool Equals(object obj)
	{
		return Equals(obj as Class3679);
	}
}
