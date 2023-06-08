using System;
using Richfit.Garnet.Common.Configuration;
using Richfit.Garnet.Common.Configuration.Sources;
using Richfit.Garnet.Common.Extensions;
using Richfit.Garnet.Common.Patterns;
using Richfit.Garnet.Common.Threading;
using Richfit.Garnet.Module.Exporting.Properties;

namespace Richfit.Garnet.Module.Exporting;

/// <summary>
/// 导出器基类
/// </summary>
public abstract class Exporter : IExporter, IDisposableObject, IDisposable
{
	/// <summary>
	/// 导出器名称
	/// </summary>
	private string name = string.Empty;

	/// <summary>
	/// 同步对象
	/// </summary>
	private ISyncLocker syncRoot;

	/// <summary>
	/// 是否已经进行清理
	/// </summary>
	private bool isDisposed = false;

	/// <summary>
	/// 获取或者设置配置
	/// </summary>
	protected IConfigurationView View { get; set; }

	/// <summary>
	/// 获取导出器名称
	/// </summary>
	public string Name
	{
		get
		{
			return name;
		}
		protected set
		{
			name = value.GuardNotNullAndEmpty(null, Literals.MSG_E_InvalidExporterName);
		}
	}

	/// <summary>
	/// 同步对象
	/// </summary>
	public ISyncLocker SyncRoot
	{
		get
		{
			return syncRoot;
		}
		protected set
		{
			syncRoot = value;
		}
	}

	/// <summary>
	/// 获取是否已经进行清理的状态
	/// </summary>
	public bool IsDisposed => isDisposed;

	/// <summary>
	/// 使用默认配置初始指定名称的导出器
	/// </summary>
	/// <param name="name">导出器名称</param>
	protected Exporter(string name)
	{
		View = null;
		Name = name;
		SyncRoot = new ReadWriteLocker();
		LoadConfiguration(null);
	}

	/// <summary>
	/// 使用指定的配置进行初始化
	/// </summary>
	/// <param name="view">配置视图</param>
	protected Exporter(IConfigurationView view)
	{
		View = view.GuardNotNull(null, Literals.MSG_E_InvalidExporterConfiguration);
		Name = view.Name;
		SyncRoot = view.Owner.SyncRoot;
		View.Owner.SourceChanged += DoSourceChanged;
		LoadConfiguration(view);
	}

	/// <summary>
	/// 析构清理
	/// </summary>
	~Exporter()
	{
		Dispose(disposing: false);
	}

	/// <summary>
	/// 加载配置数据
	/// </summary>
	/// <param name="view">配置视图</param>
	protected abstract void LoadConfiguration(IConfigurationView view);

	/// <summary>
	/// 获取配置视图
	/// </summary>
	/// <param name="configuration">配置源</param>
	/// <returns>当前导出器使用的配置视图，未找到返回null</returns>
	protected abstract IConfigurationView GetConfigurationView(IViewsConfiguration configuration);

	/// <summary>
	/// 配置源变更处理
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="args"></param>
	private void DoSourceChanged(object sender, ConfigurationSourceChangedEventArgs args)
	{
		if (args.Status == ConfigurationSourceStatus.Changed)
		{
			IConfigurationView view = GetConfigurationView((IViewsConfiguration)args.Source);
			if (view.IsNotNull())
			{
				View = view;
				LoadConfiguration(view);
			}
		}
	}

	/// <summary>
	/// 清理导出器对象
	/// </summary>
	public void Dispose()
	{
		syncRoot.Write(delegate
		{
			if (!isDisposed)
			{
				Dispose(disposing: true);
				GC.SuppressFinalize(this);
				isDisposed = true;
			}
		});
	}

	/// <summary>
	/// 执行清理
	/// </summary>
	/// <param name="disposing"></param>
	protected virtual void Dispose(bool disposing)
	{
		if (disposing && View.IsNotNull())
		{
			View.Owner.SourceChanged -= DoSourceChanged;
			View = null;
		}
	}
}
