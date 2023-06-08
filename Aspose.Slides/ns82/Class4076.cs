using System;

namespace ns82;

internal abstract class Class4076 : Class4075, Interface85
{
	private const int int_5 = -1;

	protected internal Interface110 interface110_0;

	public virtual Interface110 CharStream
	{
		get
		{
			return interface110_0;
		}
		set
		{
			interface110_0 = null;
			Reset();
			interface110_0 = value;
		}
	}

	public override string SourceName => interface110_0.SourceName;

	public override Interface107 Input => interface110_0;

	public virtual int Line => interface110_0.Line;

	public virtual int CharPositionInLine => interface110_0.CharPositionInLine;

	public virtual int CharIndex => interface110_0.imethod_3();

	public virtual string Text
	{
		get
		{
			if (class4397_0.string_0 != null)
			{
				return class4397_0.string_0;
			}
			return interface110_0.imethod_9(class4397_0.int_4, CharIndex - 1);
		}
		set
		{
			class4397_0.string_0 = value;
		}
	}

	public Class4076()
	{
	}

	public Class4076(Interface110 input)
	{
		interface110_0 = input;
	}

	public Class4076(Interface110 input, Class4397 state)
		: base(state)
	{
		interface110_0 = input;
	}

	public override void Reset()
	{
		base.Reset();
		if (interface110_0 != null)
		{
			interface110_0.Seek(0);
		}
		if (class4397_0 != null)
		{
			class4397_0.interface86_0 = null;
			class4397_0.int_8 = 0;
			class4397_0.int_7 = 0;
			class4397_0.int_4 = -1;
			class4397_0.int_6 = -1;
			class4397_0.int_5 = -1;
			class4397_0.string_0 = null;
		}
	}

	public virtual Interface86 imethod_0()
	{
		while (true)
		{
			class4397_0.interface86_0 = null;
			class4397_0.int_7 = 0;
			class4397_0.int_4 = interface110_0.imethod_3();
			class4397_0.int_6 = interface110_0.CharPositionInLine;
			class4397_0.int_5 = interface110_0.Line;
			class4397_0.string_0 = null;
			if (interface110_0.imethod_1(1) == -1)
			{
				break;
			}
			try
			{
				vmethod_30();
				if (class4397_0.interface86_0 == null)
				{
					vmethod_32();
					goto IL_00aa;
				}
				if (class4397_0.interface86_0 != Class4398.interface86_2)
				{
					goto IL_00aa;
				}
				goto end_IL_0077;
				IL_00aa:
				return class4397_0.interface86_0;
				end_IL_0077:;
			}
			catch (Exception27 exception)
			{
				vmethod_4(exception);
				vmethod_37(exception);
			}
			catch (Exception17 e)
			{
				vmethod_4(e);
			}
		}
		return Class4398.interface86_0;
	}

	public void method_3()
	{
		class4397_0.interface86_0 = Class4398.interface86_2;
	}

	public abstract void vmethod_30();

	public virtual void vmethod_31(Interface86 token)
	{
		class4397_0.interface86_0 = token;
	}

	public virtual Interface86 vmethod_32()
	{
		Interface86 @interface = new Class4093(interface110_0, class4397_0.int_8, class4397_0.int_7, class4397_0.int_4, CharIndex - 1);
		@interface.Line = class4397_0.int_5;
		@interface.Text = class4397_0.string_0;
		@interface.CharPositionInLine = class4397_0.int_6;
		vmethod_31(@interface);
		return @interface;
	}

	public virtual void vmethod_33(string s)
	{
		int num = 0;
		while (true)
		{
			if (num < s.Length)
			{
				if (interface110_0.imethod_1(1) != s[num])
				{
					break;
				}
				num++;
				interface110_0.imethod_0();
				class4397_0.bool_1 = false;
				continue;
			}
			return;
		}
		if (class4397_0.int_3 <= 0)
		{
			Exception23 exception = new Exception23(s[num], interface110_0);
			vmethod_37(exception);
			throw exception;
		}
		class4397_0.bool_1 = true;
	}

	public virtual void vmethod_34()
	{
		interface110_0.imethod_0();
	}

	public virtual void vmethod_35(int c)
	{
		if (interface110_0.imethod_1(1) != c)
		{
			if (class4397_0.int_3 <= 0)
			{
				Exception23 exception = new Exception23(c, interface110_0);
				vmethod_37(exception);
				throw exception;
			}
			class4397_0.bool_1 = true;
		}
		else
		{
			interface110_0.imethod_0();
			class4397_0.bool_1 = false;
		}
	}

	public virtual void vmethod_36(int a, int b)
	{
		if (interface110_0.imethod_1(1) >= a && interface110_0.imethod_1(1) <= b)
		{
			interface110_0.imethod_0();
			class4397_0.bool_1 = false;
			return;
		}
		if (class4397_0.int_3 <= 0)
		{
			Exception22 exception = new Exception22(a, b, interface110_0);
			vmethod_37(exception);
			throw exception;
		}
		class4397_0.bool_1 = true;
	}

	public virtual void vmethod_37(Exception17 re)
	{
		interface110_0.imethod_0();
	}

	public override void vmethod_4(Exception17 e)
	{
		vmethod_5(TokenNames, e);
	}

	public override string vmethod_6(Exception17 e, string[] tokenNames)
	{
		string text = null;
		if (e is Exception23)
		{
			Exception23 exception = (Exception23)e;
			return "mismatched character " + smethod_2(e.Char) + " expecting " + smethod_2(exception.Expecting);
		}
		if (e is Exception27)
		{
			Exception27 exception2 = (Exception27)e;
			return "no viable alternative at character " + smethod_2(exception2.Char);
		}
		if (e is Exception18)
		{
			Exception18 exception3 = (Exception18)e;
			return "required (...)+ loop did not match anything at character " + smethod_2(exception3.Char);
		}
		if (e is Exception21)
		{
			Exception20 exception4 = (Exception20)e;
			return "mismatched character " + smethod_2(exception4.Char) + " expecting set " + exception4.class4391_0;
		}
		if (e is Exception20)
		{
			Exception20 exception5 = (Exception20)e;
			return "mismatched character " + smethod_2(exception5.Char) + " expecting set " + exception5.class4391_0;
		}
		if (e is Exception22)
		{
			Exception22 exception6 = (Exception22)e;
			return "mismatched character " + smethod_2(exception6.Char) + " expecting set " + smethod_2(exception6.A) + ".." + smethod_2(exception6.B);
		}
		return base.vmethod_6(e, tokenNames);
	}

	public static string smethod_2(int c)
	{
		return "'" + c switch
		{
			9 => "\\t", 
			10 => "\\n", 
			13 => "\\r", 
			-1 => "<EOF>", 
			_ => Convert.ToString((char)c), 
		} + "'";
	}

	public virtual void vmethod_38(string ruleName, int ruleIndex)
	{
		string inputSymbol = (char)interface110_0.imethod_8(1) + " line=" + Line + ":" + CharPositionInLine;
		base.vmethod_22(ruleName, ruleIndex, inputSymbol);
	}

	public virtual void vmethod_39(string ruleName, int ruleIndex)
	{
		string inputSymbol = (char)interface110_0.imethod_8(1) + " line=" + Line + ":" + CharPositionInLine;
		base.vmethod_23(ruleName, ruleIndex, inputSymbol);
	}
}
