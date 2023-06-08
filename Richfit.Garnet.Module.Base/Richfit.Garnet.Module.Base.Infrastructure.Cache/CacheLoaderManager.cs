using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Richfit.Garnet.Common.Configuration;
using Richfit.Garnet.Common.Logging;

namespace Richfit.Garnet.Module.Base.Infrastructure.Cache;

/// <summary>
/// 缓存管理器
/// </summary>
public static class CacheLoaderManager
{
	/// <summary>
	/// 日志记录器
	/// </summary>
	private static readonly ILogger Logger = LoggerManager.GetLogger("DataCache");

	/// <summary>
	/// 初始化方法，调用实现了ICacheLoader接口的实例，加载到缓存
	/// </summary>
	public static void Initialize()
	{
		Logger.Info("缓存初始化开始");
		IEnumerable<Type> loaders = from t in (from a in AppDomain.CurrentDomain.GetAssemblies()
				where !IsIgnoredAssembly(a)
				select a).SelectMany((Assembly a) => a.GetTypes())
			where typeof(ICacheLoader).IsAssignableFrom(t)
			select t;
		foreach (Type item in loaders)
		{
			if (item.FullName != "Richfit.Garnet.Module.Base.Infrastructure.Cache.ICacheLoader")
			{
				try
				{
					Logger.Info(item.FullName + "缓存初始化开始");
					(Activator.CreateInstance(item) as ICacheLoader).Load();
					Logger.Info(item.FullName + "缓存初始化完成");
				}
				catch (Exception ex)
				{
					StringBuilder message = new StringBuilder();
					message.AppendLine("DataCache初始化出错，出错Loader：" + item.FullName);
					message.AppendLine("错误信息：" + ex.Message);
					Logger.Error(message.ToString());
					throw;
				}
			}
		}
		Logger.Info("缓存初始化结束");
	}

	/// <summary>
	/// 根据类全名称重新加载缓存
	/// </summary>
	/// <param name="loaderFullName"></param>
	public static void ReLoad(string loaderFullName)
	{
		Type type = Type.GetType(loaderFullName);
		ReLoad(type);
	}

	/// <summary>
	/// 刷新某项缓存
	/// </summary>
	/// <param name="type"></param>
	private static void ReLoad(Type type)
	{
		try
		{
			Logger.Info(type.FullName + "缓存重新加载开始");
			(Activator.CreateInstance(type) as ICacheLoader).Load();
			Logger.Info(type.FullName + "缓存重新加载完成");
		}
		catch (Exception ex)
		{
			StringBuilder message = new StringBuilder();
			message.AppendLine("重新加载缓存出错，出错Loader：" + type.FullName);
			message.AppendLine("错误信息：" + ex.Message);
			Logger.Error(message.ToString());
			throw ex;
		}
	}

	/// <summary>
	/// 检测是否是应忽略的程序集
	/// </summary>
	/// <param name="assembly"></param>
	/// <returns></returns>
	private static bool IsIgnoredAssembly(Assembly assembly)
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

	/// <summary>
	/// 检测是否是应包含的程序集
	/// </summary>
	/// <param name="assembly"></param>
	/// <returns></returns>
	public static bool IsIncludeActionCode(string actionCode)
	{
		string autoExecuteFlag = ConfigurationManager.System.Settings.GetSetting<string>("AutoExecuteFlag") ?? string.Empty;
		string[] autoExecuteFlagArray = autoExecuteFlag.Split(new char[1] { ';' }, StringSplitOptions.RemoveEmptyEntries);
		string[] array = autoExecuteFlagArray;
		foreach (string flag in array)
		{
			if (actionCode.StartsWith(flag))
			{
				return true;
			}
		}
		return false;
	}
}
