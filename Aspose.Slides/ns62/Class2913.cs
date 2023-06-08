namespace ns62;

internal class Class2913 : Class2911
{
	public Class2913(Enum426 id, uint value)
		: base(id, value)
	{
	}

	public Class2913(Enum426 id, bool isBid, uint value)
		: base(id, isBid, value)
	{
	}

	public static bool operator ==(Class2913 x, Class2913 y)
	{
		if (object.ReferenceEquals(x, y))
		{
			return true;
		}
		if (object.ReferenceEquals(x, null))
		{
			return false;
		}
		if (object.ReferenceEquals(y, null))
		{
			return false;
		}
		return x.vmethod_1(y);
	}

	public static bool operator !=(Class2913 x, Class2913 y)
	{
		return !(x == y);
	}

	protected virtual bool vmethod_1(Class2913 flags)
	{
		if (GetType() == flags.GetType())
		{
			return base.Value == flags.Value;
		}
		return false;
	}
}
