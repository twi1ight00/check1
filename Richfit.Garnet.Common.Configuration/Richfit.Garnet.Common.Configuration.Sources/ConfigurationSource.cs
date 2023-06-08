using System;
using Richfit.Garnet.Common.Extensions;
using Richfit.Garnet.Common.Patterns;
using Richfit.Garnet.Common.Threading;

namespace Richfit.Garnet.Common.Configuration.Sources;

/// <summary>
/// 配置源基类
/// </summary>
public abstract class ConfigurationSource : IConfigurationSource, ISyncableObject, IDisposableObject, IDisposable
{
	/// <summary>
	/// 是否已经被清理
	/// </summary>
	private bool isDisposed;

	/// <summary>
	/// 共享锁
	/// </summary>
	private ISyncLocker syncLocker;

	/// <summary>
	/// 配置源ID
	/// </summary>
	private Guid sourceID;

	/// <summary>
	/// 配置源名称
	/// </summary>
	private string sourceName;

	/// <summary>
	/// 配置源类型
	/// </summary>
	private Type sourceType;

	/// <summary>
	/// 配置源类别
	/// </summary>
	private string category;

	/// <summary>
	/// 配置源位置
	/// </summary>
	private string location;

	/// <summary>
	/// 配置源有效状态
	/// </summary>
	private bool isValid;

	/// <summary>
	/// 配置源的父配置组
	/// </summary>
	private IConfigurationSourceGroup ownerGroup;

	/// <summary>
	/// 指示是否已经被清理
	/// </summary>
	public bool IsDisposed
	{
		get
		{
			return syncLocker.Read(() => isDisposed);
		}
		protected set
		{
			isDisposed = value;
		}
	}

	/// <summary>
	/// 获取共享锁
	/// </summary>
	public ISyncLocker SyncRoot
	{
		get
		{
			return syncLocker;
		}
		protected set
		{
			syncLocker = value;
		}
	}

	/// <summary>
	/// 获取配置源的ID
	/// </summary>
	public Guid SourceID
	{
		get
		{
			return syncLocker.Read(delegate
			{
				this.GuardNotDisposed();
				return sourceID;
			});
		}
		protected set
		{
			sourceID = value;
		}
	}

	/// <summary>
	/// 获取配置源名称
	/// </summary>
	public string SourceName
	{
		get
		{
			return syncLocker.Read(delegate
			{
				this.GuardNotDisposed();
				return sourceName;
			});
		}
		protected set
		{
			sourceName = value.IfNull(string.Empty);
		}
	}

	/// <summary>
	/// 获取或者设置配置源类型，根据该类型可以生成配置源对象
	/// </summary>
	public Type SourceType
	{
		get
		{
			return syncLocker.Read(delegate
			{
				this.GuardNotDisposed();
				return sourceType;
			});
		}
		set
		{
			syncLocker.Write(delegate
			{
				this.GuardNotDisposed();
				sourceType = value;
			});
		}
	}

	/// <summary>
	/// 获取或者设置配置源类别
	/// </summary>
	public string Category
	{
		get
		{
			return syncLocker.Read(delegate
			{
				this.GuardNotDisposed();
				return category;
			});
		}
		set
		{
			syncLocker.Write(delegate
			{
				this.GuardNotDisposed();
				category = value.IfNull(string.Empty);
			});
		}
	}

	/// <summary>
	/// 获取配置源位置
	/// </summary>
	public string Location
	{
		get
		{
			return syncLocker.Read(delegate
			{
				this.GuardNotDisposed();
				return location;
			});
		}
		protected set
		{
			location = value.IfNull(string.Empty);
		}
	}

	/// <summary>
	/// 获取配置源是否有效
	/// </summary>
	public bool IsValid
	{
		get
		{
			return syncLocker.Read(() => isValid);
		}
		protected set
		{
			isValid = value;
		}
	}

	/// <summary>
	/// 获取原始配置数据
	/// </summary>
	public virtual object RawData
	{
		get
		{
			return syncLocker.Read((Func<object>)delegate
			{
				this.GuardNotDisposed();
				return null;
			});
		}
		set
		{
			syncLocker.Write(delegate
			{
				this.GuardNotDisposed();
			});
		}
	}

	/// <summary>
	/// 获取配置源所属的父配置组,如果不属于任何配置组则返回null.
	/// </summary>
	public IConfigurationSourceGroup Owner
	{
		get
		{
			return syncLocker.Read(delegate
			{
				this.GuardNotDisposed();
				return ownerGroup;
			});
		}
		protected set
		{
			ownerGroup = value;
		}
	}

	/// <summary>
	/// 获取配置视图
	/// </summary>
	public virtual IConfigurationView View => null;

	/// <summary>
	/// 初始化配置源
	/// </summary>
	protected ConfigurationSource()
		: this(null)
	{
	}

	/// <summary>
	/// 初始化配置源
	/// </summary>
	/// <param name="locker">同步锁对象</param>
	protected ConfigurationSource(ISyncLocker locker)
	{
		syncLocker = locker.IfNull(new ReadWriteLocker());
		isDisposed = false;
		isValid = true;
		sourceID = Guid.NewGuid();
		sourceName = string.Empty;
		category = string.Empty;
		ownerGroup = null;
	}

	/// <summary>
	/// 清理配置管理器
	/// </summary>
	~ConfigurationSource()
	{
		Dispose(disposing: false);
	}

	/// <summary>
	/// 清理对象
	/// </summary>
	public virtual void Dispose()
	{
		syncLocker.Write(delegate
		{
			if (!isDisposed)
			{
				Dispose(disposing: true);
				GC.SuppressFinalize(this);
			}
		});
	}

	/// <summary>
	/// 清理对象方法
	/// </summary>
	/// <param name="disposing"></param>
	protected virtual void Dispose(bool disposing)
	{
		if (disposing)
		{
			isDisposed = true;
			isValid = false;
			SourceID = Guid.NewGuid();
		}
	}
}
