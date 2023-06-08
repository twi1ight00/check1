using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using Richfit.Garnet.Common.Configuration;
using Richfit.Garnet.Common.Configuration.Sources;
using Richfit.Garnet.Common.Extensions;
using Richfit.Garnet.Common.Patterns;
using Richfit.Garnet.Common.Threading;
using Richfit.Garnet.Module.Importing.Properties;

namespace Richfit.Garnet.Module.Importing;

/// <summary>
/// 导入管理器
/// </summary>
public class ImportManager : IImportManager, IDisposableObject, IDisposable
{
	/// <summary>
	/// 主配置源
	/// </summary>
	private static IMainConfiguration mainConfiguration;

	/// <summary>
	/// 包配置源
	/// </summary>
	private static IPackageConfiguration packageConfiguration;

	/// <summary>
	/// 管理器实例缓存
	/// </summary>
	private static List<IImportManager> managers = new List<IImportManager>();

	/// <summary>
	/// 导入管理器实例
	/// </summary>
	private static IImportManager manager;

	/// <summary>
	/// 导入器配置源
	/// </summary>
	private IViewsConfiguration configuration;

	/// <summary>
	/// 导入器缓存
	/// </summary>
	private List<IImporter> importers;

	/// <summary>
	/// 配置管理器名称
	/// </summary>
	private string name;

	/// <summary>
	/// 同步对象
	/// </summary>
	private ISyncLocker syncRoot;

	/// <summary>
	/// 管理器是否已经清理
	/// </summary>
	private bool isDisposed;

	/// <summary>
	/// 获取导入管理器默认实例
	/// </summary>
	public static IImportManager Default => GetDefaultManager();

	/// <summary>
	/// 设置配置管理器名称
	/// </summary>
	public string Name => name;

	/// <summary>
	/// 获取同步对象
	/// </summary>
	public ISyncLocker SyncRoot => syncRoot;

	/// <summary>
	/// 获取管理器是否已经清理的状态
	/// </summary>
	public bool IsDisposed => isDisposed;

	/// <summary>
	/// 初始化管理器
	/// </summary>
	/// <param name="configuration">主配置源</param>
	public static void Initialize(IMainConfiguration configuration)
	{
		mainConfiguration.GuardNull(typeof(InvalidOperationException), Literals.M_E_ImportManager_Initialized);
		configuration.SyncRoot.Write(delegate
		{
			mainConfiguration = configuration.GuardNotNull(null, Literals.M_E_ImportManager_NoMainConfiguration);
			packageConfiguration = mainConfiguration.CurrentPackage.GuardNotNull(null, Literals.M_E_ImportManager_NoPackageConfiguration);
			packageConfiguration.SourceChanged += DoPackageSourceChanged;
			LoadManagerConfiguration(packageConfiguration);
		});
	}

	/// <summary>
	/// 加载导入管理器
	/// </summary>
	/// <param name="configuration">配置源</param>
	private static void LoadManagerConfiguration(IPackageConfiguration configuration)
	{
		ClearManagers();
		IViewsConfiguration[] all = packageConfiguration.GetAll<IViewsConfiguration>();
		foreach (IViewsConfiguration viewConfiguration in all)
		{
			List<IImportManager> source = managers;
			Func<IImportManager, bool> predicate = (IImportManager x) => x.Name.EqualOrdinal(viewConfiguration.SourceName);
			source.Any(predicate).GuardFalse(typeof(ConfigurationErrorsException), Literals.M_E_ImportManager_Configuration_Duplication.FormatValue(viewConfiguration.SourceName));
			managers.Add(new ImportManager(viewConfiguration));
		}
		manager = managers.FirstOrDefault();
	}

	/// <summary>
	/// 清除已加载的导入管理器
	/// </summary>
	private static void ClearManagers()
	{
		foreach (IImportManager im in managers)
		{
			im.Dispose();
		}
		managers.Clear();
		manager = null;
	}

	/// <summary>
	/// 配置包配置监控
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="args"></param>
	private static void DoPackageSourceChanged(object sender, ConfigurationSourceChangedEventArgs args)
	{
		mainConfiguration.SyncRoot.Write(delegate
		{
			if (args.Status == ConfigurationSourceStatus.Changed)
			{
				if (!packageConfiguration.ReferenceEquals(args.Source))
				{
					packageConfiguration.SourceChanged -= DoPackageSourceChanged;
					packageConfiguration = (IPackageConfiguration)args.Source;
					packageConfiguration.SourceChanged += DoPackageSourceChanged;
				}
				LoadManagerConfiguration(packageConfiguration);
			}
		});
	}

	/// <summary>
	/// 获取默认的导入管理器（配置中定义的第一个导入管理器）
	/// </summary>
	/// <returns>默认的导入管理器</returns>
	public static IImportManager GetDefaultManager()
	{
		mainConfiguration.GuardNotNull(typeof(InvalidOperationException), Literals.M_E_ImportManager_NotInitialized);
		return mainConfiguration.SyncRoot.Read(() => managers.FirstOrDefault());
	}

	/// <summary>
	/// 获取指定名称的导入管理器
	/// </summary>
	/// <param name="name">导入管理器名称</param>
	/// <returns>指定名称的导入管理器</returns>
	public static IImportManager GetManager(string name)
	{
		mainConfiguration.GuardNotNull(typeof(InvalidOperationException), Literals.M_E_ImportManager_NotInitialized);
		name.GuardNotNull();
		return mainConfiguration.SyncRoot.Read(() => managers.FirstOrDefault((IImportManager x) => x.Name.EqualOrdinal(name)));
	}

	/// <summary>
	/// 清理导出管理器
	/// </summary>
	public static void Dispose()
	{
		if (mainConfiguration.IsNull())
		{
			return;
		}
		mainConfiguration.SyncRoot.Write(delegate
		{
			if (packageConfiguration.IsNotNull())
			{
				packageConfiguration.SourceChanged -= DoPackageSourceChanged;
				packageConfiguration = null;
			}
			ClearManagers();
			mainConfiguration = null;
		});
	}

	/// <summary>
	/// 初始化导入管理器
	/// </summary>
	/// <param name="configuration">导入配置源</param>
	public ImportManager(IViewsConfiguration configuration)
	{
		configuration.GuardNotNull(typeof(ConfigurationErrorsException), Literals.M_E_ImportManager_Configuration_Invalid);
		this.configuration = configuration;
		syncRoot = this.configuration.SyncRoot;
		importers = new List<IImporter>();
		isDisposed = false;
		this.configuration.SourceChanged += DoSourceChanged;
		LoadExporterConfiguration(configuration);
	}

	/// <summary>
	/// 加载配置
	/// </summary>
	/// <param name="configuration">配置数据对象</param>
	private void LoadExporterConfiguration(IViewsConfiguration configuration)
	{
		name = configuration.SourceName.GuardNotNullAndEmpty(null, Literals.M_E_ImportManager_InvalidName);
		ImportManagerConfigurationView view = configuration.GetView<ImportManagerConfigurationView>(Name).GuardNotNull(typeof(ConfigurationErrorsException), Literals.M_E_ImportManager_Configuration_Invalid);
		ClearImporters();
		ImportManagerConfigurationView.ImporterInfo[] infos = view.GetInfos();
		foreach (ImportManagerConfigurationView.ImporterInfo info in infos)
		{
			List<IImporter> source = importers;
			Func<IImporter, bool> predicate = (IImporter x) => x.Name.EqualOrdinal(info.Name);
			source.Any(predicate).GuardFalse(typeof(ConfigurationErrorsException), Literals.M_E_Importer_Configuration_Duplication.FormatValue(info.Name));
			IConfigurationView importerView = info.Configuration.GetView(info.Name);
			IImporter importer = ((!importerView.IsNull()) ? info.Type.CreateInstance<IImporter>(new object[1] { importerView }) : info.Type.CreateInstance<IImporter>(new object[1] { info.Name }));
			importers.Add(importer);
		}
	}

	/// <summary>
	/// 配置变更事件处理器
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="args"></param>
	private void DoSourceChanged(object sender, ConfigurationSourceChangedEventArgs args)
	{
		syncRoot.Write(delegate
		{
			if (!isDisposed && args.Status == ConfigurationSourceStatus.Changed)
			{
				LoadExporterConfiguration((IViewsConfiguration)args.Source);
			}
		});
	}

	/// <summary>
	/// 获取指定名称的导入器
	/// </summary>
	/// <param name="name">导入器名称</param>
	/// <returns>指定名称的导入器，如果不存在指定名称的导入器，返回null</returns>
	public IImporter GetImporter(string name)
	{
		name.GuardNotNull();
		return syncRoot.Read(delegate
		{
			this.GuardNotDisposed();
			return importers.FirstOrDefault((IImporter x) => x.Name.EqualOrdinal(name));
		});
	}

	/// <summary>
	/// 获取指定类型的第一个导入器
	/// </summary>
	/// <typeparam name="T">导入器类型</typeparam>
	/// <returns>指定类型的第一个导入器，如果不存在指定类型的导入器，返回null</returns>
	public T GetImporter<T>() where T : IImporter
	{
		return syncRoot.Read(delegate
		{
			this.GuardNotDisposed();
			return importers.OfType<T>().FirstOrDefault();
		});
	}

	/// <summary>
	/// 获取指定类型和名称的导入器
	/// </summary>
	/// <typeparam name="T">导入器类型</typeparam>
	/// <param name="name">导入器名称</param>
	/// <returns>匹配的导入器，如果没有匹配的导入器，返回null</returns>
	public T GetImporter<T>(string name) where T : IImporter
	{
		name.GuardNotNull();
		return syncRoot.Read(delegate
		{
			this.GuardNotDisposed();
			return importers.OfType<T>().FirstOrDefault((T x) => x.Name.EqualOrdinal(name));
		});
	}

	/// <summary>
	/// 清空全部导入器
	/// </summary>
	public void ClearImporters()
	{
		syncRoot.Write(delegate
		{
			this.GuardNotDisposed();
			foreach (IImporter current in importers)
			{
				if (current.IsNotNull() && !current.IsDisposed)
				{
					current.Dispose();
				}
			}
			importers.Clear();
		});
	}

	/// <summary>
	/// 清理对象
	/// </summary>
	void IDisposable.Dispose()
	{
		syncRoot.Write(delegate
		{
			if (!isDisposed)
			{
				ClearImporters();
				configuration = null;
				isDisposed = true;
			}
		});
	}
}
