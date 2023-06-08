using System;
using Richfit.Garnet.Common.Configuration;
using Richfit.Garnet.Common.Extensions;
using Richfit.Garnet.Common.Patterns;
using Richfit.Garnet.Common.Threading;
using Richfit.Garnet.Module.Importing.Properties;

namespace Richfit.Garnet.Module.Importing;

/// <summary>
/// 导入器基类
/// </summary>
public abstract class Importer : IImporter, IDisposableObject, IDisposable
{
	/// <summary>
	/// 导入器名称
	/// </summary>
	private string name;

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
	/// 获取导入器名称
	/// </summary>
	public string Name
	{
		get
		{
			return name;
		}
		protected set
		{
			name = value.GuardNotNullAndEmpty(null, Literals.M_E_Importer_InvalidName);
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
	/// 使用默认配置初始指定名称的导入器
	/// </summary>
	/// <param name="name">导入器名称</param>
	protected Importer(string name)
	{
		View = null;
		Name = name;
		SyncRoot = new ReadWriteLocker();
		LoadConfiguration(null);
	}

	/// <summary>
	/// 使用指定的配置初始化导入器
	/// </summary>
	/// <param name="view">配置视图</param>
	protected Importer(IConfigurationView view)
	{
		View = view.GuardNotNull(null, Literals.M_E_Importer_Configuration_Missing);
		Name = view.Name;
		SyncRoot = view.Owner.SyncRoot;
		LoadConfiguration(view);
	}

	/// <summary>
	/// 析构清理
	/// </summary>
	~Importer()
	{
		Dispose(disposing: false);
	}

	/// <summary>
	/// 加载配置数据
	/// </summary>
	/// <param name="view">配置视图</param>
	protected abstract void LoadConfiguration(IConfigurationView view);

	/// <summary>
	/// 清理导入器对象
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
		if (disposing)
		{
			View = null;
		}
	}
}
