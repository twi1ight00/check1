using System;
using System.IO;
using Richfit.Garnet.Common.Configuration.Sources;
using Richfit.Garnet.Common.Patterns;

namespace Richfit.Garnet.Common.Configuration;

/// <summary>
/// 多视图配置接口
/// </summary>
[ConfigurationSourceMapping(typeof(ViewsConfigurationSource))]
public interface IViewsConfiguration : IConfiguration, IRefreshableConfigurationSource, ISavableConfigurationSource, IWatchingConfigurationSource, IConfigurationSource, ISyncableObject, IDisposableObject, IDisposable
{
	/// <summary>
	/// 获取配置文件对象
	/// </summary>
	FileInfo File { get; }

	/// <summary>
	/// 获取配置中的默认视图（第一个视图）
	/// </summary>
	IConfigurationView View { get; }

	/// <summary>
	/// 获取配置中所有配置视图的数组
	/// </summary>
	IConfigurationView[] Views { get; }

	/// <summary>
	/// 获取配置中的所有配置视图
	/// </summary>
	/// <returns>配置中所有配置视图的数组</returns>
	IConfigurationView[] GetViews();

	/// <summary>
	/// 获取所有指定类型的配置视图
	/// </summary>
	/// <param name="viewType">配置视图类型</param>
	/// <returns>指定类型的配置视图数组，如果没有该类型的配置视图，返回空数组</returns>
	IConfigurationView[] GetViews(Type viewType);

	/// <summary>
	/// 获取所有指定类型的配置视图
	/// </summary>
	/// <typeparam name="T">配置视图类型</typeparam>
	/// <returns>所有指定类型的配置视图数组，如果没有该类型的配置视图，返回空数组</returns>
	T[] GetViews<T>() where T : IConfigurationView;

	/// <summary>
	/// 获取满足指定条件的配置视图数组
	/// </summary>
	/// <typeparam name="T">配置视图类型</typeparam>
	/// <param name="predicate">匹配条件</param>
	/// <returns>返回满足指定条件的配置视图数组，如果没有符合的配置视图，返回空数组</returns>
	T[] GetViews<T>(Func<T, bool> predicate) where T : IConfigurationView;

	/// <summary>
	/// 获取默认的配置视图
	/// </summary>
	/// <returns>默认配置视图，如果不存在默认视图返回null</returns>
	IConfigurationView GetView();

	/// <summary>
	/// 获取与指定类型匹配的第一个配置视图
	/// </summary>
	/// <param name="viewType">配置视图类型</param>
	/// <returns>与指定类型匹配的第一个配置视图，如果没有匹配的配置视图，返回null</returns>
	IConfigurationView GetView(Type viewType);

	/// <summary>
	/// 获取与指定类型的第一个配置视图
	/// </summary>
	/// <typeparam name="T">配置视图类型</typeparam>
	/// <returns>与指定类型匹配的第一个配置视图，如果没有匹配的配置视图，返回null</returns>
	T GetView<T>() where T : IConfigurationView;

	/// <summary>
	/// 获取指定名称的配置视图
	/// </summary>
	/// <param name="viewName">配置视图名称</param>
	/// <param name="ignoreCase">配置视图名称是否区分大小写</param>
	/// <returns>匹配的配置视图对象，如果没有匹配的配置视图，返回null</returns>
	IConfigurationView GetView(string viewName, bool ignoreCase = false);

	/// <summary>
	/// 获取指定名称和类型的配置视图
	/// </summary>
	/// <param name="viewName">配置视图名称</param>
	/// <param name="viewType">配置视图类型</param>
	/// <param name="ignoreCase">配置视图名称是否区分大小写</param>
	/// <returns>匹配的配置视图，如果没有匹配的配置视图，返回null</returns>
	IConfigurationView GetView(string viewName, Type viewType, bool ignoreCase = false);

	/// <summary>
	/// 获取指定名称、指定类型的配置视图
	/// 没有匹配的配置视图，则返回null
	/// </summary>
	/// <typeparam name="T">配置视图类型</typeparam>
	/// <param name="viewName">配置视图名称</param>
	/// <param name="ignoreCase">配置视图名称是否区分大小写</param>
	/// <returns>匹配的配置视图，如果没有匹配的配置视图，返回null</returns>
	T GetView<T>(string viewName, bool ignoreCase = false) where T : IConfigurationView;

	/// <summary>
	/// 获取满足指定条件的第一个配置视图
	/// </summary>
	/// <typeparam name="T">配置视图类型</typeparam>
	/// <param name="predicate">匹配条件</param>
	/// <returns>返回满足指定条件的第一个配置视图，如果没有符合的配置视图，返回null</returns>
	T GetView<T>(Func<T, bool> predicate) where T : IConfigurationView;

	/// <summary>
	/// 添加配置视图
	/// </summary>
	/// <param name="view">待添加的配置视图</param>
	/// <returns>如果添加成功返回true，否则返回false</returns>
	bool AddView(IConfigurationView view);

	/// <summary>
	/// 添加指定类型的配置视图
	/// </summary>
	/// <param name="viewName">配置视图名称</param>
	/// <param name="viewType">配置视图类型</param>
	/// <returns>如果添加成功返回true，否则返回false</returns>
	bool AddView(string viewName, Type viewType);

	/// <summary>
	/// 添加指定名称的配置视图
	/// </summary>
	/// <typeparam name="T">配置视图类型</typeparam>
	/// <param name="viewName">配置视图名称</param>
	/// <returns>如果添加成功返回true，否则返回false</returns>
	bool AddView<T>(string viewName) where T : IConfigurationView, new();

	/// <summary>
	/// 移除指定名称的配置视图
	/// </summary>
	/// <param name="viewName">配置视图名称</param>
	/// <param name="ignoreCase">配置视图名称是否区分大小写</param>
	/// <returns>如果移除成功返回true，否则返回false</returns>
	bool RemoveView(string viewName, bool ignoreCase = false);

	/// <summary>
	/// 移除符合指定条件的配置视图
	/// </summary>
	/// <typeparam name="T">配置视图类型</typeparam>
	/// <param name="predicate">配置视图筛选条件</param>
	/// <returns>删除的配置视图数量</returns>
	int RemoveView<T>(Func<T, bool> predicate) where T : IConfigurationView;

	/// <summary>
	/// 移除所有配置视图
	/// </summary>
	void ClearViews();
}
