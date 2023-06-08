using System;
using System.Collections.Generic;
using ns277;
using ns284;
using ns322;

namespace ns286;

internal class Class6805 : IDisposable
{
	public const string string_0 = "application/ecmascript";

	public const string string_1 = "application/javascript";

	public const string string_2 = "text/ecmascript";

	public const string string_3 = "text/javascript";

	[ThreadStatic]
	private static Stack<Class6805> stack_0;

	private readonly Interface355 interface355_0;

	private readonly Interface322 interface322_0;

	private readonly Class7685 class7685_0;

	private Class6983 class6983_0;

	public static Class6805 Current
	{
		get
		{
			if (stack_0 == null)
			{
				stack_0 = new Stack<Class6805>();
			}
			if (stack_0.Count != 0)
			{
				return stack_0.Peek();
			}
			return null;
		}
	}

	public Interface355 GlobalSettings => interface355_0;

	public Interface322 ResourceLoadingCallback => interface322_0;

	public Class6983 CurrentProcessingElement
	{
		get
		{
			return class6983_0;
		}
		set
		{
			class6983_0 = value;
		}
	}

	public Class7685 ScriptEngine => class7685_0;

	public static bool smethod_0(string mime)
	{
		if (mime.Equals("text/javascript", StringComparison.OrdinalIgnoreCase))
		{
			return true;
		}
		if (mime.Equals("application/javascript", StringComparison.OrdinalIgnoreCase))
		{
			return true;
		}
		if (mime.Equals("text/ecmascript", StringComparison.OrdinalIgnoreCase))
		{
			return true;
		}
		if (mime.Equals("application/ecmascript", StringComparison.OrdinalIgnoreCase))
		{
			return true;
		}
		return false;
	}

	public Class6805(Interface355 settings, Interface322 callback, Class7685 engine)
	{
		if (settings == null)
		{
			throw new ArgumentNullException("settings");
		}
		if (callback == null)
		{
			throw new ArgumentNullException("callback");
		}
		interface355_0 = settings;
		interface322_0 = callback;
		class7685_0 = engine;
		if (stack_0 == null)
		{
			stack_0 = new Stack<Class6805>();
		}
		stack_0.Push(this);
	}

	public void Dispose()
	{
		Class6805 objA = stack_0.Pop();
		if (!object.ReferenceEquals(objA, this))
		{
			throw new ApplicationException("ScriptExecutionContext stack is broken!");
		}
	}
}
