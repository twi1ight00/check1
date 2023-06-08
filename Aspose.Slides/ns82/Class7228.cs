using System;

namespace ns82;

internal abstract class Class7228 : Class7226, Interface394
{
	private const int int_5 = -1;

	protected internal Interface391 interface391_0;

	public virtual Interface391 CharStream
	{
		get
		{
			return interface391_0;
		}
		set
		{
			interface391_0 = null;
			Reset();
			interface391_0 = value;
		}
	}

	public override string SourceName => interface391_0.SourceName;

	public override Interface388 Input => interface391_0;

	public virtual int Line => interface391_0.Line;

	public virtual int CharPositionInLine => interface391_0.CharPositionInLine;

	public virtual int CharIndex => interface391_0.imethod_3();

	public virtual string Text
	{
		get
		{
			if (class7345_0.string_0 != null)
			{
				return class7345_0.string_0;
			}
			return interface391_0.imethod_9(class7345_0.int_4, CharIndex - 1);
		}
		set
		{
			class7345_0.string_0 = value;
		}
	}

	public Class7228()
	{
	}

	public Class7228(Interface391 input)
	{
		interface391_0 = input;
	}

	public Class7228(Interface391 input, Class7345 state)
		: base(state)
	{
		interface391_0 = input;
	}

	public override void Reset()
	{
		base.Reset();
		if (interface391_0 != null)
		{
			interface391_0.Seek(0);
		}
		if (class7345_0 != null)
		{
			class7345_0.interface392_0 = null;
			class7345_0.int_8 = 0;
			class7345_0.int_7 = 0;
			class7345_0.int_4 = -1;
			class7345_0.int_6 = -1;
			class7345_0.int_5 = -1;
			class7345_0.string_0 = null;
		}
	}

	public virtual Interface392 imethod_0()
	{
		while (true)
		{
			class7345_0.interface392_0 = null;
			class7345_0.int_7 = 0;
			class7345_0.int_4 = interface391_0.imethod_3();
			class7345_0.int_6 = interface391_0.CharPositionInLine;
			class7345_0.int_5 = interface391_0.Line;
			class7345_0.string_0 = null;
			if (interface391_0.imethod_1(1) == -1)
			{
				break;
			}
			try
			{
				vmethod_30();
				if (class7345_0.interface392_0 == null)
				{
					vmethod_32();
					goto IL_00aa;
				}
				if (class7345_0.interface392_0 != Class7346.interface392_2)
				{
					goto IL_00aa;
				}
				goto end_IL_0077;
				IL_00aa:
				return class7345_0.interface392_0;
				end_IL_0077:;
			}
			catch (Exception87 exception)
			{
				vmethod_4(exception);
				vmethod_37(exception);
			}
			catch (Exception77 e)
			{
				vmethod_4(e);
			}
		}
		return Class7346.interface392_0;
	}

	public void method_3()
	{
		class7345_0.interface392_0 = Class7346.interface392_2;
	}

	public abstract void vmethod_30();

	public virtual void vmethod_31(Interface392 token)
	{
		class7345_0.interface392_0 = token;
	}

	public virtual Interface392 vmethod_32()
	{
		Interface392 @interface = new Class7335(interface391_0, class7345_0.int_8, class7345_0.int_7, class7345_0.int_4, CharIndex - 1);
		@interface.Line = class7345_0.int_5;
		@interface.Text = class7345_0.string_0;
		@interface.CharPositionInLine = class7345_0.int_6;
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
				if (interface391_0.imethod_1(1) != s[num])
				{
					break;
				}
				num++;
				interface391_0.imethod_0();
				class7345_0.bool_1 = false;
				continue;
			}
			return;
		}
		if (class7345_0.int_3 <= 0)
		{
			Exception83 exception = new Exception83(s[num], interface391_0);
			vmethod_37(exception);
			throw exception;
		}
		class7345_0.bool_1 = true;
	}

	public virtual void vmethod_34()
	{
		interface391_0.imethod_0();
	}

	public virtual void vmethod_35(int c)
	{
		if (interface391_0.imethod_1(1) != c)
		{
			if (class7345_0.int_3 <= 0)
			{
				Exception83 exception = new Exception83(c, interface391_0);
				vmethod_37(exception);
				throw exception;
			}
			class7345_0.bool_1 = true;
		}
		else
		{
			interface391_0.imethod_0();
			class7345_0.bool_1 = false;
		}
	}

	public virtual void vmethod_36(int a, int b)
	{
		if (interface391_0.imethod_1(1) >= a && interface391_0.imethod_1(1) <= b)
		{
			interface391_0.imethod_0();
			class7345_0.bool_1 = false;
			return;
		}
		if (class7345_0.int_3 <= 0)
		{
			Exception82 exception = new Exception82(a, b, interface391_0);
			vmethod_37(exception);
			throw exception;
		}
		class7345_0.bool_1 = true;
	}

	public virtual void vmethod_37(Exception77 re)
	{
		interface391_0.imethod_0();
	}

	public override void vmethod_4(Exception77 e)
	{
		vmethod_5(TokenNames, e);
	}

	public override string vmethod_6(Exception77 e, string[] tokenNames)
	{
		string text = null;
		if (e is Exception83)
		{
			Exception83 exception = (Exception83)e;
			return "mismatched character " + smethod_2(e.Char) + " expecting " + smethod_2(exception.Expecting);
		}
		if (e is Exception87)
		{
			Exception87 exception2 = (Exception87)e;
			return "no viable alternative at character " + smethod_2(exception2.Char);
		}
		if (e is Exception78)
		{
			Exception78 exception3 = (Exception78)e;
			return "required (...)+ loop did not match anything at character " + smethod_2(exception3.Char);
		}
		if (e is Exception81)
		{
			Exception80 exception4 = (Exception80)e;
			return "mismatched character " + smethod_2(exception4.Char) + " expecting set " + exception4.class7332_0;
		}
		if (e is Exception80)
		{
			Exception80 exception5 = (Exception80)e;
			return "mismatched character " + smethod_2(exception5.Char) + " expecting set " + exception5.class7332_0;
		}
		if (e is Exception82)
		{
			Exception82 exception6 = (Exception82)e;
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
		string inputSymbol = (char)interface391_0.imethod_8(1) + " line=" + Line + ":" + CharPositionInLine;
		base.vmethod_22(ruleName, ruleIndex, inputSymbol);
	}

	public virtual void vmethod_39(string ruleName, int ruleIndex)
	{
		string inputSymbol = (char)interface391_0.imethod_8(1) + " line=" + Line + ":" + CharPositionInLine;
		base.vmethod_23(ruleName, ruleIndex, inputSymbol);
	}
}
