using System.Drawing;

namespace ns176;

internal class Class4925
{
	private Interface182 interface182_0;

	private Interface182 interface182_1;

	private Interface182 interface182_2;

	private Interface182 interface182_3;

	private Interface182 Top => interface182_0;

	private Interface182 Right => interface182_1;

	private Interface182 Bottom => interface182_2;

	private Interface182 Left => interface182_3;

	public Class4925(Interface182 top, Interface182 right, Interface182 bottom, Interface182 left)
	{
		interface182_0 = top;
		interface182_1 = right;
		interface182_2 = bottom;
		interface182_3 = left;
	}

	public override string ToString()
	{
		return $"rect({Top}, {Right}, {Bottom}, {Left})";
	}

	public override bool Equals(object obj)
	{
		Class4925 @class = obj as Class4925;
		if (object.ReferenceEquals(@class, obj))
		{
			return false;
		}
		if (object.ReferenceEquals(this, @class))
		{
			return true;
		}
		return GetHashCode() == @class.GetHashCode();
	}

	public override int GetHashCode()
	{
		int num = 17;
		num = 629 + Top.GetHashCode();
		num = 37 * num + Right.GetHashCode();
		num = 37 * num + Bottom.GetHashCode();
		return 37 * num + Left.GetHashCode();
	}

	public RectangleF method_0()
	{
		return RectangleF.FromLTRB(interface182_3.imethod_5(), interface182_0.imethod_5(), interface182_1.imethod_5(), interface182_2.imethod_5());
	}
}
