using System;
using ns83;

namespace ns82;

internal class Exception77 : Exception
{
	[NonSerialized]
	protected Interface388 interface388_0;

	protected int int_0;

	protected Interface392 interface392_0;

	protected object object_0;

	protected int int_1;

	protected int int_2;

	protected int int_3;

	public bool bool_0;

	public Interface388 Input
	{
		get
		{
			return interface388_0;
		}
		set
		{
			interface388_0 = value;
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

	public Interface392 Token
	{
		get
		{
			return interface392_0;
		}
		set
		{
			interface392_0 = value;
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
			if (interface388_0 is Interface393)
			{
				return interface392_0.Type;
			}
			if (interface388_0 is Interface389)
			{
				Interface389 @interface = (Interface389)interface388_0;
				Interface387 treeAdaptor = @interface.TreeAdaptor;
				return treeAdaptor.imethod_14(object_0);
			}
			return int_1;
		}
	}

	public Exception77()
		: this(null, null, null)
	{
	}

	public Exception77(string message)
		: this(message, null, null)
	{
	}

	public Exception77(string message, Exception inner)
		: this(message, inner, null)
	{
	}

	public Exception77(Interface388 input)
		: this(null, null, input)
	{
	}

	public Exception77(string message, Interface388 input)
		: this(message, null, input)
	{
	}

	public Exception77(string message, Exception inner, Interface388 input)
		: base(message, inner)
	{
		interface388_0 = input;
		int_0 = input.imethod_3();
		if (input is Interface393)
		{
			interface392_0 = ((Interface393)input).imethod_8(1);
			int_2 = interface392_0.Line;
			int_3 = interface392_0.CharPositionInLine;
		}
		if (input is Interface389)
		{
			method_0(input);
		}
		else if (input is Interface391)
		{
			int_1 = input.imethod_1(1);
			int_2 = ((Interface391)input).Line;
			int_3 = ((Interface391)input).CharPositionInLine;
		}
		else
		{
			int_1 = input.imethod_1(1);
		}
	}

	protected void method_0(Interface388 input)
	{
		Interface389 @interface = (Interface389)input;
		object_0 = @interface.imethod_9(1);
		Interface387 treeAdaptor = @interface.TreeAdaptor;
		Interface392 interface2 = treeAdaptor.imethod_18(object_0);
		if (interface2 != null)
		{
			interface392_0 = interface2;
			if (interface2.Line <= 0)
			{
				int num = -1;
				object obj = @interface.imethod_9(-1);
				Interface392 interface3;
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
		else if (object_0 is Interface386)
		{
			int_2 = ((Interface386)object_0).Line;
			int_3 = ((Interface386)object_0).CharPositionInLine;
			if (object_0 is Class7211)
			{
				interface392_0 = ((Class7211)object_0).Token;
			}
		}
		else
		{
			int type = treeAdaptor.imethod_14(object_0);
			string text = treeAdaptor.imethod_16(object_0);
			interface392_0 = new Class7335(type, text);
		}
	}
}
