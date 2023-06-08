using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace AutoMapper.Internal;

internal class ProbingAdapterResolver : IAdapterResolver
{
	private readonly string[] _platformNames;

	private readonly Func<string, Assembly> _assemblyLoader;

	private readonly object _lock = new object();

	private readonly Dictionary<Type, object> _adapters = new Dictionary<Type, object>();

	private Assembly _assembly;

	private bool _probed;

	public ProbingAdapterResolver(params string[] platformNames)
		: this(Assembly.Load, platformNames)
	{
	}

	public ProbingAdapterResolver(Func<string, Assembly> assemblyLoader, params string[] platformNames)
	{
		_platformNames = platformNames;
		_assemblyLoader = assemblyLoader;
	}

	public object Resolve(Type type)
	{
		lock (_lock)
		{
			if (!_adapters.TryGetValue(type, out var value))
			{
				Assembly platformSpecificAssembly = GetPlatformSpecificAssembly();
				value = ResolveAdapter(platformSpecificAssembly, type);
				_adapters.Add(type, value);
			}
			return value;
		}
	}

	private static object ResolveAdapter(Assembly assembly, Type interfaceType)
	{
		string text = MakeAdapterTypeName(interfaceType);
		Type type;
		if ((object)assembly != null)
		{
			type = assembly.GetType(text + "Override");
			if ((object)type != null)
			{
				return Activator.CreateInstance(type);
			}
			type = assembly.GetType(text);
			if ((object)type != null)
			{
				return Activator.CreateInstance(type);
			}
		}
		type = typeof(ProbingAdapterResolver).Assembly.GetType(text);
		if ((object)type == null)
		{
			return null;
		}
		return Activator.CreateInstance(type);
	}

	private static string MakeAdapterTypeName(Type interfaceType)
	{
		return interfaceType.Namespace + "." + interfaceType.Name.Substring(1);
	}

	private Assembly GetPlatformSpecificAssembly()
	{
		if ((object)_assembly == null && !_probed)
		{
			_probed = true;
			_assembly = ProbeForPlatformSpecificAssembly();
		}
		return _assembly;
	}

	private Assembly ProbeForPlatformSpecificAssembly()
	{
		return _platformNames.Select(ProbeForPlatformSpecificAssembly).FirstOrDefault((Assembly assembly) => (object)assembly != null);
	}

	private Assembly ProbeForPlatformSpecificAssembly(string platformName)
	{
		AssemblyName assemblyName = new AssemblyName(GetType().Assembly.FullName);
		assemblyName.Name = "AutoMapper." + platformName;
		AssemblyName assemblyName2 = assemblyName;
		try
		{
			return _assemblyLoader(assemblyName2.ToString());
		}
		catch (FileNotFoundException)
		{
		}
		catch (Exception)
		{
			assemblyName2.SetPublicKey(null);
			assemblyName2.SetPublicKeyToken(null);
			try
			{
				return _assemblyLoader(assemblyName2.ToString());
			}
			catch (Exception)
			{
				return null;
			}
		}
		return null;
	}
}
