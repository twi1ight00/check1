using System;
using System.Text;
using ns1;
using ns323;
using ns82;

namespace ns322;

internal class Class7685
{
	private readonly Class7678 class7678_0;

	private Interface401 Global => class7678_0.Global;

	public Class7397 method_0(Class7397 function, params Class7397[] args)
	{
		if (!(function is Class7400 function2))
		{
			throw new Exception89("Argument is not a Function object");
		}
		class7678_0.imethod_37(function2, null, args);
		return class7678_0.Returned;
	}

	public Class7397 method_1(object value, Type type)
	{
		return Global.imethod_5(type).method_13(value);
	}

	internal static Class7380 smethod_0(string source)
	{
		Class7380 result = null;
		if (!string.IsNullOrEmpty(source))
		{
			Class7229 tokenSource = new Class7229(new Class7328(source));
			Class7231 @class = new Class7231(new Class7336(tokenSource));
			result = @class.method_92().class7380_0;
			if (@class.Errors != null && @class.Errors.Count > 0)
			{
				throw new Exception89(string.Join(Environment.NewLine, @class.Errors.ToArray()));
			}
		}
		return result;
	}

	public static bool smethod_1(string script, out string errors)
	{
		try
		{
			errors = null;
			Class7380 @class = smethod_0(script);
			return @class != null;
		}
		catch (Exception ex)
		{
			errors = ex.Message;
			return true;
		}
	}

	private Class7397 method_2(Class7380 program)
	{
		class7678_0.imethod_0(program);
		return class7678_0.Result;
	}

	public Class7397 method_3(string script)
	{
		if (script == null)
		{
			throw new ArgumentException("Script can't be null", "script");
		}
		try
		{
			Class7380 program = smethod_0(script);
			return method_2(program);
		}
		catch (Exception88 exception)
		{
			string message = ((!(exception.Value is Class7430 @class)) ? exception.Message : @class.Value.ToString());
			throw new Exception89(method_4(message), exception);
		}
		catch (Exception ex)
		{
			throw new Exception89(method_4(ex.Message), ex);
		}
	}

	private string method_4(string message)
	{
		StringBuilder stringBuilder = new StringBuilder();
		while (class7678_0.CallStack.Count > 0)
		{
			stringBuilder.AppendLine(class7678_0.CallStack.Pop());
		}
		if (stringBuilder.Length > 0)
		{
			stringBuilder.Insert(0, Environment.NewLine + "------ Stack Trace:" + Environment.NewLine);
		}
		return message + Environment.NewLine + stringBuilder;
	}

	private Class7685(Enum987 options)
	{
		class7678_0 = new Class7678(options);
	}

	public Class7685()
		: this(Enum987.flag_0 | Enum987.flag_2)
	{
	}

	public void method_5(Class7448 extension)
	{
		Global.imethod_4(extension);
	}
}
