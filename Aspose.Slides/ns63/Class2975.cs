using ns60;

namespace ns63;

internal class Class2975 : Interface40
{
	private short short_0;

	private short short_1;

	private bool bool_0;

	private bool bool_1;

	public short? LeftMargin
	{
		get
		{
			if (!bool_0)
			{
				return null;
			}
			return short_0;
		}
		set
		{
			if (value.HasValue)
			{
				short_0 = value.Value;
			}
			bool_0 = value.HasValue;
		}
	}

	public short? Indent
	{
		get
		{
			if (!bool_1)
			{
				return null;
			}
			return short_1;
		}
		set
		{
			if (value.HasValue)
			{
				short_1 = value.Value;
			}
			bool_1 = value.HasValue;
		}
	}
}
