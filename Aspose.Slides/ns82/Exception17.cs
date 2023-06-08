using System;
using ns83;

namespace ns82;

internal class Exception17 : Exception
{
	[NonSerialized]
	protected Interface107 interface107_0;

	protected int int_0;

	protected Interface86 interface86_0;

	protected object object_0;

	protected int int_1;

	protected int int_2;

	protected int int_3;

	public bool bool_0;

	public Interface107 Input
	{
		get
		{
			return interface107_0;
		}
		set
		{
			interface107_0 = value;
		}
	}

	public int Index
	{
		get
		{
			return int_0;
		}
		set
		{
			int_0 = value;
		}
	}

	public Interface86 Token
	{
		get
		{
			return interface86_0;
		}
		set
		{
			interface86_0 = value;
		}
	}

	public object Node
	{
		get
		{
			return object_0;
		}
		set
		{
			object_0 = value;
		}
	}

	public int Char
	{
		get
		{
			return int_1;
		}
		set
		{
			int_1 = value;
		}
	}

	public int CharPositionInLine
	{
		get
		{
			return int_3;
		}
		set
		{
			int_3 = value;
		}
	}

	public int Line
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

	public virtual int UnexpectedType
	{
		get
		{
			if (interface107_0 is Interface111)
			{
				return interface86_0.Type;
			}
			if (interface107_0 is Interface108)
			{
				Interface108 @interface = (Interface108)interface107_0;
				Interface106 treeAdaptor = @interface.TreeAdaptor;
				return treeAdaptor.imethod_14(object_0);
			}
			return int_1;
		}
	}

	public Exception17()
		: this(null, null, null)
	{
	}

	public Exception17(string message)
		: this(message, null, null)
	{
	}

	public Exception17(string message, Exception inner)
		: this(message, inner, null)
	{
	}

	public Exception17(Interface107 input)
		: this(null, null, input)
	{
	}

	public Exception17(string message, Interface107 input)
		: this(message, null, input)
	{
	}

	public Exception17(string message, Exception inner, Interface107 input)
		: base(message, inner)
	{
		interface107_0 = input;
		int_0 = input.imethod_3();
		if (input is Interface111)
		{
			interface86_0 = ((Interface111)input).imethod_8(1);
			int_2 = interface86_0.Line;
			int_3 = interface86_0.CharPositionInLine;
		}
		if (input is Interface108)
		{
			method_0(input);
		}
		else if (input is Interface110)
		{
			int_1 = input.imethod_1(1);
			int_2 = ((Interface110)input).Line;
			int_3 = ((Interface110)input).CharPositionInLine;
		}
		else
		{
			int_1 = input.imethod_1(1);
		}
	}

	protected void method_0(Interface107 input)
	{
		Interface108 @interface = (Interface108)input;
		object_0 = @interface.imethod_9(1);
		Interface106 treeAdaptor = @interface.TreeAdaptor;
		Interface86 interface2 = treeAdaptor.imethod_18(object_0);
		if (interface2 != null)
		{
			interface86_0 = interface2;
			if (interface2.Line <= 0)
			{
				int num = -1;
				object obj = @interface.imethod_9(-1);
				Interface86 interface3;
				while (true)
				{
					if (obj != null)
					{
						interface3 = treeAdaptor.imethod_18(obj);
						if (interface3 != null && interface3.Line > 0)
						{
							break;
						}
						num--;
						obj = @interface.imethod_9(num);
						continue;
					}
					return;
				}
				int_2 = interface3.Line;
				int_3 = interface3.CharPositionInLine;
				bool_0 = true;
			}
			else
			{
				int_2 = interface2.Line;
				int_3 = interface2.CharPositionInLine;
			}
		}
		else if (object_0 is Interface105)
		{
			int_2 = ((Interface105)object_0).Line;
			int_3 = ((Interface105)object_0).CharPositionInLine;
			if (object_0 is Class4363)
			{
				interface86_0 = ((Class4363)object_0).Token;
			}
		}
		else
		{
			int type = treeAdaptor.imethod_14(object_0);
			string text = treeAdaptor.imethod_16(object_0);
			interface86_0 = new Class4093(type, text);
		}
	}
}
