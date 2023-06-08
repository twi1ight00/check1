using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using Richfit.Garnet.Common.Configuration;
using Richfit.Garnet.Common.Configuration.Sources;
using Richfit.Garnet.Common.Extensions;
using Richfit.Garnet.Common.IoC;
using Richfit.Garnet.Common.Patterns;
using Richfit.Garnet.Common.Threading;
using Richfit.Garnet.Module.Base.Application.DTO;
using Richfit.Garnet.Module.Exporting.Properties;

namespace Richfit.Garnet.Module.Exporting;

/// <summary>
/// 导出管理器
/// </summary>
public class ExportManager : IExportManager, IDisposableObject, IDisposable
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
	private static List<IExportManager> managers = new List<IExportManager>();

	/// <summary>
	/// 导出管理器实例
	/// </summary>
	private static IExportManager manager;

	/// <summary>
	/// 导出器配置源
	/// </summary>
	private IViewsConfiguration configuration;

	/// <summary>
	/// 导出器缓存
	/// </summary>
	private List<IExporter> exporters;

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
	/// 获取导出管理器默认实例
	/// </summary>
	public static IExportManager Default => GetDefaultManager();

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
		mainConfiguration.GuardNull(typeof(InvalidOperationException), Literals.MSG_E_ExportManagerInitialized);
		configuration.GuardNotNull(null, Literals.MSG_E_NoMainConfiguration);
		configuration.SyncRoot.Write(delegate
		{
			mainConfiguration = configuration.GuardNotNull(null, Literals.MSG_E_NoMainConfiguration);
			packageConfiguration = mainConfiguration.CurrentPackage.GuardNotNull(null, Literals.MSG_E_NoPackageConfiguration);
			packageConfiguration.SourceChanged += DoPackageSourceChanged;
			LoadManagerConfiguration(packageConfiguration);
		});
	}

	/// <summary>
	/// 加载导出管理器
	/// </summary>
	/// <param name="configuration">配置源</param>
	private static void LoadManagerConfiguration(IPackageConfiguration configuration)
	{
		ClearManagers();
		IViewsConfiguration[] all = packageConfiguration.GetAll<IViewsConfiguration>();
		foreach (IViewsConfiguration viewConfiguration in all)
		{
			List<IExportManager> source = managers;
			Func<IExportManager, bool> predicate = (IExportManager x) => x.Name.EqualOrdinal(viewConfiguration.SourceName);
			source.Any(predicate).GuardFalse(typeof(ConfigurationErrorsException), Literals.MSG_E_InvalidManagerName);
			managers.Add(new ExportManager(viewConfiguration));
		}
		manager = managers.FirstOrDefault();
	}

	/// <summary>
	/// 清除已加载的导出管理器
	/// </summary>
	private static void ClearManagers()
	{
		foreach (IExportManager em in managers)
		{
			em.Dispose();
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
	/// 获取默认的导出管理器（配置中定义的一个导出管理器）
	/// </summary>
	/// <returns>默认的导出管理器</returns>
	public static IExportManager GetDefaultManager()
	{
		mainConfiguration.GuardNotNull(typeof(InvalidOperationException), Literals.MSG_E_ExportManagerNotInitialized);
		return mainConfiguration.SyncRoot.Read(() => managers.FirstOrDefault());
	}

	/// <summary>
	/// 获取指定名称的导出管理器
	/// </summary>
	/// <param name="name">导出管理器名称</param>
	/// <returns>指定名称的导出管理器</returns>
	public static IExportManager GetManager(string name)
	{
		mainConfiguration.GuardNotNull(typeof(InvalidOperationException), Literals.MSG_E_ExportManagerNotInitialized);
		name.GuardNotNull();
		return mainConfiguration.SyncRoot.Read(() => managers.FirstOrDefault((IExportManager x) => x.Name.EqualOrdinal(name)));
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
	/// 初始化导出管理器
	/// </summary>
	/// <param name="configuration">导出配置源</param>
	public ExportManager(IViewsConfiguration configuration)
	{
		configuration.GuardNotNull(typeof(ConfigurationErrorsException), Literals.MSG_E_NoManagerConfiguration);
		this.configuration = configuration;
		syncRoot = this.configuration.SyncRoot;
		exporters = new List<IExporter>();
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
		name = configuration.SourceName.GuardNotNullAndEmpty(null, Literals.MSG_E_InvalidManagerName);
		ExportManagerConfigurationView view = configuration.GetView<ExportManagerConfigurationView>(Name).GuardNotNull(typeof(ConfigurationErrorsException), Literals.MSG_E_NoManagerConfiguration);
		ClearExporters();
		ExportManagerConfigurationView.ExporterInfo[] infos = view.GetInfos();
		foreach (ExportManagerConfigurationView.ExporterInfo info in infos)
		{
			List<IExporter> source = exporters;
			Func<IExporter, bool> predicate = (IExporter x) => x.Name.EqualOrdinal(info.Name);
			source.Any(predicate).GuardFalse(typeof(ConfigurationErrorsException), Literals.MSG_E_ExporterExists);
			IConfigurationView exporterView = info.Configuration.GetView(info.Name);
			IExporter exporter = ((!exporterView.IsNull()) ? info.Type.CreateInstance<IExporter>(new object[1] { exporterView }) : info.Type.CreateInstance<IExporter>(new object[1] { info.Name }));
			exporters.Add(exporter);
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
	/// 获取指定名称的导出器
	/// </summary>
	/// <param name="name">导出器名称</param>
	/// <returns>指定名称的导出器，如果不存在指定名称的导出器，返回null</returns>
	public IExporter GetExporter(string name)
	{
		name.GuardNotNull();
		return syncRoot.Read(delegate
		{
			this.GuardNotDisposed();
			return exporters.FirstOrDefault((IExporter x) => x.Name.EqualOrdinal(name));
		});
	}

	/// <summary>
	/// 获取指定类型的第一个导出器
	/// </summary>
	/// <typeparam name="T">导出器类型</typeparam>
	/// <returns>指定类型的第一个导出器，如果不存在指定类型的导出器，返回null</returns>
	public T GetExporter<T>() where T : IExporter
	{
		return syncRoot.Read(delegate
		{
			this.GuardNotDisposed();
			return exporters.OfType<T>().FirstOrDefault();
		});
	}

	/// <summary>
	/// 获取指定类型和名称的导出器
	/// </summary>
	/// <typeparam name="T">导出器类型</typeparam>
	/// <param name="name">导出器名称</param>
	/// <returns>匹配的导出器，如果没有匹配的导出器，返回null</returns>
	public T GetExporter<T>(string name) where T : IExporter
	{
		name.GuardNotNull();
		return syncRoot.Read(delegate
		{
			this.GuardNotDisposed();
			return exporters.OfType<T>().FirstOrDefault((T x) => x.Name.EqualOrdinal(name));
		});
	}

	/// <summary>
	/// 清空全部导出器
	/// </summary>
	public void ClearExporters()
	{
		syncRoot.Write(delegate
		{
			this.GuardNotDisposed();
			foreach (IExporter current in exporters)
			{
				if (current.IsNotNull() && !current.IsDisposed)
				{
					current.Dispose();
				}
			}
			exporters.Clear();
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
				ClearExporters();
				configuration = null;
				isDisposed = true;
			}
		});
	}

	/// <summary>
	/// 通用导出EXCEL
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <param name="dataGridColumn">列表头</param>
	/// <param name="resultDto">导出的数据</param>
	/// <param name="excelName">excel名字</param>
	/// <param name="strFrontTranslates">前端翻译，格式为项和项之间分号分隔，项里面逗号分隔，如IS_MERGE,0,否;IS_MERGE,1,是</param>
	/// <param name="strSqlTranslate">Sql翻译,格式为项和项之间分号分隔，项里面逗号分隔,如ORG_ID,ORG_NAME;CARD_TYPE,CARD_TYPE_NAME</param>
	/// <returns>Stream流</returns>
	public Stream ExportCommonExcel<T>(string dataGridColumn, List<T> resultDto, string excelName, string strFrontTranslates = "", string strSqlTranslate = "") where T : DTOBase
	{
		ICommonExportcsService commonExportcsService = ServiceLocator.Instance.GetService<ICommonExportcsService>();
		return commonExportcsService.ExportCommonExcel(dataGridColumn, resultDto, excelName, strFrontTranslates, strSqlTranslate);
	}
}
