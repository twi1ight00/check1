using ns82;

namespace ns83;

internal class Class7211 : Class7210
{
	public int int_0 = -1;

	public int int_1 = -1;

	protected Interface392 interface392_0;

	public Class7211 class7211_0;

	public int int_2 = -1;

	public virtual Interface392 Token => interface392_0;

	public override bool IsNil => interface392_0 == null;

	public override int Type
	{
		get
		{
			if (interface392_0 == null)
			{
				return 0;
			}
			return interface392_0.Type;
		}
	}

	public override string Text
	{
		get
		{
			if (interface392_0 == null)
			{
				return null;
			}
			return interface392_0.Text;
		}
	}

	public override int Line
	{
		get
		{
			if (interface392_0 != null && interface392_0.Line != 0)
			{
				return interface392_0.Line;
			}
			if (ChildCount > 0)
			{
				return imethod_1(0).Line;
			}
			return 0;
		}
	}

	public override int CharPositionInLine
	{
		get
		{
			if (interface392_0 != null && interface392_0.CharPositionInLine != -1)
			{
				return interface392_0.CharPositionInLine;
			}
			if (ChildCount > 0)
			{
				return imethod_1(0).CharPositionInLine;
			}
			return 0;
		}
	}

	public override int TokenStartIndex
	{
		get
		{
			if (int_0 == -1 && interface392_0 != null)
			{
				return interface392_0.TokenIndex;
			}
			return int_0;
		}
		set
		{
			int_0 = value;
		}
	}

	public override int TokenStopIndex
	{
		get
		{
			if (int_1 == -1 && interface392_0 != null)
			{
				return interface392_0.TokenIndex;
			}
			return int_1;
		}
		set
		{
			int_1 = value;
		}
	}

	public override int ChildIndex
	{
		get
		{
			return int_2;
		}
		set
		{
			int_2 = value;
		}
	}

	public override Interface386 Parent
	{
		get
		{
			return class7211_0;
		}
		set
		{
			class7211_0 = (Class7211)value;
		}
	}

	public Class7211()
	{
	}

	public Class7211(Class7211 node)
		: base(node)
	{
		interface392_0 = node.interface392_0;
		int_0 = node.int_0;
		int_1 = node.int_1;
	}

	public Class7211(Interface392 t)
	{
		interface392_0 = t;
	}

	public override Interface386 imethod_6()
	{
		return new Class7211(this);
	}

	public override string ToString()
	{
		if (IsNil)
		{
			return "nil";
		}
		if (Type == 0)
		{
			return "<errornode>";
		}
		if (interface392_0 == null)
		{
			return null;
		}
		return interface392_0.Text;
	}
}
