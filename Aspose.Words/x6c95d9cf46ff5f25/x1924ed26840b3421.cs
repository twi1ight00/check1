using System;
using System.Diagnostics;
using Aspose;

namespace x6c95d9cf46ff5f25;

[JavaDelete("Not porting to Java.")]
internal class x1924ed26840b3421
{
	private static bool xc84a55029490ce7c;

	private static bool x9afcbb98bf7d53be;

	public static int x5c5e4217ebb7cb1d
	{
		[DebuggerStepThrough]
		get
		{
			return Debug.IndentLevel;
		}
		[DebuggerStepThrough]
		set
		{
			Debug.IndentLevel = value;
		}
	}

	public static int x44b2deda1cf6ddbe
	{
		[DebuggerStepThrough]
		get
		{
			return Debug.IndentSize;
		}
		[DebuggerStepThrough]
		set
		{
			Debug.IndentSize = value;
		}
	}

	public static TraceListenerCollection x5c20b2bd2a3410f1
	{
		[DebuggerStepThrough]
		get
		{
			return Debug.Listeners;
		}
	}

	public static bool x5b6d11e763542781
	{
		[DebuggerStepThrough]
		get
		{
			return Debug.AutoFlush;
		}
		[DebuggerStepThrough]
		set
		{
			Debug.AutoFlush = value;
		}
	}

	private x1924ed26840b3421()
	{
	}

	[Conditional("TEST")]
	[DebuggerStepThrough]
	[Conditional("DEBUG")]
	public static void x205342cdf2da6bc7(bool xbcea506a33cf9111)
	{
		if (x5c20b2bd2a3410f1["Default"] is DefaultTraceListener defaultTraceListener)
		{
			defaultTraceListener.AssertUiEnabled = xbcea506a33cf9111;
		}
	}

	[DebuggerStepThrough]
	[Conditional("TEST")]
	[Conditional("DEBUG")]
	public static void xe0baf210a430c747(bool xbcea506a33cf9111)
	{
		xc84a55029490ce7c = xbcea506a33cf9111;
	}

	[Conditional("TEST")]
	[Conditional("DEBUG")]
	[DebuggerStepThrough]
	public static void x3ea87804a6d01863(bool xbcea506a33cf9111)
	{
		x9afcbb98bf7d53be = xbcea506a33cf9111;
	}

	[Conditional("DEBUG")]
	[Conditional("TEST")]
	[DebuggerStepThrough]
	public static void x4d60da6bfcd4ba66()
	{
	}

	[Conditional("DEBUG")]
	[DebuggerStepThrough]
	[Conditional("TEST")]
	public static void x4e846d09fe48634b(bool x29ca7772d281a736)
	{
	}

	[Conditional("TEST")]
	[DebuggerStepThrough]
	[Conditional("DEBUG")]
	public static void x4e846d09fe48634b(bool x29ca7772d281a736, string x1f25abf5fb75e795)
	{
	}

	[DebuggerStepThrough]
	[Conditional("TEST")]
	[Conditional("DEBUG")]
	public static void x4e846d09fe48634b(bool x29ca7772d281a736, string x1f25abf5fb75e795, string x9f15a273ba01f6f6)
	{
		if (!x29ca7772d281a736)
		{
			if (x9afcbb98bf7d53be)
			{
				throw new InvalidOperationException(new StackTrace(0, fNeedFileInfo: true).ToString());
			}
			if (xc84a55029490ce7c)
			{
				Debugger.Break();
			}
		}
	}

	[DebuggerStepThrough]
	[Conditional("DEBUG")]
	[Conditional("TEST")]
	public static void x796f1fadaaff6052(string x1f25abf5fb75e795)
	{
	}

	[DebuggerStepThrough]
	[Conditional("TEST")]
	[Conditional("DEBUG")]
	public static void x796f1fadaaff6052(string x1f25abf5fb75e795, string x9f15a273ba01f6f6)
	{
	}

	[DebuggerStepThrough]
	[Conditional("DEBUG")]
	[Conditional("TEST")]
	public static void x6210059f049f0d48(string x1f25abf5fb75e795)
	{
	}

	[Conditional("TEST")]
	[DebuggerStepThrough]
	[Conditional("DEBUG")]
	public static void x6210059f049f0d48(object xbcea506a33cf9111)
	{
	}

	[DebuggerStepThrough]
	[Conditional("TEST")]
	[Conditional("DEBUG")]
	public static void x6210059f049f0d48(string x1f25abf5fb75e795, string x6f02b6a80bf6b36f)
	{
	}

	[Conditional("DEBUG")]
	[DebuggerStepThrough]
	[Conditional("TEST")]
	public static void x6210059f049f0d48(object xbcea506a33cf9111, string x6f02b6a80bf6b36f)
	{
	}

	[Conditional("TEST")]
	[Conditional("DEBUG")]
	[DebuggerStepThrough]
	public static void x047e318d44422faa(bool x29ca7772d281a736, string x1f25abf5fb75e795)
	{
	}

	[Conditional("TEST")]
	[Conditional("DEBUG")]
	[DebuggerStepThrough]
	public static void x047e318d44422faa(bool x29ca7772d281a736, object xbcea506a33cf9111)
	{
	}

	[DebuggerStepThrough]
	[Conditional("TEST")]
	[Conditional("DEBUG")]
	public static void x047e318d44422faa(bool x29ca7772d281a736, string x1f25abf5fb75e795, string x6f02b6a80bf6b36f)
	{
	}

	[Conditional("TEST")]
	[DebuggerStepThrough]
	[Conditional("DEBUG")]
	public static void x047e318d44422faa(bool x29ca7772d281a736, object xbcea506a33cf9111, string x6f02b6a80bf6b36f)
	{
	}

	[DebuggerStepThrough]
	[Conditional("DEBUG")]
	[Conditional("TEST")]
	public static void x25d0efbd7848eeb3(string x1f25abf5fb75e795)
	{
	}

	[Conditional("TEST")]
	[DebuggerStepThrough]
	[Conditional("DEBUG")]
	public static void x25d0efbd7848eeb3(object xbcea506a33cf9111)
	{
	}

	[Conditional("TEST")]
	[Conditional("DEBUG")]
	[DebuggerStepThrough]
	public static void x25d0efbd7848eeb3(string x1f25abf5fb75e795, string x6f02b6a80bf6b36f)
	{
	}

	[Conditional("TEST")]
	[DebuggerStepThrough]
	[Conditional("DEBUG")]
	public static void x25d0efbd7848eeb3(object xbcea506a33cf9111, string x6f02b6a80bf6b36f)
	{
	}

	[Conditional("DEBUG")]
	[DebuggerStepThrough]
	[Conditional("TEST")]
	public static void xfa4ede6417b818ff(bool x29ca7772d281a736, string x1f25abf5fb75e795)
	{
	}

	[DebuggerStepThrough]
	[Conditional("DEBUG")]
	[Conditional("TEST")]
	public static void xfa4ede6417b818ff(bool x29ca7772d281a736, object xbcea506a33cf9111)
	{
	}

	[Conditional("DEBUG")]
	[Conditional("TEST")]
	[DebuggerStepThrough]
	public static void xfa4ede6417b818ff(bool x29ca7772d281a736, string x1f25abf5fb75e795, string x6f02b6a80bf6b36f)
	{
	}

	[DebuggerStepThrough]
	[Conditional("TEST")]
	[Conditional("DEBUG")]
	public static void xfa4ede6417b818ff(bool x29ca7772d281a736, object xbcea506a33cf9111, string x6f02b6a80bf6b36f)
	{
	}

	[Conditional("TEST")]
	[Conditional("DEBUG")]
	[DebuggerStepThrough]
	public static void x8ffe90e7fbccfccd()
	{
	}

	[Conditional("DEBUG")]
	[Conditional("TEST")]
	[DebuggerStepThrough]
	public static void xbb7550bbb62a218c()
	{
	}

	[Conditional("TEST")]
	[Conditional("DEBUG")]
	[DebuggerStepThrough]
	public static void x941a43d4a5637fd0()
	{
	}

	[Conditional("DEBUG")]
	[DebuggerStepThrough]
	[Conditional("TEST")]
	public static void xca77b49dff6dc191()
	{
	}

	[Conditional("TEST")]
	[DebuggerStepThrough]
	[Conditional("DEBUG")]
	public static void x5827c4f2314f1346()
	{
		Debugger.Break();
	}

	[Conditional("DEBUG")]
	[DebuggerStepThrough]
	[Conditional("TEST")]
	public static void xd3c9b3c0b51f8bf5(Type x43163d22e8cd5a71)
	{
	}
}
