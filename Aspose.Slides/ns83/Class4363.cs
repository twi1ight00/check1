using ns82;

namespace ns83;

internal class Class4363 : Class4362
{
	public int int_0 = -1;

	public int int_1 = -1;

	protected Interface86 interface86_0;

	public Class4363 class4363_0;

	public int int_2 = -1;

	public virtual Interface86 Token => interface86_0;

	public override bool IsNil => interface86_0 == null;

	public override int Type
	{
		get
		{
			if (interface86_0 == null)
			{
				return 0;
			}
			return interface86_0.Type;
		}
	}

	public override string Text
	{
		get
		{
			if (interface86_0 == null)
			{
				return null;
			}
			return interface86_0.Text;
		}
	}

	public override int Line
	{
		get
		{
			if (interface86_0 != null && interface86_0.Line != 0)
			{
				return interface86_0.Line;
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
			if (interface86_0 != null && interface86_0.CharPositionInLine != -1)
			{
				return interface86_0.CharPositionInLine;
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
			if (int_0 == -1 && interface86_0 != null)
			{
				return interface86_0.TokenIndex;
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
			if (int_1 == -1 && interface86_0 != null)
			{
				return interface86_0.TokenIndex;
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

	public override Interface105 Parent
	{
		get
		{
			return class4363_0;
		}
		set
		{
			class4363_0 = (Class4363)value;
		}
	}

	public Class4363()
	{
	}

	public Class4363(Class4363 node)
		: base(node)
	{
		interface86_0 = node.interface86_0;
		int_0 = node.int_0;
		int_1 = node.int_1;
	}

	public Class4363(Interface86 t)
	{
		interface86_0 = t;
	}

	public override Interface105 imethod_6()
	{
		return new Class4363(this);
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
		if (interface86_0 == null)
		{
			return null;
		}
		return interface86_0.Text;
	}
}
