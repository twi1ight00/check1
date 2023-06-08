using System;
using System.Collections;
using System.Diagnostics;

namespace ns82;

internal abstract class Class7226
{
	public const int int_0 = -2;

	public const int int_1 = -1;

	public const int int_2 = 100;

	public const int int_3 = 0;

	public const int int_4 = 99;

	public static readonly string string_0 = "nextToken";

	protected internal Class7345 class7345_0;

	public abstract Interface388 Input { get; }

	public int BacktrackingLevel => class7345_0.int_3;

	public int NumberOfSyntaxErrors => class7345_0.int_2;

	public virtual string GrammarFileName => null;

	public abstract string SourceName { get; }

	public virtual string[] TokenNames => null;

	public Class7226()
	{
		class7345_0 = new Class7345();
	}

	public Class7226(Class7345 state)
	{
		if (state == null)
		{
			state = new Class7345();
		}
		class7345_0 = state;
	}

	public virtual void vmethod_0(int level)
	{
	}

	public virtual void vmethod_1(int level, bool successful)
	{
	}

	public virtual void Reset()
	{
		if (class7345_0 != null)
		{
			class7345_0.int_0 = -1;
			class7345_0.bool_0 = false;
			class7345_0.int_1 = -1;
			class7345_0.bool_1 = false;
			class7345_0.int_2 = 0;
			class7345_0.int_3 = 0;
			int num = 0;
			while (class7345_0.idictionary_0 != null && num < class7345_0.idictionary_0.Length)
			{
				class7345_0.idictionary_0[num] = null;
				num++;
			}
		}
	}

	public virtual object vmethod_2(Interface388 input, int ttype, Class7332 follow)
	{
		object result = vmethod_28(input);
		if (input.imethod_1(1) == ttype)
		{
			input.imethod_0();
			class7345_0.bool_0 = false;
			class7345_0.bool_1 = false;
			return result;
		}
		if (class7345_0.int_3 > 0)
		{
			class7345_0.bool_1 = true;
			return result;
		}
		vmethod_24(input, ttype, follow);
		return vmethod_13(input, ttype, follow);
	}

	public virtual void vmethod_3(Interface388 input)
	{
		class7345_0.bool_0 = false;
		class7345_0.bool_1 = false;
		input.imethod_0();
	}

	public static bool smethod_0(Interface388 input, int ttype)
	{
		return input.imethod_1(2) == ttype;
	}

	public bool method_0(Interface388 input, Class7332 follow)
	{
		if (follow == null)
		{
			return false;
		}
		if (follow.vmethod_4(1))
		{
			Class7332 a = vmethod_26();
			follow = follow.vmethod_0(a);
			if (class7345_0.int_0 >= 0)
			{
				follow.Remove(1);
			}
		}
		if (!follow.vmethod_4(input.imethod_1(1)) && !follow.vmethod_4(1))
		{
			return false;
		}
		return true;
	}

	public virtual void vmethod_4(Exception77 e)
	{
		if (!class7345_0.bool_0)
		{
			class7345_0.int_2++;
			class7345_0.bool_0 = true;
			vmethod_5(TokenNames, e);
		}
	}

	public virtual void vmethod_5(string[] tokenNames, Exception77 e)
	{
		string text = vmethod_7(e);
		string text2 = vmethod_6(e, tokenNames);
		vmethod_9(text + " " + text2);
	}

	public virtual string vmethod_6(Exception77 e, string[] tokenNames)
	{
		string result = e.Message;
		if (e is Exception85)
		{
			Exception85 exception = (Exception85)e;
			string text = "<unknown>";
			result = string.Concat(str3: (exception.Expecting != Class7346.int_7) ? tokenNames[exception.Expecting] : "EOF", str0: "extraneous input ", str1: vmethod_8(exception.UnexpectedToken), str2: " expecting ");
		}
		else if (e is Exception84)
		{
			Exception84 exception2 = (Exception84)e;
			string text2 = "<unknown>";
			text2 = ((exception2.Expecting != Class7346.int_7) ? tokenNames[exception2.Expecting] : "EOF");
			result = "missing " + text2 + " at " + vmethod_8(e.Token);
		}
		else if (e is Exception83)
		{
			Exception83 exception3 = (Exception83)e;
			string text3 = "<unknown>";
			result = string.Concat(str3: (exception3.Expecting != Class7346.int_7) ? tokenNames[exception3.Expecting] : "EOF", str0: "mismatched input ", str1: vmethod_8(e.Token), str2: " expecting ");
		}
		else if (e is Exception86)
		{
			Exception86 exception4 = (Exception86)e;
			string text4 = "<unknown>";
			text4 = ((exception4.int_4 != Class7346.int_7) ? tokenNames[exception4.int_4] : "EOF");
			result = string.Concat("mismatched tree node: ", (exception4.Node == null || exception4.Node.ToString() == null) ? string.Empty : exception4.Node, " expecting ", text4);
		}
		else if (e is Exception87)
		{
			result = "no viable alternative at input " + vmethod_8(e.Token);
		}
		else if (e is Exception78)
		{
			result = "required (...)+ loop did not match anything at input " + vmethod_8(e.Token);
		}
		else if (e is Exception80)
		{
			Exception80 exception5 = (Exception80)e;
			result = "mismatched input " + vmethod_8(e.Token) + " expecting set " + exception5.class7332_0;
		}
		else if (e is Exception81)
		{
			Exception81 exception6 = (Exception81)e;
			result = "mismatched input " + vmethod_8(e.Token) + " expecting set " + exception6.class7332_0;
		}
		else if (e is Exception79)
		{
			Exception79 exception7 = (Exception79)e;
			result = "rule " + exception7.string_0 + " failed predicate: {" + exception7.string_1 + "}?";
		}
		return result;
	}

	public virtual string vmethod_7(Exception77 e)
	{
		return "line " + e.Line + ":" + e.CharPositionInLine;
	}

	public virtual string vmethod_8(Interface392 t)
	{
		string text = t.Text;
		if (text == null)
		{
			text = ((t.Type != Class7346.int_7) ? ("<" + t.Type + ">") : "<EOF>");
		}
		text = text.Replace("\n", "\\\\n");
		text = text.Replace("\r", "\\\\r");
		text = text.Replace("\t", "\\\\t");
		return "'" + text + "'";
	}

	public virtual void vmethod_9(string msg)
	{
	}

	public virtual void vmethod_10(Interface388 input, Exception77 re)
	{
		if (class7345_0.int_1 == input.imethod_3())
		{
			input.imethod_0();
		}
		class7345_0.int_1 = input.imethod_3();
		Class7332 set = vmethod_25();
		vmethod_11();
		vmethod_16(input, set);
		vmethod_12();
	}

	public virtual void vmethod_11()
	{
	}

	public virtual void vmethod_12()
	{
	}

	protected virtual object vmethod_13(Interface388 input, int ttype, Class7332 follow)
	{
		Exception77 e = null;
		if (smethod_0(input, ttype))
		{
			e = new Exception85(ttype, input);
			vmethod_11();
			input.imethod_0();
			vmethod_12();
			vmethod_4(e);
			object result = vmethod_28(input);
			input.imethod_0();
			return result;
		}
		if (!method_0(input, follow))
		{
			e = new Exception83(ttype, input);
			throw e;
		}
		object obj = vmethod_29(input, e, ttype, follow);
		e = new Exception84(ttype, input, obj);
		vmethod_4(e);
		return obj;
	}

	public virtual object vmethod_14(Interface388 input, Exception77 e, Class7332 follow)
	{
		if (!method_0(input, follow))
		{
			throw e;
		}
		vmethod_4(e);
		return vmethod_29(input, e, 0, follow);
	}

	public virtual void vmethod_15(Interface388 input, int tokenType)
	{
		int num = input.imethod_1(1);
		while (num != Class7346.int_7 && num != tokenType)
		{
			input.imethod_0();
			num = input.imethod_1(1);
		}
	}

	public virtual void vmethod_16(Interface388 input, Class7332 set)
	{
		int num = input.imethod_1(1);
		while (num != Class7346.int_7 && !set.vmethod_4(num))
		{
			input.imethod_0();
			num = input.imethod_1(1);
		}
	}

	public virtual IList vmethod_17()
	{
		string fullName = GetType().FullName;
		return smethod_1(new Exception(), fullName);
	}

	public static IList smethod_1(Exception e, string recognizerClassName)
	{
		IList list = new ArrayList();
		StackTrace stackTrace = new StackTrace(e);
		int num = 0;
		for (num = stackTrace.FrameCount - 1; num >= 0; num--)
		{
			StackFrame frame = stackTrace.GetFrame(num);
			if (!frame.GetMethod().DeclaringType.FullName.StartsWith("Antlr.Runtime.") && !frame.GetMethod().Name.Equals(string_0) && frame.GetMethod().DeclaringType.FullName.Equals(recognizerClassName))
			{
				list.Add(frame.GetMethod().Name);
			}
		}
		return list;
	}

	public virtual IList vmethod_18(IList tokens)
	{
		if (tokens == null)
		{
			return null;
		}
		IList list = new ArrayList(tokens.Count);
		for (int i = 0; i < tokens.Count; i++)
		{
			list.Add(((Interface392)tokens[i]).Text);
		}
		return list;
	}

	public virtual int vmethod_19(int ruleIndex, int ruleStartIndex)
	{
		if (class7345_0.idictionary_0[ruleIndex] == null)
		{
			class7345_0.idictionary_0[ruleIndex] = new Hashtable();
		}
		object obj = class7345_0.idictionary_0[ruleIndex][ruleStartIndex];
		if (obj == null)
		{
			return -1;
		}
		return (int)obj;
	}

	public virtual bool vmethod_20(Interface388 input, int ruleIndex)
	{
		int num = vmethod_19(ruleIndex, input.imethod_3());
		switch (num)
		{
		case -1:
			return false;
		case -2:
			class7345_0.bool_1 = true;
			break;
		default:
			input.Seek(num + 1);
			break;
		}
		return true;
	}

	public virtual void vmethod_21(Interface388 input, int ruleIndex, int ruleStartIndex)
	{
		int num = (class7345_0.bool_1 ? (-2) : (input.imethod_3() - 1));
		if (class7345_0.idictionary_0[ruleIndex] != null)
		{
			class7345_0.idictionary_0[ruleIndex][ruleStartIndex] = num;
		}
	}

	public int method_1()
	{
		int num = 0;
		int num2 = 0;
		while (class7345_0.idictionary_0 != null && num2 < class7345_0.idictionary_0.Length)
		{
			IDictionary dictionary = class7345_0.idictionary_0[num2];
			if (dictionary != null)
			{
				num += dictionary.Count;
			}
			num2++;
		}
		return num;
	}

	public virtual void vmethod_22(string ruleName, int ruleIndex, object inputSymbol)
	{
	}

	public virtual void vmethod_23(string ruleName, int ruleIndex, object inputSymbol)
	{
	}

	protected internal virtual void vmethod_24(Interface388 input, int ttype, Class7332 follow)
	{
		if (smethod_0(input, ttype))
		{
			throw new Exception85(ttype, input);
		}
		if (method_0(input, follow))
		{
			throw new Exception84(ttype, input, null);
		}
		throw new Exception83(ttype, input);
	}

	protected internal virtual Class7332 vmethod_25()
	{
		return vmethod_27(exact: false);
	}

	protected internal virtual Class7332 vmethod_26()
	{
		return vmethod_27(exact: true);
	}

	protected internal virtual Class7332 vmethod_27(bool exact)
	{
		int num = class7345_0.int_0;
		Class7332 @class = new Class7332();
		for (int num2 = num; num2 >= 0; num2--)
		{
			Class7332 class2 = class7345_0.class7332_0[num2];
			@class.vmethod_2(class2);
			if (exact)
			{
				if (!class2.vmethod_4(1))
				{
					break;
				}
				if (num2 > 0)
				{
					@class.Remove(1);
				}
			}
		}
		return @class;
	}

	protected virtual object vmethod_28(Interface388 input)
	{
		return null;
	}

	protected virtual object vmethod_29(Interface388 input, Exception77 e, int expectedTokenType, Class7332 follow)
	{
		return null;
	}

	protected void method_2(Class7332 fset)
	{
		if (class7345_0.int_0 + 1 >= class7345_0.class7332_0.Length)
		{
			Class7332[] array = new Class7332[class7345_0.class7332_0.Length * 2];
			Array.Copy(class7345_0.class7332_0, 0, array, 0, class7345_0.class7332_0.Length);
			class7345_0.class7332_0 = array;
		}
		class7345_0.class7332_0[++class7345_0.int_0] = fset;
	}
}
