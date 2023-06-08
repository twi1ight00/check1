using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using AutoMapper;

namespace Richfit.Garnet.Common.Adapter.AutoMapper;

/// <summary>
/// Automapper Type Adapter Factory
/// </summary>
public class AutomapperTypeAdapterFactory : ITypeAdapterFactory
{
	/// <summary>
	/// AutoMapper默认属性正则解析规则设置
	/// </summary>
	private class DummyNamingConverter : INamingConvention
	{
		public string SeparatorCharacter => string.Empty;

		public Regex SplittingExpression => new Regex("\\s+");
	}

	/// <summary>
	/// Create a new Automapper type adapter factory
	/// </summary>
	public AutomapperTypeAdapterFactory()
	{
		Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
		Func<Assembly, bool> predicate = (Assembly a) => !IsIgnoredAssembly(a);
		IEnumerable<Type> profiles = from t in assemblies.Where(predicate).SelectMany((Assembly a) => a.GetTypes())
			where t.BaseType == typeof(Profile)
			select t;
		Mapper.Initialize(delegate(IConfiguration cfg)
		{
			cfg.SourceMemberNamingConvention = new DummyNamingConverter();
			cfg.DestinationMemberNamingConvention = new DummyNamingConverter();
			cfg.DisableConstructorMapping();
			foreach (Type current in profiles)
			{
				if (current.FullName != "AutoMapper.SelfProfiler`2")
				{
					cfg.AddProfile(Activator.CreateInstance(current) as Profile);
				}
			}
		});
	}

	/// <summary>
	/// Create type adapter
	/// </summary>
	/// <returns></returns>
	public ITypeAdapter Create()
	{
		return new AutomapperTypeAdapter();
	}

	/// <summary>
	/// Test assembly name ingored
	/// </summary>
	/// <param name="assembly"></param>
	/// <returns></returns>
	private bool IsIgnoredAssembly(Assembly assembly)
	{
		List<Func<Assembly, bool>> list = new List<Func<Assembly, bool>>();
		list.Add((Assembly asm) => asm.FullName.StartsWith("Microsoft.", StringComparison.InvariantCulture));
		list.Add((Assembly asm) => asm.FullName.StartsWith("System.", StringComparison.InvariantCulture));
		list.Add((Assembly asm) => asm.FullName.StartsWith("System,", StringComparison.InvariantCulture));
		list.Add((Assembly asm) => asm.FullName.StartsWith("CR_ExtUnitTest", StringComparison.InvariantCulture));
		list.Add((Assembly asm) => asm.FullName.StartsWith("mscorlib,", StringComparison.InvariantCulture));
		list.Add((Assembly asm) => asm.FullName.StartsWith("CR_VSTest", StringComparison.InvariantCulture));
		List<Func<Assembly, bool>> ignoreChecks = list;
		foreach (Func<Assembly, bool> check in ignoreChecks)
		{
			if (check(assembly))
			{
				return true;
			}
		}
		return false;
	}
}
