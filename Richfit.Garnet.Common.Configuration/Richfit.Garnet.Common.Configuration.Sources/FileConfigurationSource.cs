using System;
using System.IO;
using System.Text;
using Richfit.Garnet.Common.Extensions;
using Richfit.Garnet.Common.Patterns;
using Richfit.Garnet.Common.Watching;

namespace Richfit.Garnet.Common.Configuration.Sources;

/// <summary>
/// 基于文件的配置源
/// </summary>
public class FileConfigurationSource : ConfigurationSourceBase, IFileConfiguration, IConfiguration, IFileConfigurationSource, IRefreshableConfigurationSource, ISavableConfigurationSource, IWatchingConfigurationSource, IConfigurationSource, ISyncableObject, IDisposableObject, IDisposable
{
	/// <summary>
	/// 配置文件对象
	/// </summary>
	private FileInfo file;

	/// <summary>
	/// 配置文件编码, 默认是UTF-8
	/// </summary>
	private Encoding fileEncoding = Encoding.UTF8;

	/// <summary>
	/// 获取原始配置数据
	/// </summary>
	public override object RawData
	{
		get
		{
			return Bytes;
		}
		set
		{
			Bytes = ((value is byte[]) ? ((byte[])value) : new byte[0]);
		}
	}

	/// <summary>
	/// 获取或者设置配置源文件的编码类型
	/// 如果设置为null，则恢复默认值UTF-8
	/// </summary>
	public Encoding Encoding
	{
		get
		{
			return base.SyncRoot.Read(delegate
			{
				this.GuardNotDisposed();
				return fileEncoding;
			});
		}
		set
		{
			base.SyncRoot.Write(delegate
			{
				this.GuardNotDisposed();
				fileEncoding = value.IfNull(Encoding.UTF8);
			});
		}
	}

	/// <summary>
	/// 获取配置文件全名
	/// </summary>
	public string FullName => base.SyncRoot.Read(delegate
	{
		this.GuardNotDisposed();
		return file.FullName;
	});

	/// <summary>
	/// 获取配置文件对象
	/// </summary>
	public FileInfo File => base.SyncRoot.Read(delegate
	{
		this.GuardNotDisposed();
		return file;
	});

	/// <summary>
	/// 指示配置源文件是否存在
	/// </summary>
	public virtual bool Exists => base.SyncRoot.Read(delegate
	{
		this.GuardNotDisposed();
		file.Refresh();
		return file.Exists;
	});

	/// <summary>
	/// 获取或者设置配置源文本内容
	/// </summary>
	public virtual string Text
	{
		get
		{
			return base.SyncRoot.Read(delegate
			{
				this.GuardNotDisposed();
				return file.ReadText(Encoding);
			});
		}
		set
		{
			base.SyncRoot.Write(delegate
			{
				this.GuardNotDisposed();
				file.Write(value.IfNull(string.Empty), Encoding);
				LoadConfiguration();
			});
		}
	}

	/// <summary>
	/// 获取或者设置配置内容字节数组
	/// </summary>
	public byte[] Bytes
	{
		get
		{
			return base.SyncRoot.Read(delegate
			{
				this.GuardNotDisposed();
				return file.ReadBytes();
			});
		}
		set
		{
			base.SyncRoot.Write(delegate
			{
				this.GuardNotDisposed();
				file.Write(value.IfNull(new byte[0]));
				LoadConfiguration();
			});
		}
	}

	/// <summary>
	/// 获取文件监控器
	/// </summary>
	public IFileWatcher FileWatcher => base.SyncRoot.Read(delegate
	{
		this.GuardNotDisposed();
		return base.Watcher as IFileWatcher;
	});

	/// <summary>
	/// 创建配置源对象
	/// </summary>
	/// <param name="parentGroup">父配置组</param>
	/// <param name="sourceName">配置源名称</param>
	/// <param name="sourceFile">配置文件</param>
	/// <param name="watcher">配置源监控器</param>
	public FileConfigurationSource(IConfigurationSourceGroup parentGroup, string sourceName, string sourceFile, IWatcher watcher)
		: base(parentGroup, sourceName, watcher)
	{
		Initialize(sourceFile);
	}

	/// <summary>
	/// 创建配置源对象
	/// </summary>
	/// <param name="parentGroup">父配置组</param>
	/// <param name="sourceName">配置源名称</param>
	/// <param name="sourceFile">配置文件</param>
	/// <param name="timer">配置源监控定时器</param>
	public FileConfigurationSource(IConfigurationSourceGroup parentGroup, string sourceName, string sourceFile, IWatchingTimer timer)
		: base(parentGroup, sourceName, timer)
	{
		Initialize(sourceFile);
	}

	/// <summary>
	/// 初始化配置源对象
	/// </summary>
	/// <param name="file">配置源文件</param>
	private void Initialize(string file)
	{
		file.GuardNotNull();
		if (!file.IsAbsolutePath())
		{
			file = file.GetAbsolutePath();
		}
		this.file = new FileInfo(file);
		if (base.SourceName.IsNullOrEmpty())
		{
			base.SourceName = this.file.FullName;
		}
		base.Location = this.file.FullName;
		base.IsValid = LoadConfiguration();
		RegisterWatchingFile();
	}

	/// <summary>
	/// 析构
	/// </summary>
	~FileConfigurationSource()
	{
		Dispose(disposing: false);
	}

	/// <summary>
	/// 清理对象方法
	/// </summary>
	/// <param name="disposing"></param>
	protected override void Dispose(bool disposing)
	{
		if (disposing)
		{
			UnregisterWatchingFile();
			file = null;
		}
		base.Dispose(disposing);
	}

	/// <summary>
	/// 加载配置
	/// </summary>
	/// <returns>如果加载成功返回true，或者返回null</returns>
	protected virtual bool LoadConfiguration()
	{
		try
		{
			if (FileWatcher.IsNotNull())
			{
				FileWatcher.Refresh(file, notify: false);
			}
			file.Refresh();
			if (file.IsNull() || !file.Exists)
			{
				return base.IsValid = false;
			}
			return base.IsValid = true;
		}
		catch
		{
			throw;
		}
	}

	/// <summary>
	/// 刷新配置源
	/// </summary>
	public override void Refresh()
	{
		base.SyncRoot.Write(delegate
		{
			this.GuardNotDisposed();
			if (FileWatcher.IsNotNull())
			{
				FileWatcher.Refresh(file);
			}
		});
	}

	/// <summary>
	/// 保存配置源
	/// </summary>
	public override void Save()
	{
		base.SyncRoot.Write(delegate
		{
			this.GuardNotDisposed();
			LoadConfiguration();
		});
	}

	/// <summary>
	/// 获取配置内容字节流，调用者需要关闭该流
	/// </summary>
	/// <returns>配置内容字节流</returns>
	public Stream GetStream()
	{
		return base.SyncRoot.Write(delegate
		{
			this.GuardNotDisposed();
			return file.Open(FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);
		});
	}

	/// <summary>
	/// 创建文件监控器
	/// </summary>
	/// <param name="obj">基础监控器</param>
	/// <returns>创建的文件监控器</returns>
	protected override IWatcher CreateWatcher(object obj)
	{
		IFileWatcher watcher = null;
		if (obj.IsNull())
		{
			watcher = null;
		}
		else if (obj is IWatchingTimer)
		{
			watcher = new FileWatcher((IWatchingTimer)obj);
		}
		else if (obj is IFileWatcher)
		{
			watcher = (IFileWatcher)obj;
		}
		else
		{
			if (!(obj is IWatcher))
			{
				throw new ArgumentException();
			}
			watcher = new FileWatcher(obj.As<IWatcher>().WatchingTimer);
		}
		if (watcher.IsNotNull())
		{
			watcher.FileWatchingNotify += OnSourceWatchingNotify;
		}
		return base.CreateWatcher(watcher);
	}

	/// <summary>
	/// 清理监控器
	/// </summary>
	protected override void DisposeWatcher()
	{
		IFileWatcher watcher = base.Watcher as IFileWatcher;
		if (watcher.IsNotNull())
		{
			watcher.FileWatchingNotify -= OnSourceWatchingNotify;
		}
		base.DisposeWatcher();
	}

	/// <summary>
	/// 配置源变更处理
	/// 当允许监控时，如果配置源发生变更，则刷新配置源
	/// 当编辑配置源内容时，应关闭监控
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="args"></param>
	protected virtual void OnSourceWatchingNotify(object sender, FileWatchingEventArgs args)
	{
		base.SyncRoot.Write(delegate
		{
			if (!base.IsDisposed && base.IsWatching && file.FullName.EqualOrdinal(args.WatchingFile.FullName, ignoreCase: true))
			{
				switch (args.WatchingStatus)
				{
				case WatchingStatus.Unchanged:
					base.IsValid = true;
					break;
				case WatchingStatus.Changed:
					base.SourceID = Guid.NewGuid();
					base.IsValid = LoadConfiguration();
					OnSourceChanged(ConfigurationSourceStatus.Changed);
					break;
				case WatchingStatus.New:
					base.SourceID = Guid.NewGuid();
					base.IsValid = LoadConfiguration();
					OnSourceChanged(ConfigurationSourceStatus.New);
					break;
				case WatchingStatus.Missing:
					base.SourceID = Guid.NewGuid();
					base.IsValid = false;
					OnSourceChanged(ConfigurationSourceStatus.Missing);
					break;
				default:
					base.SourceID = Guid.NewGuid();
					base.IsValid = false;
					OnSourceChanged(ConfigurationSourceStatus.Invalid);
					break;
				}
			}
		});
	}

	/// <summary>
	/// 添加监控的文件源
	/// </summary>
	protected virtual void RegisterWatchingFile()
	{
		base.Watcher.As<IFileWatcher>().AddFile(file.FullName);
	}

	/// <summary>
	/// 移除监控的文件源
	/// </summary>
	protected virtual void UnregisterWatchingFile()
	{
		base.Watcher.As<IFileWatcher>().RemoveFile(file.FullName);
	}
}
