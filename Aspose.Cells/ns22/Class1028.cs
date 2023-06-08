using System;
using System.IO;
using System.Reflection;

namespace ns22;

internal class Class1028
{
	private Class1028()
	{
	}

	public static Stream smethod_0(string string_0)
	{
		Assembly callingAssembly = Assembly.GetCallingAssembly();
		Stream manifestResourceStream = callingAssembly.GetManifestResourceStream(string_0);
		if (manifestResourceStream == null)
		{
			throw new InvalidOperationException($"Cannot find resource '{string_0}'.");
		}
		return manifestResourceStream;
	}
}
